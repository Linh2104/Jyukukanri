using ComDll;
using System;

namespace 飛鳥SES_人事
{
    partial class 出勤表エラー記録
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(出勤表エラー記録));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_date = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.btn_NewAddition = new System.Windows.Forms.Button();
            this.btn_FixTheError = new System.Windows.Forms.Button();
            this.cmb_Employee = new System.Windows.Forms.ComboBox();
            this.lbl_Employee = new System.Windows.Forms.Label();
            this.gridView_ErrorList = new ComDll.RowMergeView();
            this.社員コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出勤機コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.登録コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出退勤フラグ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.出退勤時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.元日時 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewRowフラグ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslbl_エラーメッセージ = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ErrorList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_date.Location = new System.Drawing.Point(17, 16);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(40, 23);
            this.lbl_date.TabIndex = 126;
            this.lbl_date.Text = "日付";
            // 
            // dtp_date
            // 
            this.dtp_date.CalendarFont = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.dtp_date.CustomFormat = "yyyy 年 MM 月";
            this.dtp_date.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(63, 14);
            this.dtp_date.MaxDate = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 59);
            this.dtp_date.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.ShowUpDown = true;
            this.dtp_date.Size = new System.Drawing.Size(166, 28);
            this.dtp_date.TabIndex = 133;
            this.dtp_date.Value = new System.DateTime(2020, 9, 28, 0, 0, 0, 0);
            this.dtp_date.ValueChanged += new System.EventHandler(this.dateTimePicker01_ValueChanged);
            // 
            // btn_NewAddition
            // 
            this.btn_NewAddition.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_NewAddition.Location = new System.Drawing.Point(765, 14);
            this.btn_NewAddition.Name = "btn_NewAddition";
            this.btn_NewAddition.Size = new System.Drawing.Size(241, 29);
            this.btn_NewAddition.TabIndex = 140;
            this.btn_NewAddition.Text = "出勤記録を新規追加する";
            this.btn_NewAddition.UseVisualStyleBackColor = true;
            this.btn_NewAddition.Click += new System.EventHandler(this.btn_NewAddition_Click);
            // 
            // btn_FixTheError
            // 
            this.btn_FixTheError.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_FixTheError.Location = new System.Drawing.Point(563, 14);
            this.btn_FixTheError.Name = "btn_FixTheError";
            this.btn_FixTheError.Size = new System.Drawing.Size(165, 29);
            this.btn_FixTheError.TabIndex = 139;
            this.btn_FixTheError.Text = "エラーを修正する";
            this.btn_FixTheError.UseVisualStyleBackColor = true;
            this.btn_FixTheError.Click += new System.EventHandler(this.btn_FixTheError_Click);
            // 
            // cmb_Employee
            // 
            this.cmb_Employee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Employee.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_Employee.FormattingEnabled = true;
            this.cmb_Employee.Items.AddRange(new object[] {
            "ALL"});
            this.cmb_Employee.Location = new System.Drawing.Point(321, 14);
            this.cmb_Employee.Name = "cmb_Employee";
            this.cmb_Employee.Size = new System.Drawing.Size(205, 29);
            this.cmb_Employee.TabIndex = 138;
            this.cmb_Employee.SelectedIndexChanged += new System.EventHandler(this.cmb_Employee_SelectedIndexChanged);
            // 
            // lbl_Employee
            // 
            this.lbl_Employee.AutoSize = true;
            this.lbl_Employee.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Employee.Location = new System.Drawing.Point(253, 16);
            this.lbl_Employee.Name = "lbl_Employee";
            this.lbl_Employee.Size = new System.Drawing.Size(40, 23);
            this.lbl_Employee.TabIndex = 137;
            this.lbl_Employee.Text = "職員";
            // 
            // gridView_ErrorList
            // 
            this.gridView_ErrorList.AllowUserToAddRows = false;
            this.gridView_ErrorList.AllowUserToResizeRows = false;
            this.gridView_ErrorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_ErrorList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_ErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_ErrorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.社員コード,
            this.出勤機コード,
            this.登録コード,
            this.出退勤フラグ,
            this.出退勤時間,
            this.元日時,
            this.NewRowフラグ});
            this.gridView_ErrorList.ContextMenuStrip = this.contextMenuStrip1;
            this.gridView_ErrorList.Key = "";
            this.gridView_ErrorList.Location = new System.Drawing.Point(21, 61);
            this.gridView_ErrorList.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_ErrorList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_ErrorList.MergeColumnNames")));
            this.gridView_ErrorList.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_ErrorList.MergeRowIndex")));
            this.gridView_ErrorList.Name = "gridView_ErrorList";
            this.gridView_ErrorList.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_ErrorList.NoLink")));
            this.gridView_ErrorList.RowTemplate.Height = 21;
            this.gridView_ErrorList.Size = new System.Drawing.Size(985, 449);
            this.gridView_ErrorList.TabIndex = 141;
            this.gridView_ErrorList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridView_ErrorList_CellBeginEdit);
            this.gridView_ErrorList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_ErrorList_CellEndEdit);
            this.gridView_ErrorList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridView_ErrorList_CellMouseDown);
            this.gridView_ErrorList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_ErrorList_CellValueChanged);
            // 
            // 社員コード
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.社員コード.DefaultCellStyle = dataGridViewCellStyle2;
            this.社員コード.HeaderText = "職員";
            this.社員コード.MaxInputLength = 500;
            this.社員コード.Name = "社員コード";
            this.社員コード.ReadOnly = true;
            this.社員コード.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.社員コード.Width = 149;
            // 
            // 出勤機コード
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.出勤機コード.DefaultCellStyle = dataGridViewCellStyle3;
            this.出勤機コード.HeaderText = "出勤機コード";
            this.出勤機コード.MaxInputLength = 100;
            this.出勤機コード.Name = "出勤機コード";
            this.出勤機コード.ReadOnly = true;
            this.出勤機コード.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.出勤機コード.Width = 114;
            // 
            // 登録コード
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.登録コード.DefaultCellStyle = dataGridViewCellStyle4;
            this.登録コード.HeaderText = "登録コード";
            this.登録コード.MaxInputLength = 100;
            this.登録コード.Name = "登録コード";
            this.登録コード.ReadOnly = true;
            this.登録コード.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.登録コード.Width = 99;
            // 
            // 出退勤フラグ
            // 
            this.出退勤フラグ.HeaderText = "出☑退□勤フラグ";
            this.出退勤フラグ.Name = "出退勤フラグ";
            this.出退勤フラグ.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.出退勤フラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.出退勤フラグ.Width = 120;
            // 
            // 出退勤時間
            // 
            this.出退勤時間.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.Format = "d";
            this.出退勤時間.DefaultCellStyle = dataGridViewCellStyle5;
            this.出退勤時間.HeaderText = "出退勤時間";
            this.出退勤時間.MaxInputLength = 19;
            this.出退勤時間.Name = "出退勤時間";
            this.出退勤時間.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // 元日時
            // 
            this.元日時.FillWeight = 1F;
            this.元日時.HeaderText = "元日時";
            this.元日時.Name = "元日時";
            this.元日時.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.元日時.Visible = false;
            this.元日時.Width = 48;
            // 
            // NewRowフラグ
            // 
            this.NewRowフラグ.FillWeight = 1F;
            this.NewRowフラグ.HeaderText = "NewRowフラグ";
            this.NewRowフラグ.Name = "NewRowフラグ";
            this.NewRowフラグ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NewRowフラグ.Visible = false;
            this.NewRowフラグ.Width = 78;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.追加ToolStripMenuItem.Text = "コピー・追加";
            this.追加ToolStripMenuItem.Click += new System.EventHandler(this.追加ToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbl_エラーメッセージ});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1035, 22);
            this.statusStrip1.TabIndex = 142;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbl_エラーメッセージ
            // 
            this.sslbl_エラーメッセージ.Name = "sslbl_エラーメッセージ";
            this.sslbl_エラーメッセージ.Size = new System.Drawing.Size(0, 17);
            // 
            // 出勤表エラー記録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 551);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gridView_ErrorList);
            this.Controls.Add(this.btn_NewAddition);
            this.Controls.Add(this.btn_FixTheError);
            this.Controls.Add(this.cmb_Employee);
            this.Controls.Add(this.lbl_Employee);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.lbl_date);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "出勤表エラー記録";
            this.Text = "出勤表エラー記録";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.出勤表エラー記録_FormClosed);
            this.Load += new System.EventHandler(this.出勤表エラー記録_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ErrorList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Button btn_NewAddition;
        private System.Windows.Forms.Button btn_FixTheError;
        public System.Windows.Forms.ComboBox cmb_Employee;
        private System.Windows.Forms.Label lbl_Employee;
        public RowMergeView gridView_ErrorList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_エラーメッセージ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 社員コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出勤機コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 登録コード;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 出退勤フラグ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出退勤時間;
        private System.Windows.Forms.DataGridViewTextBoxColumn 元日時;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NewRowフラグ;
    }
}