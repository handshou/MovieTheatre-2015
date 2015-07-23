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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("wdwdw");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("ffdwewdw");
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.listTime = new System.Windows.Forms.ListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cobTime = new System.Windows.Forms.Label();
            this.cobQty = new System.Windows.Forms.ComboBox();
            this.rTxtMessages = new System.Windows.Forms.RichTextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(64, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(123, 52);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse movies";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 96);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(208, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search movie:";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnBook
            // 
            this.btnBook.Enabled = false;
            this.btnBook.Location = new System.Drawing.Point(708, 415);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(94, 78);
            this.btnBook.TabIndex = 3;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            // 
            // picPoster
            // 
            this.picPoster.Image = ((System.Drawing.Image)(resources.GetObject("picPoster.Image")));
            this.picPoster.Location = new System.Drawing.Point(391, 212);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(271, 239);
            this.picPoster.TabIndex = 5;
            this.picPoster.TabStop = false;
            // 
            // listTime
            // 
            this.listTime.Enabled = false;
            this.listTime.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listTime.Location = new System.Drawing.Point(855, 212);
            this.listTime.Name = "listTime";
            this.listTime.Size = new System.Drawing.Size(100, 346);
            this.listTime.TabIndex = 7;
            this.listTime.UseCompatibleStateImageBehavior = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(686, 259);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 24);
            this.comboBox1.TabIndex = 8;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(712, 325);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(90, 17);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "No. of tickets";
            // 
            // cobTime
            // 
            this.cobTime.AutoSize = true;
            this.cobTime.Location = new System.Drawing.Point(712, 229);
            this.cobTime.Name = "cobTime";
            this.cobTime.Size = new System.Drawing.Size(91, 17);
            this.cobTime.TabIndex = 10;
            this.cobTime.Text = "Time Chosen";
            // 
            // cobQty
            // 
            this.cobQty.Enabled = false;
            this.cobQty.FormattingEnabled = true;
            this.cobQty.Location = new System.Drawing.Point(724, 345);
            this.cobQty.Name = "cobQty";
            this.cobQty.Size = new System.Drawing.Size(68, 24);
            this.cobQty.TabIndex = 11;
            // 
            // rTxtMessages
            // 
            this.rTxtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtMessages.Location = new System.Drawing.Point(246, 12);
            this.rTxtMessages.Name = "rTxtMessages";
            this.rTxtMessages.Size = new System.Drawing.Size(577, 143);
            this.rTxtMessages.TabIndex = 13;
            this.rTxtMessages.Text = "i am text box";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 167);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 22);
            this.txtSearch.TabIndex = 14;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Name",
            "Genre",
            "Director"});
            this.comboBox2.Location = new System.Drawing.Point(12, 137);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(106, 24);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.Text = "--Search By--";
            // 
            // listMovies
            // 
            this.listMovies.FormattingEnabled = true;
            this.listMovies.ItemHeight = 16;
            this.listMovies.Items.AddRange(new object[] {
            "--click me--",
            "(this list should be empty",
            "and then populated by values after ",
            "clicking Search/Browse)"});
            this.listMovies.Location = new System.Drawing.Point(12, 212);
            this.listMovies.Name = "listMovies";
            this.listMovies.Size = new System.Drawing.Size(357, 340);
            this.listMovies.TabIndex = 18;
            // 
            // lblShowName
            // 
            this.lblShowName.AutoSize = true;
            this.lblShowName.Location = new System.Drawing.Point(429, 464);
            this.lblShowName.Name = "lblShowName";
            this.lblShowName.Size = new System.Drawing.Size(90, 17);
            this.lblShowName.TabIndex = 19;
            this.lblShowName.Text = "Movie Name:";
            this.lblShowName.Visible = false;
            // 
            // lblShowGenre
            // 
            this.lblShowGenre.AutoSize = true;
            this.lblShowGenre.Location = new System.Drawing.Point(429, 495);
            this.lblShowGenre.Name = "lblShowGenre";
            this.lblShowGenre.Size = new System.Drawing.Size(52, 17);
            this.lblShowGenre.TabIndex = 20;
            this.lblShowGenre.Text = "Genre:";
            this.lblShowGenre.Visible = false;
            // 
            // lblShowDirector
            // 
            this.lblShowDirector.AutoSize = true;
            this.lblShowDirector.Location = new System.Drawing.Point(429, 526);
            this.lblShowDirector.Name = "lblShowDirector";
            this.lblShowDirector.Size = new System.Drawing.Size(62, 17);
            this.lblShowDirector.TabIndex = 21;
            this.lblShowDirector.Text = "Director:";
            this.lblShowDirector.Visible = false;
            // 
            // lblMvName
            // 
            this.lblMvName.AutoSize = true;
            this.lblMvName.Location = new System.Drawing.Point(543, 464);
            this.lblMvName.Name = "lblMvName";
            this.lblMvName.Size = new System.Drawing.Size(61, 17);
            this.lblMvName.TabIndex = 22;
            this.lblMvName.Text = "mvname";
            this.lblMvName.Visible = false;
            // 
            // lblMvGenre
            // 
            this.lblMvGenre.AutoSize = true;
            this.lblMvGenre.Location = new System.Drawing.Point(543, 495);
            this.lblMvGenre.Name = "lblMvGenre";
            this.lblMvGenre.Size = new System.Drawing.Size(63, 17);
            this.lblMvGenre.TabIndex = 23;
            this.lblMvGenre.Text = "mvgenre";
            this.lblMvGenre.Visible = false;
            // 
            // lblMvDirector
            // 
            this.lblMvDirector.AutoSize = true;
            this.lblMvDirector.Location = new System.Drawing.Point(543, 526);
            this.lblMvDirector.Name = "lblMvDirector";
            this.lblMvDirector.Size = new System.Drawing.Size(74, 17);
            this.lblMvDirector.TabIndex = 24;
            this.lblMvDirector.Text = "mvdirector";
            this.lblMvDirector.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(698, 517);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "lblBookMessage";
            this.label1.Visible = false;
            // 
            // btnSaveBH
            // 
            this.btnSaveBH.Enabled = false;
            this.btnSaveBH.Location = new System.Drawing.Point(845, 91);
            this.btnSaveBH.Name = "btnSaveBH";
            this.btnSaveBH.Size = new System.Drawing.Size(123, 52);
            this.btnSaveBH.TabIndex = 26;
            this.btnSaveBH.Text = "Save booking history";
            this.btnSaveBH.UseVisualStyleBackColor = true;
            // 
            // btnViewBH
            // 
            this.btnViewBH.Location = new System.Drawing.Point(845, 23);
            this.btnViewBH.Name = "btnViewBH";
            this.btnViewBH.Size = new System.Drawing.Size(123, 52);
            this.btnViewBH.TabIndex = 27;
            this.btnViewBH.Text = "View booking history";
            this.btnViewBH.UseVisualStyleBackColor = true;
            // 
            // lblBoardMessage
            // 
            this.lblBoardMessage.AutoSize = true;
            this.lblBoardMessage.Location = new System.Drawing.Point(252, 167);
            this.lblBoardMessage.Name = "lblBoardMessage";
            this.lblBoardMessage.Size = new System.Drawing.Size(117, 17);
            this.lblBoardMessage.TabIndex = 28;
            this.lblBoardMessage.Text = "lblBoardMessage";
            this.lblBoardMessage.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 567);
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
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.rTxtMessages);
            this.Controls.Add(this.cobQty);
            this.Controls.Add(this.cobTime);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listTime);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.picPoster);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowse);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label cobTime;
        private System.Windows.Forms.ComboBox cobQty;
        private System.Windows.Forms.RichTextBox rTxtMessages;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox comboBox2;
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
    }
}

