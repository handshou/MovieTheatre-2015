using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    class ConnectionHandler {
        // Attributes
        private Socket client;
        private TcpClient tcpclient;
        private Form1 form;
        private NetworkStream ns;
        private StreamReader reader;
        private StreamWriter writer;
        private IFormatter formatter;
        private MemoryStream memory;
        private Dictionary<String, Movie> movies = new Dictionary<String, Movie>();
        private static int connections = 0;
        private byte[] data = new byte[1024];

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";

        // Constructor
        public ConnectionHandler(TcpClient client, Form1 form, ref Dictionary<String, Movie> movies) {
            this.tcpclient = client;
            this.form = form;
            this.movies = movies;
        }

        // Methods
        public void HandleConnection(Object state) {
            try {
                // ns = new NetworkStream(client);
                ns = new NetworkStream(tcpclient.Client);
                reader = new StreamReader(ns);
                writer = new StreamWriter(ns);
                memory = new MemoryStream(data);
                connections++;

                String msg = "New client accepted: " + connections + " active connection";
                if (connections != 1)
                    msg += "s";
                form.DisplayMsg(msg);

                string cmd;
                while (true) {
                    data = new Byte[1024];
                    /* R */
                    ns.Read(data, 0, data.Length);
                    // int size = client.Receive(data);
                    cmd = Encoding.ASCII.GetString(data, 0, data.Length).Trim('\0');
                    form.DisplayMsg(cmd); // (!) Remove when complete
                    
                    switch (cmd) {
                        case BROWSE: Browse();
                            break;
                        case SEARCH: Search();
                            break;
                        case BOOKNG: Book();
                            break;
                        case FINISH: Quit();
                            break;
                        default:     form.DisplayMsg("Unknown command received!");
                            break;
                    }
                    if (cmd == FINISH)
                        break;
                }    
            } catch (Exception) {
                connections--;
                form.DisplayMsg("Client disconnected: " + connections + " active connections");
            }
        }

        public void Browse() {
            formatter = new BinaryFormatter();
            data = new byte[1024];

            form.DisplayMsg("Browsing...");

            // Number of movies
            data = Encoding.ASCII.GetBytes(movies.Count.ToString());
            String msg = "Sending " + movies.Count.ToString() + " movie";
            form.DisplayMsg(msg);
            if (movies.Count != 1)
                msg += "s";
            /* S */ ns.Write(data, 0, data.Length);
                    ns.Flush();
            /* S */ foreach (KeyValuePair<String, Movie> m in movies) {
                        formatter.Serialize(ns, m);
                    }
            form.DisplayMsg("Serialize completed");

            // End of file
            //data = Encoding.ASCII.GetBytes(ENDOFF);
            ///* S */ ns.Write(data, 0, data.Length);
            //        ns.Flush();

        }

        public void Search() {

        }

        public void Book() {
            
        }

        public void Quit() {
            if(ns != null)
                ns.Close();
            if(client != null)
                client.Close();
            connections--;
            form.DisplayMsg("Client disconnected: " + connections + " active connections");
        }
    }
}
