using ComDll;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace 飛鳥SES_人事
{
    public partial class 小口現金出納帳一覧 : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        #region 変数設定
        private string connectionString = ComClass.connectionString;
        private DateTime startDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
        private DateTime endDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")+ " 23:59:59");
        private string cmbChoose = string.Empty;
        public string syutsnyukinID = string.Empty;
        private string columnName = string.Empty;

        #endregion

        #region Main処理
        public 小口現金出納帳一覧()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期画面Load
        /// </summary>
        private void 小口現金出納帳一覧_Load(object sender, EventArgs e)
        {
            cmb_type.SelectedIndex = 0;
            cmbChoose = cmb_type.SelectedIndex.ToString();
        }

        /// <summary>
        /// 画面が閉じる時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 小口現金出納帳一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
           ((Form1)(this.Tag)).m_小口現金出納帳一覧Handle.iHandle = IntPtr.Zero;
        }

        #endregion

        #region データ設定と取得
        /// <summary>
        /// DBから呼び出すデータをテーブルに作成用
        /// </summary>
        /// <param name="str_cmd"></param>
        /// <returns></returns>
        private System.Data.DataTable GetDatatable(string str_cmd)
        {

            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_count.ForeColor = Color.Red;
                lbl_count.Text = "DBサーバーの接続に失敗しました。";
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
                lbl_count.ForeColor = Color.Red;
                lbl_count.Text = ex.ToString();
            }
            finally
            {
                sqlcon?.Close();
            }

            return null;
        }

        #endregion

        #region DGV処理

        /// <summary>
        /// DGVのセルにDoubleClick処理
        /// 出金証明書がある場合PDFファイルとしてPreviewする
        /// 入金申請書がある場合PDFファイルとしてPreviewする
        /// </summary>
        private void gridView_syutsnyukin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridView_syutsnyukin.CurrentCell.OwningColumn.HeaderText == "出金証明書")
            {
                string code = gridView_syutsnyukin.CurrentRow.Cells["出入金コード"].Value.ToString();
                string tempdir = @"D:\Temp\";

                if (gridView_syutsnyukin.CurrentCell.Value.ToString() == "-" || string.IsNullOrWhiteSpace(gridView_syutsnyukin.CurrentCell.Value.ToString()))
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = string.Format("出金証明書の添付ファイルがありません。");
                    return;
                }

                string UploadFileName = gridView_syutsnyukin.CurrentCell.Value.ToString();
                byte[] UploadFileData = null;
                string renameFile = tempdir + UploadFileName.Substring(0, UploadFileName.LastIndexOf(".")) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                string sqlcmd = string.Format(@"SELECT
                                                出金証明書
                                            FROM
	                                            HL_JEC_小口現金出納帳
                                            WHERE 
                                                出入金コード = {0}", Convert.ToInt32(code));

                try
                {
                    System.Data.DataTable tablegetdata = GetDatatable(sqlcmd);
                    UploadFileData = (byte[])tablegetdata.Rows[0][0];

                    if (UploadFileName.Trim().ToLower().EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        UploadFileName.Trim().ToLower().EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        UploadFileName.Trim().ToLower().EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                        ConvertJPEGToPDF(tempdir + UploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                    else if (UploadFileName.Trim().ToLower().EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                            UploadFileName.Trim().ToLower().EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                            UploadFileName.Trim().ToLower().EndsWith(".xlw", StringComparison.OrdinalIgnoreCase) ||
                            UploadFileName.Trim().ToLower().EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                        ConvertExcelToPDF(tempdir + UploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                    else
                    {
                        File.WriteAllBytes(renameFile, UploadFileData);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                }
                catch (Exception ex)
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = ex.ToString() + string.Format("出金証明書のファイル呼び込みに失敗しました。");
                }
                finally
                {
                    KillFile(tempdir, UploadFileName);
                }
            }
            else if (gridView_syutsnyukin.CurrentCell.OwningColumn.HeaderText == "入金申請書")
            {
                string code = gridView_syutsnyukin.CurrentRow.Cells["出入金コード"].Value.ToString();
                string tempdir = @"D:\Temp\";

                if (gridView_syutsnyukin.CurrentCell.Value.ToString() == "-" || string.IsNullOrWhiteSpace(gridView_syutsnyukin.CurrentCell.Value.ToString()))
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = string.Format("入金申請書の添付ファイルがありません。");
                    return;
                }

                string UploadFileName = gridView_syutsnyukin.CurrentCell.Value.ToString();
                byte[] UploadFileData = null;
                string renameFile = tempdir + UploadFileName.Substring(0, UploadFileName.LastIndexOf(".")) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                string sqlcmd = string.Format(@"SELECT
                                                入金申請書
                                            FROM
	                                            HL_JEC_小口現金出納帳
                                            WHERE 
                                                出入金コード = {0}", Convert.ToInt32(code));

                try
                {
                    System.Data.DataTable tablegetdata = GetDatatable(sqlcmd);
                    UploadFileData = (byte[])tablegetdata.Rows[0][0];

                    if (UploadFileName.Trim().ToLower().EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        UploadFileName.Trim().ToLower().EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        UploadFileName.Trim().ToLower().EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                        ConvertJPEGToPDF(tempdir + UploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                    else if (UploadFileName.Trim().ToLower().EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                            UploadFileName.Trim().ToLower().EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                            UploadFileName.Trim().ToLower().EndsWith(".xlw", StringComparison.OrdinalIgnoreCase) ||
                            UploadFileName.Trim().ToLower().EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                        ConvertExcelToPDF(tempdir + UploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                    else
                    {
                        File.WriteAllBytes(renameFile, UploadFileData);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                }
                catch (Exception ex)
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = ex.ToString() + string.Format("入金申請書のファイル呼び込みに失敗しました。");
                }
                finally
                {
                    KillFile(tempdir, UploadFileName);
                }
            }
        }

        #endregion

        #region コントロール処理

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {
            cmbChoose = cmb_type.SelectedIndex.ToString();
            if (cmbChoose == "0")
            {
                AllSearch();
            }
            if (cmbChoose == "1")
            {
                NyukinSearch();
            }
            if (cmbChoose == "2")
            {
                SyutsukinSearch();
            }
        }

        /// <summary>
        /// ダウンロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_download_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            System.Windows.Forms.SaveFileDialog saveDia = new SaveFileDialog();
            saveDia.Filter = "Excel|*.xls";
            saveDia.Title = "Excelファイル作成";
            if (saveDia.ShowDialog() == System.Windows.Forms.DialogResult.OK
             && !string.Empty.Equals(saveDia.FileName))
            {
                int nyuukincount = 0;
                int syukkincount = 0;
                int startmonth = Convert.ToInt32(startDate.Month);
                int lastmonth = Convert.ToInt32(endDate.Month);
                int sheetAllCount= endDate.Year * 12 + endDate.Month - startDate.Year * 12 - startDate.Month;
                DateTime sheetdate = startDate;
                int sheetcount = 1;
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet mSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add
                    (Type.Missing, Type.Missing, sheetAllCount, Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                for (DateTime start = startDate; start.Month <= endDate.Month; start = start.AddMonths(1))
                {
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[sheetcount];//sheet1取得
                    Microsoft.Office.Interop.Excel.Range range = null;
                    worksheet.Name = sheetdate.ToString("yyyyMM");
                    long totalCount = gridView_syutsnyukin.Rows.Count;
                    string fileName = saveDia.FileName;
                    int rownum = 4;
                    //タイトル
                    worksheet.Cells[1, 1] = "JEC保育園小口現金出納帳";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                    range.Font.Bold = true;//Bold
                    range.Font.Size = 14;//文字サイズ
                    worksheet.get_Range("A1", "G1").Merge(worksheet.get_Range("A1", "G1").MergeCells);
                    worksheet.get_Range("E2", "G2").Merge(worksheet.get_Range("E2", "G2").MergeCells);
                    worksheet.Cells[2, 5] = sheetdate.ToString("yyyy年MM月");
                    sheetdate = sheetdate.AddMonths(1);
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 5];
                    range.Font.Size = 14;//文字サイズ
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                    worksheet.Cells[3, 1] = "日付";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 1];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                                       //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 12;//幅
                    range.RowHeight = 19;//高さ
                    worksheet.Cells[3, 2] = "勘定科目";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 2];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                                       //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 42;//幅
                    range.RowHeight = 19;//高さ
                    worksheet.Cells[3, 3] = "摘要";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 3];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                                       //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 43;//幅
                    range.RowHeight = 19;//高さ
                    worksheet.Cells[3, 4] = "入金額";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 4];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                                       //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 12;//幅
                    range.RowHeight = 19;//高さ
                    worksheet.Cells[3, 5] = "出金額";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 5];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                                       //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 12;//幅
                    range.RowHeight = 19;//高さ
                    worksheet.Cells[3, 6] = "残高";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 6];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                                       //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 15;//幅
                    range.RowHeight = 19;//高さ
                    worksheet.Cells[3, 7] = "支払方法";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 7];
                    range.Font.Size = 14;//文字サイズ
                    range.Interior.ColorIndex = 12;//背景色
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 12;//幅
                    range.RowHeight = 19;//高さ
                    for (int r = 0; r < gridView_syutsnyukin.Rows.Count; r++)
                    {
                        
                        bool insert = false;
                        for (int i = 1; i < gridView_syutsnyukin.Columns.Count; i++)
                        {
                            if (Convert.ToDateTime(gridView_syutsnyukin.Rows[r].Cells[1].Value.ToString()).Month== start.Month &&
                                Convert.ToDateTime(gridView_syutsnyukin.Rows[r].Cells[1].Value.ToString()).Year == start.Year)
                            {
                                insert = true;
                                if (gridView_syutsnyukin.Columns[i].HeaderText == "日付")
                                {
                                    worksheet.Cells[rownum, 1] = gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString();
                                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 1];
                                    range.Font.Size = 11;//文字サイズ
                                                         //Border
                                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                                }
                                else if (gridView_syutsnyukin.Columns[i].HeaderText == "勘定科目")
                                {
                                    worksheet.Cells[rownum, 2] = gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString();
                                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 2];
                                    range.Font.Size = 11;//文字サイズ
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;//Left
                                                                                                                     //Border
                                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                                }
                                else if (gridView_syutsnyukin.Columns[i].HeaderText == "摘要")
                                {
                                    worksheet.Cells[rownum, 3] = gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString();
                                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 3];
                                    range.Font.Size = 11;//文字サイズ
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;//Left
                                                                                                                     //Border
                                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                                }
                                else if (gridView_syutsnyukin.Columns[i].HeaderText == "入金")
                                {
                                    if (!string.IsNullOrEmpty(gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString()))
                                    {
                                        nyuukincount += Convert.ToInt32(gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString().Replace("\\", string.Empty).Replace(",", string.Empty));
                                    }
                                    worksheet.Cells[rownum, 4] = gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString();
                                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 4];
                                    range.Font.Size = 11;//文字サイズ
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;//Right
                                                                                                                      //Border
                                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);

                                }
                                else if (gridView_syutsnyukin.Columns[i].HeaderText == "出金")
                                {
                                    if (!string.IsNullOrEmpty(gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString()))
                                    {
                                        syukkincount += Convert.ToInt32(gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString().Replace("\\", string.Empty).Replace(",", string.Empty));
                                    }
                                    worksheet.Cells[rownum, 5] = gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString();
                                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 5];
                                    range.Font.Size = 11;//文字サイズ
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;//Right
                                                                                                                      //Border
                                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);

                                }
                                else if (gridView_syutsnyukin.Columns[i].HeaderText == "残高")
                                {
                                    worksheet.Cells[rownum, 6] = gridView_syutsnyukin.Rows[r].Cells[i].Value.ToString();
                                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 6];
                                    range.Font.Size = 11;//文字サイズ
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;//Right
                                                                                                                      //Border
                                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                                }
                                worksheet.Cells[rownum, 7] = "現金";
                                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rownum, 7];
                                range.Font.Size = 11;//文字サイズ
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;//Left
                                                                                                                 //Border
                                range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            }
                            else
                            {
                                insert = false;
                            }
                        }
                        if (insert == true)
                        {
                            rownum++;
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    //合計
                    string lastrow = rownum.ToString();
                    worksheet.get_Range("A" + lastrow, " C" + lastrow).Merge(worksheet.get_Range("A" + lastrow, "C" + lastrow).MergeCells);
                    worksheet.Cells[lastrow, 1] = "合計";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 1];
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//Center
                    range.Font.Size = 14;//文字サイズ
                                         //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 2];
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 3];
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    worksheet.Cells[lastrow, 4] = "\\" + nyuukincount.ToString();
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 4];
                    range.Font.Size = 14;//文字サイズ
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;//Left
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    worksheet.Cells[lastrow, 5] = "\\" + syukkincount.ToString();
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 5];
                    range.Font.Size = 14;//文字サイズ
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;//Left
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    worksheet.Cells[lastrow, 6] = "";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 6];
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    worksheet.Cells[lastrow, 7] = "";
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[lastrow, 7];
                    //Border
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    if (gridView_syutsnyukin.Columns.Count > 1)
                    {
                        range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    }
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(fileName);
                    }
                    catch (Exception ex)
                    {
                        lbl_errorMessage.ForeColor = Color.Red;
                        lbl_errorMessage.Text = ex.ToString() + string.Format("ダウンロード失敗しました。");
                        return;
                    }
                    sheetcount++;
                }
                workbooks.Close();
                lbl_errorMessage.ForeColor = Color.Green;
                lbl_errorMessage.Text = string.Format("ダウンロード成功しました。");
            }
        }

        /// <summary>
        /// 開始日調整処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_startdate_Leave(object sender, EventArgs e)
        {
            startDate = Convert.ToDateTime(dtp_startdate.Value.ToString("yyyy/MM/dd"));
            if (dtp_startdate.Focused == false)
            {
                if (cmbChoose == "0")
                {
                    AllSearch();
                }
                else if (cmbChoose == "1")
                {
                    NyukinSearch();
                }
                else if (cmbChoose == "2")
                {
                    SyutsukinSearch();
                }
            }
        }

        /// <summary>
        /// 終了日調整処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_enddate_Leave(object sender, EventArgs e)
        {
            endDate = Convert.ToDateTime(dtp_enddate.Value.ToString("yyyy/MM/dd") + " 23:59:59"); 
            if (cmbChoose == "0")
            {
                AllSearch();
            }
            else if (cmbChoose == "1")
            {
                NyukinSearch();
            }
            else if (cmbChoose == "2")
            {
                SyutsukinSearch();
            }
        }

        /// <summary>
        /// コンボボックス変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbChoose = cmb_type.SelectedIndex.ToString();
            if (cmbChoose == "0")
            {
                AllSearch();
            }
            else if (cmbChoose == "1")
            {
                NyukinSearch();
            }
            else if (cmbChoose == "2")
            {
                SyutsukinSearch();
            }
        }

        /// <summary>
        /// 変更処理
        /// </summary>
        private void 変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            小口現金出納帳登録 小口現金出納帳登録Form = new 小口現金出納帳登録();
            小口現金出納帳登録Form.currentID = this.gridView_syutsnyukin.CurrentRow.Cells["出入金コード"].Value.ToString();
            小口現金出納帳登録Form.executePattern = 2;
            小口現金出納帳登録Form.user = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
            小口現金出納帳登録Form.ShowDialog();
            if (cmbChoose == "0")
            {
                AllSearch();
            }
            else if (cmbChoose == "1")
            {
                NyukinSearch();
            }
            else if (cmbChoose == "2")
            {
                SyutsukinSearch();
            }
            if (小口現金出納帳登録Form.update == true)
            {
                lbl_errorMessage.ForeColor = Color.Green;
                lbl_errorMessage.Text = "小口現金出納帳を更新しました。";
            }
            else if (小口現金出納帳登録Form.delete == true)
            {
                lbl_errorMessage.ForeColor = Color.Green;
                lbl_errorMessage.Text = "小口現金出納帳を削除しました。";
            }
            小口現金出納帳登録Form.update = false;
            小口現金出納帳登録Form.delete = false;
        }

        #endregion

        #region Support処理

        /// <summary>
        /// Convert image to pdf file
        /// </summary>
        private void ConvertJPEGToPDF(string jpgfile, string rename2PDF)
        {
            if (ComClass.CompressImage(jpgfile, jpgfile + ".jpg"))
            {
                File.Copy(jpgfile + ".jpg", jpgfile, true);
                File.Delete(jpgfile + ".jpg");

            }

            var document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 25, 25);


            using (FileStream stream = new FileStream(rename2PDF, FileMode.Create, FileAccess.Write, FileShare.None))
            {

                PdfWriter.GetInstance(document, stream);
                document.Open();

                using (FileStream imagestream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imagestream);
                    if (image.Width > PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    if (image.Height > PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
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
                lbl_count.ForeColor = Color.Red;
                lbl_count.Text = ex.Message;
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
                    //Killexcel.Kill(application);
                }
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

        #region 検索処理
        /// <summary>
        /// ALL検索処理
        /// </summary>
        private void AllSearch()
        {
            if (DateCheck())
            {
                ((Form1)(Tag)).toolStripStatusLabel2.Text = string.Empty;
                lbl_errorMessage.Text = string.Empty;
                int index = 0;
                string sqlcmd = string.Format(@"SELECT 出入金コード,日付,勘定科目,摘要,備考,入金,出金,残高,出金証明書名称,入金申請書名称,作成者,更新者 FROM HL_JEC_小口現金出納帳 WHERE 削除フラグ IS NULL AND 日付 BETWEEN '{0}' And '{1}'", startDate, endDate);

                gridView_syutsnyukin.Rows.Clear();
                gridView_syutsnyukin.Columns.Clear();

                SqlConnection sqlcon = new SqlConnection(connectionString);

                try
                {
                    sqlcon?.Open();
                }
                catch
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                    sqlcon.Close();
                    return;
                }
                //カラム作成
                gridView_syutsnyukin.Columns.Add("出入金コード", "出入金コード");
                gridView_syutsnyukin.Columns.Add("日付", "日付");
                gridView_syutsnyukin.Columns.Add("勘定科目", "勘定科目");
                gridView_syutsnyukin.Columns.Add("摘要", "摘要");
                gridView_syutsnyukin.Columns.Add("備考", "備考");
                gridView_syutsnyukin.Columns.Add("入金", "入金");
                gridView_syutsnyukin.Columns.Add("入金申請書", "入金申請書");
                gridView_syutsnyukin.Columns.Add("出金", "出金");
                gridView_syutsnyukin.Columns.Add("出金証明書", "出金証明書");
                gridView_syutsnyukin.Columns.Add("残高", "残高");
                gridView_syutsnyukin.Columns.Add("更新者", "更新者");

                gridView_syutsnyukin.Columns["出入金コード"].Visible = false;

                //Set datetime's format of the columns
                gridView_syutsnyukin.Columns["日付"].DefaultCellStyle.Format = "yyyy/MM/dd";

                //Set columns's length
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["日付"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["摘要"]).MaxInputLength = 50;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["備考"]).MaxInputLength = 50;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["入金"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["出金"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["残高"]).MaxInputLength = 12;

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        if (
                            (reader["出入金コード"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["日付"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["勘定科目"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["摘要"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["備考"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["入金"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["入金申請書名称"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["出金"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["出金証明書名称"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["残高"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["更新者"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            )
                        {
                            //Rowにデータ入れ
                            gridView_syutsnyukin.Rows.Add();
                            gridView_syutsnyukin.Rows[index].Cells["出入金コード"].Value = string.IsNullOrWhiteSpace(reader["出入金コード"].ToString()) ? "-" : reader["出入金コード"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["日付"].Value = string.IsNullOrWhiteSpace(reader["日付"].ToString()) ? "-" : Convert.ToDateTime(reader["日付"]).ToString("yyyy/MM/dd");
                            gridView_syutsnyukin.Rows[index].Cells["勘定科目"].Value = string.IsNullOrWhiteSpace(reader["勘定科目"].ToString()) ? "-" : reader["勘定科目"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["摘要"].Value = string.IsNullOrWhiteSpace(reader["摘要"].ToString()) ? "-" : reader["摘要"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["備考"].Value = string.IsNullOrWhiteSpace(reader["備考"].ToString()) ? "-" : reader["備考"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["入金"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["入金"].ToString()) ? "-" : reader["入金"].ToString());
                            gridView_syutsnyukin.Rows[index].Cells["入金申請書"].Value = string.IsNullOrWhiteSpace(reader["入金申請書名称"].ToString()) ? "-" : reader["入金申請書名称"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["出金"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["出金"].ToString()) ? "-" : reader["出金"].ToString());
                            gridView_syutsnyukin.Rows[index].Cells["出金証明書"].Value = string.IsNullOrWhiteSpace(reader["出金証明書名称"].ToString()) ? "-" : reader["出金証明書名称"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["残高"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["残高"].ToString()) ? "-" : reader["残高"].ToString());
                            if (string.IsNullOrWhiteSpace(reader["更新者"].ToString()))
                            {
                                gridView_syutsnyukin.Rows[index].Cells["更新者"].Value = string.IsNullOrWhiteSpace(reader["作成者"].ToString()) ? "-" : reader["作成者"].ToString();
                            }
                            else
                            {
                                gridView_syutsnyukin.Rows[index].Cells["更新者"].Value = string.IsNullOrWhiteSpace(reader["更新者"].ToString()) ? "-" : reader["更新者"].ToString();
                            }
                            foreach (DataGridViewCell gridCell in gridView_syutsnyukin.Rows[index].Cells)
                            {
                                gridView_syutsnyukin.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            index++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "検索処理に失敗しました." + ex.Message;
                    return;
                }
                finally
                {
                    sqlcon?.Close();
                }
                lbl_count.ForeColor = Color.Black;
                lbl_count.Text = string.Format("{0}件", index);
            }
        }

        /// <summary>
        /// 入金検索処理
        /// </summary>
        private void NyukinSearch()
        {
            if (DateCheck())
            {
                ((Form1)(Tag)).toolStripStatusLabel2.Text = string.Empty;
                lbl_errorMessage.Text = string.Empty;
                int index = 0;
                string sqlcmd = string.Format(@"SELECT 出入金コード,日付,備考,入金,出金,残高,入金申請書名称,作成者,更新者 FROM HL_JEC_小口現金出納帳 WHERE 削除フラグ IS NULL AND 日付 BETWEEN '{0}' And '{1}'", startDate, endDate);

                gridView_syutsnyukin.Rows.Clear();
                gridView_syutsnyukin.Columns.Clear();

                SqlConnection sqlcon = new SqlConnection(connectionString);

                try
                {
                    sqlcon?.Open();
                }
                catch
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                    sqlcon.Close();
                    return;
                }
                //カラム作成
                gridView_syutsnyukin.Columns.Add("出入金コード", "出入金コード");
                gridView_syutsnyukin.Columns.Add("日付", "日付");
                gridView_syutsnyukin.Columns.Add("備考", "備考");
                gridView_syutsnyukin.Columns.Add("入金", "入金");
                gridView_syutsnyukin.Columns.Add("入金申請書", "入金申請書");
                gridView_syutsnyukin.Columns.Add("残高", "残高");
                gridView_syutsnyukin.Columns.Add("更新者", "更新者");

                gridView_syutsnyukin.Columns["出入金コード"].Visible = false;

                //Set datetime's format of the columns
                gridView_syutsnyukin.Columns["日付"].DefaultCellStyle.Format = "yyyy/MM/dd";

                //Set columns's length
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["日付"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["備考"]).MaxInputLength = 50;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["入金"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["残高"]).MaxInputLength = 12;

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        if (
                            string.IsNullOrEmpty(reader["出金"].ToString())
                            && (
                            (reader["出入金コード"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["日付"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["備考"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["入金"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["入金申請書名称"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["残高"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["更新者"].ToString().IndexOf(txt_jyouken.Text) >= 0))
                            )
                        {
                            //Rowにデータ入れ
                            gridView_syutsnyukin.Rows.Add();
                            gridView_syutsnyukin.Rows[index].Cells["出入金コード"].Value = string.IsNullOrWhiteSpace(reader["出入金コード"].ToString()) ? "-" : reader["出入金コード"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["日付"].Value = string.IsNullOrWhiteSpace(reader["日付"].ToString()) ? "-" : Convert.ToDateTime(reader["日付"]).ToString("yyyy/MM/dd");
                            gridView_syutsnyukin.Rows[index].Cells["備考"].Value = string.IsNullOrWhiteSpace(reader["備考"].ToString()) ? "-" : reader["備考"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["入金"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["入金"].ToString()) ? "-" : reader["入金"].ToString());
                            gridView_syutsnyukin.Rows[index].Cells["入金申請書"].Value = string.IsNullOrWhiteSpace(reader["入金申請書名称"].ToString()) ? "-" : reader["入金申請書名称"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["残高"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["残高"].ToString()) ? "-" : reader["残高"].ToString());
                            if (string.IsNullOrWhiteSpace(reader["更新者"].ToString()))
                            {
                                gridView_syutsnyukin.Rows[index].Cells["更新者"].Value = string.IsNullOrWhiteSpace(reader["作成者"].ToString()) ? "-" : reader["作成者"].ToString();
                            }
                            else
                            {
                                gridView_syutsnyukin.Rows[index].Cells["更新者"].Value = string.IsNullOrWhiteSpace(reader["更新者"].ToString()) ? "-" : reader["更新者"].ToString();
                            }
                            foreach (DataGridViewCell gridCell in gridView_syutsnyukin.Rows[index].Cells)
                            {
                                gridView_syutsnyukin.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            index++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "検索処理に失敗しました." + ex.Message;
                    return;
                }
                finally
                {
                    sqlcon?.Close();
                }
                lbl_count.ForeColor = Color.Black;
                lbl_count.Text = string.Format("{0}件", index);
            }
        }

        /// <summary>
        /// 出金検索処理
        /// </summary>
        private void SyutsukinSearch()
        {
            if (DateCheck())
            {
                ((Form1)(Tag)).toolStripStatusLabel2.Text = string.Empty;
                lbl_errorMessage.Text = string.Empty;
                int index = 0;
                string sqlcmd = string.Format(@"SELECT 出入金コード,日付,勘定科目,摘要,入金,出金,残高,出金証明書名称,作成者,更新者 FROM HL_JEC_小口現金出納帳 WHERE 削除フラグ IS NULL AND 日付 BETWEEN '{0}' And '{1}'", startDate, endDate);

                gridView_syutsnyukin.Rows.Clear();
                gridView_syutsnyukin.Columns.Clear();

                SqlConnection sqlcon = new SqlConnection(connectionString);

                try
                {
                    sqlcon?.Open();
                }
                catch
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                    sqlcon.Close();
                    return;
                }
                //カラム作成
                gridView_syutsnyukin.Columns.Add("出入金コード", "出入金コード");
                gridView_syutsnyukin.Columns.Add("日付", "日付");
                gridView_syutsnyukin.Columns.Add("勘定科目", "勘定科目");
                gridView_syutsnyukin.Columns.Add("摘要", "摘要");
                gridView_syutsnyukin.Columns.Add("出金", "出金");
                gridView_syutsnyukin.Columns.Add("出金証明書", "出金証明書");
                gridView_syutsnyukin.Columns.Add("残高", "残高");
                gridView_syutsnyukin.Columns.Add("更新者", "更新者");

                gridView_syutsnyukin.Columns["出入金コード"].Visible = false;

                //Set datetime's format of the columns
                gridView_syutsnyukin.Columns["日付"].DefaultCellStyle.Format = "yyyy/MM/dd";

                //Set columns's length
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["日付"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["摘要"]).MaxInputLength = 50;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["出金"]).MaxInputLength = 12;
                ((DataGridViewTextBoxColumn)gridView_syutsnyukin.Columns["残高"]).MaxInputLength = 12;

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        string aaa = reader["入金"].ToString();
                        bool dd = string.IsNullOrEmpty(reader["入金"].ToString());
                        if (
                            string.IsNullOrEmpty(reader["入金"].ToString())
                            && (
                            (reader["出入金コード"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["日付"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["勘定科目"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["摘要"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["出金"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["出金証明書名称"].ToString().IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (ComClass.numToKinngake(reader["残高"].ToString()).IndexOf(txt_jyouken.Text) >= 0)
                            ||
                            (reader["更新者"].ToString().IndexOf(txt_jyouken.Text) >= 0))
                            )
                        {
                            //Rowにデータ入れ
                            gridView_syutsnyukin.Rows.Add();
                            gridView_syutsnyukin.Rows[index].Cells["出入金コード"].Value = string.IsNullOrWhiteSpace(reader["出入金コード"].ToString()) ? "-" : reader["出入金コード"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["日付"].Value = string.IsNullOrWhiteSpace(reader["日付"].ToString()) ? "-" : Convert.ToDateTime(reader["日付"]).ToString("yyyy/MM/dd");
                            gridView_syutsnyukin.Rows[index].Cells["勘定科目"].Value = string.IsNullOrWhiteSpace(reader["勘定科目"].ToString()) ? "-" : reader["勘定科目"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["摘要"].Value = string.IsNullOrWhiteSpace(reader["摘要"].ToString()) ? "-" : reader["摘要"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["出金"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["出金"].ToString()) ? "-" : reader["出金"].ToString());
                            gridView_syutsnyukin.Rows[index].Cells["出金証明書"].Value = string.IsNullOrWhiteSpace(reader["出金証明書名称"].ToString()) ? "-" : reader["出金証明書名称"].ToString();
                            gridView_syutsnyukin.Rows[index].Cells["残高"].Value = ComClass.numToKinngake(string.IsNullOrWhiteSpace(reader["残高"].ToString()) ? "-" : reader["残高"].ToString());
                            if (string.IsNullOrWhiteSpace(reader["更新者"].ToString()))
                            {
                                gridView_syutsnyukin.Rows[index].Cells["更新者"].Value = string.IsNullOrWhiteSpace(reader["作成者"].ToString()) ? "-" : reader["作成者"].ToString();
                            }
                            else
                            {
                                gridView_syutsnyukin.Rows[index].Cells["更新者"].Value = string.IsNullOrWhiteSpace(reader["更新者"].ToString()) ? "-" : reader["更新者"].ToString();
                            }
                            foreach (DataGridViewCell gridCell in gridView_syutsnyukin.Rows[index].Cells)
                            {
                                gridView_syutsnyukin.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            index++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "検索処理に失敗しました." + ex.Message;
                    return;
                }
                finally
                {
                    sqlcon?.Close();
                }
                lbl_count.ForeColor = Color.Black;
                lbl_count.Text = string.Format("{0}件", index);
            }
        }

        #endregion

        #region チェック処理
        /// <summary>
        /// 開始日終了日チェック
        /// </summary>
        private bool DateCheck()
        {
            if (startDate > endDate)
            {
                lbl_errorMessage.Text = "開始日付は終了日付より遅い、検索条件を確認してください。";
                lbl_errorMessage.ForeColor = Color.Red;
                return false;
            }
            return true;
        }
        #endregion

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //メニューの箇所設定
            System.Drawing.Point startPosition = Cursor.Position;

            System.Drawing.Point point = gridView_syutsnyukin.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = gridView_syutsnyukin.HitTest(point.X, point.Y);

            gridView_syutsnyukin.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                gridView_syutsnyukin.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
