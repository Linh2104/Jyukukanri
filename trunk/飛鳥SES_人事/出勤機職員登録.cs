using ComDll;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public partial class 出勤機職員登録 : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        //DB接続情報
        public string connectionString = ComClass.connectionString;
       
        public 出勤機職員登録()
        {
            InitializeComponent();
        }

        private void 出勤機ユーザ登録_Load(object sender, EventArgs e)
        {
            //出勤機、職員コンボボックス値を設定する
            SetMachineComboboxList();
            SetEmployeeComboxList();
        }

        /// <summary>
        /// 出勤機コンボボックス値を設定する
        /// </summary>
        public void SetMachineComboboxList()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                sslbl_エラーメッセージ.Text = "DBサーバーの接続が失敗しました.";
                return;
            }
            try
            {
                string str_sqlcmd = "SELECT 出勤機コード,場所 FROM HL_JINJI_出勤機マスタ ORDER BY 出勤機コード";
                SqlDataAdapter sqlDa = new SqlDataAdapter(str_sqlcmd, sqlcon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                cmb_出勤機.DisplayMember = "場所";
                cmb_出勤機.ValueMember = "出勤機コード";
                cmb_出勤機.DataSource = dt;
            }
            catch (Exception ex)
            {
                sslbl_エラーメッセージ.Text = "出勤機の設定が失敗しました." + ex.Message;
                sslbl_エラーメッセージ.ForeColor = Color.Red;
            }
            sqlcon.Close();

            if (cmb_出勤機.Items.Count == 0)
            {
                sslbl_エラーメッセージ.Text = "出勤機名の取得が失敗しました.";
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                return;
            }
        }

        /// <summary>
        /// 職員コンボボックス値を設定する
        /// </summary>
        public void SetEmployeeComboxList()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                sslbl_エラーメッセージ.Text = "DBサーバーの接続が失敗しました.";
                return;
            }
            try
            {
                string sql = "select a.社員コード, a.社員コード+ '　'+ a.名前 as 名前 from HL_JINJI_社員マスタ as a" +
                    " left join HL_JINJI_出勤機_登録ユーザマスタ as b on a.社員コード= b.社員コード" +
                    " left join HL_JINJI_社員在職状態 as c on c.社員コード = a.社員コード" +
                    " where b.社員コード is null and c.職務 = '保　育' order by a.社員コード";
                SqlDataAdapter sqlDa1 = new SqlDataAdapter(sql, sqlcon);
                DataTable dt1 = new DataTable();
                sqlDa1.Fill(dt1);
                cmb_職員コード.DisplayMember = "名前";
                cmb_職員コード.ValueMember = "社員コード";
                cmb_職員コード.DataSource = dt1;　　　　　　   
            }
            catch(Exception ex)
            {
                sslbl_エラーメッセージ.Text = "職員の設定が失敗しました." + ex.Message;
                sslbl_エラーメッセージ.ForeColor = Color.Red;
            }
            sqlcon.Close();

            if (cmb_職員コード.Items.Count == 0)
            {
                sslbl_エラーメッセージ.Text = "職員データの取得が失敗しました.";
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                return;
            }
        }

        public bool Codecheck()
        {
            //エラーが発生する場合はfalse
            bool result = false;

            string code_登録コード = txt_登録コード.Text;
            if (string.IsNullOrWhiteSpace(code_登録コード))
            {
                sslbl_エラーメッセージ.Text = "登録コードが入力されていません.";
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                return result;
            }

            //登録コード存在チェック
            result = IsExistedWith登録コード(code_登録コード);

            return result;
        }

        public bool IsExistedWith登録コード(string code_登録コード)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                sqlcon.Open();
				string str_sqlcmd = string.Format(@"SELECT 登録コード FROM HL_JINJI_出勤機_登録ユーザマスタ WHERE 登録コード = {0}", code_登録コード);
                SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
                reader = com.ExecuteReader();
                if (reader.Read())
				{
                    sslbl_エラーメッセージ.Text = string.Format(@"登録コード({0})既に存在しています.", code_登録コード);
					sslbl_エラーメッセージ.ForeColor = Color.Red;
					return false;
				}
				else
				{
                    sslbl_エラーメッセージ.Text = "";
                    return true;
                }
            }
            catch
            {
                sslbl_エラーメッセージ.Text = "DBサーバーの接続が失敗しました.";
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                return false;
            }
			finally
			{
                reader.Close();
				sqlcon.Close();	
			}
        }
        private void btn_登録_Click(object sender, EventArgs e)
        {
            bool check = Codecheck();
            if(!check)
            {
                return;
            }
            SqlConnection sqlcon = new SqlConnection(connectionString);
            int result = 0;
            try
            {
                sqlcon.Open();
            }
            catch(Exception ex)
            {
                sslbl_エラーメッセージ.Text = "登録処理が失敗しました." + ex.Message;
                sslbl_エラーメッセージ.ForeColor = Color.Red;
                return;
            }
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            try
            {
                //画面値取得
                string code_出勤機 = cmb_出勤機.SelectedValue.ToString();
                string code_登録コード = txt_登録コード.Text;
                string code_職員 = cmb_職員コード.SelectedValue.ToString();
                //登録行う
                sqlcom.CommandText = string.Format(@"Insert into HL_JINJI_出勤機_登録ユーザマスタ (出勤機コード,登録コード,社員コード)Values ('{0}', '{1}', '{2}')", code_出勤機, code_登録コード, code_職員);
                result = sqlcom.ExecuteNonQuery();
                if (result == 1)
                {
                    ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Green;
                    ((Form1)(this.Tag)).toolStripStatusLabel2.Text = string.Format("({0})が正常に登録されました.", cmb_職員コード.Text);
                    if (((Form1)(this.Tag)).m_出勤機職員一覧Handle != null)
                    {
                        SendMessage(((Form1)(this.Tag)).m_出勤機職員一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);                        
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                sslbl_エラーメッセージ.Text = "登録処理が失敗しました." + ex.Message;
                sslbl_エラーメッセージ.ForeColor = Color.Red;
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }
            SetEmployeeComboxList();
            txt_登録コード.Text = "";
        }
        
        private void 出勤機職員登録_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_出勤機職員登録Handle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// ラベル文字色設定
        /// </summary>
        private void lbl_必須_Paint(object sender, PaintEventArgs e)
        {
            Label strLbl = (Label)sender;
            string str = strLbl.Text;

            if (str.Contains("必須"))
            {
                strLbl.ForeColor = Color.FromArgb(240, 240, 240);

                Font f = new Font("メイリオ", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));

                int i = str.IndexOf("　[");
                string str_name = str.Substring(0, i);
                string str必須 = str.Substring(i, str.Length - i);

                for (int x = 0; x <= i; x++)
                {
                    str必須 = "   " + str必須;
                }

                Point point = new Point(((Label)sender).Padding.Right, ((Label)sender).Padding.Top);
                TextRenderer.DrawText(e.Graphics, str必須, f, point, Color.Red);
                TextRenderer.DrawText(e.Graphics, str_name, ((Label)sender).Font, point, Color.Black);
            }
            else
            {
                strLbl.ForeColor = Color.Black;
            }
        }
    }
 }