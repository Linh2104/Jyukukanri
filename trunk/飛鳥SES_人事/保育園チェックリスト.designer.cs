using ComDll;
namespace 飛鳥SES_人事
{
    partial class 保育園チェックリスト
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(保育園チェックリスト));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_koumoku = new System.Windows.Forms.ComboBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_koumoku = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.lbl_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_errorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridView_checkList = new ComDll.RowMergeView();
            this.記録コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.メイン項目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.サブ項目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.点検内容例 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.チェック = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.処置 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.報告 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.点検内容コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_checkList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_koumoku
            // 
            this.cmb_koumoku.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmb_koumoku.Font = new System.Drawing.Font("MS UI Gothic", 15.75F);
            this.cmb_koumoku.FormattingEnabled = true;
            this.cmb_koumoku.ItemHeight = 21;
            this.cmb_koumoku.Items.AddRange(new object[] {
            "施設・設備",
            "遊具"});
            this.cmb_koumoku.Location = new System.Drawing.Point(84, 13);
            this.cmb_koumoku.Name = "cmb_koumoku";
            this.cmb_koumoku.Size = new System.Drawing.Size(180, 29);
            this.cmb_koumoku.TabIndex = 37;
            this.cmb_koumoku.SelectedIndexChanged += new System.EventHandler(this.cmb_koumoku_SelectedIndexChanged);
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_download.Location = new System.Drawing.Point(919, 12);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(150, 29);
            this.btn_download.TabIndex = 40;
            this.btn_download.Text = "ダウンロード";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_insert.Location = new System.Drawing.Point(711, 12);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(140, 29);
            this.btn_insert.TabIndex = 39;
            this.btn_insert.Text = "登録";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // dtp_date
            // 
            this.dtp_date.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.dtp_date.Location = new System.Drawing.Point(422, 13);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(180, 26);
            this.dtp_date.TabIndex = 41;
            // 
            // lbl_koumoku
            // 
            this.lbl_koumoku.AutoSize = true;
            this.lbl_koumoku.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.lbl_koumoku.Location = new System.Drawing.Point(12, 17);
            this.lbl_koumoku.Name = "lbl_koumoku";
            this.lbl_koumoku.Size = new System.Drawing.Size(39, 19);
            this.lbl_koumoku.TabIndex = 45;
            this.lbl_koumoku.Text = "項目";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.lbl_date.Location = new System.Drawing.Point(345, 17);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(39, 19);
            this.lbl_date.TabIndex = 47;
            this.lbl_date.Text = "日付";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_count,
            this.lbl_errorMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1088, 22);
            this.statusStrip1.TabIndex = 48;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_count
            // 
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(0, 17);
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_errorMessage
            // 
            this.lbl_errorMessage.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_errorMessage.Name = "lbl_errorMessage";
            this.lbl_errorMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "記録コード";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 82;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.HeaderText = "メイン項目";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.HeaderText = "サブ項目";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.HeaderText = "点検内容例";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.HeaderText = "処置";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "GroupCode1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 103;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "GroupCode2";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 103;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "行番号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 68;
            // 
            // gridView_checkList
            // 
            this.gridView_checkList.AllowUserToAddRows = false;
            this.gridView_checkList.AllowUserToResizeRows = false;
            this.gridView_checkList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_checkList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_checkList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_checkList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.記録コード,
            this.メイン項目,
            this.サブ項目,
            this.点検内容例,
            this.チェック,
            this.処置,
            this.報告,
            this.GroupCode1,
            this.GroupCode2,
            this.点検内容コード});
            this.gridView_checkList.Key = "";
            this.gridView_checkList.Location = new System.Drawing.Point(12, 88);
            this.gridView_checkList.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_checkList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_checkList.MergeColumnNames")));
            this.gridView_checkList.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_checkList.MergeRowIndex")));
            this.gridView_checkList.Name = "gridView_checkList";
            this.gridView_checkList.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_checkList.NoLink")));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView_checkList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridView_checkList.RowHeadersWidth = 60;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView_checkList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridView_checkList.RowTemplate.Height = 21;
            this.gridView_checkList.Size = new System.Drawing.Size(1064, 499);
            this.gridView_checkList.TabIndex = 49;
            this.gridView_checkList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridView_checkList_CellBeginEdit);
            this.gridView_checkList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_checkList_CellEndEdit);
            this.gridView_checkList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridView_checkList_CellMouseClick);
            this.gridView_checkList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridView_checkList_CellPainting);
            this.gridView_checkList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_checkList_CellValueChanged);
            // 
            // 記録コード
            // 
            this.記録コード.HeaderText = "記録コード";
            this.記録コード.Name = "記録コード";
            this.記録コード.ReadOnly = true;
            this.記録コード.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.記録コード.Visible = false;
            // 
            // メイン項目
            // 
            this.メイン項目.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.メイン項目.DefaultCellStyle = dataGridViewCellStyle2;
            this.メイン項目.HeaderText = "メイン項目";
            this.メイン項目.Name = "メイン項目";
            this.メイン項目.ReadOnly = true;
            this.メイン項目.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.メイン項目.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.メイン項目.Width = 150;
            // 
            // サブ項目
            // 
            this.サブ項目.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.サブ項目.HeaderText = "サブ項目";
            this.サブ項目.Name = "サブ項目";
            this.サブ項目.ReadOnly = true;
            this.サブ項目.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.サブ項目.Width = 150;
            // 
            // 点検内容例
            // 
            this.点検内容例.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.点検内容例.HeaderText = "点検内容例";
            this.点検内容例.Name = "点検内容例";
            this.点検内容例.ReadOnly = true;
            this.点検内容例.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.点検内容例.Width = 350;
            // 
            // チェック
            // 
            this.チェック.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.チェック.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.チェック.HeaderText = "チェック";
            this.チェック.Items.AddRange(new object[] {
            "",
            "○",
            "×"});
            this.チェック.Name = "チェック";
            this.チェック.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.チェック.Width = 110;
            // 
            // 処置
            // 
            this.処置.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.処置.HeaderText = "処置";
            this.処置.Name = "処置";
            this.処置.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.処置.Width = 110;
            // 
            // 報告
            // 
            this.報告.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.報告.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.報告.HeaderText = "報告";
            this.報告.Items.AddRange(new object[] {
            "×",
            "○"});
            this.報告.Name = "報告";
            this.報告.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.報告.Width = 110;
            // 
            // GroupCode1
            // 
            this.GroupCode1.HeaderText = "GroupCode1";
            this.GroupCode1.Name = "GroupCode1";
            this.GroupCode1.Visible = false;
            // 
            // GroupCode2
            // 
            this.GroupCode2.HeaderText = "GroupCode2";
            this.GroupCode2.Name = "GroupCode2";
            this.GroupCode2.Visible = false;
            // 
            // 点検内容コード
            // 
            this.点検内容コード.HeaderText = "点検内容コード";
            this.点検内容コード.Name = "点検内容コード";
            this.点検内容コード.Visible = false;
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_close.Location = new System.Drawing.Point(56, 53);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 30);
            this.btn_close.TabIndex = 97;
            this.btn_close.Text = "-";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_open.Location = new System.Drawing.Point(12, 53);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(30, 30);
            this.btn_open.TabIndex = 96;
            this.btn_open.Text = "+";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_Search.Location = new System.Drawing.Point(608, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(61, 29);
            this.btn_Search.TabIndex = 98;
            this.btn_Search.Text = "検索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Sarch_Click);
            // 
            // 保育園チェックリスト
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 624);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.gridView_checkList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_koumoku);
            this.Controls.Add(this.cmb_koumoku);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.dtp_date);
            this.Name = "保育園チェックリスト";
            this.Text = "保育園チェックリスト";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.保育園チェックリスト_FormClosed);
            this.Load += new System.EventHandler(this.保育園チェックリスト_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_checkList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_koumoku;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label lbl_koumoku;
        private System.Windows.Forms.Label lbl_date;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_errorMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private RowMergeView gridView_checkList;
        private System.Windows.Forms.DataGridViewTextBoxColumn 記録コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn メイン項目;
        private System.Windows.Forms.DataGridViewTextBoxColumn サブ項目;
        private System.Windows.Forms.DataGridViewTextBoxColumn 点検内容例;
        private System.Windows.Forms.DataGridViewComboBoxColumn チェック;
        private System.Windows.Forms.DataGridViewTextBoxColumn 処置;
        private System.Windows.Forms.DataGridViewComboBoxColumn 報告;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 点検内容コード;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.ToolStripStatusLabel lbl_count;
        private System.Windows.Forms.Button btn_Search;
    }
}