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
using System.Collections;

namespace MvSysClient {
    public partial class Form1 : Form {
        public Form1()
        {

            InitializeComponent();
            Thread t = new Thread(runClient);
            t.IsBackground = true;
            t.Start(1);

            loadMovieDetails();

            List<Block> blocks = new List<Block>
            {
                new Block { Name = "A", Rows = 3, Seats = 5 },
            };

            Block block = blocks[0];

            //rTxtMessages.Text = "Showing seat block: " + block.Name;

            for (int y = 0; y <= 1; y++)
            {

                Label column1 = new Label();
                column1.Top = y * 20;
                column1.Width = 50;
                column1.Height = 20;
                column1.Text = (y + 1).ToString();
                this.pnSeats.Controls.Add(column1);

                for (int x = 0; x <= block.Seats; x++)
                {

                    {
                        Label column = new Label();
                        column.Top = y * 20;
                        column.Width = 50;
                        column.Height = 20;
                        column.Text = (y + 1).ToString();
                        this.pnSeats.Controls.Add(column);
                    }

                }
            }

            for (int y = 0; y < block.Rows; y++)
            {

                Label label = new Label();
                label.Top = y * 20;
                label.Width = 50;
                label.Height = 20;
                label.Text = (y+1).ToString();
                this.pnSeats.Controls.Add(label);

                for (int x = 0; x <= block.Seats; x++)
                {

                    {
                        CheckBox chkbx = new CheckBox();
                        chkbx.Left = x * 50;
                        chkbx.Top = y * 20;
                        chkbx.Width = 50;
                        chkbx.Height = 20;
                        chkbx.Checked = false;

                        this.pnSeats.Controls.Add(chkbx);
                    }

                }
            }

        }

        public struct Block
        {
            public string Name { get; set; }
            public int Rows { get; set; }
            public int Seats { get; set; }
        }

        public void loadMovieDetails()
            //this method adds the details of a selected movie to the form for users to refer to
            //called by 
        {
            //hardcoded times:

            lblShowName.Visible = true;
            lblShowDirector.Visible = true;
            lblShowGenre.Visible = true;

            lblMvName.Visible = true;
            lblMvGenre.Visible = true;
            lblMvDirector.Visible = true;

            cobTime.Enabled = true;
            cobSeat.Enabled = true;

            lblMvName.Text = "Best Movie 5";
            lblMvGenre.Text = "Action";
            lblMvDirector.Text = "Bobby Han";

            //cobTime.Items.Add("10:00");
            //cobTime.Items.Add(5);

            ArrayList s = new ArrayList();
            s.Add("10:00");  s.Add("12:00");  s.Add("14:00");
            cobTime.DataSource = s;

            cobTime.SelectedIndex = 0;

        }

        /*public void processkiller()
        {
            Thread t = new Thread(runClient);
            t.IsBackground = true;
            //make thread background
        }*/

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //kills all bckgrnd thread under this prog
        }

        public void runClient(object state)
        {
            //thread created
            rTxtMessages.Text = "Thread " + state.ToString() + "established".;
            
        }

    }
}
