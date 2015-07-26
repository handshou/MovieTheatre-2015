﻿using System;
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
            Thread t = new Thread(ConnectClient);
            t.IsBackground = true;
            t.Start();
        }
        private List<Socket> clients;
        private static int port = 9070;
        private Socket server = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        public Dictionary<String, Movie> movies = new Dictionary<String, Movie>();

        public delegate void DisplayMsgCallBack(String msg);
        public void DisplayMsg(String msg) {
            if (this.InvokeRequired) {
                DisplayMsgCallBack d = new DisplayMsgCallBack(DisplayMsg);
                this.Invoke(d, msg);
                return;
            }
            string[] lines = msg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++) {
                tbDisplay.AppendText(lines[i] + "\r\n");
            }
        }

        public void ConnectClient() {
            server.Bind(endpoint);
            server.Listen(10);
            while(true) {
                try {
                    Socket client = server.Accept();
                    clients.Add(client);
                    ConnectionHandler handler = new ConnectionHandler(client, this);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(
                                                        handler.HandleConnection));
                } catch(Exception) {
                    // Error output
                    tbDisplay.AppendText("Connection failed on port " + port + "\r\n");
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
