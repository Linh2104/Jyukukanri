namespace 飛鳥SES_人事
{
    partial class 日誌一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(日誌一覧));
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.lbl_KenSuu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtp_DateTo = new System.Windows.Forms.DateTimePicker();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Output = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_kara = new System.Windows.Forms.Label();
            this.dtp_DateFrom = new System.Windows.Forms.DateTimePicker();
            this.SeqNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.記録 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年齢 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.園児名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Result = new ComDll.RowMergeView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_KenSuu,
            this.lbl_Msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1172, 22);
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
            // dtp_DateTo
            // 
            this.dtp_DateTo.CalendarFont = new System.Drawing.Font("Meiryo UI", 11.25F);
            this.dtp_DateTo.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.dtp_DateTo.Location = new System.Drawing.Point(195, 12);
            this.dtp_DateTo.Name = "dtp_DateTo";
            this.dtp_DateTo.Size = new System.Drawing.Size(153, 26);
            this.dtp_DateTo.TabIndex = 1;
            this.dtp_DateTo.ValueChanged += new System.EventHandler(this.dtp_Date_ValueChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Search.Location = new System.Drawing.Point(571, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(113, 27);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "検索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_Search.Location = new System.Drawing.Point(354, 12);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(211, 26);
            this.txt_Search.TabIndex = 2;
            this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Search_KeyDown);
            // 
            // btn_Output
            // 
            this.btn_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Output.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Output.Location = new System.Drawing.Point(1024, 11);
            this.btn_Output.Name = "btn_Output";
            this.btn_Output.Size = new System.Drawing.Size(136, 27);
            this.btn_Output.TabIndex = 4;
            this.btn_Output.Text = "EXCEL出力";
            this.btn_Output.UseVisualStyleBackColor = true;
            this.btn_Output.Click += new System.EventHandler(this.btn_Output_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "園児名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "記録";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "備考";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "日付";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn5.HeaderText = "年齢";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // lbl_kara
            // 
            this.lbl_kara.AutoSize = true;
            this.lbl_kara.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.lbl_kara.Location = new System.Drawing.Point(169, 13);
            this.lbl_kara.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_kara.Name = "lbl_kara";
            this.lbl_kara.Size = new System.Drawing.Size(22, 23);
            this.lbl_kara.TabIndex = 42;
            this.lbl_kara.Text = "~";
            // 
            // dtp_DateFrom
            // 
            this.dtp_DateFrom.CalendarFont = new System.Drawing.Font("Meiryo UI", 11.25F);
            this.dtp_DateFrom.Font = new System.Drawing.Font("Meiryo UI", 10.8F);
            this.dtp_DateFrom.Location = new System.Drawing.Point(12, 12);
            this.dtp_DateFrom.Name = "dtp_DateFrom";
            this.dtp_DateFrom.Size = new System.Drawing.Size(153, 26);
            this.dtp_DateFrom.TabIndex = 0;
            this.dtp_DateFrom.ValueChanged += new System.EventHandler(this.dtp_Date_ValueChanged);
            // 
            // SeqNo
            // 
            this.SeqNo.HeaderText = "SeqNo";
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.ReadOnly = true;
            this.SeqNo.Visible = false;
            // 
            // 備考
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.備考.DefaultCellStyle = dataGridViewCellStyle6;
            this.備考.FillWeight = 30F;
            this.備考.HeaderText = "備考";
            this.備考.Name = "備考";
            // 
            // 記録
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.記録.DefaultCellStyle = dataGridViewCellStyle7;
            this.記録.FillWeight = 40F;
            this.記録.HeaderText = "記録";
            this.記録.Name = "記録";
            // 
            // 日付
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.日付.DefaultCellStyle = dataGridViewCellStyle8;
            this.日付.FillWeight = 10F;
            this.日付.HeaderText = "日付";
            this.日付.Name = "日付";
            this.日付.ReadOnly = true;
            // 
            // 年齢
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.年齢.DefaultCellStyle = dataGridViewCellStyle9;
            this.年齢.FillWeight = 10F;
            this.年齢.HeaderText = "年齢";
            this.年齢.Name = "年齢";
            this.年齢.ReadOnly = true;
            // 
            // 園児名
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.園児名.DefaultCellStyle = dataGridViewCellStyle10;
            this.園児名.FillWeight = 10F;
            this.園児名.HeaderText = "園児名";
            this.園児名.Name = "園児名";
            this.園児名.ReadOnly = true;
            // 
            // dgv_Result
            // 
            this.dgv_Result.AllowUserToAddRows = false;
            this.dgv_Result.AllowUserToResizeRows = false;
            this.dgv_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.園児名,
            this.年齢,
            this.日付,
            this.記録,
            this.備考,
            this.SeqNo});
            this.dgv_Result.Key = "";
            this.dgv_Result.Location = new System.Drawing.Point(12, 44);
            this.dgv_Result.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Result.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Result.MergeColumnNames")));
            this.dgv_Result.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("dgv_Result.MergeRowIndex")));
            this.dgv_Result.Name = "dgv_Result";
            this.dgv_Result.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("dgv_Result.NoLink")));
            this.dgv_Result.RowTemplate.Height = 21;
            this.dgv_Result.Size = new System.Drawing.Size(1148, 496);
            this.dgv_Result.TabIndex = 5;
            this.dgv_Result.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_Result_CellBeginEdit);
            this.dgv_Result.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Result_CellValueChanged);
            // 
            // 日誌一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 574);
            this.Controls.Add(this.dtp_DateFrom);
            this.Controls.Add(this.lbl_kara);
            this.Controls.Add(this.btn_Output);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.dtp_DateTo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgv_Result);
            this.Name = "日誌一覧";
            this.Text = "日誌一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.日誌一覧_FormClosed);
            this.Load += new System.EventHandler(this.日誌一覧_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_KenSuu;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Msg;
        private System.Windows.Forms.DateTimePicker dtp_DateTo;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lbl_kara;
        private System.Windows.Forms.DateTimePicker dtp_DateFrom;
        private System.Windows.Forms.DataGridViewLinkColumn SeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
        private System.Windows.Forms.DataGridViewTextBoxColumn 記録;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日付;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年齢;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児名;
        private ComDll.RowMergeView dgv_Result;
    }
}