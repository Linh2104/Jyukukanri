using ComDll;

namespace 飛鳥SES_人事
{
    partial class 職員検便記録表
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(職員検便記録表));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ダウンロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アップロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmb_状態 = new System.Windows.Forms.ComboBox();
            this.lbl_状態 = new System.Windows.Forms.Label();
            this.dtp_年度 = new System.Windows.Forms.DateTimePicker();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new ComDll.RowMergeView();
            this.職員コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名前 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.検便日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.アップロード日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.定期検便ファイル = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_年度 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(858, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ダウンロードToolStripMenuItem,
            this.アップロードToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 70);
            // 
            // ダウンロードToolStripMenuItem
            // 
            this.ダウンロードToolStripMenuItem.Name = "ダウンロードToolStripMenuItem";
            this.ダウンロードToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ダウンロードToolStripMenuItem.Text = "ダウンロード";
            this.ダウンロードToolStripMenuItem.Click += new System.EventHandler(this.ダウンロードToolStripMenuItem_Click);
            // 
            // アップロードToolStripMenuItem
            // 
            this.アップロードToolStripMenuItem.Name = "アップロードToolStripMenuItem";
            this.アップロードToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.アップロードToolStripMenuItem.Text = "アップロード";
            this.アップロードToolStripMenuItem.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // cmb_状態
            // 
            this.cmb_状態.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_状態.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_状態.FormattingEnabled = true;
            this.cmb_状態.Items.AddRange(new object[] {
            "ALL",
            "アップロード済み",
            "未アップロード"});
            this.cmb_状態.Location = new System.Drawing.Point(277, 22);
            this.cmb_状態.Name = "cmb_状態";
            this.cmb_状態.Size = new System.Drawing.Size(121, 27);
            this.cmb_状態.TabIndex = 1;
            this.cmb_状態.SelectedIndexChanged += new System.EventHandler(this.cmb_状態_SelectedIndexChanged);
            // 
            // lbl_状態
            // 
            this.lbl_状態.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_状態.AutoSize = true;
            this.lbl_状態.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_状態.Location = new System.Drawing.Point(232, 24);
            this.lbl_状態.Name = "lbl_状態";
            this.lbl_状態.Size = new System.Drawing.Size(39, 19);
            this.lbl_状態.TabIndex = 133;
            this.lbl_状態.Text = "状態";
            // 
            // dtp_年度
            // 
            this.dtp_年度.CustomFormat = "yyyy年";
            this.dtp_年度.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtp_年度.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_年度.Location = new System.Drawing.Point(85, 22);
            this.dtp_年度.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_年度.Name = "dtp_年度";
            this.dtp_年度.ShowUpDown = true;
            this.dtp_年度.Size = new System.Drawing.Size(91, 27);
            this.dtp_年度.TabIndex = 0;
            this.dtp_年度.ValueChanged += new System.EventHandler(this.dtp_年度_ValueChanged);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Meiryo", 10.8F);
            this.txt_search.Location = new System.Drawing.Point(484, 22);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(251, 29);
            this.txt_search.TabIndex = 2;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Meiryo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_search.Location = new System.Drawing.Point(741, 22);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(79, 29);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.職員コード,
            this.名前,
            this.検便日付,
            this.アップロード日付,
            this.定期検便ファイル});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Key = "";
            this.dataGridView1.Location = new System.Drawing.Point(43, 71);
            this.dataGridView1.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGridView1.MergeColumnNames")));
            this.dataGridView1.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("dataGridView1.MergeRowIndex")));
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("dataGridView1.NoLink")));
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(777, 305);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // 職員コード
            // 
            this.職員コード.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.職員コード.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.職員コード.DefaultCellStyle = dataGridViewCellStyle2;
            this.職員コード.HeaderText = "職員コード";
            this.職員コード.Name = "職員コード";
            this.職員コード.ReadOnly = true;
            this.職員コード.Width = 81;
            // 
            // 名前
            // 
            this.名前.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.名前.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.名前.DefaultCellStyle = dataGridViewCellStyle3;
            this.名前.FillWeight = 61.54822F;
            this.名前.HeaderText = "名前";
            this.名前.Name = "名前";
            this.名前.ReadOnly = true;
            // 
            // 検便日付
            // 
            this.検便日付.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.検便日付.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.検便日付.DefaultCellStyle = dataGridViewCellStyle4;
            this.検便日付.FillWeight = 61.54822F;
            this.検便日付.HeaderText = "検便日付";
            this.検便日付.MaxInputLength = 10;
            this.検便日付.Name = "検便日付";
            this.検便日付.Width = 78;
            // 
            // アップロード日付
            // 
            this.アップロード日付.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.アップロード日付.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Meiryo UI", 9F);
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.アップロード日付.DefaultCellStyle = dataGridViewCellStyle5;
            this.アップロード日付.FillWeight = 61.54822F;
            this.アップロード日付.HeaderText = "アップロード日付";
            this.アップロード日付.MaxInputLength = 10;
            this.アップロード日付.Name = "アップロード日付";
            this.アップロード日付.ReadOnly = true;
            this.アップロード日付.Width = 110;
            // 
            // 定期検便ファイル
            // 
            this.定期検便ファイル.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.定期検便ファイル.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Meiryo UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            this.定期検便ファイル.DefaultCellStyle = dataGridViewCellStyle6;
            this.定期検便ファイル.FillWeight = 61.54822F;
            this.定期検便ファイル.HeaderText = "定期検便ファイル";
            this.定期検便ファイル.Name = "定期検便ファイル";
            this.定期検便ファイル.ReadOnly = true;
            // 
            // lbl_年度
            // 
            this.lbl_年度.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_年度.AutoSize = true;
            this.lbl_年度.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_年度.Location = new System.Drawing.Point(39, 24);
            this.lbl_年度.Name = "lbl_年度";
            this.lbl_年度.Size = new System.Drawing.Size(39, 19);
            this.lbl_年度.TabIndex = 129;
            this.lbl_年度.Text = "年度";
            // 
            // 職員検便記録表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 399);
            this.Controls.Add(this.cmb_状態);
            this.Controls.Add(this.lbl_状態);
            this.Controls.Add(this.dtp_年度);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_年度);
            this.Controls.Add(this.statusStrip1);
            this.Name = "職員検便記録表";
            this.Text = "職員検便記録表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.職員検便記録表_FormClosed);
            this.Load += new System.EventHandler(this.職員検便記録表_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ダウンロードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アップロードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_状態;
        private System.Windows.Forms.Label lbl_状態;
        private System.Windows.Forms.DateTimePicker dtp_年度;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private RowMergeView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 職員コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名前;
        private System.Windows.Forms.DataGridViewTextBoxColumn 検便日付;
        private System.Windows.Forms.DataGridViewTextBoxColumn アップロード日付;
        private System.Windows.Forms.DataGridViewTextBoxColumn 定期検便ファイル;
        private System.Windows.Forms.Label lbl_年度;
    }
}