using ComDll;
namespace 飛鳥SES_人事
{
    partial class 園児出勤一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(園児出勤一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_検索 = new System.Windows.Forms.TextBox();
            this.gv_出勤一覧 = new ComDll.RowMergeView();
            this.園児名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.登園時間 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.降園時間 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.体温 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.体温原本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.健康状況観察 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.欠勤 = new 飛鳥SES_人事.DataGridViewTreeViewColumn();
            this.早退 = new 飛鳥SES_人事.DataGridViewTreeViewColumn();
            this.遅刻 = new 飛鳥SES_人事.DataGridViewTreeViewColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clear = new System.Windows.Forms.ToolStripMenuItem();
            this.datetime = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.sslbl_件数 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslbl_メッセージ = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_検索 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTreeViewColumn1 = new 飛鳥SES_人事.DataGridViewTreeViewColumn();
            this.dataGridViewTreeViewColumn2 = new 飛鳥SES_人事.DataGridViewTreeViewColumn();
            this.dataGridViewTreeViewColumn3 = new 飛鳥SES_人事.DataGridViewTreeViewColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_出勤一覧)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_検索
            // 
            this.txt_検索.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_検索.Location = new System.Drawing.Point(15, 18);
            this.txt_検索.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_検索.MaxLength = 100;
            this.txt_検索.Multiline = true;
            this.txt_検索.Name = "txt_検索";
            this.txt_検索.Size = new System.Drawing.Size(250, 35);
            this.txt_検索.TabIndex = 0;
            // 
            // gv_出勤一覧
            // 
            this.gv_出勤一覧.AllowUserToAddRows = false;
            this.gv_出勤一覧.AllowUserToResizeRows = false;
            this.gv_出勤一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_出勤一覧.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_出勤一覧.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_出勤一覧.ColumnHeadersHeight = 46;
            this.gv_出勤一覧.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.園児名,
            this.登園時間,
            this.降園時間,
            this.体温,
            this.体温原本,
            this.健康状況観察,
            this.欠勤,
            this.早退,
            this.遅刻,
            this.備考});
            this.gv_出勤一覧.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv_出勤一覧.Key = "";
            this.gv_出勤一覧.Location = new System.Drawing.Point(15, 65);
            this.gv_出勤一覧.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gv_出勤一覧.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gv_出勤一覧.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gv_出勤一覧.MergeColumnNames")));
            this.gv_出勤一覧.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gv_出勤一覧.MergeRowIndex")));
            this.gv_出勤一覧.Name = "gv_出勤一覧";
            this.gv_出勤一覧.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gv_出勤一覧.NoLink")));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gv_出勤一覧.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gv_出勤一覧.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gv_出勤一覧.RowTemplate.Height = 21;
            this.gv_出勤一覧.Size = new System.Drawing.Size(1358, 495);
            this.gv_出勤一覧.TabIndex = 2;
            this.gv_出勤一覧.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gv_出勤一覧_CellBeginEdit);
            this.gv_出勤一覧.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_出勤一覧_CellContentClick);
            this.gv_出勤一覧.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_出勤一覧_CellMouseClick);
            this.gv_出勤一覧.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_出勤一覧_CellMouseDown);
            this.gv_出勤一覧.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_出勤一覧_CellValueChanged);
            this.gv_出勤一覧.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gv_出勤一覧_EditingControlShowing);
            // 
            // 園児名
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.園児名.DefaultCellStyle = dataGridViewCellStyle2;
            this.園児名.FillWeight = 79.09646F;
            this.園児名.HeaderText = "園児名";
            this.園児名.MinimumWidth = 10;
            this.園児名.Name = "園児名";
            this.園児名.ReadOnly = true;
            this.園児名.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.園児名.Width = 130;
            // 
            // 登園時間
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.登園時間.DefaultCellStyle = dataGridViewCellStyle3;
            this.登園時間.FillWeight = 98.87057F;
            this.登園時間.HeaderText = "登園時間";
            this.登園時間.MinimumWidth = 10;
            this.登園時間.Name = "登園時間";
            this.登園時間.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.登園時間.Text = "登園";
            this.登園時間.UseColumnTextForButtonValue = true;
            this.登園時間.Width = 90;
            // 
            // 降園時間
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.降園時間.DefaultCellStyle = dataGridViewCellStyle4;
            this.降園時間.FillWeight = 98.87057F;
            this.降園時間.HeaderText = "降園時間";
            this.降園時間.MinimumWidth = 10;
            this.降園時間.Name = "降園時間";
            this.降園時間.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.降園時間.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.降園時間.Text = "降園";
            this.降園時間.UseColumnTextForButtonValue = true;
            this.降園時間.Width = 90;
            // 
            // 体温
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.体温.DefaultCellStyle = dataGridViewCellStyle5;
            this.体温.FillWeight = 28.83038F;
            this.体温.HeaderText = "体温℃";
            this.体温.MaxInputLength = 5;
            this.体温.MinimumWidth = 10;
            this.体温.Name = "体温";
            this.体温.Width = 70;
            // 
            // 体温原本
            // 
            this.体温原本.HeaderText = "体温原本";
            this.体温原本.MinimumWidth = 10;
            this.体温原本.Name = "体温原本";
            this.体温原本.Visible = false;
            this.体温原本.Width = 95;
            // 
            // 健康状況観察
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.健康状況観察.DefaultCellStyle = dataGridViewCellStyle6;
            this.健康状況観察.FillWeight = 102.1541F;
            this.健康状況観察.HeaderText = "健康状況観察";
            this.健康状況観察.MinimumWidth = 10;
            this.健康状況観察.Name = "健康状況観察";
            this.健康状況観察.ReadOnly = true;
            this.健康状況観察.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.健康状況観察.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.健康状況観察.Width = 340;
            // 
            // 欠勤
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.欠勤.DefaultCellStyle = dataGridViewCellStyle7;
            this.欠勤.FillWeight = 98.50574F;
            this.欠勤.HeaderText = "欠勤";
            this.欠勤.MinimumWidth = 10;
            this.欠勤.Name = "欠勤";
            this.欠勤.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.欠勤.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.欠勤.Width = 90;
            // 
            // 早退
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.早退.DefaultCellStyle = dataGridViewCellStyle8;
            this.早退.FillWeight = 98.50574F;
            this.早退.HeaderText = "早退";
            this.早退.MinimumWidth = 10;
            this.早退.Name = "早退";
            this.早退.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.早退.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.早退.Width = 90;
            // 
            // 遅刻
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.遅刻.DefaultCellStyle = dataGridViewCellStyle9;
            this.遅刻.FillWeight = 98.50574F;
            this.遅刻.HeaderText = "遅刻";
            this.遅刻.MinimumWidth = 10;
            this.遅刻.Name = "遅刻";
            this.遅刻.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.遅刻.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.遅刻.Width = 90;
            // 
            // 備考
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.備考.DefaultCellStyle = dataGridViewCellStyle10;
            this.備考.FillWeight = 98.50574F;
            this.備考.HeaderText = "備考";
            this.備考.MaxInputLength = 500;
            this.備考.MinimumWidth = 10;
            this.備考.Name = "備考";
            this.備考.Width = 270;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(301, 86);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // clear
            // 
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(300, 38);
            this.clear.Text = "クリア";
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // datetime
            // 
            this.datetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datetime.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.datetime.Location = new System.Drawing.Point(489, 19);
            this.datetime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(200, 52);
            this.datetime.TabIndex = 3;
            this.datetime.ValueChanged += new System.EventHandler(this.datetime_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbl_件数,
            this.sslbl_メッセージ});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1384, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbl_件数
            // 
            this.sslbl_件数.Name = "sslbl_件数";
            this.sslbl_件数.Size = new System.Drawing.Size(0, 12);
            // 
            // sslbl_メッセージ
            // 
            this.sslbl_メッセージ.Name = "sslbl_メッセージ";
            this.sslbl_メッセージ.Size = new System.Drawing.Size(0, 12);
            // 
            // btn_検索
            // 
            this.btn_検索.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_検索.Location = new System.Drawing.Point(300, 18);
            this.btn_検索.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_検索.Name = "btn_検索";
            this.btn_検索.Size = new System.Drawing.Size(100, 36);
            this.btn_検索.TabIndex = 0;
            this.btn_検索.Text = "検索";
            this.btn_検索.Click += new System.EventHandler(this.btn_検索_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn1.HeaderText = "園児名";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn2.HeaderText = "園児コード";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn3.HeaderText = "登園時間";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn4.HeaderText = "降園時間";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn5.HeaderText = "体温";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn6.HeaderText = "健康状況観察";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTreeViewColumn1
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTreeViewColumn1.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTreeViewColumn1.HeaderText = "欠勤";
            this.dataGridViewTreeViewColumn1.MinimumWidth = 10;
            this.dataGridViewTreeViewColumn1.Name = "dataGridViewTreeViewColumn1";
            this.dataGridViewTreeViewColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTreeViewColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTreeViewColumn1.Width = 200;
            // 
            // dataGridViewTreeViewColumn2
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTreeViewColumn2.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTreeViewColumn2.HeaderText = "早退";
            this.dataGridViewTreeViewColumn2.MinimumWidth = 10;
            this.dataGridViewTreeViewColumn2.Name = "dataGridViewTreeViewColumn2";
            this.dataGridViewTreeViewColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTreeViewColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTreeViewColumn2.Width = 200;
            // 
            // dataGridViewTreeViewColumn3
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTreeViewColumn3.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTreeViewColumn3.HeaderText = "遅刻";
            this.dataGridViewTreeViewColumn3.MinimumWidth = 10;
            this.dataGridViewTreeViewColumn3.Name = "dataGridViewTreeViewColumn3";
            this.dataGridViewTreeViewColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTreeViewColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTreeViewColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn7.HeaderText = "備考";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // 園児出勤一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 611);
            this.Controls.Add(this.btn_検索);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.datetime);
            this.Controls.Add(this.gv_出勤一覧);
            this.Controls.Add(this.txt_検索);
            this.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "園児出勤一覧";
            this.Text = "園児出勤一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児出勤一覧_FormClosed);
            this.Load += new System.EventHandler(this.園児出勤一覧_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_出勤一覧)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_検索;
        public RowMergeView gv_出勤一覧;
        private System.Windows.Forms.DateTimePicker datetime;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_メッセージ;
        private System.Windows.Forms.Button btn_検索;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_件数;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTreeViewColumn dataGridViewTreeViewColumn1;
        private DataGridViewTreeViewColumn dataGridViewTreeViewColumn2;
        private DataGridViewTreeViewColumn dataGridViewTreeViewColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 園児名;
        private System.Windows.Forms.DataGridViewButtonColumn 登園時間;
        private System.Windows.Forms.DataGridViewButtonColumn 降園時間;
        private System.Windows.Forms.DataGridViewTextBoxColumn 体温;
        private System.Windows.Forms.DataGridViewTextBoxColumn 体温原本;
        private System.Windows.Forms.DataGridViewButtonColumn 健康状況観察;
        private DataGridViewTreeViewColumn 欠勤;
        private DataGridViewTreeViewColumn 早退;
        private DataGridViewTreeViewColumn 遅刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
    }
}