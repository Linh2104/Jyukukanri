using ComDll;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
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
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;

namespace 飛鳥SES_人事
{
    public partial class 職員健康診断書一覧 : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        private string connectionString = ComClass.connectionString;

        /// <summary>
        /// フォームロード
        /// </summary>
        bool isFormLoad = true;

        public 職員健康診断書一覧()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 職員健康診断書一覧_Load(object sender, EventArgs e)
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
        private void 職員健康診断書一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_職員健康診断書一覧Handle.iHandle = IntPtr.Zero;
        }

        #region ボタンクリックなど
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
        /// 診断書類別チェンジ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_RuiBetsu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoad)
            {
                ShowData();
            }
        }

        /// <summary>
        /// 年度チェンジ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_Year_ValueChanged(object sender, EventArgs e)
        {
            if (!isFormLoad)
            {
                if (DateTime.Now > dtp_Year.Value)
                {
                    ShowData();
                }
                else
                {
                    dtp_Year.Value = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// 過去履歴ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 過去履歴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            職員健康診断書個人履歴 historyPage = new 職員健康診断書個人履歴();
            historyPage.code = dgv_Result.CurrentRow.Cells["職員コード"].Value.ToString();
            historyPage.name = dgv_Result.CurrentRow.Cells["職員氏名"].Value.ToString();
            historyPage.user = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
            historyPage.ShowDialog();
            ShowData();
        }

        /// <summary>
        /// アップロードボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void アップロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileUpload();
        }

        /// <summary>
        /// 削除ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDelete();
        }

        /// <summary>
        /// ファイルセルダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Result_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Result.CurrentCell.ColumnIndex == 5)
            {
                ShowFile();
            }
        }

        /// <summary>
        /// ENTER押下よりデータ取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowData();
            }
        }

        /// <summary>
        /// メニューのアップロードボタンEnabled設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point startPosition = Cursor.Position;
            Point point = dgv_Result.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = dgv_Result.HitTest(point.X, point.Y);
            dgv_Result.ClearSelection();

            //ヘッダーと行数を右クリック無効
            if (hitinfo.RowIndex >= 0 && hitinfo.ColumnIndex >= 0)
            {
                dgv_Result.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }

            //今年度のみ編集可の設定
            if (dgv_Result.CurrentRow.Cells["診断年度"].Value.Equals(DateTime.Now.Year.ToString() + "年"))
            {
                contextMenuStrip1.Items[1].Enabled = true;
                //ファイルが存在の場合は削除可
                if (!dgv_Result.CurrentRow.Cells["ファイル名"].Value.Equals("-"))
                {
                    contextMenuStrip1.Items[2].Enabled = true;
                }
                else
                {
                    contextMenuStrip1.Items[2].Enabled = false;
                }
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
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

            dtp_Year.Value = DateTime.Now;
            cmb_RuiBetsu.SelectedIndex = 0;

            lbl_KenSuu.Text = string.Empty;
            lbl_Msg.Text = string.Empty;
        }

        /// <summary>
        /// データ表示
        /// </summary>
        private void ShowData()
        {
            int index = 0;
            lbl_KenSuu.Text = string.Empty;
            lbl_Msg.Text = string.Empty;

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

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = SqlSelect(txt_Search, dtp_Year, cmb_RuiBetsu);

            //パラメータ設定
            if (!string.IsNullOrEmpty(txt_Search.Text))
            {
                sqlcmd.Parameters.AddWithValue("@検索条件", "%" + txt_Search.Text + "%");
            }
            if (!string.IsNullOrEmpty(dtp_Year.Text))
            {
                sqlcmd.Parameters.AddWithValue("@診断年度", dtp_Year.Text);
                sqlcmd.Parameters.AddWithValue("@診断年度_入退職", dtp_Year.Text.Substring(0, 4));
            }
            if (!string.IsNullOrEmpty(cmb_RuiBetsu.SelectedItem.ToString()))
            {
                sqlcmd.Parameters.AddWithValue("@診断書類別", cmb_RuiBetsu.SelectedItem);
            }

            sqlcmd.Connection = sqlcon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            try
            {
                dgv_Result.Rows.Clear();

                while (reader.Read())
                {
                    //データ表示
                    dgv_Result.Rows.Add();
                    dgv_Result.Rows[index].Cells["職員コード"].Value = reader["職員コード"].ToString();
                    dgv_Result.Rows[index].Cells["職員氏名"].Value = reader["名前"].ToString();
                    dgv_Result.Rows[index].Cells["在職状態"].Value = string.IsNullOrEmpty(reader["退職日"].ToString()) ? "在職" : "退職";
                    dgv_Result.Rows[index].Cells["診断年度"].Value = string.IsNullOrEmpty(reader["診断年度"].ToString()) ? dtp_Year.Text : reader["診断年度"].ToString();
                    dgv_Result.Rows[index].Cells["診断書類別"].Value = string.IsNullOrEmpty(reader["診断書類別"].ToString()) ? cmb_RuiBetsu.SelectedItem : reader["診断書類別"].ToString();
                    dgv_Result.Rows[index].Cells["ファイル名"].Value = string.IsNullOrEmpty(reader["ファイル名"].ToString()) ? "-" : reader["ファイル名"].ToString();
                    dgv_Result.Rows[index].Cells["アップロード日付"].Value = string.IsNullOrEmpty(reader["アップロード日付"].ToString()) ? "-" : Convert.ToDateTime(reader["アップロード日付"]).ToString("yyyy/MM/dd");
                    dgv_Result.Rows[index].Cells["SeqNo"].Value = reader["SeqNo"].ToString();
                    dgv_Result.Rows[index].Cells["退職日"].Value = string.IsNullOrEmpty(reader["退職日"].ToString()) ? "" : reader["退職日"].ToString();

                    //書式設定
                    foreach (DataGridViewCell gridCell in dgv_Result.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() != "-")
                        {
                            if (gridCell.OwningColumn.HeaderText == "職員コード" || gridCell.OwningColumn.HeaderText == "診断年度" || gridCell.OwningColumn.HeaderText == "アップロード日付")
                            {
                                dgv_Result.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                            else
                            {
                                dgv_Result.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                        else
                        {
                            dgv_Result.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        if (gridCell.OwningColumn.HeaderText == "退職日")
                        {
                            if (!string.IsNullOrEmpty(dgv_Result.Rows[index].Cells[gridCell.ColumnIndex].Value.ToString()))
                            {
                                dgv_Result.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                            }
                        }
                    }
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
        /// ファイルアップロード
        /// </summary>
        private void FileUpload()
        {
            lbl_KenSuu.Text = string.Empty;
            lbl_Msg.Text = string.Empty;
            string seqNo = dgv_Result.CurrentRow.Cells["SeqNo"].Value.ToString();
            string code = dgv_Result.CurrentRow.Cells["職員コード"].Value.ToString();
            string name = dgv_Result.CurrentRow.Cells["職員氏名"].Value.ToString();
            string year = dgv_Result.CurrentRow.Cells["診断年度"].Value.ToString();
            string ruiBetsu = dgv_Result.CurrentRow.Cells["診断書類別"].Value.ToString();
            string userName = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;

            byte[] file = null;
            string fileName = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "画像|*.jpg;*.jpeg;*.png|EXCEL|*.xlsx;*.xls;*.xlw;*.xml|ドキュメント|*.doc;*.docx|PDF|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = File.ReadAllBytes(openFileDialog.FileName);
                fileName = Path.GetFileName(openFileDialog.FileName);
            }
            else
            {
                return;
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
                if (string.IsNullOrEmpty(seqNo))
                {
                    //登録
                    sqlcom.CommandText = SqlInsert();
                    //パラメータ設定
                    sqlcom.Parameters.AddWithValue("@職員コード", code);
                    sqlcom.Parameters.AddWithValue("@診断年度", year);
                    sqlcom.Parameters.AddWithValue("@診断書類別", ruiBetsu);
                    sqlcom.Parameters.AddWithValue("@ファイル", file);
                    sqlcom.Parameters.AddWithValue("@ファイル名", fileName);
                    sqlcom.Parameters.AddWithValue("@更新者", userName);
                }
                else
                {
                    //更新
                    sqlcom.CommandText = SqlUpdate();
                    //パラメータ設定
                    sqlcom.Parameters.AddWithValue("@診断年度", year);
                    sqlcom.Parameters.AddWithValue("@診断書類別", ruiBetsu);
                    sqlcom.Parameters.AddWithValue("@ファイル", file);
                    sqlcom.Parameters.AddWithValue("@ファイル名", fileName);
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
                    lbl_Msg.Text = string.Format("[{0}.{1}]さんの「{2}」をアップロードしました。", code, name, fileName);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = string.Format("「{0}」のアップロードが失敗しました。" + ex.ToString(), fileName);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        /// <summary>
        /// ファイル削除
        /// </summary>
        private void FileDelete()
        {
            lbl_KenSuu.Text = string.Empty;
            lbl_Msg.Text = string.Empty;
            string seqNo = dgv_Result.CurrentRow.Cells["SeqNo"].Value.ToString();
            string code = dgv_Result.CurrentRow.Cells["職員コード"].Value.ToString();
            string name = dgv_Result.CurrentRow.Cells["職員氏名"].Value.ToString();
            string fileName = dgv_Result.CurrentRow.Cells["ファイル名"].Value.ToString();

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
                sqlcom.CommandText = string.Format(@"DELETE FROM HL_JEC_健康診断書 WHERE SeqNo = '{0}' ", seqNo);
                //実行
                int ret = sqlcom.ExecuteNonQuery();

                if (ret == 1)
                {
                    transaction.Commit();

                    ShowData();
                    lbl_Msg.ForeColor = Color.Green;
                    lbl_Msg.Text = string.Format("[{0}.{1}]さんの「{2}」を削除しました。", code, name, fileName);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = string.Format("「{0}」の削除が失敗しました。" + ex.ToString(), fileName);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        /// <summary>
        /// ファイル表示
        /// </summary>
        private void ShowFile()
        {
            lbl_Msg.Text = string.Empty;

            string seqNo = dgv_Result.CurrentRow.Cells["SeqNo"].Value.ToString();
            string fileName = dgv_Result.CurrentCell.Value.ToString();
            string tempdir = @"C:\Windows\Temp\";
            string sqlcmd = string.Empty;

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

            if (!string.IsNullOrEmpty(seqNo))
            {
                sqlcmd = string.Format(@"Select * From [dbo].[HL_JEC_健康診断書] Where SeqNo = {0}", seqNo);

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();

                    reader.Read();

                    //ファイルなしの場合
                    if (!reader.HasRows || string.IsNullOrEmpty(reader["ファイル"].ToString()))
                    {
                        lbl_Msg.ForeColor = Color.Red;
                        lbl_Msg.Text = "ファイルが存在しません。";
                        return;
                    }

                    string reNamePdf = tempdir + Path.GetFileNameWithoutExtension(fileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                    if (fileName.Trim().ToLower().EndsWith(".jpg") || fileName.Trim().ToLower().EndsWith(".jpeg") || fileName.Trim().ToLower().EndsWith(".png"))
                    {
                        File.WriteAllBytes(tempdir + fileName, (byte[])reader["ファイル"]);
                        ConvertJpgToPdf(tempdir + fileName, reNamePdf);
                        ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                    }
                    else if (fileName.Trim().ToLower().EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                              fileName.Trim().ToLower().EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                              fileName.Trim().ToLower().EndsWith(".xlw", StringComparison.OrdinalIgnoreCase) ||
                              fileName.Trim().ToLower().EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + fileName, (byte[])reader["ファイル"]);
                        ConvertExcelToPDF(tempdir + fileName, reNamePdf);
                        ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                    }
                    else if (".doc, .docx".Contains(fileName.Substring(fileName.LastIndexOf("."))))
                    {
                        File.WriteAllBytes(tempdir + fileName, (byte[])reader["ファイル"]);
                        ConvertWordToPDF(tempdir + fileName, reNamePdf);
                        ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                    }
                    else if (".pdf".Contains(fileName.Substring(fileName.LastIndexOf("."))))
                    {
                        File.WriteAllBytes(reNamePdf, (byte[])reader["ファイル"]);
                        ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                    }
                    else
                    {
                        return;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    lbl_Msg.ForeColor = Color.Red;
                    lbl_Msg.Text = "ファイル表示が失敗しました。";
                }
                finally
                {
                    if (sqlcon != null)
                    {
                        sqlcon.Close();
                    }

                    KillFile(tempdir, fileName);
                }
            }
        }
        #endregion

        #region ファイル処理
        /// <summary>
        /// Convert Excel File to PDF file
        /// </summary>
        private void ConvertExcelToPDF(string excelfile, string rename2PDF)
        {
            Excel.Application application = null;
            Excel.Workbook workBook = null;
            try
            {
                application = new Excel.Application();
                workBook = application.Workbooks.Open(excelfile, Type.Missing, Type.Missing, Type.Missing);
                workBook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, rename2PDF, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            catch (Exception ex)
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = ex.Message;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(false, Type.Missing, Type.Missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                    Killexcel.Kill(application);
                }
            }

        }

        /// <summary>
        /// Convert Word File to PDF File
        /// </summary>
        private void ConvertWordToPDF(string wordfile, string rename2PDF)
        {
            Word.Application application = null;
            Word.Document document = null;
            object misValue = System.Reflection.Missing.Value;
            try
            {
                application = new Word.Application();
                document = application.Documents.Open(wordfile);
                document.Activate();
                document.ExportAsFixedFormat(rename2PDF, WdExportFormat.wdExportFormatPDF);
            }
            catch (Exception ex)
            {
                lbl_Msg.ForeColor = Color.Red;
                lbl_Msg.Text = ex.Message;
            }
            finally
            {
                if (document != null)
                {
                    document.Close(Word.WdSaveOptions.wdDoNotSaveChanges, Word.WdOriginalFormat.wdOriginalDocumentFormat, false);
                    document = null;
                }
                if (application != null)
                {
                    application.Quit(Word.WdSaveOptions.wdDoNotSaveChanges, Type.Missing, Type.Missing);
                    application = null;

                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// Convert jpg File to PDF File
        /// </summary>
        /// <param name="jpgfile"></param>
        /// <param name="pdf"></param>
        private void ConvertJpgToPdf(string jpgfile, string pdf)
        {
            if (ComClass.CompressImage(jpgfile, jpgfile + ".jpg"))
            {
                File.Copy(jpgfile + ".jpg", jpgfile, true);
                File.Delete(jpgfile + ".jpg");
            }
            var document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 25, 25);
            using (var stream = new FileStream(pdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imageStream);
                    if (image.Height > PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    else if (image.Width > PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    image.Alignment = Element.ALIGN_MIDDLE;
                    document.Add(image);
                }

                document.Close();
            }
        }

        /// <summary>
        /// Delete File in temp after read or print 
        /// </summary>
        private void KillFile(string pathfile, string filename)
        {
            string[] filelist = Directory.GetFiles(pathfile);
            foreach (var item in filelist)
            {
                if (item.Contains(filename.Substring(0, filename.LastIndexOf("."))))
                {
                    File.Delete(item);
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
        /// <param name="ruiBetsu">類別</param>
        /// <returns>Sql文</returns>
        private string SqlSelect(TextBox txt, DateTimePicker year, ComboBox ruiBetsu)
        {
            string sqlSel = string.Empty;
            StringBuilder s = new StringBuilder();

            s.AppendLine("SELECT ");
            s.AppendLine("   C.SeqNo ");
            s.AppendLine("  ,A.職員コード ");
            s.AppendLine("  ,B.名前 ");
            s.AppendLine("  ,C.診断年度 ");
            s.AppendLine("  ,C.診断書類別 ");
            s.AppendLine("  ,C.ファイル名 ");
            s.AppendLine("  ,C.アップロード日付 ");
            s.AppendLine("  ,B.退職日 ");
            s.AppendLine("FROM ");
            s.AppendLine("   HL_JEC_職員情報 A ");
            s.AppendLine("LEFT JOIN ");
            s.AppendLine("   HL_JINJI_社員マスタ B ");
            s.AppendLine("ON ");
            s.AppendLine("   A.職員コード = B.社員コード ");
            s.AppendLine("LEFT JOIN ");
            s.AppendLine("   HL_JEC_健康診断書 C ");
            s.AppendLine("ON ");
            s.AppendLine("   C.職員コード = B.社員コード ");
            //年度
            if (!string.IsNullOrEmpty(year.Text))
            {
                s.AppendLine("AND ");
                s.AppendLine("   C.診断年度 = @診断年度 ");
            }
            //類別
            if (!string.IsNullOrEmpty(ruiBetsu.SelectedItem.ToString()))
            {
                s.AppendLine("AND ");
                s.AppendLine("   C.診断書類別 = @診断書類別 ");
            }
            s.AppendLine("WHERE ");
            s.AppendLine("   LEFT(B.入職日,4) <= @診断年度_入退職 ");
            s.AppendLine("AND ");
            s.AppendLine("   ISNULL(LEFT(B.退職日,4),9999) >= @診断年度_入退職 ");
            //テキストボックス検索条件
            if (!string.IsNullOrEmpty(txt.Text))
            {
                s.AppendLine("AND ");
                s.AppendLine("   (A.職員コード LIKE @検索条件 ");
                s.AppendLine("OR ");
                s.AppendLine("   B.名前 LIKE @検索条件 ");
                s.AppendLine("OR ");
                s.AppendLine("   C.診断年度 LIKE @検索条件 ");
                s.AppendLine("OR ");
                s.AppendLine("   C.診断書類別 LIKE @検索条件 ");
                s.AppendLine("OR ");
                s.AppendLine("   CONVERT(varchar(100), C.アップロード日付,111) LIKE @検索条件 ");
                s.AppendLine("OR ");
                s.AppendLine("   C.ファイル名 LIKE @検索条件) ");
            }
            s.AppendLine("ORDER BY ");
            s.AppendLine("   A.職員コード  ");

            sqlSel = s.ToString();
            return sqlSel;
        }

        /// <summary>
        /// ファイル登録のSql文
        /// </summary>
        /// <returns>Sql文</returns>
        private string SqlInsert()
        {
            string sqlupd = string.Empty;
            StringBuilder s = new StringBuilder();

            s.AppendLine("INSERT INTO HL_JEC_健康診断書 ");
            s.AppendLine("  (SeqNo ");
            s.AppendLine("  ,職員コード ");
            s.AppendLine("  ,診断年度 ");
            s.AppendLine("  ,診断書類別 ");
            s.AppendLine("  ,ファイル ");
            s.AppendLine("  ,ファイル名 ");
            s.AppendLine("  ,アップロード日付 ");
            s.AppendLine("  ,更新者) ");
            s.AppendLine("VALUES ");
            s.AppendLine("  ((SELECT ISNULL(MAX(seqNo),0) +1 FROM HL_JEC_健康診断書) ");
            s.AppendLine("  ,@職員コード ");
            s.AppendLine("  ,@診断年度 ");
            s.AppendLine("  ,@診断書類別 ");
            s.AppendLine("  ,@ファイル ");
            s.AppendLine("  ,@ファイル名 ");
            s.AppendLine("  ,getdate() ");
            s.AppendLine("  ,@更新者) ");

            sqlupd = s.ToString();
            return sqlupd;
        }

        /// <summary>
        /// ファイル更新のSql文
        /// </summary>
        /// <returns>Sql文</returns>
        private string SqlUpdate()
        {
            string sqlupd = string.Empty;
            StringBuilder s = new StringBuilder();

            s.AppendLine("UPDATE ");
            s.AppendLine("   HL_JEC_健康診断書 ");
            s.AppendLine("SET ");
            s.AppendLine("   診断年度 = @診断年度 ");
            s.AppendLine("  ,診断書類別 = @診断書類別 ");
            s.AppendLine("  ,ファイル = @ファイル ");
            s.AppendLine("  ,ファイル名 = @ファイル名 ");
            s.AppendLine("  ,アップロード日付 = getdate() ");
            s.AppendLine("  ,更新者 = @更新者 ");
            s.AppendLine("WHERE ");
            s.AppendLine("   SeqNo = @SeqNo ");

            sqlupd = s.ToString();
            return sqlupd;
        }
        #endregion

    }
}
