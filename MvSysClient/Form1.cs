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

namespace MvSysClient {
    public partial class Form1 : Form {
        public Form1()
        {

            InitializeComponent();
            /*Thread t  = new Thread(runClient)
            t.IsBackground = true;
            t.Start();

            */

        }

        public void regextest()
        {
            string word = "";
            string meaning = "";

            Regex regex1 = new Regex(@"^[a-zA-Z]+$");
            Regex regex2 = new Regex(@"^[\[][a-zA-Z]+[\]]");

            if (regex1.IsMatch(word) && regex2.IsMatch(meaning))
            {
                /*if (!dic.ContainsKey(word)) //check if not inside
                {
                    dic.Add(word, meaning); //adds
                }*/

                //else means dictionary contains word
                //no new word added
            }

            //else means got input error
        }

        public void processkiller()
        {
            Thread t = new Thread(runServer);
            //make thread background


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //kills all bckgrnd thread under this prog
        }

        public void runServer()
        {

        }

        //public void when listMovies value changed due to file transfer
        /* enable listMovies control
         */

        //public void when value in listmovie is selected
        /* enable relevant controls related to selecting a movie
         * populate cobTime with movie times retrieved from server
         * populate quantity with 1 to 10
         * change label values to fit Movie Name, Director and 
         */


        // '^' = start of expression
        // '$' = end of expression

    }
}
