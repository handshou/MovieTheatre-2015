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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveBHistory = new System.Windows.Forms.Button();
            this.btnViewBHistory = new System.Windows.Forms.Button();
            this.lblBoardMessage = new System.Windows.Forms.Label();
            this.cobSeat = new System.Windows.Forms.ComboBox();
            this.lblSeatNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblMvDescription = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cobDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(10, 98);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(92, 64);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse movies";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(112, 142);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search movie:";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBook
            // 
            this.btnBook.Enabled = false;
            this.btnBook.Location = new System.Drawing.Point(534, 287);
            this.btnBook.Margin = new System.Windows.Forms.Padding(2);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(70, 63);
            this.btnBook.TabIndex = 3;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // picPoster
            // 
            this.picPoster.Image = ((System.Drawing.Image)(resources.GetObject("picPoster.Image")));
            this.picPoster.Location = new System.Drawing.Point(293, 172);
            this.picPoster.Margin = new System.Windows.Forms.Padding(2);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(203, 194);
            this.picPoster.TabIndex = 5;
            this.picPoster.TabStop = false;
            // 
            // listTime
            // 
            this.listTime.Enabled = false;
            this.listTime.Location = new System.Drawing.Point(650, 163);
            this.listTime.Margin = new System.Windows.Forms.Padding(2);
            this.listTime.Name = "listTime";
            this.listTime.Size = new System.Drawing.Size(76, 282);
            this.listTime.TabIndex = 7;
            this.listTime.UseCompatibleStateImageBehavior = false;
            // 
            // cobTime
            // 
            this.cobTime.Enabled = false;
            this.cobTime.FormattingEnabled = true;
            this.cobTime.Location = new System.Drawing.Point(518, 207);
            this.cobTime.Margin = new System.Windows.Forms.Padding(2);
            this.cobTime.Name = "cobTime";
            this.cobTime.Size = new System.Drawing.Size(104, 21);
            this.cobTime.TabIndex = 8;
            this.cobTime.SelectedIndexChanged += new System.EventHandler(this.cobTime_SelectedIndexChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(532, 187);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(69, 13);
            this.labelTime.TabIndex = 10;
            this.labelTime.Text = "Time Chosen";
            // 
            // rTxtMessages
            // 
            this.rTxtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtMessages.Location = new System.Drawing.Point(230, 10);
            this.rTxtMessages.Margin = new System.Windows.Forms.Padding(2);
            this.rTxtMessages.Name = "rTxtMessages";
            this.rTxtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTxtMessages.Size = new System.Drawing.Size(626, 117);
            this.rTxtMessages.TabIndex = 13;
            this.rTxtMessages.Text = "I am text box";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(112, 121);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(111, 20);
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
            this.cobSearch.Location = new System.Drawing.Point(112, 97);
            this.cobSearch.Margin = new System.Windows.Forms.Padding(2);
            this.cobSearch.Name = "cobSearch";
            this.cobSearch.Size = new System.Drawing.Size(80, 21);
            this.cobSearch.TabIndex = 15;
            this.cobSearch.Text = "--Search By--";
            this.cobSearch.SelectedIndexChanged += new System.EventHandler(this.cobSearch_SelectedIndexChanged);
            // 
            // listMovies
            // 
            this.listMovies.DisplayMember = "string";
            this.listMovies.FormattingEnabled = true;
            this.listMovies.Location = new System.Drawing.Point(9, 198);
            this.listMovies.Margin = new System.Windows.Forms.Padding(2);
            this.listMovies.Name = "listMovies";
            this.listMovies.Size = new System.Drawing.Size(269, 251);
            this.listMovies.TabIndex = 18;
            this.listMovies.SelectedIndexChanged += new System.EventHandler(this.listMovies_SelectedIndexChanged);
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowName.Location = new System.Drawing.Point(293, 379);
            this.lblShowName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(72, 15);
            this.lblShowName.TabIndex = 19;
            this.lblShowName.Text = "Movie Name:";
            this.lblShowName.Visible = false;
            // 
            // lblShowGenre
            // 
            this.lblShowGenre.AutoSize = true;
            this.lblShowGenre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowGenre.Location = new System.Drawing.Point(293, 404);
            this.lblShowGenre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowGenre.Name = "lblShowGenre";
            this.lblShowGenre.Size = new System.Drawing.Size(41, 15);
            this.lblShowGenre.TabIndex = 20;
            this.lblShowGenre.Text = "Genre:";
            this.lblShowGenre.Visible = false;
            // 
            // lblShowDirector
            // 
            this.lblShowDirector.AutoSize = true;
            this.lblShowDirector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShowDirector.Location = new System.Drawing.Point(293, 429);
            this.lblShowDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowDirector.Name = "lblShowDirector";
            this.lblShowDirector.Size = new System.Drawing.Size(49, 15);
            this.lblShowDirector.TabIndex = 21;
            this.lblShowDirector.Text = "Director:";
            this.lblShowDirector.Visible = false;
            // 
            // lblMvName
            // 
            this.lblMvName.AutoSize = true;
            this.lblMvName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvName.Location = new System.Drawing.Point(367, 379);
            this.lblMvName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvName.Name = "lblMvName";
            this.lblMvName.Size = new System.Drawing.Size(49, 15);
            this.lblMvName.TabIndex = 22;
            this.lblMvName.Text = "mvname";
            this.lblMvName.Visible = false;
            // 
            // lblMvGenre
            // 
            this.lblMvGenre.AutoSize = true;
            this.lblMvGenre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvGenre.Location = new System.Drawing.Point(367, 404);
            this.lblMvGenre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvGenre.Name = "lblMvGenre";
            this.lblMvGenre.Size = new System.Drawing.Size(50, 15);
            this.lblMvGenre.TabIndex = 23;
            this.lblMvGenre.Text = "mvgenre";
            this.lblMvGenre.Visible = false;
            // 
            // lblMvDirector
            // 
            this.lblMvDirector.AutoSize = true;
            this.lblMvDirector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMvDirector.Location = new System.Drawing.Point(367, 429);
            this.lblMvDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvDirector.Name = "lblMvDirector";
            this.lblMvDirector.Size = new System.Drawing.Size(58, 15);
            this.lblMvDirector.TabIndex = 24;
            this.lblMvDirector.Text = "mvdirector";
            this.lblMvDirector.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 360);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "lblBookMessage";
            this.label1.Visible = false;
            // 
            // btnSaveBHistory
            // 
            this.btnSaveBHistory.Location = new System.Drawing.Point(871, 42);
            this.btnSaveBHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveBHistory.Name = "btnSaveBHistory";
            this.btnSaveBHistory.Size = new System.Drawing.Size(104, 40);
            this.btnSaveBHistory.TabIndex = 26;
            this.btnSaveBHistory.Text = "Save booking history";
            this.btnSaveBHistory.UseVisualStyleBackColor = true;
            this.btnSaveBHistory.Click += new System.EventHandler(this.btnSaveBHistory_Click);
            // 
            // btnViewBHistory
            // 
            this.btnViewBHistory.Enabled = false;
            this.btnViewBHistory.Location = new System.Drawing.Point(871, 2);
            this.btnViewBHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewBHistory.Name = "btnViewBHistory";
            this.btnViewBHistory.Size = new System.Drawing.Size(104, 35);
            this.btnViewBHistory.TabIndex = 27;
            this.btnViewBHistory.Text = "View booking history";
            this.btnViewBHistory.UseVisualStyleBackColor = true;
            this.btnViewBHistory.Click += new System.EventHandler(this.btnViewBHistory_Click);
            // 
            // lblBoardMessage
            // 
            this.lblBoardMessage.AutoSize = true;
            this.lblBoardMessage.Location = new System.Drawing.Point(228, 142);
            this.lblBoardMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoardMessage.Name = "lblBoardMessage";
            this.lblBoardMessage.Size = new System.Drawing.Size(88, 13);
            this.lblBoardMessage.TabIndex = 28;
            this.lblBoardMessage.Text = "lblBoardMessage";
            this.lblBoardMessage.Visible = false;
            // 
            // cobSeat
            // 
            this.cobSeat.Enabled = false;
            this.cobSeat.FormattingEnabled = true;
            this.cobSeat.Location = new System.Drawing.Point(540, 256);
            this.cobSeat.Margin = new System.Windows.Forms.Padding(2);
            this.cobSeat.Name = "cobSeat";
            this.cobSeat.Size = new System.Drawing.Size(54, 21);
            this.cobSeat.TabIndex = 30;
            this.cobSeat.SelectedIndexChanged += new System.EventHandler(this.cobSeat_SelectedIndexChanged);
            // 
            // lblSeatNo
            // 
            this.lblSeatNo.AutoSize = true;
            this.lblSeatNo.Location = new System.Drawing.Point(532, 238);
            this.lblSeatNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeatNo.Name = "lblSeatNo";
            this.lblSeatNo.Size = new System.Drawing.Size(69, 13);
            this.lblSeatNo.TabIndex = 31;
            this.lblSeatNo.Text = "Seat Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "User:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(60, 19);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(132, 20);
            this.txtUser.TabIndex = 38;
            // 
            // lblMvDescription
            // 
            this.lblMvDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMvDescription.Location = new System.Drawing.Point(488, 380);
            this.lblMvDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMvDescription.Name = "lblMvDescription";
            this.lblMvDescription.Size = new System.Drawing.Size(149, 65);
            this.lblMvDescription.TabIndex = 39;
            this.lblMvDescription.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(26, 50);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(76, 32);
            this.btnLogin.TabIndex = 40;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(123, 50);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(76, 32);
            this.btnLogout.TabIndex = 43;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(733, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 44;
            this.label3.Text = "Price: $";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(814, 155);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 26);
            this.lblPrice.TabIndex = 45;
            this.lblPrice.Text = "----";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(550, 139);
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
            this.cobDate.Location = new System.Drawing.Point(518, 157);
            this.cobDate.Margin = new System.Windows.Forms.Padding(2);
            this.cobDate.Name = "cobDate";
            this.cobDate.Size = new System.Drawing.Size(104, 21);
            this.cobDate.TabIndex = 47;
            this.cobDate.SelectedIndexChanged += new System.EventHandler(this.cobDate_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 461);
            this.Controls.Add(this.cobDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblMvDescription);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSeatNo);
            this.Controls.Add(this.cobSeat);
            this.Controls.Add(this.lblBoardMessage);
            this.Controls.Add(this.btnViewBHistory);
            this.Controls.Add(this.btnSaveBHistory);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveBHistory;
        private System.Windows.Forms.Button btnViewBHistory;
        private System.Windows.Forms.Label lblBoardMessage;
        private System.Windows.Forms.ComboBox cobSeat;
        private System.Windows.Forms.Label lblSeatNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMvDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cobDate;
    }
}

