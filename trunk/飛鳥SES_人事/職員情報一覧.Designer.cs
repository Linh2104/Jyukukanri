using ComDll;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    partial class 職員情報一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(職員情報一覧));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmb_在職状態リスト = new System.Windows.Forms.ComboBox();
            this.cmb_表示リスト = new System.Windows.Forms.ComboBox();
            this.gridView_職員情報一覧 = new ComDll.RowMergeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退職ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.健康診断一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検便記録一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_職員資料一覧 = new ComDll.RowMergeView();
            this.社員コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名前 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.資格証書 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.履歴書 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.秘密保持契約書 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.一括印刷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルアップロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルダウンロードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職員コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.氏名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ローマ字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.フリガナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生年月日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入社日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.退職日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.社員種別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.園内職務 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_職員情報一覧)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_職員資料一覧)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("メイリオ", 10.8F);
            this.txt_search.Location = new System.Drawing.Point(613, 15);
            this.txt_search.Margin = new System.Windows.Forms.Padding(4);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(211, 34);
            this.txt_search.TabIndex = 91;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("メイリオ", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(833, 15);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(133, 36);
            this.btn_search.TabIndex = 92;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1443, 22);
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
            // cmb_在職状態リスト
            // 
            this.cmb_在職状態リスト.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_在職状態リスト.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_在職状態リスト.FormattingEnabled = true;
            this.cmb_在職状態リスト.Items.AddRange(new object[] {
            "在職のみ表示",
            "退職のみ表示",
            "すべて表示"});
            this.cmb_在職状態リスト.Location = new System.Drawing.Point(379, 15);
            this.cmb_在職状態リスト.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_在職状態リスト.Name = "cmb_在職状態リスト";
            this.cmb_在職状態リスト.Size = new System.Drawing.Size(193, 34);
            this.cmb_在職状態リスト.TabIndex = 1;
            this.cmb_在職状態リスト.SelectedIndexChanged += new System.EventHandler(this.cmb_在職状態リスト_SelectedIndexChanged);
            // 
            // cmb_表示リスト
            // 
            this.cmb_表示リスト.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_表示リスト.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_表示リスト.FormattingEnabled = true;
            this.cmb_表示リスト.Items.AddRange(new object[] {
            "職員情報一覧",
            "職員資料一覧"});
            this.cmb_表示リスト.Location = new System.Drawing.Point(35, 15);
            this.cmb_表示リスト.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_表示リスト.Name = "cmb_表示リスト";
            this.cmb_表示リスト.Size = new System.Drawing.Size(312, 34);
            this.cmb_表示リスト.TabIndex = 1;
            this.cmb_表示リスト.SelectedIndexChanged += new System.EventHandler(this.cmb_表示リスト_SelectedIndexChanged);
            // 
            // gridView_職員情報一覧
            // 
            this.gridView_職員情報一覧.AllowUserToAddRows = false;
            this.gridView_職員情報一覧.AllowUserToResizeRows = false;
            this.gridView_職員情報一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_職員情報一覧.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_職員情報一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_職員情報一覧.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.職員コード,
            this.氏名,
            this.ローマ字,
            this.フリガナ,
            this.生年月日,
            this.性別,
            this.入社日,
            this.退職日,
            this.社員種別,
            this.園内職務});
            this.gridView_職員情報一覧.ContextMenuStrip = this.contextMenuStrip1;
            this.gridView_職員情報一覧.Key = "";
            this.gridView_職員情報一覧.Location = new System.Drawing.Point(35, 81);
            this.gridView_職員情報一覧.Margin = new System.Windows.Forms.Padding(4);
            this.gridView_職員情報一覧.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_職員情報一覧.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_職員情報一覧.MergeColumnNames")));
            this.gridView_職員情報一覧.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_職員情報一覧.MergeRowIndex")));
            this.gridView_職員情報一覧.Name = "gridView_職員情報一覧";
            this.gridView_職員情報一覧.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_職員情報一覧.NoLink")));
            this.gridView_職員情報一覧.RowTemplate.Height = 20;
            this.gridView_職員情報一覧.Size = new System.Drawing.Size(1200, 600);
            this.gridView_職員情報一覧.TabIndex = 91;
            this.gridView_職員情報一覧.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_職員情報一覧_CellClick_1);
            this.gridView_職員情報一覧.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_職員情報一覧_CellEndEdit);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.変更ToolStripMenuItem,
            this.退職ToolStripMenuItem,
            this.健康診断一覧ToolStripMenuItem,
            this.検便記録一覧ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 100);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening_1);
            // 
            // 変更ToolStripMenuItem
            // 
            this.変更ToolStripMenuItem.Name = "変更ToolStripMenuItem";
            this.変更ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.変更ToolStripMenuItem.Text = "変更";
            this.変更ToolStripMenuItem.Click += new System.EventHandler(this.変更ToolStripMenuItem_Click);
            // 
            // 退職ToolStripMenuItem
            // 
            this.退職ToolStripMenuItem.Name = "退職ToolStripMenuItem";
            this.退職ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.退職ToolStripMenuItem.Text = "退職";
            this.退職ToolStripMenuItem.Click += new System.EventHandler(this.退職ToolStripMenuItem_Click);
            // 
            // 健康診断一覧ToolStripMenuItem
            // 
            this.健康診断一覧ToolStripMenuItem.Name = "健康診断一覧ToolStripMenuItem";
            this.健康診断一覧ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.健康診断一覧ToolStripMenuItem.Text = "健康診断一覧";
            this.健康診断一覧ToolStripMenuItem.Click += new System.EventHandler(this.健康診断一覧ToolStripMenuItem_Click);
            // 
            // 検便記録一覧ToolStripMenuItem
            // 
            this.検便記録一覧ToolStripMenuItem.Name = "検便記録一覧ToolStripMenuItem";
            this.検便記録一覧ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.検便記録一覧ToolStripMenuItem.Text = "検便記録一覧";
            this.検便記録一覧ToolStripMenuItem.Click += new System.EventHandler(this.検便記録一覧ToolStripMenuItem_Click);
            // 
            // gridView_職員資料一覧
            // 
            this.gridView_職員資料一覧.AllowUserToAddRows = false;
            this.gridView_職員資料一覧.AllowUserToOrderColumns = true;
            this.gridView_職員資料一覧.AllowUserToResizeRows = false;
            this.gridView_職員資料一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_職員資料一覧.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gridView_職員資料一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_職員資料一覧.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.社員コード,
            this.名前,
            this.資格証書,
            this.履歴書,
            this.秘密保持契約書});
            this.gridView_職員資料一覧.ContextMenuStrip = this.contextMenuStrip2;
            this.gridView_職員資料一覧.Key = "";
            this.gridView_職員資料一覧.Location = new System.Drawing.Point(35, 81);
            this.gridView_職員資料一覧.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridView_職員資料一覧.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridView_職員資料一覧.MergeColumnNames")));
            this.gridView_職員資料一覧.MergeRowIndex = ((System.Collections.Generic.Dictionary<int, int>)(resources.GetObject("gridView_職員資料一覧.MergeRowIndex")));
            this.gridView_職員資料一覧.Name = "gridView_職員資料一覧";
            this.gridView_職員資料一覧.NoLink = ((System.Collections.Generic.List<object>)(resources.GetObject("gridView_職員資料一覧.NoLink")));
            this.gridView_職員資料一覧.RowTemplate.Height = 20;
            this.gridView_職員資料一覧.RowTemplate.ReadOnly = true;
            this.gridView_職員資料一覧.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView_職員資料一覧.Size = new System.Drawing.Size(1000, 599);
            this.gridView_職員資料一覧.TabIndex = 124;
            this.gridView_職員資料一覧.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_職員資料一覧_CellDoubleClick);
            // 
            // 社員コード
            // 
            this.社員コード.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.社員コード.DefaultCellStyle = dataGridViewCellStyle12;
            this.社員コード.HeaderText = "職員コード";
            this.社員コード.Name = "社員コード";
            this.社員コード.ReadOnly = true;
            // 
            // 名前
            // 
            this.名前.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.名前.DefaultCellStyle = dataGridViewCellStyle13;
            this.名前.HeaderText = "名前";
            this.名前.Name = "名前";
            this.名前.ReadOnly = true;
            // 
            // 資格証書
            // 
            this.資格証書.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.資格証書.DefaultCellStyle = dataGridViewCellStyle14;
            this.資格証書.HeaderText = "資格証書";
            this.資格証書.Name = "資格証書";
            this.資格証書.ReadOnly = true;
            // 
            // 履歴書
            // 
            this.履歴書.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.履歴書.DefaultCellStyle = dataGridViewCellStyle15;
            this.履歴書.HeaderText = "履歴書";
            this.履歴書.Name = "履歴書";
            this.履歴書.ReadOnly = true;
            // 
            // 秘密保持契約書
            // 
            this.秘密保持契約書.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.秘密保持契約書.DefaultCellStyle = dataGridViewCellStyle16;
            this.秘密保持契約書.HeaderText = "秘密保持契約書";
            this.秘密保持契約書.Name = "秘密保持契約書";
            this.秘密保持契約書.ReadOnly = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.一括印刷ToolStripMenuItem,
            this.ファイルアップロードToolStripMenuItem,
            this.ファイルダウンロードToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(229, 76);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // 一括印刷ToolStripMenuItem
            // 
            this.一括印刷ToolStripMenuItem.Name = "一括印刷ToolStripMenuItem";
            this.一括印刷ToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.一括印刷ToolStripMenuItem.Text = "一括印刷";
            this.一括印刷ToolStripMenuItem.Click += new System.EventHandler(this.一括印刷ToolStripMenuItem_Click);
            // 
            // ファイルアップロードToolStripMenuItem
            // 
            this.ファイルアップロードToolStripMenuItem.Name = "ファイルアップロードToolStripMenuItem";
            this.ファイルアップロードToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.ファイルアップロードToolStripMenuItem.Text = "ファイルアップロード";
            this.ファイルアップロードToolStripMenuItem.Click += new System.EventHandler(this.アップロードToolStripMenuItem_Click);
            // 
            // ファイルダウンロードToolStripMenuItem
            // 
            this.ファイルダウンロードToolStripMenuItem.Name = "ファイルダウンロードToolStripMenuItem";
            this.ファイルダウンロードToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.ファイルダウンロードToolStripMenuItem.Text = "ファイルダウンロード";
            this.ファイルダウンロードToolStripMenuItem.Click += new System.EventHandler(this.ファイルダウンロードToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 49.54659F;
            this.dataGridViewTextBoxColumn1.HeaderText = "職員コード";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn2.FillWeight = 39.79966F;
            this.dataGridViewTextBoxColumn2.HeaderText = "氏名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn3.FillWeight = 66.38738F;
            this.dataGridViewTextBoxColumn3.HeaderText = "ローマ字";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn4.FillWeight = 66.42651F;
            this.dataGridViewTextBoxColumn4.HeaderText = "フリガナ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn5.FillWeight = 439.7565F;
            this.dataGridViewTextBoxColumn5.HeaderText = "生年月日";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn6.FillWeight = 57.30295F;
            this.dataGridViewTextBoxColumn6.HeaderText = "性別";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn7.FillWeight = 57.02715F;
            this.dataGridViewTextBoxColumn7.HeaderText = "入社日";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn8.FillWeight = 114.1747F;
            this.dataGridViewTextBoxColumn8.HeaderText = "退職日";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn9.FillWeight = 39.86712F;
            this.dataGridViewTextBoxColumn9.HeaderText = "社員種別";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn10.HeaderText = "職員コード";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn11.HeaderText = "名前";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn12.HeaderText = "資格証書";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn13.HeaderText = "履歴書";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTextBoxColumn14.HeaderText = "秘密保持契約書";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // 職員コード
            // 
            this.職員コード.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.職員コード.FillWeight = 52.47248F;
            this.職員コード.HeaderText = "職員コード";
            this.職員コード.Name = "職員コード";
            this.職員コード.ReadOnly = true;
            // 
            // 氏名
            // 
            this.氏名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.氏名.DefaultCellStyle = dataGridViewCellStyle2;
            this.氏名.FillWeight = 75.9248F;
            this.氏名.HeaderText = "氏名";
            this.氏名.Name = "氏名";
            this.氏名.ReadOnly = true;
            // 
            // ローマ字
            // 
            this.ローマ字.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ローマ字.DefaultCellStyle = dataGridViewCellStyle3;
            this.ローマ字.FillWeight = 75.30778F;
            this.ローマ字.HeaderText = "ローマ字";
            this.ローマ字.Name = "ローマ字";
            this.ローマ字.ReadOnly = true;
            // 
            // フリガナ
            // 
            this.フリガナ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.フリガナ.DefaultCellStyle = dataGridViewCellStyle4;
            this.フリガナ.FillWeight = 75.34922F;
            this.フリガナ.HeaderText = "フリガナ";
            this.フリガナ.Name = "フリガナ";
            this.フリガナ.ReadOnly = true;
            // 
            // 生年月日
            // 
            this.生年月日.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.生年月日.DefaultCellStyle = dataGridViewCellStyle5;
            this.生年月日.FillWeight = 110.7565F;
            this.生年月日.HeaderText = "生年月日";
            this.生年月日.Name = "生年月日";
            this.生年月日.ReadOnly = true;
            // 
            // 性別
            // 
            this.性別.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.性別.DefaultCellStyle = dataGridViewCellStyle6;
            this.性別.FillWeight = 60.68688F;
            this.性別.HeaderText = "性別";
            this.性別.Name = "性別";
            this.性別.ReadOnly = true;
            // 
            // 入社日
            // 
            this.入社日.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.入社日.DefaultCellStyle = dataGridViewCellStyle7;
            this.入社日.FillWeight = 60.39479F;
            this.入社日.HeaderText = "入社日";
            this.入社日.Name = "入社日";
            this.入社日.ReadOnly = true;
            // 
            // 退職日
            // 
            this.退職日.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.退職日.DefaultCellStyle = dataGridViewCellStyle8;
            this.退職日.FillWeight = 114.1747F;
            this.退職日.HeaderText = "退職日";
            this.退職日.Name = "退職日";
            this.退職日.ReadOnly = true;
            // 
            // 社員種別
            // 
            this.社員種別.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.社員種別.DefaultCellStyle = dataGridViewCellStyle9;
            this.社員種別.FillWeight = 42.22141F;
            this.社員種別.HeaderText = "社員種別";
            this.社員種別.Name = "社員種別";
            this.社員種別.ReadOnly = true;
            // 
            // 園内職務
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.園内職務.DefaultCellStyle = dataGridViewCellStyle10;
            this.園内職務.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.園内職務.HeaderText = "園内職務";
            this.園内職務.Items.AddRange(new object[] {
            "保育士",
            "保育补助",
            "保育补助雇上加算",
            "連携推進員",
            "英語先生",
            "清掃",
            "施設長"});
            this.園内職務.Name = "園内職務";
            this.園内職務.Width = 110;
            // 
            // 職員情報一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 721);
            this.Controls.Add(this.gridView_職員資料一覧);
            this.Controls.Add(this.gridView_職員情報一覧);
            this.Controls.Add(this.cmb_表示リスト);
            this.Controls.Add(this.cmb_在職状態リスト);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "職員情報一覧";
            this.Text = "職員情報一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.職員情報一覧_FormClosed);
            this.Load += new System.EventHandler(this.職員情報一覧_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_職員情報一覧)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_職員資料一覧)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private ComboBox cmb_在職状態リスト;
        public ComboBox cmb_表示リスト;
        private RowMergeView gridView_職員情報一覧;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 変更ToolStripMenuItem;
        private ToolStripMenuItem 退職ToolStripMenuItem;
        private ToolStripMenuItem 健康診断一覧ToolStripMenuItem;
        private ToolStripMenuItem 検便記録一覧ToolStripMenuItem;
        private RowMergeView gridView_職員資料一覧;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 一括印刷ToolStripMenuItem;
        private ToolStripMenuItem ファイルアップロードToolStripMenuItem;
        private ToolStripMenuItem ファイルダウンロードToolStripMenuItem;
        private DataGridViewTextBoxColumn 社員コード;
        private DataGridViewTextBoxColumn 名前;
        private DataGridViewTextBoxColumn 資格証書;
        private DataGridViewTextBoxColumn 履歴書;
        private DataGridViewTextBoxColumn 秘密保持契約書;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn 職員コード;
        private DataGridViewTextBoxColumn 氏名;
        private DataGridViewTextBoxColumn ローマ字;
        private DataGridViewTextBoxColumn フリガナ;
        private DataGridViewTextBoxColumn 生年月日;
        private DataGridViewTextBoxColumn 性別;
        private DataGridViewTextBoxColumn 入社日;
        private DataGridViewTextBoxColumn 退職日;
        private DataGridViewTextBoxColumn 社員種別;
        private DataGridViewComboBoxColumn 園内職務;
    }
}