namespace 飛鳥SES_人事
{
    partial class 園児健康診断登録
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_名前 = new System.Windows.Forms.Label();
            this.cmb_名前 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbl_室温 = new System.Windows.Forms.Label();
            this.txt_室温 = new System.Windows.Forms.TextBox();
            this.lbl_測温時間1 = new System.Windows.Forms.Label();
            this.lbl_測温時間2 = new System.Windows.Forms.Label();
            this.lbl_測温時間3 = new System.Windows.Forms.Label();
            this.lbl_単位１ = new System.Windows.Forms.Label();
            this.lbl_単位2 = new System.Windows.Forms.Label();
            this.lbl_単位3 = new System.Windows.Forms.Label();
            this.lbl_機嫌 = new System.Windows.Forms.Label();
            this.lbl_しっしん = new System.Windows.Forms.Label();
            this.lbl_せきはなみず = new System.Windows.Forms.Label();
            this.cmb_機嫌 = new System.Windows.Forms.ComboBox();
            this.cmb_しっしん = new System.Windows.Forms.ComboBox();
            this.cmb_せきはなみず = new System.Windows.Forms.ComboBox();
            this.lbl_その他 = new System.Windows.Forms.Label();
            this.txt_その他 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_軟便 = new System.Windows.Forms.Label();
            this.lbl_普通 = new System.Windows.Forms.Label();
            this.lbl_硬便 = new System.Windows.Forms.Label();
            this.txt_軟便 = new System.Windows.Forms.TextBox();
            this.txt_普通 = new System.Windows.Forms.TextBox();
            this.txt_硬便 = new System.Windows.Forms.TextBox();
            this.lbl_食事状況 = new System.Windows.Forms.Label();
            this.cmb_食事状況 = new System.Windows.Forms.ComboBox();
            this.btn_登録 = new System.Windows.Forms.Button();
            this.txt_体温1 = new System.Windows.Forms.TextBox();
            this.txt_体温2 = new System.Windows.Forms.TextBox();
            this.txt_体温3 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.time_2 = new System.Windows.Forms.DateTimePicker();
            this.time_1 = new System.Windows.Forms.DateTimePicker();
            this.gb_ = new System.Windows.Forms.GroupBox();
            this.time_3 = new System.Windows.Forms.DateTimePicker();
            this.gp_健康状況 = new System.Windows.Forms.GroupBox();
            this.gb_排便 = new System.Windows.Forms.GroupBox();
            this.lbl_日付 = new System.Windows.Forms.Label();
            this.txt_他 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.gb_.SuspendLayout();
            this.gp_健康状況.SuspendLayout();
            this.gb_排便.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_名前
            // 
            this.lbl_名前.AutoSize = true;
            this.lbl_名前.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_名前.Location = new System.Drawing.Point(43, 55);
            this.lbl_名前.Name = "lbl_名前";
            this.lbl_名前.Size = new System.Drawing.Size(40, 23);
            this.lbl_名前.TabIndex = 0;
            this.lbl_名前.Text = "名前";
            // 
            // cmb_名前
            // 
            this.cmb_名前.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_名前.FormattingEnabled = true;
            this.cmb_名前.Location = new System.Drawing.Point(185, 54);
            this.cmb_名前.Name = "cmb_名前";
            this.cmb_名前.Size = new System.Drawing.Size(121, 20);
            this.cmb_名前.TabIndex = 1;
            this.cmb_名前.SelectedIndexChanged += new System.EventHandler(this.Cmb_名前_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(185, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 19);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // lbl_室温
            // 
            this.lbl_室温.AutoSize = true;
            this.lbl_室温.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_室温.Location = new System.Drawing.Point(43, 96);
            this.lbl_室温.Name = "lbl_室温";
            this.lbl_室温.Size = new System.Drawing.Size(99, 23);
            this.lbl_室温.TabIndex = 3;
            this.lbl_室温.Text = "室温　[必須]";
            this.lbl_室温.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // txt_室温
            // 
            this.txt_室温.Location = new System.Drawing.Point(185, 99);
            this.txt_室温.MaxLength = 4;
            this.txt_室温.Name = "txt_室温";
            this.txt_室温.Size = new System.Drawing.Size(77, 19);
            this.txt_室温.TabIndex = 2;
            // 
            // lbl_測温時間1
            // 
            this.lbl_測温時間1.AutoSize = true;
            this.lbl_測温時間1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_測温時間1.Location = new System.Drawing.Point(7, 28);
            this.lbl_測温時間1.Name = "lbl_測温時間1";
            this.lbl_測温時間1.Size = new System.Drawing.Size(139, 23);
            this.lbl_測温時間1.TabIndex = 6;
            this.lbl_測温時間1.Text = "測温時間1　[必須]";
            this.lbl_測温時間1.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_測温時間2
            // 
            this.lbl_測温時間2.AutoSize = true;
            this.lbl_測温時間2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_測温時間2.Location = new System.Drawing.Point(7, 73);
            this.lbl_測温時間2.Name = "lbl_測温時間2";
            this.lbl_測温時間2.Size = new System.Drawing.Size(80, 23);
            this.lbl_測温時間2.TabIndex = 7;
            this.lbl_測温時間2.Text = "測温時間2";
            // 
            // lbl_測温時間3
            // 
            this.lbl_測温時間3.AutoSize = true;
            this.lbl_測温時間3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_測温時間3.Location = new System.Drawing.Point(7, 117);
            this.lbl_測温時間3.Name = "lbl_測温時間3";
            this.lbl_測温時間3.Size = new System.Drawing.Size(80, 23);
            this.lbl_測温時間3.TabIndex = 8;
            this.lbl_測温時間3.Text = "測温時間3";
            // 
            // lbl_単位１
            // 
            this.lbl_単位１.AutoSize = true;
            this.lbl_単位１.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_単位１.Location = new System.Drawing.Point(362, 28);
            this.lbl_単位１.Name = "lbl_単位１";
            this.lbl_単位１.Size = new System.Drawing.Size(25, 23);
            this.lbl_単位１.TabIndex = 12;
            this.lbl_単位１.Text = "℃";
            // 
            // lbl_単位2
            // 
            this.lbl_単位2.AutoSize = true;
            this.lbl_単位2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_単位2.Location = new System.Drawing.Point(362, 76);
            this.lbl_単位2.Name = "lbl_単位2";
            this.lbl_単位2.Size = new System.Drawing.Size(25, 23);
            this.lbl_単位2.TabIndex = 13;
            this.lbl_単位2.Text = "℃";
            // 
            // lbl_単位3
            // 
            this.lbl_単位3.AutoSize = true;
            this.lbl_単位3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_単位3.Location = new System.Drawing.Point(362, 120);
            this.lbl_単位3.Name = "lbl_単位3";
            this.lbl_単位3.Size = new System.Drawing.Size(25, 23);
            this.lbl_単位3.TabIndex = 14;
            this.lbl_単位3.Text = "℃";
            // 
            // lbl_機嫌
            // 
            this.lbl_機嫌.AutoSize = true;
            this.lbl_機嫌.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_機嫌.Location = new System.Drawing.Point(16, 28);
            this.lbl_機嫌.Name = "lbl_機嫌";
            this.lbl_機嫌.Size = new System.Drawing.Size(99, 23);
            this.lbl_機嫌.TabIndex = 16;
            this.lbl_機嫌.Text = "機嫌　[必須]";
            this.lbl_機嫌.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_しっしん
            // 
            this.lbl_しっしん.AutoSize = true;
            this.lbl_しっしん.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_しっしん.Location = new System.Drawing.Point(16, 69);
            this.lbl_しっしん.Name = "lbl_しっしん";
            this.lbl_しっしん.Size = new System.Drawing.Size(129, 23);
            this.lbl_しっしん.TabIndex = 17;
            this.lbl_しっしん.Text = "しっしん　[必須]";
            this.lbl_しっしん.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_せきはなみず
            // 
            this.lbl_せきはなみず.AutoSize = true;
            this.lbl_せきはなみず.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_せきはなみず.Location = new System.Drawing.Point(16, 113);
            this.lbl_せきはなみず.Name = "lbl_せきはなみず";
            this.lbl_せきはなみず.Size = new System.Drawing.Size(174, 23);
            this.lbl_せきはなみず.TabIndex = 18;
            this.lbl_せきはなみず.Text = "せき・はなみず　[必須]";
            this.lbl_せきはなみず.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // cmb_機嫌
            // 
            this.cmb_機嫌.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_機嫌.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_機嫌.FormattingEnabled = true;
            this.cmb_機嫌.Items.AddRange(new object[] {
            "良",
            "普通",
            "不良"});
            this.cmb_機嫌.Location = new System.Drawing.Point(193, 30);
            this.cmb_機嫌.Name = "cmb_機嫌";
            this.cmb_機嫌.Size = new System.Drawing.Size(121, 20);
            this.cmb_機嫌.TabIndex = 9;
            // 
            // cmb_しっしん
            // 
            this.cmb_しっしん.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_しっしん.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_しっしん.FormattingEnabled = true;
            this.cmb_しっしん.Items.AddRange(new object[] {
            "有",
            "無"});
            this.cmb_しっしん.Location = new System.Drawing.Point(193, 69);
            this.cmb_しっしん.Name = "cmb_しっしん";
            this.cmb_しっしん.Size = new System.Drawing.Size(121, 20);
            this.cmb_しっしん.TabIndex = 10;
            // 
            // cmb_せきはなみず
            // 
            this.cmb_せきはなみず.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_せきはなみず.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_せきはなみず.FormattingEnabled = true;
            this.cmb_せきはなみず.Items.AddRange(new object[] {
            "有",
            "無"});
            this.cmb_せきはなみず.Location = new System.Drawing.Point(193, 113);
            this.cmb_せきはなみず.Name = "cmb_せきはなみず";
            this.cmb_せきはなみず.Size = new System.Drawing.Size(121, 20);
            this.cmb_せきはなみず.TabIndex = 11;
            // 
            // lbl_その他
            // 
            this.lbl_その他.AutoSize = true;
            this.lbl_その他.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_その他.Location = new System.Drawing.Point(16, 149);
            this.lbl_その他.Name = "lbl_その他";
            this.lbl_その他.Size = new System.Drawing.Size(55, 23);
            this.lbl_その他.TabIndex = 22;
            this.lbl_その他.Text = "その他";
            // 
            // txt_その他
            // 
            this.txt_その他.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_その他.Location = new System.Drawing.Point(193, 153);
            this.txt_その他.Name = "txt_その他";
            this.txt_その他.Size = new System.Drawing.Size(121, 19);
            this.txt_その他.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(281, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "℃";
            // 
            // lbl_軟便
            // 
            this.lbl_軟便.AutoSize = true;
            this.lbl_軟便.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_軟便.Location = new System.Drawing.Point(7, 35);
            this.lbl_軟便.Name = "lbl_軟便";
            this.lbl_軟便.Size = new System.Drawing.Size(40, 23);
            this.lbl_軟便.TabIndex = 26;
            this.lbl_軟便.Text = "軟便";
            // 
            // lbl_普通
            // 
            this.lbl_普通.AutoSize = true;
            this.lbl_普通.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_普通.Location = new System.Drawing.Point(156, 35);
            this.lbl_普通.Name = "lbl_普通";
            this.lbl_普通.Size = new System.Drawing.Size(40, 23);
            this.lbl_普通.TabIndex = 27;
            this.lbl_普通.Text = "普通";
            // 
            // lbl_硬便
            // 
            this.lbl_硬便.AutoSize = true;
            this.lbl_硬便.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_硬便.Location = new System.Drawing.Point(332, 35);
            this.lbl_硬便.Name = "lbl_硬便";
            this.lbl_硬便.Size = new System.Drawing.Size(40, 23);
            this.lbl_硬便.TabIndex = 28;
            this.lbl_硬便.Text = "硬便";
            // 
            // txt_軟便
            // 
            this.txt_軟便.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_軟便.Location = new System.Drawing.Point(77, 38);
            this.txt_軟便.MaxLength = 2;
            this.txt_軟便.Name = "txt_軟便";
            this.txt_軟便.Size = new System.Drawing.Size(29, 19);
            this.txt_軟便.TabIndex = 14;
            this.txt_軟便.Text = "0";
            // 
            // txt_普通
            // 
            this.txt_普通.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_普通.Location = new System.Drawing.Point(220, 39);
            this.txt_普通.MaxLength = 2;
            this.txt_普通.Name = "txt_普通";
            this.txt_普通.Size = new System.Drawing.Size(29, 19);
            this.txt_普通.TabIndex = 15;
            this.txt_普通.Text = "0";
            // 
            // txt_硬便
            // 
            this.txt_硬便.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_硬便.Location = new System.Drawing.Point(398, 39);
            this.txt_硬便.MaxLength = 2;
            this.txt_硬便.Name = "txt_硬便";
            this.txt_硬便.Size = new System.Drawing.Size(29, 19);
            this.txt_硬便.TabIndex = 16;
            this.txt_硬便.Text = "0";
            // 
            // lbl_食事状況
            // 
            this.lbl_食事状況.AutoSize = true;
            this.lbl_食事状況.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_食事状況.Location = new System.Drawing.Point(43, 317);
            this.lbl_食事状況.Name = "lbl_食事状況";
            this.lbl_食事状況.Size = new System.Drawing.Size(70, 23);
            this.lbl_食事状況.TabIndex = 32;
            this.lbl_食事状況.Text = "食事状況";
            // 
            // cmb_食事状況
            // 
            this.cmb_食事状況.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_食事状況.FormattingEnabled = true;
            this.cmb_食事状況.Items.AddRange(new object[] {
            "2/3",
            "完食",
            "その他"});
            this.cmb_食事状況.Location = new System.Drawing.Point(185, 320);
            this.cmb_食事状況.Name = "cmb_食事状況";
            this.cmb_食事状況.Size = new System.Drawing.Size(77, 20);
            this.cmb_食事状況.TabIndex = 5;
            this.cmb_食事状況.SelectedIndexChanged += new System.EventHandler(this.Cmb_食事状況_SelectedIndexChanged);
            // 
            // btn_登録
            // 
            this.btn_登録.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_登録.Location = new System.Drawing.Point(395, 450);
            this.btn_登録.Name = "btn_登録";
            this.btn_登録.Size = new System.Drawing.Size(78, 30);
            this.btn_登録.TabIndex = 7;
            this.btn_登録.Text = "登  録";
            this.btn_登録.UseVisualStyleBackColor = true;
            this.btn_登録.Click += new System.EventHandler(this.Btn_登録_Click);
            // 
            // txt_体温1
            // 
            this.txt_体温1.AcceptsReturn = true;
            this.txt_体温1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_体温1.Location = new System.Drawing.Point(295, 28);
            this.txt_体温1.Name = "txt_体温1";
            this.txt_体温1.Size = new System.Drawing.Size(61, 19);
            this.txt_体温1.TabIndex = 4;
            this.txt_体温1.Leave += new System.EventHandler(this.Txt_体温1_Leave);
            // 
            // txt_体温2
            // 
            this.txt_体温2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_体温2.Location = new System.Drawing.Point(295, 75);
            this.txt_体温2.MaxLength = 4;
            this.txt_体温2.Name = "txt_体温2";
            this.txt_体温2.Size = new System.Drawing.Size(61, 19);
            this.txt_体温2.TabIndex = 6;
            this.txt_体温2.Leave += new System.EventHandler(this.Txt_体温2_Leave);
            // 
            // txt_体温3
            // 
            this.txt_体温3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_体温3.Location = new System.Drawing.Point(295, 120);
            this.txt_体温3.MaxLength = 4;
            this.txt_体温3.Name = "txt_体温3";
            this.txt_体温3.Size = new System.Drawing.Size(61, 19);
            this.txt_体温3.TabIndex = 8;
            this.txt_体温3.Leave += new System.EventHandler(this.Txt_体温3_Leave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(845, 22);
            this.statusStrip1.TabIndex = 125;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // time_2
            // 
            this.time_2.CustomFormat = "HH:mm:ss";
            this.time_2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.time_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_2.Location = new System.Drawing.Point(149, 73);
            this.time_2.Name = "time_2";
            this.time_2.ShowUpDown = true;
            this.time_2.Size = new System.Drawing.Size(126, 19);
            this.time_2.TabIndex = 5;
            this.time_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Time_2_MouseDown);
            // 
            // time_1
            // 
            this.time_1.CustomFormat = "HH:mm:ss";
            this.time_1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.time_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_1.Location = new System.Drawing.Point(149, 28);
            this.time_1.Name = "time_1";
            this.time_1.ShowUpDown = true;
            this.time_1.Size = new System.Drawing.Size(126, 19);
            this.time_1.TabIndex = 3;
            this.time_1.Value = new System.DateTime(2020, 10, 9, 13, 19, 15, 0);
            this.time_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Time_1_MouseDown);
            // 
            // gb_
            // 
            this.gb_.AccessibleDescription = "体温";
            this.gb_.Controls.Add(this.time_3);
            this.gb_.Controls.Add(this.lbl_測温時間1);
            this.gb_.Controls.Add(this.lbl_測温時間3);
            this.gb_.Controls.Add(this.lbl_測温時間2);
            this.gb_.Controls.Add(this.time_2);
            this.gb_.Controls.Add(this.time_1);
            this.gb_.Controls.Add(this.txt_体温3);
            this.gb_.Controls.Add(this.txt_体温1);
            this.gb_.Controls.Add(this.lbl_単位１);
            this.gb_.Controls.Add(this.lbl_単位3);
            this.gb_.Controls.Add(this.txt_体温2);
            this.gb_.Controls.Add(this.lbl_単位2);
            this.gb_.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gb_.Location = new System.Drawing.Point(36, 135);
            this.gb_.Name = "gb_";
            this.gb_.Size = new System.Drawing.Size(427, 155);
            this.gb_.TabIndex = 3;
            this.gb_.TabStop = false;
            this.gb_.Text = "体温";
            // 
            // time_3
            // 
            this.time_3.CustomFormat = "HH:mm:ss";
            this.time_3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.time_3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_3.Location = new System.Drawing.Point(149, 121);
            this.time_3.Name = "time_3";
            this.time_3.ShowUpDown = true;
            this.time_3.Size = new System.Drawing.Size(126, 19);
            this.time_3.TabIndex = 7;
            this.time_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Time_3_MouseDown);
            // 
            // gp_健康状況
            // 
            this.gp_健康状況.Controls.Add(this.lbl_機嫌);
            this.gp_健康状況.Controls.Add(this.cmb_機嫌);
            this.gp_健康状況.Controls.Add(this.lbl_せきはなみず);
            this.gp_健康状況.Controls.Add(this.cmb_せきはなみず);
            this.gp_健康状況.Controls.Add(this.lbl_しっしん);
            this.gp_健康状況.Controls.Add(this.cmb_しっしん);
            this.gp_健康状況.Controls.Add(this.lbl_その他);
            this.gp_健康状況.Controls.Add(this.txt_その他);
            this.gp_健康状況.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gp_健康状況.Location = new System.Drawing.Point(480, 135);
            this.gp_健康状況.Name = "gp_健康状況";
            this.gp_健康状況.Size = new System.Drawing.Size(340, 202);
            this.gp_健康状況.TabIndex = 4;
            this.gp_健康状況.TabStop = false;
            this.gp_健康状況.Text = "健康状況　";
            // 
            // gb_排便
            // 
            this.gb_排便.Controls.Add(this.lbl_軟便);
            this.gb_排便.Controls.Add(this.txt_硬便);
            this.gb_排便.Controls.Add(this.txt_軟便);
            this.gb_排便.Controls.Add(this.txt_普通);
            this.gb_排便.Controls.Add(this.lbl_普通);
            this.gb_排便.Controls.Add(this.lbl_硬便);
            this.gb_排便.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gb_排便.Location = new System.Drawing.Point(36, 353);
            this.gb_排便.Name = "gb_排便";
            this.gb_排便.Size = new System.Drawing.Size(609, 71);
            this.gb_排便.TabIndex = 6;
            this.gb_排便.TabStop = false;
            this.gb_排便.Text = "排便";
            // 
            // lbl_日付
            // 
            this.lbl_日付.AutoSize = true;
            this.lbl_日付.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_日付.Location = new System.Drawing.Point(43, 12);
            this.lbl_日付.Name = "lbl_日付";
            this.lbl_日付.Size = new System.Drawing.Size(40, 23);
            this.lbl_日付.TabIndex = 129;
            this.lbl_日付.Text = "日付";
            // 
            // txt_他
            // 
            this.txt_他.Location = new System.Drawing.Point(285, 320);
            this.txt_他.Name = "txt_他";
            this.txt_他.Size = new System.Drawing.Size(40, 19);
            this.txt_他.TabIndex = 130;
            this.txt_他.Visible = false;
            // 
            // 園児健康診断登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 555);
            this.Controls.Add(this.txt_他);
            this.Controls.Add(this.lbl_日付);
            this.Controls.Add(this.gb_排便);
            this.Controls.Add(this.gp_健康状況);
            this.Controls.Add(this.gb_);
            this.Controls.Add(this.lbl_室温);
            this.Controls.Add(this.txt_室温);
            this.Controls.Add(this.lbl_名前);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_名前);
            this.Controls.Add(this.cmb_食事状況);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_登録);
            this.Controls.Add(this.lbl_食事状況);
            this.Name = "園児健康診断登録";
            this.Text = "園児健康診断登録";
            this.Load += new System.EventHandler(this.健康診断登録_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gb_.ResumeLayout(false);
            this.gb_.PerformLayout();
            this.gp_健康状況.ResumeLayout(false);
            this.gp_健康状況.PerformLayout();
            this.gb_排便.ResumeLayout(false);
            this.gb_排便.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_名前;
        private System.Windows.Forms.ComboBox cmb_名前;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbl_室温;
        private System.Windows.Forms.TextBox txt_室温;
        private System.Windows.Forms.Label lbl_測温時間1;
        private System.Windows.Forms.Label lbl_測温時間2;
        private System.Windows.Forms.Label lbl_測温時間3;
        private System.Windows.Forms.Label lbl_単位１;
        private System.Windows.Forms.Label lbl_単位2;
        private System.Windows.Forms.Label lbl_単位3;
        private System.Windows.Forms.Label lbl_機嫌;
        private System.Windows.Forms.Label lbl_しっしん;
        private System.Windows.Forms.Label lbl_せきはなみず;
        private System.Windows.Forms.ComboBox cmb_機嫌;
        private System.Windows.Forms.ComboBox cmb_しっしん;
        private System.Windows.Forms.ComboBox cmb_せきはなみず;
        private System.Windows.Forms.Label lbl_その他;
        private System.Windows.Forms.TextBox txt_その他;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_軟便;
        private System.Windows.Forms.Label lbl_普通;
        private System.Windows.Forms.Label lbl_硬便;
        private System.Windows.Forms.TextBox txt_軟便;
        private System.Windows.Forms.TextBox txt_普通;
        private System.Windows.Forms.TextBox txt_硬便;
        private System.Windows.Forms.Label lbl_食事状況;
        private System.Windows.Forms.ComboBox cmb_食事状況;
        private System.Windows.Forms.Button btn_登録;
        private System.Windows.Forms.TextBox txt_体温1;
        private System.Windows.Forms.TextBox txt_体温2;
        private System.Windows.Forms.TextBox txt_体温3;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DateTimePicker time_2;
        private System.Windows.Forms.DateTimePicker time_1;
        private System.Windows.Forms.GroupBox gb_;
        private System.Windows.Forms.GroupBox gp_健康状況;
        private System.Windows.Forms.GroupBox gb_排便;
        private System.Windows.Forms.Label lbl_日付;
        private System.Windows.Forms.DateTimePicker time_3;
        private System.Windows.Forms.TextBox txt_他;
    }
}