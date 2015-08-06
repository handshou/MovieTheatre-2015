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
            this.tabPageMovies = new System.Windows.Forms.TabPage();
            this.lblImage = new System.Windows.Forms.Label();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.tbDirector = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbMovies = new System.Windows.Forms.TextBox();
            this.libClientsMovies = new System.Windows.Forms.ListBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabPageShows = new System.Windows.Forms.TabPage();
            this.lbShowDays = new System.Windows.Forms.ListBox();
            this.lbShows = new System.Windows.Forms.ListBox();
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.btnAddShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.lblTimeTo = new System.Windows.Forms.Label();
            this.tbTimeTo = new System.Windows.Forms.TextBox();
            this.tbTimeFrom = new System.Windows.Forms.TextBox();
            this.lblTimeFrom = new System.Windows.Forms.Label();
            this.tbShows = new System.Windows.Forms.TextBox();
            this.libClientsShows = new System.Windows.Forms.ListBox();
            this.tabPageBooking = new System.Windows.Forms.TabPage();
            this.lbBookings = new System.Windows.Forms.ListBox();
            this.tbBookings = new System.Windows.Forms.TextBox();
            this.tabPageShowBookings = new System.Windows.Forms.TabPage();
            this.tbShowBookings = new System.Windows.Forms.TextBox();
            this.lbShowBkShowDays = new System.Windows.Forms.ListBox();
            this.lbShowBkShows = new System.Windows.Forms.ListBox();
            this.lbShowBkMovies = new System.Windows.Forms.ListBox();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.btnWipe = new System.Windows.Forms.Button();
            this.libClientsDebug = new System.Windows.Forms.ListBox();
            this.btnDebugClear = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageMovies.SuspendLayout();
            this.tabPageShows.SuspendLayout();
            this.tabPageBooking.SuspendLayout();
            this.tabPageShowBookings.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMovies);
            this.tabControl.Controls.Add(this.tabPageShows);
            this.tabControl.Controls.Add(this.tabPageBooking);
            this.tabControl.Controls.Add(this.tabPageShowBookings);
            this.tabControl.Controls.Add(this.tabPageDebug);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(452, 473);
            this.tabControl.TabIndex = 15;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageMovies
            // 
            this.tabPageMovies.Controls.Add(this.lblImage);
            this.tabPageMovies.Controls.Add(this.tbImage);
            this.tabPageMovies.Controls.Add(this.tbGenre);
            this.tabPageMovies.Controls.Add(this.lblGenre);
            this.tabPageMovies.Controls.Add(this.lblDirector);
            this.tabPageMovies.Controls.Add(this.tbDirector);
            this.tabPageMovies.Controls.Add(this.lblDescription);
            this.tabPageMovies.Controls.Add(this.tbDescription);
            this.tabPageMovies.Controls.Add(this.tbMovies);
            this.tabPageMovies.Controls.Add(this.libClientsMovies);
            this.tabPageMovies.Controls.Add(this.tbTitle);
            this.tabPageMovies.Controls.Add(this.btnClear);
            this.tabPageMovies.Controls.Add(this.btnAdd);
            this.tabPageMovies.Controls.Add(this.btnList);
            this.tabPageMovies.Controls.Add(this.btnSave);
            this.tabPageMovies.Controls.Add(this.btnBroadcast);
            this.tabPageMovies.Controls.Add(this.lblTitle);
            this.tabPageMovies.Location = new System.Drawing.Point(4, 22);
            this.tabPageMovies.Name = "tabPageMovies";
            this.tabPageMovies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMovies.Size = new System.Drawing.Size(444, 447);
            this.tabPageMovies.TabIndex = 0;
            this.tabPageMovies.Text = "Add Movies";
            this.tabPageMovies.UseVisualStyleBackColor = true;
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
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(104, 371);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(209, 20);
            this.tbImage.TabIndex = 5;
            this.tbImage.Text = "optional";
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(104, 345);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(209, 20);
            this.tbGenre.TabIndex = 4;
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
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(26, 322);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(44, 13);
            this.lblDirector.TabIndex = 27;
            this.lblDirector.Text = "Director";
            // 
            // tbDirector
            // 
            this.tbDirector.Location = new System.Drawing.Point(104, 319);
            this.tbDirector.Name = "tbDirector";
            this.tbDirector.Size = new System.Drawing.Size(209, 20);
            this.tbDirector.TabIndex = 3;
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
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(104, 267);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(209, 46);
            this.tbDescription.TabIndex = 2;
            // 
            // tbMovies
            // 
            this.tbMovies.Location = new System.Drawing.Point(17, 21);
            this.tbMovies.Multiline = true;
            this.tbMovies.Name = "tbMovies";
            this.tbMovies.ReadOnly = true;
            this.tbMovies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMovies.Size = new System.Drawing.Size(318, 199);
            this.tbMovies.TabIndex = 23;
            this.tbMovies.TabStop = false;
            // 
            // libClientsMovies
            // 
            this.libClientsMovies.FormattingEnabled = true;
            this.libClientsMovies.Location = new System.Drawing.Point(353, 21);
            this.libClientsMovies.Name = "libClientsMovies";
            this.libClientsMovies.Size = new System.Drawing.Size(75, 199);
            this.libClientsMovies.TabIndex = 24;
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
            this.btnAdd.Location = new System.Drawing.Point(353, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add Movie";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(353, 241);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(353, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Location = new System.Drawing.Point(353, 405);
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
            // tabPageShows
            // 
            this.tabPageShows.Controls.Add(this.lbShowDays);
            this.tabPageShows.Controls.Add(this.lbShows);
            this.tabPageShows.Controls.Add(this.lbMovies);
            this.tabPageShows.Controls.Add(this.btnAddShow);
            this.tabPageShows.Controls.Add(this.label2);
            this.tabPageShows.Controls.Add(this.lblPrice);
            this.tabPageShows.Controls.Add(this.tbPrice);
            this.tabPageShows.Controls.Add(this.label1);
            this.tabPageShows.Controls.Add(this.tbDate);
            this.tabPageShows.Controls.Add(this.lblTimeTo);
            this.tabPageShows.Controls.Add(this.tbTimeTo);
            this.tabPageShows.Controls.Add(this.tbTimeFrom);
            this.tabPageShows.Controls.Add(this.lblTimeFrom);
            this.tabPageShows.Controls.Add(this.tbShows);
            this.tabPageShows.Controls.Add(this.libClientsShows);
            this.tabPageShows.Location = new System.Drawing.Point(4, 22);
            this.tabPageShows.Name = "tabPageShows";
            this.tabPageShows.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShows.Size = new System.Drawing.Size(444, 447);
            this.tabPageShows.TabIndex = 2;
            this.tabPageShows.Text = "Add Shows";
            this.tabPageShows.UseVisualStyleBackColor = true;
            // 
            // lbShowDays
            // 
            this.lbShowDays.FormattingEnabled = true;
            this.lbShowDays.Location = new System.Drawing.Point(204, 242);
            this.lbShowDays.Name = "lbShowDays";
            this.lbShowDays.Size = new System.Drawing.Size(109, 95);
            this.lbShowDays.TabIndex = 54;
            this.lbShowDays.SelectedIndexChanged += new System.EventHandler(this.lbShowDays_SelectedIndexChanged);
            // 
            // lbShows
            // 
            this.lbShows.FormattingEnabled = true;
            this.lbShows.Location = new System.Drawing.Point(319, 242);
            this.lbShows.Name = "lbShows";
            this.lbShows.Size = new System.Drawing.Size(109, 95);
            this.lbShows.TabIndex = 53;
            // 
            // lbMovies
            // 
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.Location = new System.Drawing.Point(17, 242);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(181, 95);
            this.lbMovies.TabIndex = 52;
            this.lbMovies.SelectedIndexChanged += new System.EventHandler(this.lbMovies_SelectedIndexChanged);
            // 
            // btnAddShow
            // 
            this.btnAddShow.Location = new System.Drawing.Point(353, 405);
            this.btnAddShow.Name = "btnAddShow";
            this.btnAddShow.Size = new System.Drawing.Size(75, 23);
            this.btnAddShow.TabIndex = 50;
            this.btnAddShow.Text = "Add Show";
            this.btnAddShow.UseVisualStyleBackColor = true;
            this.btnAddShow.Click += new System.EventHandler(this.btnAddShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "$";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(26, 409);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 48;
            this.lblPrice.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(104, 406);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(209, 20);
            this.tbPrice.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Date";
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(104, 354);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(209, 20);
            this.tbDate.TabIndex = 41;
            // 
            // lblTimeTo
            // 
            this.lblTimeTo.AutoSize = true;
            this.lblTimeTo.Location = new System.Drawing.Point(195, 383);
            this.lblTimeTo.Name = "lblTimeTo";
            this.lblTimeTo.Size = new System.Drawing.Size(20, 13);
            this.lblTimeTo.TabIndex = 46;
            this.lblTimeTo.Text = "To";
            // 
            // tbTimeTo
            // 
            this.tbTimeTo.Location = new System.Drawing.Point(255, 380);
            this.tbTimeTo.Name = "tbTimeTo";
            this.tbTimeTo.Size = new System.Drawing.Size(58, 20);
            this.tbTimeTo.TabIndex = 43;
            // 
            // tbTimeFrom
            // 
            this.tbTimeFrom.Location = new System.Drawing.Point(104, 380);
            this.tbTimeFrom.Name = "tbTimeFrom";
            this.tbTimeFrom.Size = new System.Drawing.Size(58, 20);
            this.tbTimeFrom.TabIndex = 42;
            // 
            // lblTimeFrom
            // 
            this.lblTimeFrom.AutoSize = true;
            this.lblTimeFrom.Location = new System.Drawing.Point(26, 383);
            this.lblTimeFrom.Name = "lblTimeFrom";
            this.lblTimeFrom.Size = new System.Drawing.Size(30, 13);
            this.lblTimeFrom.TabIndex = 45;
            this.lblTimeFrom.Text = "Time";
            // 
            // tbShows
            // 
            this.tbShows.Location = new System.Drawing.Point(17, 21);
            this.tbShows.Multiline = true;
            this.tbShows.Name = "tbShows";
            this.tbShows.ReadOnly = true;
            this.tbShows.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbShows.Size = new System.Drawing.Size(318, 199);
            this.tbShows.TabIndex = 25;
            // 
            // libClientsShows
            // 
            this.libClientsShows.FormattingEnabled = true;
            this.libClientsShows.Location = new System.Drawing.Point(353, 21);
            this.libClientsShows.Name = "libClientsShows";
            this.libClientsShows.Size = new System.Drawing.Size(75, 199);
            this.libClientsShows.TabIndex = 26;
            // 
            // tabPageBooking
            // 
            this.tabPageBooking.Controls.Add(this.lbBookings);
            this.tabPageBooking.Controls.Add(this.tbBookings);
            this.tabPageBooking.Location = new System.Drawing.Point(4, 22);
            this.tabPageBooking.Name = "tabPageBooking";
            this.tabPageBooking.Size = new System.Drawing.Size(444, 447);
            this.tabPageBooking.TabIndex = 3;
            this.tabPageBooking.Text = "User Info";
            this.tabPageBooking.UseVisualStyleBackColor = true;
            // 
            // lbBookings
            // 
            this.lbBookings.FormattingEnabled = true;
            this.lbBookings.Location = new System.Drawing.Point(353, 21);
            this.lbBookings.Name = "lbBookings";
            this.lbBookings.Size = new System.Drawing.Size(75, 407);
            this.lbBookings.TabIndex = 27;
            this.lbBookings.SelectedIndexChanged += new System.EventHandler(this.lbBookings_SelectedIndexChanged);
            // 
            // tbBookings
            // 
            this.tbBookings.Location = new System.Drawing.Point(17, 21);
            this.tbBookings.Multiline = true;
            this.tbBookings.Name = "tbBookings";
            this.tbBookings.ReadOnly = true;
            this.tbBookings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBookings.Size = new System.Drawing.Size(318, 405);
            this.tbBookings.TabIndex = 26;
            // 
            // tabPageShowBookings
            // 
            this.tabPageShowBookings.Controls.Add(this.tbShowBookings);
            this.tabPageShowBookings.Controls.Add(this.lbShowBkShowDays);
            this.tabPageShowBookings.Controls.Add(this.lbShowBkShows);
            this.tabPageShowBookings.Controls.Add(this.lbShowBkMovies);
            this.tabPageShowBookings.Location = new System.Drawing.Point(4, 22);
            this.tabPageShowBookings.Name = "tabPageShowBookings";
            this.tabPageShowBookings.Size = new System.Drawing.Size(444, 447);
            this.tabPageShowBookings.TabIndex = 4;
            this.tabPageShowBookings.Text = "Show Info";
            this.tabPageShowBookings.UseVisualStyleBackColor = true;
            // 
            // tbShowBookings
            // 
            this.tbShowBookings.Location = new System.Drawing.Point(17, 128);
            this.tbShowBookings.Multiline = true;
            this.tbShowBookings.Name = "tbShowBookings";
            this.tbShowBookings.ReadOnly = true;
            this.tbShowBookings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbShowBookings.Size = new System.Drawing.Size(411, 304);
            this.tbShowBookings.TabIndex = 58;
            // 
            // lbShowBkShowDays
            // 
            this.lbShowBkShowDays.FormattingEnabled = true;
            this.lbShowBkShowDays.Location = new System.Drawing.Point(204, 18);
            this.lbShowBkShowDays.Name = "lbShowBkShowDays";
            this.lbShowBkShowDays.Size = new System.Drawing.Size(109, 95);
            this.lbShowBkShowDays.TabIndex = 57;
            this.lbShowBkShowDays.SelectedIndexChanged += new System.EventHandler(this.lbShowBkShowDays_SelectedIndexChanged);
            // 
            // lbShowBkShows
            // 
            this.lbShowBkShows.FormattingEnabled = true;
            this.lbShowBkShows.Location = new System.Drawing.Point(319, 18);
            this.lbShowBkShows.Name = "lbShowBkShows";
            this.lbShowBkShows.Size = new System.Drawing.Size(109, 95);
            this.lbShowBkShows.TabIndex = 56;
            this.lbShowBkShows.SelectedIndexChanged += new System.EventHandler(this.lbShowBkShows_SelectedIndexChanged);
            // 
            // lbShowBkMovies
            // 
            this.lbShowBkMovies.FormattingEnabled = true;
            this.lbShowBkMovies.Location = new System.Drawing.Point(17, 18);
            this.lbShowBkMovies.Name = "lbShowBkMovies";
            this.lbShowBkMovies.Size = new System.Drawing.Size(181, 95);
            this.lbShowBkMovies.TabIndex = 55;
            this.lbShowBkMovies.SelectedIndexChanged += new System.EventHandler(this.lbShowBkMovies_SelectedIndexChanged);
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.Controls.Add(this.btnWipe);
            this.tabPageDebug.Controls.Add(this.libClientsDebug);
            this.tabPageDebug.Controls.Add(this.btnDebugClear);
            this.tabPageDebug.Controls.Add(this.tbDisplay);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebug.Size = new System.Drawing.Size(444, 447);
            this.tabPageDebug.TabIndex = 1;
            this.tabPageDebug.Text = "Debug";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // btnWipe
            // 
            this.btnWipe.Location = new System.Drawing.Point(353, 405);
            this.btnWipe.Name = "btnWipe";
            this.btnWipe.Size = new System.Drawing.Size(75, 23);
            this.btnWipe.TabIndex = 19;
            this.btnWipe.Text = "Restore";
            this.btnWipe.UseVisualStyleBackColor = true;
            this.btnWipe.Click += new System.EventHandler(this.btnWipe_Click);
            // 
            // libClientsDebug
            // 
            this.libClientsDebug.FormattingEnabled = true;
            this.libClientsDebug.Location = new System.Drawing.Point(353, 21);
            this.libClientsDebug.Name = "libClientsDebug";
            this.libClientsDebug.Size = new System.Drawing.Size(75, 199);
            this.libClientsDebug.TabIndex = 17;
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
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(17, 21);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDisplay.Size = new System.Drawing.Size(318, 405);
            this.tbDisplay.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 497);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageMovies.ResumeLayout(false);
            this.tabPageMovies.PerformLayout();
            this.tabPageShows.ResumeLayout(false);
            this.tabPageShows.PerformLayout();
            this.tabPageBooking.ResumeLayout(false);
            this.tabPageBooking.PerformLayout();
            this.tabPageShowBookings.ResumeLayout(false);
            this.tabPageShowBookings.PerformLayout();
            this.tabPageDebug.ResumeLayout(false);
            this.tabPageDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMovies;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.TextBox tbMovies;
        private System.Windows.Forms.ListBox libClientsMovies;
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
        private System.Windows.Forms.ListBox libClientsDebug;
        private System.Windows.Forms.TabPage tabPageShows;
        private System.Windows.Forms.Button btnWipe;
        private System.Windows.Forms.TextBox tbShows;
        private System.Windows.Forms.ListBox libClientsShows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label lblTimeTo;
        private System.Windows.Forms.TextBox tbTimeTo;
        private System.Windows.Forms.TextBox tbTimeFrom;
        private System.Windows.Forms.Label lblTimeFrom;
        private System.Windows.Forms.Button btnAddShow;
        private System.Windows.Forms.ListBox lbMovies;
        private System.Windows.Forms.ListBox lbShows;
        private System.Windows.Forms.ListBox lbShowDays;
        private System.Windows.Forms.TabPage tabPageBooking;
        private System.Windows.Forms.TextBox tbBookings;
        private System.Windows.Forms.ListBox lbBookings;
        private System.Windows.Forms.TabPage tabPageShowBookings;
        private System.Windows.Forms.TextBox tbShowBookings;
        private System.Windows.Forms.ListBox lbShowBkShowDays;
        private System.Windows.Forms.ListBox lbShowBkShows;
        private System.Windows.Forms.ListBox lbShowBkMovies;
    }
}

