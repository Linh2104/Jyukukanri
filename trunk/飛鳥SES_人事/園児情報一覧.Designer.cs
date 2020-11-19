using ComDll;
namespace 飛鳥SES_人事
{
    partial class 園児情報一覧
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(園児情報一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.cmb_gridview = new System.Windows.Forms.ComboBox();
            this.DateGV = new ComDll.RowMergeView();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.印刷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アップロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ダウンロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アップロードToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退園キャンセルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退園ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DateGV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Meiryo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(520, 15);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 30);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_search.Font = new System.Drawing.Font("Meiryo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(250, 15);
            this.txt_search.MaxLength = 200;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(250, 30);
            this.txt_search.TabIndex = 1;
            // 
            // cmb_gridview
            // 
            this.cmb_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmb_gridview.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_gridview.Font = new System.Drawing.Font("Meiryo", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_gridview.FormattingEnabled = true;
            this.cmb_gridview.ItemHeight = 21;
            this.cmb_gridview.Items.AddRange(new object[] {
            "園児情報一覧",
            "園児緊急連絡先",
            "園児健康情報",
            "園児入園書類",
            "園児退園書類"});
            this.cmb_gridview.Location = new System.Drawing.Point(20, 15);
            this.cmb_gridview.Name = "cmb_gridview";
            this.cmb_gridview.Size = new System.Drawing.Size(186, 29);
            this.cmb_gridview.TabIndex = 0;
            this.cmb_gridview.SelectedIndexChanged += new System.EventHandler(this.cmb_gridview_SelectedIndexChanged);
            // 
            // DateGV
            // 
            this.DateGV.AllowUserToAddRows = false;
            this.DateGV.AllowUserToResizeRows = false;
            this.DateGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DateGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DateGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DateGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.DateGV.Key = "";
            this.DateGV.Location = new System.Drawing.Point(20, 50);
            this.DateGV.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.DateGV.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("DateGV.MergeColumnNames")));
            this.DateGV.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("DateGV.MergeRowIndex")));
            this.DateGV.Name = "DateGV";
            this.DateGV.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("DateGV.NoLink")));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DateGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DateGV.RowHeadersWidth = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue;
            this.DateGV.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DateGV.RowTemplate.Height = 21;
            this.DateGV.Size = new System.Drawing.Size(649, 375);
            this.DateGV.TabIndex = 0;
            this.DateGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.DateGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.DateGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.DateGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.DateGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.DateGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Meiryo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.印刷ToolStripMenuItem,
            this.アップロードToolStripMenuItem,
            this.ダウンロードToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // 印刷ToolStripMenuItem
            // 
            this.印刷ToolStripMenuItem.Name = "印刷ToolStripMenuItem";
            this.印刷ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.印刷ToolStripMenuItem.Text = "印刷";
            this.印刷ToolStripMenuItem.Click += new System.EventHandler(this.印刷ToolStripMenuItem_Click);
            // 
            // アップロードToolStripMenuItem
            // 
            this.アップロードToolStripMenuItem.Name = "アップロードToolStripMenuItem";
            this.アップロードToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.アップロードToolStripMenuItem.Text = "アップロード";
            this.アップロードToolStripMenuItem.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // ダウンロードToolStripMenuItem
            // 
            this.ダウンロードToolStripMenuItem.Name = "ダウンロードToolStripMenuItem";
            this.ダウンロードToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ダウンロードToolStripMenuItem.Text = "ダウンロード";
            this.ダウンロードToolStripMenuItem.Click += new System.EventHandler(this.ダウンロードToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.変更ToolStripMenuItem,
            this.アップロードToolStripMenuItem1,
            this.退園キャンセルToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(145, 70);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // 変更ToolStripMenuItem
            // 
            this.変更ToolStripMenuItem.Name = "変更ToolStripMenuItem";
            this.変更ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.変更ToolStripMenuItem.Text = "変更";
            this.変更ToolStripMenuItem.Click += new System.EventHandler(this.変更ToolStripMenuItem_Click);
            // 
            // アップロードToolStripMenuItem1
            // 
            this.アップロードToolStripMenuItem1.Name = "アップロードToolStripMenuItem1";
            this.アップロードToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.アップロードToolStripMenuItem1.Text = "アップロード";
            this.アップロードToolStripMenuItem1.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // 退園キャンセルToolStripMenuItem
            // 
            this.退園キャンセルToolStripMenuItem.Name = "退園キャンセルToolStripMenuItem";
            this.退園キャンセルToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.退園キャンセルToolStripMenuItem.Text = "退園キャンセル";
            this.退園キャンセルToolStripMenuItem.Click += new System.EventHandler(this.退園キャンセルToolStripMenuItem_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退園ToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(181, 48);
            this.contextMenuStrip3.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // 退園ToolStripMenuItem
            // 
            this.退園ToolStripMenuItem.Name = "退園ToolStripMenuItem";
            this.退園ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.退園ToolStripMenuItem.Text = "退園";
            this.退園ToolStripMenuItem.Click += new System.EventHandler(this.変更ToolStripMenuItem_Click);
            // 
            // 園児情報一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 461);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.DateGV);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.cmb_gridview);
            this.Controls.Add(this.statusStrip1);
            this.Name = "園児情報一覧";
            this.Text = "園児情報一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児情報一覧_FormClosed);
            this.Load += new System.EventHandler(this.園児情報一覧_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private System.Windows.Forms.StatusStrip statusStrip1;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.ComboBox cmb_gridview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 印刷ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アップロードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ダウンロードToolStripMenuItem;
        public RowMergeView DateGV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アップロードToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退園キャンセルToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 退園ToolStripMenuItem;
    }
}