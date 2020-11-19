using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using ComDll;

namespace 飛鳥SES_人事
{
    public partial class 出勤記録新規追加 : Form
    {
        private string m_出勤機コード = "";
        private string m_登録コード = "";
        public DataGridViewRow m_dgvRow = null;
        //private string connectionString = "Integrated Security=TRUE; Server=DESKTOP-L97HM3B\\SQLEXPRESS; Database=oa; Connection Timeout=60";
        private string connectionString = ComClass.connectionString;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref 出勤記録新規追加STRUCT lParam);

        public 出勤記録新規追加()
        {
            InitializeComponent();
            EmployeeListGet();
            DateClear();
            this.rbtn_Attflg01.Select();
        }

        #region 職員コード選択肢取得

        /// <summary>
        /// 職員コード選択肢(List)取得、フォーマット（社員コードプラス全角スペースプラン名前）
        /// </summary>

        private void EmployeeListGet()
        {
            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            if (!Sqlconnection(conn))
            {
                return;
            }

            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" select * from HL_JINJI_出勤機_登録ユーザマスタ a  ");
                stringBuilder.Append(@" inner join HL_JINJI_社員マスタ b ");
                stringBuilder.Append(@" on a.社員コード = b.社員コード ");
                stringBuilder.Append(@" and 退職日 is NULL ");
                stringBuilder.Append(@" and a.出勤機コード = 1 ");

                SqlCommand com = new SqlCommand(stringBuilder.ToString(), conn);

                SqlDataReader reader = com.ExecuteReader();

                this.cmb_Employee.Items.Clear();

                while (reader.Read())
                {
                    this.cmb_Employee.Items.Add(reader["社員コード"].ToString() + " " + reader["名前"].ToString());
                }

                if (this.cmb_Employee.Items.Count > 0)
                {
                    this.cmb_Employee.SelectedIndex = 0;
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "職員Listの取得が失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return;
            }            
        }

        #endregion

        #region 出退勤時間をシステム時間に変更します。

        public void DateClear()
        {
            this.txt_AddDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        #endregion

        #region 出退勤時間をチェックします。

        private bool DateErrorCheck()
        {
            if (this.txt_AddDateTime.Text.Equals(""))
            {
                this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                this.sslbl_エラーメッセージ.Text = "出退勤時間未入力.";
                return false;
            }

            try
            {
                DateTime dateTime = DateTime.Parse(this.txt_AddDateTime.Text);

                if (string.Compare(dateTime.ToString("yyyyMMddHHmmss"), DateTime.Now.ToString("yyyyMMddHHmmss")) >= 1)
                {
                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                    this.sslbl_エラーメッセージ.Text = "過去の時間を入力してください.";
                    return false;
                }
            }
            catch
            {
                this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                this.sslbl_エラーメッセージ.Text = "正しい時間を入力してください.";

                return false;
            }

            return true;
        }

        #endregion

        #region 出勤機コード、登録コードを取得します。

        private void GetInsertCode (string employeeCode)
        {
            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            if (!Sqlconnection(conn))
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(@" select top 1 * from HL_JINJI_出勤機_登録ユーザマスタ ");
            stringBuilder.Append(@" where 社員コード = '").Append(employeeCode).Append(@"' ");

            string str_sqlcmd = string.Format(@"select top 1 * from HL_JINJI_出勤機_登録ユーザマスタ where 社員コード = '{0}'", employeeCode);

            SqlCommand com = new SqlCommand(str_sqlcmd, conn);

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                m_出勤機コード = reader["出勤機コード"].ToString();

                m_登録コード = reader["登録コード"].ToString();
            }

            reader.Close();
            conn.Close();
        }

        #endregion

        #region 出退勤記録登録する。

        private bool DataInsert()
        {
            if (DateErrorCheck() == false)
            {
                return false;
            }

            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            if (!Sqlconnection(conn))
            {
                return false;
            }

            DateTime dateTime = DateTime.Parse(this.txt_AddDateTime.Text);

            GetInsertCode(this.cmb_Employee.Text.Split(' ')[0]);

            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" delete HL_JINJI_出勤機元記録 ");
                stringBuilder.Append(@" where 出勤機コード = '").Append(this.m_出勤機コード).Append(@"' ");
                stringBuilder.Append(@" and 登録コード = ").Append(this.m_登録コード).Append(@" ");
                stringBuilder.Append(@" and 出退勤時間 = '").Append(dateTime).Append(@"' ");

                stringBuilder.Append(@" Insert Into HL_JINJI_出勤機元記録 ");
                stringBuilder.Append(@" Values('").Append(this.m_出勤機コード).Append(@"' ");
                stringBuilder.Append(@" , '").Append(this.m_登録コード).Append(@"' ");
                stringBuilder.Append(@" , ").Append(this.rbtn_Attflg01.Checked ? 0 : 1).Append(@" ");
                stringBuilder.Append(@" , '").Append(dateTime).Append(@"') ");

                stringBuilder.Append(@" delete HL_JINJI_出勤機ダウンロード記録 ");
                stringBuilder.Append(@" where 出勤機コード = '").Append(this.m_出勤機コード).Append(@"' ");
                stringBuilder.Append(@" and 登録コード = ").Append(this.m_登録コード).Append(@" ");
                stringBuilder.Append(@" and 年 = '").Append(dateTime.Year).Append(@"' ");
                stringBuilder.Append(@" and 月 = '").Append(dateTime.Month).Append(@"' ");
                stringBuilder.Append(@" and 日 = '").Append(dateTime.Day).Append(@"' ");

                stringBuilder.Append(@" insert into HL_JINJI_出勤機ダウンロード記録 ");
                stringBuilder.Append(@" values('").Append(this.m_出勤機コード).Append(@"' ");
                stringBuilder.Append(@" , '").Append(this.m_登録コード).Append(@"' ");
                stringBuilder.Append(@" ,'").Append(dateTime.Year).Append(@"' ");
                stringBuilder.Append(@" ,'").Append(dateTime.Month).Append(@"' ");
                stringBuilder.Append(@" ,'").Append(dateTime.Day).Append(@"','新規') ");

                string sql = stringBuilder.ToString();

                SqlCommand com = new SqlCommand(sql, conn);

                com.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "出勤記録の登録が失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
            }                            
        }

        #endregion

        #region サーバーがつなげます。

        private bool Sqlconnection(SqlConnection conn)
        {
            try
            {
                conn.Open();

                return true;
            }
            catch
            {
                this.sslbl_エラーメッセージ.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
            }
        }

        #endregion

        #region イベント

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            EmployeeListGet();
            DateClear();
            this.rbtn_Attflg01.Select();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (DataInsert())
            {
                出勤表エラー記録.pCurrentWin.adddateValue = txt_AddDateTime.Text;

                this.Close();

                出勤表エラー記録.pCurrentWin.AddBacked();
            }           
        }

        #endregion        
    }
}
