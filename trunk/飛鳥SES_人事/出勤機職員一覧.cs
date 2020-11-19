using ComDll;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace 飛鳥SES_人事
{
    public partial class 出勤機職員一覧 : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        private string connectionString = ComClass.connectionString;

        public 出勤機職員一覧()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message msg)
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
        private void 出勤機職員一覧_Load(object sender, EventArgs e)
        {
            //一覧表示
            DisplayGridView();
        }

        /// <summary>
        /// 初期表示
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayGridView()
        {
            //メッセージをクリアする
            this.toolStripStatusLabel1.Text = "";
            //画面値を取得
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました.";
                this.toolStrip1.Text = string.Format("{0}件", 0);
                return;
            } 
            string str_sqlcmd = @"SELECT Distinct c.場所, a.登録コード, a.社員コード, b.名前 as 社員名 ,d.職務　FROM HL_JINJI_出勤機_登録ユーザマスタ a
                                  Left Join HL_JINJI_社員マスタ b on a.社員コード = b.社員コード          
                                  Left Join HL_JINJI_出勤機マスタ c on a.出勤機コード = c.出勤機コード 
                                  Left Join HL_JINJI_社員在職状態 d on d.社員コード　= a.社員コード
                                  WHERE  d.職務 = '保　育' ORDER BY  a.登録コード";          
          
            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            this.gridView_出勤機職員.Rows.Clear();
            int index = 0;
            try
            {
                while (reader.Read())
                {
                    if (
                        (reader["場所"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["登録コード"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["社員コード"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["社員名"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["職務"].ToString().IndexOf(this.txt_search.Text) < 0)
                        )
                    {
                        continue;
                    }
                    this.gridView_出勤機職員.Rows.Add();
                    this.gridView_出勤機職員.Rows[index].Cells["出勤機"].Value = reader["場所"].ToString();
                    this.gridView_出勤機職員.Rows[index].Cells["登録コード"].Value = reader["登録コード"].ToString();
                    this.gridView_出勤機職員.Rows[index].Cells["職員コード"].Value = reader["社員コード"].ToString();
                    this.gridView_出勤機職員.Rows[index].Cells["職員名"].Value = reader["社員名"].ToString();
                    this.gridView_出勤機職員.Rows[index].Cells["職務"].Value = reader["職務"].ToString();
                    index++;
                }
            }
            catch(Exception ex)
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

        /// <summary>
        /// 検索ボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_search_Click(object sender, EventArgs e)
        {
            DisplayGridView();
        }

      　/// <summary>
        /// フォームを閉める処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 出勤機職員一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_出勤機職員一覧Handle.iHandle = IntPtr.Zero;
        }
       
        /// <summary>
        /// 選択行のデータを削除する処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView_出勤機職員.CurrentCell != null)
            {
                this.gridView_出勤機職員.CurrentCell.Selected = true;
                string code_登録コード = this.gridView_出勤機職員.CurrentRow.Cells["登録コード"].Value.ToString();

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
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlcon;

                try
                {
                    //削除行う
                    sqlcom.CommandText = string.Format(@"Delete From HL_JINJI_出勤機_登録ユーザマスタ Where 登録コード = '{0}'", code_登録コード);
                    int result = sqlcom.ExecuteNonQuery();

                    if (result == 1)
                    {
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        this.toolStripStatusLabel1.Text = string.Format(@"{0}を正常に削除しました", this.gridView_出勤機職員.CurrentRow.Cells["職員名"].Value);
                    }
                }
                catch
                {
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                    this.toolStripStatusLabel1.Text = string.Format(@"{0}の削除処理が失敗しました", this.gridView_出勤機職員.CurrentRow.Cells["職員名"].Value);
                }
                finally
                {
                    if (sqlcon != null)
                    {
                        sqlcon.Close();
                    }
                }

                this.gridView_出勤機職員.Rows.Remove(this.gridView_出勤機職員.CurrentRow);
                this.toolStrip1.Text = string.Format("{0}件", this.gridView_出勤機職員.RowCount);
            }
        }

        /// <summary>
        /// 右クリックするとメニューを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point startPosition = Cursor.Position;

            Point point = this.gridView_出勤機職員.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.gridView_出勤機職員.HitTest(point.X, point.Y);

            this.gridView_出勤機職員.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                this.gridView_出勤機職員.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        
    }
}
