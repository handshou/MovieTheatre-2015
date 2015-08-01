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
            this.lblBookMessage = new System.Windows.Forms.Label();
            this.btnSaveBHistory = new System.Windows.Forms.Button();
            this.btnViewBHistory = new System.Windows.Forms.Button();
            this.cobSeat = new System.Windows.Forms.ComboBox();
            this.lblSeatNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblMvDescription = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cobDate = new System.Windows.Forms.ComboBox();
            this.lblBookingHistory = new System.Windows.Forms.Label();
            this.chkA1 = new System.Windows.Forms.CheckBox();
            this.chkA2 = new System.Windows.Forms.CheckBox();
            this.chkA3 = new System.Windows.Forms.CheckBox();
            this.chkA4 = new System.Windows.Forms.CheckBox();
            this.chkA5 = new System.Windows.Forms.CheckBox();
            this.chkB5 = new System.Windows.Forms.CheckBox();
            this.chkB4 = new System.Windows.Forms.CheckBox();
            this.chkB3 = new System.Windows.Forms.CheckBox();
            this.chkB2 = new System.Windows.Forms.CheckBox();
            this.chkB1 = new System.Windows.Forms.CheckBox();
            this.chkC5 = new System.Windows.Forms.CheckBox();
            this.chkC4 = new System.Windows.Forms.CheckBox();
            this.chkC3 = new System.Windows.Forms.CheckBox();
            this.chkC2 = new System.Windows.Forms.CheckBox();
            this.chkC1 = new System.Windows.Forms.CheckBox();
            this.chkD5 = new System.Windows.Forms.CheckBox();
            this.chkD4 = new System.Windows.Forms.CheckBox();
            this.chkD3 = new System.Windows.Forms.CheckBox();
            this.chkD2 = new System.Windows.Forms.CheckBox();
            this.chkD1 = new System.Windows.Forms.CheckBox();
            this.chkE5 = new System.Windows.Forms.CheckBox();
            this.chkE4 = new System.Windows.Forms.CheckBox();
            this.chkE3 = new System.Windows.Forms.CheckBox();
            this.chkE2 = new System.Windows.Forms.CheckBox();
            this.chkE1 = new System.Windows.Forms.CheckBox();
            this.lblScreen = new System.Windows.Forms.Label();
            this.lblBorder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnBrowse.Location = new System.Drawing.Point(581, 100);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(239, 136);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnSearch.Location = new System.Drawing.Point(17, 595);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 186);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBook
            // 
            this.btnBook.Enabled = false;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.Location = new System.Drawing.Point(454, 717);
            this.btnBook.Margin = new System.Windows.Forms.Padding(2);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(104, 64);
            this.btnBook.TabIndex = 3;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // picPoster
            // 
            this.picPoster.Image = ((System.Drawing.Image)(resources.GetObject("picPoster.Image")));
            this.picPoster.Location = new System.Drawing.Point(358, 249);
            this.picPoster.Margin = new System.Windows.Forms.Padding(2);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(200, 200);
            this.picPoster.TabIndex = 5;
            this.picPoster.TabStop = false;
            // 
            // listTime
            // 
            this.listTime.Enabled = false;
            this.listTime.Location = new System.Drawing.Point(358, 615);
            this.listTime.Margin = new System.Windows.Forms.Padding(2);
            this.listTime.Name = "listTime";
            this.listTime.Size = new System.Drawing.Size(200, 30);
            this.listTime.TabIndex = 7;
            this.listTime.UseCompatibleStateImageBehavior = false;
            // 
            // cobTime
            // 
            this.cobTime.Enabled = false;
            this.cobTime.FormattingEnabled = true;
            this.cobTime.Location = new System.Drawing.Point(454, 685);
            this.cobTime.Margin = new System.Windows.Forms.Padding(2);
            this.cobTime.Name = "cobTime";
            this.cobTime.Size = new System.Drawing.Size(104, 21);
            this.cobTime.TabIndex = 8;
            this.cobTime.SelectedIndexChanged += new System.EventHandler(this.cobTime_SelectedIndexChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(354, 688);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(69, 13);
            this.labelTime.TabIndex = 10;
            this.labelTime.Text = "Time Chosen";
            // 
            // rTxtMessages
            // 
            this.rTxtMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtMessages.Location = new System.Drawing.Point(17, 101);
            this.rTxtMessages.Margin = new System.Windows.Forms.Padding(2);
            this.rTxtMessages.Name = "rTxtMessages";
            this.rTxtMessages.ReadOnly = true;
            this.rTxtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTxtMessages.Size = new System.Drawing.Size(541, 134);
            this.rTxtMessages.TabIndex = 13;
            this.rTxtMessages.Text = "Welcome! Please login to continue..";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(17, 557);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(138, 31);
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
            this.cobSearch.Location = new System.Drawing.Point(17, 526);
            this.cobSearch.Margin = new System.Windows.Forms.Padding(2);
            this.cobSearch.Name = "cobSearch";
            this.cobSearch.Size = new System.Drawing.Size(138, 21);
            this.cobSearch.TabIndex = 15;
            this.cobSearch.Text = "-- Select search type --";
            this.cobSearch.SelectedIndexChanged += new System.EventHandler(this.cobSearch_SelectedIndexChanged);
            // 
            // listMovies
            // 
            this.listMovies.DisplayMember = "string";
            this.listMovies.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMovies.FormattingEnabled = true;
            this.listMovies.ItemHeight = 21;
            this.listMovies.Location = new System.Drawing.Point(17, 249);
            this.listMovies.Margin = new System.Windows.Forms.Padding(2);
            this.listMovies.Name = "listMovies";
            this.listMovies.Size = new System.Drawing.Size(315, 256);
            this.listMovies.TabIndex = 18;
            this.listMovies.SelectedIndexChanged += new System.EventHandler(this.listMovies_SelectedIndexChanged);
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.Location = new System.Drawing.Point(358, 466);
            this.lblShowName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(67, 13);
            this.lblShowName.TabIndex = 19;
            this.lblShowName.Text = "Movie Name";
            this.lblShowName.Visible = false;
            // 
            // lblShowGenre
            // 
            this.lblShowGenre.AutoSize = true;
            this.lblShowGenre.Location = new System.Drawing.Point(358, 513);
            this.lblShowGenre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowGenre.Name = "lblShowGenre";
            this.lblShowGenre.Size = new System.Drawing.Size(36, 13);
            this.lblShowGenre.TabIndex = 20;
            this.lblShowGenre.Text = "Genre";
            this.lblShowGenre.Visible = false;
            // 
            // lblShowDirector
            // 
            this.lblShowDirector.AutoSize = true;
            this.lblShowDirector.Location = new System.Drawing.Point(358, 559);
            this.lblShowDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowDirector.Name = "lblShowDirector";
            this.lblShowDirector.Size = new System.Drawing.Size(44, 13);
            this.lblShowDirector.TabIndex = 21;
            this.lblShowDirector.Text = "Director";
            this.lblShowDirector.Visible = false;
            // 
            // lblMvName
            // 
            this.lblMvName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMvName.Location = new System.Drawing.Point(358, 482);
            this.lblMvName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvName.Name = "lblMvName";
            this.lblMvName.Size = new System.Drawing.Size(200, 25);
            this.lblMvName.TabIndex = 22;
            this.lblMvName.Text = "mvname";
            this.lblMvName.Visible = false;
            // 
            // lblMvGenre
            // 
            this.lblMvGenre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMvGenre.Location = new System.Drawing.Point(358, 528);
            this.lblMvGenre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvGenre.Name = "lblMvGenre";
            this.lblMvGenre.Size = new System.Drawing.Size(200, 25);
            this.lblMvGenre.TabIndex = 23;
            this.lblMvGenre.Text = "mvgenre";
            this.lblMvGenre.Visible = false;
            // 
            // lblMvDirector
            // 
            this.lblMvDirector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMvDirector.Location = new System.Drawing.Point(358, 575);
            this.lblMvDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvDirector.Name = "lblMvDirector";
            this.lblMvDirector.Size = new System.Drawing.Size(200, 25);
            this.lblMvDirector.TabIndex = 24;
            this.lblMvDirector.Text = "mvdirector";
            this.lblMvDirector.Visible = false;
            // 
            // lblBookMessage
            // 
            this.lblBookMessage.Location = new System.Drawing.Point(580, 715);
            this.lblBookMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookMessage.Name = "lblBookMessage";
            this.lblBookMessage.Size = new System.Drawing.Size(169, 68);
            this.lblBookMessage.TabIndex = 25;
            this.lblBookMessage.Text = "lblBookMessage";
            this.lblBookMessage.Visible = false;
            // 
            // btnSaveBHistory
            // 
            this.btnSaveBHistory.Location = new System.Drawing.Point(357, 760);
            this.btnSaveBHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveBHistory.Name = "btnSaveBHistory";
            this.btnSaveBHistory.Size = new System.Drawing.Size(78, 21);
            this.btnSaveBHistory.TabIndex = 26;
            this.btnSaveBHistory.Text = "Save";
            this.btnSaveBHistory.UseVisualStyleBackColor = true;
            this.btnSaveBHistory.Click += new System.EventHandler(this.btnSaveBHistory_Click);
            // 
            // btnViewBHistory
            // 
            this.btnViewBHistory.Enabled = false;
            this.btnViewBHistory.Location = new System.Drawing.Point(357, 735);
            this.btnViewBHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewBHistory.Name = "btnViewBHistory";
            this.btnViewBHistory.Size = new System.Drawing.Size(78, 21);
            this.btnViewBHistory.TabIndex = 27;
            this.btnViewBHistory.Text = "View";
            this.btnViewBHistory.UseVisualStyleBackColor = true;
            this.btnViewBHistory.Click += new System.EventHandler(this.btnViewBHistory_Click);
            // 
            // cobSeat
            // 
            this.cobSeat.Enabled = false;
            this.cobSeat.FormattingEnabled = true;
            this.cobSeat.Location = new System.Drawing.Point(148, 6);
            this.cobSeat.Margin = new System.Windows.Forms.Padding(2);
            this.cobSeat.Name = "cobSeat";
            this.cobSeat.Size = new System.Drawing.Size(54, 21);
            this.cobSeat.TabIndex = 30;
            this.cobSeat.Visible = false;
            this.cobSeat.SelectedIndexChanged += new System.EventHandler(this.cobSeat_SelectedIndexChanged);
            // 
            // lblSeatNo
            // 
            this.lblSeatNo.AutoSize = true;
            this.lblSeatNo.Location = new System.Drawing.Point(14, 9);
            this.lblSeatNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeatNo.Name = "lblSeatNo";
            this.lblSeatNo.Size = new System.Drawing.Size(69, 13);
            this.lblSeatNo.TabIndex = 31;
            this.lblSeatNo.Text = "Seat Number";
            this.lblSeatNo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "User ID";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(320, 37);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(94, 26);
            this.txtUser.TabIndex = 1;
            // 
            // lblMvDescription
            // 
            this.lblMvDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMvDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMvDescription.Location = new System.Drawing.Point(581, 249);
            this.lblMvDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvDescription.Name = "lblMvDescription";
            this.lblMvDescription.Size = new System.Drawing.Size(239, 200);
            this.lblMvDescription.TabIndex = 39;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(432, 37);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(66, 29);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(502, 37);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(66, 29);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(161, 676);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 26);
            this.lblPrice.TabIndex = 45;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(354, 657);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 46;
            this.lblDate.Text = "Date";
            // 
            // cobDate
            // 
            this.cobDate.Enabled = false;
            this.cobDate.FormattingEnabled = true;
            this.cobDate.Location = new System.Drawing.Point(454, 654);
            this.cobDate.Margin = new System.Windows.Forms.Padding(2);
            this.cobDate.Name = "cobDate";
            this.cobDate.Size = new System.Drawing.Size(104, 21);
            this.cobDate.TabIndex = 47;
            this.cobDate.SelectedIndexChanged += new System.EventHandler(this.cobDate_SelectedIndexChanged);
            // 
            // lblBookingHistory
            // 
            this.lblBookingHistory.AutoSize = true;
            this.lblBookingHistory.Location = new System.Drawing.Point(354, 717);
            this.lblBookingHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookingHistory.Name = "lblBookingHistory";
            this.lblBookingHistory.Size = new System.Drawing.Size(81, 13);
            this.lblBookingHistory.TabIndex = 51;
            this.lblBookingHistory.Text = "Booking History";
            // 
            // chkA1
            // 
            this.chkA1.AutoSize = true;
            this.chkA1.Checked = true;
            this.chkA1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkA1.Location = new System.Drawing.Point(627, 551);
            this.chkA1.Name = "chkA1";
            this.chkA1.Size = new System.Drawing.Size(15, 14);
            this.chkA1.TabIndex = 52;
            this.chkA1.TabStop = false;
            this.chkA1.UseVisualStyleBackColor = true;
            // 
            // chkA2
            // 
            this.chkA2.AutoSize = true;
            this.chkA2.Checked = true;
            this.chkA2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkA2.Location = new System.Drawing.Point(670, 551);
            this.chkA2.Name = "chkA2";
            this.chkA2.Size = new System.Drawing.Size(15, 14);
            this.chkA2.TabIndex = 53;
            this.chkA2.TabStop = false;
            this.chkA2.UseVisualStyleBackColor = true;
            // 
            // chkA3
            // 
            this.chkA3.AutoSize = true;
            this.chkA3.Checked = true;
            this.chkA3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkA3.Location = new System.Drawing.Point(692, 551);
            this.chkA3.Name = "chkA3";
            this.chkA3.Size = new System.Drawing.Size(15, 14);
            this.chkA3.TabIndex = 54;
            this.chkA3.TabStop = false;
            this.chkA3.UseVisualStyleBackColor = true;
            // 
            // chkA4
            // 
            this.chkA4.AutoSize = true;
            this.chkA4.Checked = true;
            this.chkA4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkA4.Location = new System.Drawing.Point(713, 551);
            this.chkA4.Name = "chkA4";
            this.chkA4.Size = new System.Drawing.Size(15, 14);
            this.chkA4.TabIndex = 55;
            this.chkA4.TabStop = false;
            this.chkA4.UseVisualStyleBackColor = true;
            // 
            // chkA5
            // 
            this.chkA5.AutoSize = true;
            this.chkA5.Checked = true;
            this.chkA5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkA5.Location = new System.Drawing.Point(756, 551);
            this.chkA5.Name = "chkA5";
            this.chkA5.Size = new System.Drawing.Size(15, 14);
            this.chkA5.TabIndex = 56;
            this.chkA5.TabStop = false;
            this.chkA5.UseVisualStyleBackColor = true;
            // 
            // chkB5
            // 
            this.chkB5.AutoSize = true;
            this.chkB5.Checked = true;
            this.chkB5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkB5.Location = new System.Drawing.Point(756, 571);
            this.chkB5.Name = "chkB5";
            this.chkB5.Size = new System.Drawing.Size(15, 14);
            this.chkB5.TabIndex = 61;
            this.chkB5.TabStop = false;
            this.chkB5.UseVisualStyleBackColor = true;
            // 
            // chkB4
            // 
            this.chkB4.AutoSize = true;
            this.chkB4.Checked = true;
            this.chkB4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkB4.Location = new System.Drawing.Point(713, 571);
            this.chkB4.Name = "chkB4";
            this.chkB4.Size = new System.Drawing.Size(15, 14);
            this.chkB4.TabIndex = 60;
            this.chkB4.TabStop = false;
            this.chkB4.UseVisualStyleBackColor = true;
            // 
            // chkB3
            // 
            this.chkB3.AutoSize = true;
            this.chkB3.Checked = true;
            this.chkB3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkB3.Location = new System.Drawing.Point(692, 571);
            this.chkB3.Name = "chkB3";
            this.chkB3.Size = new System.Drawing.Size(15, 14);
            this.chkB3.TabIndex = 59;
            this.chkB3.TabStop = false;
            this.chkB3.UseVisualStyleBackColor = true;
            // 
            // chkB2
            // 
            this.chkB2.AutoSize = true;
            this.chkB2.Checked = true;
            this.chkB2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkB2.Location = new System.Drawing.Point(670, 571);
            this.chkB2.Name = "chkB2";
            this.chkB2.Size = new System.Drawing.Size(15, 14);
            this.chkB2.TabIndex = 58;
            this.chkB2.TabStop = false;
            this.chkB2.UseVisualStyleBackColor = true;
            // 
            // chkB1
            // 
            this.chkB1.AutoSize = true;
            this.chkB1.Checked = true;
            this.chkB1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkB1.Location = new System.Drawing.Point(627, 571);
            this.chkB1.Name = "chkB1";
            this.chkB1.Size = new System.Drawing.Size(15, 14);
            this.chkB1.TabIndex = 57;
            this.chkB1.TabStop = false;
            this.chkB1.UseVisualStyleBackColor = true;
            // 
            // chkC5
            // 
            this.chkC5.AutoSize = true;
            this.chkC5.Checked = true;
            this.chkC5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkC5.Location = new System.Drawing.Point(756, 591);
            this.chkC5.Name = "chkC5";
            this.chkC5.Size = new System.Drawing.Size(15, 14);
            this.chkC5.TabIndex = 66;
            this.chkC5.TabStop = false;
            this.chkC5.UseVisualStyleBackColor = true;
            // 
            // chkC4
            // 
            this.chkC4.AutoSize = true;
            this.chkC4.Checked = true;
            this.chkC4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkC4.Location = new System.Drawing.Point(713, 591);
            this.chkC4.Name = "chkC4";
            this.chkC4.Size = new System.Drawing.Size(15, 14);
            this.chkC4.TabIndex = 65;
            this.chkC4.TabStop = false;
            this.chkC4.UseVisualStyleBackColor = true;
            // 
            // chkC3
            // 
            this.chkC3.AutoSize = true;
            this.chkC3.Checked = true;
            this.chkC3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkC3.Location = new System.Drawing.Point(692, 591);
            this.chkC3.Name = "chkC3";
            this.chkC3.Size = new System.Drawing.Size(15, 14);
            this.chkC3.TabIndex = 64;
            this.chkC3.TabStop = false;
            this.chkC3.UseVisualStyleBackColor = true;
            // 
            // chkC2
            // 
            this.chkC2.AutoSize = true;
            this.chkC2.Checked = true;
            this.chkC2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkC2.Location = new System.Drawing.Point(670, 591);
            this.chkC2.Name = "chkC2";
            this.chkC2.Size = new System.Drawing.Size(15, 14);
            this.chkC2.TabIndex = 63;
            this.chkC2.TabStop = false;
            this.chkC2.UseVisualStyleBackColor = true;
            // 
            // chkC1
            // 
            this.chkC1.AutoSize = true;
            this.chkC1.Checked = true;
            this.chkC1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkC1.Location = new System.Drawing.Point(627, 591);
            this.chkC1.Name = "chkC1";
            this.chkC1.Size = new System.Drawing.Size(15, 14);
            this.chkC1.TabIndex = 62;
            this.chkC1.TabStop = false;
            this.chkC1.UseVisualStyleBackColor = true;
            // 
            // chkD5
            // 
            this.chkD5.AutoSize = true;
            this.chkD5.Checked = true;
            this.chkD5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkD5.Location = new System.Drawing.Point(756, 611);
            this.chkD5.Name = "chkD5";
            this.chkD5.Size = new System.Drawing.Size(15, 14);
            this.chkD5.TabIndex = 71;
            this.chkD5.TabStop = false;
            this.chkD5.UseVisualStyleBackColor = true;
            // 
            // chkD4
            // 
            this.chkD4.AutoSize = true;
            this.chkD4.Checked = true;
            this.chkD4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkD4.Location = new System.Drawing.Point(713, 611);
            this.chkD4.Name = "chkD4";
            this.chkD4.Size = new System.Drawing.Size(15, 14);
            this.chkD4.TabIndex = 70;
            this.chkD4.TabStop = false;
            this.chkD4.UseVisualStyleBackColor = true;
            // 
            // chkD3
            // 
            this.chkD3.AutoSize = true;
            this.chkD3.Checked = true;
            this.chkD3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkD3.Location = new System.Drawing.Point(692, 611);
            this.chkD3.Name = "chkD3";
            this.chkD3.Size = new System.Drawing.Size(15, 14);
            this.chkD3.TabIndex = 69;
            this.chkD3.TabStop = false;
            this.chkD3.UseVisualStyleBackColor = true;
            // 
            // chkD2
            // 
            this.chkD2.AutoSize = true;
            this.chkD2.Checked = true;
            this.chkD2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkD2.Location = new System.Drawing.Point(670, 611);
            this.chkD2.Name = "chkD2";
            this.chkD2.Size = new System.Drawing.Size(15, 14);
            this.chkD2.TabIndex = 68;
            this.chkD2.TabStop = false;
            this.chkD2.UseVisualStyleBackColor = true;
            // 
            // chkD1
            // 
            this.chkD1.AutoSize = true;
            this.chkD1.Checked = true;
            this.chkD1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkD1.Location = new System.Drawing.Point(627, 611);
            this.chkD1.Name = "chkD1";
            this.chkD1.Size = new System.Drawing.Size(15, 14);
            this.chkD1.TabIndex = 67;
            this.chkD1.TabStop = false;
            this.chkD1.UseVisualStyleBackColor = true;
            // 
            // chkE5
            // 
            this.chkE5.AutoSize = true;
            this.chkE5.Checked = true;
            this.chkE5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkE5.Location = new System.Drawing.Point(756, 631);
            this.chkE5.Name = "chkE5";
            this.chkE5.Size = new System.Drawing.Size(15, 14);
            this.chkE5.TabIndex = 76;
            this.chkE5.TabStop = false;
            this.chkE5.UseVisualStyleBackColor = true;
            // 
            // chkE4
            // 
            this.chkE4.AutoSize = true;
            this.chkE4.Checked = true;
            this.chkE4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkE4.Location = new System.Drawing.Point(713, 631);
            this.chkE4.Name = "chkE4";
            this.chkE4.Size = new System.Drawing.Size(15, 14);
            this.chkE4.TabIndex = 75;
            this.chkE4.TabStop = false;
            this.chkE4.UseVisualStyleBackColor = true;
            // 
            // chkE3
            // 
            this.chkE3.AutoSize = true;
            this.chkE3.Checked = true;
            this.chkE3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkE3.Location = new System.Drawing.Point(692, 631);
            this.chkE3.Name = "chkE3";
            this.chkE3.Size = new System.Drawing.Size(15, 14);
            this.chkE3.TabIndex = 74;
            this.chkE3.TabStop = false;
            this.chkE3.UseVisualStyleBackColor = true;
            // 
            // chkE2
            // 
            this.chkE2.AutoSize = true;
            this.chkE2.Checked = true;
            this.chkE2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkE2.Location = new System.Drawing.Point(670, 631);
            this.chkE2.Name = "chkE2";
            this.chkE2.Size = new System.Drawing.Size(15, 14);
            this.chkE2.TabIndex = 73;
            this.chkE2.TabStop = false;
            this.chkE2.UseVisualStyleBackColor = true;
            // 
            // chkE1
            // 
            this.chkE1.AutoSize = true;
            this.chkE1.Checked = true;
            this.chkE1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkE1.Location = new System.Drawing.Point(627, 631);
            this.chkE1.Name = "chkE1";
            this.chkE1.Size = new System.Drawing.Size(15, 14);
            this.chkE1.TabIndex = 72;
            this.chkE1.TabStop = false;
            this.chkE1.UseVisualStyleBackColor = true;
            // 
            // lblScreen
            // 
            this.lblScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScreen.Location = new System.Drawing.Point(649, 490);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(100, 38);
            this.lblScreen.TabIndex = 77;
            this.lblScreen.Text = "Screen";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBorder
            // 
            this.lblBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBorder.Location = new System.Drawing.Point(581, 480);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(239, 194);
            this.lblBorder.TabIndex = 78;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 792);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.chkE5);
            this.Controls.Add(this.chkE4);
            this.Controls.Add(this.chkE3);
            this.Controls.Add(this.chkE2);
            this.Controls.Add(this.chkE1);
            this.Controls.Add(this.chkD5);
            this.Controls.Add(this.chkD4);
            this.Controls.Add(this.chkD3);
            this.Controls.Add(this.chkD2);
            this.Controls.Add(this.chkD1);
            this.Controls.Add(this.chkC5);
            this.Controls.Add(this.chkC4);
            this.Controls.Add(this.chkC3);
            this.Controls.Add(this.chkC2);
            this.Controls.Add(this.chkC1);
            this.Controls.Add(this.chkB5);
            this.Controls.Add(this.chkB4);
            this.Controls.Add(this.chkB3);
            this.Controls.Add(this.chkB2);
            this.Controls.Add(this.chkB1);
            this.Controls.Add(this.chkA5);
            this.Controls.Add(this.chkA4);
            this.Controls.Add(this.chkA3);
            this.Controls.Add(this.chkA2);
            this.Controls.Add(this.chkA1);
            this.Controls.Add(this.lblBookingHistory);
            this.Controls.Add(this.cobDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblMvDescription);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSeatNo);
            this.Controls.Add(this.cobSeat);
            this.Controls.Add(this.btnViewBHistory);
            this.Controls.Add(this.btnSaveBHistory);
            this.Controls.Add(this.lblBookMessage);
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
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblBookMessage;
        private System.Windows.Forms.Button btnSaveBHistory;
        private System.Windows.Forms.Button btnViewBHistory;
        private System.Windows.Forms.ComboBox cobSeat;
        private System.Windows.Forms.Label lblSeatNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMvDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cobDate;
        private System.Windows.Forms.Label lblBookingHistory;
        private System.Windows.Forms.CheckBox chkA1;
        private System.Windows.Forms.CheckBox chkA2;
        private System.Windows.Forms.CheckBox chkA3;
        private System.Windows.Forms.CheckBox chkA4;
        private System.Windows.Forms.CheckBox chkA5;
        private System.Windows.Forms.CheckBox chkB5;
        private System.Windows.Forms.CheckBox chkB4;
        private System.Windows.Forms.CheckBox chkB3;
        private System.Windows.Forms.CheckBox chkB2;
        private System.Windows.Forms.CheckBox chkB1;
        private System.Windows.Forms.CheckBox chkC5;
        private System.Windows.Forms.CheckBox chkC4;
        private System.Windows.Forms.CheckBox chkC3;
        private System.Windows.Forms.CheckBox chkC2;
        private System.Windows.Forms.CheckBox chkC1;
        private System.Windows.Forms.CheckBox chkD5;
        private System.Windows.Forms.CheckBox chkD4;
        private System.Windows.Forms.CheckBox chkD3;
        private System.Windows.Forms.CheckBox chkD2;
        private System.Windows.Forms.CheckBox chkD1;
        private System.Windows.Forms.CheckBox chkE5;
        private System.Windows.Forms.CheckBox chkE4;
        private System.Windows.Forms.CheckBox chkE3;
        private System.Windows.Forms.CheckBox chkE2;
        private System.Windows.Forms.CheckBox chkE1;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Label lblBorder;
    }
}

