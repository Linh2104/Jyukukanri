using ComDll;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public partial class 健康状況観察 : Form
    {
        //データベース接続情報
        private string connectionString = ComClass.connectionString;

        public string value { get; set; }
        public string childcode { get; set; }
        public string date { get; set; }
        public int result { get; set; }

        public 健康状況観察()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            if (value.Contains("機嫌"))
            {
                cmb_機嫌.Text = MidStrEx_New(value, "機嫌-", ",");
            }
            if (value.Contains("しっしん"))
            {
                cmb_しっしん.Text = MidStrEx_New(value, "しっしん-", ",");
            }
            if (value.Contains("せき・はなみず"))
            {
                cmb_せき.Text = value.Contains("その他") ? MidStrEx_New(value, "せき・はなみず-", ",") :
                                value.Substring(value.LastIndexOf("-") + 1, value.Length - value.LastIndexOf("-") - 1);
            }
            if (value.Contains("その他"))
            {
                txt_その他.Text = value.Substring(value.LastIndexOf("-") + 1, value.Length - value.LastIndexOf("-") - 1);
            }
        }

        /// <summary>
        /// 健康状況観察変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            value += !string.IsNullOrEmpty(cmb_機嫌.Text) ? "機嫌-" + cmb_機嫌.Text + ',' : string.Empty;
            value += !string.IsNullOrEmpty(cmb_しっしん.Text) ? "しっしん-" + cmb_しっしん.Text + ',' : string.Empty;
            value += !string.IsNullOrEmpty(cmb_せき.Text) ? "せき・はなみず-" + cmb_せき.Text + ',' : string.Empty;
            value += !string.IsNullOrWhiteSpace(txt_その他.Text) ? "その他-" + txt_その他.Text + ',' : string.Empty;
            value = value.EndsWith(",") ? value.Substring(0, value.Length - 1) : value;

            SqlConnection sqlcon = SQLLinkTest();
            if (sqlcon == null)
            {
                result = 0;
                this.Close();
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Transaction = transaction;
            sqlcom.Connection = sqlcon;

            try
            {
                sqlcom.CommandText = string.Format(@"Update HL_JEC_園児健康状況観察 Set チェック項目 = N'{0}' Where
                                                     園児コード = {1} and 日付 = '{2}'", value, childcode, date);

                if (sqlcom.ExecuteNonQuery() == 1)
                {
                    transaction.Commit();
                    result = 1;
                }
                else
                {
                    transaction.Rollback();
                    result = 2;
                }
            }
            catch
            {
                transaction.Rollback();
                result = 2;
            }
            finally
            {
                sqlcon?.Close();
                this.Close();
            }
        }

        /// <summary>
        /// 健康状況観察変更をキャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            result = 3;
            this.Close();
        }

        /// <summary>
        /// DBサーバーに接続が可能かどうか
        /// </summary>
        private SqlConnection SQLLinkTest()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon.Open();
                return sqlcon;
            }
            catch
            {
                sqlcon.Close();
                return null;
            }
        }

        /// <summary>
        /// 指定された文字列と文字列間の部分を抽出
        /// </summary>
        private string MidStrEx_New(string sourse, string startstr, string endstr)
        {
            Regex rg = new Regex("(?<=(" + startstr + "))[.\\s\\S]*?(?=(" + endstr + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(sourse).Value;
        }
    }
}
