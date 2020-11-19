using ComDll;

namespace 飛鳥SES_人事
{
    partial class 園児保育経過記録
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(園児保育経過記録));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_記録分類 = new System.Windows.Forms.Label();
            this.cmb_記録分類 = new System.Windows.Forms.ComboBox();
            this.lbl_在退園 = new System.Windows.Forms.Label();
            this.cmd_在退園 = new System.Windows.Forms.ComboBox();
            this.lbl_状態 = new System.Windows.Forms.Label();
            this.cmb_アップロード状態 = new System.Windows.Forms.ComboBox();
            this.lbl_入園年度 = new System.Windows.Forms.Label();
            this.dtp_入園年度 = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.sslbl_エラーメッセージ = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.アップロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ダウンロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gridView_保育経過記録一覧 = new ComDll.RowMergeView();
            this.園児 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生年月日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年齢 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.作成日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.更新日時 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.保育経過記録ファイル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_保育経過記録一覧)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_記録分類
            // 
            this.lbl_記録分類.AutoSize = true;
            this.lbl_記録分類.Location = new System.Drawing.Point(28, 21);
            this.lbl_記録分類.Name = "lbl_記録分類";
            this.lbl_記録分類.Size = new System.Drawing.Size(53, 12);
            this.lbl_記録分類.TabIndex = 0;
            this.lbl_記録分類.Text = "記録分類";
            // 
            // cmb_記録分類
            // 
            this.cmb_記録分類.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_記録分類.FormattingEnabled = true;
            this.cmb_記録分類.Items.AddRange(new object[] {
            "0歳",
            "1歳",
            "2歳",
            "3歳"});
            this.cmb_記録分類.Location = new System.Drawing.Point(87, 18);
            this.cmb_記録分類.Name = "cmb_記録分類";
            this.cmb_記録分類.Size = new System.Drawing.Size(66, 20);
            this.cmb_記録分類.TabIndex = 133;
            this.cmb_記録分類.SelectedIndexChanged += new System.EventHandler(this.Cmb_記録年齢_SelectedIndexChanged);
            // 
            // lbl_在退園
            // 
            this.lbl_在退園.AutoSize = true;
            this.lbl_在退園.Location = new System.Drawing.Point(206, 21);
            this.lbl_在退園.Name = "lbl_在退園";
            this.lbl_在退園.Size = new System.Drawing.Size(41, 12);
            this.lbl_在退園.TabIndex = 134;
            this.lbl_在退園.Text = "在退園";
            // 
            // cmd_在退園
            // 
            this.cmd_在退園.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmd_在退園.FormattingEnabled = true;
            this.cmd_在退園.Items.AddRange(new object[] {
            "在園",
            "退園"});
            this.cmd_在退園.Location = new System.Drawing.Point(253, 18);
            this.cmd_在退園.Name = "cmd_在退園";
            this.cmd_在退園.Size = new System.Drawing.Size(66, 20);
            this.cmd_在退園.TabIndex = 149;
            this.cmd_在退園.SelectedIndexChanged += new System.EventHandler(this.Cmd_在退園_SelectedIndexChanged);
            // 
            // lbl_状態
            // 
            this.lbl_状態.AutoSize = true;
            this.lbl_状態.Location = new System.Drawing.Point(380, 21);
            this.lbl_状態.Name = "lbl_状態";
            this.lbl_状態.Size = new System.Drawing.Size(29, 12);
            this.lbl_状態.TabIndex = 150;
            this.lbl_状態.Text = "状態";
            // 
            // cmb_アップロード状態
            // 
            this.cmb_アップロード状態.AutoCompleteCustomSource.AddRange(new string[] {
            " ",
            "アップロード済み",
            "未アップロード"});
            this.cmb_アップロード状態.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_アップロード状態.FormattingEnabled = true;
            this.cmb_アップロード状態.Items.AddRange(new object[] {
            " ",
            "アップロード済み",
            "アップロード未だ"});
            this.cmb_アップロード状態.Location = new System.Drawing.Point(415, 18);
            this.cmb_アップロード状態.Name = "cmb_アップロード状態";
            this.cmb_アップロード状態.Size = new System.Drawing.Size(132, 20);
            this.cmb_アップロード状態.TabIndex = 149;
            this.cmb_アップロード状態.SelectedIndexChanged += new System.EventHandler(this.Cmb_アップロード状態_SelectedIndexChanged);
            // 
            // lbl_入園年度
            // 
            this.lbl_入園年度.AutoSize = true;
            this.lbl_入園年度.Location = new System.Drawing.Point(762, 21);
            this.lbl_入園年度.Name = "lbl_入園年度";
            this.lbl_入園年度.Size = new System.Drawing.Size(53, 12);
            this.lbl_入園年度.TabIndex = 151;
            this.lbl_入園年度.Text = "入園年度";
            // 
            // dtp_入園年度
            // 
            this.dtp_入園年度.CustomFormat = "yyyy年";
            this.dtp_入園年度.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtp_入園年度.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_入園年度.Location = new System.Drawing.Point(822, 14);
            this.dtp_入園年度.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_入園年度.MaxDate = new System.DateTime(2020, 10, 22, 23, 59, 59, 59);
            this.dtp_入園年度.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtp_入園年度.Name = "dtp_入園年度";
            this.dtp_入園年度.ShowUpDown = true;
            this.dtp_入園年度.Size = new System.Drawing.Size(91, 27);
            this.dtp_入園年度.TabIndex = 148;
            this.dtp_入園年度.Value = new System.DateTime(2020, 10, 22, 23, 59, 59, 59);
            this.dtp_入園年度.ValueChanged += new System.EventHandler(this.Dtp_入園年度_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbl_エラーメッセージ});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1344, 22);
            this.statusStrip1.TabIndex = 152;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbl_エラーメッセージ
            // 
            this.sslbl_エラーメッセージ.Name = "sslbl_エラーメッセージ";
            this.sslbl_エラーメッセージ.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アップロードToolStripMenuItem,
            this.ダウンロードToolStripMenuItem,
            this.削除ToolStripMenuItem,
            this.新規ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // アップロードToolStripMenuItem
            // 
            this.アップロードToolStripMenuItem.Name = "アップロードToolStripMenuItem";
            this.アップロードToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.アップロードToolStripMenuItem.Text = "アップロード";
            this.アップロードToolStripMenuItem.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // ダウンロードToolStripMenuItem
            // 
            this.ダウンロードToolStripMenuItem.Name = "ダウンロードToolStripMenuItem";
            this.ダウンロードToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ダウンロードToolStripMenuItem.Text = "ダウンロード";
            this.ダウンロードToolStripMenuItem.Click += new System.EventHandler(this.ダウンロードToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // 新規ToolStripMenuItem
            // 
            this.新規ToolStripMenuItem.Name = "新規ToolStripMenuItem";
            this.新規ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.新規ToolStripMenuItem.Text = "新規";
            this.新規ToolStripMenuItem.Click += new System.EventHandler(this.新規ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gridView_保育経過記録一覧
            // 
            this.gridView_保育経過記録一覧.AllowUserToAddRows = false;
            this.gridView_保育経過記録一覧.AllowUserToDeleteRows = false;
            this.gridView_保育経過記録一覧.AllowUserToResizeRows = false;
            this.gridView_保育経過記録一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_保育経過記録一覧.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_保育経過記録一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_保育経過記録一覧.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.園児,
            this.生年月日,
            this.年齢,
            this.作成日付,
            this.更新日時,
            this.保育経過記録ファイル});
            this.gridView_保育経過記録一覧.ContextMenuStrip = this.contextMenuStrip1;
            this.gridView_保育経過記録一覧.Key = "";
            this.gridView_保育経過記録一覧.Location = new System.Drawing.Point(30, 44);
            this.gridView_保育経過記録一覧.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_保育経過記録一覧.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_保育経過記録一覧.MergeColumnNames")));
            this.gridView_保育経過記録一覧.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_保育経過記録一覧.MergeRowIndex")));
            this.gridView_保育経過記録一覧.Name = "gridView_保育経過記録一覧";
            this.gridView_保育経過記録一覧.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_保育経過記録一覧.NoLink")));
            this.gridView_保育経過記録一覧.ReadOnly = true;
            this.gridView_保育経過記録一覧.RowTemplate.Height = 21;
            this.gridView_保育経過記録一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView_保育経過記録一覧.Size = new System.Drawing.Size(897, 650);
            this.gridView_保育経過記録一覧.TabIndex = 153;
            this.gridView_保育経過記録一覧.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_保育経過記録一覧_CellDoubleClick);
            this.gridView_保育経過記録一覧.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_保育経過記録一覧_CellMouseDown);
            // 
            // 園児
            // 
            this.園児.HeaderText = "園児";
            this.園児.Name = "園児";
            this.園児.ReadOnly = true;
            this.園児.Width = 120;
            // 
            // 生年月日
            // 
            this.生年月日.HeaderText = "生年月日";
            this.生年月日.Name = "生年月日";
            this.生年月日.ReadOnly = true;
            this.生年月日.Width = 80;
            // 
            // 年齢
            // 
            this.年齢.HeaderText = "年齢";
            this.年齢.Name = "年齢";
            this.年齢.ReadOnly = true;
            this.年齢.Width = 40;
            // 
            // 作成日付
            // 
            this.作成日付.HeaderText = "作成日付";
            this.作成日付.Name = "作成日付";
            this.作成日付.ReadOnly = true;
            this.作成日付.Width = 80;
            // 
            // 更新日時
            // 
            this.更新日時.HeaderText = "更新日時";
            this.更新日時.Name = "更新日時";
            this.更新日時.ReadOnly = true;
            this.更新日時.Width = 180;
            // 
            // 保育経過記録ファイル
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.保育経過記録ファイル.DefaultCellStyle = dataGridViewCellStyle2;
            this.保育経過記録ファイル.HeaderText = "保育経過記録ファイル";
            this.保育経過記録ファイル.Name = "保育経過記録ファイル";
            this.保育経過記録ファイル.ReadOnly = true;
            this.保育経過記録ファイル.Width = 340;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "園児";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "生年月日";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "年齢";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "作成日付";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "更新日時";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 280;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "保育経過記録ファイル";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 340;
            // 
            // 園児保育経過記録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.gridView_保育経過記録一覧);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtp_入園年度);
            this.Controls.Add(this.lbl_入園年度);
            this.Controls.Add(this.cmb_アップロード状態);
            this.Controls.Add(this.lbl_状態);
            this.Controls.Add(this.cmd_在退園);
            this.Controls.Add(this.lbl_在退園);
            this.Controls.Add(this.cmb_記録分類);
            this.Controls.Add(this.lbl_記録分類);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "園児保育経過記録";
            this.Text = "園児保育経過記録";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児保育経過記録_FormClosed);
            this.Load += new System.EventHandler(this.園児保育経過記録_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_保育経過記録一覧)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_記録分類;
        private System.Windows.Forms.ComboBox cmb_記録分類;
        private System.Windows.Forms.Label lbl_在退園;
        private System.Windows.Forms.ComboBox cmd_在退園;
        private System.Windows.Forms.Label lbl_状態;
        private System.Windows.Forms.ComboBox cmb_アップロード状態;
        private System.Windows.Forms.Label lbl_入園年度;
        private System.Windows.Forms.DateTimePicker dtp_入園年度;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_エラーメッセージ;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem アップロードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ダウンロードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private RowMergeView gridView_保育経過記録一覧;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStripMenuItem 新規ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生年月日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年齢;
        private System.Windows.Forms.DataGridViewTextBoxColumn 作成日付;
        private System.Windows.Forms.DataGridViewTextBoxColumn 更新日時;
        private System.Windows.Forms.DataGridViewTextBoxColumn 保育経過記録ファイル;
    }
}