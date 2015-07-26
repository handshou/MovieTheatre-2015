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

namespace MvSysClient {
    public partial class Form1 : Form 
    {

        public static Socket socket = new Socket(AddressFamily.InterNetwork,
                          SocketType.Stream, ProtocolType.Tcp);

        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";

        public Form1()
        {

            InitializeComponent();

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse
                                              ("127.0.0.1"), 9070);

            try
            {
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
                
                Thread t = new Thread(runClient);
                //t.IsBackground = true;
                t.Start();

            }
            catch (SocketException ex)
            {
                rTxtMessages.Text = "Unable to connect to the movie server." + ex;
                rTxtMessages.AppendText("\nPlease check if the server is running.");
                return;
            }

        }

        
        

        public void runClient()
            //this method starts a thread
            //called when the client has connected to the server
        {
            rTxtMessages.Text = "Welcome to the Movie Booking System.";
            //DisplayMsg("\nYou may find your desired movies either by browsing or searching with a keyword.");

            cobSearch.SelectedIndex = 0;

            //loadMovieDetails();
        }

        public void loadMovieDetails()
            //this method adds the details of a selected movie to the form for users to refer to
            //called when a thread is started
        {
            //hardcoded times:

            lblShowName.Visible = true;
            lblShowDirector.Visible = true;
            lblShowGenre.Visible = true;

            lblMvName.Visible = true;
            lblMvGenre.Visible = true;
            lblMvDirector.Visible = true;

            cobTime.Enabled = true;
            cobSeat.Enabled = true;

            lblMvName.Text = "Best Movie 5";
            lblMvGenre.Text = "Action";
            lblMvDirector.Text = "Bobby Han";

            //cobTime.Items.Add("10:00");
            //cobTime.Items.Add(5);

            ArrayList s = new ArrayList();
            s.Add("10:00");  s.Add("12:00");  s.Add("14:00");
            cobTime.DataSource = s;

            cobTime.SelectedIndex = 0;

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //kills all bckgrnd thread under this prog
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //request for movies from server
            BinaryFormatter formatter = new BinaryFormatter();

            byte[] data = new byte[1024];

            data = Encoding.ASCII.GetBytes(BROWSE);

            socket.Send(data); //this ends the browse request
            
            Movie m = null;

            data = new byte[1024];
            int size = socket.Receive(data);

            NetworkStream ns = new NetworkStream(socket);
            try {
                m = (Movie)formatter.Deserialize(ns);
            } catch (Exception ex) {
                rTxtMessages.Text = ex.Message;
            }
        }



    }

}
