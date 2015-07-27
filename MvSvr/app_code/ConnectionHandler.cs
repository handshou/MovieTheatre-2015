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
        private List<Socket> clients = new List<Socket>();
        private Form1 form;
        private FileInfo f;
        private FileStream fs;
        private NetworkStream ns;
        private StreamReader reader;
        private StreamWriter writer;
        private BinaryReader br;
        private IFormatter formatter;
        private Dictionary<String, Movie> movies = new Dictionary<String, Movie>();

        // Test
        public Dictionary<String, Car> carInfo = new Dictionary<String, Car>();

        string infoFile = @"info.dat";
        private long filesize = 0;
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

                if (connections == 1)
                    form.DisplayMsg("New client accepted: " + connections + " active connection");
                else
                    form.DisplayMsg("New client accepted: " + connections + " active connections");

                string cmd;
                while (true) {
                    data = new Byte[1024];
                    /* R */
                    int size = client.Receive(data);
                    cmd = Encoding.ASCII.GetString(data, 0, size);
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
                ns.Close();
                client.Close();
                connections--;
                if (connections == 1)
                    form.DisplayMsg("Client disconnected: " + connections + " active connection");
                else
                    form.DisplayMsg("Client disconnected: " + connections + " active connections");
            } catch (Exception ex) {
                connections--;
                if (connections == 1)
                    form.DisplayMsg("Client disconnected: " + connections + " active connection");
                else
                    form.DisplayMsg("Client disconnected: " + connections + " active connections");
                form.DisplayMsg(ex.Message);
            }
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=0VmFdYWdSSU
        /// </summary>
        public void Browse() {
            formatter = new BinaryFormatter();

            Car car;
            car = new Car();
            car.Name = "Test";
            car.Number = 1;

            carInfo.Add(car.Name, car);

            using (fs = new FileStream(infoFile, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, carInfo.Values.ToArray());
                fs.Close();
            }

            f = new FileInfo(infoFile);
            filesize = f.Length;
            data = new byte[filesize]; // create data for file

            /* S */ // sending filesize
            client.Send(Encoding.ASCII.GetBytes(filesize.ToString()));
            form.DisplayMsg(filesize.ToString());
            /* S */ // sending file
            byte[] buffer = null;
            using (fs = new FileStream(infoFile, FileMode.Open, FileAccess.Read)) {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
            }
            // byte[] buffer = File.ReadAllBytes(infoFile);
            try {
                client.Send(buffer);
            } catch (Exception ex) {
                form.DisplayMsg(ex.Message);
            }

            form.DisplayMsg("Files sent");

        }

        //public void Browse() {
        //    formatter = new BinaryFormatter();
        //    data = new byte[8192];

        //    form.DisplayMsg("Browsing...");

        //    // Number of movies
        //    // data = Encoding.ASCII.GetBytes(movies.Count.ToString());
        //    form.DisplayMsg(movies.Count.ToString());
        //    /* S */ //client.Send(data);
        //    /* S */ //foreach (KeyValuePair<String, Movie> m in movies) {
        //                Car m = new Car();
        //                m.Name = "test";
        //                formatter.Serialize(ns, m);
        //                form.DisplayMsg("Sending movie...");
        //            //}

        //    // End of file
        //    //data = Encoding.ASCII.GetBytes(ENDOFF);
        //    ///* S */ ns.Write(data, 0, data.Length);
        //    //        ns.Flush();

        //}

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
