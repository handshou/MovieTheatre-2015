using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MvSvr {
    class ConnectionHandler {
        // Attributes
        private Socket client;
        private Form1 form;
        private NetworkStream ns;
        private StreamReader reader;
        private StreamWriter writer;
        private BinaryFormatter formatter;
        private Dictionary<String, Movie> movies = new Dictionary<String, Movie>();
        private static int connections = 0;
        private byte[] data = new byte[1024];

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";

        // Constructor
        public ConnectionHandler(Socket client, Form1 form, ref Dictionary<String, Movie> movies) {
            this.client = client;
            this.form = form;
            this.movies = movies;
        }

        // Methods
        public void HandleConnection(Object state) {
            try {
                ns = new NetworkStream(client);
                reader = new StreamReader(ns);
                writer = new StreamWriter(ns);
                connections++;
                form.DisplayMsg("New client accepted: " + connections +
                    "active connections");

                string cmd;
                while (true) {
                    data = new Byte[1024];
                    /* R */

                    int size = client.Receive(data);
                    cmd = Encoding.ASCII.GetString(data, 0, size);
                    form.DisplayMsg(cmd);
                    
                    //switch (cmd) {
                    //    case BROWSE: Browse();
                    //        form.DisplayMsg("Browsing");
                    //        break;
                    //    case SEARCH: Search();
                    //        break;
                    //    case BOOKNG: Book();
                    //        break;
                    //    default:
                    //        form.DisplayMsg("Unknown Command Message");
                    //        break;
                    //}

                    if (cmd == BROWSE)
                        Browse();
                    else 
                        if (cmd == SEARCH)
                            Search();
                    else 
                        if (cmd == BOOKNG) {
                            Book();
                    } else 
                        if (cmd == FINISH)
                            break;
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

        public void Browse() {
            formatter = new BinaryFormatter();
            data = new byte[1024];

            form.DisplayMsg("Browsing...");

            // Number of movies
            data = Encoding.ASCII.GetBytes(movies.Count.ToString());
            /* S */ ns.Write(data, 0, data.Length);
                    ns.Flush();

            /* S */
            foreach (KeyValuePair<String, Movie> m in movies) {
                formatter.Serialize(ns, m);
                form.DisplayMsg("Sending movie...");
            }

            // End of file
            //data = Encoding.ASCII.GetBytes(ENDOFF);
            ///* S */ ns.Write(data, 0, data.Length);
            //        ns.Flush();

        }

        public void Search() {

        }

        public void Book() {
            
        }
    }
}
