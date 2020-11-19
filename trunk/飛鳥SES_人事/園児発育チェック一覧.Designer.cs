namespace 飛鳥SES_人事
{
    partial class 園児発育チェック一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(園児発育チェック一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_園児検索 = new System.Windows.Forms.Button();
            this.dgv_園児発育現状 = new ComDll.RowMergeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.体重身長入力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.発育チェック登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_入園年度 = new System.Windows.Forms.ComboBox();
            this.lbl_入園年度 = new System.Windows.Forms.Label();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.名前 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.フリガナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.胸囲 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.頭囲 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.栄養状況 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身長 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.体重 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.測定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_園児発育現状)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_園児検索
            // 
            this.btn_園児検索.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_園児検索.Location = new System.Drawing.Point(344, 8);
            this.btn_園児検索.Margin = new System.Windows.Forms.Padding(4);
            this.btn_園児検索.Name = "btn_園児検索";
            this.btn_園児検索.Size = new System.Drawing.Size(122, 37);
            this.btn_園児検索.TabIndex = 93;
            this.btn_園児検索.Text = "検索";
            this.btn_園児検索.UseVisualStyleBackColor = true;
            this.btn_園児検索.Click += new System.EventHandler(this.btn_園児検索_Click);
            // 
            // dgv_園児発育現状
            // 
            this.dgv_園児発育現状.AllowUserToAddRows = false;
            this.dgv_園児発育現状.AllowUserToResizeRows = false;
            this.dgv_園児発育現状.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_園児発育現状.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_園児発育現状.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_園児発育現状.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.名前,
            this.フリガナ,
            this.性別,
            this.胸囲,
            this.頭囲,
            this.栄養状況,
            this.身長,
            this.体重,
            this.測定日});
            this.dgv_園児発育現状.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_園児発育現状.Key = "";
            this.dgv_園児発育現状.Location = new System.Drawing.Point(13, 53);
            this.dgv_園児発育現状.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_園児発育現状.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_園児発育現状.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_園児発育現状.MergeColumnNames")));
            this.dgv_園児発育現状.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("dgv_園児発育現状.MergeRowIndex")));
            this.dgv_園児発育現状.Name = "dgv_園児発育現状";
            this.dgv_園児発育現状.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("dgv_園児発育現状.NoLink")));
            this.dgv_園児発育現状.RowTemplate.Height = 20;
            this.dgv_園児発育現状.Size = new System.Drawing.Size(979, 491);
            this.dgv_園児発育現状.TabIndex = 94;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.体重身長入力ToolStripMenuItem,
            this.発育チェック登録ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 体重身長入力ToolStripMenuItem
            // 
            this.体重身長入力ToolStripMenuItem.Name = "体重身長入力ToolStripMenuItem";
            this.体重身長入力ToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.体重身長入力ToolStripMenuItem.Text = "成長曲線図";
            this.体重身長入力ToolStripMenuItem.Click += new System.EventHandler(this.体重身長入力ToolStripMenuItem_Click);
            // 
            // 発育チェック登録ToolStripMenuItem
            // 
            this.発育チェック登録ToolStripMenuItem.Name = "発育チェック登録ToolStripMenuItem";
            this.発育チェック登録ToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.発育チェック登録ToolStripMenuItem.Text = "発育チェック登録";
            this.発育チェック登録ToolStripMenuItem.Click += new System.EventHandler(this.発育チェック登録ToolStripMenuItem_Click);
            // 
            // cmb_入園年度
            // 
            this.cmb_入園年度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_入園年度.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_入園年度.FormattingEnabled = true;
            this.cmb_入園年度.Location = new System.Drawing.Point(127, 11);
            this.cmb_入園年度.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_入園年度.Name = "cmb_入園年度";
            this.cmb_入園年度.Size = new System.Drawing.Size(193, 34);
            this.cmb_入園年度.TabIndex = 95;
            this.cmb_入園年度.SelectedIndexChanged += new System.EventHandler(this.cmb_入園年度_SelectedIndexChanged);
            // 
            // lbl_入園年度
            // 
            this.lbl_入園年度.AutoSize = true;
            this.lbl_入園年度.Font = new System.Drawing.Font("SimSun", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_入園年度.Location = new System.Drawing.Point(31, 19);
            this.lbl_入園年度.Name = "lbl_入園年度";
            this.lbl_入園年度.Size = new System.Drawing.Size(89, 19);
            this.lbl_入園年度.TabIndex = 96;
            this.lbl_入園年度.Text = "入園年度";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1045, 22);
            this.statusStrip1.TabIndex = 124;
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
            // 名前
            // 
            this.名前.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.名前.DefaultCellStyle = dataGridViewCellStyle2;
            this.名前.FillWeight = 82.40611F;
            this.名前.HeaderText = "名前";
            this.名前.Name = "名前";
            this.名前.ReadOnly = true;
            // 
            // フリガナ
            // 
            this.フリガナ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.フリガナ.DefaultCellStyle = dataGridViewCellStyle3;
            this.フリガナ.FillWeight = 67.9403F;
            this.フリガナ.HeaderText = "フリガナ";
            this.フリガナ.Name = "フリガナ";
            this.フリガナ.ReadOnly = true;
            // 
            // 性別
            // 
            this.性別.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.性別.DefaultCellStyle = dataGridViewCellStyle4;
            this.性別.FillWeight = 35.30485F;
            this.性別.HeaderText = "性別";
            this.性別.Name = "性別";
            this.性別.ReadOnly = true;
            // 
            // 胸囲
            // 
            this.胸囲.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.胸囲.DefaultCellStyle = dataGridViewCellStyle5;
            this.胸囲.FillWeight = 55.01791F;
            this.胸囲.HeaderText = "胸囲(cm)";
            this.胸囲.Name = "胸囲";
            this.胸囲.ReadOnly = true;
            // 
            // 頭囲
            // 
            this.頭囲.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.頭囲.DefaultCellStyle = dataGridViewCellStyle6;
            this.頭囲.FillWeight = 50.1677F;
            this.頭囲.HeaderText = "頭囲(cm)";
            this.頭囲.Name = "頭囲";
            this.頭囲.ReadOnly = true;
            // 
            // 栄養状況
            // 
            this.栄養状況.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.栄養状況.DefaultCellStyle = dataGridViewCellStyle7;
            this.栄養状況.FillWeight = 45.59831F;
            this.栄養状況.HeaderText = "栄養状況";
            this.栄養状況.Name = "栄養状況";
            this.栄養状況.ReadOnly = true;
            // 
            // 身長
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.身長.DefaultCellStyle = dataGridViewCellStyle8;
            this.身長.HeaderText = "身長(cm)";
            this.身長.Name = "身長";
            this.身長.ReadOnly = true;
            // 
            // 体重
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.体重.DefaultCellStyle = dataGridViewCellStyle9;
            this.体重.HeaderText = "体重(kg)";
            this.体重.Name = "体重";
            this.体重.ReadOnly = true;
            // 
            // 測定日
            // 
            this.測定日.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.測定日.DefaultCellStyle = dataGridViewCellStyle10;
            this.測定日.HeaderText = "測定日";
            this.測定日.Name = "測定日";
            this.測定日.ReadOnly = true;
            // 
            // 園児発育チェック一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 586);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_入園年度);
            this.Controls.Add(this.cmb_入園年度);
            this.Controls.Add(this.dgv_園児発育現状);
            this.Controls.Add(this.btn_園児検索);
            this.Name = "園児発育チェック一覧";
            this.Text = "園児発育チェック一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児発育チェック一覧_FormClosed);
            this.Load += new System.EventHandler(this.園児発育チェック一覧_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_園児発育現状)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_園児検索;
        private ComDll.RowMergeView dgv_園児発育現状;
        private System.Windows.Forms.ComboBox cmb_入園年度;
        private System.Windows.Forms.Label lbl_入園年度;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 体重身長入力ToolStripMenuItem;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 発育チェック登録ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名前;
        private System.Windows.Forms.DataGridViewTextBoxColumn フリガナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 胸囲;
        private System.Windows.Forms.DataGridViewTextBoxColumn 頭囲;
        private System.Windows.Forms.DataGridViewTextBoxColumn 栄養状況;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身長;
        private System.Windows.Forms.DataGridViewTextBoxColumn 体重;
        private System.Windows.Forms.DataGridViewTextBoxColumn 測定日;
    }
}