namespace 飛鳥SES_人事
{
    partial class 水泳活動参加園児一覧
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.sslbl_件数 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslbl_メッセージ = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.btn_印刷 = new System.Windows.Forms.Button();
            this.lbl_日付 = new System.Windows.Forms.Label();
            this.gridView_水泳活動 = new System.Windows.Forms.DataGridView();
            this.園児ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.園児名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年齢 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参加状況 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.送信チェック = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.メール = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.承諾書ファイル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.詳細 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.送信状態 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.アップロード = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_mail = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_水泳活動)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbl_件数,
            this.sslbl_メッセージ,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1136, 22);
            this.statusStrip1.TabIndex = 140;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbl_件数
            // 
            this.sslbl_件数.Name = "sslbl_件数";
            this.sslbl_件数.Size = new System.Drawing.Size(0, 17);
            // 
            // sslbl_メッセージ
            // 
            this.sslbl_メッセージ.Name = "sslbl_メッセージ";
            this.sslbl_メッセージ.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_date
            // 
            this.dtp_date.CustomFormat = "yyyy年MM月";
            this.dtp_date.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(85, 25);
            this.dtp_date.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.ShowUpDown = true;
            this.dtp_date.Size = new System.Drawing.Size(147, 23);
            this.dtp_date.TabIndex = 139;
            this.dtp_date.ValueChanged += new System.EventHandler(this.dtp_date_ValueChanged);
            // 
            // btn_印刷
            // 
            this.btn_印刷.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_印刷.Location = new System.Drawing.Point(989, 21);
            this.btn_印刷.Name = "btn_印刷";
            this.btn_印刷.Size = new System.Drawing.Size(124, 27);
            this.btn_印刷.TabIndex = 137;
            this.btn_印刷.Text = "お知らせ印刷";
            this.btn_印刷.UseVisualStyleBackColor = true;
            this.btn_印刷.Click += new System.EventHandler(this.btn_印刷_Click);
            // 
            // lbl_日付
            // 
            this.lbl_日付.AutoSize = true;
            this.lbl_日付.Location = new System.Drawing.Point(10, 28);
            this.lbl_日付.Name = "lbl_日付";
            this.lbl_日付.Size = new System.Drawing.Size(29, 12);
            this.lbl_日付.TabIndex = 135;
            this.lbl_日付.Text = "日付";
            // 
            // gridView_水泳活動
            // 
            this.gridView_水泳活動.AllowUserToAddRows = false;
            this.gridView_水泳活動.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_水泳活動.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_水泳活動.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.園児ID,
            this.園児名,
            this.性別,
            this.年齢,
            this.参加状況,
            this.日付,
            this.送信チェック,
            this.メール,
            this.承諾書ファイル,
            this.詳細,
            this.送信状態});
            this.gridView_水泳活動.ContextMenuStrip = this.contextMenuStrip1;
            this.gridView_水泳活動.Location = new System.Drawing.Point(12, 55);
            this.gridView_水泳活動.Name = "gridView_水泳活動";
            this.gridView_水泳活動.RowTemplate.Height = 23;
            this.gridView_水泳活動.Size = new System.Drawing.Size(1100, 502);
            this.gridView_水泳活動.TabIndex = 136;
            this.gridView_水泳活動.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_水泳活動_CellClick);
            this.gridView_水泳活動.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_水泳活動_CellContentDoubleClick);
            this.gridView_水泳活動.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_水泳活動_CellEndEdit);
            this.gridView_水泳活動.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_水泳活動_CellValueChanged);
            // 
            // 園児ID
            // 
            this.園児ID.HeaderText = "園児ID";
            this.園児ID.Name = "園児ID";
            this.園児ID.ReadOnly = true;
            // 
            // 園児名
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.園児名.DefaultCellStyle = dataGridViewCellStyle1;
            this.園児名.HeaderText = "園児名";
            this.園児名.Name = "園児名";
            this.園児名.ReadOnly = true;
            // 
            // 性別
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.性別.DefaultCellStyle = dataGridViewCellStyle2;
            this.性別.HeaderText = "性別";
            this.性別.Name = "性別";
            this.性別.ReadOnly = true;
            // 
            // 年齢
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.年齢.DefaultCellStyle = dataGridViewCellStyle3;
            this.年齢.HeaderText = "年齢";
            this.年齢.Name = "年齢";
            this.年齢.ReadOnly = true;
            // 
            // 参加状況
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.参加状況.DefaultCellStyle = dataGridViewCellStyle4;
            this.参加状況.HeaderText = "参加状況";
            this.参加状況.Items.AddRange(new object[] {
            "未提出",
            "参加",
            "不参加"});
            this.参加状況.Name = "参加状況";
            this.参加状況.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.参加状況.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 日付
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.日付.DefaultCellStyle = dataGridViewCellStyle5;
            this.日付.HeaderText = "日付";
            this.日付.Name = "日付";
            this.日付.ReadOnly = true;
            this.日付.Visible = false;
            // 
            // 送信チェック
            // 
            this.送信チェック.HeaderText = "送信チェック";
            this.送信チェック.Name = "送信チェック";
            // 
            // メール
            // 
            this.メール.HeaderText = "メール";
            this.メール.Name = "メール";
            this.メール.ReadOnly = true;
            this.メール.Width = 150;
            // 
            // 承諾書ファイル
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.承諾書ファイル.DefaultCellStyle = dataGridViewCellStyle6;
            this.承諾書ファイル.HeaderText = "承諾書ファイル";
            this.承諾書ファイル.Name = "承諾書ファイル";
            this.承諾書ファイル.ReadOnly = true;
            this.承諾書ファイル.Visible = false;
            // 
            // 詳細
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.詳細.DefaultCellStyle = dataGridViewCellStyle7;
            this.詳細.HeaderText = "承諾書";
            this.詳細.Name = "詳細";
            this.詳細.ReadOnly = true;
            this.詳細.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.詳細.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 送信状態
            // 
            this.送信状態.HeaderText = "送信状態";
            this.送信状態.Name = "送信状態";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アップロード});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // アップロード
            // 
            this.アップロード.Name = "アップロード";
            this.アップロード.Size = new System.Drawing.Size(148, 22);
            this.アップロード.Text = "アップロード";
            this.アップロード.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // btn_mail
            // 
            this.btn_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mail.Location = new System.Drawing.Point(848, 21);
            this.btn_mail.Name = "btn_mail";
            this.btn_mail.Size = new System.Drawing.Size(124, 27);
            this.btn_mail.TabIndex = 141;
            this.btn_mail.Text = "メール送信";
            this.btn_mail.UseVisualStyleBackColor = true;
            this.btn_mail.Click += new System.EventHandler(this.btn_mail_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "園児ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "園児名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.HeaderText = "性別";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "年齢";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "参加状況";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "日付";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn7.HeaderText = "承諾書ファイル";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn8.HeaderText = "承諾書";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "送信状態";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // 水泳活動参加園児一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 594);
            this.Controls.Add(this.btn_mail);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.btn_印刷);
            this.Controls.Add(this.lbl_日付);
            this.Controls.Add(this.gridView_水泳活動);
            this.Name = "水泳活動参加園児一覧";
            this.Text = "水泳活動参加園児一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.水泳活動参加園児一覧_FormClosed);
            this.Load += new System.EventHandler(this.水泳活動参加園児一覧_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_水泳活動)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_件数;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_メッセージ;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Button btn_印刷;
        private System.Windows.Forms.Label lbl_日付;
        private System.Windows.Forms.DataGridView gridView_水泳活動;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button btn_mail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem アップロード;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年齢;
        private System.Windows.Forms.DataGridViewComboBoxColumn 参加状況;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日付;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 送信チェック;
        private System.Windows.Forms.DataGridViewTextBoxColumn メール;
        private System.Windows.Forms.DataGridViewTextBoxColumn 承諾書ファイル;
        private System.Windows.Forms.DataGridViewTextBoxColumn 詳細;
        private System.Windows.Forms.DataGridViewTextBoxColumn 送信状態;
    }
}