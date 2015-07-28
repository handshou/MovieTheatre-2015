﻿using System;
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
        private String infoFile = @"movieInfo.dat";
        private FileStream fs;
        private IFormatter formatter;
        private Dictionary<String, Movie> movieInfo = new Dictionary<String, Movie>();

        // Connection Attributes
        private static int port = 9070;
        private static IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Socket> clients = new List<Socket>();

        public delegate void DisplayMsgCallback(String msg);

        public Form1() {

            InitializeComponent();
            LoadMovies();
            Thread t = new Thread(ConnectClient);
            t.IsBackground = true;
            t.Start();
        }

        public void ConnectClient() {

            server.Bind(endpoint);
            server.Listen(10);
            while(true) {
                try {
                    Socket client = server.Accept();
                    clients.Add(client);
                    ConnectionHandler handler = new ConnectionHandler(client, this, ref movieInfo, ref clients);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(handler.HandleConnection));

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {

            Application.Exit();
        }

        public Image GetImage(String imgPath) {

            Image img = Image.FromFile(imgPath);
            return img;
        }

        public void LoadMovies() {

            Movie m = new Movie();
            m.Title = "Batman";
            m.Genre = "Drama";
            m.Director = "Christopher Nolan";
            m.Poster = GetImage("poster\\the_dark_knight.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "1 January 2015", new Hall(), "0800", "1000", 8.00),
                new Show(m, "1 January 2015", new Hall(), "1600", "1800", 8.00),
                new Show(m, "2 January 2015", new Hall(), "2000", "2200", 8.00),
                new Show(m, "2 January 2015", new Hall(), "0800", "1000", 8.00),
                new Show(m, "3 January 2015", new Hall(), "1600", "1800", 8.00),
                new Show(m, "3 January 2015", new Hall(), "2000", "2200", 8.00),
            };
            movieInfo.Add(m.Title, m);

            m = new Movie();
            m.Title = "Batman Of The Future";
            m.Genre = "Animated";
            m.Director = "Steven Lim";
            m.Poster = GetImage("poster\\the_dark_knight.jpg");
            m.Shows = new List<Show> { 
                new Show(m, "3 July 2015", new Hall(), "0900", "1100", 8.00),
                new Show(m, "3 July 2015", new Hall(), "1700", "1900", 8.00),
                new Show(m, "3 July 2015", new Hall(), "2100", "2300", 8.00)
            };
            movieInfo.Add(m.Title, m);
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

                tbDisplay.AppendText(ex.Message + "\r\n");
            }
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
    }
}
