using ComDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;

namespace 飛鳥SES_人事
{
    public partial class 日誌一覧 : DockContent
    {
        #region 定義
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);

        /// <summary>
        /// DB接続文字列
        /// </summary>
        private string connectionString = ComClass.connectionString;

        /// <summary>
        /// フォームロード判断
        /// </summary>
        bool isFormLoad = true;

        /// <summary>
        /// 編集前の値
        /// </summary>
        private string beforeValue = string.Empty;

        /// <summary>
        /// 編集後の値
        /// </summary>
        private string afterValue = string.Empty;

        /// <summary>
        /// 編集判断
        /// </summary>
        private bool change = false;
        #endregion

        public 日誌一覧()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 日誌一覧_Load(object sender, EventArgs e)
        {
            //初期設定
            SyokiHyouji();
            //データ表示
            ShowData();

            isFormLoad = false;
        }

        /// <summary>
        /// フォームを閉じる処理
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
        private void 日誌一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_日誌一覧NewHandle.iHandle = IntPtr.Zero;
        }

        #region コントロールイベント
        /// <summary>
        /// 検索ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        /// <summary>
        /// 日付変更検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            if (!isFormLoad)
            {
                if (DateTime.Now >= dtp_DateFrom.Value)
                {
                    ShowData();
                }
                else
                {
                    dtp_DateFrom.Value = DateTime.Now;
                }
                if (DateTime.Now >= dtp_DateTo.Value)
                {
                    ShowData();
                }
                else
                {
                    dtp_DateTo.Value = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// セル内容変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Result_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (change)
            {
                CellEdit();
            }
        }

        /// <summary>
        /// セル内容が変更する前に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Result_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            change = true;
            beforeValue = dgv_Result.CurrentCell.Value == null ? string.Empty : dgv_Result.CurrentCell.Value.ToString();
        }

        /// <summary>
        /// 出力ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Output_Click(object sender, EventArgs e)
        {
            FileOutput();
        }

        /// <summary>
        /// ENTER押下よりデータ取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowData();
            }
        }
        #endregion

        #region 処理関数
        /// <summary>
        /// 初期表示
        /// </summary>
        private void SyokiHyouji()
        {
            txt_Search.Text = string.Empty;
            dtp_DateFrom.Value = DateTime.Now;
            dtp_DateTo.Value = DateTime.Now;

            lbl_KenSuu.Text = string.Empty;
            lbl_Msg.Text = string.Empty;
        }

        /// <summary>
        /// データ表示
        /// </summary>
        private void ShowData()
        {
            //日付From≦To判断
            if (int.Parse(dtp_DateFrom.Value.ToString("yyyyMMdd")) > int.Parse(dtp_DateTo.Value.ToString("yyyyMMdd")))
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "期間の指定は開始日付≦終了日付で検索してください。";
                return;
            }

            lbl_KenSuu.Text = string.Empty;
            lbl_Msg.Text = string.Empty;
            change = false;

            int index = 0;
            int now = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
            DateTime dateFrom = dtp_DateFrom.Value;
            Color cellColor = Color.White;

            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "DBサーバーの接続に失敗しました。";
                return;
            }

            //SQL文編集
            SqlCommand sqlcmd = new SqlCommand();
            while (int.Parse(dateFrom.ToString("yyyyMMdd")) <= int.Parse(dtp_DateTo.Value.ToString("yyyyMMdd")))
            {
                if (!dateFrom.DayOfWeek.ToString().Equals("Saturday") && !dateFrom.DayOfWeek.ToString().Equals("Sunday"))
                {
                    sqlcmd.CommandText += SqlSelect(txt_Search, dateFrom);

                    if (int.Parse(dateFrom.ToString("yyyyMMdd")) < int.Parse(dtp_DateTo.Value.ToString("yyyyMMdd")))
                    {
                        sqlcmd.CommandText += " UNION ALL ";
                    }
                    else
                    {
                        sqlcmd.CommandText += " ORDER BY 日付,生年月日 DESC ";
                    }
                }
                dateFrom = dateFrom.AddDays(1);
            }

            //パラメータ設定
            if (!string.IsNullOrEmpty(txt_Search.Text))
            {
                sqlcmd.Parameters.AddWithValue("@検索条件", "%" + txt_Search.Text + "%");
            }

            //実行
            sqlcmd.Connection = sqlcon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            try
            {
                dgv_Result.Rows.Clear();

                while (reader.Read())
                {
                    //データ表示
                    dgv_Result.Rows.Add();
                    dgv_Result.Rows[index].Cells["園児名"].Value = reader["園児コード"].ToString() + "　" + reader["名前"].ToString();
                    dgv_Result.Rows[index].Cells["記録"].Value = string.IsNullOrEmpty(reader["記録"].ToString()) ? "-" : reader["記録"].ToString();
                    dgv_Result.Rows[index].Cells["備考"].Value = string.IsNullOrEmpty(reader["備考"].ToString()) ? "-" : reader["備考"].ToString();
                    dgv_Result.Rows[index].Cells["日付"].Value = DateTime.Parse(reader["日付"].ToString()).ToString("yyyy/MM/dd");
                    int birth = int.Parse((reader["生年月日"].ToString().Substring(0, 10).Replace("/", "")));
                    dgv_Result.Rows[index].Cells["年齢"].Value = (now - birth).ToString().Length > 4 ? (now - birth).ToString().Substring(0, (now - birth).ToString().Length - 4) + "歳" : "0歳";
                    dgv_Result.Rows[index].Cells["SeqNo"].Value = reader["SeqNo"].ToString();

                    //CELL書式設定
                    foreach (DataGridViewCell gridCell in dgv_Result.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() == "-")
                        {
                            dgv_Result.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    if (index != 0 && dgv_Result.Rows[index].Cells["日付"].Value.ToString() != dgv_Result.Rows[index - 1].Cells["日付"].Value.ToString())
                    {
                        if (cellColor == Color.White)
                        {
                            cellColor = Color.OldLace;
                        }
                        else if (cellColor == Color.OldLace)
                        {
                            cellColor = Color.White;
                        }
                    }
                    dgv_Result.Rows[index].Cells["園児名"].Style.BackColor = cellColor;
                    dgv_Result.Rows[index].Cells["年齢"].Style.BackColor = cellColor;
                    dgv_Result.Rows[index].Cells["日付"].Style.BackColor = cellColor;

                    index++;
                }
            }
            catch (Exception ex)
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "エラーが発生しました。もう一度やり直してください。" + ex.Message;
                return;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
                lbl_KenSuu.ForeColor = Color.Black;
                lbl_KenSuu.Text = string.Format("{0}件", index);
            }
        }

        /// <summary>
        /// セル編集処理
        /// </summary>
        private void CellEdit()
        {
            //メッセージクリア
            lbl_Msg.Text = string.Empty;

            //画面情報セット
            string codeName = dgv_Result.CurrentRow.Cells["園児名"].Value.ToString();
            string childCode = codeName.Substring(0, codeName.IndexOf('　'));
            string childName = codeName.Substring(codeName.IndexOf('　') + 1);
            string kiRoku = string.Empty;
            string biKou = string.Empty;
            string date = dgv_Result.CurrentRow.Cells["日付"].Value.ToString();
            string userName = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
            string seqNo = dgv_Result.CurrentRow.Cells["SeqNo"].Value.ToString();
            string colName = dgv_Result.Columns[dgv_Result.CurrentCell.ColumnIndex].HeaderText;

            //編集後の内容
            if (dgv_Result.CurrentCell.Value != null)
            {
                afterValue = dgv_Result.CurrentCell.EditedFormattedValue.ToString().Trim();
            }
            else
            {
                afterValue = string.Empty;
            }

            if (afterValue == beforeValue)
            {
                //変更前と変更後の内容が同じ場合
                return;
            }
            else
            {
                if (colName.Equals("記録"))
                {
                    kiRoku = afterValue;
                }
                else if (colName.Equals("備考"))
                {
                    biKou = afterValue;
                }
            }

            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "DBサーバーの接続に失敗しました。";
                return;
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            try
            {
                //文字数オーバーチェック
                if (Encoding.GetEncoding(932).GetByteCount(kiRoku) < 250 && Encoding.GetEncoding(932).GetByteCount(biKou) < 250)
                {
                    if (string.IsNullOrEmpty(seqNo))
                    {
                        //登録
                        sqlcom.CommandText = SqlInsert();
                        //パラメータ設定
                        sqlcom.Parameters.AddWithValue("@園児コード", childCode);
                        sqlcom.Parameters.AddWithValue("@記録", kiRoku);
                        sqlcom.Parameters.AddWithValue("@備考", biKou);
                        sqlcom.Parameters.AddWithValue("@日付", date);
                        sqlcom.Parameters.AddWithValue("@更新者", userName);
                    }
                    else
                    {
                        //更新
                        sqlcom.CommandText = SqlUpdate(colName);
                        //パラメータ設定
                        sqlcom.Parameters.AddWithValue("@園児コード", childCode);
                        sqlcom.Parameters.AddWithValue("@編集内容", afterValue);
                        sqlcom.Parameters.AddWithValue("@日付", date);
                        sqlcom.Parameters.AddWithValue("@更新者", userName);
                        sqlcom.Parameters.AddWithValue("@SeqNo", seqNo);
                    }

                    //実行
                    int ret = sqlcom.ExecuteNonQuery();

                    if (ret == 1)
                    {
                        transaction.Commit();

                        ShowData();
                        lbl_Msg.ForeColor = Color.Green;
                        lbl_Msg.Text = string.Format("[{0}　{1}]ちゃんの「{2}」を更新しました。", childCode, childName, colName);
                    }
                }
                else
                {
                    transaction.Rollback();
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Msg.Text = colName + "の文字数がオーバーです。";
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "エラーが発生しました。もう一度やり直してください。" + ex.Message;
            }
            finally
            {
                sqlcon.Close();
                change = false;
            }
        }

        /// <summary>
        /// ファイル出力処理
        /// </summary>
        private void FileOutput()
        {
            //メッセージクリア
            lbl_Msg.Text = string.Empty;

            //DB接続
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "DBサーバーの接続に失敗しました。";
                return;
            }

            int sheetRowNo = 1;
            string fileName = string.Empty;
            string lastDate = string.Empty;
            string tmpDir = @"C:\Windows\Temp\";
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelBook = null;
            Excel.Worksheet formatSheet = null;
            Excel.Worksheet newSheet = null;
            Excel.Worksheet lastSheet = null;

            //ファイル保存ダイアログ
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.FileName = "日誌.xlsx";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //出力開始メッセージ
                    lbl_Msg.ForeColor = Color.Green;
                    lbl_Msg.Text = dtp_DateFrom.Value.ToShortDateString() + "～" + dtp_DateTo.Value.ToShortDateString() + "の日誌が出力中......";

                    //フォーマットファイルダウンロード
                    string sql = @"select * from HL_JEC_保育園業務書類フォーマット where ファイル名 = '00_6.日誌'";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();

                    fileName = tmpDir + "日誌_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                    if (reader.Read())
                    {
                        File.WriteAllBytes(fileName, (byte[])reader["ファイル"]);
                    }

                    //画面内容をファイルに書き込み処理
                    excelBook = excelApp.Workbooks.Open(fileName);
                    formatSheet = excelBook.Worksheets[1];

                    for (int i = 1; i <= dgv_Result.Rows.Count; i++)
                    {
                        if (!lastDate.Equals(dgv_Result.Rows[i - 1].Cells["日付"].Value.ToString()))
                        {
                            if (lastSheet == null)
                            {
                                lastSheet = formatSheet;
                            }
                            newSheet = excelBook.Worksheets.Add(Type.Missing, lastSheet, 1, Type.Missing);
                            formatSheet.get_Range("A1", "Z50").Copy(newSheet.get_Range("A1", "Z50"));
                            newSheet.Name = dgv_Result.Rows[i - 1].Cells["日付"].Value.ToString().Replace("/", "");
                            lastSheet = newSheet;
                            sheetRowNo = 1;
                        }

                        newSheet.Cells[sheetRowNo * 3 + 1, 2] = dgv_Result.Rows[i - 1].Cells["園児名"].Value.ToString();
                        newSheet.Cells[sheetRowNo * 3 + 1, 4] = dgv_Result.Rows[i - 1].Cells["記録"].Value.ToString();
                        newSheet.Cells[sheetRowNo * 3 + 1, 9] = dgv_Result.Rows[i - 1].Cells["備考"].Value.ToString();
                        newSheet.Cells[sheetRowNo * 3 + 1, 11] = dgv_Result.Rows[i - 1].Cells["日付"].Value.ToString();

                        lastDate = dgv_Result.Rows[i - 1].Cells["日付"].Value.ToString();
                        sheetRowNo++;
                    }

                    reader.Close();
                    formatSheet.Delete();
                    excelBook.Save();
                    excelApp.Quit();
                    Killexcel.Kill(excelApp);
                    excelApp = null;

                    //ファイル保存
                    byte[] fileData = ReadFileToByte(fileName);
                    File.WriteAllBytes(saveFileDialog.FileName, fileData);

                    lbl_Msg.ForeColor = Color.Green;
                    lbl_Msg.Text = dtp_DateFrom.Value.ToShortDateString() + "～" + dtp_DateTo.Value.ToShortDateString() + "の日誌を出力しました。";
                }
            }
            catch (Exception ex)
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = "エラーが発生しました。もう一度やり直してください。" + ex.Message;
            }
            finally
            {
                //DB閉じる
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
                //ExcelプロセスをKill
                if (excelApp != null)
                {
                    Killexcel.Kill(excelApp);
                }
                //編集した臨時フォーマットファイルを削除
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }

        /// <summary>
        /// excelをbyteにする。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static byte[] ReadFileToByte(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pFileStream != null)
                {
                    pFileStream.Close();
                }
            }
        }
        #endregion

        #region SQL文
        /// <summary>
        /// 検索のSql文
        /// </summary>
        /// <param name="txt">検索条件のテキストボックス</param>
        /// <param name="year">年度</param>
        /// <returns>Sql文</returns>
        private string SqlSelect(TextBox txt, DateTime date)
        {
            string sqlSel = string.Empty;
            StringBuilder s = new StringBuilder();

            s.AppendLine(" SELECT ");
            s.AppendLine("   B.SeqNo ");
            s.AppendLine("  ,A.園児コード ");
            s.AppendLine("  ,A.名前 ");
            s.AppendLine("  ,B.記録 ");
            s.AppendLine("  ,B.備考 ");
            s.AppendLine("  ,(CASE WHEN B.日付 IS NULL THEN '" + date.ToString("yyyy/MM/dd") + "' ELSE B.日付 END) AS 日付 ");
            s.AppendLine("  ,A.生年月日 ");
            s.AppendLine(" FROM ");
            s.AppendLine("   HL_JEC_園児情報マスタ A ");
            s.AppendLine(" LEFT JOIN ");
            s.AppendLine("   HL_JEC_日誌 B ");
            s.AppendLine(" ON ");
            s.AppendLine("   A.園児コード = B.園児コード ");
            s.AppendLine(" AND ");
            s.AppendLine("   B.日付 = '" + date.ToString("yyyy/MM/dd") + "'");
            s.AppendLine(" WHERE ");
            s.AppendLine("   A.登園開始日 <= '" + date.ToString("yyyy/MM/dd") + "'");
            s.AppendLine(" AND ");
            s.AppendLine("   ISNULL(A.退園日,'2100/12/31') >= '" + date.ToString("yyyy/MM/dd") + "'");
            //テキストボックス検索条件
            if (!string.IsNullOrEmpty(txt.Text))
            {
                s.AppendLine(" AND ");
                s.AppendLine("   (A.園児コード LIKE @検索条件 ");
                s.AppendLine(" OR ");
                s.AppendLine("   A.名前 LIKE @検索条件 ");
                s.AppendLine(" OR ");
                s.AppendLine("   B.記録 LIKE @検索条件 ");
                s.AppendLine(" OR ");
                s.AppendLine("   B.備考 LIKE @検索条件 ");
                s.AppendLine(" OR ");
                s.AppendLine("   CONVERT(varchar(100), B.日付,111) LIKE @検索条件) ");
                //s.AppendLine("OR ");
                //s.AppendLine("   年齢？？ LIKE @検索条件) ");
            }

            sqlSel = s.ToString();
            return sqlSel;
        }

        /// <summary>
        /// データ登録のSql文
        /// </summary>
        /// <returns>Sql文</returns>
        private string SqlInsert()
        {
            string sqlupd = string.Empty;
            StringBuilder s = new StringBuilder();

            s.AppendLine("INSERT INTO HL_JEC_日誌 ");
            s.AppendLine("  (SeqNo ");
            s.AppendLine("  ,園児コード ");
            s.AppendLine("  ,記録 ");
            s.AppendLine("  ,備考 ");
            s.AppendLine("  ,日付 ");
            s.AppendLine("  ,更新者) ");
            s.AppendLine("VALUES ");
            s.AppendLine("  ((SELECT ISNULL(MAX(seqNo),0) +1 FROM HL_JEC_日誌) ");
            s.AppendLine("  ,@園児コード ");
            s.AppendLine("  ,@記録 ");
            s.AppendLine("  ,@備考 ");
            s.AppendLine("  ,@日付 ");
            s.AppendLine("  ,@更新者) ");

            sqlupd = s.ToString();
            return sqlupd;
        }

        /// <summary>
        /// ファイル更新のSql文
        /// </summary>
        /// <returns>Sql文</returns>
        private string SqlUpdate(string colName)
        {
            string sqlupd = string.Empty;
            StringBuilder s = new StringBuilder();

            s.AppendLine("UPDATE ");
            s.AppendLine("   HL_JEC_日誌 ");
            s.AppendLine("SET ");
            s.AppendLine("   園児コード = @園児コード ");
            if (colName.Equals("記録"))
            {
                s.AppendLine("  ,記録 = @編集内容 ");
            }
            else if (colName.Equals("備考"))
            {
                s.AppendLine("  ,備考 = @編集内容 ");
            }
            s.AppendLine("  ,日付 = @日付 ");
            s.AppendLine("  ,更新者 = @更新者 ");
            s.AppendLine("WHERE ");
            s.AppendLine("   SeqNo = @SeqNo ");

            sqlupd = s.ToString();
            return sqlupd;
        }
        #endregion

    }
}
