using ComDll;

namespace 飛鳥SES_人事
{
    partial class 園児健康診断
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(園児健康診断));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_健康診断 = new ComDll.RowMergeView();
            this.園児名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.園児コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.日付 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.室温 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.食事内容状況 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.体温 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.検温時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.チェック項目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.健康状況 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.排便 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.回数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_全て表示 = new System.Windows.Forms.Button();
            this.btn_隠す = new System.Windows.Forms.Button();
            this.btn_regist = new System.Windows.Forms.Button();
            this.dtp_日付 = new System.Windows.Forms.DateTimePicker();
            this.btn_output = new System.Windows.Forms.Button();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_健康診断)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_健康診断
            // 
            this.dataGridView_健康診断.AllowUserToAddRows = false;
            this.dataGridView_健康診断.AllowUserToResizeRows = false;
            this.dataGridView_健康診断.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_健康診断.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_健康診断.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_健康診断.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.園児名,
            this.園児コード,
            this.日付,
            this.室温,
            this.食事内容状況,
            this.体温,
            this.検温時間,
            this.チェック項目,
            this.健康状況,
            this.排便,
            this.回数,
            this.GroupCode,
            this.CName,
            this.行番号,
            this.id});
            this.dataGridView_健康診断.Key = "";
            this.dataGridView_健康診断.Location = new System.Drawing.Point(12, 121);
            this.dataGridView_健康診断.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_健康診断.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGridView_健康診断.MergeColumnNames")));
            this.dataGridView_健康診断.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("dataGridView_健康診断.MergeRowIndex")));
            this.dataGridView_健康診断.Name = "dataGridView_健康診断";
            this.dataGridView_健康診断.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("dataGridView_健康診断.NoLink")));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_健康診断.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_健康診断.RowHeadersWidth = 60;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView_健康診断.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_健康診断.RowTemplate.Height = 21;
            this.dataGridView_健康診断.Size = new System.Drawing.Size(1204, 514);
            this.dataGridView_健康診断.TabIndex = 0;
            this.dataGridView_健康診断.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_児童健康状況一覧_CellBeginEdit);
            this.dataGridView_健康診断.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridView_児童健康状況一覧_CellPainting);
            this.dataGridView_健康診断.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_児童健康状況一覧_CellValueChanged);
            this.dataGridView_健康診断.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_児童健康状況一覧_RowHeaderMouseClick);
            // 
            // 園児名
            // 
            this.園児名.ContextMenuStrip = this.contextMenuStrip1;
            this.園児名.HeaderText = "園児名";
            this.園児名.Name = "園児名";
            this.園児名.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.園児名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.変更ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // 変更ToolStripMenuItem
            // 
            this.変更ToolStripMenuItem.Name = "変更ToolStripMenuItem";
            this.変更ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.変更ToolStripMenuItem.Text = "変更";
            this.変更ToolStripMenuItem.Click += new System.EventHandler(this.変更ToolStripMenuItem_Click);
            // 
            // 園児コード
            // 
            this.園児コード.ContextMenuStrip = this.contextMenuStrip1;
            this.園児コード.HeaderText = "園児コード";
            this.園児コード.Name = "園児コード";
            this.園児コード.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 日付
            // 
            this.日付.ContextMenuStrip = this.contextMenuStrip1;
            this.日付.HeaderText = "日付";
            this.日付.Name = "日付";
            this.日付.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 室温
            // 
            this.室温.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Format = "E1";
            dataGridViewCellStyle2.NullValue = null;
            this.室温.DefaultCellStyle = dataGridViewCellStyle2;
            this.室温.HeaderText = "室温(℃)";
            this.室温.MaxInputLength = 5;
            this.室温.Name = "室温";
            this.室温.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 食事内容状況
            // 
            this.食事内容状況.ContextMenuStrip = this.contextMenuStrip1;
            this.食事内容状況.HeaderText = "食事内容状況";
            this.食事内容状況.Name = "食事内容状況";
            this.食事内容状況.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.食事内容状況.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 体温
            // 
            this.体温.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.体温.DefaultCellStyle = dataGridViewCellStyle3;
            this.体温.HeaderText = "体温(℃)";
            this.体温.MaxInputLength = 4;
            this.体温.Name = "体温";
            this.体温.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.体温.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 検温時間
            // 
            this.検温時間.ContextMenuStrip = this.contextMenuStrip1;
            this.検温時間.HeaderText = "検温時間";
            this.検温時間.Name = "検温時間";
            this.検温時間.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // チェック項目
            // 
            this.チェック項目.ContextMenuStrip = this.contextMenuStrip1;
            this.チェック項目.HeaderText = "チェック項目";
            this.チェック項目.Name = "チェック項目";
            this.チェック項目.ReadOnly = true;
            this.チェック項目.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 健康状況
            // 
            this.健康状況.ContextMenuStrip = this.contextMenuStrip1;
            this.健康状況.DataPropertyName = "健康状況";
            this.健康状況.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.健康状況.HeaderText = "健康状況";
            this.健康状況.Name = "健康状況";
            this.健康状況.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 排便
            // 
            this.排便.ContextMenuStrip = this.contextMenuStrip1;
            this.排便.HeaderText = "排便";
            this.排便.Name = "排便";
            this.排便.ReadOnly = true;
            this.排便.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.排便.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 回数
            // 
            this.回数.ContextMenuStrip = this.contextMenuStrip1;
            this.回数.HeaderText = "回数";
            this.回数.MaxInputLength = 2;
            this.回数.Name = "回数";
            this.回数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GroupCode
            // 
            this.GroupCode.HeaderText = "GroupCode";
            this.GroupCode.Name = "GroupCode";
            this.GroupCode.Visible = false;
            // 
            // CName
            // 
            this.CName.HeaderText = "Name";
            this.CName.Name = "CName";
            this.CName.Visible = false;
            // 
            // 行番号
            // 
            this.行番号.HeaderText = "行番号";
            this.行番号.Name = "行番号";
            this.行番号.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("メイリオ", 10.8F);
            this.txt_search.Location = new System.Drawing.Point(25, 34);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(159, 29);
            this.txt_search.TabIndex = 92;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(219, 34);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 29);
            this.btn_search.TabIndex = 93;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // btn_全て表示
            // 
            this.btn_全て表示.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_全て表示.Location = new System.Drawing.Point(25, 74);
            this.btn_全て表示.Name = "btn_全て表示";
            this.btn_全て表示.Size = new System.Drawing.Size(26, 29);
            this.btn_全て表示.TabIndex = 94;
            this.btn_全て表示.Text = "+";
            this.btn_全て表示.UseVisualStyleBackColor = true;
            this.btn_全て表示.Click += new System.EventHandler(this.Btn_全て表示_Click);
            // 
            // btn_隠す
            // 
            this.btn_隠す.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_隠す.Location = new System.Drawing.Point(57, 74);
            this.btn_隠す.Name = "btn_隠す";
            this.btn_隠す.Size = new System.Drawing.Size(26, 29);
            this.btn_隠す.TabIndex = 95;
            this.btn_隠す.Text = "-";
            this.btn_隠す.UseVisualStyleBackColor = true;
            this.btn_隠す.Click += new System.EventHandler(this.Btn_隠す_Click);
            // 
            // btn_regist
            // 
            this.btn_regist.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_regist.Location = new System.Drawing.Point(543, 33);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(143, 29);
            this.btn_regist.TabIndex = 96;
            this.btn_regist.Text = "園児健康診断登録";
            this.btn_regist.UseVisualStyleBackColor = true;
            this.btn_regist.Click += new System.EventHandler(this.btn_regist_Click);
            // 
            // dtp_日付
            // 
            this.dtp_日付.Location = new System.Drawing.Point(358, 38);
            this.dtp_日付.Name = "dtp_日付";
            this.dtp_日付.Size = new System.Drawing.Size(120, 19);
            this.dtp_日付.TabIndex = 97;
            this.dtp_日付.ValueChanged += new System.EventHandler(this.dtp_日付_ValueChanged);
            // 
            // btn_output
            // 
            this.btn_output.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_output.Location = new System.Drawing.Point(962, 33);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(103, 29);
            this.btn_output.TabIndex = 98;
            this.btn_output.Text = "EXCEL出力";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.Btn_output_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 638);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1270, 22);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "園児名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle6.Format = "E1";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "園児コード";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle7.Format = "N1";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn5.HeaderText = "日付";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle8.Format = "E1";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "室温(℃)";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle9.Format = "N1";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn7.HeaderText = "体温(℃)";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "検温時間";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "チェック項目";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "回数";
            this.dataGridViewTextBoxColumn10.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "GroupCode";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // 園児健康診断
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 660);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.dtp_日付);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.btn_隠す);
            this.Controls.Add(this.btn_全て表示);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dataGridView_健康診断);
            this.Name = "園児健康診断";
            this.Text = "園児健康診断";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.健康診断_FormClosed);
            this.Load += new System.EventHandler(this.児童健康状況一覧_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_健康診断)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RowMergeView dataGridView_健康診断;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_全て表示;
        private System.Windows.Forms.Button btn_隠す;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.DateTimePicker dtp_日付;
        private System.Windows.Forms.Button btn_output;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 変更ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日付;
        private System.Windows.Forms.DataGridViewTextBoxColumn 室温;
        private System.Windows.Forms.DataGridViewTextBoxColumn 食事内容状況;
        private System.Windows.Forms.DataGridViewTextBoxColumn 体温;
        private System.Windows.Forms.DataGridViewTextBoxColumn 検温時間;
        private System.Windows.Forms.DataGridViewTextBoxColumn チェック項目;
        private System.Windows.Forms.DataGridViewComboBoxColumn 健康状況;
        private System.Windows.Forms.DataGridViewTextBoxColumn 排便;
        private System.Windows.Forms.DataGridViewTextBoxColumn 回数;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}