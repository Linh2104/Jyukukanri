using ComDll;
namespace 飛鳥SES_人事
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ユーザToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ログアウトToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.パスワードの変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.メール署名設定CtrlMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.職員出勤管理TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出勤機管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出勤機職員登録ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.出勤機職員一覧ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.エラー一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.園児出勤一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.職員管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.職員入園ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.職員情報一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.職員検便記録表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.職員職員健康診断書一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.園児管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新園児入園資料表出力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入園ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退園ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.園児情報一覧ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.健康診断ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水泳活動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保育経過記録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.園児発育チェックToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.業務管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小口現金出納帳ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小口現金出納帳一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保育園チェックリストToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検食ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検食簿一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検食簿登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指導計画ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日誌一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭该页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.すべて閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.このうんどToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ユーザToolStripMenuItem,
            this.職員出勤管理TToolStripMenuItem,
            this.職員管理ToolStripMenuItem,
            this.園児管理ToolStripMenuItem,
            this.業務管理ToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1344, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ユーザToolStripMenuItem
            // 
            this.ユーザToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ログアウトToolStripMenuItem,
            this.パスワードの変更ToolStripMenuItem,
            this.メール署名設定CtrlMToolStripMenuItem});
            this.ユーザToolStripMenuItem.Name = "ユーザToolStripMenuItem";
            this.ユーザToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.ユーザToolStripMenuItem.Text = "ユーザ(&U)";
            // 
            // ログアウトToolStripMenuItem
            // 
            this.ログアウトToolStripMenuItem.Name = "ログアウトToolStripMenuItem";
            this.ログアウトToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ログアウトToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ログアウトToolStripMenuItem.Text = "ログアウト";
            this.ログアウトToolStripMenuItem.Click += new System.EventHandler(this.ログアウトToolStripMenuItem_Click);
            // 
            // パスワードの変更ToolStripMenuItem
            // 
            this.パスワードの変更ToolStripMenuItem.Name = "パスワードの変更ToolStripMenuItem";
            this.パスワードの変更ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.パスワードの変更ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.パスワードの変更ToolStripMenuItem.Text = "パスワードの変更";
            // 
            // メール署名設定CtrlMToolStripMenuItem
            // 
            this.メール署名設定CtrlMToolStripMenuItem.Name = "メール署名設定CtrlMToolStripMenuItem";
            this.メール署名設定CtrlMToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.メール署名設定CtrlMToolStripMenuItem.Text = "メール署名設定　Ctrl+M";
            this.メール署名設定CtrlMToolStripMenuItem.Click += new System.EventHandler(this.メール署名設定CtrlMToolStripMenuItem_Click);
            // 
            // 職員出勤管理TToolStripMenuItem
            // 
            this.職員出勤管理TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.出勤機管理ToolStripMenuItem,
            this.園児出勤一覧ToolStripMenuItem});
            this.職員出勤管理TToolStripMenuItem.Name = "職員出勤管理TToolStripMenuItem";
            this.職員出勤管理TToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.職員出勤管理TToolStripMenuItem.Text = "出勤管理(&T)";
            // 
            // 出勤機管理ToolStripMenuItem
            // 
            this.出勤機管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.出勤機職員登録ToolStripMenuItem1,
            this.出勤機職員一覧ToolStripMenuItem1,
            this.エラー一覧ToolStripMenuItem});
            this.出勤機管理ToolStripMenuItem.Name = "出勤機管理ToolStripMenuItem";
            this.出勤機管理ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.出勤機管理ToolStripMenuItem.Text = "出勤機管理";
            // 
            // 出勤機職員登録ToolStripMenuItem1
            // 
            this.出勤機職員登録ToolStripMenuItem1.Name = "出勤機職員登録ToolStripMenuItem1";
            this.出勤機職員登録ToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.出勤機職員登録ToolStripMenuItem1.Text = "職員登録";
            this.出勤機職員登録ToolStripMenuItem1.Click += new System.EventHandler(this.出勤機職員登録ToolStripMenuItem1_Click);
            // 
            // 出勤機職員一覧ToolStripMenuItem1
            // 
            this.出勤機職員一覧ToolStripMenuItem1.Name = "出勤機職員一覧ToolStripMenuItem1";
            this.出勤機職員一覧ToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.出勤機職員一覧ToolStripMenuItem1.Text = "職員一覧";
            this.出勤機職員一覧ToolStripMenuItem1.Click += new System.EventHandler(this.出勤機職員一覧ToolStripMenuItem1_Click);
            // 
            // エラー一覧ToolStripMenuItem
            // 
            this.エラー一覧ToolStripMenuItem.Name = "エラー一覧ToolStripMenuItem";
            this.エラー一覧ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.エラー一覧ToolStripMenuItem.Text = "エラー一覧";
            this.エラー一覧ToolStripMenuItem.Click += new System.EventHandler(this.エラー一覧ToolStripMenuItem_Click);
            // 
            // 園児出勤一覧ToolStripMenuItem
            // 
            this.園児出勤一覧ToolStripMenuItem.Name = "園児出勤一覧ToolStripMenuItem";
            this.園児出勤一覧ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.園児出勤一覧ToolStripMenuItem.Text = "園児出勤一覧";
            this.園児出勤一覧ToolStripMenuItem.Click += new System.EventHandler(this.園児出勤一覧ToolStripMenuItem_Click);
            // 
            // 職員管理ToolStripMenuItem
            // 
            this.職員管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.職員入園ToolStripMenuItem,
            this.職員情報一覧ToolStripMenuItem,
            this.職員検便記録表ToolStripMenuItem,
            this.職員職員健康診断書一覧ToolStripMenuItem});
            this.職員管理ToolStripMenuItem.Name = "職員管理ToolStripMenuItem";
            this.職員管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.職員管理ToolStripMenuItem.Text = "職員管理";
            // 
            // 職員入園ToolStripMenuItem
            // 
            this.職員入園ToolStripMenuItem.Name = "職員入園ToolStripMenuItem";
            this.職員入園ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.職員入園ToolStripMenuItem.Text = "職員入園";
            this.職員入園ToolStripMenuItem.Click += new System.EventHandler(this.職員入園ToolStripMenuItem_Click);
            // 
            // 職員情報一覧ToolStripMenuItem
            // 
            this.職員情報一覧ToolStripMenuItem.Name = "職員情報一覧ToolStripMenuItem";
            this.職員情報一覧ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.職員情報一覧ToolStripMenuItem.Text = "職員情報一覧";
            this.職員情報一覧ToolStripMenuItem.Click += new System.EventHandler(this.職員情報一覧ToolStripMenuItem_Click);
            // 
            // 職員検便記録表ToolStripMenuItem
            // 
            this.職員検便記録表ToolStripMenuItem.Name = "職員検便記録表ToolStripMenuItem";
            this.職員検便記録表ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.職員検便記録表ToolStripMenuItem.Text = "職員検便記録表";
            this.職員検便記録表ToolStripMenuItem.Click += new System.EventHandler(this.職員検便記録表ToolStripMenuItem_Click);
            // 
            // 職員職員健康診断書一覧ToolStripMenuItem
            // 
            this.職員職員健康診断書一覧ToolStripMenuItem.Name = "職員職員健康診断書一覧ToolStripMenuItem";
            this.職員職員健康診断書一覧ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.職員職員健康診断書一覧ToolStripMenuItem.Text = "職員職員健康診断書一覧";
            this.職員職員健康診断書一覧ToolStripMenuItem.Click += new System.EventHandler(this.職員健康診断書一覧ToolStripMenuItem_Click);
            // 
            // 園児管理ToolStripMenuItem
            // 
            this.園児管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新園児入園資料表出力ToolStripMenuItem,
            this.入園ToolStripMenuItem,
            this.退園ToolStripMenuItem,
            this.園児情報一覧ToolStripMenuItem1,
            this.健康診断ToolStripMenuItem,
            this.水泳活動ToolStripMenuItem,
            this.保育経過記録ToolStripMenuItem,
            this.園児発育チェックToolStripMenuItem});
            this.園児管理ToolStripMenuItem.Name = "園児管理ToolStripMenuItem";
            this.園児管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.園児管理ToolStripMenuItem.Text = "園児管理";
            // 
            // 新園児入園資料表出力ToolStripMenuItem
            // 
            this.新園児入園資料表出力ToolStripMenuItem.Name = "新園児入園資料表出力ToolStripMenuItem";
            this.新園児入園資料表出力ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.新園児入園資料表出力ToolStripMenuItem.Text = "新園児入園資料表出力";
            this.新園児入園資料表出力ToolStripMenuItem.Click += new System.EventHandler(this.新園児入園資料表出力ToolStripMenuItem_Click);
            // 
            // 入園ToolStripMenuItem
            // 
            this.入園ToolStripMenuItem.Name = "入園ToolStripMenuItem";
            this.入園ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.入園ToolStripMenuItem.Text = "入園";
            this.入園ToolStripMenuItem.Click += new System.EventHandler(this.入園ToolStripMenuItem_Click);
            // 
            // 退園ToolStripMenuItem
            // 
            this.退園ToolStripMenuItem.Name = "退園ToolStripMenuItem";
            this.退園ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.退園ToolStripMenuItem.Text = "退園";
            this.退園ToolStripMenuItem.Click += new System.EventHandler(this.退園ToolStripMenuItem_Click);
            // 
            // 園児情報一覧ToolStripMenuItem1
            // 
            this.園児情報一覧ToolStripMenuItem1.Name = "園児情報一覧ToolStripMenuItem1";
            this.園児情報一覧ToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.園児情報一覧ToolStripMenuItem1.Text = "園児情報一覧";
            this.園児情報一覧ToolStripMenuItem1.Click += new System.EventHandler(this.園児情報一覧ToolStripMenuItem_Click);
            // 
            // 健康診断ToolStripMenuItem
            // 
            this.健康診断ToolStripMenuItem.Name = "健康診断ToolStripMenuItem";
            this.健康診断ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.健康診断ToolStripMenuItem.Text = "園児健康診断";
            this.健康診断ToolStripMenuItem.Click += new System.EventHandler(this.健康診断ToolStripMenuItem_Click);
            // 
            // 水泳活動ToolStripMenuItem
            // 
            this.水泳活動ToolStripMenuItem.Name = "水泳活動ToolStripMenuItem";
            this.水泳活動ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.水泳活動ToolStripMenuItem.Text = "水泳活動";
            this.水泳活動ToolStripMenuItem.Click += new System.EventHandler(this.水泳活動ToolStripMenuItem_Click);
            // 
            // 保育経過記録ToolStripMenuItem
            // 
            this.保育経過記録ToolStripMenuItem.Name = "保育経過記録ToolStripMenuItem";
            this.保育経過記録ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.保育経過記録ToolStripMenuItem.Text = "保育経過記録";
            this.保育経過記録ToolStripMenuItem.Click += new System.EventHandler(this.保育経過記録ToolStripMenuItem_Click);
            // 
            // 園児発育チェックToolStripMenuItem
            // 
            this.園児発育チェックToolStripMenuItem.Name = "園児発育チェックToolStripMenuItem";
            this.園児発育チェックToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.園児発育チェックToolStripMenuItem.Text = "園児発育チェック";
            this.園児発育チェックToolStripMenuItem.Click += new System.EventHandler(this.園児発育チェックToolStripMenuItem_Click);
            // 
            // 業務管理ToolStripMenuItem
            // 
            this.業務管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.小口現金出納帳ToolStripMenuItem,
            this.小口現金出納帳一覧ToolStripMenuItem,
            this.保育園チェックリストToolStripMenuItem,
            this.検食ToolStripMenuItem,
            this.指導計画ToolStripMenuItem});
            this.業務管理ToolStripMenuItem.Name = "業務管理ToolStripMenuItem";
            this.業務管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.業務管理ToolStripMenuItem.Text = "業務管理";
            // 
            // 小口現金出納帳ToolStripMenuItem
            // 
            this.小口現金出納帳ToolStripMenuItem.Name = "小口現金出納帳ToolStripMenuItem";
            this.小口現金出納帳ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.小口現金出納帳ToolStripMenuItem.Text = "小口現金出納帳";
            this.小口現金出納帳ToolStripMenuItem.Click += new System.EventHandler(this.小口現金出納帳ToolStripMenuItem_Click);
            // 
            // 小口現金出納帳一覧ToolStripMenuItem
            // 
            this.小口現金出納帳一覧ToolStripMenuItem.Name = "小口現金出納帳一覧ToolStripMenuItem";
            this.小口現金出納帳一覧ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.小口現金出納帳一覧ToolStripMenuItem.Text = "小口現金出納帳一覧";
            this.小口現金出納帳一覧ToolStripMenuItem.Click += new System.EventHandler(this.小口現金出納帳一覧ToolStripMenuItem_Click);
            // 
            // 保育園チェックリストToolStripMenuItem
            // 
            this.保育園チェックリストToolStripMenuItem.Name = "保育園チェックリストToolStripMenuItem";
            this.保育園チェックリストToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.保育園チェックリストToolStripMenuItem.Text = "保育園チェックリスト";
            this.保育園チェックリストToolStripMenuItem.Click += new System.EventHandler(this.保育園チェックリストToolStripMenuItem_Click);
            // 
            // 検食ToolStripMenuItem
            // 
            this.検食ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.検食簿一覧ToolStripMenuItem,
            this.検食簿登録ToolStripMenuItem});
            this.検食ToolStripMenuItem.Name = "検食ToolStripMenuItem";
            this.検食ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.検食ToolStripMenuItem.Text = "検食";
            // 
            // 検食簿一覧ToolStripMenuItem
            // 
            this.検食簿一覧ToolStripMenuItem.Name = "検食簿一覧ToolStripMenuItem";
            this.検食簿一覧ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.検食簿一覧ToolStripMenuItem.Text = "検食簿一覧";
            this.検食簿一覧ToolStripMenuItem.Click += new System.EventHandler(this.検食簿一覧ToolStripMenuItem_Click);
            // 
            // 検食簿登録ToolStripMenuItem
            // 
            this.検食簿登録ToolStripMenuItem.Name = "検食簿登録ToolStripMenuItem";
            this.検食簿登録ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.検食簿登録ToolStripMenuItem.Text = "検食簿登録";
            this.検食簿登録ToolStripMenuItem.Click += new System.EventHandler(this.検食簿登録ToolStripMenuItem_Click);
            // 
            // 指導計画ToolStripMenuItem
            // 
            this.指導計画ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日誌一覧ToolStripMenuItem});
            this.指導計画ToolStripMenuItem.Name = "指導計画ToolStripMenuItem";
            this.指導計画ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.指導計画ToolStripMenuItem.Text = "指導計画";
            // 
            // 日誌一覧ToolStripMenuItem
            // 
            this.日誌一覧ToolStripMenuItem.Name = "日誌一覧ToolStripMenuItem";
            this.日誌一覧ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.日誌一覧ToolStripMenuItem.Text = "日誌一覧";
            this.日誌一覧ToolStripMenuItem.Click += new System.EventHandler(this.日誌一覧ToolStripMenuItem_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョン情報ToolStripMenuItem});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            this.バージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1344, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(250, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭该页ToolStripMenuItem,
            this.すべて閉じるToolStripMenuItem,
            this.このうんどToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 70);
            // 
            // 关闭该页ToolStripMenuItem
            // 
            this.关闭该页ToolStripMenuItem.Name = "关闭该页ToolStripMenuItem";
            this.关闭该页ToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.关闭该页ToolStripMenuItem.Text = "閉じる";
            this.关闭该页ToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
            // 
            // すべて閉じるToolStripMenuItem
            // 
            this.すべて閉じるToolStripMenuItem.Name = "すべて閉じるToolStripMenuItem";
            this.すべて閉じるToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.すべて閉じるToolStripMenuItem.Text = "すべて閉じる";
            this.すべて閉じるToolStripMenuItem.Click += new System.EventHandler(this.すべて閉じるToolStripMenuItem_Click);
            // 
            // このうんどToolStripMenuItem
            // 
            this.このうんどToolStripMenuItem.Name = "このうんどToolStripMenuItem";
            this.このうんどToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.このうんどToolStripMenuItem.Text = "このウィンドウ以外すべて閉じる";
            this.このうんどToolStripMenuItem.Click += new System.EventHandler(this.このうんどToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(38, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 30);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(35, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 25);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.Text = "▼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1007, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 13;
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.Size = new System.Drawing.Size(1344, 729);
            this.dockPanel1.TabIndex = 4;
            this.dockPanel1.Theme = this.vS2015LightTheme1;
            this.dockPanel1.Resize += new System.EventHandler(this.dockPanel1_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dockPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "飛鳥SES_人事";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private HL_StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem ユーザToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ログアウトToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem パスワードの変更ToolStripMenuItem;
        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭该页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem すべて閉じるToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem このうんどToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private System.Windows.Forms.ToolStripMenuItem メール署名設定CtrlMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 職員出勤管理TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 園児管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新園児入園資料表出力ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入園ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退園ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 園児情報一覧ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 出勤機管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出勤機職員登録ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 出勤機職員一覧ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 職員管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 職員入園ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 職員情報一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 業務管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小口現金出納帳ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 職員検便記録表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 健康診断ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 園児出勤一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小口現金出納帳一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem エラー一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 職員職員健康診断書一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水泳活動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保育園チェックリストToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 検食ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 検食簿一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 検食簿登録ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指導計画ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日誌一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保育経過記録ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 園児発育チェックToolStripMenuItem;
    }
}

