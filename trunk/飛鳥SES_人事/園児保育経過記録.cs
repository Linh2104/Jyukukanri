using ComDll;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace 飛鳥SES_人事
{
    public partial class 園児保育経過記録 : DockContent
    {
        #region 関数

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        string childCdAndName = "";

        /// <summary>
        /// データベース接続用
        /// </summary>
        //private string connectionString = "Integrated Security=TRUE; Server=DESKTOP-L97HM3B\\SQLEXPRESS; Database=oa; Connection Timeout=60";
        private string connectionString = ComClass.connectionString;

        #endregion

        #region 初期画面表示

        public 園児保育経過記録()
        {
            InitializeComponent();

            cmb_記録分類.SelectedIndex = 0;

            cmd_在退園.SelectedIndex = 0;

            cmb_アップロード状態.SelectedIndex = 0;
        }

        private void 園児保育経過記録_Load(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        #endregion

        #region サーバーがつなげます。

        /// <summary>
        /// サーバーがつなげます。
        /// </summary>
        /// <param name="conn">SqlConnection</param>
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

        #region 記録検索

        /// <summary>
        /// 保育経過記録：初期検索して、又は再検索して、表示する。
        /// </summary>
        private void DisplayGridView()
        {
            // gridViewデータクリア
            gridView_保育経過記録一覧.Rows.Clear();

            // データベース連続
            SqlConnection conn = new SqlConnection(connectionString);

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return;
            }

            // 検索条件：作成日付、記録類別
            string code_年齢 = cmb_記録分類.Text;

            string date_日付 = dtp_入園年度.Value.ToString("yyyy");

            // 取得処理
            try
            {
                // Sql文構成
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" Select a.園児コード, ");
                stringBuilder.Append(@" a.名前, ");
                stringBuilder.Append(@" a.生年月日, ");
                stringBuilder.Append(@" b.作成日付, ");
                stringBuilder.Append(@" b.更新日時, ");
                stringBuilder.Append(@" b.記録ファイル名, ");
                stringBuilder.Append(@" Case When Right(Convert(varchar(100), Getdate(), 112) , 4) >= Right(Convert(varchar(100), a.生年月日, 112) , 4) Then Datediff(Year,a.生年月日,Getdate()) else Datediff(Year,a.生年月日,Getdate()) - 1 End As 年齢  ");
                stringBuilder.Append(@" From HL_JEC_園児情報マスタ a ");

                if (cmb_アップロード状態.SelectedIndex != 1)
                {
                    stringBuilder.Append(@" Left join HL_JEC_保育経過記録一覧表 b ");
                }
                else
                {
                    stringBuilder.Append(@" Inner join HL_JEC_保育経過記録一覧表 b ");
                }

                stringBuilder.Append(@" On a.園児コード = b.園児コード ");
                stringBuilder.Append(@" And b.記録分類 = '").Append(code_年齢).Append(@"' ");

                if (cmd_在退園.Text == "在園")
                {
                    stringBuilder.Append(@" Where a.退園日 Is Null ");
                }
                else if (cmd_在退園.Text == "退園")
                {
                    stringBuilder.Append(@" Where a.退園日 Is Not Null ");
                    stringBuilder.Append(@" And Left ( a.登園開始日 , 4 ) = ").Append(date_日付);
                }

                if (cmb_アップロード状態.SelectedIndex == 2)
                {
                    stringBuilder.Append(@" And b.園児コード Is Null ");
                }

                stringBuilder.Append(@" And (Case When Right(Convert(varchar(100), Getdate(), 112) , 4) >= Right(Convert(varchar(100), a.生年月日, 112) , 4) Then Datediff(Year,a.生年月日,Getdate()) else Datediff(Year,a.生年月日,Getdate()) - 1 End) >= Left('").Append(code_年齢).Append(@"' , 1 )");
                stringBuilder.Append(@" Order By a.園児コード ");

                SqlDataAdapter sqlDate = new SqlDataAdapter(stringBuilder.ToString(), conn);

                System.Data.DataTable dt = new System.Data.DataTable();

                sqlDate.Fill(dt);

                // 一覧値設定
                if (dt.Rows.Count > 0)
                {
                    int rowIndex = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.gridView_保育経過記録一覧.Rows.Add();

                        gridView_保育経過記録一覧.Rows[rowIndex].Cells["園児"].Value = dt.Rows[i]["園児コード"].ToString() + "　" + dt.Rows[i]["名前"].ToString();

                        gridView_保育経過記録一覧.Rows[rowIndex].Cells["生年月日"].Value = DateTime.Parse(dt.Rows[i]["生年月日"].ToString()).ToString("yyyy/MM/dd");

                        gridView_保育経過記録一覧.Rows[rowIndex].Cells["年齢"].Value = dt.Rows[i]["年齢"].ToString() + "歳";

                        if (string.IsNullOrWhiteSpace(dt.Rows[i]["作成日付"].ToString()))
                        {
                            gridView_保育経過記録一覧.Rows[rowIndex].Cells["作成日付"].Value = "-";
                        }
                        else
                        {
                            gridView_保育経過記録一覧.Rows[rowIndex].Cells["作成日付"].Value = DateTime.Parse(dt.Rows[i]["作成日付"].ToString()).ToString("yyyy/MM/dd");
                        }

                        if (string.IsNullOrWhiteSpace(dt.Rows[i]["更新日時"].ToString()))
                        {
                            gridView_保育経過記録一覧.Rows[rowIndex].Cells["更新日時"].Value = "-";
                        }
                        else
                        {
                            gridView_保育経過記録一覧.Rows[rowIndex].Cells["更新日時"].Value = DateTime.Parse(dt.Rows[i]["更新日時"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                        }

                        if (string.IsNullOrWhiteSpace(dt.Rows[i]["記録ファイル名"].ToString()))
                        {
                            gridView_保育経過記録一覧.Rows[rowIndex].Cells["保育経過記録ファイル"].Value = " ";
                        }
                        else
                        {
                            gridView_保育経過記録一覧.Rows[rowIndex].Cells["保育経過記録ファイル"].Value = dt.Rows[i]["記録ファイル名"].ToString();
                        }

                        rowIndex++;
                    }
                    this.sslbl_エラーメッセージ.Text = string.Format("{0}件", dt.Rows.Count.ToString());

                    this.sslbl_エラーメッセージ.ForeColor = Color.Black;
                }
                else
                {
                    this.sslbl_エラーメッセージ.Text = "0件.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Black;
                }

                if (gridView_保育経過記録一覧.RowCount == 0)
                {
                    this.sslbl_エラーメッセージ.Text = "0件.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "保育経過記録の取得処理に失敗しました." + ex.Message;

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

        #region 入園年度.Visible変更：退園園児の保育経過記録を検索する時、入園年度を条件にします。

        /// <summary>
        /// 退園園児の保育経過記録を検索する時、入園年度を条件にします。
        /// </summary>
        private void VisibleChange()
        {
            if (cmd_在退園.Text == "在園")
            {
                lbl_入園年度.Visible = false;

                dtp_入園年度.Visible = false;
            }
            else
            {
                lbl_入園年度.Visible = true;

                dtp_入園年度.Visible = true;
            }
        }

        #endregion

        #region 記録既に存在しているかどうかをチェックする。

        /// <summary>
        /// 記録既に存在しているかどうかをチェックする。
        /// </summary>
        /// <returns>データ個数</returns>
        private int GetDateCountChech()
        {
            // データベース連続
            SqlConnection conn = new SqlConnection(connectionString);

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return -1;
            }

            // 検索条件：園児コード、記録類別
            string code_年齢 = cmb_記録分類.Text;

            string code_園児 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[0];

            // 取得処理
            try
            {
                // Sql文構成
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" Select 園児コード ");
                stringBuilder.Append(@" From HL_JEC_保育経過記録一覧表 ");
                stringBuilder.Append(@" Where 園児コード = ").Append(code_園児); ;
                stringBuilder.Append(@" And 記録分類 = '").Append(code_年齢).Append(@"' ");

                SqlDataAdapter sqlDate = new SqlDataAdapter(stringBuilder.ToString(), conn);

                System.Data.DataTable dt = new System.Data.DataTable();

                sqlDate.Fill(dt);

                return dt.Rows.Count;
            }
            catch
            {
                conn.Close();

                return -1;
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

        #region ファイル取得

        /// <summary>
        /// ファイルバイト取得
        /// </summary>
        /// <returns>ファイルバイト</returns>
        private byte[] GetFileBT()
        {
            // データベース連続
            SqlConnection conn = new SqlConnection(connectionString);

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return null;
            }

            // 検索条件：園児コード、記録類別、ファイル名
            string code_年齢 = cmb_記録分類.Text;

            string code_園児 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[0];

            string name_File = this.gridView_保育経過記録一覧.CurrentRow.Cells["保育経過記録ファイル"].Value.ToString().Split('　')[0];

            byte[] uploadFileData = null;
            // 取得処理
            try
            {
                // Sql文構成
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" Select 記録ファイル名 , 記録ファイル ");
                stringBuilder.Append(@" From HL_JEC_保育経過記録一覧表 ");
                stringBuilder.Append(@" Where 園児コード = ").Append(code_園児); ;
                stringBuilder.Append(@" And 記録分類 = '").Append(code_年齢).Append(@"' ");
                stringBuilder.Append(@" And 記録ファイル名 = '").Append(name_File).Append(@"' ");

                SqlDataAdapter sqlDate = new SqlDataAdapter(stringBuilder.ToString(), conn);

                System.Data.DataTable dt = new System.Data.DataTable();

                sqlDate.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    uploadFileData = (byte[])dt.Rows[0]["記録ファイル"];

                    return uploadFileData;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                conn.Close();

                return null;
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

        #region 記録追加

        /// <summary>
        /// 保育経過記録追加
        /// </summary>
        private bool DataInsert(byte[] uploadFileData, string filename)
        {
            // データベース連続
            SqlConnection conn = new SqlConnection(connectionString);

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return false;
            }

            // 追加データの園児コード、記録類別、ファイル名
            string code_年齢 = cmb_記録分類.Text;

            string code_園児 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[0];

            this.childCdAndName = code_園児;

            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" Insert Into HL_JEC_保育経過記録一覧表 ");
                stringBuilder.Append(@" Values ( ").Append(code_園児);
                stringBuilder.Append(@" , Convert(varchar(100), GETDATE(), 23) ");
                stringBuilder.Append(@" , Convert(varchar(100), GETDATE(), 121) ");
                stringBuilder.Append(@" , '").Append(code_年齢).Append(@"' ");
                stringBuilder.Append(@" , @uploadFileData ");
                stringBuilder.Append(@" , '").Append(filename).Append(@"')");

                string sql = stringBuilder.ToString();

                SqlCommand com = new SqlCommand();

                com.CommandText = sql;

                com.Connection = conn;

                com.Parameters.AddWithValue("@uploadFileData", uploadFileData);

                // 登録異常場合
                if (com.ExecuteNonQuery() != 1)
                {
                    this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "保育経過記録の登録処理に失敗しました.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }
                else
                {
                    DisplayGridView();
                }
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "保育経過記録の登録処理に失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
            }
        }

        #endregion

        #region 記録更新

        /// <summary>
        /// 記録更新
        /// </summary>
        /// <returns></returns>
        private bool DataSave(byte[] uploadFileData, string filename)
        {
            // データベース連続
            SqlConnection conn = new SqlConnection(connectionString);

            // データベースOpenチェック
            if (!Sqlconnection(conn))
            {
                return false;
            }

            // 更新条件：園児コード、作成日付、更新日時、年齢（記録類別）、ファイル名
            string code_園児 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[0];

            string date_記録日 = this.gridView_保育経過記録一覧.CurrentRow.Cells["作成日付"].Value.ToString();

            string date_更新日 = this.gridView_保育経過記録一覧.CurrentRow.Cells["更新日時"].Value.ToString();

            string olds_年齢 = cmb_記録分類.Text;

            string name_ファイル = this.gridView_保育経過記録一覧.CurrentRow.Cells["保育経過記録ファイル"].Value.ToString();

            this.childCdAndName = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString();

            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" Update HL_JEC_保育経過記録一覧表 ");
                stringBuilder.Append(@" Set 更新日時 = Convert(varchar(100), GETDATE(), 121), ");
                stringBuilder.Append(@" 記録ファイル = @uploadFileData, ");
                stringBuilder.Append(@" 記録ファイル名 = '").Append(filename).Append(@"' ");
                stringBuilder.Append(@" Where 園児コード = ").Append(code_園児);
                stringBuilder.Append(@" And CONVERT(varchar(100), 作成日付, 111) = '").Append(date_記録日).Append(@"' ");
                stringBuilder.Append(@" And CONVERT(varchar(100), 更新日時, 111) + ' ' + CONVERT(varchar(100), 更新日時, 8) = '").Append(date_更新日).Append(@"' ");
                stringBuilder.Append(@" And 記録分類 = '").Append(olds_年齢).Append(@"' ");
                stringBuilder.Append(@" And 記録ファイル名 = '").Append(name_ファイル).Append(@"' ");

                string sql = stringBuilder.ToString();

                SqlCommand com = new SqlCommand();

                com.CommandText = sql;

                com.Connection = conn;

                com.Parameters.AddWithValue("@uploadFileData", uploadFileData);

                // 更新異常場合
                if (com.ExecuteNonQuery() != 1)
                {
                    this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "保育経過記録の更新処理に失敗しました.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }
                else
                {
                    DisplayGridView();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "保育経過記録の更新処理に失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
            }
            return true;
        }

        #endregion

        #region 記録削除

        /// <summary>
        /// 記録削除処理
        /// </summary>
        /// <returns>削除結果</returns>
        private bool DateAndFileDelete()
        {
            // データベース連続
            SqlConnection conn = new SqlConnection(connectionString);

            // ファイルパス + ファイル名
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "保育経過記録\\" + this.gridView_保育経過記録一覧.CurrentRow.Cells["保育経過記録ファイル"].Value.ToString();

            // データベースOpenチェック、ファイル削除チェック
            if (!Sqlconnection(conn))
            {
                return false;
            }

            // 削除条件：園児コード、作成日付、更新日時、記録類別、ファイル名
            string code_園児 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[0];

            string date_記録日付 = this.gridView_保育経過記録一覧.CurrentRow.Cells["作成日付"].Value.ToString();

            string date_更新日付 = this.gridView_保育経過記録一覧.CurrentRow.Cells["更新日時"].Value.ToString();

            string olds_記録類別 = cmb_記録分類.Text;

            string name_ファイル名 = this.gridView_保育経過記録一覧.CurrentRow.Cells["保育経過記録ファイル"].Value.ToString();

            childCdAndName = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString();

            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@"  Delete HL_JEC_保育経過記録一覧表 ");
                stringBuilder.Append(@"  Where 園児コード = ").Append(code_園児);
                stringBuilder.Append(@"  And CONVERT(varchar(100), 作成日付, 111) = '").Append(date_記録日付).Append(@"' ");
                stringBuilder.Append(@"  And CONVERT(varchar(100), 更新日時, 111) + ' ' + CONVERT(varchar(100), 更新日時, 8) = '").Append(date_更新日付).Append(@"' ");
                stringBuilder.Append(@"  And 記録分類 = '").Append(olds_記録類別).Append(@"' ");
                stringBuilder.Append(@"  And 記録ファイル名 = '").Append(name_ファイル名).Append(@"' ");

                string sql = stringBuilder.ToString();

                SqlCommand com = new SqlCommand(sql, conn);

                // 削除異常場合
                if (com.ExecuteNonQuery() != 1)
                {
                    this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "記録の削除処理に失敗しました.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;
                }

                conn.Close();

                // 削除した後、再検索
                DisplayGridView();

                this.sslbl_エラーメッセージ.Text = childCdAndName + "の" + cmb_記録分類.Text + "の" + "記録が正常に削除されました.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Green;

                return true;
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "記録の削除処理に失敗しました." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
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

        #region ファイル削除処理

        /// <summary>
        /// ファイル削除処理
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>削除結果</returns>
        private bool FileDelete(string path)
        {
            try
            {
                // ファイル存在チェック
                if (!File.Exists(path))
                {
                    return true;
                }
                else
                {
                    // ファイル削除
                    File.Delete(path);

                    return true;
                }
            }
            catch
            {
                this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "ファイルの削除処理に失敗しました.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
            }
        }

        #endregion

        #region ファイルコピー処理

        /// <summary>
        /// ファイルコピー処理
        /// </summary>
        /// <param name="filemoto">コピー元</param>
        /// <param name="filesaki">コピー先</param>
        /// <returns></returns>
        private bool AddFileCopy(string filemoto, string filesaki)
        {
            try
            {
                // 存在チェック、既に存在しています場合、削除する。
                if (File.Exists(filesaki))
                {
                    File.Delete(filesaki);
                }

                File.Copy(filemoto, filesaki);

                return true;
            }
            catch (Exception ex)
            {
                this.sslbl_エラーメッセージ.Text = "ファイル操作異常." + ex.Message;

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return false;
            }
        }

        #endregion

        #region アップロード処理

        /// <summary>
        /// アップロード処理
        /// </summary>
        private void DataUpLoad()
        {
            // ファイルパス
            string getPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // ファイルパスファイル名
            string filePathAndName;

            // ファイル名
            string fileName;

            // ファイルタイプ
            string fileType;

            // ファイルバイト
            byte[] uploadFileData = null;

            // ファイル選択する時、初期フォルダ
            openFileDialog1.InitialDirectory = getPath;

            // 初期ファイル名
            openFileDialog1.FileName = "保育経過記録";

            // ファイル選択する時、初期ファイルタイプ
            openFileDialog1.Filter = "Excelファイル|*.xlsx|Excelファイル|*.xls";
            openFileDialog1.RestoreDirectory = true;

            // ファイル選択
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 選択したファイルパスファイル名
                filePathAndName = openFileDialog1.FileName;

                // 選択したファイル名
                fileName = filePathAndName.Split('\\')[filePathAndName.Split('\\').Length - 1];

                // 選択したファイルタイプ
                fileType = fileName.Split('.')[fileName.Split('.').Length - 1];

                // タイプチェック
                if (fileType != "xlsx" && fileType != "xls")
                {
                    this.sslbl_エラーメッセージ.Text = "Excelファイルを選択してください.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                    return;
                }
                else
                {
                    // 記録も存在しているかをチェックする.
                    int dateSum = GetDateCountChech();

                    // チェック異常
                    if (dateSum == -1)
                    {
                        this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "アップロードが異常に終了しました.";

                        this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                        return;
                    }
                    else if (dateSum != 0)
                    {
                        uploadFileData = File.ReadAllBytes(openFileDialog1.FileName);

                        // 記録更新
                        if (DataSave(uploadFileData, fileName))
                        {
                            this.sslbl_エラーメッセージ.Text = childCdAndName + "の" + cmb_記録分類.Text + "の" + "保育経過記録が正常に更新されました.";

                            this.sslbl_エラーメッセージ.ForeColor = Color.Green;
                        }
                    }
                    else
                    {
                        uploadFileData = File.ReadAllBytes(openFileDialog1.FileName);

                        // コピー成功した場合、記録追加
                        if (DataInsert(uploadFileData, fileName))
                        {
                            this.sslbl_エラーメッセージ.Text = childCdAndName + "の" + cmb_記録分類.Text + "の" + "保育経過記録が正常に登録されました.";

                            this.sslbl_エラーメッセージ.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        #endregion

        #region ダウンロード処理

        /// <summary>
        /// ダウンロード処理
        /// </summary>
        private void DataDownLoad()
        {
            // ファイルパス
            string getPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // ファイル名
            string fileName = this.gridView_保育経過記録一覧.CurrentRow.Cells["保育経過記録ファイル"].Value.ToString();

            // ファイルバイト
            byte[] uploadFileData = null;

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return;
            }

            // ファイルパスファイル名
            string filePathAndName = getPath + "保育経過記録\\" + fileName;

            // ファイル選択する時、ファイルパス設定
            openFileDialog1.InitialDirectory = getPath;

            // ファイル選択する時、ファイルタイプ
            saveFileDialog1.Filter = "Excelファイル|*.xlsx|Excelファイル|*.xls";

            // ファイル選択する時、ファイル名設定
            saveFileDialog1.FileName = fileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = saveFileDialog1.FileName.ToString();

                uploadFileData = GetFileBT();

                if (uploadFileData != null)
                {
                    File.WriteAllBytes(localFilePath, uploadFileData);

                    this.sslbl_エラーメッセージ.Text = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString() + "の" + cmb_記録分類.Text + "の" + "ファイルがダウンロードしました.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Green;
                }
            }
        }

        #endregion

        #region 更新処理

        /// <summary>
        /// 更新処理
        /// </summary>
        private void DataUpdate()
        {
            // 記録既存しているかどうかをチェックする
            int dateSum = GetDateCountChech();

            // チェック異常
            if (dateSum == -1)
            {
                this.sslbl_エラーメッセージ.Text = "更新異常.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return;
            }
            else if (dateSum == 0)
            {
                // アップロードしてない場合、更新できません。
                this.sslbl_エラーメッセージ.Text = "記録存在していない、アップロードしてください.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return;
            }
            else
            {
                // ファイルパス
                string getPath = System.AppDomain.CurrentDomain.BaseDirectory;

                // ファイルパスファイル名
                string filePathAndName;

                // ファイル名
                string fileName;

                // ファイルタイプ
                string fileType;

                // ファイル保存する時、ファイルパス
                openFileDialog1.InitialDirectory = getPath;

                // ファイル保存する時、ファイルタイプ
                openFileDialog1.Filter = "Excelファイル|*.xlsx|Excelファイル|*.xls";
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // 入力したファイル名
                    filePathAndName = openFileDialog1.FileName;

                    // ファイル名取得
                    fileName = filePathAndName.Split('\\')[filePathAndName.Split('\\').Length - 1];

                    // ファイルタイプ
                    fileType = fileName.Split('.')[fileName.Split('.').Length - 1];

                    // タイプがExcelファイルしかできない
                    if (fileType != "xlsx")
                    {
                        this.sslbl_エラーメッセージ.Text = "Excelファイルを選択してください.";

                        this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                        return;
                    }
                    else
                    {
                        // 選択したパスにコピーします。
                        if (AddFileCopy(filePathAndName, System.AppDomain.CurrentDomain.BaseDirectory + "保育経過記録\\" + fileName))
                        {
                            // 記録更新
                            //DataSave(fileName);

                            this.sslbl_エラーメッセージ.Text = "保育経過記録更新済.";

                            this.sslbl_エラーメッセージ.ForeColor = Color.Green;

                            return;
                        }
                        else
                        {
                            // コピー失敗
                            return;
                        }
                    }
                }
            }
        }

        #endregion

        #region 削除処理

        /// <summary>
        /// 記録削除する
        /// </summary>
        private void DataDelete()
        {
            // 記録存在しているかをチェックする
            int dateSum = GetDateCountChech();

            // チェック異常
            if (dateSum == -1)
            {
                this.sslbl_エラーメッセージ.Text = "削除異常.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return;
            }
            else if (dateSum == 0)
            {
                // 記録存在していない場合、削除できません。
                this.sslbl_エラーメッセージ.Text = "記録が未だアップロードしていない.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return;
            }
            else
            {
                // 記録削除する、ファイル削除する。
                DateAndFileDelete();
            }
        }

        #endregion

        #region フォマード新規追加

        /// <summary>
        /// フォマード新規追加
        /// </summary>
        private void DateAdd()
        {
            // ファイルパス
            string getPath = System.AppDomain.CurrentDomain.BaseDirectory;

            string motofilename = "00_9.保育経過記録_0歳.xlsx";

            string sakifilename = string.Join("", this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')) + "_" + cmb_記録分類.Text + "保育経過記録.xlsx";

            string tempdir = @"C:\Windows\Temp\";
            
            // ファイルバイト
            byte[] uploadFileData = null;

            if (cmb_記録分類.Text == "1歳")
            {
                motofilename = "00_10.保育経過記録_1歳.xlsx";
            }
            else if (cmb_記録分類.Text == "2歳")
            {
                motofilename = "00_11.保育経過記録_2歳.xlsx";
            }
            else if (cmb_記録分類.Text == "3歳")
            {
                motofilename = "00_12.保育経過記録_3歳.xlsx";
            }
            
            try
            {
                // 記録存在しているかをチェックする
                int dateSum = GetDateCountChech();

                // チェック異常
                if (dateSum == -1)
                {
                    this.sslbl_エラーメッセージ.Text = "フォマード新規追加異常.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                    return;
                }
                else if (dateSum != 0)
                {
                    // 記録存在している場合、追加できません。
                    this.sslbl_エラーメッセージ.Text = "記録もアップロードしました、フォマード新規追加不可.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                    return;
                }
                else
                {
                    if (AddFileCopy(getPath + "保育経過記録\\" + motofilename, tempdir + sakifilename))
                    {
                        FileDataWrite(tempdir + sakifilename);

                        uploadFileData = File.ReadAllBytes(tempdir + sakifilename);

                        // コピー成功した場合、記録追加
                        DataInsert(uploadFileData, sakifilename);

                        this.sslbl_エラーメッセージ.Text = childCdAndName + "の" + cmb_記録分類.Text + "の" + "保育経過記録が正常に追加しました.";

                        this.sslbl_エラーメッセージ.ForeColor = Color.Green;
                    }
                    else
                    {
                        return;
                    }                                        
                }
            }
            catch
            {
                this.sslbl_エラーメッセージ.Text = childCdAndName + "の" + cmb_記録分類.Text + "の" + "フォマード新規追加処理に失敗しました.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                return;
            }
        }

        #endregion

        #region ファイルに園児名、生年月日入力

        private void FileDataWrite(string filename)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            Workbook workBook = null;

            object oMissiong = Missing.Value;

            try
            {
                workBook = app.Workbooks.Open(filename, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);

                Worksheet workSheet = (Worksheet)workBook.Worksheets.Item[1];

                if (cmb_記録分類.Text == "0歳")
                {
                    workSheet.Range["E3"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[1] + "　" + this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[2];
                    workSheet.Range["M4"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["生年月日"].Value.ToString();
                }
                else if (cmb_記録分類.Text == "1歳")
                {
                    workSheet.Range["E7"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[1] + "　" + this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[2];
                    workSheet.Range["F8"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["生年月日"].Value.ToString();
                }
                else if (cmb_記録分類.Text == "2歳")
                {
                    workSheet.Range["E7"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[1] + "　" + this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[2];
                    workSheet.Range["F8"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["生年月日"].Value.ToString();
                }
                else if (cmb_記録分類.Text == "3歳")
                {
                    workSheet.Range["D7"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[1] + "　" + this.gridView_保育経過記録一覧.CurrentRow.Cells["園児"].Value.ToString().Split('　')[2];
                    workSheet.Range["E4"].Value2 = this.gridView_保育経過記録一覧.CurrentRow.Cells["生年月日"].Value.ToString();
                }
                workBook.Saved = true;
            }
            catch
            {
                this.sslbl_エラーメッセージ.Text = "データの入力が失敗しました.";

                this.sslbl_エラーメッセージ.ForeColor = Color.Red;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Save();
                    workBook.Close(false, oMissiong, oMissiong);
                    Marshal.ReleaseComObject(workBook);
                    app.Workbooks.Close();
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                }
            }

        }

        #endregion

        #region イベント（検索条件変更する時）

        /// <summary>
        /// 在園、退園
        /// </summary>
        private void Cmd_在退園_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleChange();

            DisplayGridView();
        }

        /// <summary>
        /// 記録類別選択（0歳、1歳、2歳、3歳）
        /// </summary>
        private void Cmb_記録年齢_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// アップロード状態：アップロードした、アップロードしてない、全て
        /// </summary>
        private void Cmb_アップロード状態_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// 退園の園児の記録をチェックする場合、年度も条件にする
        /// </summary>
        private void Dtp_入園年度_ValueChanged(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        #endregion

        #region イベント（事件）

        /// <summary>
        /// 画面閉じる
        /// </summary>
        private void 園児保育経過記録_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_保育経過記録Handle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// アップロード
        /// </summary>
        private void アップロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataUpLoad();
        }

        /// <summary>
        /// ダウンロード
        /// </summary>
        private void ダウンロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDownLoad();
        }

        /// <summary>
        /// 記録更新
        /// </summary>
        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataUpdate();
        }

        /// <summary>
        /// 記録削除
        /// </summary>
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDelete();
        }

        /// <summary>
        /// フォマード新規追加
        /// </summary>
        private void 新規ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateAdd();
        }

        #endregion

        #region イベント（セル操作）

        /// <summary>
        /// セル選択
        /// </summary>
        private void GridView_保育経過記録一覧_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if ((this.gridView_保育経過記録一覧.Rows[e.RowIndex].Selected == false))
                    {
                        this.gridView_保育経過記録一覧.ClearSelection();
                        this.gridView_保育経過記録一覧.Rows[e.RowIndex].Selected = true;
                    }
                    //'只选中一行时设置活动单元格
                    if ((this.gridView_保育経過記録一覧.SelectedRows.Count == 1))
                    {
                        this.gridView_保育経過記録一覧.CurrentCell = this.gridView_保育経過記録一覧.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                }
            }
        }

        /// <summary>
        /// 一覧右クリック、メニュー表示（チェック、削除）
        /// </summary>
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            System.Drawing.Point startPosition = Cursor.Position;

            System.Drawing.Point point = this.gridView_保育経過記録一覧.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.gridView_保育経過記録一覧.HitTest(point.X, point.Y);

            this.gridView_保育経過記録一覧.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                this.gridView_保育経過記録一覧.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ファイル開く
        /// </summary>
        private void GridView_保育経過記録一覧_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                try
                {
                    string filename = this.gridView_保育経過記録一覧.CurrentRow.Cells["保育経過記録ファイル"].Value.ToString();

                    string path = "保育経過記録\\" + filename;

                    string tempdir = @"C:\Windows\Temp\";

                    // ファイルバイト
                    byte[] uploadFileData = null;

                    if (string.IsNullOrWhiteSpace(filename))
                    {
                        return;
                    }
                    if (File.Exists(tempdir + filename))
                    {
                        File.Delete(tempdir + filename);
                    }

                    uploadFileData = GetFileBT();

                    if (uploadFileData != null)
                    {
                        File.WriteAllBytes(tempdir + filename, uploadFileData);
                    }

                    System.Diagnostics.Process.Start(tempdir + filename);
                }
                catch
                {
                    this.sslbl_エラーメッセージ.Text = "ファイルの開くが失敗しました.";

                    this.sslbl_エラーメッセージ.ForeColor = Color.Red;

                    return;
                }
            }
        }

        #endregion        
    }
}