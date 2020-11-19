using ComDll;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    partial class 出勤機職員一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(出勤機職員一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridView_出勤機職員 = new ComDll.RowMergeView();
            this.出勤機 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登録コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職員コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職員名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職務 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_出勤機職員)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView_出勤機職員
            // 
            this.gridView_出勤機職員.AllowUserToAddRows = false;
            this.gridView_出勤機職員.AllowUserToResizeRows = false;
            this.gridView_出勤機職員.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_出勤機職員.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_出勤機職員.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_出勤機職員.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.出勤機,
            this.登録コード,
            this.職員コード,
            this.職員名,
            this.職務});
            this.gridView_出勤機職員.ContextMenuStrip = this.contextMenuStrip1;
            this.gridView_出勤機職員.Key = "";
            this.gridView_出勤機職員.Location = new System.Drawing.Point(26, 55);
            this.gridView_出勤機職員.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_出勤機職員.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_出勤機職員.MergeColumnNames")));
            this.gridView_出勤機職員.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_出勤機職員.MergeRowIndex")));
            this.gridView_出勤機職員.Name = "gridView_出勤機職員";
            this.gridView_出勤機職員.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_出勤機職員.NoLink")));
            this.gridView_出勤機職員.ReadOnly = true;
            this.gridView_出勤機職員.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gridView_出勤機職員.RowTemplate.Height = 21;
            this.gridView_出勤機職員.Size = new System.Drawing.Size(800, 350);
            this.gridView_出勤機職員.TabIndex = 9;
            // 
            // 出勤機
            // 
            this.出勤機.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.出勤機.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.出勤機.DefaultCellStyle = dataGridViewCellStyle2;
            this.出勤機.HeaderText = "出勤機";
            this.出勤機.Name = "出勤機";
            this.出勤機.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // 登録コード
            // 
            this.登録コード.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.登録コード.DefaultCellStyle = dataGridViewCellStyle3;
            this.登録コード.HeaderText = "登録コード";
            this.登録コード.Name = "登録コード";
            this.登録コード.ReadOnly = true;
            // 
            // 職員コード
            // 
            this.職員コード.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.職員コード.DefaultCellStyle = dataGridViewCellStyle4;
            this.職員コード.HeaderText = "職員コード";
            this.職員コード.Name = "職員コード";
            this.職員コード.ReadOnly = true;
            // 
            // 職員名
            // 
            this.職員名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.職員名.DefaultCellStyle = dataGridViewCellStyle5;
            this.職員名.HeaderText = "職員名";
            this.職員名.Name = "職員名";
            this.職員名.ReadOnly = true;
            // 
            // 職務
            // 
            this.職務.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.職務.DefaultCellStyle = dataGridViewCellStyle6;
            this.職務.HeaderText = "職務";
            this.職務.Name = "職務";
            this.職務.ReadOnly = true;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("メイリオ", 10.8F);
            this.txt_search.Location = new System.Drawing.Point(26, 12);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(159, 29);
            this.txt_search.TabIndex = 91;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(201, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 29);
            this.btn_search.TabIndex = 92;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(854, 22);
            this.statusStrip1.TabIndex = 123;
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
            // 出勤機職員一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.gridView_出勤機職員);
            this.Name = "出勤機職員一覧";
            this.Text = "出勤機職員一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.出勤機職員一覧_FormClosed);
            this.Load += new System.EventHandler(this.出勤機職員一覧_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_出勤機職員)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RowMergeView  gridView_出勤機職員;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private DataGridViewTextBoxColumn 出勤機;
        private DataGridViewTextBoxColumn 登録コード;
        private DataGridViewTextBoxColumn 職員コード;
        private DataGridViewTextBoxColumn 職員名;
        private DataGridViewTextBoxColumn 職務;
    }
}