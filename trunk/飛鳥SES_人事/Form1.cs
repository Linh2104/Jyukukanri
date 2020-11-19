using ComDll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
//using Microsoft.Office.Interop.Excel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace 飛鳥SES_人事
{
    public partial class Form1 : Form
    {
        public FromHandleBox m_メール一斉配信Handle = new FromHandleBox();
        public FromHandleBox m_バージョン情報Handle = new FromHandleBox();
        public FromHandleBox m_メール署名設定Handle = new FromHandleBox();
        public List<IntPtr> m_メール返信転送Handle = new List<IntPtr>();
        public bool reLoad = false;
        //20200824 qin add
        public FromHandleBox m_出勤機職員登録Handle = new FromHandleBox();
        //20200824 qin end
        //2020 08/24  沙丹丹 add
        public FromHandleBox m_出勤機職員一覧Handle = new FromHandleBox();
        //2020 08/24  沙丹丹 end
        // 20200827 Linh add
        public FromHandleBox m_園児情報一覧Handle = new FromHandleBox();
        // 20200827 Linh end

        // 20200828 LiuRui add start
        public FromHandleBox m_入園手続きHandle = new FromHandleBox();
        // 20200828 LiuRui add end
        // 20200907 叶 add
        public FromHandleBox m_職員新規と変更Handle = new FromHandleBox();
        // 20200907 叶 end
        // 20200831 LXB-Add-S
        public FromHandleBox m_職員情報一覧Handle = new FromHandleBox();
        // 20200831 LXB-Add-E
        //2020 09/11  CHW add
        public FromHandleBox m_小口現金出納帳Handle = new FromHandleBox();
        //2020 09/11  CHW end
        //2020 09/23  CHW add
        public FromHandleBox m_小口現金出納帳一覧Handle = new FromHandleBox();
        //2020 09/23  CHW end
        //2020 09/24  沙丹丹 add
        public FromHandleBox m_健康診断Handle = new FromHandleBox();
        //2020 09/24 沙丹丹 end
        //20200929 qin add
        public FromHandleBox m_園児出勤一覧Handle = new FromHandleBox();
        //20200929 qin end
        // 20200929 LXB-Add-S
        public FromHandleBox m_職員退園Handle = new FromHandleBox();
        // 20200929 LXB-Add-E

        //20200923 Linh add
        public FromHandleBox m_職員検便記録表Handle = new FromHandleBox();
        //20200923 Linh end

        //20201006 Lin(XY) add
        public FromHandleBox m_出勤表エラー記録Handle = new FromHandleBox();
        //20201006 Lin(XY) edd
        //20201008 GJL add
        public FromHandleBox m_職員健康診断書一覧Handle = new FromHandleBox();
        //20201008 GJL edd
        //20201009 chenriming add
        public FromHandleBox m_水泳活動Handle = new FromHandleBox();
        //20201009 chenriming add
        //2020 10/20  tc add
        public FromHandleBox m_検食簿一覧Handle = new FromHandleBox();
        //2020 10/20  tc end
        //2020 1019  CHW add
        public FromHandleBox m_保育園チェックリストHandle = new FromHandleBox();
        //2020 1019  CHW end
        //2020 10/20  tc add
        public FromHandleBox m_検食簿編集Handle = new FromHandleBox();
        //2020 10/20  tc end
        //20201022 GJL add
        public FromHandleBox m_日誌一覧NewHandle = new FromHandleBox();
        //20201022 GJL edd

        //20201028 Linh add
        public FromHandleBox m_園児退園Handle = new FromHandleBox();
        //20201028 Linh end

        //20201102 LXB add
        public FromHandleBox m_発育チェック一覧Handle = new FromHandleBox();
        public FromHandleBox m_園児発育チェック曲線図画面Handle = new FromHandleBox();
        public FromHandleBox m_園児発育チェック登録画面Handle = new FromHandleBox();
        //20201102 LXB end

        //20201104 LIURUI add
        public FromHandleBox m_新園児入園資料出力Handle = new FromHandleBox();
        //20201104 LIURUI end

        //20201106 Lin(XY) add
        public FromHandleBox m_保育経過記録Handle = new FromHandleBox();
        //20201106 Lin(XY) end

        public ユーザ登録 m_ユーザ登録 = null;
        public テスト実施 m_テスト実施_From = null;
        public FromHandleBox m_メール返信中 = new FromHandleBox();

        public const int MAXDAYS = -15;
        public const int UpdateNum = 300;
        public const int WM_CLOSE = 0x0010;
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();

            this.Text = "【飛鳥SES-人事】";

            CheckForIllegalCrossThreadCalls = false;
        }

        #region Myメイン画面

        [DllImport("User32.dll ")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("User32.dll ")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("Kernel32.dll ")]
        private static extern int GetLastError();

        Color Caption = Color.FromArgb(217, 196, 102);
        Color Caption1 = Color.FromArgb(217, 186, 96);

        protected override CreateParams CreateParams
        {
            get
            {
                var param = base.CreateParams;
                param.ClassStyle |= 0x20000;// 类似于 窗体阴影效果
                return param;
            }
        }

        void PainWindow(IntPtr hwnd, bool active)
        {
            IntPtr hDC = GetWindowDC(hwnd);
            Graphics gx = Graphics.FromHdc(hDC);

            Brush brush = null;

            //画标题栏
            if (active)
            {
                brush = new SolidBrush(Caption);
            }
            else
            {
                brush = new SolidBrush(Caption1);
            }
            gx.FillRectangle(brush, 8, 0, this.Width - 16, 31);

            ////左边框1
            gx.FillRectangle(brush, 0, 0, 8, this.Height);
            ////右边框1
            gx.FillRectangle(brush, this.Width - 8, 0, this.Width, this.Height);
            ////下边框1
            gx.FillRectangle(brush, 0, this.Height - 8, this.Width, this.Height);

            //画图标和标题
            DrawIcon(gx);
            DrawText(gx, active);
            ////画按钮

            this.DrawMinButton(gx, active);
            this.DrawMaxButton(gx, active);
            this.DrawCloseButton(gx, active);

            gx.Dispose();
            ReleaseDC(hDC, hDC); //释放GDI资源 
        }

        void DrawIcon(Graphics g)
        {
            g.DrawImage(Properties.Resources.メイン画面, new Point(8, 4));
        }
        void DrawText(Graphics g, bool active)
        {
            Brush brush = null;
            if (active)
            {
                brush = new SolidBrush(Color.Black);
            }
            else
            {
                brush = new SolidBrush(Color.Gray);
            }
            g.DrawString(this.Text, new System.Drawing.Font("Segoe UI Symbol", 10), brush, new Point(46, 10), StringFormat.GenericDefault);
        }
        void DrawMinButton(Graphics g, bool active)
        {
            Pen pen = null;
            if (active)
            {
                pen = new Pen(Color.Black);
            }
            else
            {
                pen = new Pen(Color.Gray);
            }

            g.DrawLine(pen, new Point(this.Width - 33 - 31 - 10 - 31 - 10, 16), new Point(this.Width - 33 - 31 - 10 - 31, 16));
        }
        void DrawMaxButton(Graphics g, bool active)
        {
            Pen pen = null;
            if (active)
            {
                pen = new Pen(Color.Black);
            }
            else
            {
                pen = new Pen(Color.Gray);
            }

            if (this.WindowState == FormWindowState.Maximized)
            {
                g.DrawLine(pen, new Point(this.Width - 33 - 31, 11), new Point(this.Width - 33 - 31 - 8, 11));
                g.DrawLine(pen, new Point(this.Width - 33 - 33, 13), new Point(this.Width - 33 - 31 - 10, 13));
                g.DrawLine(pen, new Point(this.Width - 33 - 33, 21), new Point(this.Width - 33 - 31 - 10, 21));

                g.DrawLine(pen, new Point(this.Width - 33 - 31 - 8, 11), new Point(this.Width - 33 - 31 - 8, 13));

                g.DrawLine(pen, new Point(this.Width - 33 - 31, 11), new Point(this.Width - 33 - 31, 19));
                g.DrawLine(pen, new Point(this.Width - 33 - 33, 13), new Point(this.Width - 33 - 33, 21));
                g.DrawLine(pen, new Point(this.Width - 33 - 31 - 10, 13), new Point(this.Width - 33 - 31 - 10, 21));

                g.DrawLine(pen, new Point(this.Width - 33 - 31, 19), new Point(this.Width - 33 - 33, 19));
            }
            else
            {
                g.DrawLine(pen, new Point(this.Width - 33 - 31, 11), new Point(this.Width - 33 - 31 - 10, 11));
                g.DrawLine(pen, new Point(this.Width - 33 - 31, 21), new Point(this.Width - 33 - 31 - 10, 21));
                g.DrawLine(pen, new Point(this.Width - 33 - 31, 11), new Point(this.Width - 33 - 31, 21));
                g.DrawLine(pen, new Point(this.Width - 33 - 31 - 10, 11), new Point(this.Width - 33 - 31 - 10, 21));
            }
        }

        void DrawCloseButton(Graphics g, bool active)
        {
            Pen pen = null;
            if (active)
            {
                pen = new Pen(Color.Black, 1.5f);
            }
            else
            {
                pen = new Pen(Color.Gray, 1.5f);
            }

            g.DrawLine(pen, new Point(this.Width - 23 - 10, 11), new Point(this.Width - 23, 21));
            g.DrawLine(pen, new Point(this.Width - 23 - 10, 21), new Point(this.Width - 23, 11));
        }
        private bool bMinButton = false;
        private bool bMaxButton = false;
        private bool bCloseButton = false;

        private void MinButton_Show(IntPtr hwnd, Point mousePoint, bool active)
        {
            System.Drawing.Rectangle CloseButton_rect = new System.Drawing.Rectangle(this.Width - 33 - 31 - 10 - 31 - 10 - 15, 0, 40, 30);

            if (CloseButton_rect.Contains(mousePoint))
            {
                if (!bMinButton)
                {
                    IntPtr hDC = GetWindowDC(hwnd);
                    Graphics gx = Graphics.FromHdc(hDC);

                    Brush brush = new SolidBrush(Color.FromArgb(229, 229, 229));

                    gx.FillRectangle(brush, CloseButton_rect);
                    DrawMinButton(gx, active);
                    gx.Dispose();
                    ReleaseDC(hDC, hDC);
                    bMinButton = true;
                }
            }
            else
            {
                if (bMinButton)
                {
                    IntPtr hDC = GetWindowDC(hwnd);
                    Graphics gx = Graphics.FromHdc(hDC);

                    Brush brush = null;

                    if (active)
                    {
                        brush = new SolidBrush(Caption);
                    }
                    else
                    {
                        brush = new SolidBrush(Caption1);
                    }

                    gx.FillRectangle(brush, CloseButton_rect);
                    DrawMinButton(gx, active);
                    gx.Dispose();
                    ReleaseDC(hDC, hDC);
                    bMinButton = false;
                }
            }
        }
        private void MaxButton_Show(IntPtr hwnd, Point mousePoint, bool active)
        {
            System.Drawing.Rectangle CloseButton_rect = new System.Drawing.Rectangle(this.Width - 33 - 31 - 10 - 15, 0, 40, 30);

            if (CloseButton_rect.Contains(mousePoint))
            {
                if (!bMaxButton)
                {
                    IntPtr hDC = GetWindowDC(hwnd);
                    Graphics gx = Graphics.FromHdc(hDC);

                    Brush brush = new SolidBrush(Color.FromArgb(229, 229, 229));

                    gx.FillRectangle(brush, CloseButton_rect);
                    DrawMaxButton(gx, active);
                    gx.Dispose();
                    ReleaseDC(hDC, hDC);
                    bMaxButton = true;
                }
            }
            else
            {
                if (bMaxButton)
                {
                    IntPtr hDC = GetWindowDC(hwnd);
                    Graphics gx = Graphics.FromHdc(hDC);

                    Brush brush = null;

                    if (active)
                    {
                        brush = new SolidBrush(Caption);
                    }
                    else
                    {
                        brush = new SolidBrush(Caption1);
                    }

                    gx.FillRectangle(brush, CloseButton_rect);
                    DrawMaxButton(gx, active);
                    gx.Dispose();
                    ReleaseDC(hDC, hDC);
                    bMaxButton = false;
                }
            }
        }
        private void CloseButton_Show(IntPtr hwnd, Point mousePoint, bool active)
        {
            System.Drawing.Rectangle CloseButton_rect = new System.Drawing.Rectangle(this.Width - 33 - 15, 0, 40, 30);

            if (CloseButton_rect.Contains(mousePoint))
            {
                if (!bCloseButton)
                {
                    IntPtr hDC = GetWindowDC(hwnd);
                    Graphics gx = Graphics.FromHdc(hDC);

                    Brush brush = new SolidBrush(Color.FromArgb(232, 17, 35));

                    gx.FillRectangle(brush, CloseButton_rect);
                    DrawCloseButton(gx, active);
                    gx.Dispose();
                    ReleaseDC(hDC, hDC);
                    bCloseButton = true;
                }
            }
            else
            {
                if (bCloseButton)
                {
                    IntPtr hDC = GetWindowDC(hwnd);
                    Graphics gx = Graphics.FromHdc(hDC);

                    Brush brush = null;

                    if (active)
                    {
                        brush = new SolidBrush(Caption);
                    }
                    else
                    {
                        brush = new SolidBrush(Caption1);
                    }

                    gx.FillRectangle(brush, CloseButton_rect);
                    DrawCloseButton(gx, active);
                    gx.Dispose();
                    ReleaseDC(hDC, hDC);
                    bCloseButton = false;
                }
            }
        }

        private void MinButton_Click(IntPtr hwnd, Point mousePoint)
        {
            System.Drawing.Rectangle CloseButton_rect = new System.Drawing.Rectangle(this.Width - 33 - 31 - 10 - 31 - 10 - 15, 0, 40, 30);

            if (CloseButton_rect.Contains(mousePoint))
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void MaxButton_Click(IntPtr hwnd, Point mousePoint)
        {
            System.Drawing.Rectangle CloseButton_rect = new System.Drawing.Rectangle(this.Width - 33 - 31 - 10 - 15, 0, 40, 30);

            if (CloseButton_rect.Contains(mousePoint))
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void CloseButton_Click(IntPtr hwnd, Point mousePoint)
        {
            System.Drawing.Rectangle CloseButton_rect = new System.Drawing.Rectangle(this.Width - 33 - 15, 0, 40, 30);

            if (CloseButton_rect.Contains(mousePoint))
            {
                this.Close();
            }
        }
        #region GetMessagePos 103

        [DllImport("user32.dll")]
        public static extern int GetMessagePos();

        public static int GET_X_LPARAM(int lParam)
        {
            return (lParam & 0xffff);
        }

        public static int GET_Y_LPARAM(int lParam)
        {
            return (lParam >> 16);
        }

        #endregion
        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {
            switch (msg.Msg)
            {
                case 0x86://WM_NCACTIVATE
                    {
                        this.PainWindow(msg.HWnd, msg.WParam.ToInt32() > 0);

                        if (msg.WParam == (IntPtr)0)
                        {
                            msg.Result = (IntPtr)1;
                        }
                        break;
                    }
                case 0x85://WM_NCPAINT 
                    {
                        this.PainWindow(msg.HWnd, Form.ActiveForm == this);
                        break;
                    }
                case 0x0020://WM_SETCURSOR 绘制可以拖拽边框size的鼠标造型 也会引起右上角3按钮出现
                    {
                        Point screenPoint = new Point((int)GetMessagePos());
                        Point formPoint = this.PointToClient(Control.MousePosition);

                        //this.Width this.Height指得客户区的size，要加算非客户区
                        if (((formPoint.X <= 35 && formPoint.X >= -2) && (formPoint.Y >= -31 && formPoint.Y <= -25)) ||
                            ((formPoint.X <= 0 && formPoint.X >= -2) && (formPoint.Y >= -31 && formPoint.Y <= 0)))
                        {
                            Cursor.Current = Cursors.SizeNWSE;//左上角
                        }
                        else if (((formPoint.X <= this.Width && formPoint.X >= this.Width - 16) && (formPoint.Y >= -31 && formPoint.Y <= -25)) ||
                            ((formPoint.X <= this.Width - 15 && formPoint.X >= this.Width - 16) && (formPoint.Y >= -31 && formPoint.Y <= 0)))
                        {
                            Cursor.Current = Cursors.SizeNESW;//右上角
                        }
                        else if (((formPoint.X <= 35 && formPoint.X >= -2) && (formPoint.Y >= this.Height - 41 && formPoint.Y <= this.Height - 39)) ||
                            ((formPoint.X <= 0 && formPoint.X >= -2) && (formPoint.Y >= this.Height - 60 && formPoint.Y <= this.Height - 39)))
                        {
                            Cursor.Current = Cursors.SizeNESW;//左下角
                        }
                        else if (((formPoint.X <= this.Width && formPoint.X >= this.Width - 52) && (formPoint.Y >= this.Height - 41 && formPoint.Y <= this.Height - 39)) ||
                            ((formPoint.X <= this.Width - 15 && formPoint.X >= this.Width - 16) && (formPoint.Y >= this.Height - 60 && formPoint.Y <= this.Height - 39)))
                        {
                            Cursor.Current = Cursors.SizeNWSE;//右下角
                        }
                        else if ((formPoint.X <= 0 && formPoint.X >= -2) || (formPoint.X <= this.Width - 15 && formPoint.X >= this.Width - 16))
                        {
                            Cursor.Current = Cursors.SizeWE;//左右边界
                        }
                        else if (((formPoint.Y >= -31 && formPoint.Y <= -25) || (formPoint.Y >= this.Height - 41 && formPoint.Y <= this.Height - 39)))
                        {
                            Cursor.Current = Cursors.SizeNS;//上下边界
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                        }

                        break;
                    }
                case 0x000F://WM_PAINT  
                    {
                        base.WndProc(ref msg);

                        GraphicsPath gr = new GraphicsPath();
                        gr.AddRectangle(new Rectangle(6, 0, this.Width - 12, this.Height - 6));
                        Region region = new Region(gr);
                        this.Region = region;

                        break;
                    }
                case 0xA0://WM_NCMOUSEMOVE
                    {
                        Point mousePoint = new Point((int)msg.LParam);

                        mousePoint.Offset(-this.Left, -this.Top);

                        MinButton_Show(msg.HWnd, mousePoint, Form.ActiveForm == this);
                        MaxButton_Show(msg.HWnd, mousePoint, Form.ActiveForm == this);
                        CloseButton_Show(msg.HWnd, mousePoint, Form.ActiveForm == this);

                        base.WndProc(ref msg);
                        break;
                    }
                case 0xA1://WM_NCLBUTTONDOWN 
                    {

                        Point mousePoint = new Point((int)msg.LParam);

                        mousePoint.Offset(-this.Left, -this.Top);

                        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(this.Width - 33 - 31 - 10 - 31 - 10 - 15, 0, 122, 30);

                        bool bButtonRect = false;
                        if (rect.Contains(mousePoint))
                        {
                            bButtonRect = true;
                        }

                        MinButton_Click(msg.HWnd, mousePoint);
                        MaxButton_Click(msg.HWnd, mousePoint);
                        CloseButton_Click(msg.HWnd, mousePoint);

                        if (!bButtonRect)
                        {
                            base.WndProc(ref msg);
                        }

                        break;
                    }
                case 0x0005://WM_SIZE 拖拽变大变小时，边框重新裁剪
                    {
                        base.WndProc(ref msg);

                        GraphicsPath gr = new GraphicsPath();
                        gr.AddRectangle(new Rectangle(6, 0, this.Width - 12, this.Height - 6));
                        Region region = new Region(gr);
                        this.Region = region;

                        break;
                    }
                case 0x00AE://这个消息，会让系统按钮重现。是Windows的Bug处理。
                case 0x00AF://由于是自己控制绘制，所以直接可以丢弃此消息。另外还有个0x00AF的消息也一样处理。
                    {
                        base.WndProc(ref msg);

                        this.PainWindow(msg.HWnd, Form.ActiveForm == this);

                        GraphicsPath gr = new GraphicsPath();
                        gr.AddRectangle(new Rectangle(6, 0, this.Width - 12, this.Height - 6));
                        Region region = new Region(gr);
                        this.Region = region;

                        break;
                    }
                default:
                    {
                        Point mousePoint = new Point((int)GetMessagePos());
                        mousePoint.Offset(-this.Left, -this.Top);

                        MinButton_Show(msg.HWnd, mousePoint, Form.ActiveForm == this);
                        MaxButton_Show(msg.HWnd, mousePoint, Form.ActiveForm == this);
                        CloseButton_Show(msg.HWnd, mousePoint, Form.ActiveForm == this);

                        base.WndProc(ref msg);
                        break;
                    }
            }
        }
        #endregion

        private void メニュー表示()
        {
            //権限により　画面の非表示など
        }

        private void ログアウトToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("画面を閉じてログアウトしてよろしですか。", "ログアウト", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Hide();
            }
            else
            {
                return;
            }

            this.Text = "【飛鳥SES-人事】";


            this.m_ユーザ登録.m_ログイン_ユーザ = "";

            SendMessage(m_メール一斉配信Handle.iHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            SendMessage(m_バージョン情報Handle.iHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

            foreach (IntPtr tmpIP in m_メール返信転送Handle)
            {
                SendMessage(tmpIP, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }

            foreach (Form childrenForm in this.MdiChildren)
            {
                childrenForm.Close();
            }

            this.m_ユーザ登録.load();
            this.m_ユーザ登録.Show();
        }

        public void load()
        {
            if (!this.m_ユーザ登録.Equals(""))
            {
                this.Text += " " + this.m_ユーザ登録.m_ログイン_ユーザ;
            }

            string connectionString = "";

            connectionString = ComClass.connectionString;  // muhuaizhi updata 20180607 


            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("サーバーがつなげない！インターネット接続をチェックしてください。");

                return;
            }

            string str_sqlcmd = string.Format(@"select * from HL_EIGYO_ユーザ where ユーザ = '{0}'", this.m_ユーザ登録.m_ログイン_ユーザ);

            SqlCommand com = new SqlCommand(str_sqlcmd, conn);

            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = reader["氏名"].ToString() + " 様　ようこそ";

                //権限によりメイン画面のメニューの表示・非表示
            }

            reader.Close();
            conn.Close();


            Thread thread = new Thread(new ThreadStart(更新スレッド));
            thread.IsBackground = true;
            thread.Start();

        }

        public void 更新スレッド()
        {
            while (true)
            {
                Thread.Sleep(60000 * 5);

                 if (this.m_園児出勤一覧Handle != null)
                {
                    SendMessage(this.m_園児出勤一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_出勤機職員一覧Handle != null)
                {
                    SendMessage(this.m_出勤機職員一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_出勤表エラー記録Handle != null)
                {
                    SendMessage(this.m_出勤表エラー記録Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_職員情報一覧Handle != null)
                {
                    SendMessage(this.m_職員情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_職員検便記録表Handle != null)
                {
                    SendMessage(this.m_職員検便記録表Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_職員健康診断書一覧Handle != null)
                {
                    SendMessage(this.m_職員健康診断書一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_園児情報一覧Handle != null)
                {
                    SendMessage(this.m_園児情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_健康診断Handle != null)
                {
                    SendMessage(this.m_健康診断Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_水泳活動Handle != null)
                {
                    SendMessage(this.m_水泳活動Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_保育経過記録Handle != null)
                {
                    SendMessage(this.m_保育経過記録Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_園児発育チェック曲線図画面Handle != null)
                {
                    SendMessage(this.m_園児発育チェック曲線図画面Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_小口現金出納帳一覧Handle != null)
                {
                    SendMessage(this.m_小口現金出納帳一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_保育園チェックリストHandle != null)
                {
                    SendMessage(this.m_保育園チェックリストHandle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_検食簿一覧Handle != null)
                {
                    SendMessage(this.m_検食簿一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }

                if (this.m_日誌一覧NewHandle != null)
                {
                    SendMessage(this.m_日誌一覧NewHandle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();

            SetLocation();

            メニュー表示();

            this.dockPanel1.DockBackColor = Color.DarkGray;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_ユーザ登録.m_MainForm = null;
            this.m_ユーザ登録.Close();
        }


        private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dockPanel1.ActiveContent.DockHandler.Close();
        }

        private void すべて閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockContentCollection contents = this.dockPanel1.Contents;
            int num = 0;
            while (num < contents.Count)
            {
                if (contents[num].DockHandler.DockState == DockState.Document)
                {
                    contents[num].DockHandler.Close();
                }
                else
                {
                    num++;
                }
            }
        }

        private void このうんどToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockContentCollection contents = this.dockPanel1.Contents;
            int num = 0;
            while (num < contents.Count)
            {
                if (contents[num].DockHandler.DockState == DockState.Document && this.dockPanel1.ActiveContent != contents[num])
                {
                    contents[num].DockHandler.Close();
                }
                else
                {
                    num++;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("【飛鳥SES-人事】を終了してよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        メール一斉配信 m_NewForm_メール一斉配信 = new メール一斉配信();//muhuaizhi add 20190205

        private void 一斉配信ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_メール一斉配信Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_メール一斉配信Handle.iHandle);
                return;
            }

            m_NewForm_メール一斉配信 = new メール一斉配信();//muhuaizhi updata 20190205

            m_NewForm_メール一斉配信.Tag = this;//muhuaizhi updata 20190205
            m_NewForm_メール一斉配信.Show(this.dockPanel1);//muhuaizhi updata 20190205
            this.m_メール一斉配信Handle.iHandle = m_NewForm_メール一斉配信.Handle;//muhuaizhi updata 20190205
            toolStripStatusLabel1.Text = "";
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_バージョン情報Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_バージョン情報Handle.iHandle);
                return;
            }

            バージョン情報 NewForm = new バージョン情報();

            NewForm.Setシステム名(Properties.Resources.SubSystemName);
            NewForm.Tag = this.m_バージョン情報Handle;
            NewForm.Show();

            this.m_バージョン情報Handle.iHandle = NewForm.Handle;
        }


        //muhuaizhi add 20190205 start
        private void SetLocation()
        {
            int h1 = menuStrip1.Height;
            panel1.Location = new System.Drawing.Point(0, menuStrip1.Height);
            panel1.Width = menuStrip1.Width;
            panel1.BringToFront();
        }
        private void dockPanel1_Resize(object sender, EventArgs e)
        {
            SetLocation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            if (panel1.Visible)
            {
                button1.Text = "▲";

            }
            else
            {
                button1.Text = "▼";
            }
            label1.Focus();
        }
        //現在VIEW全部印刷
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Data.DataTable 出力内容 = new System.Data.DataTable();
            string タイトル = "";
            List<int> lst広さ = new List<int>();

            if (this.dockPanel1.ActiveDocument == null)//add muhuaizhi 20190419
            {
                return;
            }

            switch (this.dockPanel1.ActiveDocument.DockHandler.TabText)
            {
            }

            ComClass.PrintOut(出力内容, タイトル, lst広さ);
        }

        //選択範囲印刷
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Data.DataTable 出力内容 = new System.Data.DataTable();
            string タイトル = "";
            List<int> lst広さ = new List<int>();

            if (this.dockPanel1.ActiveDocument == null)//add muhuaizhi 20190419
            {
                return;
            }

            switch (this.dockPanel1.ActiveDocument.DockHandler.TabText)
            {
                case "学校一覧":
                    //Getdt_Select(m_NewForm_学校一覧.rowMergeView1, ref 出力内容, ref lst広さ);
                    タイトル = "学校一覧";
                    break;
            }

            ComClass.PrintOut(出力内容, タイトル, lst広さ);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            toolTip1.SetToolTip(this.pictureBox1, "現在表示している内容を全てプリントアウト。");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            toolTip1.SetToolTip(this.pictureBox2, "現在選択している内容をプリントアウト。");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void Getdt(RowMergeView r, ref System.Data.DataTable dt, ref List<int> lst)
        {
            dt = new System.Data.DataTable();

            for (int a = 0; a < r.ColumnCount; a++)
            {
                dt.Columns.Add(r.Columns[a].HeaderText, "string".GetType());
                lst.Add(r.Columns[a].Width);
            }

            for (int a = 0; a < r.RowCount; a++)
            {
                dt.Rows.Add();

                for (int b = 0; b < r.ColumnCount; b++)
                {
                    dt.Rows[a][b] = r.Rows[a].Cells[b].Value;
                }
            }
        }

        private void Getdt_Select(RowMergeView r, ref System.Data.DataTable dt, ref List<int> lst)
        {
            dt = new System.Data.DataTable();
            lst.Clear();
            int startR = -2;
            int startC = -2;
            int endR = -2;
            int endC = -2;
            int times = 0;
            for (int a = 0; a < r.RowCount; a++)
            {
                times = 0;
                for (int b = 0; b < r.ColumnCount; b++)
                {
                    if (r.Rows[a].Cells[b].Selected && startR == -2)
                    {
                        startR = a;
                        startC = b;
                    }
                    if (!r.Rows[a].Cells[b].Selected && startR == a && endC == -2)
                    {
                        endC = b - 1;
                    }
                    if (!r.Rows[a].Cells[b].Selected)
                    {
                        times++;
                    }
                    if (times == r.ColumnCount && startR != -2)
                    {
                        endR = a - 1;
                        goto here;
                    }
                }
            }
        here:

            if (endC == -2)
            {
                endC = r.ColumnCount - 1;
            }

            if (endR == -2)
            {
                endR = r.RowCount - 1;
            }

            for (int a = startC; a <= endC; a++)
            {
                dt.Columns.Add(r.Columns[a].HeaderText, "string".GetType());
                lst.Add(r.Columns[a].Width);
            }
            int dt_indexR = 0;
            int dt_indexC = 0;
            for (int a = startR; a <= endR; a++)
            {
                dt.Rows.Add();

                dt_indexC = 0;
                for (int b = startC; b <= endC; b++)
                {
                    dt.Rows[dt_indexR][dt_indexC] = r.Rows[a].Cells[b].Value;
                    dt_indexC++;
                }
                dt_indexR++;
            }
        }
        //qin 20200821 start
        /// <summary>
        /// メール署名設定ボタンクリック処理
        /// ユーザメニュー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void メール署名設定CtrlMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_メール署名設定Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_メール署名設定Handle.iHandle);
                return;
            }
            メール署名設定 m_NewForm_メール署名設定 = new メール署名設定();
            m_NewForm_メール署名設定.Tag = this;
            m_NewForm_メール署名設定.m_str部署名 = "人事部";
            m_NewForm_メール署名設定.m_ログイン_ユーザ = this.m_ユーザ登録.m_ログイン_ユーザ;
            m_NewForm_メール署名設定.m_ログイン_ユーザ氏名 = this.m_ユーザ登録.m_ログイン_ユーザ氏名;
            m_NewForm_メール署名設定.m_ログイン_署名 = this.m_ユーザ登録.m_ログイン_署名;
            m_NewForm_メール署名設定.Show(this.dockPanel1);
            this.m_メール署名設定Handle.iHandle = m_NewForm_メール署名設定.Handle;
            toolStripStatusLabel1.Text = "";
        }

        //20200827 Linh add
        /// <summary>
        ///  園児情報一覧のボタンクリック処理
        ///  親のメニュー：園児管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 園児情報一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_園児情報一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_園児情報一覧Handle.iHandle);
                return;
            }
            園児情報一覧 m_NewForm園児情報一覧 = new 園児情報一覧();
            m_NewForm園児情報一覧.Tag = this;
            m_NewForm園児情報一覧.Show(this.dockPanel1);
            this.m_園児情報一覧Handle.iHandle = m_NewForm園児情報一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20200826　Linh end

        //20200902 qin start
        /// <summary>
        /// 出勤管理メニューの子項目、出勤機管理メニュー追加
        /// 出勤機管理メニューの子項目、出勤機職員一覧登録クリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 出勤機職員登録ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.m_出勤機職員登録Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_出勤機職員登録Handle.iHandle);
                return;
            }
            出勤機職員登録 m_NewForm出勤機職員登録 = new 出勤機職員登録();
            m_NewForm出勤機職員登録.Tag = this;
            m_NewForm出勤機職員登録.Show(this.dockPanel1);
            this.m_出勤機職員登録Handle.iHandle = m_NewForm出勤機職員登録.Handle;
            toolStripStatusLabel1.Text = "";
        }

        /// <summary>
        /// 出勤管理メニューの子項目、出勤機管理メニュー追加
        /// 出勤機管理メニューの子項目、出勤機職員一覧クリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 出勤機職員一覧ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.m_出勤機職員一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_出勤機職員一覧Handle.iHandle);
                return;
            }
            出勤機職員一覧 m_NewForm出勤機職員一覧 = new 出勤機職員一覧();
            m_NewForm出勤機職員一覧.Tag = this;
            m_NewForm出勤機職員一覧.Show(this.dockPanel1);
            this.m_出勤機職員一覧Handle.iHandle = m_NewForm出勤機職員一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20200902　qin end

        //20200828 LiuRui add start
        /// <summary>
        /// 入園ボタンをクリック
        /// 園児管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 入園ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_入園手続きHandle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_入園手続きHandle.iHandle);
                return;
            }

            入園手続き m_NewForm入園手続き = new 入園手続き();
            m_NewForm入園手続き.Tag = this;
            m_NewForm入園手続き.Show(this.dockPanel1);
            this.m_入園手続きHandle.iHandle = m_NewForm入園手続き.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20200828 LiuRui add end

        // 20200907 叶 add
        private void 職員入園ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_職員新規と変更Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_職員新規と変更Handle.iHandle);
                return;
            }
            職員新規と変更 m_NewForm職員新規と変更 = new 職員新規と変更(1, string.Empty);
            m_NewForm職員新規と変更.Tag = this;
            m_NewForm職員新規と変更.Show(this.dockPanel1);
            this.m_職員新規と変更Handle.iHandle = m_NewForm職員新規と変更.Handle;
            toolStripStatusLabel1.Text = "";
        }
        // 20200907 叶 end

        //　20200909 LXB　start
        /// <summary>
        /// 職員管理の子メニュー、職員情報一覧表示する画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 職員情報一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_職員情報一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_職員情報一覧Handle.iHandle);
                return;
            }
            職員情報一覧 m_NewForm職員情報一覧 = new 職員情報一覧();
            m_NewForm職員情報一覧.Tag = this;
            m_NewForm職員情報一覧.Show(this.dockPanel1);
            this.m_職員情報一覧Handle.iHandle = m_NewForm職員情報一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //　20200909 LXB　end

        //　20200911 CHW　start
        /// <summary>
        /// 業務管理メニューの子項目、小口現金出納帳登録メニュー追加
        /// 業務管理メニューの子項目、小口現金出納帳登録クリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 小口現金出納帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_小口現金出納帳Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_小口現金出納帳Handle.iHandle);
                return;
            }
            小口現金出納帳登録 m_NewForm_小口現金出納帳登録 = new 小口現金出納帳登録();
            m_NewForm_小口現金出納帳登録.Tag = this;
            m_NewForm_小口現金出納帳登録.Show(this.dockPanel1);
            this.m_小口現金出納帳Handle.iHandle = m_NewForm_小口現金出納帳登録.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //　20200911 CHW　end
        //20200923　Linh　start
        /// <summary>
        /// 職員管理メニューの子項目、職員検便記録表画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 職員検便記録表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_職員検便記録表Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_職員検便記録表Handle.iHandle);
                return;
            }
            職員検便記録表 m_NewForm_職員検便記録表 = new 職員検便記録表();
            m_NewForm_職員検便記録表.Tag = this;
            m_NewForm_職員検便記録表.Show(this.dockPanel1);
            this.m_職員検便記録表Handle.iHandle = m_NewForm_職員検便記録表.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20200923　Linh end

        //　20200923 CHW　start
        /// <summary>
        /// 業務管理メニューの子項目、小口現金出納帳一覧メニュー追加
        /// 業務管理メニューの子項目、小口現金出納帳一覧クリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 小口現金出納帳一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_小口現金出納帳一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_小口現金出納帳一覧Handle.iHandle);
                return;
            }
            小口現金出納帳一覧 m_NewForm_小口現金出納帳一覧 = new 小口現金出納帳一覧();
            m_NewForm_小口現金出納帳一覧.Tag = this;
            m_NewForm_小口現金出納帳一覧.Show(this.dockPanel1);
            this.m_小口現金出納帳一覧Handle.iHandle = m_NewForm_小口現金出納帳一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //　20200923 CHW　end

        //2020 09/24  沙丹丹 add
        /// <summary>
        ///  園児管理メニューの子項目、健康診断追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 健康診断ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.m_健康診断Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_健康診断Handle.iHandle);
                return;
            }
            園児健康診断 m_NewForm健康診断 = new 園児健康診断();
            m_NewForm健康診断.Tag = this;
            m_NewForm健康診断.Show(this.dockPanel1);
            this.m_健康診断Handle.iHandle = m_NewForm健康診断.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //2020 09/24  沙丹丹 end

        //20200929 qin add
        /// <summary>
        /// 出勤管理メニューの子項目、園児出勤一覧クリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 園児出勤一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_園児出勤一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_園児出勤一覧Handle.iHandle);
                return;
            }
            園児出勤一覧 m_NewForm_園児出勤一覧 = new 園児出勤一覧();
            m_NewForm_園児出勤一覧.Tag = this;
            m_NewForm_園児出勤一覧.Show(this.dockPanel1);
            this.m_園児出勤一覧Handle.iHandle = m_NewForm_園児出勤一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20200929 qin end

        //20201006 Lin(XY) add
        /// <summary>
        /// 出勤機エラー記録一覧画面、エラー記録追加画面クリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void エラー一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_出勤表エラー記録Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_出勤表エラー記録Handle.iHandle);
                return;
            }
            出勤表エラー記録 m_NewForm出勤表エラー記録 = new 出勤表エラー記録();
            m_NewForm出勤表エラー記録.Tag = this;
            m_NewForm出勤表エラー記録.Show(this.dockPanel1);
            this.m_出勤表エラー記録Handle.iHandle = m_NewForm出勤表エラー記録.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20201006 Lin(XY) edd

        //20201008 GJL add
        /// <summary>
        /// 職員管理メニューに、職員健康診断書一覧追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 職員健康診断書一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_職員健康診断書一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_職員健康診断書一覧Handle.iHandle);
                return;
            }
            職員健康診断書一覧 m_NewForm職員健康診断書一覧 = new 職員健康診断書一覧();
            m_NewForm職員健康診断書一覧.Tag = this;
            m_NewForm職員健康診断書一覧.Show(this.dockPanel1);
            this.m_職員健康診断書一覧Handle.iHandle = m_NewForm職員健康診断書一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20201008 GJL edd

        /// <summary>
        /// 園児管理メニューに、水泳活動参加園児一覧追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 水泳活動ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.m_水泳活動Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_水泳活動Handle.iHandle);
                return;
            }
            水泳活動参加園児一覧 m_NewForm水泳活動 = new 水泳活動参加園児一覧();
            m_NewForm水泳活動.Tag = this;
            m_NewForm水泳活動.Show(this.dockPanel1);
            this.m_水泳活動Handle.iHandle = m_NewForm水泳活動.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20201008 chenriming edd

        //　20201019 CHW　start
        /// <summary>
        /// 業務管理メニューの子項目、保育園チェックリストメニュー追加
        /// 業務管理メニューの子項目、保育園チェックリストクリック処理追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保育園チェックリストToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_保育園チェックリストHandle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_保育園チェックリストHandle.iHandle);
                return;
            }
            保育園チェックリスト m_NewForm_保育園チェックリスト = new 保育園チェックリスト();
            m_NewForm_保育園チェックリスト.Tag = this;
            m_NewForm_保育園チェックリスト.Show(this.dockPanel1);
            this.m_保育園チェックリストHandle.iHandle = m_NewForm_保育園チェックリスト.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //　20201019 CHW　end

		//20201020 tongchang add
        /// <summary>
        /// 業務管理メニューに、検食簿一覧追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 検食簿一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_検食簿一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_検食簿一覧Handle.iHandle);
                return;
            }
            検食簿一覧 m_NewForm_検食簿一覧 = new 検食簿一覧();
            m_NewForm_検食簿一覧.Tag = this;
            m_NewForm_検食簿一覧.Show(this.dockPanel1);
            this.m_検食簿一覧Handle.iHandle = m_NewForm_検食簿一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20201020 tongchang end
        private void 検食簿登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_検食簿編集Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_検食簿編集Handle.iHandle);
                return;
            }
            検食簿編集 m_NewForm_検食簿編集 = new 検食簿編集();
            m_NewForm_検食簿編集.Tag = this;
            m_NewForm_検食簿編集.Show(this.dockPanel1);
            this.m_検食簿編集Handle.iHandle = m_NewForm_検食簿編集.Handle;
        }        

        //20201022 GJL add
        /// <summary>
        /// 業務管理メニューに、日誌一覧一覧追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 日誌一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_日誌一覧NewHandle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_日誌一覧NewHandle.iHandle);
                return;
            }
            日誌一覧 m_NewForm日誌一覧New = new 日誌一覧();
            m_NewForm日誌一覧New.Tag = this;
            m_NewForm日誌一覧New.Show(this.dockPanel1);
            this.m_日誌一覧NewHandle.iHandle = m_NewForm日誌一覧New.Handle;
            toolStripStatusLabel1.Text = "";
        }
        //20201022 GJL end

        //20201028 linh start
        /// <summary>
        /// 園児管理メニューの退園追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退園ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_園児退園Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_園児退園Handle.iHandle);
                return;
            }
            園児退園 m_NewForm_園児退園 = new 園児退園();
            m_NewForm_園児退園.Tag = this;
            m_NewForm_園児退園.Show(this.dockPanel1);
            this.m_園児退園Handle.iHandle = m_NewForm_園児退園.Handle;
            toolStripStatusLabel1.Text = "";
        }

        // 20201104 LiuRui add
        /// <summary>
        /// 園児管理メニューに、新園児入園資料表出力追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新園児入園資料表出力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_新園児入園資料出力Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_新園児入園資料出力Handle.iHandle);
                return;
            }
            新園児入園資料出力 m_NewForm新園児入園資料出力 = new 新園児入園資料出力();
            m_NewForm新園児入園資料出力.Tag = this;
            m_NewForm新園児入園資料出力.StartPosition = FormStartPosition.CenterParent;
            this.m_新園児入園資料出力Handle.iHandle = m_NewForm新園児入園資料出力.Handle;
            m_NewForm新園児入園資料出力.ShowDialog();
            toolStripStatusLabel1.Text = "";
        }
        // 20201104 LiuRui end

        // 20201106 Lxy add
        /// <summary>
        /// 園児管理メニューの保育経過記録追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保育経過記録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_保育経過記録Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_保育経過記録Handle.iHandle);
                return;
            }
            園児保育経過記録 m_NewForm園児保育経過記録 = new 園児保育経過記録();
            m_NewForm園児保育経過記録.Tag = this;
            m_NewForm園児保育経過記録.Show(this.dockPanel1);
            this.m_保育経過記録Handle.iHandle = m_NewForm園児保育経過記録.Handle;
            toolStripStatusLabel1.Text = "";
        }
        // 20201106 Lxy end
        // 20201118 Lxb start
        /// <summary>
        /// 園児管理メニューの発育チェック一覧追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 園児発育チェックToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_発育チェック一覧Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(this.m_発育チェック一覧Handle.iHandle);
                return;
            }
            園児発育チェック一覧 m_NewForm_園児発育チェック一覧 = new 園児発育チェック一覧();
            m_NewForm_園児発育チェック一覧.Tag = this;
            m_NewForm_園児発育チェック一覧.Show(this.dockPanel1);
            this.m_発育チェック一覧Handle.iHandle = m_NewForm_園児発育チェック一覧.Handle;
            toolStripStatusLabel1.Text = "";
        }
        // 20201118 Lxb end
    }
}
