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

namespace MvSysClient {
    public partial class Form1 : Form 
    {

        public static Socket socket = new Socket(AddressFamily.InterNetwork,
                          SocketType.Stream, ProtocolType.Tcp);

        public FileStream fs;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;

        private long filesize = 0;
        public Dictionary<String, Movie> movieInfo = new Dictionary<String, Movie>();

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";

        public Thread t = null;

        public Boolean userInside = false;
        public String userID = "";

        public Form1()
        {

            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtUser.Text))
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

        private void btnLogout_Click(object sender, EventArgs e)
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
            cobTime.Enabled = false;
        }

        public void runClient()
            //this method starts a thread
            //called when the client has connected to the server and logged in with a userID
        {

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

        public void loadShowDetails()
            //this method adds the details of a selected show to the form for users to refer to
        {

            List<Block> blocks = new List<Block>
            {
                new Block { Name = "A", Rows = 3, Seats = 5 },
            };

            Block block = blocks[0];

            //rTxtMessages.Text = "Showing seat block: " + block.Name;

            for (int y = 0; y <= 1; y++)
            {

                Label column1 = new Label();
                column1.Top = y * 20;
                column1.Width = 50;
                column1.Height = 20;
                column1.Text = (y + 1).ToString();
                this.pnSeats.Controls.Add(column1);

                for (int x = 0; x <= block.Seats; x++)
                {

                    {
                        Label column = new Label();
                        column.Top = y * 20;
                        column.Width = 50;
                        column.Height = 20;
                        column.Text = (y + 1).ToString();
                        this.pnSeats.Controls.Add(column);
                    }

                }
            }

            for (int y = 0; y < block.Rows; y++)
            {

                Label label = new Label();
                label.Top = y * 20;
                label.Width = 50;
                label.Height = 20;
                label.Text = (y + 1).ToString();
                this.pnSeats.Controls.Add(label);

                for (int x = 0; x <= block.Seats; x++)
                {

                    {
                        CheckBox chkbx = new CheckBox();
                        chkbx.Left = x * 50;
                        chkbx.Top = y * 20;
                        chkbx.Width = 50;
                        chkbx.Height = 20;
                        chkbx.Checked = false;

                        this.pnSeats.Controls.Add(chkbx);
                    }

                }
            }

        }

        public struct Block
        {
            public string Name { get; set; }
            public int Rows { get; set; }
            public int Seats { get; set; }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //request for movies from server
            IFormatter formatter = new BinaryFormatter();

            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(BROWSE);

            socket.Send(data); //this sends the Browse request
            
            int size = 0;
            string infoFile = @"info.dat";

            //receiving file size
            data = new byte[1024];
            try {
                size = socket.Receive(data);
            } catch (Exception) {
                rTxtMessages.AppendText("Receiving file size error" + "\r\n");
            }

            filesize = Convert.ToInt64(Encoding.ASCII.GetString(data));

            rTxtMessages.Clear();
            rTxtMessages.AppendText(filesize + " (filesize) " + size + " (size)\r\n");

            //receiving file
            data = new byte[filesize];
            try {
                size = socket.Receive(data);
                rTxtMessages.AppendText("File received" + "\r\n");
            } catch (Exception) {
                rTxtMessages.AppendText("Receiving file error" + "\r\n");
            }

            //if (!File.Exists(infoFile)) {
            //    File.Create(infoFile);
            //}
            if (!File.Exists(infoFile)) {
                File.Create(infoFile);
            }
            using (fs = new FileStream(infoFile, FileMode.Open, FileAccess.Write)) {
                fs.Write(data, 0, Convert.ToInt32(filesize));
                fs.Flush();
                rTxtMessages.AppendText("File written" + "\r\n" + fs.Length + " bytes\r\n");
                fs.Close();
            }

            try {
                using (fs = new FileStream(infoFile, FileMode.Open, FileAccess.Read)) {
                    Movie[] m_info = (Movie[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    movieInfo = m_info.ToDictionary((u) => u.Title, (u) => u);
                    foreach (KeyValuePair<String, Movie> infos in movieInfo) {
                        rTxtMessages.AppendText(infos.Value.Title + "\r\n");
                        rTxtMessages.AppendText(infos.Value.Genre + "\r\n");

                        Movie mv = new Movie(infos.Value.Title, infos.Value.Description, infos.Value.Genre, infos.Value.Shows);

                        //listMovies.Items.Add(movieInfo[infos.Value.Title].toString());
                        listMovies.Items.Add(mv.Title);

                    }
                }
            } catch (Exception ex) {
                rTxtMessages.AppendText(ex.Message);
            }

            //NetworkStream ns = new NetworkStream(socket);
            //try {
            //    m = (Car) formatter.Deserialize(ns);
            //} catch (Exception ex) {
            //    rTxtMessages.Text = ex.Message;
            //}
        }

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

        private void showMovieDetails(Movie m)
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

            //lblMvDirector.Text = m.Director;
            //lblMvDescription.Text = m.Description;

            picPoster.Image = m.Poster;

            cobTime.Enabled = true;
            cobTime.Items.Clear();
            cobSeat.Enabled = true;

            List<Show> listShow = m.Shows;

            foreach( Show sh in listShow)
            {
                cobTime.Items.Add(sh.TimeStart);
            }

            cobTime.SelectedIndex = 0;

            double price = 0;
            lblPrice.Text = price.ToString();
            
        }

        private void cobTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            string movie = (string)listMovies.GetItemText(listMovies.SelectedItem);
            Movie m = movieInfo[movie];

            Show s = GetShow(m);

            Hall h = s.Hall;

            foreach (Seat seat in h.Seats)
            {
                cobSeat.Items.Add(seat.Name);
            }
        }

        public Show GetShow(Movie m)
        {
            int index = cobTime.SelectedIndex;
            return m.Shows[index];
        }

        public delegate void DisplayMsgCallback(String msg);
        public void DisplayMsg(String msg)
        {
            if (this.InvokeRequired)
            {
                DisplayMsgCallback d = new DisplayMsgCallback(DisplayMsg);
                this.Invoke(d, msg);
                return;
            }
            string[] lines = msg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                rTxtMessages.AppendText(lines[i] + "\r\n");
            }
        }

        private void cobSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobSearch.SelectedIndex != 0)
            {
                btnSearch.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //requests for movies from server under a search type and key
            //Sends request, search type and key
            //search runs in the server, results sent back
            //process results and show

            listMovies.Items.Clear();

            string searchType = (string)cobSearch.SelectedItem;
            string searchKey = txtSearch.Text;

            rTxtMessages.AppendText(searchType + searchKey);

            IFormatter formatter = new BinaryFormatter();

            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(SEARCH);
            socket.Send(data); //this sends the Search request

            data = Encoding.ASCII.GetBytes(searchType);
            socket.Send(data); //this sends the search term

            data = Encoding.ASCII.GetBytes(searchKey);
            socket.Send(data); //this sends the search key

            int size = 0;
            string infoFile = @"info.dat"; //temporary file for storage

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

            if (size != 0)
            {
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

                if (!File.Exists(infoFile))
                {
                    File.Create(infoFile);
                }
                using (fs = new FileStream(infoFile, FileMode.Open, FileAccess.Write))
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

                            Movie mv = new Movie(infos.Value.Title, infos.Value.Description, infos.Value.Genre, infos.Value.Shows);

                            //listMovies.Items.Add(movieInfo[infos.Value.Title].toString());
                            listMovies.Items.Add(mv.Title);

                        }
                    }
                }
                catch (Exception ex)
                {
                    rTxtMessages.AppendText("No movies can be found. " + ex.Message);
                }
            }

            else
            {
                rTxtMessages.AppendText("Search results returns nothing.");
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //kills all bckgrnd thread under this prog
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

            string time = (string)cobSearch.SelectedItem;
            int seatIndex = cobSeat.SelectedIndex;
            string price = lblPrice.Text;
            string line = "";

            string movie = (string)listMovies.GetItemText(listMovies.SelectedItem);
            Movie m = movieInfo[movie];
            Show s = GetShow(m);

            line = userID + ";" + m.Title + ";" + time + ";" + seatIndex + ";" + price;
            //hall or show + index of seat

            //sending to server
            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(BOOKNG); //sends prompt for server to receive a booking
            socket.Send(data);

            data = Encoding.ASCII.GetBytes(line); //sends the booking information
            socket.Send(data);

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
                result = "Failed";
            }

            finally
            {
                lblBoardMessage.Visible = true;
            }

            if (result == "Success")
            {
                lblBoardMessage.Text = "Your booking has been successful";
                lblBoardMessage.Font = new Font(lblBoardMessage.Font, FontStyle.Bold);
            }

            else
            {
                lblBoardMessage.Text = "Booking unsuccessful. Please contact a staff member for assistance.";
                lblBoardMessage.ForeColor = Color.Red;
            }

        }

        private void btnViewBHistory_Click(object sender, EventArgs e)
            //event is fired when user clicks view booking history
        {
            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(BOOKNG); //sends prompt for server to receive booking history
            socket.Send(data);

            data = Encoding.ASCII.GetBytes(userID); //sends the user ID
            socket.Send(data);

            string history = "";

            try
            {
                int size = 0;
                size = socket.Receive(data);
                history = Encoding.ASCII.GetString(data, 0, size);
                rTxtMessages.Clear();
                rTxtMessages.AppendText("Booking History:\n");

                if (!string.IsNullOrWhiteSpace(history))
                {
                    rTxtMessages.AppendText(history);
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

            btnSaveBHistory.Enabled = true;

        }

        private void btnSaveBHistory_Click(object sender, EventArgs e)
        {

        }

        

        

        

    }

}
