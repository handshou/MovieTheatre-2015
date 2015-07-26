using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvSvr {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            LoadMovies();
            Thread t = new Thread(ConnectClient);
            t.IsBackground = true;
            t.Start();
        }

        private Dictionary<String, Movie> movies = new Dictionary<String, Movie>();

        public List<Socket> clients = new List<Socket>();
        private static int port = 9070;
        private static TcpClient tcpclient;
        private static Socket server = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);
        private static IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

        public delegate void DisplayMsgCallback(String msg);
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

        public void LoadMovies() {
            Movie m = new Movie();
            m.Title = "Bat man";
            movies.Add(m.Title, m);

            m = new Movie();
            m.Title = "Bat man of the Future";
            movies.Add(m.Title, m);
        }

        public void ConnectClient() {
            server.Bind(endpoint);
            server.Listen(10);
            while(true) {
                try {
                    Socket client = server.Accept();
                    tcpclient = new TcpClient(endpoint);
                    clients.Add(client);
                    ConnectionHandler handler = new ConnectionHandler(tcpclient, this, ref movies);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(
                                                        handler.HandleConnection));
                } catch(Exception ex) {
                    // Error output
                    tbDisplay.AppendText("Connection failed on port " + port + "\r\n");
                    tbDisplay.AppendText(ex.ToString());
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {

        }

        private void btnList_Click(object sender, EventArgs e) {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
