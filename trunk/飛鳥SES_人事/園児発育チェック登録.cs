using ComDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public partial class 園児発育チェック登録 : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        園児発育チェック一覧 ownerform;

        //DB接続用
        private string connectionString = ComClass.connectionString;
        private string strcode;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public 園児発育チェック登録()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public 園児発育チェック登録(園児発育チェック一覧 owner)
        {
            InitializeComponent();
            ownerform = owner;
        }

        /// <summary>
        /// 登録ボダン押下より登録処理する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_add_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库

            if (cmb_id.Text.Trim()==""|| txt_胸囲.Text.Trim() == ""|| txt_頭囲.Text.Trim() == ""|| cmb_栄養状況.Text.Trim() == ""|| txt_身長.Text.Trim() == ""|| txt_体重.Text.Trim() == "")
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "すべで項目を入力してから、登録をしてください。";
                return;
            }
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
                string str_sqlcmd = string.Format(@"INSERT INTO  HL_JEC_園児発育状況 
                                                    (園児コード,胸囲,頭囲,栄養状況,身長,体重,更新日)                                               
                                                    VALUES ({0},{1},{2},'{3}',{4},{5},'{6}')",
                                                    cmb_id.Text.Split(new char[] { '　' }, StringSplitOptions.RemoveEmptyEntries)[0],
                                                    txt_胸囲.Text,
                                                    txt_頭囲.Text,
                                                    cmb_栄養状況.Text,
                                                    txt_身長.Text,
                                                    txt_体重.Text,
                                                    datetime.Value.ToShortDateString());

                SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
                int relust = com.ExecuteNonQuery();

                if (relust == 1)
                {
                    if (ownerform != null)
                    {
                        SendMessage(((Form1)(this.Tag)).m_発育チェック一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero).ToInt64();

                        ownerform.toolStripStatusLabel1.ForeColor = Color.Green;
                        ownerform.toolStripStatusLabel1.Text = string.Format("{0} さんの登録処理実施成功しました。", cmb_id.Text);
                        this.Close();
                    }
                }
                else
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = string.Format("{0} さんの登録処理実施失敗しました。", cmb_id.Text);
                }
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "登録処理に失敗しました.";

                return;
            }
            finally
            {
                sqlcon.Close();
            }
        }

        /// <summary>
        /// 園児コンボボックスの項目取得
        /// </summary>
        public void CodeInit()
        {

            //connectionString = ComClass.connectionString;
            SqlConnection connection = new SqlConnection(connectionString); //连接数据库
            SqlDataReader reader = null;

            try
            {
                
                string str_sqlcmd = string.Format(@"select a.園児コード, a.名前 from  HL_JEC_園児情報マスタ a");
                connection.Open();
                SqlCommand com = new SqlCommand(str_sqlcmd, connection);

                reader = com.ExecuteReader();

                this.cmb_id.Items.Clear();

                while (reader.Read())
                {
                    this.cmb_id.Items.Add(reader["園児コード"].ToString() + "　" + reader["名前"].ToString());
                }

                if (this.cmb_id.Items.Count > 0)
                {
                    this.cmb_id.SelectedIndex = -1;
                }
                else if (this.cmb_id.Items.Count > 0 )
                {
                    this.cmb_id.SelectedIndex = 0;
                    cmb_id.Enabled = false;
                }


            }
            catch (Exception)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";

            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }
        }
        /// <summary>
        /// 画面閉じる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面ロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 園児発育チェック登録_Load(object sender, EventArgs e)
        {
            //　園児コード+名前を取得する
            CodeInit();           
            strcode = cmb_id.Text;
        }

        private void 園児発育チェック登録_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_園児発育チェック登録画面Handle.iHandle = IntPtr.Zero;
        }
    }
}
