using ComDll;
using System.Windows.Forms;
namespace 飛鳥SES_人事
{
    partial class 検食簿一覧
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
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(検食簿一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_date = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_diff = new System.Windows.Forms.Label();
            this.cmb_diff = new System.Windows.Forms.ComboBox();
            this.gv_foodcheck = new ComDll.RowMergeView();
            this.チェックコード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.献立名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.味付 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.盛付 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.分量 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.担当者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.衛生所見等 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtp_datelast = new System.Windows.Forms.DateTimePicker();
            this.lbl_kara = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gv_foodcheck)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Meiryo", 10.8F);
            this.txt_search.Location = new System.Drawing.Point(7, 21);
            this.txt_search.Margin = new System.Windows.Forms.Padding(2);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(127, 29);
            this.txt_search.TabIndex = 0;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Meiryo", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(151, 20);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(93, 34);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "検　索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Meiryo", 10.8F, System.Drawing.FontStyle.Bold);
            this.lbl_date.Location = new System.Drawing.Point(276, 23);
            this.lbl_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(40, 23);
            this.lbl_date.TabIndex = 2;
            this.lbl_date.Text = "日付";
            // 
            // dtp_date
            // 
            this.dtp_date.Font = new System.Drawing.Font("Meiryo", 10.8F);
            this.dtp_date.Location = new System.Drawing.Point(347, 20);
            this.dtp_date.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(149, 29);
            this.dtp_date.TabIndex = 3;
            this.dtp_date.ValueChanged += new System.EventHandler(this.dtp_date_Leave);
            // 
            // lbl_diff
            // 
            this.lbl_diff.AutoSize = true;
            this.lbl_diff.Font = new System.Drawing.Font("Meiryo", 10.8F, System.Drawing.FontStyle.Bold);
            this.lbl_diff.Location = new System.Drawing.Point(740, 25);
            this.lbl_diff.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_diff.Name = "lbl_diff";
            this.lbl_diff.Size = new System.Drawing.Size(40, 23);
            this.lbl_diff.TabIndex = 4;
            this.lbl_diff.Text = "区分";
            // 
            // cmb_diff
            // 
            this.cmb_diff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_diff.Font = new System.Drawing.Font("Meiryo", 10.8F);
            this.cmb_diff.FormattingEnabled = true;
            this.cmb_diff.Items.AddRange(new object[] {
            "All",
            "九時おやつ",
            "昼食",
            "三時おやつ"});
            this.cmb_diff.Location = new System.Drawing.Point(819, 22);
            this.cmb_diff.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_diff.Name = "cmb_diff";
            this.cmb_diff.Size = new System.Drawing.Size(106, 29);
            this.cmb_diff.TabIndex = 5;
            this.cmb_diff.SelectedIndexChanged += new System.EventHandler(this.cmb_diff_SelectedIndexChanged);
            // 
            // gv_foodcheck
            // 
            this.gv_foodcheck.AllowUserToAddRows = false;
            this.gv_foodcheck.AllowUserToResizeRows = false;
            this.gv_foodcheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_foodcheck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_foodcheck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_foodcheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_foodcheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.チェックコード,
            this.日付,
            this.時間,
            this.献立名,
            this.味付,
            this.盛付,
            this.分量,
            this.担当者,
            this.衛生所見等,
            this.備考});
            this.gv_foodcheck.Key = "";
            this.gv_foodcheck.Location = new System.Drawing.Point(7, 75);
            this.gv_foodcheck.Margin = new System.Windows.Forms.Padding(2);
            this.gv_foodcheck.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gv_foodcheck.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gv_foodcheck.MergeColumnNames")));
            this.gv_foodcheck.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gv_foodcheck.MergeRowIndex")));
            this.gv_foodcheck.Name = "gv_foodcheck";
            this.gv_foodcheck.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gv_foodcheck.NoLink")));
            this.gv_foodcheck.RowTemplate.Height = 27;
            this.gv_foodcheck.Size = new System.Drawing.Size(1280, 496);
            this.gv_foodcheck.TabIndex = 7;
            this.gv_foodcheck.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_foodcheck_CellValueChanged);
            // 
            // チェックコード
            // 
            this.チェックコード.HeaderText = "チェックコード";
            this.チェックコード.Name = "チェックコード";
            this.チェックコード.Visible = false;
            // 
            // 日付
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.日付.DefaultCellStyle = dataGridViewCellStyle2;
            this.日付.HeaderText = "日付";
            this.日付.Name = "日付";
            this.日付.ReadOnly = true;
            // 
            // 時間
            // 
            this.時間.HeaderText = "時間";
            this.時間.Name = "時間";
            this.時間.ReadOnly = true;
            // 
            // 献立名
            // 
            this.献立名.HeaderText = "献立名";
            this.献立名.Name = "献立名";
            this.献立名.ReadOnly = true;
            // 
            // 味付
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.味付.DefaultCellStyle = dataGridViewCellStyle3;
            this.味付.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.味付.HeaderText = "味付";
            this.味付.Items.AddRange(new object[] {
            "良",
            "薄",
            "濃"});
            this.味付.Name = "味付";
            this.味付.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 盛付
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.盛付.DefaultCellStyle = dataGridViewCellStyle4;
            this.盛付.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.盛付.HeaderText = "盛付";
            this.盛付.Items.AddRange(new object[] {
            "良",
            "普",
            "悪"});
            this.盛付.Name = "盛付";
            this.盛付.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 分量
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            this.分量.DefaultCellStyle = dataGridViewCellStyle5;
            this.分量.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.分量.HeaderText = "分量";
            this.分量.Items.AddRange(new object[] {
            "適",
            "多",
            "少"});
            this.分量.Name = "分量";
            this.分量.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 担当者
            // 
            this.担当者.HeaderText = "担当者";
            this.担当者.MaxInputLength = 10;
            this.担当者.Name = "担当者";
            this.担当者.ReadOnly = true;
            // 
            // 衛生所見等
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            this.衛生所見等.DefaultCellStyle = dataGridViewCellStyle6;
            this.衛生所見等.HeaderText = "衛生所見等";
            this.衛生所見等.MaxInputLength = 50;
            this.衛生所見等.Name = "衛生所見等";
            // 
            // 備考
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            this.備考.DefaultCellStyle = dataGridViewCellStyle7;
            this.備考.HeaderText = "備考";
            this.備考.MaxInputLength = 50;
            this.備考.Name = "備考";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1296, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_datelast
            // 
            this.dtp_datelast.Font = new System.Drawing.Font("Meiryo", 10.8F);
            this.dtp_datelast.Location = new System.Drawing.Point(555, 20);
            this.dtp_datelast.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_datelast.Name = "dtp_datelast";
            this.dtp_datelast.Size = new System.Drawing.Size(149, 29);
            this.dtp_datelast.TabIndex = 9;
            this.dtp_datelast.ValueChanged += new System.EventHandler(this.dtp_date_Leave);
            // 
            // lbl_kara
            // 
            this.lbl_kara.AutoSize = true;
            this.lbl_kara.Font = new System.Drawing.Font("Meiryo", 10.8F, System.Drawing.FontStyle.Bold);
            this.lbl_kara.Location = new System.Drawing.Point(517, 23);
            this.lbl_kara.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_kara.Name = "lbl_kara";
            this.lbl_kara.Size = new System.Drawing.Size(22, 23);
            this.lbl_kara.TabIndex = 10;
            this.lbl_kara.Text = "~";
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("Meiryo", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_download.Location = new System.Drawing.Point(990, 21);
            this.btn_download.Margin = new System.Windows.Forms.Padding(2);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(186, 33);
            this.btn_download.TabIndex = 11;
            this.btn_download.Text = "検食簿導出";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // 検食簿一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 612);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.lbl_kara);
            this.Controls.Add(this.dtp_datelast);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gv_foodcheck);
            this.Controls.Add(this.cmb_diff);
            this.Controls.Add(this.lbl_diff);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "検食簿一覧";
            this.Text = "検食簿一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.検食簿一覧_FormClosed);
            this.Load += new System.EventHandler(this.検食簿一覧_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_foodcheck)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label lbl_diff;
        private System.Windows.Forms.ComboBox cmb_diff;
        //private System.Windows.Forms.DataGridView gv_foodcheck;
        //private System.Windows.Forms.StatusStrip statusStrip1;
        public RowMergeView gv_foodcheck;
        private HL_StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private DateTimePicker dtp_datelast;
        private Label lbl_kara;
        private DataGridViewTextBoxColumn チェックコード;
        private DataGridViewTextBoxColumn 日付;
        private DataGridViewTextBoxColumn 時間;
        private DataGridViewTextBoxColumn 献立名;
        private DataGridViewComboBoxColumn 味付;
        private DataGridViewComboBoxColumn 盛付;
        private DataGridViewComboBoxColumn 分量;
        private DataGridViewTextBoxColumn 担当者;
        private DataGridViewTextBoxColumn 衛生所見等;
        private DataGridViewTextBoxColumn 備考;
        private Button btn_download;
    }
}