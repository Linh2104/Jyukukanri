using ComDll;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace 飛鳥SES_人事
{
    public partial class 園児発育チェック一覧 : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        private string connectionString = ComClass.connectionString;
        public 園児発育チェック一覧()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message msg)
        {
            try
            {
                switch (msg.Msg)
                {
                    case ComClass.CUSTOM_MESSAGE:
                        {
                            DisplayGridView();
                        }
                        break;

                    default:
                        base.WndProc(ref msg);
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void DisplayGridView()
        {
            //メッセージをクリアする
            this.toolStripStatusLabel1.Text = "";

            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました.";

                return;
            }
            string str_sqlcmd = @"select distinct  a.名前,a.フリガナ,a.性別,b.胸囲,b.頭囲,b.栄養状況,b.身長,b.体重,b.測定日
                                                from 
                                                        HL_JEC_園児情報マスタ a  
                                                inner join    
                                                        HL_JEC_園児発育状況 b  on a.園児コード = b.園児コード
                                                order by　b.測定日　ASC ";


            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);    
            SqlDataReader reader = com.ExecuteReader();
            this.dgv_園児発育現状.Rows.Clear();
            int index = 0;
            try
            {
                while (reader.Read())
                {
                    this.dgv_園児発育現状.Rows.Add();
                    this.dgv_園児発育現状.Rows[index].Cells["名前"].Value = reader["名前"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["フリガナ"].Value = reader["フリガナ"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["性別"].Value = reader["性別"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["胸囲"].Value = reader["胸囲"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["頭囲"].Value = reader["頭囲"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["栄養状況"].Value = reader["栄養状況"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["身長"].Value = reader["身長"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["体重"].Value = reader["体重"].ToString();
                    this.dgv_園児発育現状.Rows[index].Cells["測定日"].Value = reader["測定日"].ToString().Equals("") ? "-" : reader["測定日"].ToString();

                    if (this.dgv_園児発育現状.Rows[index].Cells["測定日"].Value.ToString() == "-")
                    {
                        this.dgv_園児発育現状.Rows[index].Cells["測定日"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
                this.toolStrip1.Text = string.Format("{0}件", index);
            }
        }

        private void 園児発育チェック一覧_Load(object sender, EventArgs e)
        {
            //this.cmb_入園年度.SelectedIndex = 0;
            DisplayGridView();
        }

        private void 園児発育チェック一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_発育チェック一覧Handle.iHandle = IntPtr.Zero;
        }

        private void 体重身長入力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvRow;

            dgvRow = dgv_園児発育現状.SelectedRows[0];

            if (((Form1)(this.Tag)).m_園児発育チェック曲線図画面Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(((Form1)(this.Tag)).m_園児発育チェック曲線図画面Handle.iHandle);
                return;
            }

            園児発育チェック曲線図画面 NewForm_園児発育チェック曲線図画面 = new 園児発育チェック曲線図画面();

            NewForm_園児発育チェック曲線図画面.Tag = ((Form1)(this.Tag));
            NewForm_園児発育チェック曲線図画面.ename = dgvRow.Cells["名前"].Value.ToString();
            NewForm_園児発育チェック曲線図画面.Show();

            ((Form1)(this.Tag)).m_健康診断Handle.iHandle = NewForm_園児発育チェック曲線図画面.Handle;
            toolStripStatusLabel1.Text = "";
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //メニューの箇所設定
            System.Drawing.Point startPosition = Cursor.Position;
            System.Drawing.Point point = this.dgv_園児発育現状.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.dgv_園児発育現状.HitTest(point.X, point.Y);

            this.dgv_園児発育現状.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                this.dgv_園児発育現状.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmb_入園年度_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_園児検索_Click(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        private void 発育チェック登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((Form1)(this.Tag)).m_園児発育チェック登録画面Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(((Form1)(this.Tag)).m_園児発育チェック登録画面Handle.iHandle);
                return;
            }

            園児発育チェック登録 NewForm_m_園児発育チェック登録画面 = new 園児発育チェック登録(this);

            NewForm_m_園児発育チェック登録画面.Tag = ((Form1)(this.Tag));
            NewForm_m_園児発育チェック登録画面.Show();

            ((Form1)(this.Tag)).m_園児発育チェック登録画面Handle.iHandle = NewForm_m_園児発育チェック登録画面.Handle;
            toolStripStatusLabel1.Text = "";
        }
    }
}
