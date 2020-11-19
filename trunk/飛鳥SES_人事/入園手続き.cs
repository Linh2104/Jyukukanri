using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using ComDll;
using Excel = Microsoft.Office.Interop.Excel;

namespace 飛鳥SES_人事
{
    public partial class 入園手続き : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        [DllImport("kernel32.dll")]
        private static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        //プロセスID
        private static int pid = 0;
        private static IntPtr hwnd;
        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_VM_WRITE = 0x0020;

        //Excel
        private static Excel.Application excelApp = null;
        private static Excel.Workbook excelBook = null;
        private static Excel.Worksheet excelSheet = null;
        private static Excel.Range excelRange = null;

        //DB接続
        private string connectionString = ComClass.connectionString;

        private int result { get; set; }
        private int 園児コード { get; set; }

        //画面項目・材料UpLoad
        private string str_入園登録 = string.Empty;
        private string str_母子手帳 = string.Empty;
        private string str_健康保険 = string.Empty;
        private string str_医療証 = string.Empty;
        private string str_健康診断 = string.Empty;
        private string str_緊急連絡 = string.Empty;
        private string str_児童調査 = string.Empty;
        private string str_健康調査 = string.Empty;
        private string str_利用報告 = string.Empty;
        private string str_撮影契約 = string.Empty;
        private string str_個人情報 = string.Empty;
        private string str_共済給付 = string.Empty;

        //画面項目・基本情報
        private string str_名前 = string.Empty;
        private string str_フリガナ = string.Empty;
        private string str_性別 = string.Empty;
        private string str_生年月日 = string.Empty;
        private string str_電話番号 = string.Empty;
        private string str_郵便番号 = string.Empty;
        private string str_メール = string.Empty;
        private string str_住所 = string.Empty;
        private string str_登園 = string.Empty;
        private string str_コース = string.Empty;
        private string str_備考 = string.Empty;

        //画面項目・緊急連絡先
        private string str_氏名1 = string.Empty;
        private string str_続柄1 = string.Empty;
        private string str_電話番号1 = string.Empty;
        private string str_勤務先1 = string.Empty;
        private string str_氏名2 = string.Empty;
        private string str_続柄2 = string.Empty;
        private string str_電話番号2 = string.Empty;
        private string str_勤務先2 = string.Empty;
        private string str_氏名3 = string.Empty;
        private string str_続柄3 = string.Empty;
        private string str_電話番号3 = string.Empty;
        private string str_勤務先3 = string.Empty;
        private string str_氏名4 = string.Empty;
        private string str_続柄4 = string.Empty;
        private string str_電話番号4 = string.Empty;
        private string str_勤務先4 = string.Empty;

        //画面項目・健康情報
        private string str_平熱 = string.Empty;
        private string str_ひきつけ = string.Empty;
        private string str_呼吸 = string.Empty;
        private string str_食物 = string.Empty;
        private string str_その他 = string.Empty;
        private string str_既往症 = string.Empty;
        private string str_詳細 = string.Empty;

        public 入園手続き()
        {
            InitializeComponent();
        }

        private void 入園手続き_Load(object sender, EventArgs e)
        {
            Step1Change();
        }

        private void 入園手続き_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_入園手続きHandle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// 次へ・登録ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "次へ" && UpLoadチェック())
            {
                Data読み取り(txt_入園登録.Text);
                Step2Change();
                return;
            }
            if (btn_save.Text == "登　録")
            {
                //画面項目読み取り
                Step1読み取り();
                Step2読み取り();

                //画面項目チェック
                if (!園児情報チェック() || !緊急連絡先チェック() || !健康情報チェック())
                {
                    return;
                }

                //データベースへ接続
                SqlConnection sqlcon = new SqlConnection(connectionString); 
                SqlCommand sqlcom = new SqlCommand();
                
                try
                {
                    sqlcon.Open();
                }
                catch
                {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                    return;
                }

                SqlTransaction transaction = sqlcon.BeginTransaction();
                sqlcom.Connection = sqlcon;
                sqlcom.Transaction = transaction;

                //園児情報登録
                Insert園児情報マスタ(sqlcom);
                if (result == 1)
                {
                    transaction.Commit();
                    ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Green;
                    ((Form1)(this.Tag)).toolStripStatusLabel2.Text = string.Format(@"名前：{0}の情報が正常に登録しました。", str_名前);

                    if (((Form1)(this.Tag)).m_園児情報一覧Handle != null)
                    {
                        SendMessage(((Form1)(this.Tag)).m_園児情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                    }
                    this.Close();
                }
                else
                {
                    transaction.Rollback();
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = string.Format(@"名前：{0}の登録処理に失敗しました。", str_名前);
                }

                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }
        }

        /// <summary>
        /// 戻るボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_back_Click(object sender, EventArgs e)
        {
            Step1Change();
        }

        /// <summary>
        /// キャンセルボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 園児情報マスタに登録
        /// </summary>
        /// <param name="sqlcom">SQLコマンド</param>
        private void Insert園児情報マスタ(SqlCommand sqlcom)
        {
            try
            {
                sqlcom.CommandText = string.Format(@"Insert Into HL_JEC_園児情報マスタ Values" +
                                     "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},null)",
                                     str_名前, str_性別, str_フリガナ, str_生年月日, str_電話番号,
                                     str_郵便番号, str_住所, str_メール, str_登園, str_コース, str_備考);

                result = sqlcom.ExecuteNonQuery();
                if (result == 1)
                {
                    Select園児コード(sqlcom);
                }
            }
            catch
            {
                result = 0;
            }
        }

        /// <summary>
        /// 園児コード取得
        /// </summary>
        /// <param name="sqlcom">SQLコマンド</param>
        private void Select園児コード(SqlCommand sqlcom)
        {
            try
            {
                sqlcom.CommandText = string.Format("Select 園児コード From HL_JEC_園児情報マスタ " +
                                     "Where 名前 = '{0}' And 電話番号 = '{1}'", str_名前, str_電話番号);

                SqlDataReader reader = sqlcom.ExecuteReader();
                if (reader.Read())
                {
                    園児コード = int.Parse(reader["園児コード"].ToString());
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                reader.Close();

                if (result == 1)
                {
                    Insert緊急連絡先(sqlcom);
                }
            }
            catch
            {
                result = 0;
            }
        }

        /// <summary>
        /// 園児緊急連絡先に登録
        /// </summary>
        /// <param name="sqlcom">SQLコマンド</param>
        private void Insert緊急連絡先(SqlCommand sqlcom)
        {
            try
            {
                sqlcom.CommandText = string.Format(@"Insert Into HL_JEC_園児緊急連絡先 Values" +
                                     "({0},'{1}','{2}','{3}','{4}',{5},{6},{7},{8}," +
                                     "{9},{10},{11},{12},{13},{14},{15},{16})",
                                     園児コード, str_氏名1, str_続柄1, str_電話番号1, str_勤務先1,
                                     str_氏名2, str_続柄2, str_電話番号2, str_勤務先2,
                                     str_氏名3, str_続柄3, str_電話番号3, str_勤務先3,
                                     str_氏名4, str_続柄4, str_電話番号4, str_勤務先4);

                result = sqlcom.ExecuteNonQuery(); 
                if (result == 1)
                {
                    Insert園児健康情報(sqlcom);
                }
            }
            catch
            {
                result = 0;
            }
        }

        /// <summary>
        /// 園児健康情報に登録
        /// </summary>
        /// <param name="sqlcom">SQLコマンド</param>
        private void Insert園児健康情報(SqlCommand sqlcom)
        {
            try
            {
                sqlcom.CommandText = string.Format(@"Insert Into HL_JEC_園児健康情報 Values" +
                                     "({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7})",
                                     園児コード, str_平熱, str_ひきつけ, str_呼吸, str_食物, str_その他, str_既往症, str_詳細);

                result = sqlcom.ExecuteNonQuery();
                if (result == 1)
                {
                    Insert園児入園材料(sqlcom);
                }
            }
            catch
            {
                result = 0;
            }
        }

        /// <summary>
        /// 園児入園材料に登録
        /// </summary>
        /// <param name="sqlcom">SQLコマンド</param>
        private void Insert園児入園材料(SqlCommand sqlcom)
        {
            string sql_入園登録 = "@入園登録申込書ファイル,@入園登録申込書ファイル名,";
            string sql_母子手帳 = "null,null,";
            string sql_健康保険 = "null,null,";
            string sql_医療証 = "null,null,";
            string sql_健康診断 = "null,null,";
            string sql_緊急連絡 = "null,null,";
            string sql_児童調査 = "null,null,";
            string sql_健康調査 = "null,null,";
            string sql_利用報告 = "null,null,";
            string sql_撮影契約 = "null,null,";
            string sql_個人情報 = "null,null,";
            string sql_共済給付 = "null,null";

            if (!string.IsNullOrWhiteSpace(str_母子手帳))
            {
                sql_母子手帳 = "@母子手帳ファイル,@母子手帳ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_健康保険))
            {
                sql_健康保険 = "@健康保険ファイル,@健康保険ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_医療証))
            {
                sql_医療証 = "@医療証ファイル,@医療証ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_健康診断))
            {
                sql_健康診断 = "@登園前健康診断ファイル,@登園前健康診断ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_緊急連絡))
            {
                sql_緊急連絡 = "@緊急連絡電話表ファイル,@緊急連絡電話表ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_児童調査))
            {
                sql_児童調査 = "@児童調査票ファイル,@児童調査票ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_健康調査))
            {
                sql_健康調査 = "@健康調査票ファイル,@健康調査票ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_利用報告))
            {
                sql_利用報告 = "@保育事業利用報告書ファイル,@保育事業利用報告書ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_撮影契約))
            {
                sql_撮影契約 = "@撮影契約書ファイル,@撮影契約書ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_個人情報))
            {
                sql_個人情報 = "@個人情報取扱同意書ファイル,@個人情報取扱同意書ファイル名,";
            }
            if (!string.IsNullOrWhiteSpace(str_共済給付))
            {
                sql_共済給付 = "@共済給付制度同意書ファイル,@共済給付制度同意書ファイル名,";
            }

            try
            {
                sqlcom.CommandText = string.Format(@"Insert Into HL_JEC_園児入園材料 Values" +
                                     "({0},{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12})",
                                     園児コード, sql_入園登録, sql_母子手帳, sql_健康保険, sql_医療証, sql_健康診断, sql_緊急連絡, 
                                     sql_児童調査, sql_健康調査, sql_利用報告, sql_撮影契約, sql_個人情報, sql_共済給付);

                sqlcom.Parameters.AddWithValue("@入園登録申込書ファイル名", Path.GetFileName(str_入園登録));
                sqlcom.Parameters.AddWithValue("@入園登録申込書ファイル", File.ReadAllBytes(str_入園登録));

                if (!string.IsNullOrWhiteSpace(str_母子手帳))
                {
                    sqlcom.Parameters.AddWithValue("@母子手帳ファイル名", Path.GetFileName(str_母子手帳));
                    sqlcom.Parameters.AddWithValue("@母子手帳ファイル", File.ReadAllBytes(str_母子手帳));
                }
                if (!string.IsNullOrWhiteSpace(str_健康保険))
                {
                    sqlcom.Parameters.AddWithValue("@健康保険ファイル名", Path.GetFileName(str_健康保険));
                    sqlcom.Parameters.AddWithValue("@健康保険ファイル", File.ReadAllBytes(str_健康保険));
                }
                if (!string.IsNullOrWhiteSpace(str_医療証))
                {
                    sqlcom.Parameters.AddWithValue("@医療証ファイル名", Path.GetFileName(str_医療証));
                    sqlcom.Parameters.AddWithValue("@医療証ファイル", File.ReadAllBytes(str_医療証));
                }
                if (!string.IsNullOrWhiteSpace(str_健康診断))
                {
                    sqlcom.Parameters.AddWithValue("@登園前健康診断ファイル名", Path.GetFileName(str_健康診断));
                    sqlcom.Parameters.AddWithValue("@登園前健康診断ファイル", File.ReadAllBytes(str_健康診断));
                }
                if (!string.IsNullOrWhiteSpace(str_緊急連絡))
                {
                    sqlcom.Parameters.AddWithValue("@緊急連絡電話表ファイル名", Path.GetFileName(str_緊急連絡));
                    sqlcom.Parameters.AddWithValue("@緊急連絡電話表ファイル", File.ReadAllBytes(str_緊急連絡));
                }
                if (!string.IsNullOrWhiteSpace(str_児童調査))
                {
                    sqlcom.Parameters.AddWithValue("@児童調査票ファイル名", Path.GetFileName(str_児童調査));
                    sqlcom.Parameters.AddWithValue("@児童調査票ファイル", File.ReadAllBytes(str_児童調査));
                }
                if (!string.IsNullOrWhiteSpace(str_健康調査))
                {
                    sqlcom.Parameters.AddWithValue("@健康調査票ファイル名", Path.GetFileName(str_健康調査));
                    sqlcom.Parameters.AddWithValue("@健康調査票ファイル", File.ReadAllBytes(str_健康調査));
                }
                if (!string.IsNullOrWhiteSpace(str_利用報告))
                {
                    sqlcom.Parameters.AddWithValue("@保育事業利用報告書ファイル名", Path.GetFileName(str_利用報告));
                    sqlcom.Parameters.AddWithValue("@保育事業利用報告書ファイル", File.ReadAllBytes(str_利用報告));
                }
                if (!string.IsNullOrWhiteSpace(str_撮影契約))
                {
                    sqlcom.Parameters.AddWithValue("@撮影契約書ファイル名", Path.GetFileName(str_撮影契約));
                    sqlcom.Parameters.AddWithValue("@撮影契約書ファイル", File.ReadAllBytes(str_撮影契約));
                }
                if (!string.IsNullOrWhiteSpace(str_個人情報))
                {
                    sqlcom.Parameters.AddWithValue("@個人情報取扱同意書ファイル名", Path.GetFileName(str_個人情報));
                    sqlcom.Parameters.AddWithValue("@個人情報取扱同意書ファイル", File.ReadAllBytes(str_個人情報));
                }
                if (!string.IsNullOrWhiteSpace(str_共済給付))
                {
                    sqlcom.Parameters.AddWithValue("@共済給付制度同意書ファイル名", Path.GetFileName(str_共済給付));
                    sqlcom.Parameters.AddWithValue("@共済給付制度同意書ファイル", File.ReadAllBytes(str_共済給付));
                }

                result = sqlcom.ExecuteNonQuery(); ;
            }
            catch
            {
                result = 0;
            }
        }

        /// <summary>
        /// 園児情報チェック
        /// </summary>
        private bool 園児情報チェック()
        {
            if (Nameチェック(txt_名前) &&
                Nameチェック(txt_フリガナ) &&
                生年月日チェック() &&
                電話番号チェック(txt_電話番号) &&
                郵便番号チェック() &&
                メールチェック() &&
                IsNo空白(txt_住所) &&
                コースチェック() &&
                Nameチェック(txt_氏名1) &&
                IsNo空白(txt_続柄1) &&
                電話番号チェック(txt_電話番号1) &&
                IsNo空白(txt_勤務先1)&&
                登園開始日チェック(dtp_登園.Value.ToString("yyyy/MM/dd")))
            {
                lbl_error.ForeColor = Color.Black;
                lbl_error.Text = string.Empty;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 緊急連絡先チェック
        /// </summary>
        private bool 緊急連絡先チェック()
        {
            TextBox[] txt = { txt_氏名2, txt_氏名3, txt_氏名4, txt_電話番号2, txt_電話番号3, txt_電話番号4 };

            foreach (TextBox item in txt)
            {
                if (IsNo空白(item))
                {
                    switch (item.Name.Replace("txt_", ""))
                    {
                        case "氏名2":
                        case "氏名3":
                        case "氏名4":
                            if (!Nameチェック(item))
                            {
                                return false;
                            }
                            break;
                        case "電話番号2":
                        case "電話番号3":
                        case "電話番号4":
                            if (!電話番号チェック(item))
                            {
                                return false;
                            }
                            break;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 健康情報チェック
        /// </summary>
        private bool 健康情報チェック()
        {
            if (!IsNo空白(txt_平熱))
            {
                return false;
            }
            if (!Is数字(txt_平熱.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "平熱に数字のみを入力してください!";
                return false;
            }
            if (rb_有ひき.Checked || rb_有呼吸.Checked || rb_有食物.Checked || rb_有その他.Checked || rb_有既往症.Checked)
            {
                if (!IsNo空白(txt_詳細))
                {
                    return false;
                }
            }
            if (Convert.ToInt32(txt_平熱.Text) < 30 || Convert.ToInt32(txt_平熱.Text) > 40)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "平熱を正しくを入力してください。";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 名前・フリガナ・氏名チェック
        /// </summary>
        /// <param name="txt">コントロール</param>
        private bool Nameチェック(TextBox txt)
        {
            if (!IsNo空白(txt))
            {
                return false;
            }
            if (txt.Text.IndexOf(" ") > 0)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format("[{0}]に許可されない文字 '半角Space' が入りました。", txt.Name.Replace("txt_", ""));
                return false;
            }
            if (txt.Text.IndexOf("　") == -1)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "姓と名の間に '全角Space' を挿入してください!";
                return false;
            }
            if (txt.Text.IndexOf("　") != txt.Text.LastIndexOf("　"))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format("[{0}]に '全角Space' は二つ以上入力しないでください!", txt.Name.Replace("txt_", ""));
                return false;
            }
            if (!IsNoカンマ(txt))
            {
                return false;
            }
            if (txt.Name.Replace("txt_", "") == "フリガナ")
            {
                if (!ComClass.IsFullKatakana(txt.Text.Replace("　", "")))
                {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = "フリガナは全角フリガナでご入力ください！";
                    return false;
                }
            }
            return true;
        }
        private bool 登園開始日チェック(string txt)
        {
            if (dtp_登園.Value <= dtp_生年月日.Value)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "登園開始日は生年月日よりの過去の日付を入力できません。";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 生年月日チェック
        /// </summary>
        private bool 生年月日チェック()
        {
            if (dtp_生年月日.Value > DateTime.Today)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "生年月日の日付が不正です。";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 電話番号チェック
        /// </summary>
        /// <param name="txt">コントロール</param>
        private bool 電話番号チェック(TextBox txt)
        {
            if (!IsNo空白(txt))
            {
                return false;
            }
            if (!IsNoカンマ(txt))
            {
                return false;
            }
            if (!Is電話番号(txt.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format("[{0}]のフォーマットが間違っています!", txt.Name.Replace("txt_",""));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 郵便番号チェック
        /// </summary>
        private bool 郵便番号チェック()
        {
            if (!IsNo空白(txt_郵便番号1) || !IsNo空白(txt_郵便番号2))
            {
                return false;
            }
            if (!Is数字(txt_郵便番号1.Text) || !Is数字(txt_郵便番号2.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "郵便番号に数字のみを入力してください!";
                return false;
            }
            if (!Is郵便番号(txt_郵便番号1.Text + "-" + txt_郵便番号2.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "郵便番号のフォーマットが間違っています!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// メールチェック
        /// </summary>
        private bool メールチェック()
        {
            if (!IsNo空白(txt_メール))
            {
                return false;
            }
            if (!IsNoカンマ(txt_メール))
            {
                return false;
            }
            if (!Isメール(txt_メール.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "メールのフォーマットが間違っています!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// コースチェック
        /// </summary>
        private bool コースチェック()
        {
            if (!rb_通常.Checked && !rb_延長1.Checked && !rb_延長2.Checked)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = "コースを一つ選んでください!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 空白でないかどうかをチェック
        /// </summary>
        /// <param name="txt">コントロール</param>
        private bool IsNo空白(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format("{0}を入力してください!", txt.Name.Replace("txt_",""));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 「,」がないかどうかをチェック
        /// </summary>
        /// <param name="txt">コントロール</param>
        private bool IsNoカンマ(TextBox txt)
        {
            if (txt.Text.IndexOf(",") > 0)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format("{0}に許可されない文字「,」が入りました。", txt.Name.Replace("txt_", ""));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 数字かどうかをチェック
        /// </summary>
        private bool Is数字(string value)
        {
            return Regex.IsMatch(value, @"^\d{1,7}(?:\.\d{0,2}$|$)");
        }

        /// <summary>
        /// 電話番号かどうかをチェック
        /// </summary>
        private bool Is電話番号(string value)
        {
            return Regex.IsMatch(value, @"\A0\d{1,4}-\d{1,4}-\d{4}\z");
        }

        /// <summary>
        /// 郵便番号かどうかをチェック
        /// </summary>
        private bool Is郵便番号(string value)
        {
            return Regex.IsMatch(value, @"\d{7}|\d{3}-\d{4}");
        }

        /// <summary>
        /// メールアドレスかどうかをチェック
        /// </summary>
        private bool Isメール(string value)
        {
            return Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" + @"|(([\w-]+\.)+))([a-zA-Z]{2,5}|[0-9]{1,3})(\]?)$");
        }
        
        /// <summary>
        /// ファイルUpLoadボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpLoad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OpenFileDialog op = new OpenFileDialog();

            op.Filter = "Excelファイル|*.xls;*.xlsx|Wordファイル|*.doc;*.docx|すべてファイル|*.*";
            op.RestoreDirectory = true;

            if (op.ShowDialog() == DialogResult.OK)
            {
                switch (btn.Name.Replace("btn_", ""))
                {
                    case "入園登録":
                        txt_入園登録.Text = op.FileName;

                        if (!FileExtensionCheck(txt_入園登録.Text, lbl_入園登録.Text.Replace("[必須]","")))
                        {
                            txt_入園登録.Text = string.Empty;
                            txt_入園登録.Tag = null;
                        }
                        break;
                    case "母子手帳":
                        txt_母子手帳.Text = op.FileName;

                        if (!FileExtensionCheck(txt_母子手帳.Text, lbl_母子手帳.Text))
                        {
                            txt_母子手帳.Text = string.Empty;
                            txt_母子手帳.Tag = null;
                        }
                        break;
                    case "健康保険":
                        txt_健康保険.Text = op.FileName;

                        if (!FileExtensionCheck(txt_健康保険.Text, lbl_健康保険.Text))
                        {
                            txt_健康保険.Text = string.Empty;
                            txt_健康保険.Tag = null;
                        }
                        break;
                    case "医療証":
                        txt_医療証.Text = op.FileName;

                        if (!FileExtensionCheck(txt_医療証.Text, lbl_医療証.Text))
                        {
                            txt_医療証.Text = string.Empty;
                            txt_医療証.Tag = null;
                        }
                        break;
                    case "健康診断":
                        txt_健康診断.Text = op.FileName;

                        if (!FileExtensionCheck(txt_健康診断.Text, lbl_健康診断.Text))
                        {
                            txt_健康診断.Text = string.Empty;
                            txt_健康診断.Tag = null;
                        }
                        break;
                    case "緊急連絡":
                        txt_緊急連絡.Text = op.FileName;

                        if (!FileExtensionCheck(txt_緊急連絡.Text, lbl_緊急連絡.Text))
                        {
                            txt_緊急連絡.Text = string.Empty;
                            txt_緊急連絡.Tag = null;
                        }
                        break;
                    case "児童調査":
                        txt_児童調査.Text = op.FileName;

                        if (!FileExtensionCheck(txt_児童調査.Text, lbl_児童調査.Text))
                        {
                            txt_児童調査.Text = string.Empty;
                            txt_児童調査.Tag = null;
                        }
                        break;
                    case "健康調査":
                        txt_健康調査.Text = op.FileName;

                        if (!FileExtensionCheck(txt_健康調査.Text, lbl_健康調査.Text))
                        {
                            txt_健康調査.Text = string.Empty;
                            txt_健康調査.Tag = null;
                        }
                        break;
                    case "利用報告":
                        txt_利用報告.Text = op.FileName;

                        if (!FileExtensionCheck(txt_利用報告.Text, lbl_利用報告.Text))
                        {
                            txt_利用報告.Text = string.Empty;
                            txt_利用報告.Tag = null;
                        }
                        break;
                    case "撮影契約":
                        txt_撮影契約.Text = op.FileName;

                        if (!FileExtensionCheck(txt_撮影契約.Text, lbl_撮影契約.Text))
                        {
                            txt_撮影契約.Text = string.Empty;
                            txt_撮影契約.Tag = null;
                        }
                        break;
                    case "個人情報":
                        txt_個人情報.Text = op.FileName;

                        if (!FileExtensionCheck(txt_個人情報.Text, lbl_個人情報.Text))
                        {
                            txt_個人情報.Text = string.Empty;
                            txt_個人情報.Tag = null;
                        }
                        break;
                    case "共済給付":
                        txt_共済給付.Text = op.FileName;

                        if (!FileExtensionCheck(txt_共済給付.Text, lbl_共済給付.Text))
                        {
                            txt_共済給付.Text = string.Empty;
                            txt_共済給付.Tag = null;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// ファイルUpLoadするかを確認
        /// </summary>
        private bool UpLoadチェック()
        {
            if (string.IsNullOrEmpty(txt_入園登録.Text))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format(@"入園登録申込書をアップロードしてください！");
                return false;
            }
            if (txt_入園登録.Tag != null)
            {
                if (!PathCheck(txt_入園登録.Text, lbl_入園登録.Text.Replace("[必須]", "")) || 
                    !FileExtensionCheck(txt_入園登録.Text, lbl_入園登録.Text.Replace("[必須]", "")))
                {
                    return false;
                }
            }
            if (txt_母子手帳.Tag != null)
            {
                if (!PathCheck(txt_母子手帳.Text, lbl_母子手帳.Text) || !FileExtensionCheck(txt_母子手帳.Text, lbl_母子手帳.Text))
                {
                    return false;
                }
            }
            if (txt_健康保険.Tag != null)
            {
                if (!PathCheck(txt_健康保険.Text, lbl_健康保険.Text) || !FileExtensionCheck(txt_健康保険.Text, lbl_健康保険.Text))
                {
                    return false;
                }
            }
            if (txt_医療証.Tag != null)
            {
                if (!PathCheck(txt_医療証.Text, lbl_医療証.Text) || !FileExtensionCheck(txt_医療証.Text, lbl_医療証.Text))
                {
                    return false;
                }
            }
            if (txt_健康診断.Tag != null)
            {
                if (!PathCheck(txt_健康診断.Text, lbl_健康診断.Text) || !FileExtensionCheck(txt_健康診断.Text, lbl_健康診断.Text))
                {
                    return false;
                }
            }
            if (txt_緊急連絡.Tag != null)
            {
                if (!PathCheck(txt_緊急連絡.Text, lbl_緊急連絡.Text) || !FileExtensionCheck(txt_緊急連絡.Text, lbl_緊急連絡.Text))
                {
                    return false;
                }
            }
            if (txt_児童調査.Tag != null)
            {
                if (!PathCheck(txt_児童調査.Text, lbl_児童調査.Text) || !FileExtensionCheck(txt_児童調査.Text, lbl_児童調査.Text))
                {
                    return false;
                }
            }
            if (txt_健康調査.Tag != null)
            {
                if (!PathCheck(txt_健康調査.Text, lbl_健康調査.Text) || !FileExtensionCheck(txt_健康調査.Text, lbl_健康調査.Text))
                {
                    return false;
                }
            }
            if (txt_利用報告.Tag != null)
            {
                if (!PathCheck(txt_利用報告.Text, lbl_利用報告.Text) || !FileExtensionCheck(txt_利用報告.Text, lbl_利用報告.Text))
                {
                    return false;
                }
            }
            if (txt_撮影契約.Tag != null)
            {
                if (!PathCheck(txt_撮影契約.Text, lbl_撮影契約.Text) || !FileExtensionCheck(txt_撮影契約.Text, lbl_撮影契約.Text))
                {
                    return false;
                }
            }
            if (txt_個人情報.Tag != null)
            {
                if (!PathCheck(txt_個人情報.Text, lbl_個人情報.Text) || !FileExtensionCheck(txt_個人情報.Text, lbl_個人情報.Text))
                {
                    return false;
                }
            }
            if (txt_共済給付.Tag != null)
            {
                if (!PathCheck(txt_共済給付.Text, lbl_共済給付.Text) || !FileExtensionCheck(txt_共済給付.Text, lbl_共済給付.Text))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// UpLoadファイルのパスチェック
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="fileName">ファイル名</param>
        private bool PathCheck(string path, string fileName)
        {
            if (!File.Exists(path))
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format(@"{0}:「{1}」が存在しません！", fileName.Replace("　", ""), Path.GetFileName(path));
                return false;
            }
            return true;
        }

        /// <summary>
        /// UpLoadファイルの拡張子チェック
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="fileName">ファイル名</param>
        private bool FileExtensionCheck(string path, string fileName)
        {
            if (Path.GetExtension(path.ToLower()) == ".xls" || Path.GetExtension(path.ToLower()) == ".xlsx" ||
                Path.GetExtension(path.ToLower()) == ".doc" || Path.GetExtension(path.ToLower()) == ".docx")
            {
                return true;
            }
            else
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = string.Format(@"{0}:ExcelファイルまたはWordファイルをUpLoadしてください。", fileName.Replace("　",""));
                return false;
            }
        }

        /// <summary>
        /// UpLoadファイルパスが変更したかを確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_UpLoad_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;

            if (!string.IsNullOrEmpty(txtbox.Text.Trim()))
            {
                txtbox.Tag = "変更した";
            }
            else
            {
                txtbox.Tag = null;
            }
        }

        /// <summary>
        /// Step1画面を表示
        /// </summary>
        private void Step1Change()
        {
            this.Text = "Step1　入園材料UpLoad";
            this.Size = new Size(875, 750);

            gb_入園材料.Visible = true;
            gb_入園材料確認.Visible = false;
            gb_園児情報.Visible = false;

            btn_save.Text = "次へ";
            btn_save.Location = new Point(175, gb_入園材料.Location.Y + 640);
            btn_back.Location = new Point(425, gb_入園材料.Location.Y + 640);
            btn_cancel.Location = new Point(575, gb_入園材料.Location.Y + 640);
            btn_back.Visible = false;

            lbl_error.ForeColor = Color.Black;
            lbl_error.Text = string.Empty;
        }

        /// <summary>
        /// Step2画面を表示
        /// </summary>
        private void Step2Change()
        {
            UpLoadFileName();

            this.Text = "Step2　情報確認";
            this.Size = new Size(1000, 700);

            gb_入園材料.Visible = false;
            gb_入園材料確認.Visible = true;
            gb_園児情報.Visible = true;
            gb_園児情報.Location = new Point(gb_入園材料確認.Location.X, gb_入園材料確認.Location.Y + 335);
            cmb_性別.SelectedIndex = 0;

            btn_save.Text = "登　録";
            btn_save.Location = new Point(125, gb_園児情報.Location.Y + 900);
            btn_back.Location = new Point(425, gb_園児情報.Location.Y + 900);
            btn_cancel.Location = new Point(725, gb_園児情報.Location.Y + 900);
            btn_back.Visible = true;

            gb_入園材料確認.Focus();
            lbl_error.ForeColor = Color.Black;
            lbl_error.Text = string.Empty;
        }

        /// <summary>
        /// 入園登録申込書の内容を読み取り
        /// </summary>
        /// <param name="filePath">ファイルのパス</param>
        private void Data読み取り(string filePath)
        {
            try
            {
                //Excelプロセスを作る
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                excelBook = excelApp.Workbooks.Open(filePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                excelSheet = (Excel.Worksheet)excelBook.ActiveSheet;

                //ExcelのプロセスIDを記録する
                hwnd = new IntPtr(excelApp.Hwnd);
                GetWindowThreadProcessId(hwnd, out pid);

                //画面項目・基本情報
                txt_名前.Text = GetConnect("D7", "I9");
                txt_フリガナ.Text = GetConnect("E6", "I6");
                dtp_生年月日.Value = GetDateTime(GetConnect("L6", "Q9"));
                txt_電話番号.Text = GetConnect("N13", "Q13");
                txt_メール.Text = GetConnect("D18", "I18");
                txt_住所.Text = GetConnect("D11", "Q12");
                dtp_登園.Value = GetDateTime(GetConnect("D40", "H41"));
                txt_備考.Text = GetConnect("C38", "J39");

                string zipCode = GetConnect("D10", "F10").Replace("〒", "").Replace("-", "").Replace("ー", "").Trim();
                txt_郵便番号1.Text = !string.IsNullOrEmpty(zipCode) ? zipCode.Substring(0, 3) : string.Empty;
                txt_郵便番号2.Text = !string.IsNullOrEmpty(zipCode) ? zipCode.Substring(3, 4) : string.Empty;

                //画面項目・コース
                if (GetConnect("C35", "L35").Contains("✓") || GetConnect("C35", "L35").Contains("☑"))
                {
                    rb_通常.Checked = true;
                }
                if (GetConnect("C36", "L36").Contains("✓") || GetConnect("C36", "L36").Contains("☑"))
                {
                    rb_延長1.Checked = rb_通常.Checked = true ? false : true;
                }
                if (GetConnect("C37", "L37").Contains("✓") || GetConnect("C37", "L37").Contains("☑"))
                {
                    rb_延長2.Checked = rb_通常.Checked ? false : rb_延長1.Checked ? false : true;
                }

                //画面項目・緊急連絡先
                if (GetConnect("D20", "I21") != null)
                {
                    txt_氏名1.Text = GetConnect("D20", "I21");
                    txt_続柄1.Text = "父";
                    txt_電話番号1.Text = GetConnect("N22", "Q22") != null ? GetConnect("N22", "Q22") : GetConnect("N23", "Q23");
                    txt_勤務先1.Text = GetConnect("G22", "L23");
                }
                if (GetConnect("L20", "Q21") != null)
                {
                    txt_氏名2.Text = GetConnect("L20", "Q21");
                    txt_続柄2.Text = "母";
                    txt_電話番号2.Text = GetConnect("N24", "Q24") != null ? GetConnect("N24", "Q24") : GetConnect("N25", "Q25");
                    txt_勤務先2.Text = GetConnect("G24", "L25");
                }
                if (GetConnect("G26", "J27") != null)
                {
                    txt_氏名3.Text = GetConnect("G26", "J27");
                    txt_続柄3.Text = GetConnect("K27", "L27");
                    txt_電話番号3.Text = GetConnect("N26", "Q26") != null ? GetConnect("N26", "Q26") : GetConnect("N27", "Q27");
                }
                if (GetConnect("G28", "J29") != null)
                {
                    txt_氏名4.Text = GetConnect("G28", "J29");
                    txt_続柄4.Text = GetConnect("K29", "L29");
                    txt_電話番号4.Text = GetConnect("N28", "Q28") != null ? GetConnect("N28", "Q28") : GetConnect("N29", "Q29");
                }

                //画面項目・健康情報
                txt_平熱.Text = GetConnect("C31", "F31").Replace("平熱", "").Replace("℃", "").Trim();
                txt_詳細.Text = GetConnect("M33", "Q37");
                GetRadioButton();
            }
            catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = ex.Message;
            }
            finally
            {
                KillExcel();
            }
        }

        /// <summary>
        /// Excelセルの内容を読み取り
        /// </summary>
        private string GetConnect(string cell1, string cell2)
        {
            excelRange = excelSheet.Range[cell1, cell2];
            object[,] ObjctrlList = (object[,])excelRange.Value2;

            if (ObjctrlList[1, 1] != null)
            {
                return ObjctrlList[1, 1].ToString().Trim();
            }
            return null;
        }

        /// <summary>
        /// 和暦から西暦に変更
        /// </summary>
        private DateTime GetDateTime(string date)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ja-JP", false);
            ci.DateTimeFormat.Calendar = new System.Globalization.JapaneseCalendar();

            string pattern = "平成|令和|年|月|日|生";
            string output = Regex.Replace(date, pattern, string.Empty);

            if (!string.IsNullOrWhiteSpace(output))
            {
                string strdate = date.Replace("生", "").Replace(" ", "").Replace("　", "");
                return DateTime.ParseExact(strdate, "ggyy年M月d日", ci);
            }
            return DateTime.Now;
        }

        /// <summary>
        /// 画面のRadioButtonを設定する
        /// </summary>
        private void GetRadioButton()
        {
            string[] check = { "✓", "☑", "○", "◯" };
            string[] name = { "性別", "ひきつけ", "呼吸心疾患", "食物アレルギー", "その他のアレルギー", "既往症" };

            foreach (string column in name)
            {
                switch (column)
                {
                    case "性別":
                        string sex = GetConnect("P9", "Q9").Substring(0, GetConnect("P9", "Q9").IndexOf("・"));
                        foreach (var item in check)
                        {
                            cmb_性別.SelectedIndex = sex.Contains(item) ? 0 : 1;
                        }
                        break;
                    case "ひきつけ":
                        string a = GetConnect("C32", "F32").Substring(0, GetConnect("C32", "F32").IndexOf("有"));
                        foreach (var item in check)
                        {
                            rb_有ひき.Checked = a.Contains(item) ? true : false;
                            rb_無ひき.Checked = !rb_有ひき.Checked ? true : false;
                        }
                        break;
                    case "呼吸心疾患":
                        string b = GetConnect("C33", "F33").Substring(0, GetConnect("C33", "F33").IndexOf("有"));
                        foreach (var item in check)
                        {
                            rb_有呼吸.Checked = b.Contains(item) ? true : false;
                            rb_無呼吸.Checked = !rb_有呼吸.Checked ? true : false;
                        }
                        break;
                    case "食物アレルギー":
                        string c = GetConnect("G31", "L31").Substring(0, GetConnect("G31", "L31").IndexOf("有"));
                        foreach (var item in check)
                        {
                            rb_有食物.Checked = c.Contains(item) ? true : false;
                            rb_無食物.Checked = !rb_有食物.Checked ? true : false;
                        }
                        break;
                    case "その他のアレルギー":
                        string d = GetConnect("G32", "L32").Substring(0, GetConnect("G32", "L32").IndexOf("有"));
                        foreach (var item in check)
                        {
                            rb_有その他.Checked = d.Contains(item) ? true : false;
                            rb_無その他.Checked = !rb_有その他.Checked ? true : false;
                        }
                        break;
                    case "既往症":
                        string e = GetConnect("G33", "L33").Substring(0, GetConnect("G33", "L33").IndexOf("有"));
                        foreach (var item in check)
                        {
                            rb_有既往症.Checked = e.Contains(item) ? true : false;
                            rb_無既往症.Checked = !rb_有既往症.Checked ? true : false;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Excelプロセスを閉じる
        /// </summary>
        private void KillExcel()
        {
            try
            {
                //正常にExcelを閉じる
                excelBook.Close(Excel.XlSaveAction.xlDoNotSaveChanges, null, null);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                lbl_error.ForeColor = Color.Red;
                lbl_error.Text = ex.Message;
            }
            finally
            {
                if (excelApp != null && pid > 0)
                {
                    //強制的にExcelを閉じる
                    int ExcelProcess;
                    ExcelProcess = OpenProcess(PROCESS_VM_READ | PROCESS_VM_WRITE, false, pid);

                    if (ExcelProcess > 0)
                    {
                        try
                        {
                            System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(pid);
                            process.Kill();
                        }
                        catch (Exception ex)
                        {
                            lbl_error.ForeColor = Color.Red;
                            lbl_error.Text = ex.Message;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Step1画面でUpLoadしたファイル名を読み取り
        /// </summary>
        private void UpLoadFileName()
        {
            txt_入園登録確認.Text = !string.IsNullOrEmpty(txt_入園登録.Text) ? Path.GetFileName(txt_入園登録.Text) : string.Empty;
            txt_母子手帳確認.Text = !string.IsNullOrEmpty(txt_母子手帳.Text) ? Path.GetFileName(txt_母子手帳.Text) : string.Empty;
            txt_健康保険確認.Text = !string.IsNullOrEmpty(txt_健康保険.Text) ? Path.GetFileName(txt_健康保険.Text) : string.Empty;
            txt_医療証確認.Text = !string.IsNullOrEmpty(txt_医療証.Text) ? Path.GetFileName(txt_医療証.Text) : string.Empty;
            txt_健康診断確認.Text = !string.IsNullOrEmpty(txt_健康診断.Text) ? Path.GetFileName(txt_健康診断.Text) : string.Empty;
            txt_緊急連絡確認.Text = !string.IsNullOrEmpty(txt_緊急連絡.Text) ? Path.GetFileName(txt_緊急連絡.Text) : string.Empty;
            txt_児童調査確認.Text = !string.IsNullOrEmpty(txt_児童調査.Text) ? Path.GetFileName(txt_児童調査.Text) : string.Empty;
            txt_健康調査確認.Text = !string.IsNullOrEmpty(txt_健康調査.Text) ? Path.GetFileName(txt_健康調査.Text) : string.Empty;
            txt_利用報告確認.Text = !string.IsNullOrEmpty(txt_利用報告.Text) ? Path.GetFileName(txt_利用報告.Text) : string.Empty;
            txt_撮影契約確認.Text = !string.IsNullOrEmpty(txt_撮影契約.Text) ? Path.GetFileName(txt_撮影契約.Text) : string.Empty;
            txt_個人情報確認.Text = !string.IsNullOrEmpty(txt_個人情報.Text) ? Path.GetFileName(txt_個人情報.Text) : string.Empty;
            txt_共済給付確認.Text = !string.IsNullOrEmpty(txt_共済給付.Text) ? Path.GetFileName(txt_共済給付.Text) : string.Empty;
        }

        /// <summary>
        /// Step1画面項目を読み取り
        /// </summary>
        private void Step1読み取り()
        {
            str_入園登録 = txt_入園登録.Text;
            str_母子手帳 = txt_母子手帳.Text;
            str_健康保険 = txt_健康保険.Text;
            str_医療証 = txt_医療証.Text;
            str_健康診断 = txt_健康診断.Text;
            str_緊急連絡 = txt_緊急連絡.Text;
            str_児童調査 = txt_児童調査.Text;
            str_健康調査 = txt_健康調査.Text;
            str_利用報告 = txt_利用報告.Text;
            str_撮影契約 = txt_撮影契約.Text;
            str_個人情報 = txt_個人情報.Text;
            str_共済給付 = txt_共済給付.Text;
        }

        /// <summary>
        /// Step2画面項目を読み取り
        /// </summary>
        private void Step2読み取り()
        {
            //画面項目・基本情報
            str_名前 = txt_名前.Text;
            str_フリガナ = txt_フリガナ.Text;
            str_性別 = cmb_性別.Text;
            str_生年月日 = dtp_生年月日.Value.ToString("yyyy-MM-dd");
            str_電話番号 = txt_電話番号.Text;
            str_郵便番号 = ZenToHanNum(txt_郵便番号1.Text) + "-" + ZenToHanNum(txt_郵便番号2.Text);
            str_メール = txt_メール.Text;
            str_住所 = txt_住所.Text;
            str_登園 = dtp_登園.Value.ToString("yyyy-MM-dd");
            str_コース = rb_通常.Checked ? "通常" : rb_延長1.Checked ? "延長1" : "延長2";
            str_備考 = txt_備考.Text;

            //画面項目・緊急連絡先
            str_氏名1 = txt_氏名1.Text;
            str_続柄1 = txt_続柄1.Text;
            str_電話番号1 = txt_電話番号1.Text;
            str_勤務先1 = txt_勤務先1.Text;
            str_氏名2 = txt_氏名2.Text;
            str_続柄2 = txt_続柄2.Text;
            str_電話番号2 = txt_電話番号2.Text;
            str_勤務先2 = txt_勤務先2.Text;
            str_氏名3 = txt_氏名3.Text;
            str_続柄3 = txt_続柄3.Text;
            str_電話番号3 = txt_電話番号3.Text;
            str_勤務先3 = txt_勤務先3.Text;
            str_氏名4 = txt_氏名4.Text;
            str_続柄4 = txt_続柄4.Text;
            str_電話番号4 = txt_電話番号4.Text;
            str_勤務先4 = txt_勤務先4.Text;

            //画面項目・健康情報
            str_平熱 = txt_平熱.Text;
            str_ひきつけ = rb_有ひき.Checked ? "有" : "無";
            str_呼吸 = rb_有呼吸.Checked ? "有" : "無";
            str_食物 = rb_有食物.Checked ? "有" : "無";
            str_その他 = rb_有その他.Checked ? "有" : "無";
            str_既往症 = rb_有既往症.Checked ? "有" : "無";
            str_詳細 = txt_詳細.Text;

            //空白可能の項目をnullに変更
            str_備考 = nullチェンジ(str_備考);
            str_氏名2 = nullチェンジ(str_氏名2);
            str_続柄2 = nullチェンジ(str_続柄2);
            str_電話番号2 = nullチェンジ(str_電話番号2);
            str_勤務先2 = nullチェンジ(str_勤務先2);
            str_氏名3 = nullチェンジ(str_氏名3);
            str_続柄3 = nullチェンジ(str_続柄3);
            str_電話番号3 = nullチェンジ(str_電話番号3);
            str_勤務先3 = nullチェンジ(str_勤務先3);
            str_氏名4 = nullチェンジ(str_氏名4);
            str_続柄4 = nullチェンジ(str_続柄4);
            str_電話番号4 = nullチェンジ(str_電話番号4);
            str_勤務先4 = nullチェンジ(str_勤務先4);
            str_詳細 = nullチェンジ(str_詳細);
        }

        /// <summary>
        /// 画面項目の値をnullにチェンジするか
        /// </summary>
        /// <param name="value">TextBoxの値</param>
        private string nullチェンジ(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "null" : "'" + value + "'";
        }

        private string ZenToHanNum(string s)
        {
            return Regex.Replace(s, "[０-９]", p => ((char)(p.Value[0] - '０' + '0')).ToString());
        }

        /// <summary>
        /// 年齢を設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_生年月日_ValueChanged(object sender, EventArgs e)
        {
            DateTime year = DateTime.Parse(DateTime.Now.Year.ToString() + "/4/1");
            DateTime birthDay = dtp_生年月日.Value;
            int age = year.Year - birthDay.Year;

            //誕生日がまだ来ていなければ、1引く
            if (year.Month < birthDay.Month ||
               (year.Month == birthDay.Month &&
                year.Day < birthDay.Day))
            {
                age--;
            }

            lbl_歳.Text = age.ToString() + " 歳";
        }

        /// <summary>
        /// 必須追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_必須_Paint(object sender, PaintEventArgs e)
        {
            Label strLbl = (Label)sender;
            string str = strLbl.Text;

            if (str.Contains("必須"))
            {
                strLbl.ForeColor = Color.FromArgb(240, 240, 240);
                Font f = new Font("メイリオ", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));

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

        /// <summary>
        /// GroupBoxの枠線を取る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
    }
}
