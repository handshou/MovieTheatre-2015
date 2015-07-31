/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the ConnectionHandler that handles each thread
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

/// https://www.youtube.com/watch?v=0VmFdYWdSSU - Serialize Deserialize into Collection

namespace MvSvr {

    class ConnectionHandler {

        // Attributes
        private string cmd;
        private string user;

        readonly object _object = new object();

        private String browseFile = @"browse.dat";
        private String searchFile = @"search.dat";
        private String bseatsFile = @"bseats.dat";
        private String bkHistFile = @"bkrepo.dat";
        private String moviesFile = @"movies.dat";

        private int size = 0;
        private long filesize = 0;
        private static int connections = 0;
        private byte[] data = new byte[1024];

        private FileInfo f;
        private FileStream fs;
        private NetworkStream ns;
        private IFormatter formatter = new BinaryFormatter();

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String SFOUND = "[SRHF]";
        public const String SEMPTY = "[SRHE]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";
        public const String HISTRY = "[HSTY]";
        public const String SUCCESS = "[BKSS]";
        public const String FAILURE = "[BKFL]";

        // Connection Attributes
        private Form1 form;
        private Socket client;
        private Dictionary<String, Socket> clients = new Dictionary<String, Socket>();
        private Dictionary<String, Movie> movieInfo = new Dictionary<String, Movie>();
        private Dictionary<String, List<Booking>> bookingInfo = new Dictionary<String, List<Booking>>();

        private MethodInvoker miv;

        // Constructor
        public ConnectionHandler(Socket client, Form1 form, 
            ref Dictionary<String, Movie> movieInfo, 
            ref Dictionary<String, List<Booking>> bookingInfo, 
            ref Dictionary<String, Socket> clients) {

            this.client = client;
            this.form = form;
            this.movieInfo = movieInfo;
            this.clients = clients;
            this.bookingInfo = bookingInfo;
        }

        // Methods
        public void HandleConnection(Object state) {

            miv = new MethodInvoker(form.UpdateClientListBox);

            int size = 0;
            try {
                ns = new NetworkStream(client);
                connections++;

                /* R */
                // Receive user
                data = new byte[1024];
                user = ReceiveCommand();
                if (!clients.ContainsKey(user)) {
                    clients.Add(user, client);
                    SendCommand(SUCCESS);

                    DisplayConnectMsg(connections);
                    form.BeginInvoke(miv);
                    Thread.Sleep(300);

                    while (true) {
                        lock (_object) {
                            //movieInfo = LoadMovieFile(moviesFile);

                            /* R */
                            // Receive command
                            cmd = ReceiveCommand();
                            form.DisplayMsg("[" + user + "] :: " + cmd); // (!) Remove when complete

                            switch (cmd) {
                                case BROWSE: Browse();
                                    break;
                                case SEARCH: Search();
                                    break;
                                case BOOKNG: Book();
                                    break;
                                case HISTRY: History();
                                    break;
                                case FINISH: Quit();
                                    break;
                                default: form.DisplayMsg("[" + user + "] :: Unknown command");
                                    break;
                            }
                            if (cmd == FINISH)
                                break;
                        }
                    }
                } else {
                    SendCommand(FAILURE);
                    form.DisplayMsg("[Server] Detected attempted login");
                }

            } catch (SocketException) {

                clients.Remove(user);
                connections--;
                form.BeginInvoke(miv);
                Thread.Sleep(300);

                DisplayDisconnectMsg(connections);

            } catch (Exception ex) {

                form.DisplayMsg(ex.ToString());
            }
            // Consider implementing abort thread
        }

        public void Browse() {

            //lock (_object) {
                SaveToFile(browseFile, movieInfo);
                SendFile(browseFile);
            //}
        }

        public void Search() {

            String type = "", 
                   terms = "";
            //Thread.Sleep(1000);
            /* R */ // Receive search type + terms
            terms = ReceiveTypeTerms(out type);

            // type = ReceiveCommand();
            form.DisplayMsg(type);
            // terms = ReceiveCommand().ToLower();
            form.DisplayMsg(terms);

            Dictionary<String, Movie> searchInfo;
            searchInfo = SearchMovies(type, terms);

            /* S */ // Send empty
            if (searchInfo.Count == 0)
                SendCommand(SEMPTY);
            else {
            /* S */ // Send found
            /* S */ // Send file
                SendCommand(SFOUND);
                SaveToFile(searchFile, searchInfo);
                SendFile(searchFile);
            }
        }

        public Dictionary<String, Movie> SearchMovies(String type, String terms){

            Dictionary<String, Movie> d = new Dictionary<String, Movie>();
            foreach (KeyValuePair<String, Movie> m in movieInfo) {
                if (type == "Genre") {
                    if (m.Value.Genre.ToLower().Contains(terms.ToLower())) {
                        d.Add(m.Key, m.Value);
                    }
                } else
                if (type == "Director") {
                    if (m.Value.Director.ToLower().Contains(terms.ToLower())) {
                        d.Add(m.Key, m.Value);
                    }
                } else
                if (type == "Name") {
                    if (m.Key.ToLower().Contains(terms.ToLower())) {
                        d.Add(m.Key, m.Value);
                    }
                }
            }
            return d;
        }

        public void Book() {

            //lock (_object) { // get userid title time seatindex price

                Boolean bookingSuccess = true;
                Show show = new Show();
                List<Seat> seats = new List<Seat>();
                
                /* R */ // Receive booking info
                /* R */
                ReceiveFile(bseatsFile);
                seats = LoadSeatsFile(bseatsFile, out show);

                // Create booking from seats
                Booking bnew = new Booking(user, show, seats);

                // Get server movie
                Movie bookMovie = show.Movie;
                Movie serverMovie = null;
                foreach (Movie m in movieInfo.Values) {
                    if (m.Title.Equals(bookMovie.Title)) {
                        serverMovie = m;
                    }
                }

                // Get server show
                Show serverShow = null;
                foreach (Show s in serverMovie.Shows) {
                    if (s.Date.Equals(show.Date) && s.TimeStart.Equals(show.TimeStart)) {
                        serverShow = s;
                    }
                }

                List<Seat> serverSeats = serverShow.Hall.Seats;
                form.DisplayMsg("[" + user + "] :: [" + serverMovie.Title + "] [" + serverShow.Date + "] [" + serverShow.TimeStart + "]");

                // Turn seat to unavailable : (!) consider using Dictionary collection
                foreach(Seat seat in seats) {
                    foreach (Seat serverSeat in serverSeats) {
                        if (seat.Name.Equals(serverSeat.Name)) {
                            if (!serverSeat.Vacant) {
                                bookingSuccess = false;
                                // form.DisplayMsg(seat.Name + " is not vacant"); // (!) Debug
                            }
                        }
                    }
                }

                if (bookingSuccess) {

                    foreach (Seat seat in seats) {
                        foreach (Seat serverSeat in serverSeats) {
                            if (seat.Name.Equals(serverSeat.Name)) {
                                serverSeat.Vacant = false;
                                //form.DisplayMsg(serverSeat.Name + " has been updated to " + // (!) Debug
                                //    serverSeat.Vacant.ToString());
                            }
                        }
                    }

                    // Save movie info
                    SaveMovieToFile(moviesFile);

                    // Update booking history
                    List<Booking> userBookingHistory = new List<Booking>();

                    if (!bookingInfo.TryGetValue(user, out userBookingHistory)) {
                        userBookingHistory = new List<Booking>();
                    }
                    userBookingHistory.Add(bnew);
                    
                    // Save into booking repository
                    bookingInfo[user] = userBookingHistory;
                    //form.DisplayMsg(userBookingHistory[0].Show.Movie.Title.ToString()); // (!) Debug
                    
                    // Save booking info                   
                    SaveBookingToFile(bkHistFile);

                    SendCommand(SUCCESS);
                    form.DisplayMsg("[" + user + "] :: [Booking] success");

                } else {

                    SendCommand(FAILURE);
                    form.DisplayMsg("[" + user + "] :: [Booking] failed");

                }
            //}
        }

        public void Quit() {

            if (ns != null)
                ns.Close();
            if (client != null)
                client.Close();

            clients.Remove(user);
            connections--;
            form.BeginInvoke(miv);
            DisplayDisconnectMsg(connections);
        }

        public void History() {

            Booking b = new Booking(); Show s = new Show();
            List<Seat> seats; Seat seat = new Seat();
            List<Booking> bookingList = new List<Booking>();
            //bookingInfo = LoadBookingFile(bkHistFile);
            bookingInfo.TryGetValue(user, out bookingList);

            String info_str = "";

            if (bookingList == null) {
            // No History

                info_str = "There are no booking records found";

            } else {
            // Fetch History

                // Building String..
                // e.g. [7/31/2015 10:40:33 AM]  [The Dark Knight] 1 January 2015 > 0800 - 1000 : Seats A1 
                String seats_str = "";
                for (int i = 0; i < bookingList.Count; i++) {
                    b = bookingList[i];
                    s = b.Show;
                    seats = b.Seats;
                    seats_str = "";
                    for (int h = 0; h < seats.Count; h++) {
                        seat = b.Seats[h];
                        seats_str += seat.Name + " ";
                    }
                    info_str += "[" + b.BookingTime + "] " + " [" + s.Movie.Title + "] " +
                                        s.Date + " > " + s.TimeStart + " - " + s.TimeEnd + " : " +
                                        b.Show.Hall.Name + " : Seats " + seats_str;
                    info_str += ENDOFF;
                }
            }

            SendCommand(info_str);
        }

        public void SaveToFile(String filePath, Dictionary<String, Movie> d) {

            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, d.Values.ToArray());
                fs.Close();
            }
        }

        public void SaveMovieToFile(String filePath) {

            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, movieInfo.Values.ToArray());
                fs.Close();
            }
            //form.DisplayMsg("Saved movies database to " + filePath); (!)
        }

        public void SaveBookingToFile(String filePath) {

            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, bookingInfo.Values.ToArray());
                fs.Close();
            }
            //form.DisplayMsg("Saved booking database to " + filePath); (!)
        }

        public String ReceiveTypeTerms(out String type) {

            String terms = "";
            data = new byte[1024];
            size = client.Receive(data);
            String typeterms = Encoding.ASCII.GetString(data, 0, size);

            String[] substring = typeterms.Split(';');
            type = substring[0];
            terms = substring[1];

            return terms;
        }

        public String ReceiveCommand() {

            data = new byte[1024];
            size = client.Receive(data);

            return Encoding.ASCII.GetString(data, 0, size);
        }

        public void SendCommand(String cmd) {

            data = new byte[1024];
            data = Encoding.ASCII.GetBytes(cmd);
            size = client.Send(data);
        }

        public void SendFile(String filePath) {

            f = new FileInfo(filePath);
            filesize = f.Length;
            data = new byte[filesize];

            /* S */ // Sending file size
            client.Send(Encoding.ASCII.GetBytes(filesize.ToString()));

            /* S */ // Sending file
            byte[] buffer = null;
            using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
            }

            try {
                client.Send(buffer);
                form.DisplayMsg("[" + user + "] :: File sent"); // (!) Remove when complete
            } catch (Exception ex) {
                form.DisplayMsg(ex.ToString());
            }
        }

        public void ReceiveFile(String filePath) {

            /* R */ // Receive file size
            int size = 0;
            data = new byte[1024];
            try {
                size = client.Receive(data);
            } catch (Exception ex) {
                form.DisplayMsg("Error receiving file (filesize)\n" + ex.ToString());
            }
            filesize = Convert.ToInt64(Encoding.ASCII.GetString(data));

            /* R */ // Receive file
            data = new byte[filesize];
            try {
                size = client.Receive(data);
                form.DisplayMsg("[" + user + "] :: File received"); // (!) Remove when complete
            } catch (Exception ex) {
                form.DisplayMsg("Error receiving file (file)\n" + ex.ToString());
            }
            
            // Will overwrite existing file
            using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write)) {
                fs.Write(data, 0, Convert.ToInt32(filesize));
                fs.Flush();
                fs.Close();
            }
        }

        public Dictionary<String, List<Booking>> LoadBookingFile(String filePath) {

            Dictionary<String, Booking> 
                bookingInfoBuilder = new Dictionary<String, Booking>();
            Dictionary<String, List<Booking>>
                bookingInfo = new Dictionary<String, List<Booking>>();

            try {
                using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read)) {
                    Booking[] b_info = (Booking[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    /// Key             Value
                    /// UserA + Time    BookingCopy1
                    /// UserA + Time    BookingCopy2
                    /// UserB + Time    BookingCopy3
                    bookingInfoBuilder = b_info.ToDictionary((u) => 
                        (u.User).Insert(u.User.Length + 1, u.BookingTime.ToString()), (u) => u);
                    
                    foreach(Booking ub in bookingInfoBuilder.Values){
                        if(!bookingInfo.ContainsKey(ub.User)){
                            bookingInfo.Add(ub.User, new List<Booking>());
                        }
                    }

                    foreach(List<Booking> b in bookingInfo.Values){
                        foreach(Booking ub in bookingInfoBuilder.Values){
                            for(int i = 0; i < b.Count; i++) {
                                if(ub.User.Equals(b[i].User))
                                    b.Add(ub);
                            }
                        }
                    }

                    //String userbuilder = "";
                    //foreach(var item in myDictionary){
                    //    foo(item.Key);
                    //    bar(item.Value);
                    //}

                    //foreach(KeyValuePair<String, Booking> p in bookingInfoBuilder) {
                    //    foreach (KeyValuePair<String, Booking> u in bookingInfoBuilder) {
                    //        userbuilder = u.Value.User;
                    //        if(!bookingInfo.ContainsKey(userbuilder))
                    //            bookingInfo.Add(userbuilder, )
                    //    }
                    //}
                }
            } catch (Exception ex) {
                form.DisplayMsg(ex.ToString());
            }
            return bookingInfo;
        }

        public Dictionary<String, Movie> LoadMovieFile(String filePath) {

            Dictionary<String, Movie> movieInfoNew = new Dictionary<String, Movie>();
            try {
                using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    Movie[] m_info = (Movie[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    movieInfo = m_info.ToDictionary((u) => u.Title, (u) => u);

                    foreach (KeyValuePair<String, Movie> infos in movieInfo) {
                        Movie mv = new Movie(infos.Value.Title, infos.Value.Description,
                            infos.Value.Director, infos.Value.Genre, infos.Value.Shows, infos.Value.Poster);

                        movieInfoNew.Add(mv.Title, mv);
                    }
                    
                }
            } catch (Exception ex) {
                form.DisplayMsg(ex.ToString());
            }
            return movieInfoNew;
        }

        public List<Seat> LoadSeatsFile(String filePath, out Show show) {

            List<Seat> output = new List<Seat>();
            show = new Show();
            try {
                using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    Object[] obj_info = (Object[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    show = (Show) obj_info[0];
                    int sz = (int)obj_info[1];

                    // form.DisplayMsg(obj_info.Length.ToString());

                    // Add seats - potential indexoutofrange exception
                    for(int i = 2; i < sz; i++) {
                        output.Add((Seat) obj_info[i]);
                    }
                }
            } catch (Exception ex) {
                form.DisplayMsg(ex.ToString());
            }
            return output;
        }

        public void DisplayConnectMsg(int connections) {

            if (connections == 1)
                form.DisplayMsg("[" + user + "] connected\n[Server] " + connections + " active connection");
            else
                form.DisplayMsg("[" + user + "] connected\n[Server] " + connections + " active connections");
        }

        public void DisplayDisconnectMsg(int connections) {

            if (connections == 1)
                form.DisplayMsg("[" + user + "] disconnected\n[Server] " + connections + " remaining connection");
            else
                form.DisplayMsg("[" + user + "] disconnected\n[Server] " + connections + " remaining connections");
        }
    }
}
