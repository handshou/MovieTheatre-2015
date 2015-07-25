using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    class ConnectionHandler {
        private Socket client { get; set; }
        private Form1 form { get; set; }
        private NetworkStream ns { get; set; }
        private StreamReader reader { get; set; }
        private StreamWriter writer { get; set; }
        private static int connections = 0;
        public ConnectionHandler(Socket client, Form1 form) {
            this.client = client;
            this.form = form;
        }

        public void HandleConnection(Object state) {
            try {
                ns = new NetworkStream(client);
                reader = new StreamReader(ns);
                writer = new StreamWriter(ns);
                connections++;
                form.DisplayMsg("New client accepted: " + connections +
                    "active connections");
                form.DisplayMsg("Welcome to my server");
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
                form.DisplayMsg("Client disconnected: " + connections + " active connections");
            } catch (Exception) {
                connections--;
                form.DisplayMsg("Client disconnected: " + connections + " active connections");
            }
        }
    }
}
