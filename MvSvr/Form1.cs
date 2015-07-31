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

        public delegate void DisplayMsgCallback(String msg);
        public delegate void DisplayMsgMoviesCallback(String msg);
        public delegate void DisplayMsgShowsCallback(String msg);

        public Form1() {

            InitializeComponent();
            this.Text = "Server";
            LoadMovies();
            //LoadMovieFile(browseFile);
            //bookingInfo = LoadBookingFile(bkHistFile); // Load booking info
            Thread t = new Thread(ConnectClient);
            t.IsBackground = true;
            t.Start();

        }

        public void ConnectClient() {

            DisplayMsg("Server initiated..");
            server.Bind(endpoint);
            server.Listen(10);
            while(true) {
                try {
                    Socket client = server.Accept();
                    //clients.Add(client);
                    ConnectionHandler handler = 
                        new ConnectionHandler(client, this, ref movieInfo, 
                            ref bookingInfo, ref clients);
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
                new Show(m, "1 January 2015", new Hall("Hall 1"), "0800", "1000", 8.00),
                new Show(m, "1 January 2015", new Hall("Hall 2"), "1600", "1800", 8.00),
                new Show(m, "2 January 2015", new Hall("Hall 3"), "2000", "2200", 8.00),
                new Show(m, "2 January 2015", new Hall("Hall 4"), "0800", "1000", 8.00),
                new Show(m, "3 January 2015", new Hall("Hall 5"), "1600", "1800", 10.00),
                new Show(m, "3 January 2015", new Hall("Hall 6"), "2000", "2200", 12.00),
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Batman Of The Future";
            m.Genre = "Animated";
            m.Description = "Batman is back, again!";
            m.Director = "Steven Lim";
            m.Poster = GetImage("poster\\batman_of_the_future.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "3 July 2015", new Hall("Hall 1"), "0900", "1100", 8.00),
                new Show(m, "3 July 2015", new Hall("Hall 2"), "1700", "1900", 10.00),
                new Show(m, "3 July 2015", new Hall("Hall 3"), "2100", "2300", 12.00)
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Inception";
            m.Genre = "Science Fiction - Thriller";
            m.Description = "Your mind is the scene of the crime. Dom Cobb is a professional thief who commits corporate espionage in the most lucid way - via dreams.";
            m.Director = "Christopher Nolan";
            m.Poster = GetImage("poster\\inception_poster.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "3 July 2015", new Hall("Hall 1"), "1820", "2020", 12.00),
                new Show(m, "4 July 2015", new Hall("Hall 2"), "1300", "1500", 12.00),
                new Show(m, "5 July 2015", new Hall("Hall 3"), "0030", "0230", 10.00)
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Terminator 2 : Judgement Day";
            m.Genre = "Science Fiction - Action";
            m.Description = "It's nothing personal. The sequel to the 1984 Terminator. Arnold Schwarzenegger is back as a cyborg Terminator. Now available in seasonal showings.";
            m.Director = "James Cameron";
            m.Poster = GetImage("poster\\terminator2.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "2 March 2015", new Hall("Hall 1"), "1850", "2050", 12.00),
                new Show(m, "4 September 2015", new Hall("Hall 2"), "1500", "1700", 12.00),
                new Show(m, "6 December 2015", new Hall("Hall 3"), "1230", "1430", 12.00)
            };

            movieInfo.Add(m.Title, m);

        }

        //public void WriteToTextFile() {
            
        //    String moviePath    = @"movieText.txt";
        //    String showPath     = @"showText.txt";
        //    String hallPath     = @"hallText.txt";
        //    String seatPath     = @"seatText.txt";
        //    String bookingPath  = @"bookingText.txt";

        //    List<Movie> mlist = movieInfo.Values.ToList<Movie>();
        //    using (fs = new FileStream(moviePath, FileMode.OpenOrCreate, FileAccess.Write)) {
        //        Movie m = new Movie(Title, Description, Director, Genre, List<Shows>, PosterURL)



        //        fs.Flush();
        //        fs.Close();
        //    }
        //    foreach(Show show in showlist)
        //    List<Show> showlist = mlist
        //    using (fs = new FileStream(showPath, FileMode.OpenOrCreate, FileAccess.Write)) {


        //        fs.Flush();
        //        fs.Close();
        //    }
        //    using (fs = new FileStream(hallPath, FileMode.OpenOrCreate, FileAccess.Write)) {


        //        fs.Flush();
        //        fs.Close();
        //    }
        //    using (fs = new FileStream(seatPath, FileMode.OpenOrCreate, FileAccess.Write)) {


        //        fs.Flush();
        //        fs.Close();
        //    }
        //    using (fs = new FileStream(bookingPath, FileMode.OpenOrCreate, FileAccess.Write)) {


        //        fs.Flush();
        //        fs.Close();
        //    }
        //}

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
                tbDisplay.AppendText("Load Movie File Error: \n" + ex.ToString() + "\r\n");
            }
            return movieInfoNew;
        }

        private void LoadFile(String filePath) {

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

        private void btnClear_Click(object sender, EventArgs e) {

        }

        private void btnList_Click(object sender, EventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {

            //// Create the movie and shows
           String title, desc, dir, genre, imgPath;

            title    = tbTitle.Text;
            desc     = tbDescription.Text;
            dir      = tbDirector.Text;
            genre    = tbGenre.Text;
            if(tbImage.Text.Trim().Length != 0) // No image
                imgPath  = tbImage.Text;

            Movie m = new Movie(title, desc, dir, genre);
            movieInfo.Add(m.Title, m);

            DisplayMsgMovies("New Movie: " + m.Title + " added");
            DisplayMsgShows("New Movie: " + m.Title + " added");

            tabControl.SelectedTab = tabPageShows;

        }

        private void btnDebugClear_Click(object sender, EventArgs e) {

            tbDisplay.Clear();
        }

        private void btnBroadcast_Click(object sender, EventArgs e) {

        }

        private void btnWipe_Click(object sender, EventArgs e) {

            // Wipes all saved movies and alterations made 
            // by server administrator and loads repository defaults
            if (MessageBox.Show("Wipe and restore to default?", "Movies Repository",
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
            foreach(KeyValuePair<String, Socket> client in clients) {
                libClientsMovies.Items.Add(client.Key);
                libClientsShows.Items.Add(client.Key);
                libClientsDebug.Items.Add(client.Key);
            }
        } 
    }
}
