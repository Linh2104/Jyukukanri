using ComDll;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;
using MailMessage = System.Net.Mail.MailMessage;
using Word = Microsoft.Office.Interop.Word;

namespace 飛鳥SES_人事
{
    public partial class 水泳活動参加園児一覧 : DockContent
    {
        int index = 0;
        bool isUpdate = false;
        /// <summary>
        /// DBから呼び出すデータをテーブルに作成用
        /// </summary>
        /// <param name="str_cmd"></param>
        /// <returns></returns>
        private System.Data.DataTable GetDatatable(string str_cmd)
        {
            string connectionString = ComClass.connectionString;
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {

            }

            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter(str_cmd, sqlcon);
                da.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlcon?.Close();
            }

            return null;
        }

        public 水泳活動参加園児一覧()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 水泳活動参加園児一覧_Load(object sender, EventArgs e)
        {
            Insert_水泳活動();
            display();
        }

        /// <summary>
        /// dgv情報検索と表示
        /// </summary>
        private void display()
        {
            this.gridView_水泳活動.Rows.Clear();
            string connectionString = ComClass.connectionString;
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库

            try
            {
                sqlcon.Open();
            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
                return;
            }
            //検索開始
            //string str_sqlcmd = @"SELECT 出勤機コード FROM HL_JINJI_出勤機マスタ ORDER BY 出勤機コード";
            string str_sqlcmd = "SELECT a.園児ID, " +
                "                       b.名前," +
                "                       b.性別," +
                "                       CASE WHEN DATEDIFF(yy, b.生年月日, getdate()) = 0 " +
                "                       THEN CAST(DATEDIFF(mm, b.生年月日, getdate()) as char(3))  +'カ月' " +
                "                       ELSE CAST(DATEDIFF(yy, b.生年月日, getdate()) as char(3)) + '歳'" +
                "                       END AS '年龄'," +
                "                       a.参加可否," +
                "                       a.提出年月," +
                "                       a.承諾書提出状況," +
                "                 　    b.メール," +
                "                       a.承諾書ファイル, " +
"                    　 a.送信状態 " +
                "                       FROM HL_JEC_水泳活動 a " +
                "                       LEFT OUTER JOIN HL_JEC_園児情報マスタ b " +
                "                       ON a.園児ID=b.園児コード " +
                "                       WHERE 提出年月 = '" + dtp_date.Text + "'" +
                "                       ORDER BY a.園児ID　";

            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();

            int index = 0;
            try
            {
                while (reader.Read())
                {

                    this.gridView_水泳活動.Rows.Add();
                    this.gridView_水泳活動.Rows[index].Cells["園児ID"].Value = reader["園児ID"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["園児名"].Value = reader["名前"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["性別"].Value = reader["性別"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["年齢"].Value = reader["年龄"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["参加状況"].Value = reader["参加可否"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["メール"].Value = reader["メール"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["日付"].Value = reader["提出年月"].ToString();
                    this.gridView_水泳活動.Rows[index].Cells["送信状態"].Value = reader["送信状態"].ToString();
                    if ((string)this.gridView_水泳活動.Rows[index].Cells["送信状態"].Value == "送信済み")
                    {
                        this.gridView_水泳活動.Rows[index].Cells["送信チェック"].Value = true;
                        this.gridView_水泳活動.Rows[index].Cells["送信チェック"].ReadOnly = true;
                    }
                    object o = reader["承諾書ファイル"];

                    if (o != System.DBNull.Value)
                    {
                        this.gridView_水泳活動.Rows[index].Cells["承諾書ファイル"].Value = reader["承諾書ファイル"].ToString();
                    }


                    if (reader["承諾書提出状況"].ToString() == "1")
                    {
                        this.gridView_水泳活動.Rows[index].Cells["詳細"].Style.BackColor = Color.Cyan;
                        this.gridView_水泳活動.Rows[index].Cells["詳細"].Value = "詳細";
                    }


                    index++;
                }
                this.sslbl_件数.Text = string.Format("{0}件", index);
            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "水泳活動情報取得処理に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }
        }

        /// <summary>
        /// 園児の水泳活動登録
        /// </summary>
        private void Insert_水泳活動()
        {
            string connectionString = ComClass.connectionString;
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
            System.Data.DataTable 水泳活動 = new System.Data.DataTable();
            List<string> 園児リスト = new List<string>();
            List<string> 登録園児リスト = new List<string>();

            //園児リスト検索
            try
            {
                sqlcon.Open();
            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
                return;
            }

            try
            {
                //検索開始
                string str_sqlcmd = "SELECT 園児コード, " +
                    "                       名前 " +
                    "                       FROM HL_JEC_園児情報マスタ  " +
                    "                       ORDER BY 園児コード";
                SqlDataAdapter sqlDa = new SqlDataAdapter(str_sqlcmd, sqlcon);
                SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    園児リスト.Add(reader["園児コード"].ToString());

                }


            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "水泳活動一覧の取得処理に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }

            //登録された園児リスト検索
            try
            {
                sqlcon.Open();
            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
                return;
            }

            try
            {
                //検索開始
                string str_sqlcmd = "SELECT 園児ID " +
                "                       FROM HL_JEC_水泳活動" +
                "                       WHERE 提出年月 =  '" + dtp_date.Text + "' ";
                SqlDataAdapter sqlDa = new SqlDataAdapter(str_sqlcmd, sqlcon);
                SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    登録園児リスト.Add(reader["園児ID"].ToString());

                }



            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "水泳活動一覧の取得処理に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }

            //登録園児リスト
            try
            {
                sqlcon.Open();
            }
            catch
            {
                ((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                ((Form1)(this.Tag)).toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                ((Form1)(this.Tag)).reLoad = false;
                return;
            }

            //園児情報登録
            try
            {
                string str_sqlcmd = "";
                foreach (string a in 園児リスト)
                {
                    if (登録園児リスト.Contains(a) == false)
                    {

                        str_sqlcmd += string.Format(@"insert into HL_JEC_水泳活動 (園児ID,参加可否,承諾書提出状況,承諾書ファイル,提出年月,送信状態) values ('{0}','未提出',0,NULL,'{1}') ", a, dtp_date.Text, "未送信");

                    }
                }
                if (!string.IsNullOrEmpty(str_sqlcmd))
                {
                    SqlCommand DataUpdateCmd = new SqlCommand();
                    DataUpdateCmd.Connection = sqlcon;
                    DataUpdateCmd.CommandText = str_sqlcmd;
                    DataUpdateCmd.ExecuteNonQuery();
                }

            }
            catch
            {
                //((Form1)(this.Tag)).toolStripStatusLabel2.ForeColor = Color.Red;
                //((Form1)(this.Tag)).toolStripStatusLabel2.Text = "出勤機コードリスト取得処理に失敗しました.";
                //((Form1)(this.Tag)).reLoad = false;
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }

        }

        /// <summary>
        /// PDF開く
        /// </summary>
        /// <param name="strFileName"></param>
        public static void PDF表示(string strFileName)
        {
            try
            {
                PDF表示 NewForm = new PDF表示();

                NewForm.FPD表示Show(strFileName);
                //NewForm.Show(((Form1)this.Tag).dockPanel1); //这个模式PDF不显示，原因不明。以下链接为官方共享代码的出处，大家可以利用svn下载到最新的代码。所有的修改全部建立在源代码基础上的 http://sourceforge.net/projects/dockpanelsuite
                NewForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adobe Reader がインストールされていません。\n先に【Adobe Reader】をインストールしてからもう一度試してください。");
                ComClass.OpenBrowserUrl("https://get.adobe.com/jp/reader/");
            }
        }

        /// <summary>
        /// 承諾書詳細情報開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_水泳活動_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //新建一个PDF文档，并加载测试文件
            object o = this.gridView_水泳活動.Rows[e.RowIndex].Cells["承諾書ファイル"].Value;

            if (gridView_水泳活動.Columns[e.ColumnIndex].Name == "詳細" && o != null)
            {
                string tempdir = @"C:\Windows\Temp\";
                string UploadFileName = gridView_水泳活動.CurrentCell.Value.ToString();
                string renameFile = tempdir + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                string sqlcmd = string.Format(@"SELECT 承諾書ファイル,ファイルタイプ FROM HL_JEC_水泳活動 WHERE 園児ID = {0} AND 提出年月 = '{1}'", gridView_水泳活動.Rows[e.RowIndex].Cells["園児ID"].Value, gridView_水泳活動.Rows[e.RowIndex].Cells["日付"].Value);

                System.Data.DataTable tablegetdata = GetDatatable(sqlcmd);
                byte[] UploadFileData = (byte[])tablegetdata.Rows[0][0];
                string FileType = tablegetdata.Rows[0][1].ToString();
                //
                string filename = "承諾書.pdf";
                string reNamePdf = tempdir + "column" + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                if (FileType == "jpg" || FileType == "jpeg" || FileType == "png")
                {
                    File.WriteAllBytes(tempdir + filename, (byte[])tablegetdata.Rows[0][0]);
                    ConvertJpgToPdf(tempdir + filename, reNamePdf);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                }
                else if (FileType == "xlsx" ||
                          FileType == "xls" ||
                          FileType == "xlw" ||
                          FileType == "xml")
                {
                    File.WriteAllBytes(tempdir + filename, (byte[])tablegetdata.Rows[0][0]);
                    ConvertExcelToPDF(tempdir + filename, reNamePdf);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                }
                else if (FileType == "doc" || FileType == "docx")
                {
                    File.WriteAllBytes(tempdir + filename, (byte[])tablegetdata.Rows[0][0]);
                    ConvertWordToPDF(tempdir + filename, reNamePdf);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);

                }
                else
                {
                    File.WriteAllBytes(reNamePdf, (byte[])tablegetdata.Rows[0][0]);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                }

            }
        }
        /// <summary>
        /// 日付変更の場合のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            isUpdate = false;
            if (DateTime.Now > dtp_date.Value)
            {
                Insert_水泳活動();
                display();
            }
            //未来月の場合は本月の日付に戻す
            else
            {
                dtp_date.Value = DateTime.Now;
            }
        }

        private void gridView_水泳活動_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            //{
            //    e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
            //    Rectangle rectangle = e.CellBounds;
            //    rectangle.Inflate(-2, -2);
            //    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            //    e.Handled = true;
            //}
        }
        /// <summary>
        /// 印刷画面を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_印刷_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            System.Data.DataTable 出力内容 = new System.Data.DataTable();
            string タイトル = "";
            List<int> lst広さ = new List<int>();

            ComClass.PrintOut(出力内容, タイトル, lst広さ);
        }
        /// <summary>
        /// PDF変換機能
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
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = ex.Message;
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
                    Killexcel.Kill(application);
                    application = null;
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
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = ex.Message;
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

        private void 水泳活動参加園児一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_水泳活動Handle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// ファイルをアップロードする処理
        /// </summary>
        private void アップロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] UploadFileData = null;
            string UploadFileName = string.Empty;
            string UploadFileType = string.Empty;
            string UploadFileNamePDF = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UploadFileData = File.ReadAllBytes(openFileDialog.FileName);
                UploadFileName = Path.GetFileName(openFileDialog.FileName);
                UploadFileType = Path.GetFileName(openFileDialog.FileName).Substring(Path.GetFileName(openFileDialog.FileName).LastIndexOf("."));
                UploadFileNamePDF = @"C:\Windows\Temp\承諾書" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf"; ;
            }
            else
            {
                return;
            }


            string connectionString = ComClass.connectionString;
            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                return;

            }

            int result = 0;
            string[] filetypes = UploadFileName.Split('.');
            UploadFileType = filetypes[1];

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            sqlcom.CommandText = string.Format($@"UPDATE
                                                         HL_JEC_水泳活動
                                                        SET
                                                         参加可否 = '{gridView_水泳活動.Rows[index].Cells["参加状況"].Value}',
                                                         承諾書ファイル = @UploadFileData　,
                                                         承諾書提出状況 = 1 ,
                                                         ファイルタイプ='{UploadFileType}'
                                                        WHERE
                                                         園児ID = '{gridView_水泳活動.Rows[index].Cells["園児ID"].Value}'
                                                        AND
                                                         提出年月='{gridView_水泳活動.Rows[index].Cells["日付"].Value}'");

            sqlcom.Parameters.AddWithValue("@UploadFileData", UploadFileData);

            try
            {

                result = sqlcom.ExecuteNonQuery();

                if (result == 1)
                {
                    transaction.Commit();

                    //DisplayGridView();
                    toolStripStatusLabel1.ForeColor = Color.Green;
                    toolStripStatusLabel1.Text = string.Format("ファイルのアップロードしました。");
                }

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format("ファイルのアップロード失敗しました。" + ex.ToString());
            }
            finally
            {
                sqlcon?.Close();
                isUpdate = false;
                display();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            System.Drawing.Point startPosition = Cursor.Position;
            System.Drawing.Point point = this.gridView_水泳活動.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.gridView_水泳活動.HitTest(point.X, point.Y);
            this.gridView_水泳活動.ClearSelection();

            if (hitinfo.ColumnIndex == 8)
            {
                this.gridView_水泳活動.Rows[hitinfo.RowIndex].Selected = true;
                index = hitinfo.RowIndex;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void gridView_水泳活動_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isUpdate)
            {
                display();
                isUpdate = false;
            }
        }

        private void gridView_水泳活動_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                isUpdate = true;
            }

        }

        /// <summary>
        /// セールの値（参加状況）を変更する場合データを更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_水泳活動_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isUpdate)
            {
                string connectionString = ComClass.connectionString;
                SqlConnection sqlcon = new SqlConnection(connectionString);

                try
                {
                    sqlcon?.Open();
                }
                catch
                {
                    return;

                }

                SqlTransaction transaction = sqlcon.BeginTransaction();
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlcon;
                sqlcom.Transaction = transaction;

                sqlcom.CommandText = string.Format($@"UPDATE
                                                         HL_JEC_水泳活動
                                                        SET
                                                         参加可否 = '{gridView_水泳活動.Rows[e.RowIndex].Cells["参加状況"].Value}'
                                                        WHERE
                                                         園児ID = '{gridView_水泳活動.Rows[e.RowIndex].Cells["園児ID"].Value}'
                                                        AND
                                                         提出年月='{gridView_水泳活動.Rows[e.RowIndex].Cells["日付"].Value}'");

                try
                {

                    int result = sqlcom.ExecuteNonQuery();

                    if (result == 1)
                    {
                        transaction.Commit();

                        //DisplayGridView();
                        toolStripStatusLabel1.ForeColor = Color.Green;
                        toolStripStatusLabel1.Text = string.Format("参加状況の更新は成功しました。");
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = string.Format("参加状況の更新は失敗しました。" + ex.ToString());
                }
                finally
                {
                    sqlcon?.Close();

                }
            }

            isUpdate = false;
        }

        /// <summary>
        /// メール送信機能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mail_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            string usermail = "yuki569514267@gmail.com";
            string password = "yuki8187190";
            for (int i = 0; i < gridView_水泳活動.Rows.Count; i++)
            {
                if ((string)gridView_水泳活動.Rows[i].Cells["送信状態"].Value != "送信済み")
                {
                    if ((bool)gridView_水泳活動.Rows[i].Cells["送信チェック"].EditedFormattedValue == true)
                    {
                        try
                        {

                        gridView_水泳活動.Rows[i].Cells["送信状態"].Value = "送信中...";
                        msg.To.Add((string)gridView_水泳活動.Rows[i].Cells["メール"].Value);
                        System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment("C:\\Users\\WIN10\\Desktop\\txt_data\\JEC.git\\branches\\branch1\\03_保育園資料_電子版\\00_31.水泳活動のお知らせ.docx");
                        msg.Attachments.Add(attachment);
                        attachment = new System.Net.Mail.Attachment("C:\\Users\\WIN10\\Desktop\\txt_data\\JEC.git\\branches\\branch1\\03_保育園資料_電子版\\00_32.水遊びお知らせ_2.docx");
                        msg.Attachments.Add(attachment);

                        msg.From = new MailAddress(usermail, "NagatoSun", System.Text.Encoding.UTF8);
                        /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/

                        msg.Subject = "水泳活動参加確認のメール";//邮件标题   
                        msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码   
                        msg.Body = gridView_水泳活動.Rows[i].Cells["園児名"].Value+ "\r\n"+
                                   "水泳活動参加確認書を送ります。" + "\r\n" +
                                   "ご確認お願いします。";//邮件内容   
                        msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
                        msg.IsBodyHtml = false;//是否是HTML邮件   
                        msg.Priority = MailPriority.High;//邮件优先级   
                        SmtpClient client = new SmtpClient();

                        client.Credentials = new System.Net.NetworkCredential(usermail, password);

                        //上述写你的GMail邮箱和密码   
                        client.Port = 587;//Gmail使用的端口   
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;//经过ssl加密   
                        object userState = msg;

                     
                        try
                        {
                            client.SendAsync(msg, userState);
                            gridView_水泳活動.Rows[i].Cells["送信状態"].Value = "送信済み";

                            //
                            string connectionString = ComClass.connectionString;
                            SqlConnection sqlcon = new SqlConnection(connectionString);

                            try
                            {
                                sqlcon?.Open();
                            }
                            catch
                            {
                                return;

                            }

                            int result = 0;

                            SqlTransaction transaction = sqlcon.BeginTransaction();
                            SqlCommand sqlcom = new SqlCommand();
                            sqlcom.Connection = sqlcon;
                            sqlcom.Transaction = transaction;

                            sqlcom.CommandText = string.Format($@"UPDATE
                                                         HL_JEC_水泳活動
                                                        SET
                                                         送信状態 = '{gridView_水泳活動.Rows[i].Cells["送信状態"].Value}'
                                                        WHERE
                                                         園児ID = '{gridView_水泳活動.Rows[i].Cells["園児ID"].Value}'
                                                        AND
                                                         提出年月='{gridView_水泳活動.Rows[i].Cells["日付"].Value}'");

                            try
                            {

                                result = sqlcom.ExecuteNonQuery();

                                if (result == 1)
                                {
                                    transaction.Commit();

                                    //DisplayGridView();
                                    toolStripStatusLabel1.ForeColor = Color.Green;
                                    toolStripStatusLabel1.Text = string.Format("ファイルのアップロードしました。");
                                }

                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                toolStripStatusLabel1.ForeColor = Color.Red;
                                toolStripStatusLabel1.Text = string.Format("ファイルのアップロード失敗しました。" + ex.ToString());
                            }
                            finally
                            {
                                sqlcon?.Close();
                                isUpdate = false;
                            }
                        }
                        catch (System.Net.Mail.SmtpException ex)
                        {
                            gridView_水泳活動.Rows[i].Cells["送信状態"].Value = "送信失敗";
                        }

                        }
                        catch
                        {
                            gridView_水泳活動.Rows[i].Cells["送信状態"].Value = "送信失敗";
                        }

                    }
                }
            }

        }
    }

}




