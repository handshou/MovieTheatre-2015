/* Windows Appliations Development Assignment
 * Hansel Chia: s10161147
 * Jack Chang: s10156590
 * This class covers the Client side GUI and program
 * Most of the methods are minimized. Please maximise them to show their contents.
 */

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

        public Socket socket = new Socket(AddressFamily.InterNetwork,
                          SocketType.Stream, ProtocolType.Tcp);

        public FileStream fs;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;

        private CheckBox[] checkBoxes;
        private String lastClicked = "";
        private String lastSearchedKey = "";
        private String lastSearchedType = "";
        private int lastListIndex = 0;

        private int size = 0;
        private string infoFile = @"infomo.dat";
        private string srchFile = @"search.dat";
        private string filePath = @"bookingInfo.dat";
        private string bkHistFile = @"bkrepo.dat";
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

        public String userID = "";
        public String authenticated = "";

        public String bookingInfo = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "Client";

            /// http://stackoverflow.com/questions/3563231/checkbox-array-in-c-sharp
            checkBoxes = new CheckBox[] {  chkA1, chkA2, chkA3, chkA4, chkA5,
                                            chkB1, chkB2, chkB3, chkB4, chkB5,
                                            chkC1, chkC2, chkC3, chkC4, chkC5,
                                            chkD1, chkD2, chkD3, chkD4, chkD5,
                                            chkE1, chkE2, chkE3, chkE4, chkE5 };

            btnBrowse.Click += new EventHandler(UpdateCinemaSeats);
            // btnSearch.Click += new EventHandler(UpdateCinemaSeats); // causes error when no movies found on search()

            listMovies.SelectedIndexChanged += new EventHandler(UpdateCinemaSeats);

            cobDate.SelectedIndexChanged += new EventHandler(UpdateCinemaSeats);
            cobTime.SelectedIndexChanged += new EventHandler(UpdateCinemaSeats);
            cobSeat.SelectedIndexChanged += new EventHandler(UpdateCinemaSeats); // control no longer in use, code left for keepsake/revert

            foreach (var checkBox in checkBoxes)
                checkBox.CheckedChanged += new EventHandler(UpdateCinemaPrice);
        }

        private void UpdateCinemaPrice(object sender, EventArgs e) {

            if (listMovies.GetItemText(listMovies.SelectedItem).Length > 0) {
                int count = 0;
                List<Seat> seatList = new List<Seat>();
                for (int i = 0; i < checkBoxes.Length; i++) {
                    if (checkBoxes[i].CheckState == CheckState.Checked) {
                        seatList.Add(GetShow().Hall.Seats[i]);
                        count++;
                    }
                }

                // Always show the price of one ticket
                if (count == 0)
                    count = 1;

                Booking b = new Booking(userID, GetShow(), seatList);

                lblBorder.BackColor = Color.Empty;

                grpBoxPrice.Visible = true;
                lblPrice.Text = String.Format("${0:0.00}", b.CalculateBaseCost(false));
            }
        }
        
        private void UpdateCinemaSeats(object sender, EventArgs e) {

            //string message = string.Empty;
            //for (int i = 0; i < checkBoxes.Length; i++) {
            //    if (checkBoxes[i].Checked && checkBoxes[i].Enabled) {
            //        // message += string.Format("boxes[{0}] is clicked\n", i);
            //    }
            //}

            List<Seat> seatList = GetShow().Hall.Seats;
            for (int i = 0; i < seatList.Count; i++) {
                if (!seatList[i].Vacant) {
                    checkBoxes[i].CheckState = CheckState.Indeterminate;
                    checkBoxes[i].Enabled = false;
                }
                if (seatList[i].Vacant) {
                    checkBoxes[i].CheckState = CheckState.Unchecked;
                    checkBoxes[i].Enabled = true;
                }
            }

            // MessageBox.Show(message);
        }

        public void runClient()
        //this method opens up most of the client to the user
        //called when the client has connected to the server and logged in with a userID
        {

            userID = txtUser.Text;
            //prevents changes to the user text box

            txtUser.Enabled = false;
            btnLogin.Enabled = false;
            btnLogout.Enabled = true;

            btnBrowse.Enabled = true;
            btnViewBHistory.Enabled = true;

            cobSearch.Enabled = true;
            txtSearch.Enabled = true;

            listMovies.Enabled = true;
            lblBookMessage.ResetText();

            grpBoxTheatre.Enabled = true;
            grpBoxDescription.Enabled = true;
            grpBoxPrice.Enabled = true;
            grpBoxBookingHistory.Enabled = true;

            listTime.Enabled = true;
            lblDate.Enabled = true;
            lblTime.Enabled = true;
            cobDate.Enabled = true;
            cobTime.Enabled = true;

            lblMvDescription.Visible = true;

            rTxtMessages.Clear();
            rTxtMessages.AppendText("Hi " + userID + ",\n");
            rTxtMessages.AppendText("You may browse or search for movies from our database!\n");

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

        private void btnBrowse_Click(object sender, EventArgs e) { Browse(); lastClicked = "browse"; }
        //request for movies from server

        private void btnSearch_Click(object sender, EventArgs e) { Search(); lastClicked = "search"; }
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
            if (listMovies.SelectedItem !=  null && listMovies.Items.Count != 0)
            {
                Movie m = GetMovie();
                String index = (string)listMovies.GetItemText(listMovies.SelectedItem);
                m = movieInfo[index];
                //rTxtMessages.Clear();
                //rTxtMessages.AppendText("\nMovie " + m.Title + " selected.");
                showMovieDetails(m);
            }

            lblBookMessage.ResetText();
        }

        private void cobSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
        }

        private void cobDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Movie m = GetMovie();

            cobTime.Items.Clear();
            listTime.Items.Clear();

            // List<String> showtimes = GetShowTimesByDate(m, (String)cobDate.SelectedItem);
            List<String> showtimes = m.FindShowTimes(cobDate.SelectedIndex);
            for (int i = 0; i < showtimes.Count; i++)
            {
                cobTime.Items.Add(showtimes[i]);
                listTime.Items.Add(showtimes[i]);
            }

            cobTime.SelectedIndex = 0;
            LoadSeats();
            lblTheatreName.Text = GetShow().Hall.Name;

        }

        private void LoadSeats() {

            cobSeat.Items.Clear();
            foreach (Seat seat in GetShow().Hall.AvailableSeats()) {
                cobSeat.Items.Add(seat.Name);
            }
            if (cobSeat.Items != null && cobSeat.Items.Count != 0) {
                cobSeat.SelectedIndex = 0;
            }
        }

        //private int SeatsToIndex(String seatName) {

        //    int i = char.ToLower(Convert.ToChar(seatName.Substring(0, 1)));
        //    List<Seat> test = new List<Seat>();
        //    test.

        //    return 0;
        //}

        private void cobTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSeats();

            double price = 0;
            price = GetShow().Price;
            grpBoxPrice.Visible = true;
            lblPrice.Text = String.Format("${0:0.00}", price);

            cobSeat.Enabled = true;
            lblBorder.BackColor = Color.Empty;
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
            Regex regex = new Regex(@"^[0-9A-Za-z]{4}$");
            byte[] data = new byte[1024];

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
                        " 127.0.0.1 and port 9070";

                    stream = new NetworkStream(socket);
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);

                    userID = txtUser.Text;

                    // sends user data to server
                    data = new byte[1024];
                    data = Encoding.ASCII.GetBytes(userID);
                    socket.Send(data);
                }
                catch (SocketException ex)
                {
                    rTxtMessages.AppendText("\nUnable to connect to the movie server.");
                    rTxtMessages.AppendText("\nPlease check if the server is running.");
                    return;
                }

                // check if login is successful
                data = new byte[1024];
                size = socket.Receive(data);
                authenticated = Encoding.ASCII.GetString(data).Trim('\0');                
                if (authenticated == SUCCESS) {

                    runClient();

                } else {
                    rTxtMessages.Clear();
                    rTxtMessages.AppendText("\nUser ID already logged in. Please choose another user ID.");
                }
            }

            else
            {
                txtUser.Text = null;
                rTxtMessages.AppendText("\nPlease enter a valid 4-digit user ID");
            }
        }

        public void Logout()
        //this method logs the user out
        //Disables every control except for Login (which is re-enable)
        {
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(FINISH);
            socket.Send(data);
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
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
            lblDate.Enabled = false;
            lblTime.Enabled = false;
            listMovies.Enabled = false;
            listTime.Enabled = false;

            grpBoxTheatre.Enabled = false;
            grpBoxDescription.Enabled = false;
            grpBoxPrice.Enabled = false;
            grpBoxBookingHistory.Enabled = false;

            lblMvDescription.Visible = false;
            lblBorder.BackColor = Color.Empty;

            lblBookMessage.ResetText();
        }

        public void Browse()
        //this method requests movies from the server, and then loads it into the controls
        //Manipulates other controls to add in details of each movie and each show
        //allows for the booking of seats
        {

            btnBrowse.Text = "Browse";
            listMovies.Items.Clear();

            IFormatter formatter = new BinaryFormatter();

            //Thread.Sleep(1000);


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

            //rTxtMessages.Clear();
            //rTxtMessages.AppendText(filesize + " (filesize) " + size + " (size)\r\n");

            //receiving file
            data = new byte[filesize];
            try
            {
                size = socket.Receive(data);
                //rTxtMessages.AppendText("File received" + "\r\n");
            }
            catch (Exception)
            {
                rTxtMessages.AppendText("Receiving file error" + "\r\n");
            }

            using (fs = new FileStream(infoFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(data, 0, Convert.ToInt32(filesize));
                fs.Flush();
                //rTxtMessages.AppendText("File written" + "\r\n" + fs.Length + " bytes\r\n");
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
                    SortedDictionary<String, Movie> sortedMovieInfo = new SortedDictionary<String, Movie>(movieInfo);

                    foreach (KeyValuePair<String, Movie> infos in sortedMovieInfo)
                    {
                        //rTxtMessages.AppendText(infos.Value.Title + "\r\n");
                        //rTxtMessages.AppendText(infos.Value.Genre + "\r\n");

                        Movie mv = new Movie(infos.Value.Title, infos.Value.Description, infos.Value.Director,
                            infos.Value.Genre, infos.Value.Shows, infos.Value.Poster);

                        //listMovies.Items.Add(movieInfo[infos.Value.Title].toString());
                        if(mv.Shows.Count > 0)
                            listMovies.Items.Add(mv.Title);

                    }
                    listMovies.SelectedIndex = 0;
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

                //rTxtMessages.AppendText(searchType + searchKey);

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

                    //rTxtMessages.Clear();
                    //rTxtMessages.AppendText(filesize + " (filesize) " + size + " (size)\r\n");

                    // receiving file
                    data = new byte[filesize];
                    try
                    {
                        size = socket.Receive(data);
                        //rTxtMessages.AppendText("File received" + "\r\n");
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
                        //rTxtMessages.AppendText("File written" + "\r\n" + fs.Length + " bytes\r\n");
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
                                //rTxtMessages.AppendText(infos.Value.Title + "\r\n");
                                //rTxtMessages.AppendText(infos.Value.Genre + "\r\n");

                                Movie mv = new Movie(infos.Value.Title, infos.Value.Description, infos.Value.Director,
                                infos.Value.Genre, infos.Value.Shows, infos.Value.Poster);

                                //listMovies.Items.Add(movieInfo[infos.Value.Title].toString());
                                listMovies.Items.Add(mv.Title);

                            }
                        }

                        rTxtMessages.AppendText("\nRequesting from Server \"" + searchType + " : " + searchKey + "\"");
                        listMovies.SelectedIndex = 0;

                    }
                    catch (Exception ex)
                    {
                        rTxtMessages.AppendText("\nError. Please restart the application." + ex.ToString());
                    }
                }

                else
                    if (answer == SEMPTY)
                    {
                        rTxtMessages.AppendText("\nNo movies found.\nPlease ensure that your search type is correct.");
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

            // attributes to save client's footprint, for future plans and not in use at the moment
            lastSearchedType = searchType;
            lastSearchedKey = searchKey;
            lastClicked = "search";
            lastListIndex = listMovies.SelectedIndex;

        }

        public void Book()
        //this method gathers user inputs to request a seat booking in the server
        //booking information is derived from user inputs in the relevant controls
        //server will return relevant reply depending if the booking is successful
        {
            Show s = GetShow();
            List<Seat> seatList = s.Hall.Seats;

            Dictionary<Seat, Show> showDict = new Dictionary<Seat, Show>();
            // showDict.Add(s.Hall.Seats[index], s);
            // SerializeBookedSeats(bkHistFile, showDict);

            for (int i = 0; i < seatList.Count; i++) {
                //if (!seatList[i].Vacant) {
                //    checkBoxes[i].CheckState = CheckState.Indeterminate;
                //    checkBoxes[i].Enabled = false;
                //}
                //if (seatList[i].Vacant) {
                //    checkBoxes[i].CheckState = CheckState.Unchecked;
                //    checkBoxes[i].Enabled = true;
                //}
                if (checkBoxes[i].CheckState == CheckState.Checked) {
                    showDict.Add(s.Hall.Seats[i], s);
                    // rTxtMessages.Text += s.Hall.Seats[i].Name + "\n"; // (!) debug
                }
            }

            if (showDict.Count > 0) {
                SerializeBookedSeats(bkHistFile, showDict);

                //sending to server
                byte[] data = new byte[1024];
                data = Encoding.ASCII.GetBytes(BOOKNG); //sends prompt for server to receive a booking
                socket.Send(data);

                FileInfo f = new FileInfo(filePath);
                filesize = f.Length;
                // data = new byte[filesize];
                // Sending booking information
                socket.Send(Encoding.ASCII.GetBytes(filesize.ToString()));

                Thread.Sleep(10);

                // Sending file
                byte[] buffer = null;
                using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read)) {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    fs.Close();
                }

                try {
                    socket.Send(buffer);
                    // rTxtMessages.AppendText("Files sent"); //
                } catch (Exception ex) {
                    rTxtMessages.AppendText(ex.Message);
                }

                ///////

                string result = "";

                try {
                    int size = 0;
                    size = socket.Receive(data); /* R */
                    result = Encoding.ASCII.GetString(data, 0, size);
                } catch (Exception) {
                    btnBrowse.Text = "Refresh";
                    MessageBox.Show("Please refresh the movie listing!");
                    //lblBookMessage.Text = "Booking unsuccessful. Please contact a staff member for assistance.";
                    lblBookMessage.ForeColor = Color.Red;
                    result = FAILURE;
                } finally {
                    lblBookMessage.Visible = true;
                }

                if (result == SUCCESS) {
                    MessageBox.Show("Your booking has been successful!");
                    //lblBookMessage.Text = "Your booking for " + s.Movie.Title + " has been successful";
                    lblBookMessage.Font = new Font(lblBookMessage.Font, FontStyle.Bold);
                    lblBookMessage.ForeColor = Color.Black;

                    for (int i = 0; i < seatList.Count; i++) {
                        //if (!seatList[i].Vacant) {
                        //    checkBoxes[i].CheckState = CheckState.Indeterminate;
                        //    checkBoxes[i].Enabled = false;
                        //}
                        //if (seatList[i].Vacant) {
                        //    checkBoxes[i].CheckState = CheckState.Unchecked;
                        //    checkBoxes[i].Enabled = true;
                        //}
                        if (checkBoxes[i].CheckState == CheckState.Checked) {
                            if (checkBoxes[i].CheckState == CheckState.Checked) {
                                checkBoxes[i].CheckState = CheckState.Indeterminate;
                                checkBoxes[i].Enabled = false;
                                GetShow().Hall.Seats[i].Vacant = false;
                            }
                        }
                    }

                } else {
                    btnBrowse.Text = "Refresh";
                    MessageBox.Show("Please refresh the movie listing!");
                    //lblBookMessage.ForeColor = Color.Red;
                }
            } else {
                lblBorder.BackColor = Color.LightGray;
                MessageBox.Show("Please select a seat");
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
                data = new byte[8192];
                int size = 0;
                size = socket.Receive(data);
                history = Encoding.ASCII.GetString(data, 0, size);
                history = ProcessHistory(history);
                rTxtMessages.Clear();

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

        public void SaveHistory()
        //this methods saves a user's booking information into a text file locally
        //requires a history to be loaded from the server first

        {
            string bHistory = bookingInfo;

            if (!string.IsNullOrWhiteSpace(bHistory))
            {

                try
                {
                    string fileName = "bookingHistory" + userID + ".txt";

                    FileInfo fi = new FileInfo(fileName);

                    byte[] data = new byte[1024];

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine(bHistory);
                        writer.Flush();
                        rTxtMessages.AppendText("\nBooking History saved to local file '" + fileName + "'.");
                        writer.Close();
                    }
                }

                catch (Exception)
                {
                    rTxtMessages.AppendText("\nTrouble loading booking history. Please contact tech support.");
                }

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
            //all.Sort();
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
                //showtimes.Sort();
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

        public Show GetShow()
        //this method is called when the Show object of a Movie is required
        //returns a Show object !!!!!!!!!! flawed method here, fixing in progress !!!!!!!
        {
            Movie m = GetMovie();

            Show s = m.FindShows(cobDate.SelectedIndex)[cobTime.SelectedIndex];

            return s;
            //List<Show> showList = m.Shows;
            //foreach (Show sh in showList) {
            //    if (!sh.Date.Equals(cobDate.SelectedItem)) {
            //        showList.Remove(sh);
            //    }
            //    if (!sh.TimeStart.Equals(cobTime.SelectedItem)) {
            //    // Ensure that it is not the same show
            //        showList.Remove(sh);
            //    }
            //}
            ////int index = cobDate.SelectedIndex;
            //return showList[0];
        }


        public String ProcessHistory(String msg)
        //this method processes the incoming history string from server
        //newline is added for every booking history record
        //returns the edited string (with newline)
        {
            
            String[] pattern = { ENDOFF };
            String[] processed = msg.Split(pattern, StringSplitOptions.None);
            String output = "";

            for (int i = 0; i < processed.Length; i++)
            {
                output += processed[i] + "\r\n";
            }
            return output;
        }

        public void SerializeBookedSeats(String filePath, Dictionary<Seat, Show> d)
        //this method is called by the Book method when a booking needs to be verified by the server
        //serializes and sends the seat information to the server
        {

            IFormatter formatter  = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                Object[] bookingObj = new Object[d.Count + 2]; // Create array to send
                bookingObj[0] = (Show) d.Values.ToArray()[0]; // First item in array is a Show object
                bookingObj[1] = (int) d.Count + 2;
                for(int i = 0; i < d.Keys.ToArray().Length; i++){
                    bookingObj[i+2] = (Seat) d.Keys.ToArray()[i]; // Add all seats for the show
                }
                formatter.Serialize(fs, bookingObj);
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
            grPhoto.Clear(Color.FromArgb(240,240,240));
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private void btnClear_Click(object sender, EventArgs e) {
            rTxtMessages.Clear();
        }

        /// http://aviadezra.blogspot.sg/2008/07/code-sample-net-sockets-multiple.html

        public delegate void BroadcastMsgCallback(String msg);

        public void BroadcastMsg(String msg) {

            if (this.InvokeRequired) {
                BroadcastMsgCallback d = new BroadcastMsgCallback(BroadcastMsg);
                this.Invoke(d, msg);
                return;
            }
            string[] lines = msg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++) {
                rTxtMessages.AppendText(lines[i] + "\r\n");
            }
        }

        private void listTime_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < listTime.Items.Count; i++) {
                if (listTime.Items[i].Selected) {
                    cobTime.SelectedIndex = i;
                }
            }
        }
    }
}
