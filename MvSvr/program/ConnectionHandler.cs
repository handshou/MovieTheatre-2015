using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

/// https://www.youtube.com/watch?v=0VmFdYWdSSU - Serialize Deserialize into Collection

namespace MvSvr {

    class ConnectionHandler {

        // Attributes
        private string cmd;
        private string user;

        private String browseFile = @"browse.dat";
        private String searchFile = @"search.dat";
        private int size = 0;
        private long filesize = 0;
        private static int connections = 0;
        private byte[] data = new byte[1024];

        private FileInfo f;
        private FileStream fs;
        private NetworkStream ns;
        private IFormatter formatter;

        public const String BROWSE = "[BRWS]";
        public const String SEARCH = "[SRCH]";
        public const String BOOKNG = "[BOOK]";
        public const String ENDOFF = "[ENDO]";
        public const String FINISH = "[QUIT]";

        // Connection Attributes
        private Form1 form;
        private Socket client;
        private List<Socket> clients = new List<Socket>();
        private Dictionary<String, Movie> movieInfo = new Dictionary<String, Movie>();

        // Constructor
        public ConnectionHandler(Socket client, Form1 form, ref Dictionary<String, Movie> movieInfo, ref List<Socket> clients) {

            this.client = client;
            this.form = form;
            this.movieInfo = movieInfo;
            this.clients = clients;
        }

        // Methods
        public void HandleConnection(Object state) {

            int size = 0;
            try {
                ns = new NetworkStream(client);
                connections++;
                DisplayClientMsg(connections);

                /* R */
                // Receive user
                data = new byte[1024];

                user = ReceiveCommand();
                form.DisplayMsg("Welcome " + user + "!");

                while (true) {
                    /* R */
                    // Receive command
                    cmd = ReceiveCommand();
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
                        default: form.DisplayMsg("Unknown command received!");
                            break;
                    }
                    if (cmd == FINISH)
                        break;
                }

            } catch (SocketException) {

                clients.Remove(client);
                connections--;
                DisplayDisconnectMsg(connections);

            } catch (Exception ex) {

                form.DisplayMsg(ex.Message);
            }
        }

        public void Browse() {

            SaveToFile(browseFile, movieInfo);
            SendFile(browseFile);
        }

        public void Search() {

            String type = "", 
                   terms = "";

            /* R */ // Receive search type
            /* R */ // Receive search terms
            type = ReceiveCommand();
            terms = ReceiveCommand().ToLower();

            Dictionary<String, Movie> searchInfo;
            searchInfo = SearchMovies(type, terms);

            SaveToFile(searchFile, searchInfo);
            SendFile(searchFile);
        }

        public Dictionary<String, Movie> SearchMovies(String type, String terms){

            Dictionary<String, Movie> d = new Dictionary<String, Movie>();
            if (type == "genre") {
                foreach (KeyValuePair<String, Movie> m in movieInfo) {
                    if (m.Value.Genre.Contains(terms)) {
                        d.Add(m.Key, m.Value);
                    }
                }
            }
            if (type == "director") {
                foreach (KeyValuePair<String, Movie> m in movieInfo) {
                    if (m.Value.Director.Contains(terms)) {
                        d.Add(m.Key, m.Value);
                    }
                }
            }
            if (type == "title") {
                foreach (KeyValuePair<String, Movie> m in movieInfo) {
                    if (m.Key.Contains(terms)) {
                        d.Add(m.Key, m.Value);
                    }
                }
            }
            return d;
        }

        public void Book() {
            
            Booking b = new Booking();
            lock (b) {
                
            }
        }

        public void Quit() {

            if (ns != null)
                ns.Close();
            if (client != null)
                client.Close();

            clients.Remove(client);
            connections--;
            form.DisplayMsg("Client disconnected: " + connections + " active connections");
        }

        public void SaveToFile(String filePath, Dictionary<String, Movie> d) {

            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, d.Values.ToArray());
                fs.Close();
            }
        }

        public void SaveMovieToFile(String filePath) {

            formatter = new BinaryFormatter();
            using (fs = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                formatter.Serialize(fs, movieInfo.Values.ToArray());
                fs.Close();
            }
        }

        public String ReceiveCommand() {
            data = new byte[1024];
            size = client.Receive(data);

            return Encoding.ASCII.GetString(data, 0, size);
        }

        public void SendFile(String filePath) {

            f = new FileInfo(filePath);
            filesize = f.Length;
            data = new byte[filesize];

            /* S */ // Sending file size
            client.Send(Encoding.ASCII.GetBytes(filesize.ToString()));

            /* S */ // Sending file
            byte[] buffer = null;
            using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
            }

            try {
                client.Send(buffer);
                form.DisplayMsg("Files sent"); // (!) Remove when complete
            } catch (Exception ex) {
                form.DisplayMsg(ex.Message);
            }
        }

        public void ReceiveFile(String filePath) {

            /* R */ // Receive file size
            int size = 0;
            data = new byte[1024];
            try {
                size = client.Receive(data);
            } catch (Exception ex) {
                form.DisplayMsg("Error receiving file (filesize)\n" + ex.Message);
            }
            filesize = Convert.ToInt64(Encoding.ASCII.GetString(data));

            /* R */ // Receive file
            data = new byte[filesize];
            try {
                size = client.Receive(data);
                form.DisplayMsg("File received"); // (!) Remove when complete
            } catch (Exception ex) {
                form.DisplayMsg("Error receiving file (file)\n" + ex.Message);
            }

            if (!File.Exists(filePath)) {
                File.Create(filePath);
            }

            // Will overwrite existing file
            using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Write)) {
                fs.Write(data, 0, Convert.ToInt32(filesize));
                fs.Flush();
                fs.Close();
            }
        }

        public void LoadMovieFile(String filePath) {

            try {
                using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                    Movie[] m_info = (Movie[])formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    movieInfo = m_info.ToDictionary((u) => u.Title, (u) => u);
                }
            } catch (Exception ex) {
                form.DisplayMsg(ex.Message);
            }
        }

        public void DisplayClientMsg(int connections) {

            if (connections == 1)
                form.DisplayMsg("New client accepted: " + connections + " active connection");
            else
                form.DisplayMsg("New client accepted: " + connections + " active connections");
        }

        public void DisplayDisconnectMsg(int connections) {

            if (connections == 1)
                form.DisplayMsg("Client disconnected: " + connections + " active connection");
            else
                form.DisplayMsg("Client disconnected: " + connections + " active connections");
        }
    }
}
