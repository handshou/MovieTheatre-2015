using System;
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

        public void ConnectClient() {
            int port = 9070;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, 
                                                            ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            server.Bind(endpoint);
            server.Listen(10);
            Console.WriteLine("Waiting for clients on port " + port);
            while(true) 
            {
                try 
                {
                    Socket client = server.Accept();
                    ConnectionHandler handler = new ConnectionHandler(client);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(handler.HandleConnection));
                } catch(Exception) {
                    Console.WriteLine("Connection falied on port " + port);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {

        }

        private void btnList_Click(object sender, EventArgs e) {

        }
    }

    class ConnectionHandler {
        private Socket client;
        private NetworkStream ns;
        private StreamReader reader;
        private StreamWriter writer;
        private static int connections = 0;
        public ConnectionHandler(Socket client) {
            this.client = client;
        }
        public void HandleConnection(Object state) {
            try {
                ns = new NetworkStream(client);
                reader = new StreamReader(ns);
                writer = new StreamWriter(ns);
                connections++;
                Console.WriteLine("New client accepted : " + connections + " active connections");
                writer.WriteLine("Welcome to my server");
                writer.Flush();
                                
                string input;
                while (true) {
                    input = reader.ReadLine();
                    if (input.Length == 0 || input.ToLower() == "exit")
                        break;
                    writer.WriteLine(input);
                    writer.Flush();
                }
                ns.Close();
                client.Close();
                connections--;
                Console.WriteLine("Client disconnected : " + connections + " activer connections");
            }
            catch (Exception) {
                connections--;
                Console.WriteLine("Client disconnected : " + connections + " activer connections");
            }
        }
    }
}
