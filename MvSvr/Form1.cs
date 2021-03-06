﻿/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This section covers the server side GUI and program
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MvSvr {
    public partial class Form1 : Form {
        // Attributes
        private String moviesFile = @"movies.dat";
        private String browseFile = @"browse.dat";
        private String bkHistFile = @"bkrepo.dat";
        private FileStream fs;
        private IFormatter formatter = new BinaryFormatter();
        private Dictionary<String, Movie> movieInfo = new Dictionary<String, Movie>();
        private Dictionary<String, List<Booking>> bookingInfo = new Dictionary<String, List<Booking>>();
        private Dictionary<String, List<Booking>> bkGroupByShow = new Dictionary<String, List<Booking>>();

        // Connection Attributes
        private byte[] data = new byte[1024];
        private static int port = 9070;
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Dictionary<String, Socket> clients = new Dictionary<String, Socket>();
        private Dictionary<String, String> clientsNumber = new Dictionary<String, String>();

        private const String BRCAST = "[BRCA]";

        public delegate void DisplayMsgCallback(String msg);
        public delegate void DisplayMsgMoviesCallback(String msg);
        public delegate void DisplayMsgShowsCallback(String msg);

        public Form1() {
            InitializeComponent();
            this.Text = "Server";
            //LoadMovies();
            DeserializeMovies(moviesFile);
            DeserializeBookings(bkHistFile);
            //bookingInfo = DeserializeBookings(bkHistFile); // Load booking info
            Thread t = new Thread(ConnectClient);
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// Accepts connections from clients and creates a thread for each connection.
        /// </summary>
        public void ConnectClient() {
            DisplayMsg("[Server] Initialised!");
            DisplayMsgMovies("[Server] Initialised!");
            DisplayMsgShows("[Server] Initialised!");
            server.Bind(endpoint);
            server.Listen(10);
            while(true) {
                try {
                    Socket client = server.Accept();
                    //clients.Add(client);
                    ConnectionHandler handler = 
                        new ConnectionHandler(client, this, movieInfo, 
                            bookingInfo, clients, clientsNumber);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(handler.HandleConnection));
                } catch(Exception ex) {
                    // Error output
                    DisplayMsg("Connection failed on port " + port + "\r\n");
                    DisplayMsg(ex.ToString());
                }
            }
        }        
        /// <summary>
        /// Provides a base of movies for server to reset all movies and bookings saved.
        /// Overwrites and saves to moviesFile location.
        /// </summary>
        public void LoadMovies() {
            movieInfo = new Dictionary<String, Movie>();

            Movie m = new Movie();
            m.Title = "The Dark Knight";
            m.Genre = "Superhero";
            m.Description = "Welcome to a world without rules. The sequel to Nolan's Batman Begins, The Dark Knight reveals a new but familiar enemy for the vigilante superhero.";
            m.Director = "Christopher Nolan";
            m.Poster = GetImage("poster\\the_dark_knight.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "1 January 2015", new Hall("Theatre 1"), "0800", "1000", 8.00),
                new Show(m, "1 January 2015", new Hall("Theatre 2"), "1600", "1800", 8.00),
                new Show(m, "2 January 2015", new Hall("Theatre 3"), "0800", "1000", 8.00),
                new Show(m, "2 January 2015", new Hall("Theatre 4"), "1600", "1800", 8.00),
                new Show(m, "3 January 2015", new Hall("Theatre 5"), "1600", "1800", 10.00),
                new Show(m, "3 January 2015", new Hall("Theatre 6"), "2000", "2200", 12.00),
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Batman Beyond";
            m.Genre = "Animated";
            m.Description = "Batman Beyond (known as Batman of the Future in Europe, Latin America, Australia and India) is an American animated television series created by Warner Bros. "
            + "Animation in collaboration with DC Comics as a continuation of the Batman legacy.";
            m.Director = "Bruce Timm";
            m.Poster = GetImage("poster\\batman_of_the_future.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "3 July 2015", new Hall("Theatre 1"), "0900", "1100", 8.00),
                new Show(m, "3 July 2015", new Hall("Theatre 2"), "1700", "1900", 10.00),
                new Show(m, "3 July 2015", new Hall("Theatre 3"), "2100", "2300", 12.00)
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Inception";
            m.Genre = "Science Fiction - Thriller";
            m.Description = "Your mind is the scene of the crime. Dom Cobb is a professional thief who commits corporate espionage in the most lucid way - via dreams.";
            m.Director = "Christopher Nolan";
            m.Poster = GetImage("poster\\inception_poster.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "3 July 2015", new Hall("Theatre 1"), "1820", "2020", 12.00),
                new Show(m, "4 July 2015", new Hall("Theatre 2"), "1300", "1500", 12.00),
                new Show(m, "5 July 2015", new Hall("Theatre 3"), "0030", "0230", 10.00)
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Terminator 2 : Judgement Day";
            m.Genre = "Science Fiction - Action";
            m.Description = "It's nothing personal. The sequel to the 1984 Terminator. Arnold Schwarzenegger is back as a cyborg Terminator. Now available in seasonal showings.";
            m.Director = "James Cameron";
            m.Poster = GetImage("poster\\terminator2.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "2 March 2015",     new Hall("Theatre 1"), "1850", "2050", 12.00),
                new Show(m, "4 September 2015", new Hall("Theatre 2"), "1500", "1700", 12.00),
                new Show(m, "6 December 2015",  new Hall("Theatre 3"), "1230", "1430", 12.00)
            };

            movieInfo.Add(m.Title, m);
            SerializeMovies(moviesFile);
        }
        /// <summary>
        /// Updates and refreshes the server-side client information with their user display when they connect and disconnect from the server.
        /// </summary>
        public void UpdateClientListBox()
        {
            libClientsMovies.Items.Clear();
            libClientsShows.Items.Clear();
            libClientsDebug.Items.Clear();
            foreach (KeyValuePair<String, String> client in new SortedDictionary<String, String>(clientsNumber)) {
                libClientsMovies.Items.Add(client.Value);
                libClientsShows.Items.Add(client.Value);
                libClientsDebug.Items.Add(client.Value);
            }
            libClientsMovies.Sorted = true;
            libClientsShows.Sorted = true;
            libClientsDebug.Sorted = true;
        }
        /// <summary>
        /// This method takes in a movie index, and populates the lbShowDays listbox of the Add Shows tab.
        /// </summary>
        /// <param name="index">Index of selected movie in listbox, lbMovies.</param>
        public void UpdateShowDaysList(int index)
        {
            // Show Days
            lbShowDays.Items.Clear();
            lbShows.Items.Clear();
            Movie selectedMovie = movieInfo.Values.ElementAt(index);
            List<String> showDates = selectedMovie.GetDates();

            foreach (String sDate in showDates) {
                lbShowDays.Items.Add(sDate);
            }

            if (lbShowDays.Items.Count != 0) {
                lbShowDays.SelectedIndex = 0;
            }

            if (showDates.Count == 0) {
                lbShowDays.Items.Add("No show days");
            }
        }
        /// <summary>
        /// This method takes bookingInfo collection and groups them into a new collection bkGroupByShow by Show.
        /// Used in the Show Info tab.
        /// </summary>
        public void bookingsByShow()
        {
            List<Booking> bookings = new List<Booking>();
            //Dictionary<String, List<Booking>> bookingInfo
            foreach (List<Booking> bkList in bookingInfo.Values) {
                foreach (Booking b in bkList) {
                    bookings.Add(b);
                }
            }
            //List<Booking> bookings = bookingInfo.Values;
            bkGroupByShow = bookings.GroupBy(u => u.Show.ToString()).ToDictionary(g => g.Key, g => g.ToList());
        }

        public void SerializeMovies(String filePath)
        {
            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, movieInfo.Values.ToArray());
                fs.Close();
            }
            //form.DisplayMsg("Saved movies database to " + filePath); (!)
        }
        public void SerializeBookings(String filePath)
        {
            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, bookingInfo.Values.ToArray());
                fs.Close();
            }
            //form.DisplayMsg("Saved booking database to " + filePath); (!)
        }
        public void DeserializeBookings(String filePath)
        {
            try {
                using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read)) {
                    List<Booking>[] blist_info = (List<Booking>[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    bookingInfo = blist_info.ToDictionary((u) => (u[0].User), (u) => u);
                }
                tbDisplay.AppendText("Load Bookings: Successful" + "\r\n");
            } catch (Exception ex) {
                tbDisplay.AppendText("Load Bookings: Failed" + "\r\n" + ex.ToString() +"\r\n");
            }
        }
        public Dictionary<String, Movie> DeserializeMovies(String filePath)
        {
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
                tbDisplay.AppendText("Load Movies: Successful" + "\r\n");
            } catch (Exception ex) {
                tbDisplay.AppendText("Load Movies File Error: \r\n" + ex.ToString() + "\r\n");
            }
            return movieInfoNew;
        }
        public void DisplayMsg(String msg) {
            if (this.InvokeRequired) {
                DisplayMsgCallback d = new DisplayMsgCallback(DisplayMsg);
                this.Invoke(d, msg);
                return;
            }
            string[] lines = msg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++) {
                tbDisplay.AppendText(lines[i] + "\r\n");
            }
        }
        public void DisplayMsgMovies(String msg) {
            if (this.InvokeRequired) {
                DisplayMsgMoviesCallback d = new DisplayMsgMoviesCallback(DisplayMsgMovies);
                this.Invoke(d, msg);
                return;
            }
            string[] lines = msg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++) {
                tbMovies.AppendText(lines[i] + "\r\n");
            }
        }
        public void DisplayMsgShows(String msg) {
            if (this.InvokeRequired) {
                DisplayMsgShowsCallback d = new DisplayMsgShowsCallback(DisplayMsgShows);
                this.Invoke(d, msg);
                return;
            }
            string[] lines = msg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++) {
                tbShows.AppendText(lines[i] + "\r\n");
            }
        }
        public Image GetImage(String imgPath)
        {
            Image img = Image.FromFile(@imgPath);
            return img;
        }

        // TAB CONTROL
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show Bookings
            if (tabControl.SelectedIndex == 3) {
                lbShowBkMovies.Items.Clear();
                lbShowBkShowDays.Items.Clear();
                lbShowBkShows.Items.Clear();
                tbShowBookings.Clear();
                foreach (KeyValuePair<String, Movie> kvp in movieInfo/*new SortedDictionary<String, Movie>(movieInfo)*/) {
                    lbShowBkMovies.Items.Add(kvp.Key);
                }
            }

            // Booking
            if (tabControl.SelectedIndex == 2) {
                lbBookings.Items.Clear();
                foreach (KeyValuePair<String, List<Booking>> kvp in bookingInfo) {
                    lbBookings.Items.Add(kvp.Key);
                }
                tbBookings.Text = "Select a user to view their booking information";
            }
            // Shows
            if (tabControl.SelectedIndex == 1) {
                lbMovies.Items.Clear();
                lbShowDays.Items.Clear();
                lbShows.Items.Clear();
                foreach (KeyValuePair<String, Movie> movie in movieInfo) {
                    lbMovies.Items.Add(movie.Key);
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e) {
            tbMovies.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            //// Create the movie and shows
            String title, desc, dir, genre, imgPath = "";
            Boolean hasImage = false;

            title    = tbTitle.Text;
            desc     = tbDescription.Text;
            dir      = tbDirector.Text;
            genre    = tbGenre.Text;
            if (tbImage.Text.Trim().Length != 0 && !tbImage.Text.Trim().Equals("poster\\")) {
                hasImage = true;
                imgPath = tbImage.Text;
            }

            Movie m = new Movie(title, desc, dir, genre);
            if (!movieInfo.ContainsKey(m.Title)) {
                if (hasImage) {
                    try {
                        m.Poster = GetImage(imgPath);
                    } catch {
                        DisplayMsgMovies("Unable to process image");
                    }
                }
                movieInfo.Add(m.Title, m);

                DisplayMsgMovies("New Movie: " + m.Title + " added");
                DisplayMsgShows("New Movie: " + m.Title + " added");

                lbMovies.Items.Clear();
                foreach (KeyValuePair<String, Movie> movie in movieInfo) {
                    lbMovies.Items.Add(movie.Key);
                }

                tabControl.SelectedTab = tabPageShows;
                lbMovies.SelectedIndex = lbMovies.Items.Count - 1;
            } else {
                DisplayMsgMovies("Movie already exists. Please use another title.");
            }
        }
        private void btnDebugClear_Click(object sender, EventArgs e) { tbDisplay.Clear(); }
        private void btnBroadcast_Click(object sender, EventArgs e) {
            foreach (Socket client in clients.Values) {
                data = Encoding.ASCII.GetBytes(BRCAST);
                client.Send(data);
            }
            DisplayMsgMovies("[Server] Broadcasting to all connected clients...");
        }
        private void btnWipe_Click(object sender, EventArgs e) {
            // Wipes all saved movies and alterations made 
            // by server administrator and loads repository defaults
            if (MessageBox.Show("Restore to default?", "Movies Repository",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                LoadMovies();
                bookingInfo = new Dictionary<String, List<Booking>>();
                bkGroupByShow = new Dictionary<String, List<Booking>>();
                SerializeBookings(bkHistFile);
                DisplayMsgMovies("[Server] Movies Repository wiped to default");
                DisplayMsgShows("[Server] Movies Repository wiped to default");
                DisplayMsg("[Server] Movies Repository wiped to default");
            }
        }
        private void btnList_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            DisplayMsgMovies("[Movie Listing]");
            foreach (KeyValuePair<String, Movie> movie in movieInfo) {
                DisplayMsgMovies("[" + count + "] " + movie.Key);
                count++;
            }
            if (count == 0) {
                DisplayMsgMovies("No movies.");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SerializeMovies(moviesFile);
            SerializeBookings(bkHistFile);
            DisplayMsgMovies("Movies saved to " + moviesFile);
            DisplayMsgMovies("Bookings saved to " + bkHistFile);
        }
        private void btnAddShow_Click(object sender, EventArgs e)
        {
            String saveDate = tbDate.Text;
            String saveTimeFrom = tbTimeFrom.Text;
            String saveTimeTo = tbTimeTo.Text;
            double savePrice = 8.00;
            try {
                savePrice = Convert.ToInt32(tbPrice.Text);
            } catch {
                DisplayMsgShows("Please input correct price format.");
            }

            int movieInfoIndex = lbMovies.SelectedIndex;
            Movie selectedMovie = movieInfo.Values.ElementAt(movieInfoIndex);
            selectedMovie.Shows.Add(new Show(selectedMovie, saveDate, new Hall("Theatre 1"), saveTimeFrom, saveTimeTo, savePrice));

            UpdateShowDaysList(movieInfoIndex);
            DisplayMsgShows("Show added");
        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShowDaysList(lbMovies.SelectedIndex);
        }
        private void lbShowDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Shows
            lbShows.Items.Clear();
            Movie selectedMovie = movieInfo.Values.ElementAt(lbMovies.SelectedIndex);
            List<String> showsString = selectedMovie.FindShowTimes(lbShowDays.SelectedIndex);
            foreach (String showString in showsString) {
                lbShows.Items.Add(showString);
            }
            if (lbShows.Items.Count == 0) {
                lbShows.Items.Add("No shows");
            }
        }
        private void lbBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbBookings.Text = "";
            int count = 1;
            List<Seat> seats;
            Seat seat = new Seat();
            String seats_str = "", info_str = "";
            List<Booking> bookingFile = bookingInfo[lbBookings.SelectedItem.ToString()];
            tbBookings.AppendText("User " + bookingInfo.Keys.ToArray<String>()[lbBookings.SelectedIndex] + "\r\n");
            foreach (Booking b in bookingFile) {
                Show s = b.Show;
                seats = b.Seats;
                seats_str = "";
                info_str = "";
                for (int h = 0 ; h < seats.Count ; h++) {
                    seat = b.Seats[h];
                    seats_str += seat.Name + " ";
                }
                info_str += "[" + s.Movie.Title + "] (" + b.BookingTime + ")\r\n" +
                            "[" + s.Date + "] [" + s.TimeStart + " - " + s.TimeEnd + "] " + seats_str;

                tbBookings.AppendText("[#" + count + "] " + info_str + "\r\n\r\n");
                count++;
            }
        }
        private void lbShowBkShows_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {

                Movie m = movieInfo.Values.ElementAt(lbShowBkMovies.SelectedIndex);
                Show sfind = m.FindShows(lbShowBkShowDays.SelectedIndex)[lbShowBkShows.SelectedIndex];

                tbBookings.Text = "";
                List<Seat> seats;
                Seat seat = new Seat();
                String seats_str = "", info_str = "";
                String distinctUserStr = "distinctUser";
                List<Booking> bookingFile = new List<Booking>();
                bookingsByShow();
                //foreach (Show sfinds in m.FindShows(lbShowBkShowDays.SelectedIndex)) {
                //    tbShowBookings.AppendText(sfinds.ToString() + "\r\n");
                //}
                //foreach (KeyValuePair<String, List<Booking>> kvp in bkGroupByShow) {
                //    foreach (Booking bfinds in kvp.Value) {
                //        tbShowBookings.AppendText(bfinds.Show.ToString() + "\r\n");
                //    }
                //}
                tbShowBookings.Clear();
                bkGroupByShow.TryGetValue(sfind.ToString(), out bookingFile);
                if (bookingFile == null || bookingFile.Count == 0) {
                    tbShowBookings.Text = "No bookings found\r\n";
                } else {
                    //tbShowBookings.AppendText("User " + bookingInfo.Keys.ToArray<String>()[lbBookings.SelectedIndex] + "\r\n");
                    foreach (Booking b in bkGroupByShow[sfind.ToString()]) {
                        Show s = b.Show;
                        seats = b.Seats;
                        seats_str = "";
                        info_str = "";
                        for (int h = 0 ; h < seats.Count ; h++) {
                            seat = b.Seats[h];
                            seats_str += seat.Name + " ";
                        }

                        if (!b.User.Equals(distinctUserStr)) {
                            if (!distinctUserStr.Equals("distinctUser")) {
                                info_str += "\r\n";
                            }
                            info_str += "User " + b.User + "\r\n";
                            distinctUserStr = b.User;
                        }

                        info_str += "(" + b.BookingTime + ") :: " + seats_str;

                        tbShowBookings.AppendText(info_str + "\r\n");
                    }
                }
            } catch (Exception ex) {
                tbShowBookings.AppendText(ex.ToString() + "\r\n");
            }
        }
        private void lbShowBkShowDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbShowBkShows.Items.Clear();
            Movie m = movieInfo.Values.ElementAt(lbShowBkMovies.SelectedIndex);
            foreach (String showtimes in m.FindShowTimes(lbShowBkShowDays.SelectedIndex))
                lbShowBkShows.Items.Add(showtimes);
        }
        private void lbShowBkMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbShowBkShowDays.Items.Clear();
            lbShowBkShows.Items.Clear();
            Movie m = movieInfo.Values.ElementAt(lbShowBkMovies.SelectedIndex);
            foreach (String showdays in m.GetDates()) {
                lbShowBkShowDays.Items.Add(showdays);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
