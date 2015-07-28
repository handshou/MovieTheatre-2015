namespace MvSysClient {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("wdwdw");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("ffdwewdw");
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.listTime = new System.Windows.Forms.ListView();
            this.cobTime = new System.Windows.Forms.ComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.rTxtMessages = new System.Windows.Forms.RichTextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cobSearch = new System.Windows.Forms.ComboBox();
            this.listMovies = new System.Windows.Forms.ListBox();
            this.lblShowName = new System.Windows.Forms.Label();
            this.lblShowGenre = new System.Windows.Forms.Label();
            this.lblShowDirector = new System.Windows.Forms.Label();
            this.lblMvName = new System.Windows.Forms.Label();
            this.lblMvGenre = new System.Windows.Forms.Label();
            this.lblMvDirector = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveBH = new System.Windows.Forms.Button();
            this.btnViewBH = new System.Windows.Forms.Button();
            this.lblBoardMessage = new System.Windows.Forms.Label();
            this.cobSeat = new System.Windows.Forms.ComboBox();
            this.lblSeatNo = new System.Windows.Forms.Label();
            this.pnSeats = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblMvDescription = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(14, 121);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(123, 79);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse movies";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(150, 175);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search movie:";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBook
            // 
            this.btnBook.Enabled = false;
            this.btnBook.Location = new System.Drawing.Point(708, 348);
            this.btnBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(93, 78);
            this.btnBook.TabIndex = 3;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            // 
            // picPoster
            // 
            this.picPoster.Image = ((System.Drawing.Image)(resources.GetObject("picPoster.Image")));
            this.picPoster.Location = new System.Drawing.Point(391, 212);
            this.picPoster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(271, 239);
            this.picPoster.TabIndex = 5;
            this.picPoster.TabStop = false;
            // 
            // listTime
            // 
            this.listTime.Enabled = false;
            this.listTime.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6});
            this.listTime.Location = new System.Drawing.Point(867, 201);
            this.listTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listTime.Name = "listTime";
            this.listTime.Size = new System.Drawing.Size(100, 346);
            this.listTime.TabIndex = 7;
            this.listTime.UseCompatibleStateImageBehavior = false;
            // 
            // cobTime
            // 
            this.cobTime.Enabled = false;
            this.cobTime.FormattingEnabled = true;
            this.cobTime.Location = new System.Drawing.Point(683, 242);
            this.cobTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cobTime.Name = "cobTime";
            this.cobTime.Size = new System.Drawing.Size(137, 24);
            this.cobTime.TabIndex = 8;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(710, 212);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(91, 17);
            this.labelTime.TabIndex = 10;
            this.labelTime.Text = "Time Chosen";
            // 
            // rTxtMessages
            // 
            this.rTxtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtMessages.Location = new System.Drawing.Point(307, 12);
            this.rTxtMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rTxtMessages.Name = "rTxtMessages";
            this.rTxtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTxtMessages.Size = new System.Drawing.Size(834, 143);
            this.rTxtMessages.TabIndex = 13;
            this.rTxtMessages.Text = "I am text box";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(150, 149);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(147, 22);
            this.txtSearch.TabIndex = 14;
            // 
            // cobSearch
            // 
            this.cobSearch.Enabled = false;
            this.cobSearch.FormattingEnabled = true;
            this.cobSearch.Items.AddRange(new object[] {
            "Name",
            "Genre",
            "Director"});
            this.cobSearch.Location = new System.Drawing.Point(150, 119);
            this.cobSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cobSearch.Name = "cobSearch";
            this.cobSearch.Size = new System.Drawing.Size(105, 24);
            this.cobSearch.TabIndex = 15;
            this.cobSearch.Text = "--Search By--";
            this.cobSearch.SelectedIndexChanged += new System.EventHandler(this.cobSearch_SelectedIndexChanged);
            // 
            // listMovies
            // 
            this.listMovies.DisplayMember = "string";
            this.listMovies.FormattingEnabled = true;
            this.listMovies.ItemHeight = 16;
            this.listMovies.Location = new System.Drawing.Point(12, 244);
            this.listMovies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listMovies.Name = "listMovies";
            this.listMovies.Size = new System.Drawing.Size(357, 308);
            this.listMovies.TabIndex = 18;
            this.listMovies.SelectedIndexChanged += new System.EventHandler(this.listMovies_SelectedIndexChanged);
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowName.Location = new System.Drawing.Point(391, 466);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(92, 19);
            this.lblShowName.TabIndex = 19;
            this.lblShowName.Text = "Movie Name:";
            this.lblShowName.Visible = false;
            // 
            // lblShowGenre
            // 
            this.lblShowGenre.AutoSize = true;
            this.lblShowGenre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowGenre.Location = new System.Drawing.Point(391, 497);
            this.lblShowGenre.Name = "lblShowGenre";
            this.lblShowGenre.Size = new System.Drawing.Size(54, 19);
            this.lblShowGenre.TabIndex = 20;
            this.lblShowGenre.Text = "Genre:";
            this.lblShowGenre.Visible = false;
            // 
            // lblShowDirector
            // 
            this.lblShowDirector.AutoSize = true;
            this.lblShowDirector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowDirector.Location = new System.Drawing.Point(391, 528);
            this.lblShowDirector.Name = "lblShowDirector";
            this.lblShowDirector.Size = new System.Drawing.Size(64, 19);
            this.lblShowDirector.TabIndex = 21;
            this.lblShowDirector.Text = "Director:";
            this.lblShowDirector.Visible = false;
            // 
            // lblMvName
            // 
            this.lblMvName.AutoSize = true;
            this.lblMvName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvName.Location = new System.Drawing.Point(489, 466);
            this.lblMvName.Name = "lblMvName";
            this.lblMvName.Size = new System.Drawing.Size(63, 19);
            this.lblMvName.TabIndex = 22;
            this.lblMvName.Text = "mvname";
            this.lblMvName.Visible = false;
            // 
            // lblMvGenre
            // 
            this.lblMvGenre.AutoSize = true;
            this.lblMvGenre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvGenre.Location = new System.Drawing.Point(489, 497);
            this.lblMvGenre.Name = "lblMvGenre";
            this.lblMvGenre.Size = new System.Drawing.Size(65, 19);
            this.lblMvGenre.TabIndex = 23;
            this.lblMvGenre.Text = "mvgenre";
            this.lblMvGenre.Visible = false;
            // 
            // lblMvDirector
            // 
            this.lblMvDirector.AutoSize = true;
            this.lblMvDirector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvDirector.Location = new System.Drawing.Point(489, 528);
            this.lblMvDirector.Name = "lblMvDirector";
            this.lblMvDirector.Size = new System.Drawing.Size(76, 19);
            this.lblMvDirector.TabIndex = 24;
            this.lblMvDirector.Text = "mvdirector";
            this.lblMvDirector.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "lblBookMessage";
            this.label1.Visible = false;
            // 
            // btnSaveBH
            // 
            this.btnSaveBH.Enabled = false;
            this.btnSaveBH.Location = new System.Drawing.Point(1161, 91);
            this.btnSaveBH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveBH.Name = "btnSaveBH";
            this.btnSaveBH.Size = new System.Drawing.Size(123, 52);
            this.btnSaveBH.TabIndex = 26;
            this.btnSaveBH.Text = "Save booking history";
            this.btnSaveBH.UseVisualStyleBackColor = true;
            // 
            // btnViewBH
            // 
            this.btnViewBH.Enabled = false;
            this.btnViewBH.Location = new System.Drawing.Point(1161, 23);
            this.btnViewBH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewBH.Name = "btnViewBH";
            this.btnViewBH.Size = new System.Drawing.Size(123, 52);
            this.btnViewBH.TabIndex = 27;
            this.btnViewBH.Text = "View booking history";
            this.btnViewBH.UseVisualStyleBackColor = true;
            // 
            // lblBoardMessage
            // 
            this.lblBoardMessage.AutoSize = true;
            this.lblBoardMessage.Location = new System.Drawing.Point(304, 175);
            this.lblBoardMessage.Name = "lblBoardMessage";
            this.lblBoardMessage.Size = new System.Drawing.Size(117, 17);
            this.lblBoardMessage.TabIndex = 28;
            this.lblBoardMessage.Text = "lblBoardMessage";
            this.lblBoardMessage.Visible = false;
            // 
            // cobSeat
            // 
            this.cobSeat.Enabled = false;
            this.cobSeat.FormattingEnabled = true;
            this.cobSeat.Location = new System.Drawing.Point(719, 303);
            this.cobSeat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cobSeat.Name = "cobSeat";
            this.cobSeat.Size = new System.Drawing.Size(71, 24);
            this.cobSeat.TabIndex = 30;
            // 
            // lblSeatNo
            // 
            this.lblSeatNo.AutoSize = true;
            this.lblSeatNo.Location = new System.Drawing.Point(710, 279);
            this.lblSeatNo.Name = "lblSeatNo";
            this.lblSeatNo.Size = new System.Drawing.Size(91, 17);
            this.lblSeatNo.TabIndex = 31;
            this.lblSeatNo.Text = "Seat Number";
            // 
            // pnSeats
            // 
            this.pnSeats.Location = new System.Drawing.Point(983, 242);
            this.pnSeats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnSeats.Name = "pnSeats";
            this.pnSeats.Size = new System.Drawing.Size(299, 270);
            this.pnSeats.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "User:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(80, 23);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(175, 22);
            this.txtUser.TabIndex = 38;
            // 
            // lblMvDescription
            // 
            this.lblMvDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMvDescription.Location = new System.Drawing.Point(651, 468);
            this.lblMvDescription.Name = "lblMvDescription";
            this.lblMvDescription.Size = new System.Drawing.Size(198, 79);
            this.lblMvDescription.TabIndex = 39;
            this.lblMvDescription.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(35, 62);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(102, 40);
            this.btnLogin.TabIndex = 40;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(164, 62);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(102, 40);
            this.btnLogout.TabIndex = 43;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 567);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblMvDescription);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnSeats);
            this.Controls.Add(this.lblSeatNo);
            this.Controls.Add(this.cobSeat);
            this.Controls.Add(this.lblBoardMessage);
            this.Controls.Add(this.btnViewBH);
            this.Controls.Add(this.btnSaveBH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMvDirector);
            this.Controls.Add(this.lblMvGenre);
            this.Controls.Add(this.lblMvName);
            this.Controls.Add(this.lblShowDirector);
            this.Controls.Add(this.lblShowGenre);
            this.Controls.Add(this.lblShowName);
            this.Controls.Add(this.listMovies);
            this.Controls.Add(this.cobSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.rTxtMessages);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.cobTime);
            this.Controls.Add(this.listTime);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.picPoster);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowse);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.ListView listTime;
        private System.Windows.Forms.ComboBox cobTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.RichTextBox rTxtMessages;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cobSearch;
        private System.Windows.Forms.ListBox listMovies;
        private System.Windows.Forms.Label lblShowName;
        private System.Windows.Forms.Label lblShowGenre;
        private System.Windows.Forms.Label lblShowDirector;
        private System.Windows.Forms.Label lblMvName;
        private System.Windows.Forms.Label lblMvGenre;
        private System.Windows.Forms.Label lblMvDirector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveBH;
        private System.Windows.Forms.Button btnViewBH;
        private System.Windows.Forms.Label lblBoardMessage;
        private System.Windows.Forms.ComboBox cobSeat;
        private System.Windows.Forms.Label lblSeatNo;
        private System.Windows.Forms.Panel pnSeats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMvDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
    }
}

