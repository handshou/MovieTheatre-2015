using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using MvSvr;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MvSysClient {
    public partial class Form1 : Form 
    {

        public static Socket socket = new Socket(AddressFamily.InterNetwork,
                          SocketType.Stream, ProtocolType.Tcp);

        public FileStream fs;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;

        private int size = 0;
        private string infoFile = @"infomo.dat";
        private string srchFile = @"search.dat";
        private long filesize = 0;
        private Dictionary<String, Movie> movieInfo = new Dictionary<String, Movie>();

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";
        public const String SFOUND = "[SRHF]";
        public const String SEMPTY = "[SRHE]";
        public const String HISTRY = "[HSTY]";
        public const String SUCCESS = "[BKSS]";
        public const String FAILURE = "[BKFL]";

        public Thread t = null;

        public Boolean userInside = false;
        public String userID = "";

        public String bookingInfo = "";

        public Form1()
        {

            InitializeComponent();
            this.Text = "Client";
            

        }

        

        public void runClient()
        //this method starts a thread
        //called when the client has connected to the server and logged in with a userID
        {

            Control.CheckForIllegalCrossThreadCalls = false;

            userID = txtUser.Text;
            userInside = true;

            //prevents changes to the user text box
            txtUser.Enabled = false;
            btnLogin.Enabled = false;
            btnLogout.Enabled = true;

            btnBrowse.Enabled = true;
            btnViewBHistory.Enabled = true;

            cobSearch.Enabled = true;
            txtSearch.Enabled = true;


            rTxtMessages.Clear();
            rTxtMessages.AppendText("=============================\nWelcome to the Movie Booking System.");
            //DisplayMsg("\nYou may find your desired movies either by browsing or searching with a keyword.");


            //loadMovieDetails();
        }

        /* BUTTON_CLICK EVENT CODES BELOW
         * ======================================================
         * Some of these event methods fires a relevant method.
         * ======================================================
         */

        private void btnLogin_Click(object sender, EventArgs e) { Login(); }
        //attempts a connection and logs the user into the server

        private void btnLogout_Click(object sender, EventArgs e) { Logout(); }
        //logs the user out and severs the connection with the server.

        private void btnBrowse_Click(object sender, EventArgs e) { Browse(); }
        //request for movies from server

        private void btnSearch_Click(object sender, EventArgs e) { Search(); }
        //requests for specific movies from the server

        private void btnBook_Click(object sender, EventArgs e) { Book(); }
        //sends booking information to book for a seat 

        private void btnViewBHistory_Click(object sender, EventArgs e) { ViewHistory(); }
        //requests to view server's collection of user's booking history

        private void btnSaveBHistory_Click(object sender, EventArgs e) { SaveHistory(); }
        //saves requested booking history locally

        /* LIST_CHANGED EVENT CODES BELOW
         * ======================================================
         * These methods mainly manipulates other controls when a valid value is selected.
         * ======================================================
         */

        private void listMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Movie m = null;

            if (listMovies.SelectedItem !=  null)
            {
                String index = (string)listMovies.GetItemText(listMovies.SelectedItem);
                m = movieInfo[index];
                rTxtMessages.Clear();
                rTxtMessages.AppendText("\nMovie " + m.Title + " selected.");
                showMovieDetails(m);
            }

        }

        private void cobSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
        }

        private void cobDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string movie = (string)listMovies.GetItemText(listMovies.SelectedItem);
            Movie m = movieInfo[movie];

            cobTime.Items.Clear();

            List<String> showtimes = GetShowTimesByDate(m, (String)cobDate.SelectedItem);
            for (int i = 0; i < showtimes.Count; i++)
            {
                cobTime.Items.Add(showtimes[i]);
            }

            cobTime.SelectedIndex = 0;

        }

        private void cobTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            cobSeat.Items.Clear();

            string movie = (string)listMovies.GetItemText(listMovies.SelectedItem);
            Movie m = movieInfo[movie];

            Show s = GetShow(m);

            Hall h = s.Hall;

            foreach (Seat seat in h.AvailableSeats())
            {
                cobSeat.Items.Add(seat.Name);
            }

            cobSeat.SelectedIndex = 0;

            double price = 0;
            price = s.Price;
            lblPrice.Text = price.ToString();

            cobSeat.Enabled = true;

        }

        private void cobSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBook.Enabled = true;
        }

        /* FUNCTION METHODS BELOW
         * ======================================================
         * These methods are called when a button is clicked.
         * They are expected to function according to the method they are called in
         * ======================================================
         */

        public void Login()
        //this method logs the user, with a valid userID, into the server
        //successful execution of this method results in the user being able to access all other functions.
        //unsuccessful execution prompts the user to enter a valid userID
        {
            Regex regex = new Regex(@"^[0-9]{4}$");

            if (!string.IsNullOrWhiteSpace(txtUser.Text) && regex.IsMatch(txtUser.Text))
            //checks if userID textbox is either empty or only has white spaces
            {

                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse
                                              ("127.0.0.1"), 9070);
                try
                {
                    rTxtMessages.Clear();
                    rTxtMessages.Text += "Trying to connect to server...";
                    TcpClient client = new TcpClient();
                    client.Connect(remoteEP);

                    socket = client.Client;

                    rTxtMessages.Text += "\nConnection established.";
                    rTxtMessages.Text += "\nConnected to server with IP Address of" +
                        "127.0.0.1 and port 9070";

                    stream = new NetworkStream(socket);
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);

                    userID = txtUser.Text;

                    // sends user data to server
                    byte[] data = new byte[1024];
                    data = Encoding.ASCII.GetBytes(userID);
                    socket.Send(data);

                }
                catch (SocketException ex)
                {
                    rTxtMessages.AppendText("\nUnable to connect to the movie server." + ex);
                    rTxtMessages.AppendText("\nPlease check if the server is running.");
                    return;
                }

                t = new Thread(runClient);
                t.Start();
            }

            else
            {
                txtUser.Text = null;
                rTxtMessages.AppendText("\nPlease enter a user ID");
            }
        }

        public void Logout()
        //this method logs the user out
        //Disables every control except for Login (which is re-enable)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(FINISH);
            socket.Send(data);
            t.Abort();
            //socket.Close();
            rTxtMessages.Text = "You have logged out.";
            userID = "";
            txtUser.Clear();
            txtUser.Enabled = true;
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;

            btnBrowse.Enabled = false;
            btnSearch.Enabled = false;
            btnViewBHistory.Enabled = false;
            btnSaveBHistory.Enabled = false;
            btnBook.Enabled = false;
            cobSearch.Enabled = false;
            cobSeat.Enabled = false;
            cobDate.Enabled = false;
            cobTime.Enabled = false;
        }

        public void Browse()
        //this method requests movies from the server, and then loads it into the controls
        //Manipulates other controls to add in details of each movie and each show
        //allows for the booking of seats
        {
            listMovies.Items.Clear();

            IFormatter formatter = new BinaryFormatter();

            Thread.Sleep(1000);


            SendRequest(BROWSE);

            //receiving file size
            byte[] data = new byte[1024];
            try
            {
                size = socket.Receive(data);
            }
            catch (Exception)
            {
                rTxtMessages.AppendText("Receiving file size error" + "\r\n");
            }

            filesize = Convert.ToInt64(Encoding.ASCII.GetString(data));

            rTxtMessages.Clear();
            rTxtMessages.AppendText(filesize + " (filesize) " + size + " (size)\r\n");

            //receiving file
            data = new byte[filesize];
            try
            {
                size = socket.Receive(data);
                rTxtMessages.AppendText("File received" + "\r\n");
            }
            catch (Exception)
            {
                rTxtMessages.AppendText("Receiving file error" + "\r\n");
            }

            using (fs = new FileStream(infoFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(data, 0, Convert.ToInt32(filesize));
                fs.Flush();
                rTxtMessages.AppendText("File written" + "\r\n" + fs.Length + " bytes\r\n");
                fs.Close();
            }

            try
            {
                using (fs = new FileStream(infoFile, FileMode.Open, FileAccess.Read))
                {
                    Movie[] m_info = (Movie[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    movieInfo = m_info.ToDictionary((u) => u.Title, (u) => u);
                    foreach (KeyValuePair<String, Movie> infos in movieInfo)
                    {
                        rTxtMessages.AppendText(infos.Value.Title + "\r\n");
                        rTxtMessages.AppendText(infos.Value.Genre + "\r\n");

                        Movie mv = new Movie(infos.Value.Title, infos.Value.Description, infos.Value.Director,
                            infos.Value.Genre, infos.Value.Shows, infos.Value.Poster);

                        //listMovies.Items.Add(movieInfo[infos.Value.Title].toString());
                        listMovies.Items.Add(mv.Title);

                    }
                }
            }
            catch (Exception ex)
            {
                rTxtMessages.AppendText(ex.Message);
            }
        }

        public void Search()
        //this method requests for a specific movie search in the server
        //search parameters are acquired from user inputs
        //Loads up listMovie according to acquired searched movies
        //Works similar to Browse, adds in details in other controls for each movie and each show
        {

            listMovies.Items.Clear();

            string searchType = (string)cobSearch.SelectedItem;
            string searchKey = txtSearch.Text;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {

                rTxtMessages.AppendText(searchType + searchKey);

                IFormatter formatter = new BinaryFormatter();

                byte[] data = new byte[1024];

                int size = 0;

                data = Encoding.ASCII.GetBytes(SEARCH);
                socket.Send(data); //this sends the Search request

                data = Encoding.ASCII.GetBytes(searchType + ";" + searchKey);
                socket.Send(data); //this sends the search terms

                size = socket.Receive(data); //this receives the confirmation answer

                string answer = "";

                answer = Encoding.ASCII.GetString(data, 0, size);

                if (answer == SFOUND)
                {
                    // receiving file size
                    data = new byte[1024];
                    try
                    {
                        size = socket.Receive(data);
                    }
                    catch (Exception)
                    {
                        rTxtMessages.AppendText("Receiving file size error" + "\r\n");
                    }

                    filesize = Convert.ToInt64(Encoding.ASCII.GetString(data));

                    rTxtMessages.Clear();
                    rTxtMessages.AppendText(filesize + " (filesize) " + size + " (size)\r\n");

                    // receiving file
                    data = new byte[filesize];
                    try
                    {
                        size = socket.Receive(data);
                        rTxtMessages.AppendText("File received" + "\r\n");
                    }
                    catch (Exception)
                    {
                        rTxtMessages.AppendText("Receiving file error" + "\r\n");
                    }

                    if (!File.Exists(srchFile))
                    {
                        File.Create(srchFile);
                    }
                    using (fs = new FileStream(srchFile, FileMode.Open, FileAccess.Write))
                    {
                        fs.Write(data, 0, Convert.ToInt32(filesize));
                        fs.Flush();
                        rTxtMessages.AppendText("File written" + "\r\n" + fs.Length + " bytes\r\n");
                        fs.Close();
                    }

                    try
                    {
                        using (fs = new FileStream(srchFile, FileMode.Open, FileAccess.Read))
                        {
                            Movie[] m_info = (Movie[])formatter.Deserialize(fs);
                            fs.Flush();
                            fs.Close();
                            movieInfo = m_info.ToDictionary((u) => u.Title, (u) => u);
                            foreach (KeyValuePair<String, Movie> infos in movieInfo)
                            {
                                rTxtMessages.AppendText(infos.Value.Title + "\r\n");
                                rTxtMessages.AppendText(infos.Value.Genre + "\r\n");

                                Movie mv = new Movie(infos.Value.Title, infos.Value.Description, infos.Value.Director,
                            infos.Value.Genre, infos.Value.Shows, infos.Value.Poster);

                                //listMovies.Items.Add(movieInfo[infos.Value.Title].toString());
                                listMovies.Items.Add(mv.Title);

                            }
                        }

                        rTxtMessages.AppendText("\nResults established.");

                    }
                    catch (Exception ex)
                    {
                        rTxtMessages.AppendText("\nError. Please restart the application." + ex.Message);
                    }
                }

                else
                    if (answer == SEMPTY)
                    {
                        rTxtMessages.AppendText("\nNo results attained. If this is not expected, please change the search terms.");
                    }

                    else
                    {
                        rTxtMessages.AppendText("\nSomething bad has happened. Please restart the application.");
                    }

            }

            else //triggers when textbox for search query is either null or has whitespaces
            {

                rTxtMessages.AppendText("\nSearch bar is empty: please input a key word.");

            }
        }

        public void Book()
        //this method gathers user inputs to request a seat booking in the server
        //booking information is derived from user inputs in the relevant controls
        //server will return relevant reply depending if the booking is successful
        {
            string time = (string)cobSearch.SelectedItem;
            int seatIndex = cobSeat.SelectedIndex;
            string price = lblPrice.Text;
            string line = "";

            string movie = (string)listMovies.GetItemText(listMovies.SelectedItem);
            Movie m = movieInfo[movie];
            Show s = GetShow(m);

            line = userID + ";" + ";" + time + ";" + seatIndex + ";" + price;
            //hall or show + index of seat

            //sending to server
            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(BOOKNG); //sends prompt for server to receive a booking
            socket.Send(data);

            string filePath = @"bookingInfo.dat";

            int index = cobSeat.SelectedIndex;

            Dictionary<Seat, Show> showDict = new Dictionary<Seat, Show>();

            showDict.Add(s.Hall.Seats[index], s);

            SaveToBookingFile(filePath, showDict);

            FileInfo f = new FileInfo(filePath);
            filesize = f.Length;
            data = new byte[filesize];

            // Sending booking information
            socket.Send(Encoding.ASCII.GetBytes(filesize.ToString()));

            // Sending file
            byte[] buffer = null;
            using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
            }

            try
            {
                socket.Send(buffer);
                // rTxtMessages.AppendText("Files sent"); //
            }
            catch (Exception ex)
            {
                rTxtMessages.AppendText(ex.Message);
            }

            ///////

            string result = "";

            try
            {
                int size = 0;
                size = socket.Receive(data);
                result = Encoding.ASCII.GetString(data, 0, size);
            }

            catch (Exception)
            {
                lblBoardMessage.Text = "Booking unsuccessful. Please contact a staff member for assistance.";
                lblBoardMessage.ForeColor = Color.Red;
                result = FAILURE;
            }

            finally
            {
                lblBoardMessage.Visible = true;
            }

            if (result == SUCCESS)
            {
                lblBoardMessage.Text = "Your booking has been successful";
                lblBoardMessage.Font = new Font(lblBoardMessage.Font, FontStyle.Bold);
                lblBoardMessage.ForeColor = Color.Black;
            }

            else
            {
                lblBoardMessage.Text = "Booking unsuccessful. Please contact a staff member for assistance.";
                lblBoardMessage.ForeColor = Color.Red;
            }
        }

        public void ViewHistory()
        //this methods requests a user's booking history from the server, and then loads it into the client
        //enables other controls related to booking-history
        {
            bookingInfo = null;
            byte[] data = new byte[1024];

            SendRequest(HISTRY);

            //data = Encoding.ASCII.GetBytes(userID); //sends the user ID
            //socket.Send(data);

            string history = "";

            try
            {
                int size = 0;
                size = socket.Receive(data);
                history = Encoding.ASCII.GetString(data, 0, size);
                history = ProcessHistory(history);
                rTxtMessages.Clear();
                rTxtMessages.AppendText("Booking History:\n");

                if (!string.IsNullOrWhiteSpace(history))
                {
                    rTxtMessages.AppendText(history);
                    bookingInfo = history;
                    btnSaveBHistory.Enabled = true;
                }

                else
                {
                    rTxtMessages.AppendText("No booking history found.");
                }


            }

            catch (Exception ex)
            {
                rTxtMessages.AppendText("Error: " + ex.Message);
            }
        }

        public String ProcessHistory(String msg) {
        //this method processes the incoming history string from server
        //newline is added for every booking history record
        //returns the new edited string (with newline)
            String[] pattern = {"--ENDOFBOOKING--"};
            String[] processed = msg.Split(pattern, StringSplitOptions.None);
            String output = "";

            for (int i = 0; i < processed.Length; i++) {
                output += processed[i] + "\r\n";
            }
            return output;
        }

        public void SaveHistory()
        //this methods saves a user's booking information into a text file locally
        //requires a history to be loaded from the server first

        {
            string bHistory = bookingInfo;

            bHistory = userID + ";lolol";

            if (!string.IsNullOrWhiteSpace(bHistory))
            {

                string fileName = "bookingHistory.txt";

                FileInfo fi = new FileInfo(fileName);

                byte[] data = new byte[1024];

                string line = null;

                StreamWriter writer = new StreamWriter(fileName);

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Dispose();

                    using (writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine(bHistory);
                    }

                }

                rTxtMessages.AppendText("\nBooking History saved to local file '" + fileName + "'.");


            }

            else
            {
                rTxtMessages.AppendText("\nYour booking history is empty.");
            }
        }

        /* MISC METHODS
         * ======================================================
         * These methods are called to assist other methods for the sake of code condensation
         * ======================================================
         */

        public void SendRequest(string request)
        //this method is called a request is sent to the server as part of the server-client communication protocol
        //Sends a 'request' message to the server
        {
            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(request); //sends prompt for server to receive a booking
            socket.Send(data);
        }

        private void showMovieDetails(Movie m)
        //called when a movie is selected in listMovies.
        //This method manipulates the controls to contain and show the movie's information.
        {

            lblShowName.Visible = true;
            lblShowDirector.Visible = true;
            lblShowGenre.Visible = true;

            lblMvName.Visible = true;
            lblMvGenre.Visible = true;
            lblMvDirector.Visible = true;
            lblMvDescription.Visible = true;

            lblMvName.Text = m.Title;
            lblMvGenre.Text = m.Genre;

            lblMvDirector.Text = m.Director;
            lblMvDescription.Text = m.Description;

            picPoster.Image = FixedSize(m.Poster, 200, 200);


            cobDate.Enabled = true;
            cobDate.Items.Clear();
            cobTime.Enabled = true;
            cobTime.Items.Clear();
            listTime.Items.Clear();
            btnBook.Enabled = true;

            List<Show> listShow = m.Shows;
            List<String> dates = GetDatesByMovie(m);

            foreach (String s in dates) {
                cobDate.Items.Add(s);
            }

            cobDate.SelectedIndex = 0;
            
        }

        public List<String> GetDatesByMovie(Movie m) 
        //this method is called when the show dates of a movie is required
        //returns a list of show dates
        {
            List<Show> shows = m.Shows;
            List<String> all = new List<String>();
            foreach(Show s in shows){
                if(!all.Contains(s.Date))
                    all.Add(s.Date);
            }
            all.Sort();
            //rTxtMessages.Text = all.Count.ToString();
            return all;
        }

        public List<String> GetShowTimesByDate(Movie m, String date)
        //this method is called when the show times of a show date is required
        //returns a list of show times
        {
            List<String> showtimes = new List<String>();
            try
            {
                List<Show> shows = m.Shows;
                showtimes = new List<String>();
                for (int i = 0; i < shows.Count; i++)
                {

                    if (shows[i].Date.Equals(date))
                    {
                        showtimes.Add(shows[i].TimeStart);
                    }
                    
                }
                showtimes.Sort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return showtimes;
        }

        public Movie GetMovie()
        //this method is called when a movie object is required
        //returns a Movie object
        {
        
            string movie = (string)listMovies.GetItemText(listMovies.SelectedItem);
            Movie m = movieInfo[movie];
            return m;
        }

        public Show GetShow(Movie m)
        //this method is called when the Show object of a Movie is required
        //returns a Show object
        {
            int index = cobTime.SelectedIndex;
            return m.Shows[index];
        }

        public void SaveToBookingFile(String filePath, Dictionary<Seat, Show> d)
        //this method is called by the Book method when a booking needs to be verified by the server
        //serializes and sends the seat information to the server
        {

            IFormatter formatter  = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                Object[] bookingInfo = new Object[d.Count + 2]; // Create array to send
                bookingInfo[0] = (Show) d.Values.ToArray()[0]; // First item in array is a Show object
                bookingInfo[1] = (int) d.Count + 2;
                for(int i = 0; i < d.Keys.ToArray().Length; i++){
                    bookingInfo[i+2] = (Seat) d.Keys.ToArray()[i]; // Add all seats for the show
                }
                formatter.Serialize(fs, bookingInfo);
                fs.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //kills all bckgrnd thread under this prog
        }

        /// http://stackoverflow.com/questions/1940581/c-sharp-image-resizing-to-different-size-while-preserving-aspect-ratio
        public static Image FixedSize(Image imgPhoto, int Width, int Height)
        //this method is called to resize an image into a standard size
        //resizes the image and returns a resized Image object
        {

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW) {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            } else {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

    }

}
