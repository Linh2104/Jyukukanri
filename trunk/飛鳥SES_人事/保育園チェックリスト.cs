using ComDll;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;

namespace 飛鳥SES_人事
{
    public partial class 保育園チェックリスト : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        #region 変数設定
        private string connectionString = ComClass.connectionString;
        public string syutsnyukinID = string.Empty;
        private string columnName = string.Empty;
        private DateTime startDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
        private DateTime endDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59");
        private System.Data.DataTable dt = null;

        //更新フラグ
        private bool IsUpdating = false;
        //Add chen 2020/11/05
        private bool IsOpenClose = false;
        //End chen 2020/11/05
        //Add chen 2020/11/11
        DateTime ListDate = DateTime.Now;
        //Add chen 2020/11/11
        //gridView変更前の値
        private string beforeValue = string.Empty;
        //登録更新用ユーザー名
        private string user = string.Empty;
        #endregion

        #region Main処理
        public 保育園チェックリスト()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期画面Load
        /// </summary>
        private void 保育園チェックリスト_Load(object sender, EventArgs e)
        {
            user = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
            cmb_koumoku.SelectedIndex = 0;

        }

        /// <summary>
        /// 画面が閉じる時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保育園チェックリスト_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_保育園チェックリストHandle.iHandle = IntPtr.Zero;
        }

        #endregion

        #region コントロール処理
        /// <summary>
        /// ダウンロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_download_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            System.Windows.Forms.SaveFileDialog saveDia = new SaveFileDialog();
            saveDia.FileName = "保育園チェックリスト_" + ListDate.ToString("yyyyMMdd");
            saveDia.Filter = "Excel|*.xls";
            saveDia.Title = "Excelファイル作成";
            if (saveDia.ShowDialog() == System.Windows.Forms.DialogResult.OK
             && !string.Empty.Equals(saveDia.FileName))
            {
                lbl_errorMessage.ForeColor = Color.Black;
                lbl_errorMessage.Text = "Excel出力中...";
            

                try
                {


                    Workbooks workbooks = xlApp.Workbooks;
                    Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    Worksheet mSheet = (Worksheet)workbook.Worksheets.Add
                        (Type.Missing, Type.Missing, 1, XlSheetType.xlWorksheet);

                    Worksheet worksheet = (Worksheet)workbook.Worksheets[1];//sheet取得
                    Range range = null;
                    long totalCount = gridView_checkList.Rows.Count;
                    string fileName = saveDia.FileName;

                    //タイトル
                    worksheet.Cells[2, 2] = "保育園チェックリスト";
                    range = (Range)worksheet.Cells[2, 2];
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;//Center
                    range.Font.Bold = true;//Bold
                    range.Font.Size = 20;//文字サイズ
                    worksheet.get_Range("B2", "I2").Merge(worksheet.get_Range("B2", "I2").MergeCells);
                    worksheet.get_Range("B4", "I4").Merge(worksheet.get_Range("B4", "I4").MergeCells);
                    if (cmb_koumoku.Text == "施設・設備")
                    {
                        worksheet.Cells[4, 2] = "ー　施設・設備編　ー";
                    }
                    else
                    {
                        worksheet.Cells[4, 2] = "ー　遊具編　ー";
                    }
                    range = (Range)worksheet.Cells[4, 2];
                    range.Font.Size = 11;//文字サイズ
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;//Center
                    //worksheet.Cells[5, 9] = "No.1";
                    range = (Range)worksheet.Cells[5, 9];
                    range.Font.Size = 11;//文字サイズ
                                         //表
                    if (cmb_koumoku.Text == "施設・設備")
                    {
                        worksheet.Cells[7, 2] = "場　所";
                        worksheet.get_Range("B7", "C7").Merge(worksheet.get_Range("B7", "C7").MergeCells);
                        range = worksheet.get_Range("B7", "C7");
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 8;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 4] = "点　検　内　容　例";
                        worksheet.get_Range("D7", "F7").Merge(worksheet.get_Range("D7", "F7").MergeCells);
                        range = worksheet.get_Range("D7", "F7");
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 15;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 7] = "ﾁｪｯｸ";
                        range = (Excel.Range)worksheet.Cells[7, 7];
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 9;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 8] = "処置";
                        range = (Excel.Range)worksheet.Cells[7, 8];
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 9;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 9] = "報告";
                        range = (Excel.Range)worksheet.Cells[7, 9];
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 9;//幅
                        range.RowHeight = 14.25;//高さ

                        int rownum = 8;
                        for (int r = 0; r < gridView_checkList.Rows.Count; r++)
                        {
                            if (!string.IsNullOrEmpty(gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString()))
                            {
                                int n = gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString().Length;
                                worksheet.Cells[rownum, 2] = gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString().Substring(2, n - 2);
                            }
                            range = (Excel.Range)worksheet.Cells[rownum, 2];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 8;//幅
                            range.RowHeight = 14.25;//高さ
                            if (!string.IsNullOrEmpty(gridView_checkList.Rows[r].Cells["サブ項目"].Value.ToString()))
                            {
                                int n = gridView_checkList.Rows[r].Cells["サブ項目"].Value.ToString().Length;
                                worksheet.Cells[rownum, 3] = gridView_checkList.Rows[r].Cells["サブ項目"].Value.ToString().Substring(2, n - 2);
                            }
                            range = (Excel.Range)worksheet.Cells[rownum, 3];
                            range.Font.Size = 11;//文字サイズ
                            range.ColumnWidth = 8;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 4] = gridView_checkList.Rows[r].Cells["点検内容例"].Value.ToString();
                            worksheet.get_Range("D" + rownum, "F" + rownum).Merge(worksheet.get_Range("D" + rownum, "F" + rownum).MergeCells);
                            range = worksheet.get_Range("D" + rownum, "F" + rownum);
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//Center
                                                                                    //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 15;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 7] = gridView_checkList.Rows[r].Cells["チェック"].Value.ToString();
                            range = (Excel.Range)worksheet.Cells[rownum, 7];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 9;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 8] = gridView_checkList.Rows[r].Cells["処置"].Value.ToString();
                            range = (Excel.Range)worksheet.Cells[rownum, 8];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 9;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 9] = gridView_checkList.Rows[r].Cells["報告"].Value.ToString();
                            range = (Excel.Range)worksheet.Cells[rownum, 9];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 9;//幅
                            range.RowHeight = 14.25;//高さ
                            rownum++;
                        }

                        int startrow1 = 8;
                        int endtrow1 = 8;
                        int startrow2 = 8;
                        int endtrow2 = 8;
                        rownum = 8;
                        for (int r = 0; r < gridView_checkList.Rows.Count; r++)
                        {
                            if (!string.IsNullOrEmpty(gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString()))
                            {
                                endtrow1 = rownum;
                                if (endtrow1 != startrow1)
                                {
                                    range = (Range)worksheet.get_Range("B" + startrow1, "B" + (endtrow1 - 1).ToString());
                                    range.Merge(0);
                                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    range.WrapText = true;
                                    startrow1 = rownum;
                                    range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border

                                    range = (Range)worksheet.get_Range("C" + startrow2, "C" + (endtrow1 - 1).ToString());
                                    range.Merge(0);
                                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    range.WrapText = true;
                                    startrow2 = rownum;
                                    range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border
                                }
                            }
                            if (!string.IsNullOrEmpty(gridView_checkList.Rows[r].Cells["サブ項目"].Value.ToString()))
                            {
                                endtrow2 = rownum;
                                if (endtrow2 != startrow2)
                                {
                                    range = (Range)worksheet.get_Range("C" + startrow2, "C" + (endtrow2 - 1).ToString());
                                    range.Merge(0);
                                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    range.WrapText = true;
                                    startrow2 = rownum;
                                    range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border
                                }
                            }
                            if (r == gridView_checkList.Rows.Count - 1)
                            {
                                endtrow1 = rownum;
                                range = (Range)worksheet.get_Range("B" + startrow1, "B" + (endtrow1).ToString());
                                range.Merge(0);
                                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                range.WrapText = true;
                                startrow1 = rownum;
                                range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border

                                range = (Range)worksheet.get_Range("C" + startrow2, "C" + (endtrow1).ToString());
                                range.Merge(0);
                                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                range.WrapText = true;
                                startrow2 = rownum;
                                range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border
                            }
                            rownum++;
                        }
                    }
                    else
                    {
                        worksheet.Cells[7, 2] = "点　検　内　容　例";
                        worksheet.get_Range("B7", "F7").Merge(worksheet.get_Range("B7", "F7").MergeCells);
                        range = worksheet.get_Range("B7", "F7");
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 12;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 7] = "ﾁｪｯｸ";
                        range = (Excel.Range)worksheet.Cells[7, 7];
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 9;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 8] = "処置";
                        range = (Excel.Range)worksheet.Cells[7, 8];
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 9;//幅
                        range.RowHeight = 14.25;//高さ
                        worksheet.Cells[7, 9] = "報告";
                        range = (Excel.Range)worksheet.Cells[7, 9];
                        range.Font.Size = 11;//文字サイズ
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                  //Border
                        range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                        range.ColumnWidth = 9;//幅
                        range.RowHeight = 14.25;//高さ

                        int rownum = 8;
                        for (int r = 0; r < gridView_checkList.Rows.Count; r++)
                        {
                            if (!string.IsNullOrEmpty(gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString()))
                            {
                                int n = gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString().Length;
                                worksheet.Cells[rownum, 2] = gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString().Substring(2, n - 2);
                            }
                            range = (Excel.Range)worksheet.Cells[rownum, 2];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 8;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 3] = gridView_checkList.Rows[r].Cells["点検内容例"].Value.ToString();
                            worksheet.get_Range("C" + rownum, "F" + rownum).Merge(worksheet.get_Range("C" + rownum, "F" + rownum).MergeCells);
                            range = worksheet.get_Range("C" + rownum, "F" + rownum);
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//Center
                                                                                    //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 12;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 7] = gridView_checkList.Rows[r].Cells["チェック"].Value.ToString();
                            range = (Excel.Range)worksheet.Cells[rownum, 7];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 9;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 8] = gridView_checkList.Rows[r].Cells["処置"].Value.ToString();
                            range = (Excel.Range)worksheet.Cells[rownum, 8];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 9;//幅
                            range.RowHeight = 14.25;//高さ
                            worksheet.Cells[rownum, 9] = gridView_checkList.Rows[r].Cells["報告"].Value.ToString();
                            range = (Excel.Range)worksheet.Cells[rownum, 9];
                            range.Font.Size = 11;//文字サイズ
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                                      //Border
                            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                            range.ColumnWidth = 9;//幅
                            range.RowHeight = 14.25;//高さ
                            rownum++;
                        }

                        int startrow1 = 8;
                        int endtrow1 = 8;
                        rownum = 8;
                        for (int r = 0; r < gridView_checkList.Rows.Count; r++)
                        {
                            if (!string.IsNullOrEmpty(gridView_checkList.Rows[r].Cells["メイン項目"].Value.ToString()))
                            {
                                endtrow1 = rownum;
                                if (endtrow1 != startrow1)
                                {
                                    range = (Range)worksheet.get_Range("B" + startrow1, "B" + (endtrow1 - 1).ToString());
                                    range.Merge(0);
                                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    range.WrapText = true;
                                    startrow1 = rownum;
                                    range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border
                                }
                            }
                            if (r == gridView_checkList.Rows.Count - 1)
                            {
                                endtrow1 = rownum;
                                range = (Range)worksheet.get_Range("B" + startrow1, "B" + (endtrow1).ToString());
                                range.Merge(0);
                                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                range.WrapText = true;
                                startrow1 = rownum;
                                range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);//Border
                            }
                            rownum++;
                        }
                    }
                    worksheet.Cells[6, 2] = "点検日";
                    worksheet.get_Range("B6", "C6").Merge(worksheet.get_Range("B6", "C6").MergeCells);
                    range = worksheet.get_Range("B6", "C6");
                    range.Font.Size = 11;//文字サイズ
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;//Center
                                                                        //Border
                    range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 8;//幅
                    range.RowHeight = 28;//高さ
                    worksheet.Cells[6, 4] = ListDate.ToString("yyyy年MM月dd日");
                    range = (Excel.Range)worksheet.Cells[6, 4];
                    range.Font.Size = 11;//文字サイズ
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                              //Border
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 15;//幅
                    range.RowHeight = 28;//高さ
                    worksheet.Cells[6, 5] = "点検者";
                    range = (Excel.Range)worksheet.Cells[6, 5];
                    range.Font.Size = 11;//文字サイズ
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                              //Border
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 15;//幅
                    range.RowHeight = 28;//高さ
                    worksheet.Cells[6, 6] = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
                    worksheet.get_Range("F6", "I6").Merge(worksheet.get_Range("F6", "I6").MergeCells);
                    range = worksheet.get_Range("F6", "I6");
                    range.Font.Size = 11;//文字サイズ
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//Center
                                                                              //Border
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    range.ColumnWidth = 10;//幅
                    range.RowHeight = 28;//高さ


                    System.Windows.Forms.Application.DoEvents();


                    if (gridView_checkList.Columns.Count > 1)
                    {
                        range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
                    }
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(fileName);
                    }
                    catch (Exception ex)
                    {
                        lbl_errorMessage.ForeColor = Color.Red;
                        lbl_errorMessage.Text = ex.ToString() + string.Format("保育園チェックリスト記録のダウンロードは失敗しました。");
                        return;
                    }

                    workbooks.Close();
                    lbl_errorMessage.ForeColor = Color.Green;
                    lbl_errorMessage.Text = string.Format("保育園チェックリスト記録のダウンロードは成功しました。");
                }
                catch (Exception ex)
                {
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = ex.ToString() + string.Format("保育園チェックリスト記録のダウンロードは失敗しました。");
                }
            }
        }

        //mod chen 2020/11/11
        /// <summary>
        /// 日付調整処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Sarch_Click(object sender, EventArgs e)
        {
            lbl_errorMessage.Text = string.Empty;
            ((Form1)(Tag)).toolStripStatusLabel2.Text = string.Empty;
            ListDate = dtp_date.Value;
            startDate = Convert.ToDateTime(ListDate.ToString("yyyy/MM/dd"));
            endDate = Convert.ToDateTime(ListDate.ToString("yyyy/MM/dd") + " 23:59:59");
            IsUpdating = false;
            if (cmb_koumoku.SelectedIndex == 0)
            {
                Type1();
            }
            else if (cmb_koumoku.SelectedIndex == 1)
            {
                Type2();
            }
        }
        //mod chen 2020/11/11

        /// <summary>
        /// コンボボックス変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_koumoku_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsUpdating = false;
            if (cmb_koumoku.SelectedIndex == 0)
            {
                Type1();
            }
            else if (cmb_koumoku.SelectedIndex == 1)
            {
                Type2();
            }
        }

        /// <summary>
        /// openボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenGridViewDetail();
        }

        /// <summary>
        /// closeボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            OpenGridViewDetail(false);
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_insert_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction;
            int error = 0;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction("DataUpdate");
            }
            catch (Exception)
            {
                lbl_errorMessage.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                lbl_errorMessage.ForeColor = Color.Red;
                connection?.Close();
                return;
            }
            try
            {
                SqlCommand DataUpdateCmd = new SqlCommand();
                DataUpdateCmd.Connection = connection;
                DataUpdateCmd.CommandType = CommandType.Text;
                DataUpdateCmd.Transaction = transaction;
                DataUpdateCmd.CommandText = @"INSERT INTO HL_JEC_保育園チェックリスト記録 (日付, 更新日時, メイン項目, サブ項目, 点検内容コード, チェック, 処置, 報告, 担当者) ";
                for (int r = 0; r < gridView_checkList.Rows.Count; r++)
                {
                    DataUpdateCmd.CommandText = DataUpdateCmd.CommandText + string.Format(
                      "SELECT '{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}' ",
                      ListDate, DateTime.Now,
                      gridView_checkList.Rows[r].Cells["GroupCode1"].Value.ToString(),
                      gridView_checkList.Rows[r].Cells["GroupCode2"].Value.ToString(),
                      gridView_checkList.Rows[r].Cells["点検内容コード"].Value.ToString(),
                      gridView_checkList.Rows[r].Cells["チェック"].Value.ToString(),
                      gridView_checkList.Rows[r].Cells["処置"].Value.ToString(),
                      gridView_checkList.Rows[r].Cells["報告"].Value.ToString(),
                      ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ);
                    if (r != gridView_checkList.Rows.Count - 1)
                    {
                        DataUpdateCmd.CommandText = DataUpdateCmd.CommandText + " UNION ALL ";
                    }
                }
                int AdaptedRows = DataUpdateCmd.ExecuteNonQuery();
                if (AdaptedRows == 0)
                {
                    error++;
                }
                if (error == 0)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
                connection.Close();
                lbl_errorMessage.ForeColor = Color.Green;
                lbl_errorMessage.Text = "保育園チェックリスト記録を登録しました。";
                btn_insert.Enabled = false;
            }
            catch
            {
                transaction?.Rollback();
                connection?.Close();
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = "保育園チェックリスト記録の登録は失敗しました。";
            }
        }
        #endregion

        #region 検索処理
        /// <summary>
        /// 施設・設備検索処理
        /// 記録がある場合と記録がない場合
        /// </summary>
        private void Type1()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon?.Open();
            }
            catch
            {
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = "サーバーとの接続に失敗しました、インターネット接続を確認してください。";
                sqlcon.Close();
                return;
            }

            ((Form1)(Tag)).toolStripStatusLabel2.Text = string.Empty;


            string sqlcmd = string.Format(@"SELECT a.記録コード,a.日付,a.メイン項目,a.サブ項目,b.点検内容,a.チェック,a.処置,
                a.報告 FROM HL_JEC_保育園チェックリスト記録 a LEFT JOIN HL_JEC_保育園チェックリスト点検内容 b ON 
                a.点検内容コード = b.点検内容コード WHERE a.日付 BETWEEN '{0}' And '{1}'", startDate, endDate);
            SqlDataAdapter sqlDa1 = new SqlDataAdapter(sqlcmd, sqlcon);
            System.Data.DataTable dt = new System.Data.DataTable();
            sqlDa1.Fill(dt);
            //HL_JEC_保育園チェックリスト記録に登録されていない場合のGRIDVIEW設定
            if (dt.Rows.Count == 0)
            {
                IsUpdating = false;
                btn_insert.Enabled = true;
                sqlcmd = string.Format(@"SELECT メイン項目,サブ項目,点検内容,点検内容コード FROM HL_JEC_保育園チェックリスト点検内容 WHERE 点検内容種別 = 'S' ORDER BY 点検内容コード");
                gridView_checkList.Rows.Clear();

                dt = new System.Data.DataTable();
                dt.Columns.Add("メイン項目");
                dt.Columns.Add("サブ項目");
                dt.Columns.Add("点検内容例");
                dt.Columns.Add("GroupCode1");
                dt.Columns.Add("GroupCode2");
                dt.Columns.Add("点検内容コード");

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();
                    string メイン項目 = string.Empty;
                    string サブ項目 = string.Empty;

                    while (reader.Read())
                    {
                        DataRow r = dt.NewRow();
                        if (メイン項目 == string.Empty || メイン項目 != reader["メイン項目"].ToString())
                        {
                            メイン項目 = reader["メイン項目"].ToString();
                            サブ項目 = reader["サブ項目"].ToString();
                            r["メイン項目"] = "- " + reader["メイン項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["点検内容コード"] = reader["点検内容コード"].ToString();
                            r["GroupCode1"] = reader["メイン項目"].ToString();
                            r["GroupCode2"] = reader["サブ項目"].ToString();
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 == reader["サブ項目"].ToString())
                        {
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["点検内容コード"] = reader["点検内容コード"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 != reader["サブ項目"].ToString())
                        {
                            サブ項目 = reader["サブ項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["点検内容コード"] = reader["点検内容コード"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                    }
                    int 行数 = dt.Rows.Count;
                    int メイン項目count = 0;
                    gridView_checkList.Columns["サブ項目"].Visible = true;
                    for (int i = 0; i < 行数; i++)
                    {
                        gridView_checkList.Rows.Add();
                        gridView_checkList.RowHeadersVisible = false;
                        gridView_checkList.Rows[i].Cells["メイン項目"].Value = (dt.Rows[i]["メイン項目"] == null ? string.Empty : dt.Rows[i]["メイン項目"].ToString());
                        gridView_checkList.Rows[i].Cells["サブ項目"].Value = (dt.Rows[i]["サブ項目"] == null ? string.Empty : dt.Rows[i]["サブ項目"].ToString());
                        gridView_checkList.Rows[i].Cells["点検内容例"].Value = (dt.Rows[i]["点検内容例"] == null ? string.Empty : dt.Rows[i]["点検内容例"].ToString());
                        gridView_checkList.Rows[i].Cells["チェック"].Value = "";
                        gridView_checkList.Rows[i].Cells["処置"].Value = "";
                        gridView_checkList.Rows[i].Cells["報告"].Value = "×".ToString();
                        gridView_checkList.Rows[i].Cells["GroupCode1"].Value = (dt.Rows[i]["GroupCode1"] == null ? string.Empty : dt.Rows[i]["GroupCode1"].ToString());
                        gridView_checkList.Rows[i].Cells["GroupCode2"].Value = (dt.Rows[i]["GroupCode2"] == null ? string.Empty : dt.Rows[i]["GroupCode2"].ToString());
                        gridView_checkList.Rows[i].Cells["点検内容コード"].Value = (dt.Rows[i]["点検内容コード"] == null ? string.Empty : dt.Rows[i]["点検内容コード"].ToString());

                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["メイン項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                            gridView_checkList.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                            メイン項目count++;
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["メイン項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["サブ項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["点検内容例"].Style.BackColor = Color.White;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["サブ項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                        }
                        //空白セル
                        foreach (DataGridViewCell gvCell in gridView_checkList.Rows[i].Cells)
                        {
                            if (gvCell.Value == null)
                            {
                                gvCell.Style.BackColor = Color.White;
                                gvCell.ReadOnly = true;
                                gridView_checkList.Rows[i].Cells[gvCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                    }
                    lbl_count.ForeColor = Color.Black;
                    lbl_count.Text = メイン項目count.ToString() + "件";
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
            }
            //HL_JEC_保育園チェックリスト記録に登録されている場合のGRIDVIEW設定
            else
            {
                gridView_checkList.Rows.Clear();

                dt = new System.Data.DataTable();
                dt.Columns.Add("記録コード");
                dt.Columns.Add("メイン項目");
                dt.Columns.Add("サブ項目");
                dt.Columns.Add("点検内容例");
                dt.Columns.Add("チェック");
                dt.Columns.Add("処置");
                dt.Columns.Add("報告");
                dt.Columns.Add("GroupCode1");
                dt.Columns.Add("GroupCode2");

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();
                    string メイン項目 = string.Empty;
                    string サブ項目 = string.Empty;

                    while (reader.Read())
                    {
                        DataRow r = dt.NewRow();
                        if (メイン項目 == string.Empty || メイン項目 != reader["メイン項目"].ToString())
                        {
                            メイン項目 = reader["メイン項目"].ToString();
                            サブ項目 = reader["サブ項目"].ToString();
                            r["記録コード"] = reader["記録コード"].ToString();
                            r["メイン項目"] = "- " + reader["メイン項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["チェック"] = reader["チェック"].ToString();
                            r["処置"] = reader["処置"].ToString();
                            r["報告"] = reader["報告"].ToString();
                            r["GroupCode1"] = reader["メイン項目"].ToString();
                            r["GroupCode2"] = reader["サブ項目"].ToString();
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 == reader["サブ項目"].ToString())
                        {
                            //Add chen 2020/11/05
                            r["記録コード"] = reader["記録コード"].ToString();
                            //End chen 2020/11/05
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["チェック"] = reader["チェック"].ToString();
                            r["処置"] = reader["処置"].ToString();
                            r["報告"] = reader["報告"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 != reader["サブ項目"].ToString())
                        {
                            サブ項目 = reader["サブ項目"].ToString();
                            //Add chen 2020/11/05
                            r["記録コード"] = reader["記録コード"].ToString();
                            //End chen 2020/11/05
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["チェック"] = reader["チェック"].ToString();
                            r["処置"] = reader["処置"].ToString();
                            r["報告"] = reader["報告"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                    }
                    int 行数 = dt.Rows.Count;
                    int メイン項目count = 0;
                    gridView_checkList.Columns["サブ項目"].Visible = true;
                    for (int i = 0; i < 行数; i++)
                    {
                        gridView_checkList.Rows.Add();
                        gridView_checkList.RowHeadersVisible = false;
                        gridView_checkList.Rows[i].Cells["記録コード"].Value = (dt.Rows[i]["記録コード"] == null ? string.Empty : dt.Rows[i]["記録コード"].ToString());
                        gridView_checkList.Rows[i].Cells["メイン項目"].Value = (dt.Rows[i]["メイン項目"] == null ? string.Empty : dt.Rows[i]["メイン項目"].ToString());
                        gridView_checkList.Rows[i].Cells["サブ項目"].Value = (dt.Rows[i]["サブ項目"] == null ? string.Empty : dt.Rows[i]["サブ項目"].ToString());
                        gridView_checkList.Rows[i].Cells["点検内容例"].Value = (dt.Rows[i]["点検内容例"] == null ? string.Empty : dt.Rows[i]["点検内容例"].ToString());
                        if (string.IsNullOrEmpty(dt.Rows[i]["チェック"].ToString()))
                        {
                            gridView_checkList.Rows[i].Cells["チェック"].Value = "";
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["チェック"].Value = dt.Rows[i]["チェック"].ToString();
                        }
                        gridView_checkList.Rows[i].Cells["処置"].Value = (dt.Rows[i]["処置"] == null ? string.Empty : dt.Rows[i]["処置"].ToString());
                        if (string.IsNullOrEmpty(dt.Rows[i]["報告"].ToString()))
                        {
                            gridView_checkList.Rows[i].Cells["報告"].Value = "×".ToString();
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["報告"].Value = dt.Rows[i]["報告"].ToString();
                            if (dt.Rows[i]["報告"].ToString() == "○")
                            {
                                gridView_checkList.Rows[i].Cells["報告"].Style.BackColor = Color.White;
                                gridView_checkList.Rows[i].Cells["報告"].ReadOnly = true;
                            }
                        }
                        gridView_checkList.Rows[i].Cells["GroupCode1"].Value = (dt.Rows[i]["GroupCode1"] == null ? string.Empty : dt.Rows[i]["GroupCode1"].ToString());
                        gridView_checkList.Rows[i].Cells["GroupCode2"].Value = (dt.Rows[i]["GroupCode2"] == null ? string.Empty : dt.Rows[i]["GroupCode2"].ToString());

                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["メイン項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                            gridView_checkList.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                            メイン項目count++;
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["記録コード"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["メイン項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["サブ項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["点検内容例"].Style.BackColor = Color.White;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["サブ項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                        }
                    }
                    lbl_count.ForeColor = Color.Black;
                    lbl_count.Text = メイン項目count.ToString() + "件";
                    IsUpdating = true;
                    btn_insert.Enabled = false;
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
            }
        }

        /// <summary>
        /// 遊具検索処理
        /// 記録がある場合と記録がない場合
        /// </summary>
        private void Type2()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon?.Open();
            }
            catch
            {
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = "サーバーとの接続に失敗しました、インターネット接続を確認してください。";
                sqlcon.Close();
                return;
            }

            lbl_errorMessage.Text = string.Empty;

            string sqlcmd = string.Format(@"SELECT a.記録コード,a.日付,a.メイン項目,a.サブ項目,b.点検内容,a.チェック,a.処置,
                a.報告 FROM HL_JEC_保育園チェックリスト記録 a LEFT JOIN HL_JEC_保育園チェックリスト点検内容 b ON 
                a.点検内容コード = b.点検内容コード WHERE a.日付 BETWEEN '{0}' And '{1}'", startDate, endDate);
            SqlDataAdapter sqlDa1 = new SqlDataAdapter(sqlcmd, sqlcon);
            System.Data.DataTable dt = new System.Data.DataTable();
            sqlDa1.Fill(dt);
            //HL_JEC_保育園チェックリスト記録に登録されていない場合のGRIDVIEW設定
            if (dt.Rows.Count == 0)
            {
                IsUpdating = false;
                btn_insert.Enabled = true;
                sqlcmd = string.Format(@"SELECT メイン項目,サブ項目,点検内容,点検内容コード FROM HL_JEC_保育園チェックリスト点検内容 WHERE 点検内容種別 = 'Y' ORDER BY 点検内容コード");
                gridView_checkList.Rows.Clear();

                dt = new System.Data.DataTable();
                dt.Columns.Add("メイン項目");
                dt.Columns.Add("サブ項目");
                dt.Columns.Add("点検内容例");
                dt.Columns.Add("GroupCode1");
                dt.Columns.Add("GroupCode2");
                dt.Columns.Add("点検内容コード");

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();
                    string メイン項目 = string.Empty;
                    string サブ項目 = string.Empty;

                    while (reader.Read())
                    {
                        DataRow r = dt.NewRow();
                        if (メイン項目 == string.Empty || メイン項目 != reader["メイン項目"].ToString())
                        {
                            メイン項目 = reader["メイン項目"].ToString();
                            サブ項目 = reader["サブ項目"].ToString();
                            r["メイン項目"] = "- " + reader["メイン項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["点検内容コード"] = reader["点検内容コード"].ToString();
                            r["GroupCode1"] = reader["メイン項目"].ToString();
                            r["GroupCode2"] = reader["サブ項目"].ToString();
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 == reader["サブ項目"].ToString())
                        {
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["点検内容コード"] = reader["点検内容コード"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 != reader["サブ項目"].ToString())
                        {
                            サブ項目 = reader["サブ項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["点検内容コード"] = reader["点検内容コード"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                    }
                    int 行数 = dt.Rows.Count;
                    int メイン項目count = 0;
                    gridView_checkList.Columns["サブ項目"].Visible = false;
                    for (int i = 0; i < 行数; i++)
                    {
                        gridView_checkList.Rows.Add();
                        gridView_checkList.RowHeadersVisible = false;
                        gridView_checkList.Rows[i].Cells["メイン項目"].Value = (dt.Rows[i]["メイン項目"] == null ? string.Empty : dt.Rows[i]["メイン項目"].ToString());
                        gridView_checkList.Rows[i].Cells["サブ項目"].Value = (dt.Rows[i]["サブ項目"] == null ? string.Empty : dt.Rows[i]["サブ項目"].ToString());
                        gridView_checkList.Rows[i].Cells["点検内容例"].Value = (dt.Rows[i]["点検内容例"] == null ? string.Empty : dt.Rows[i]["点検内容例"].ToString());
                        gridView_checkList.Rows[i].Cells["チェック"].Value = "";
                        gridView_checkList.Rows[i].Cells["処置"].Value = "";
                        gridView_checkList.Rows[i].Cells["報告"].Value = "×".ToString();
                        gridView_checkList.Rows[i].Cells["GroupCode1"].Value = (dt.Rows[i]["GroupCode1"] == null ? string.Empty : dt.Rows[i]["GroupCode1"].ToString());
                        gridView_checkList.Rows[i].Cells["GroupCode2"].Value = (dt.Rows[i]["GroupCode2"] == null ? string.Empty : dt.Rows[i]["GroupCode2"].ToString());
                        gridView_checkList.Rows[i].Cells["点検内容コード"].Value = (dt.Rows[i]["点検内容コード"] == null ? string.Empty : dt.Rows[i]["点検内容コード"].ToString());

                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["メイン項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                            gridView_checkList.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                            メイン項目count++;
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["メイン項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["サブ項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["点検内容例"].Style.BackColor = Color.White;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["サブ項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                        }
                    }
                    lbl_count.ForeColor = Color.Black;
                    lbl_count.Text = メイン項目count.ToString() + "件";
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
            }
            //HL_JEC_保育園チェックリスト記録に登録されている場合のGRIDVIEW設定
            else
            {
                gridView_checkList.Rows.Clear();

                dt = new System.Data.DataTable();
                dt.Columns.Add("記録コード");
                dt.Columns.Add("メイン項目");
                dt.Columns.Add("サブ項目");
                dt.Columns.Add("点検内容例");
                dt.Columns.Add("チェック");
                dt.Columns.Add("処置");
                dt.Columns.Add("報告");
                dt.Columns.Add("GroupCode1");
                dt.Columns.Add("GroupCode2");

                try
                {
                    SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();
                    string メイン項目 = string.Empty;
                    string サブ項目 = string.Empty;

                    while (reader.Read())
                    {
                        DataRow r = dt.NewRow();
                        if (メイン項目 == string.Empty || メイン項目 != reader["メイン項目"].ToString())
                        {
                            メイン項目 = reader["メイン項目"].ToString();
                            サブ項目 = reader["サブ項目"].ToString();
                            r["記録コード"] = reader["記録コード"].ToString();
                            r["メイン項目"] = "- " + reader["メイン項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["チェック"] = reader["チェック"].ToString();
                            r["処置"] = reader["処置"].ToString();
                            r["報告"] = reader["報告"].ToString();
                            r["GroupCode1"] = reader["メイン項目"].ToString();
                            r["GroupCode2"] = reader["サブ項目"].ToString();
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 == reader["サブ項目"].ToString())
                        {
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["チェック"] = reader["チェック"].ToString();
                            r["処置"] = reader["処置"].ToString();
                            r["報告"] = reader["報告"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                        else if (メイン項目 == reader["メイン項目"].ToString() && サブ項目 != reader["サブ項目"].ToString())
                        {
                            サブ項目 = reader["サブ項目"].ToString();
                            if (string.IsNullOrEmpty(reader["サブ項目"].ToString()))
                            {
                                r["サブ項目"] = reader["サブ項目"].ToString();
                            }
                            else
                            {
                                r["サブ項目"] = "- " + reader["サブ項目"].ToString();
                            }
                            r["点検内容例"] = reader["点検内容"].ToString();
                            r["チェック"] = reader["チェック"].ToString();
                            r["処置"] = reader["処置"].ToString();
                            r["報告"] = reader["報告"].ToString();
                            r["GroupCode1"] = メイン項目;
                            r["GroupCode2"] = サブ項目;
                            dt.Rows.Add(r);
                        }
                    }
                    int 行数 = dt.Rows.Count;
                    int メイン項目count = 0;
                    gridView_checkList.Columns["サブ項目"].Visible = false;
                    for (int i = 0; i < 行数; i++)
                    {
                        gridView_checkList.Rows.Add();
                        gridView_checkList.RowHeadersVisible = false;
                        gridView_checkList.Rows[i].Cells["記録コード"].Value = (dt.Rows[i]["記録コード"] == null ? string.Empty : dt.Rows[i]["記録コード"].ToString());
                        gridView_checkList.Rows[i].Cells["メイン項目"].Value = (dt.Rows[i]["メイン項目"] == null ? string.Empty : dt.Rows[i]["メイン項目"].ToString());
                        gridView_checkList.Rows[i].Cells["サブ項目"].Value = (dt.Rows[i]["サブ項目"] == null ? string.Empty : dt.Rows[i]["サブ項目"].ToString());
                        gridView_checkList.Rows[i].Cells["点検内容例"].Value = (dt.Rows[i]["点検内容例"] == null ? string.Empty : dt.Rows[i]["点検内容例"].ToString());
                        if (string.IsNullOrEmpty(dt.Rows[i]["チェック"].ToString()))
                        {
                            gridView_checkList.Rows[i].Cells["チェック"].Value = "";
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["チェック"].Value = dt.Rows[i]["チェック"].ToString();
                        }
                        gridView_checkList.Rows[i].Cells["処置"].Value = (dt.Rows[i]["処置"] == null ? string.Empty : dt.Rows[i]["処置"].ToString());
                        if (string.IsNullOrEmpty(dt.Rows[i]["報告"].ToString()))
                        {
                            gridView_checkList.Rows[i].Cells["報告"].Value = "×".ToString();
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["報告"].Value = dt.Rows[i]["報告"].ToString();
                            if (dt.Rows[i]["報告"].ToString() == "○")
                            {
                                gridView_checkList.Rows[i].Cells["報告"].Style.BackColor = Color.White;
                                gridView_checkList.Rows[i].Cells["報告"].ReadOnly = true;
                            }
                        }
                        gridView_checkList.Rows[i].Cells["GroupCode1"].Value = (dt.Rows[i]["GroupCode1"] == null ? string.Empty : dt.Rows[i]["GroupCode1"].ToString());
                        gridView_checkList.Rows[i].Cells["GroupCode2"].Value = (dt.Rows[i]["GroupCode2"] == null ? string.Empty : dt.Rows[i]["GroupCode2"].ToString());

                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["メイン項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                            gridView_checkList.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                            メイン項目count++;
                        }
                        else
                        {
                            gridView_checkList.Rows[i].Cells["記録コード"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["メイン項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["サブ項目"].Style.BackColor = Color.White;
                            gridView_checkList.Rows[i].Cells["点検内容例"].Style.BackColor = Color.White;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["サブ項目"].ToString()))
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                        }
                    }
                    lbl_count.ForeColor = Color.Green;
                    lbl_count.Text = メイン項目count.ToString() + "件";
                    IsUpdating = true;
                    btn_insert.Enabled = false;
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
            }

        }

        #endregion

        #region gridview操作
        /// <summary>
        /// セル編集切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_checkList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridView_checkList.CurrentCell.OwningColumn.HeaderText == "チェック")
                {
                    string check = gridView_checkList.CurrentRow.Cells["チェック"].Value.ToString();
                    if (check == "×")
                    {
                        gridView_checkList.CurrentRow.Cells["報告"].Style.BackColor = Color.FromArgb(128, 255, 255);
                        gridView_checkList.CurrentRow.Cells["報告"].ReadOnly = false;
                    }
                    else if (check == "○")
                    {
                        gridView_checkList.CurrentRow.Cells["報告"].Style.BackColor = Color.White;
                        gridView_checkList.CurrentRow.Cells["報告"].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = "セル編集切り替え処理に失敗しました." + ex.Message;
                return;
            }
        }

        /// <summary>
        /// ロール展開機能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_checkList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridView_checkList.CurrentCell.OwningColumn.HeaderText == "メイン項目")
            {
                int count = gridView_checkList.CurrentRow.Index;
                if (!string.IsNullOrEmpty(gridView_checkList.CurrentRow.Cells["メイン項目"].Value.ToString()))
                {
                    //Add chen 2020/11/05
                    IsOpenClose = true;
                    //End chen 2020/11/05
                    string openStyle = gridView_checkList.CurrentRow.Cells["メイン項目"].Value.ToString().Substring(0, 1); ;

                    try
                    {
                        while (gridView_checkList.Rows.Count - 1 > count)
                        {
                            if (gridView_checkList.Rows[count].Cells["GroupCode1"].Value.ToString()
                            == gridView_checkList.Rows[count + 1].Cells["GroupCode1"].Value.ToString())
                            {
                                gridView_checkList.Rows[count + 1].Visible = openStyle == "+";
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        gridView_checkList.CurrentRow.Cells["メイン項目"].Value = gridView_checkList.CurrentRow.Cells["メイン項目"].Value.ToString().Replace(openStyle == "+" ? "+" : "-", openStyle == "+" ? "-" : "+");
                    }
                    catch (Exception ex)
                    {
                        lbl_errorMessage.ForeColor = Color.Red;
                        lbl_errorMessage.Text = ex.Message;
                        return;
                    }
                    //Add chen 2020/11/05
                    finally
                    {
                        IsOpenClose = false;
                    }
                    //End chen 2020/11/05
                }
                else
                {
                    return;
                }
            }
            else if (gridView_checkList.CurrentCell.OwningColumn.HeaderText == "サブ項目")
            {
                int count = gridView_checkList.CurrentRow.Index;
                if (!string.IsNullOrEmpty(gridView_checkList.CurrentRow.Cells["サブ項目"].Value.ToString()))
                {
                    //Add chen 2020/11/05
                    IsOpenClose = true;
                    //End chen 2020/11/05
                    string openStyle = gridView_checkList.CurrentRow.Cells["サブ項目"].Value.ToString().Substring(0, 1); ;

                    try
                    {
                        while (gridView_checkList.Rows.Count - 1 > count)
                        {
                            if (gridView_checkList.Rows[count].Cells["GroupCode2"].Value.ToString()
                            == gridView_checkList.Rows[count + 1].Cells["GroupCode2"].Value.ToString())
                            {
                                gridView_checkList.Rows[count + 1].Visible = openStyle == "+";
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        gridView_checkList.CurrentRow.Cells["サブ項目"].Value = gridView_checkList.CurrentRow.Cells["サブ項目"].Value.ToString().Replace(openStyle == "+" ? "+" : "-", openStyle == "+" ? "-" : "+");
                    }
                    catch (Exception ex)
                    {
                        lbl_errorMessage.ForeColor = Color.Red;
                        lbl_errorMessage.Text = ex.Message;
                        return;
                    }
                    //Add chen 2020/11/05
                    finally
                    {
                        IsOpenClose = false;
                    }
                    //End chen 2020/11/05
                }
                else
                {
                    return;
                }
            }

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_checkList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Mod chen 2020/11/05
            if (IsUpdating && IsOpenClose == false)
            {
                string code = gridView_checkList.CurrentRow.Cells["記録コード"].Value.ToString();
                string columname = gridView_checkList.Columns[gridView_checkList.CurrentCell.ColumnIndex].Name;
                string value = gridView_checkList.CurrentCell.EditedFormattedValue.ToString();

                if (beforeValue != value)
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlTransaction transaction;
                    int error = 0;
                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction("DataUpdate");
                    }
                    catch (Exception)
                    {
                        lbl_errorMessage.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                        lbl_errorMessage.ForeColor = Color.Red;
                        connection?.Close();
                        return;
                    }
                    try
                    {
                        SqlCommand DataUpdateCmd = new SqlCommand();
                        DataUpdateCmd.Connection = connection;
                        DataUpdateCmd.CommandType = CommandType.Text;
                        DataUpdateCmd.Transaction = transaction;
                        DataUpdateCmd.CommandText = string.Format(@"update HL_JEC_保育園チェックリスト記録 set {0}= '{1}' , 担当者= '{2}', 更新日時= '{3}' where 記録コード={4}", columname, value, user, DateTime.Now, code);

                        int AdaptedRows = DataUpdateCmd.ExecuteNonQuery();
                        if (AdaptedRows == 0)
                        {
                            error++;
                        }
                        if (error == 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                        connection.Close();
                        lbl_errorMessage.ForeColor = Color.Green;
                        lbl_errorMessage.Text = "保育園チェックリスト記録が正常に更新しました。";
                    }
                    catch
                    {
                        transaction?.Rollback();
                        connection?.Close();
                        lbl_errorMessage.ForeColor = Color.Red;
                        lbl_errorMessage.Text = gridView_checkList.Columns[gridView_checkList.CurrentCell.ColumnIndex].Name + "の更新処理が失敗しました。";
                    }
                    IsUpdating = false;
                    if (cmb_koumoku.SelectedIndex == 0)
                    {
                        Type1();
                    }
                    else if (cmb_koumoku.SelectedIndex == 1)
                    {
                        Type2();
                    }

                }
            }
            //End chen 2020/11/05
            else
            {
                return;
            }
        }

        /// <summary>
        /// 更新前の値の記録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_checkList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsUpdating == true)
            {
                lbl_errorMessage.Text = "";
                beforeValue = gridView_checkList.CurrentCell.EditedFormattedValue.ToString();
            }
        }

        /// <summary>
        /// gridviewのレイアウト調整
        /// メイン項目行を枠つき
        /// メイン項目もしくはサブ項目がない行を枠なしにする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_checkList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                e.AdvancedBorderStyle.Top = gridView_checkList.AdvancedCellBorderStyle.Top;
                e.AdvancedBorderStyle.Bottom = gridView_checkList.AdvancedCellBorderStyle.Bottom;
                e.AdvancedBorderStyle.Right = gridView_checkList.AdvancedCellBorderStyle.Right;
                e.AdvancedBorderStyle.Left = gridView_checkList.AdvancedCellBorderStyle.Left;
                return;
            }
            if (string.IsNullOrEmpty(gridView_checkList.Rows[e.RowIndex].Cells["メイン項目"].Value.ToString())
                && (e.ColumnIndex == 1))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                gridView_checkList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
            }
            else if (string.IsNullOrEmpty(gridView_checkList.Rows[e.RowIndex].Cells["メイン項目"].Value.ToString())
                && string.IsNullOrEmpty(gridView_checkList.Rows[e.RowIndex].Cells["サブ項目"].Value.ToString())
                && (e.ColumnIndex == 2))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                gridView_checkList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
            }
            else
            {
                e.AdvancedBorderStyle.Top = gridView_checkList.AdvancedCellBorderStyle.Top;
                e.AdvancedBorderStyle.Bottom = gridView_checkList.AdvancedCellBorderStyle.Bottom;
                e.AdvancedBorderStyle.Right = gridView_checkList.AdvancedCellBorderStyle.Right;
                e.AdvancedBorderStyle.Left = gridView_checkList.AdvancedCellBorderStyle.Left;
            }
        }

        /// <summary>
        /// gridviewの展開機能
        /// メイン項目の"+", "-"切り替え
        /// サブ項目の"+", "-"切り替え
        /// </summary>
        /// <param name="type"></param>
        private void OpenGridViewDetail(bool type = true)
        {
            try
            {
                //Add chen 2020/11/05
                IsOpenClose = true;
                //End chen 2020/11/05
                int count = gridView_checkList.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (type)
                    {
                        gridView_checkList.Rows[i].Visible = true;
                        if (gridView_checkList.Rows[i].HeaderCell.Value != null)
                        {
                            gridView_checkList.Rows[i].HeaderCell.Value = "-";
                            gridView_checkList.Rows[i].Cells["メイン項目"].Value = gridView_checkList.Rows[i].Cells["メイン項目"].Value.ToString().Replace("+", "-");
                            gridView_checkList.Rows[i].Cells["サブ項目"].Value = gridView_checkList.Rows[i].Cells["サブ項目"].Value.ToString().Replace("+", "-");
                        }

                    }
                    else
                    {
                        //mod chen 2020/11/11
                        if (gridView_checkList.Rows[i].HeaderCell.Value != null && gridView_checkList.Rows[i].DefaultCellStyle.BackColor == Color.GreenYellow)
                        {

                            gridView_checkList.Rows[i].HeaderCell.Value = "+";
                            gridView_checkList.Rows[i].Cells["メイン項目"].Value = gridView_checkList.Rows[i].Cells["メイン項目"].Value.ToString().Replace("-", "+");
                            gridView_checkList.Rows[i].Cells["サブ項目"].Value = gridView_checkList.Rows[i].Cells["サブ項目"].Value.ToString().Replace("-", "+");

                        }
                        //end chen 2020/11/11
                        else
                        {
                            gridView_checkList.Rows[i].Visible = false;
                        }
                     
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = ex.Message;
                return;
            }
            //Add chen 2020/11/05
            finally
            {
                IsOpenClose = false;
            }
            //End chen 2020/11/05
        }




        #endregion


    }
}
