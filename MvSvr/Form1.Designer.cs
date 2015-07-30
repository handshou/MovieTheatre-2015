namespace MvSvr {
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageServer = new System.Windows.Forms.TabPage();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbClients = new System.Windows.Forms.ListBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDebugClear = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDirector = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblTimeFrom = new System.Windows.Forms.Label();
            this.tbTimeFrom = new System.Windows.Forms.TextBox();
            this.tbTimeTo = new System.Windows.Forms.TextBox();
            this.lblTimeTo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbClientsPg2 = new System.Windows.Forms.ListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageServer.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageServer);
            this.tabControl.Controls.Add(this.tabPageDebug);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(452, 512);
            this.tabControl.TabIndex = 15;
            // 
            // tabPageServer
            // 
            this.tabPageServer.Controls.Add(this.btnConfirm);
            this.tabPageServer.Controls.Add(this.label2);
            this.tabPageServer.Controls.Add(this.lblPrice);
            this.tabPageServer.Controls.Add(this.tbPrice);
            this.tabPageServer.Controls.Add(this.label1);
            this.tabPageServer.Controls.Add(this.textBox1);
            this.tabPageServer.Controls.Add(this.lblTimeTo);
            this.tabPageServer.Controls.Add(this.tbTimeTo);
            this.tabPageServer.Controls.Add(this.tbTimeFrom);
            this.tabPageServer.Controls.Add(this.lblTimeFrom);
            this.tabPageServer.Controls.Add(this.lblImage);
            this.tabPageServer.Controls.Add(this.tbImage);
            this.tabPageServer.Controls.Add(this.tbGenre);
            this.tabPageServer.Controls.Add(this.lblGenre);
            this.tabPageServer.Controls.Add(this.lblDirector);
            this.tabPageServer.Controls.Add(this.tbDirector);
            this.tabPageServer.Controls.Add(this.lblDescription);
            this.tabPageServer.Controls.Add(this.tbDescription);
            this.tabPageServer.Controls.Add(this.tbServer);
            this.tabPageServer.Controls.Add(this.lbClients);
            this.tabPageServer.Controls.Add(this.tbTitle);
            this.tabPageServer.Controls.Add(this.btnClear);
            this.tabPageServer.Controls.Add(this.btnAdd);
            this.tabPageServer.Controls.Add(this.btnList);
            this.tabPageServer.Controls.Add(this.btnSave);
            this.tabPageServer.Controls.Add(this.btnBroadcast);
            this.tabPageServer.Controls.Add(this.lblTitle);
            this.tabPageServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageServer.Name = "tabPageServer";
            this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServer.Size = new System.Drawing.Size(444, 486);
            this.tabPageServer.TabIndex = 0;
            this.tabPageServer.Text = "Server";
            this.tabPageServer.UseVisualStyleBackColor = true;
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.Controls.Add(this.lbClientsPg2);
            this.tabPageDebug.Controls.Add(this.btnDebugClear);
            this.tabPageDebug.Controls.Add(this.tbDisplay);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebug.Size = new System.Drawing.Size(444, 486);
            this.tabPageDebug.TabIndex = 1;
            this.tabPageDebug.Text = "Debug";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(17, 21);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDisplay.Size = new System.Drawing.Size(318, 199);
            this.tbDisplay.TabIndex = 16;
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(17, 21);
            this.tbServer.Multiline = true;
            this.tbServer.Name = "tbServer";
            this.tbServer.ReadOnly = true;
            this.tbServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbServer.Size = new System.Drawing.Size(318, 199);
            this.tbServer.TabIndex = 23;
            // 
            // lbClients
            // 
            this.lbClients.FormattingEnabled = true;
            this.lbClients.Location = new System.Drawing.Point(353, 21);
            this.lbClients.Name = "lbClients";
            this.lbClients.Size = new System.Drawing.Size(75, 199);
            this.lbClients.TabIndex = 24;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(104, 241);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(209, 20);
            this.tbTitle.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(353, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(353, 388);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(353, 241);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(353, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Location = new System.Drawing.Point(353, 446);
            this.btnBroadcast.Name = "btnBroadcast";
            this.btnBroadcast.Size = new System.Drawing.Size(75, 23);
            this.btnBroadcast.TabIndex = 15;
            this.btnBroadcast.Text = "Broadcast";
            this.btnBroadcast.UseVisualStyleBackColor = true;
            this.btnBroadcast.Click += new System.EventHandler(this.btnBroadcast_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(26, 246);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Title";
            // 
            // btnDebugClear
            // 
            this.btnDebugClear.Location = new System.Drawing.Point(353, 241);
            this.btnDebugClear.Name = "btnDebugClear";
            this.btnDebugClear.Size = new System.Drawing.Size(75, 23);
            this.btnDebugClear.TabIndex = 18;
            this.btnDebugClear.Text = "Clear";
            this.btnDebugClear.UseVisualStyleBackColor = true;
            this.btnDebugClear.Click += new System.EventHandler(this.btnDebugClear_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(104, 267);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(209, 46);
            this.tbDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(26, 270);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "Description";
            // 
            // tbDirector
            // 
            this.tbDirector.Location = new System.Drawing.Point(104, 319);
            this.tbDirector.Name = "tbDirector";
            this.tbDirector.Size = new System.Drawing.Size(209, 20);
            this.tbDirector.TabIndex = 3;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(26, 322);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(44, 13);
            this.lblDirector.TabIndex = 27;
            this.lblDirector.Text = "Director";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(26, 348);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 28;
            this.lblGenre.Text = "Genre";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(104, 345);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(209, 20);
            this.tbGenre.TabIndex = 4;
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(104, 371);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(209, 20);
            this.tbImage.TabIndex = 5;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(26, 374);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(36, 13);
            this.lblImage.TabIndex = 31;
            this.lblImage.Text = "Image";
            // 
            // lblTimeFrom
            // 
            this.lblTimeFrom.AutoSize = true;
            this.lblTimeFrom.Location = new System.Drawing.Point(26, 426);
            this.lblTimeFrom.Name = "lblTimeFrom";
            this.lblTimeFrom.Size = new System.Drawing.Size(30, 13);
            this.lblTimeFrom.TabIndex = 32;
            this.lblTimeFrom.Text = "Time";
            // 
            // tbTimeFrom
            // 
            this.tbTimeFrom.Location = new System.Drawing.Point(104, 423);
            this.tbTimeFrom.Name = "tbTimeFrom";
            this.tbTimeFrom.Size = new System.Drawing.Size(58, 20);
            this.tbTimeFrom.TabIndex = 7;
            // 
            // tbTimeTo
            // 
            this.tbTimeTo.Location = new System.Drawing.Point(255, 423);
            this.tbTimeTo.Name = "tbTimeTo";
            this.tbTimeTo.Size = new System.Drawing.Size(58, 20);
            this.tbTimeTo.TabIndex = 8;
            // 
            // lblTimeTo
            // 
            this.lblTimeTo.AutoSize = true;
            this.lblTimeTo.Location = new System.Drawing.Point(195, 426);
            this.lblTimeTo.Name = "lblTimeTo";
            this.lblTimeTo.Size = new System.Drawing.Size(20, 13);
            this.lblTimeTo.TabIndex = 35;
            this.lblTimeTo.Text = "To";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 397);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Date";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(104, 449);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(209, 20);
            this.tbPrice.TabIndex = 9;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(26, 452);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 39;
            this.lblPrice.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "$";
            // 
            // lbClientsPg2
            // 
            this.lbClientsPg2.FormattingEnabled = true;
            this.lbClientsPg2.Location = new System.Drawing.Point(353, 21);
            this.lbClientsPg2.Name = "lbClientsPg2";
            this.lbClientsPg2.Size = new System.Drawing.Size(75, 199);
            this.lbClientsPg2.TabIndex = 17;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(353, 417);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 536);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageServer.ResumeLayout(false);
            this.tabPageServer.PerformLayout();
            this.tabPageDebug.ResumeLayout(false);
            this.tabPageDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageServer;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.ListBox lbClients;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBroadcast;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDebugClear;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox tbDirector;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox tbTimeFrom;
        private System.Windows.Forms.Label lblTimeFrom;
        private System.Windows.Forms.Label lblTimeTo;
        private System.Windows.Forms.TextBox tbTimeTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbClientsPg2;
        private System.Windows.Forms.Button btnConfirm;
    }
}

