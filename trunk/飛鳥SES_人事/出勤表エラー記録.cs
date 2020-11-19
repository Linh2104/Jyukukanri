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
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.IO;
using ComDll;

namespace 飛鳥SES_人事
{
    public partial class 出勤表エラー記録 : DockContent
    {
        #region 関数

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);

        /// <summary>
        /// 選択した日付（日付変更時）
        /// </summary>
        private string date_selectedValue = "";

        /// <summary>
        /// Row選択チェック
        /// </summary>
        private bool isEditing = false;

        /// <summary>
        /// 出勤記録新規追加した日付
        /// </summary>
        public string adddateValue = "";

        public static 出勤表エラー記録 pCurrentWin = null;

        /// <summary>
        /// データベース接続用
        /// </summary>
        //private string connectionString = "Integrated Security=TRUE; Server=DESKTOP-L97HM3B\\SQLEXPRESS; Database=oa; Connection Timeout=60";
        private string connectionString = ComClass.connectionString;

        #endregion

        #region 初期画面表示

        public 出勤表エラー記録()
        {
            InitializeComponent();

            pCurrentWin = this;
        }       

        /// <summary>
        /// 初期画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 出勤表エラー記録_Load(object sender, EventArgs e)
        {
            GetInitialDate();

            if (EmployeeListGet())
            {
                DisplayGridView();
            }            
        }

        #endregion

        #region 出勤記録新規追加画面登録

        /// <summary>
        /// 出勤記録新規追加画面登録
        /// </summary>
        public void AddBacked()
        {
            if (!string.IsNullOrEmpty(adddateValue))
            {
                this.dtp_date.Value = DateTime.Parse(adddateValue);

                adddateValue = null;
            }
            else
            {
                GetInitialDate();
            }

            if (EmployeeListGet())
            {
                DisplayGridView();
            }
        }

        #endregion

        #region 初期日付取得

        /// <summary>
        /// 日付選択項目の初期値：システム時間の前月
        /// </summary>
        private void GetInitialDate()
        {
            // システム時間取得
            DateTime dateNow = DateTime.Now;

            // 前月日付取得
            DateTime lastMonthDate = dateNow.AddMonths(-1);

            // 画面項目日付値設定
            this.dtp_date.Value = lastMonthDate;
        }

        #endregion

        #region 職員コード選択肢取得

        /// <summary>
        /// 職員コード選択肢(List)の取得、フォーマット（社員コードプラス全角スペースプラン名前）
        /// </summary>
        private bool EmployeeListGet()
        {
            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return false;
            }

            // 取得処理
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct ");
                stringBuilder.Append(@" b.社員コード ");
                stringBuilder.Append(@",d.名前 ");
                stringBuilder.Append(@" from HL_JINJI_出勤機ダウンロード記録 a ");
                stringBuilder.Append(@" left join HL_JINJI_出勤機_登録ユーザマスタ b ");
                stringBuilder.Append(@" on a.登録コード = b.登録コード ");
                stringBuilder.Append(@" and b.出勤機コード = 1 ");
                stringBuilder.Append(@" left join HL_JINJI_出勤機元記録 c ");
                stringBuilder.Append(@" on a.登録コード = c.登録コード ");
                stringBuilder.Append(@" and c.出退勤フラグ != 6 ");
                stringBuilder.Append(@" and a.年 + a.月 + a.日 = CONVERT(varchar(8), c.出退勤時間, 112) ");
                stringBuilder.Append(@" inner join HL_JINJI_社員マスタ d ");
                stringBuilder.Append(@" on b.社員コード = d.社員コード ");
                stringBuilder.Append(@" where a.年 = ");
                stringBuilder.Append(this.dtp_date.Value.Year);
                stringBuilder.Append(@" and a.月 = ");
                stringBuilder.Append(this.dtp_date.Value.Month);
                                
                SqlCommand com = new SqlCommand(stringBuilder.ToString(), conn);

                SqlDataReader reader = com.ExecuteReader();

                this.cmb_Employee.Items.Clear();

                this.cmb_Employee.Items.Add("ALL");

                // 値設定
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

                return true;
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "職員Listの取得が失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                conn.Close();

                return false;
            }
        }

        #endregion        

        #region 出勤表エラー記録検索 条件：対象月、社員コード

        /// <summary>
        /// 初期検索する、又は再検索する
        /// </summary>
        private void DisplayGridView()
        {          
            gridView_ErrorList.Rows.Clear();
            
            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return;
            }

            // 検索条件：日付、社員コード
            string date_日付 = dtp_date.Value.ToString("yyyyMM");
            string code_社員コード = cmb_Employee.Text.Split(' ')[0];

            // 取得処理
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" select c.出勤機コード ");
                stringBuilder.Append(@" ,b.社員コード ");
                stringBuilder.Append(@" ,a.登録コード ");
                stringBuilder.Append(@" ,c.出退勤フラグ ");
                stringBuilder.Append(@" ,c.出退勤時間 ");
                stringBuilder.Append(@" ,d.名前 ");
                stringBuilder.Append(@" from HL_JINJI_出勤機ダウンロード記録 a ");
                stringBuilder.Append(@" left join HL_JINJI_出勤機_登録ユーザマスタ b ");
                stringBuilder.Append(@" on a.登録コード = b.登録コード ");
                stringBuilder.Append(@" and b.出勤機コード = 1 ");
                stringBuilder.Append(@" left join HL_JINJI_出勤機元記録 c ");
                stringBuilder.Append(@" on a.登録コード = c.登録コード ");
                stringBuilder.Append(@" and c.出退勤フラグ != 6 ");
                stringBuilder.Append(@" and a.年 + '/' + a.月 + '/' + a.日 = CONVERT(date, c.出退勤時間) ");
                stringBuilder.Append(@" inner join HL_JINJI_社員マスタ d ");
                stringBuilder.Append(@" on b.社員コード = d.社員コード ");
                stringBuilder.Append(@" where CONVERT(VARCHAR(6), c.出退勤時間, 112) = '").Append(date_日付).Append(@"' ");

                // 職員：ALL ではない場合、特定職員のエラー記録取得、ALL場合、条件は日付だけです。
                if (!code_社員コード.Equals("ALL"))
                {
                    stringBuilder.Append(@" and b.社員コード = '").Append(code_社員コード).Append(@"' ");
                }
                stringBuilder.Append(@" group by c.出勤機コード,b.社員コード,a.登録コード,c.出退勤フラグ,c.出退勤時間,d.名前 ");
                stringBuilder.Append(@" order by b.社員コード,c.出退勤時間 ");

                SqlDataAdapter sqlDate = new SqlDataAdapter(stringBuilder.ToString(), conn);

                System.Data.DataTable dt = new System.Data.DataTable();

                sqlDate.Fill(dt);

                // 一覧値設定
                if (dt.Rows.Count > 0)
                {
                    int rowIndex = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["出退勤フラグ"].ToString().Equals("6"))
                        {
                            continue;
                        }

                        this.gridView_ErrorList.Rows.Add();
                        gridView_ErrorList.Rows[rowIndex].Cells["出勤機コード"].Value = dt.Rows[i]["出勤機コード"].ToString();
                        gridView_ErrorList.Rows[rowIndex].Cells["社員コード"].Value = dt.Rows[i]["社員コード"].ToString() + "　" + dt.Rows[i]["名前"].ToString();
                        gridView_ErrorList.Rows[rowIndex].Cells["登録コード"].Value = dt.Rows[i]["登録コード"].ToString();
                        switch (dt.Rows[i]["出退勤フラグ"].ToString())
                        {
                            case "0":
                            case "2":
                            case "4":
                                gridView_ErrorList.Rows[rowIndex].Cells["出退勤フラグ"].Value = true;
                                break;
                            case "1":
                            case "3":
                            case "5":
                                gridView_ErrorList.Rows[rowIndex].Cells["出退勤フラグ"].Value = false;
                                break;
                        }
                        gridView_ErrorList.Rows[rowIndex].Cells["出退勤時間"].Value = DateTime.Parse(dt.Rows[i]["出退勤時間"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                        gridView_ErrorList.Rows[rowIndex].Cells["出退勤フラグ"].Style.BackColor = Color.FromArgb(255, 128, 255, 255);
                        gridView_ErrorList.Rows[rowIndex].Cells["出退勤フラグ"].Style.ForeColor = Color.Blue;
                        gridView_ErrorList.Rows[rowIndex].Cells["出退勤時間"].Style.BackColor = Color.FromArgb(255, 128, 255, 255);
                        gridView_ErrorList.Rows[rowIndex].Cells["出退勤時間"].Style.ForeColor = Color.Blue;
                        gridView_ErrorList.Rows[rowIndex].Cells["元日時"].Value = DateTime.Parse(dt.Rows[i]["出退勤時間"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                        gridView_ErrorList.Rows[rowIndex].Cells["NewRowフラグ"].Value = false;
                        rowIndex++;
                    }
                    this.sslbl_エラーメッセージ.Text = "";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Black;
                }
                else
                {
                    this.sslbl_エラーメッセージ.Text = "該当エラー記録無し.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }

                if (gridView_ErrorList.RowCount == 0)
                {
                    this.sslbl_エラーメッセージ.Text = "該当エラー記録無し.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                    this.btn_NewAddition.Enabled = false;
                }

                date_selectedValue = dtp_date.Value.ToString("yyyyMM");               
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "出勤機エラー記録の取得が失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                conn.Close();

                return;
            }
            finally
            {
                if (conn != null)

                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region 選択した日付が変更した場合、再検索する。

        /// <summary>
        /// 選択した日付が変更した場合、職員コードの選択肢を再検索する、エラー記録一覧を再検索する
        /// </summary>
        private void SelectedValueChange()
        {
            string getNowSelectedDate = dtp_date.Value.ToString("yyyyMM");

            // 日付変更ある場合
            if (getNowSelectedDate != date_selectedValue)
            {
                if (EmployeeListGet())
                {
                    DisplayGridView();
                }
            }
        }

        #endregion

        #region 出勤表エラーを修正する

        /// <summary>
        /// 出勤表エラーを修正する
        /// </summary>
        /// <param name="code_社員コード">選択した職員（社員コード）</param>
        private void ErrorsFix(string code_社員コード, string code_出勤機コード, string code_登録コード, string date_出退勤機コード時間)
        {
            // 変更件数
            int result = 0;
            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return;
            }
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = conn;

            // 修正処理
            try
            {
                // ペアかどうかチェック----(出勤)
                StringBuilder stringBuilder01 = new StringBuilder();

                stringBuilder01.Append(@" SELECT * FROM HL_JINJI_出勤機元記録  ");
                stringBuilder01.Append(@" WHERE 出勤機コード = '").Append(code_出勤機コード).Append(@"' ");
                stringBuilder01.Append(@" AND 登録コード = ").Append(code_登録コード);
                stringBuilder01.Append(@" AND 出退勤フラグ IN (0,2,4) ");
                stringBuilder01.Append(@" AND CONVERT(varchar(100), 出退勤時間, 112) = '").Append(date_出退勤機コード時間.Substring(0,10).Replace("/", "")).Append(@"' ");

                SqlDataAdapter sqlDate01 = new SqlDataAdapter(stringBuilder01.ToString(), conn);

                System.Data.DataTable dt01 = new System.Data.DataTable();

                sqlDate01.Fill(dt01);

                // ペアかどうかチェック----(退勤)
                StringBuilder stringBuilder02 = new StringBuilder();

                stringBuilder02.Append(@" SELECT * FROM HL_JINJI_出勤機元記録  ");
                stringBuilder02.Append(@" WHERE 出勤機コード = '").Append(code_出勤機コード).Append(@"' ");
                stringBuilder02.Append(@" AND 登録コード = ").Append(code_登録コード);
                stringBuilder02.Append(@" AND 出退勤フラグ IN (1,3,5) ");
                stringBuilder02.Append(@" AND CONVERT(varchar(100), 出退勤時間, 112) = '").Append(date_出退勤機コード時間.Substring(0, 10).Replace("/", "")).Append(@"' ");

                SqlDataAdapter sqlDate02 = new SqlDataAdapter(stringBuilder02.ToString(), conn);

                System.Data.DataTable dt02 = new System.Data.DataTable();

                sqlDate02.Fill(dt02);

                // 1件出勤、1件退勤、退勤時間 > 出勤時間 
                if (dt01.Rows.Count == 1 && dt02.Rows.Count == 1 && string.Compare(dt01.Rows[0]["出退勤時間"].ToString(), dt02.Rows[0]["出退勤時間"].ToString()) < 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.Append(@" DELETE HL_JINJI_出勤機ダウンロード記録 ");
                    stringBuilder.Append(@" WHERE 出勤機コード = '").Append(code_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" AND 登録コード = ").Append(code_登録コード);
                    stringBuilder.Append(@" AND 年 = '").Append(date_出退勤機コード時間.Substring(0, 4)).Append(@"' ");
                    stringBuilder.Append(@" AND 月 = ").Append(date_出退勤機コード時間.Substring(5, 2)).Append(@" ");
                    stringBuilder.Append(@" AND 日 = ").Append(date_出退勤機コード時間.Substring(8, 2)).Append(@" ");

                    sqlcom.CommandText = stringBuilder.ToString();

                    result = sqlcom.ExecuteNonQuery();

                    if (EmployeeListGet())
                    {
                        DisplayGridView();
                    }

                    if (result >= 1)
                    {

                        this.sslbl_エラーメッセージ.Text = "出勤機元記録が正常に修正されました.";

                        this.sslbl_エラーメッセージ.ForeColor = Color.Green;
                    }
                }
                else
                {
                    // 修正の内容がない場合。
                    this.sslbl_エラーメッセージ.Text = "修正可能の内容がないです.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }                                
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "出勤機元記録の修正が異常終了されました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                conn.Close();

                return;
            }
            finally
            {
                if (conn != null)

                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region 画面項目（Enabled）変更

        /// <summary>
        /// 画面項目（Enabled）変更
        /// </summary>
        private void EnabledChange()
        {
            this.gridView_ErrorList.Enabled = !this.gridView_ErrorList.Enabled;
            this.cmb_Employee.Enabled = !this.cmb_Employee.Enabled;
            this.dtp_date.Enabled = !this.dtp_date.Enabled;
            this.btn_FixTheError.Enabled = !this.btn_FixTheError.Enabled;
            this.btn_NewAddition.Enabled = !this.btn_NewAddition.Enabled;
        }

        #endregion

        #region 一覧データを変更します。

        /// <summary>
        /// 一覧データを変更する場合、更新します。
        /// </summary>
        private void RowValueChang()
        {
            if (isEditing && this.gridView_ErrorList.CurrentCell != null)
            {
                this.gridView_ErrorList.CurrentCell.Selected = true;

                // 修正した内容
                string code_出勤機コード = this.gridView_ErrorList.CurrentRow.Cells["出勤機コード"].Value.ToString();
                string code_登録コード = this.gridView_ErrorList.CurrentRow.Cells["登録コード"].Value.ToString();
                int flag_出勤機フラグ = this.gridView_ErrorList.CurrentRow.Cells["出退勤フラグ"].Value.ToString() == "True" ? 0 : 1;
                string date_出退勤時間 = this.gridView_ErrorList.CurrentRow.Cells["出退勤時間"].Value.ToString();
                string code_職員コード = this.gridView_ErrorList.CurrentRow.Cells["社員コード"].Value.ToString();

                // 修正前日時
                string date_元日時 = this.gridView_ErrorList.CurrentRow.Cells["元日時"].Value.ToString();

                // 入力時間チェック
                try
                {
                    DateTime dateTime = DateTime.Parse(date_出退勤時間);

                    if (string.Compare(dateTime.ToString("yyyyMMddHHmmss"), DateTime.Now.ToString("yyyyMMddHHmmss")) >= 1)
                    {
                        int index_col = gridView_ErrorList.CurrentCell.ColumnIndex;
                        int index_row = gridView_ErrorList.CurrentCell.RowIndex;
                        DisplayGridView();
                        this.sslbl_エラーメッセージ.Text = "過去の時間を入力してください.";
                        this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                        gridView_ErrorList.Rows[index_row].Cells[index_col].Selected = true;
                        return;
                    }
                }
                catch
                {                    
                    int index_col = gridView_ErrorList.CurrentCell.ColumnIndex;
                    int index_row = gridView_ErrorList.CurrentCell.RowIndex;
                    DisplayGridView();
                    this.sslbl_エラーメッセージ.Text = "正しい時間を入力してください.";
                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                    gridView_ErrorList.Rows[index_row].Cells[index_col].Selected = true;
                    return;
                }

                if (date_出退勤時間.Substring(0,10) != date_元日時.Substring(0,10))
                {
                    int index_col = gridView_ErrorList.CurrentCell.ColumnIndex;
                    int index_row = gridView_ErrorList.CurrentCell.RowIndex;
                    DisplayGridView();
                    this.sslbl_エラーメッセージ.Text = "日付変更不可、時間だけ変更してください.";
                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                    gridView_ErrorList.Rows[index_row].Cells[index_col].Selected = true;
                    return;
                }

                bool isNew = false;

                if (this.gridView_ErrorList.CurrentRow.Cells["NewRowフラグ"].Value != null)
                {
                    isNew = this.gridView_ErrorList.CurrentRow.Cells["NewRowフラグ"].Value.ToString() == "True" ? true : false;
                }

                int result = 0;

                SqlConnection conn = new SqlConnection(connectionString); //连接数据库

                // データベースOpenチェック
                if (!Sqlconnection(conn))
                {
                    return;
                }

                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = conn;

                // 変更処理
                try
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.Append(@" update HL_JINJI_出勤機ダウンロード記録 ");
                    stringBuilder.Append(@" set 年 = '").Append(date_出退勤時間.Split('/')[0]).Append(@"' ");
                    stringBuilder.Append(@" , 月 = ").Append(date_出退勤時間.Split('/')[1]).Append(@" ");
                    stringBuilder.Append(@" , 日 = ").Append(date_出退勤時間.Split('/')[2].Split(' ')[0]).Append(@" ");
                    stringBuilder.Append(@" WHERE 出勤機コード = '").Append(code_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" and 登録コード = '").Append(code_登録コード).Append(@"' ");
                    stringBuilder.Append(@" and 年 = '").Append(date_元日時.Split('/')[0]).Append(@"' ");
                    stringBuilder.Append(@" and 月 = ").Append(date_元日時.Split('/')[1]).Append(@" ");
                    stringBuilder.Append(@" and 日 = ").Append(date_元日時.Split('/')[2].Split(' ')[0]).Append(@" ");

                    stringBuilder.Append(@" Update HL_JINJI_出勤機元記録 ");
                    stringBuilder.Append(@" Set 出退勤フラグ = ").Append(flag_出勤機フラグ).Append(@" ");
                    stringBuilder.Append(@" , 出退勤時間 = '").Append(date_出退勤時間).Append(@"' ");
                    stringBuilder.Append(@" Where 登録コード = '").Append(code_登録コード).Append(@"' ");
                    stringBuilder.Append(@" and 出勤機コード = '").Append(code_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" and 出退勤時間 = '").Append(date_元日時).Append(@"' ");

                    sqlcom.CommandText = stringBuilder.ToString();

                    result = sqlcom.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        DisplayGridView();

                        this.sslbl_エラーメッセージ.Text = "出勤機元記録が正常に更新されました. 職員：" + code_職員コード + "　元日時：" + date_元日時;

                        this.sslbl_エラーメッセージ.ForeColor = Color.Green;
                    }
                    else
                    {
                        this.sslbl_エラーメッセージ.Text = "出勤機元記録の更新処理が失敗しました. 職員：" + code_職員コード + "　元日時：" + date_元日時;

                        this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                    }
                }
                catch
                {

                    this.sslbl_エラーメッセージ.Text = "出勤機元記録の更新処理が失敗しました. 職員：" + code_職員コード + "　元日時：" + date_元日時;

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

        #endregion

        #region 出勤表エラー記録コピー.追加。

        /// <summary>
        /// 出勤表エラー記録コピー.追加。
        /// </summary>
        private void ErrorCopyAdd()
        {
            if ((this.gridView_ErrorList.CurrentCell != null))
            {
                int currentIndex = this.gridView_ErrorList.CurrentRow.Index;
                int rowIndex = this.gridView_ErrorList.Rows.Add();
                Thread.Sleep(500);

                // gridView_ErrorList 新しい行追加
                this.gridView_ErrorList.CurrentRow.Selected = false;
                this.gridView_ErrorList.Rows[rowIndex].Cells["社員コード"].Value = this.gridView_ErrorList.Rows[currentIndex].Cells["社員コード"].Value;
                this.gridView_ErrorList.Rows[rowIndex].Cells["出勤機コード"].Value = this.gridView_ErrorList.Rows[currentIndex].Cells["出勤機コード"].Value;
                this.gridView_ErrorList.Rows[rowIndex].Cells["登録コード"].Value = this.gridView_ErrorList.Rows[currentIndex].Cells["登録コード"].Value;
                this.gridView_ErrorList.Rows[rowIndex].Cells["出退勤フラグ"].Value = this.gridView_ErrorList.Rows[currentIndex].Cells["出退勤フラグ"].Value;
                this.gridView_ErrorList.Rows[rowIndex].Cells["出退勤時間"].Value = DateTime.Parse(this.gridView_ErrorList.Rows[currentIndex].Cells["出退勤時間"].Value.ToString()).AddSeconds(1).ToString("yyyy/MM/dd HH:mm:ss");
                this.gridView_ErrorList.Rows[rowIndex].Cells["元日時"].Value = this.gridView_ErrorList.Rows[rowIndex].Cells["出退勤時間"].Value;
                this.gridView_ErrorList.Rows[rowIndex].Cells["NewRowフラグ"].Value = true;
                this.gridView_ErrorList.Rows[rowIndex].Selected = true;
                this.gridView_ErrorList.FirstDisplayedScrollingRowIndex = rowIndex;

                int result = 0;
                SqlConnection conn = new SqlConnection(connectionString); //连接数据库

                // データベースOpenチェック
                if (!Sqlconnection(conn))
                {
                    return;
                }

                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = conn;

                string add_出勤機コード = this.gridView_ErrorList.Rows[rowIndex].Cells["出勤機コード"].Value.ToString();
                string add_登録コード = this.gridView_ErrorList.Rows[rowIndex].Cells["登録コード"].Value.ToString();
                int add_出退勤フラグ = this.gridView_ErrorList.Rows[rowIndex].Cells["出退勤フラグ"].Value.ToString().Equals("TRUE") ? 0 : 1;
                string add_出退勤時間 = this.gridView_ErrorList.Rows[rowIndex].Cells["出退勤時間"].Value.ToString();
                string code_職員コード = this.gridView_ErrorList.Rows[rowIndex].Cells["社員コード"].Value.ToString();

                // 追加処理
                try
                {                    
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.Append(@" delete HL_JINJI_出勤機元記録 ");
                    stringBuilder.Append(@" where 出勤機コード = '").Append(add_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" and 登録コード = ").Append(add_登録コード).Append(@" ");
                    stringBuilder.Append(@" and 出退勤時間 = '").Append(add_出退勤時間).Append(@"' ");

                    stringBuilder.Append(@" Insert Into HL_JINJI_出勤機元記録 ");
                    stringBuilder.Append(@" Values('").Append(add_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" , '").Append(add_登録コード).Append(@"' ");
                    stringBuilder.Append(@" , ").Append(add_出退勤フラグ).Append(@" ");
                    stringBuilder.Append(@" , '").Append(add_出退勤時間).Append(@"') ");

                    stringBuilder.Append(@" delete HL_JINJI_出勤機ダウンロード記録 ");
                    stringBuilder.Append(@" where 出勤機コード = '").Append(add_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" and 登録コード = ").Append(add_登録コード).Append(@" ");
                    stringBuilder.Append(@" and 年 = '").Append(add_出退勤時間.Split('/')[0]).Append(@"' ");
                    stringBuilder.Append(@" and 月 = '").Append(add_出退勤時間.Split('/')[1]).Append(@"' ");
                    stringBuilder.Append(@" and 日 = '").Append(add_出退勤時間.Split('/')[2].Split(' ')[0]).Append(@"' ");

                    stringBuilder.Append(@" insert into HL_JINJI_出勤機ダウンロード記録 ");
                    stringBuilder.Append(@" values('").Append(add_出勤機コード).Append(@"' ");
                    stringBuilder.Append(@" , '").Append(add_登録コード).Append(@"' ");
                    stringBuilder.Append(@" ,'").Append(add_出退勤時間.Split('/')[0]).Append(@"' ");
                    stringBuilder.Append(@" ,'").Append(add_出退勤時間.Split('/')[1]).Append(@"' ");
                    stringBuilder.Append(@" ,'").Append(add_出退勤時間.Split('/')[2].Split(' ')[0]).Append(@"','新規') ");

                    //出勤機元記録に登録
                    sqlcom.CommandText = stringBuilder.ToString();

                    result = sqlcom.ExecuteNonQuery();

                    string str社員 = this.cmb_Employee.Text;

                    EmployeeListGet();

                    this.cmb_Employee.Text = str社員;

                    if (result >= 1)
                    {
                        this.sslbl_エラーメッセージ.ForeColor = Color.Green;

                        this.sslbl_エラーメッセージ.Text = "出勤機元記録が正常に追加されました. 職員：" + code_職員コード + "　出退勤時間：" + add_出退勤時間;

                        conn.Close();
                    }
                }
                catch
                {

                    this.sslbl_エラーメッセージ.Text = "出勤機元記録の追加処理が失敗しました. 職員：" + code_職員コード + "　出退勤時間：" + add_出退勤時間;

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                    this.gridView_ErrorList.Rows.Remove(this.gridView_ErrorList.Rows[rowIndex]);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }            
        }

        #endregion

        #region 出勤表エラー記録削除。

        /// <summary>
        /// 出勤表エラー記録削除。
        /// </summary>
        private void ErrorDelete()
        {
            if ((this.gridView_ErrorList.CurrentCell != null))
            {
               // &&
               //(!(this.gridView_ErrorList.CurrentCell.ColumnIndex == 0 && this.gridView_ErrorList.CurrentCell.RowIndex == 0))
                this.gridView_ErrorList.CurrentCell.Selected = true;
                string code_登録コード = this.gridView_ErrorList.CurrentRow.Cells["登録コード"].Value.ToString();
                string date_出退勤時間 = this.gridView_ErrorList.CurrentRow.Cells["出退勤時間"].Value.ToString();
                string date_出勤機コード = this.gridView_ErrorList.CurrentRow.Cells["出勤機コード"].Value.ToString();
                string code_職員コード = this.gridView_ErrorList.CurrentRow.Cells["社員コード"].Value.ToString();

                bool isNew = false;
                if (this.gridView_ErrorList.CurrentRow.Cells["元日時"].Value != null)
                {
                    isNew = this.gridView_ErrorList.CurrentRow.Cells["NewRowフラグ"].Value.ToString() == "True" ? true : false;
                }

                if (isNew)
                {
                    DisplayGridView();
                    return;
                }

                int result = 0;
                SqlConnection conn = new SqlConnection(connectionString); //连接数据库

                if (!Sqlconnection(conn))
                {
                    return;
                }

                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = conn;

                try
                {
                    //出勤機元記録から削除行う
                    StringBuilder stringBuilder = new StringBuilder();

                    stringBuilder.Append(@" update HL_JINJI_出勤機元記録 ");
                    stringBuilder.Append(@" set 出退勤フラグ = 6 ");
                    stringBuilder.Append(@" Where 登録コード = '").Append(code_登録コード).Append(@"' ");
                    stringBuilder.Append(@" and 出退勤時間 = '").Append(date_出退勤時間).Append(@"' ");
                    stringBuilder.Append(@" and 出勤機コード = '").Append(date_出勤機コード).Append(@"' ");

                    sqlcom.CommandText = stringBuilder.ToString();


                    result = sqlcom.ExecuteNonQuery();

                    if (result == 1)
                    {

                        this.sslbl_エラーメッセージ.Text = "出勤機元記録が正常に削除されました. 職員："+ code_職員コード + "　出退勤時間："+ date_出退勤時間;

                        this.sslbl_エラーメッセージ.ForeColor = Color.Green;

                        this.gridView_ErrorList.Rows.Remove(this.gridView_ErrorList.CurrentRow);

                        conn.Close();
                    }
                }
                catch
                {

                    this.sslbl_エラーメッセージ.Text = "出勤機元記録の削除処理が失敗しました. 職員：" + code_職員コード + "　出退勤時間：" + date_出退勤時間;

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }                
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

        /// <summary>
        /// 画面閉じる
        /// </summary>
        private void 出勤表エラー記録_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_出勤表エラー記録Handle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// 選択年月変更
        /// </summary>
        private void dateTimePicker01_ValueChanged(object sender, EventArgs e)
        {
            SelectedValueChange();
        }

        /// <summary>
        /// 選択職員変更
        /// </summary>
        private void cmb_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// エラーを修正するボタンクリック
        /// </summary>
        private void btn_FixTheError_Click(object sender, EventArgs e)
        {
            EnabledChange();

            for (int rowno = 0; rowno < gridView_ErrorList.RowCount; rowno ++)
            {
                string code_社員コード = this.gridView_ErrorList.Rows[rowno].Cells["社員コード"].Value.ToString().Split('　')[0];

                string code_出勤機コード = this.gridView_ErrorList.Rows[rowno].Cells["出勤機コード"].Value.ToString();

                string code_登録コード = this.gridView_ErrorList.Rows[rowno].Cells["登録コード"].Value.ToString();

                string date_出退勤時間 = this.gridView_ErrorList.Rows[rowno].Cells["出退勤時間"].Value.ToString();

                ErrorsFix(code_社員コード, code_出勤機コード, code_登録コード, date_出退勤時間);
            }

            EnabledChange();
        }

        /// <summary>
        /// 出勤記録を新規追加するボタンクリック
        /// </summary>
        private void btn_NewAddition_Click(object sender, EventArgs e)
        {
            出勤記録新規追加 m_NewForm_出勤記録新規追加 = new 出勤記録新規追加();
            m_NewForm_出勤記録新規追加.ShowDialog();
        }

        private void gridView_ErrorList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isEditing = true;
        }

        /// <summary>
        /// 行処理開始
        /// </summary>
        private void gridView_ErrorList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            isEditing = false;
        }

        /// <summary>
        /// 行処理終了
        /// </summary>
        private void gridView_ErrorList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RowValueChang();
        }

        /// <summary>
        /// 行クリック
        /// </summary>
        private void gridView_ErrorList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if ((this.gridView_ErrorList.Rows[e.RowIndex].Selected == false))
                    {
                        this.gridView_ErrorList.ClearSelection();
                        this.gridView_ErrorList.Rows[e.RowIndex].Selected = true;
                    }
                    //'只选中一行时设置活动单元格
                    if ((this.gridView_ErrorList.SelectedRows.Count == 1))
                    {
                        this.gridView_ErrorList.CurrentCell = this.gridView_ErrorList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                }
            }
        }

        /// <summary>
        /// 行右クリック(コピー、追加)
        /// </summary>
        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorCopyAdd();
        }

        /// <summary>
        /// 行右クリック(コピー、削除)
        /// </summary>
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorDelete();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            System.Drawing.Point startPosition = Cursor.Position;

            System.Drawing.Point point = this.gridView_ErrorList.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.gridView_ErrorList.HitTest(point.X, point.Y);

            this.gridView_ErrorList.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                this.gridView_ErrorList.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
