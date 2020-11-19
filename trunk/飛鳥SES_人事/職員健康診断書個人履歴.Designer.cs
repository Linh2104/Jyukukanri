namespace 飛鳥SES_人事
{
    partial class 職員健康診断書個人履歴
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(職員健康診断書個人履歴));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Result = new ComDll.RowMergeView();
            this.診断年度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.診断書類別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ファイル名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.アップロード日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeqNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.アップロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.lbl_KenSuu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Msg = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.診断年度,
            this.診断書類別,
            this.ファイル名,
            this.アップロード日付,
            this.SeqNo});
            this.dgv_Result.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_Result.Key = "";
            this.dgv_Result.Location = new System.Drawing.Point(12, 12);
            this.dgv_Result.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Result.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Result.MergeColumnNames")));
            this.dgv_Result.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("dgv_Result.MergeRowIndex")));
            this.dgv_Result.Name = "dgv_Result";
            this.dgv_Result.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("dgv_Result.NoLink")));
            this.dgv_Result.ReadOnly = true;
            this.dgv_Result.RowTemplate.Height = 21;
            this.dgv_Result.Size = new System.Drawing.Size(852, 340);
            this.dgv_Result.TabIndex = 39;
            this.dgv_Result.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Result_CellDoubleClick);
            // 
            // 診断年度
            // 
            this.診断年度.FillWeight = 15F;
            this.診断年度.HeaderText = "診断年度";
            this.診断年度.Name = "診断年度";
            this.診断年度.ReadOnly = true;
            // 
            // 診断書類別
            // 
            this.診断書類別.FillWeight = 15F;
            this.診断書類別.HeaderText = "診断書類別";
            this.診断書類別.Name = "診断書類別";
            this.診断書類別.ReadOnly = true;
            // 
            // ファイル名
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ファイル名.DefaultCellStyle = dataGridViewCellStyle2;
            this.ファイル名.FillWeight = 55F;
            this.ファイル名.HeaderText = "ファイル名";
            this.ファイル名.Name = "ファイル名";
            this.ファイル名.ReadOnly = true;
            // 
            // アップロード日付
            // 
            this.アップロード日付.FillWeight = 15F;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アップロードToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 366);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.TabIndex = 40;
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
            // 職員健康診断書個人履歴
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 388);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgv_Result);
            this.Name = "職員健康診断書個人履歴";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "職員健康診断書個人履歴";
            this.Load += new System.EventHandler(this.職員健康診断書個人履歴_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComDll.RowMergeView dgv_Result;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_KenSuu;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Msg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem アップロードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 診断年度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 診断書類別;
        private System.Windows.Forms.DataGridViewTextBoxColumn ファイル名;
        private System.Windows.Forms.DataGridViewTextBoxColumn アップロード日付;
        private System.Windows.Forms.DataGridViewLinkColumn SeqNo;
    }
}