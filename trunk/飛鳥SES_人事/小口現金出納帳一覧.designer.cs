using ComDll;
namespace 飛鳥SES_人事
{
    partial class 小口現金出納帳一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(小口現金出納帳一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.lbl_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_errorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_to = new System.Windows.Forms.Label();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.dtp_enddate = new System.Windows.Forms.DateTimePicker();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.dtp_startdate = new System.Windows.Forms.DateTimePicker();
            this.txt_jyouken = new System.Windows.Forms.TextBox();
            this.gridView_syutsnyukin = new ComDll.RowMergeView();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_syutsnyukin)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.変更ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 変更ToolStripMenuItem
            // 
            this.変更ToolStripMenuItem.Name = "変更ToolStripMenuItem";
            this.変更ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.変更ToolStripMenuItem.Text = "変更";
            this.変更ToolStripMenuItem.Click += new System.EventHandler(this.変更ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_count,
            this.lbl_errorMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1209, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_count
            // 
            this.lbl_count.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_errorMessage
            // 
            this.lbl_errorMessage.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_errorMessage.Name = "lbl_errorMessage";
            this.lbl_errorMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_to
            // 
            this.lbl_to.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.lbl_to.Location = new System.Drawing.Point(625, 16);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(17, 21);
            this.lbl_to.TabIndex = 43;
            this.lbl_to.Text = "～";
            // 
            // cmb_type
            // 
            this.cmb_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmb_type.Font = new System.Drawing.Font("MS UI Gothic", 15.75F);
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.ItemHeight = 21;
            this.cmb_type.Items.AddRange(new object[] {
            "ALL",
            "入金",
            "出金"});
            this.cmb_type.Location = new System.Drawing.Point(1014, 12);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(174, 29);
            this.cmb_type.TabIndex = 37;
            this.cmb_type.SelectedIndexChanged += new System.EventHandler(this.cmb_type_SelectedIndexChanged);
            // 
            // dtp_enddate
            // 
            this.dtp_enddate.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.dtp_enddate.Location = new System.Drawing.Point(652, 14);
            this.dtp_enddate.Name = "dtp_enddate";
            this.dtp_enddate.Size = new System.Drawing.Size(145, 26);
            this.dtp_enddate.TabIndex = 42;
            this.dtp_enddate.Leave += new System.EventHandler(this.dtp_enddate_Leave);
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_download.Location = new System.Drawing.Point(826, 12);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(150, 29);
            this.btn_download.TabIndex = 40;
            this.btn_download.Text = "ダウンロード";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(288, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(116, 29);
            this.btn_search.TabIndex = 39;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dtp_startdate
            // 
            this.dtp_startdate.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.dtp_startdate.Location = new System.Drawing.Point(474, 14);
            this.dtp_startdate.Name = "dtp_startdate";
            this.dtp_startdate.Size = new System.Drawing.Size(145, 26);
            this.dtp_startdate.TabIndex = 41;
            this.dtp_startdate.Leave += new System.EventHandler(this.dtp_startdate_Leave);
            // 
            // txt_jyouken
            // 
            this.txt_jyouken.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.txt_jyouken.Location = new System.Drawing.Point(20, 12);
            this.txt_jyouken.MaxLength = 200;
            this.txt_jyouken.Multiline = true;
            this.txt_jyouken.Name = "txt_jyouken";
            this.txt_jyouken.Size = new System.Drawing.Size(234, 29);
            this.txt_jyouken.TabIndex = 38;
            // 
            // gridView_syutsnyukin
            // 
            this.gridView_syutsnyukin.AllowUserToAddRows = false;
            this.gridView_syutsnyukin.AllowUserToResizeRows = false;
            this.gridView_syutsnyukin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_syutsnyukin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_syutsnyukin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_syutsnyukin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_syutsnyukin.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_syutsnyukin.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridView_syutsnyukin.Key = "";
            this.gridView_syutsnyukin.Location = new System.Drawing.Point(15, 54);
            this.gridView_syutsnyukin.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_syutsnyukin.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_syutsnyukin.MergeColumnNames")));
            this.gridView_syutsnyukin.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_syutsnyukin.MergeRowIndex")));
            this.gridView_syutsnyukin.Name = "gridView_syutsnyukin";
            this.gridView_syutsnyukin.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_syutsnyukin.NoLink")));
            this.gridView_syutsnyukin.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridView_syutsnyukin.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridView_syutsnyukin.RowTemplate.Height = 21;
            this.gridView_syutsnyukin.Size = new System.Drawing.Size(1178, 517);
            this.gridView_syutsnyukin.TabIndex = 44;
            this.gridView_syutsnyukin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_syutsnyukin_CellDoubleClick);
            // 
            // 小口現金出納帳一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 624);
            this.Controls.Add(this.gridView_syutsnyukin);
            this.Controls.Add(this.lbl_to);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.dtp_enddate);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dtp_startdate);
            this.Controls.Add(this.txt_jyouken);
            this.Controls.Add(this.statusStrip1);
            this.Name = "小口現金出納帳一覧";
            this.Text = "小口現金出納帳一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.小口現金出納帳一覧_FormClosed);
            this.Load += new System.EventHandler(this.小口現金出納帳一覧_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_syutsnyukin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 変更ToolStripMenuItem;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_count;
        private System.Windows.Forms.ToolStripStatusLabel lbl_errorMessage;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.DateTimePicker dtp_enddate;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker dtp_startdate;
        private System.Windows.Forms.TextBox txt_jyouken;
        private RowMergeView gridView_syutsnyukin;
    }
}