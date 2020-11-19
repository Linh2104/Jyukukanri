namespace 飛鳥SES_人事
{
    partial class 職員健康診断書一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(職員健康診断書一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_RuiBetsu = new System.Windows.Forms.ComboBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.過去履歴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アップロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.lbl_KenSuu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_Result = new ComDll.RowMergeView();
            this.dtp_Year = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職員コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職員氏名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.在職状態 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.診断年度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.診断書類別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ファイル名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.アップロード日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeqNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.退職日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_RuiBetsu
            // 
            this.cmb_RuiBetsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RuiBetsu.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_RuiBetsu.FormattingEnabled = true;
            this.cmb_RuiBetsu.Items.AddRange(new object[] {
            "定期診断",
            "入園前診断"});
            this.cmb_RuiBetsu.Location = new System.Drawing.Point(108, 12);
            this.cmb_RuiBetsu.Name = "cmb_RuiBetsu";
            this.cmb_RuiBetsu.Size = new System.Drawing.Size(150, 27);
            this.cmb_RuiBetsu.TabIndex = 1;
            this.cmb_RuiBetsu.SelectedIndexChanged += new System.EventHandler(this.cmb_RuiBetsu_SelectedIndexChanged);
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_Search.Location = new System.Drawing.Point(264, 12);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(211, 26);
            this.txt_Search.TabIndex = 2;
            this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Search.Location = new System.Drawing.Point(481, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(113, 27);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "検索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.過去履歴ToolStripMenuItem,
            this.アップロードToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 過去履歴ToolStripMenuItem
            // 
            this.過去履歴ToolStripMenuItem.Name = "過去履歴ToolStripMenuItem";
            this.過去履歴ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.過去履歴ToolStripMenuItem.Text = "過去履歴";
            this.過去履歴ToolStripMenuItem.Click += new System.EventHandler(this.過去履歴ToolStripMenuItem_Click);
            // 
            // アップロードToolStripMenuItem
            // 
            this.アップロードToolStripMenuItem.Name = "アップロードToolStripMenuItem";
            this.アップロードToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.アップロードToolStripMenuItem.Text = "アップロード";
            this.アップロードToolStripMenuItem.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_KenSuu,
            this.lbl_Msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1106, 22);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_KenSuu
            // 
            this.lbl_KenSuu.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_KenSuu.Name = "lbl_KenSuu";
            this.lbl_KenSuu.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(0, 17);
            // 
            // dgv_Result
            // 
            this.dgv_Result.AllowUserToAddRows = false;
            this.dgv_Result.AllowUserToResizeRows = false;
            this.dgv_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.職員コード,
            this.職員氏名,
            this.在職状態,
            this.診断年度,
            this.診断書類別,
            this.ファイル名,
            this.アップロード日付,
            this.SeqNo,
            this.退職日});
            this.dgv_Result.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_Result.Key = "";
            this.dgv_Result.Location = new System.Drawing.Point(12, 45);
            this.dgv_Result.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Result.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Result.MergeColumnNames")));
            this.dgv_Result.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("dgv_Result.MergeRowIndex")));
            this.dgv_Result.Name = "dgv_Result";
            this.dgv_Result.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("dgv_Result.NoLink")));
            this.dgv_Result.ReadOnly = true;
            this.dgv_Result.RowTemplate.Height = 21;
            this.dgv_Result.Size = new System.Drawing.Size(1082, 440);
            this.dgv_Result.TabIndex = 38;
            this.dgv_Result.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Result_CellDoubleClick);
            // 
            // dtp_Year
            // 
            this.dtp_Year.CustomFormat = "yyyy年";
            this.dtp_Year.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtp_Year.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Year.Location = new System.Drawing.Point(12, 12);
            this.dtp_Year.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_Year.Name = "dtp_Year";
            this.dtp_Year.ShowUpDown = true;
            this.dtp_Year.Size = new System.Drawing.Size(89, 27);
            this.dtp_Year.TabIndex = 0;
            this.dtp_Year.ValueChanged += new System.EventHandler(this.dtp_Year_ValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 304.5686F;
            this.dataGridViewTextBoxColumn1.HeaderText = "職員コード";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 59.08628F;
            this.dataGridViewTextBoxColumn2.HeaderText = "職員氏名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 59.08628F;
            this.dataGridViewTextBoxColumn3.HeaderText = "診断年度";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 59.08628F;
            this.dataGridViewTextBoxColumn4.HeaderText = "診断書類別";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.FillWeight = 59.08628F;
            this.dataGridViewTextBoxColumn5.HeaderText = "ファイル名";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 76;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 59.08628F;
            this.dataGridViewTextBoxColumn6.HeaderText = "アップロード日時";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 107;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.FillWeight = 59.08628F;
            this.dataGridViewTextBoxColumn7.HeaderText = "SeqNo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 148;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "SeqNo";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // 職員コード
            // 
            this.職員コード.FillWeight = 9.956155F;
            this.職員コード.HeaderText = "職員コード";
            this.職員コード.Name = "職員コード";
            this.職員コード.ReadOnly = true;
            // 
            // 職員氏名
            // 
            this.職員氏名.FillWeight = 9.956155F;
            this.職員氏名.HeaderText = "職員氏名";
            this.職員氏名.Name = "職員氏名";
            this.職員氏名.ReadOnly = true;
            // 
            // 在職状態
            // 
            this.在職状態.FillWeight = 9.956155F;
            this.在職状態.HeaderText = "在職状態";
            this.在職状態.Name = "在職状態";
            this.在職状態.ReadOnly = true;
            // 
            // 診断年度
            // 
            this.診断年度.FillWeight = 9.956155F;
            this.診断年度.HeaderText = "診断年度";
            this.診断年度.Name = "診断年度";
            this.診断年度.ReadOnly = true;
            // 
            // 診断書類別
            // 
            this.診断書類別.FillWeight = 9.956155F;
            this.診断書類別.HeaderText = "診断書類別";
            this.診断書類別.Name = "診断書類別";
            this.診断書類別.ReadOnly = true;
            // 
            // ファイル名
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ファイル名.DefaultCellStyle = dataGridViewCellStyle2;
            this.ファイル名.FillWeight = 39.82462F;
            this.ファイル名.HeaderText = "ファイル名";
            this.ファイル名.Name = "ファイル名";
            this.ファイル名.ReadOnly = true;
            // 
            // アップロード日付
            // 
            this.アップロード日付.FillWeight = 10.39461F;
            this.アップロード日付.HeaderText = "アップロード日付";
            this.アップロード日付.Name = "アップロード日付";
            this.アップロード日付.ReadOnly = true;
            // 
            // SeqNo
            // 
            this.SeqNo.HeaderText = "SeqNo";
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.ReadOnly = true;
            this.SeqNo.Visible = false;
            // 
            // 退職日
            // 
            this.退職日.HeaderText = "退職日";
            this.退職日.Name = "退職日";
            this.退職日.ReadOnly = true;
            this.退職日.Visible = false;
            // 
            // 職員健康診断書一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 524);
            this.Controls.Add(this.dtp_Year);
            this.Controls.Add(this.dgv_Result);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.cmb_RuiBetsu);
            this.Name = "職員健康診断書一覧";
            this.Text = "職員健康診断書一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.職員健康診断書一覧_FormClosed);
            this.Load += new System.EventHandler(this.職員健康診断書一覧_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_RuiBetsu;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 過去履歴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アップロードToolStripMenuItem;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_KenSuu;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Msg;
        private ComDll.RowMergeView dgv_Result;
        private System.Windows.Forms.DateTimePicker dtp_Year;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 職員コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 職員氏名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 在職状態;
        private System.Windows.Forms.DataGridViewTextBoxColumn 診断年度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 診断書類別;
        private System.Windows.Forms.DataGridViewTextBoxColumn ファイル名;
        private System.Windows.Forms.DataGridViewTextBoxColumn アップロード日付;
        private System.Windows.Forms.DataGridViewLinkColumn SeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn 退職日;
    }
}