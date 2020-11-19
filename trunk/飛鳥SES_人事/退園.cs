using ComDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using 飛鳥SES_人事;

namespace 飛鳥SES_人事
{
    public partial class 退園 : Form
    {
        //DB接続用
        private string connectionString = ComClass.connectionString;
        private string strcode = "";
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        職員情報一覧 formowner;
        private string str_name = "";
        public 退園()
        {
            InitializeComponent();
        }

        public 退園(string code,string name,string 職名,職員情報一覧 owner)
        {
            InitializeComponent();
            strcode = code;
            txt_園内職務.Text = 職名;
            txt_職員.Text = code + "　" + name;
            str_name = txt_職員.Text;
            formowner = owner;
        }

        private void btn_キャンセル_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_退園_Click(object sender, EventArgs e)
        {
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

            try
            {
                string str_sqlcmd = string.Format(@"DELETE FROM   HL_JEC_職員情報                                                     
                                                 where 職員コード = {0}", strcode);

                SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
                int relust = com.ExecuteNonQuery();
                
                if (relust == 1)
                {
                    SendMessage(((Form1)(this.Tag)).m_職員情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero).ToInt64();
                    this.Close();

                    if (formowner != null)
                    {
                        formowner.toolStripStatusLabel1.ForeColor = Color.Green;
                        formowner.toolStripStatusLabel1.Text = string.Format("{0} さんの退園処理正常に完了しました。", str_name);
                    }
                }
                else
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = string.Format("{0} さんの退園処理実施失敗しました。", str_name);
                }
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "退園処理に失敗しました.";

                return;
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void 退園_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_職員退園Handle.iHandle = IntPtr.Zero;
        }
    }
}
