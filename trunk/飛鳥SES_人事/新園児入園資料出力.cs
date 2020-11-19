using ComDll;
using Spire.Pdf;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace 飛鳥SES_人事
{
    public partial class 新園児入園資料出力 : DockContent
    {
        //データベース接続情報
        private string connectionString = ComClass.connectionString;

        public 新園児入園資料出力()
        {
            InitializeComponent();
        }

        private void 新園児入園資料出力_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            rtxt_list.Text = "(1) 入園・登録申込書         \n" +
                             "(2) 緊急連絡                 \n" +
                             "(3) 児童調査票               \n" +
                             "(4) 健康調査票               \n" +
                             "(5) 保護者同意書             \n" +
                             "(6) 保育事業利用報告書       \n" +
                             "(7) 撮影と写真掲載承諾書     \n" +
                             "(8) 個人情報の取扱い同意書   ";
        }

        private void 新園児入園資料出力_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_新園児入園資料出力Handle.iHandle = IntPtr.Zero;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            // 印刷機能生成
            AskPrintPice Formtemp = new AskPrintPice();
            Formtemp.StartPosition = FormStartPosition.CenterParent;
            Formtemp.ShowDialog();
            int pice = Formtemp.pice_back;

            if (pice > 0)
            {
                //データベースへ接続
                SqlConnection sqlcon = new SqlConnection(connectionString);

                try
                {
                    sqlcon.Open();
                }
                catch
                {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                    sqlcon.Close();
                    return;
                }

                string tmpDir = @"C:\Windows\Temp\";
                string filePath = string.Empty;
                string sqlcmd = "Select ファイル名, ファイル, ファイルタイプ From HL_JEC_保育園業務書類フォーマット";

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        byte[] file = (byte[])reader["ファイル"];
                        string fileName = reader["ファイル名"].ToString();
                        string type = reader["ファイルタイプ"].ToString();
                        
                        switch (fileName)
                        {
                            case "入園・登録申込書":
                            case "緊急連絡":
                            case "児童調査票":
                            case "健康調査票":
                            case "保護者同意書":
                            case "保育事業利用報告書":
                            case "撮影と写真掲載承諾書":
                            case "個人情報の取扱い同意書":
                                lbl_error.ForeColor = Color.Black;
                                lbl_error.Text = string.Format("ファイル[{0}]を印刷中...", fileName);

                                if (type == "Excel")
                                {
                                    filePath = tmpDir + fileName + ".xls";
                                    File.WriteAllBytes(filePath, file);
                                    ExcelFilePrint(filePath, pice, Formtemp.print_back);
                                }
                                else if (type == "Word")
                                {
                                    filePath = tmpDir + fileName + ".doc";
                                    File.WriteAllBytes(filePath, file);
                                    WordFilePrint(filePath, pice, Formtemp.print_back);
                                }
                                else if (type == "PDF")
                                {
                                    filePath = tmpDir + fileName + ".pdf";
                                    File.WriteAllBytes(filePath, file);
                                    PDFFilePrint(filePath, pice, Formtemp.print_back);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    reader.Close();

                    lbl_error.ForeColor = Color.Green;
                    lbl_error.Text = "印刷完了しました。";
                }
                catch (Exception ex)
                {
                    if (ex.Message != "HRESULT からの例外: 0x800A03EC")
                    {
                        lbl_error.ForeColor = Color.Red;
                        lbl_error.Text = ex.Message;
                    }
                    return;
                }
                finally
                {
                    sqlcon?.Close();
                }
            }   
        }

        private void ExcelFilePrint(string filePath, int 部数, string プリンター名)
        {
            Excel.Application application = new Excel.Application();
            application.Visible = false;
            application.DisplayAlerts = false;

            Excel.Workbooks workBook = (Excel.Workbooks)application.Workbooks;
            Excel._Workbook m_objBook = (Excel._Workbook)(workBook.Add(filePath));
            Excel.Worksheet wSheet = m_objBook.Worksheets[1] as Excel.Worksheet;

            try
            {
                m_objBook.PrintOutEx(Type.Missing, Type.Missing, 部数, false, プリンター名);
            }
            catch (Exception ex)
            {
                if (ex.Message != "HRESULT からの例外:0x800A03EC")
                {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = ex.Message;
                }
                return;
            }
            finally
            {
                application.Quit();
                Killexcel.Kill(application);
            }
        }

        private void WordFilePrint(string filePath, int 部数, string プリンター名)
        {
            Word.Application oWord = new Word.Application();
            Word._Document oDoc = null;
            object oMissing = System.Reflection.Missing.Value;

            oWord.Visible = false;
            oWord.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            oWord.ActivePrinter = プリンター名;

            object inFileName = filePath;
            oDoc = oWord.Documents.Add(ref inFileName, ref oMissing, ref oMissing, ref oMissing);

            try
            {
                oDoc.PrintOut(Type.Missing, Type.Missing, Word.WdPrintOutRange.wdPrintAllDocument, Type.Missing,
                          Type.Missing, Type.Missing, Word.WdPrintOutItem.wdPrintDocumentContent, 部数);
            }
            catch (Exception ex)
            {
                if (ex.Message != "HRESULT からの例外:0x800A03EC")
                {
                    lbl_error.ForeColor = Color.Red;
                    lbl_error.Text = ex.Message;
                }
                return;
            }
            finally
            {
                object paramMissing = Type.Missing;
                if (oDoc != null)
                {
                    oDoc.Close(false, paramMissing, ref paramMissing);
                    oDoc = null;
                }
                if (oWord != null)
                {
                    oWord.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    oWord = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void PDFFilePrint(string filePath, int 部数, string プリンター名)
        {
            PdfDocument pdf = new PdfDocument(filePath);
            pdf.PrintSettings.DocumentName = Path.GetFileNameWithoutExtension(filePath);
            pdf.PrintSettings.PrinterName = プリンター名;
            pdf.PrintSettings.Copies = (short)部数;
            pdf.Print();
        }
    }
}
