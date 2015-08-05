/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This section covers the server side GUI and program
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

        // Connection Attributes
        private static int port = 9070;
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Dictionary<String, Socket> clients = new Dictionary<String, Socket>();
        private Dictionary<String, String> clientsNumber = new Dictionary<String, String>();

        public delegate void DisplayMsgCallback(String msg);
        public delegate void DisplayMsgMoviesCallback(String msg);
        public delegate void DisplayMsgShowsCallback(String msg);

        public Form1() {
            InitializeComponent();
            this.Text = "Server";
            //LoadMovies();
            DeserializeMovies(moviesFile);
            //bookingInfo = DeserializeBooking(bkHistFile); // Load booking info
            Thread t = new Thread(ConnectClient);
            t.IsBackground = true;
            t.Start();
        }

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        public void SerializeMovies(String filePath) {
            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, movieInfo.Values.ToArray());
                fs.Close();
            }
            //form.DisplayMsg("Saved movies database to " + filePath); (!)
        }

        public Image GetImage(String imgPath) {
            Image img = Image.FromFile(imgPath);
            return img;
        }

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

        public Dictionary<String, Movie> DeserializeMovies(String filePath) {
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
                tbDisplay.AppendText("Load Movie File Error: \n" + ex.ToString() + "\r\n");
            }
            return movieInfoNew;
        }

        private void Deserialize(String filePath) {
            formatter = new BinaryFormatter();
            try {
                using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    Movie[] m_info = (Movie[])formatter.Deserialize(fs);
                    fs.Close();
                    movieInfo = m_info.ToDictionary((u) => u.Title, (u) => u);
                    foreach (KeyValuePair<String, Movie> infos in movieInfo) { // (!) Remove when complete
                        tbDisplay.AppendText("Title: " + infos.Value.Title + "\r\n");
                        tbDisplay.AppendText(infos.Value.Genre + "\r\n");
                    }
                }
            } catch (Exception ex) {

                tbDisplay.AppendText(ex.ToString() + "\r\n");
            }
        }

        public Dictionary<String, List<Booking>> DeserializeBooking(String filePath) {
            Dictionary<String, Booking> bookingInfoBuilder = new Dictionary<String, Booking>();
            Dictionary<String, List<Booking>> bookingInfo = new Dictionary<String, List<Booking>>();

            try {
                using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read)) {
                    Booking[] b_info = (Booking[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    /// Key             Value
                    /// UserA + Date    BookingCopy1
                    /// UserA + Date    BookingCopy2
                    /// UserB + Date    BookingCopy3
                    bookingInfoBuilder = b_info.ToDictionary((u) =>
                        (u.User).Insert(u.User.Length + 1, u.BookingTime.ToString()), (u) => u);

                    foreach (Booking ub in bookingInfoBuilder.Values) {
                        if (!bookingInfo.ContainsKey(ub.User)) {
                            bookingInfo.Add(ub.User, new List<Booking>());
                        }
                    }

                    foreach (List<Booking> b in bookingInfo.Values) {
                        foreach (Booking ub in bookingInfoBuilder.Values) {
                            for (int i = 0; i < b.Count; i++) {
                                if (ub.User.Equals(b[i].User))
                                    b.Add(ub);
                            }
                        }
                    }
                }
                tbDisplay.AppendText("Load Bookings: Successful" + "\r\n");
            } catch (Exception ex) {
                tbDisplay.AppendText("Load Bookings: Failed" + "\r\n" + ex.ToString() +"\r\n");
            }
            return bookingInfo;
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

        // (!) Consider removing if client trigger events should not activate Movies textbox display
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

        // (!) Consider removing if client trigger events should not activate Shows textbox display
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

        private void btnClear_Click(object sender, EventArgs e) { }

        private void btnList_Click(object sender, EventArgs e) { }

        private void btnAdd_Click(object sender, EventArgs e) {
            //// Create the movie and shows
            String title, desc, dir, genre, imgPath = "";
            Boolean hasImage = false;

            title    = tbTitle.Text;
            desc     = tbDescription.Text;
            dir      = tbDirector.Text;
            genre    = tbGenre.Text;
            if (tbImage.Text.Trim().Length != 0 && !tbImage.Text.Trim().Equals("optional")) {
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

        private void btnBroadcast_Click(object sender, EventArgs e) { }

        private void btnWipe_Click(object sender, EventArgs e) {
            // Wipes all saved movies and alterations made 
            // by server administrator and loads repository defaults
            if (MessageBox.Show("Restore to default?", "Movies Repository",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                LoadMovies();
                DisplayMsgMovies("[Server] Movies Repository wiped to default");
                DisplayMsgShows("[Server] Movies Repository wiped to default");
                DisplayMsg("[Server] Movies Repository wiped to default");
            }
        }

        public void UpdateClientListBox()    
        {
            libClientsMovies.Items.Clear();
            libClientsShows.Items.Clear();
            libClientsDebug.Items.Clear();
            foreach(KeyValuePair<String, String> client in new SortedDictionary<String, String>(clientsNumber)) {
                libClientsMovies.Items.Add(client.Value);
                libClientsShows.Items.Add(client.Value);
                libClientsDebug.Items.Add(client.Value);
            }
            libClientsMovies.Sorted = true;
            libClientsShows.Sorted = true;
            libClientsDebug.Sorted = true;
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

        public void UpdateShowDaysList(int index)
        {

            // Show Days
            lbShowDays.Items.Clear();
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

        private void lbShowDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Shows
            lbShows.Items.Clear();
            Movie selectedMovie = movieInfo.Values.ElementAt(lbMovies.SelectedIndex);
            List<String> showsString = selectedMovie.FindShowTimes(lbShowDays.SelectedIndex);
            foreach(String showString in showsString){
                lbShows.Items.Add(showString);
            }
            if(lbShows.Items.Count == 0){
                lbShows.Items.Add("No shows");
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            }
        }

        private void lbBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbBookings.Text = "";
            int count = 1;
            List<Seat> seats;
            Seat seat = new Seat();
            String seats_str = "", info_str = "";
            //foreach (KeyValuePair<String, List<Booking>> kvp in bookingInfo) {
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
            //}
        }
    }
}
