using ComDll;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace 飛鳥SES_人事
{
    public partial class 園児健診出力 : Form
    {      
        public 園児健診出力()
        {
            InitializeComponent();
            this.Location = new Point(879,300);
        }
        public string connectionString = ComClass.connectionString;
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        //excelの保存
        string tmpDir;
        string filename;
        //excelに関する新規定義
        Excel.Application app = new Excel.Application();
        Excel.Workbook workbook;
        Excel.Worksheet formatSheet;
        Excel.Worksheet newSheet = null;
        Excel.Worksheet lastSheet = null;
        bool Isnull = false;
        /// <summary>
        /// 出力ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_output_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            DateTime fromtime = Convert.ToDateTime(dtp_from.Value.ToString("yyyy/MM/dd"));
            DateTime totime = Convert.ToDateTime(dtp_to.Value.ToString("yyyy/MM/dd"));
            if (fromtime > Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd")))
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "当日より以前の日時を選択してください。";
                return;
            }
            if (fromtime > totime)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "正しい日時期間を選択してください。";
                return;
            }           
            TimeSpan timespan = totime - fromtime;
            int span = Int16.Parse(timespan.ToString("dd"));
            int count　= 0;
            for (int f = 0; f <= span; f++)
            {
                DataTable result = null;
                result = GetdowmloadDate(fromtime.AddDays(f));
                count += result.Rows.Count;
            }
            if(count==0)
            {
                Isnull = true;
            }
                
            if(Isnull)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "この期間の記録がないため、出力できません。";
                Isnull = false;
                return;
            }
            else
            {
                //databaseに接続し、元excelファイルをダウンロードする
                string sql = @"select ファイル from HL_JEC_保育園業務書類フォーマット where ファイル名='00_8.健診'";
                SqlConnection sqlcon = new SqlConnection(connectionString);
                try
                {
                    sqlcon.Open();
                }
                catch
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました.";
                    return;
                }
                try
                {
                    SqlCommand com = new SqlCommand(sql, sqlcon);
                    SqlDataReader reader = com.ExecuteReader();
                    tmpDir = @"C:\Windows\Temp\";
                    filename = tmpDir + "健診" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xlsx";
                    if (reader.Read())
                    {
                        try
                        {
                            File.WriteAllBytes(filename, (byte[])reader["ファイル"]);
                        }
                        catch
                        {
                            toolStripStatusLabel1.ForeColor = Color.Red;
                            toolStripStatusLabel1.Text = "ファイルの獲得は失敗しました.";
                            reader.Close();
                            return;
                        }
                    }
                    //ダウンロードしたファイルを開く           
                    app = new Excel.Application();
                    workbook = app.Workbooks.Open(filename);
                    //フォーマットsheetを取得する
                    formatSheet = workbook.Worksheets[1];   
                    //一日一sheet、データを書き込む
                    for (int f = 0; f <= span; f++)
                    {
                        //sheetを追加する
                        lastSheet = formatSheet;
                        newSheet = workbook.Worksheets.Add(Type.Missing, lastSheet, 1, Type.Missing);
                        formatSheet.get_Range("A1", "Z82").Copy(newSheet.get_Range("A1", "O82"));
                        newSheet.Name = fromtime.AddDays(f).ToString("D");
                        lastSheet = newSheet;
                        //データをsheetに書き込む
                        DataTable dt2 = null;
                        dt2 = GetdowmloadDate(fromtime.AddDays(f));
                        Imprint(dt2, fromtime.AddDays(f));
                    }
                    //最後の空sheet削除
                    workbook.Worksheets[1].Delete();
                    reader.Close();
                    workbook.Save();
                    app.Quit();
                    Killexcel.Kill(app);
                    //ダウンロードダイヤログを表示する
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    FileInfo fileInfo = new FileInfo(filename);
                    byte[] fileData = ReadFileToByte(filename);
                    string fileExtension = fileInfo.Extension;
                    using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                    {
                        saveFileDialog1.Filter = "Files (*" + fileExtension + ")|*" + fileExtension;
                        saveFileDialog1.Title = "Save File as";
                        saveFileDialog1.CheckPathExists = true;
                        saveFileDialog1.FileName = "健診" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xlsx";

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog1.FileName, fileData);
                            if (((Form1)(this.Tag)).m_健康診断Handle != null)
                            {
                                園児健康診断 m_NewForm園児健康診断 = (園児健康診断)this.Owner;//把健康診断登録的父窗口指针赋给健康診断
                                m_NewForm園児健康診断.FileName = "健診" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xlsx";
                                SendMessage(((Form1)(this.Tag)).m_健康診断Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                            }
                            this.Close();
                        }
                        else
                        {
                            toolStripStatusLabel1.ForeColor = Color.Red;
                            toolStripStatusLabel1.Text = string.Format("{0}のダウンロードがキャンセルされました。", "健診" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xls");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = ex.Message;
                    return;
                }               
            }   
        }
        /// <summary>
        /// excelの図形(〇)を入力する
        /// </summary>
        /// <param name="xlength"></場所の値>
        /// <param name="ylength"></場所の値>
        private void InputCircle(float xlength, float ylength)
        {
            Excel.Shape maru = lastSheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, xlength, ylength, 20, 20);
            maru.Line.ForeColor.RGB = (255);
            maru.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
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
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }
　　　　/// <summary>
　　　　/// データを獲得する
　　　　/// </summary>
　　　　/// <param name="time"></param>
　　　　/// <returns></returns>
        private DataTable GetdowmloadDate(DateTime time)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("園児コード");
            dt1.Columns.Add("園児名");
            dt1.Columns.Add("日付");
            dt1.Columns.Add("室温");
            dt1.Columns.Add("体温");
            dt1.Columns.Add("検温時間");
            dt1.Columns.Add("チェック項目");
            dt1.Columns.Add("健康状況");
            dt1.Columns.Add("排便");
            dt1.Columns.Add("回数");
            dt1.Columns.Add("食事内容状況");
            dt1.Columns.Add("GroupCode");
            dt1.Columns.Add("CName");
            dt1.Columns.Add("行番号");
            dt1.Columns.Add("id");
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました.";
            }
            string str_sqlcmd = string.Format(@"select a.園児コード,a.名前,b.日付,b.チェック項目,b.体温,b.食事内容状況,b.室温,b.排便, b.id                                        
　　　　　　　　　　　　　　　　              from  HL_JEC_園児情報マスタ a left join  HL_JEC_園児健康状況観察 b  on a.園児コード = b.園児コード
                                              Where b.日付 = '{0}' order by a.園児コード", time);
            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            dt1.Rows.Clear();
            try
            {
                while (reader.Read())
                {
                    string[] チェック項目 = reader["チェック項目"].ToString().Split(',');
                    string[] 体温 = reader["体温"].ToString().Split(',');
                    string[] 排便 = reader["排便"].ToString().Split(',');
                    int rowIndex = (new int[] { チェック項目.Length, 体温.Length, 排便.Length }).Max();
                    for (int x = 0; x < rowIndex; x++)
                    {
                        DataRow r = dt1.NewRow();
                        if (x == 0)
                        {
                            r["園児コード"] = reader["園児コード"].ToString();
                            r["園児名"] = reader["名前"].ToString();
                            r["日付"] = reader["日付"].ToString().Substring(0, 10);
                            r["食事内容状況"] = reader["食事内容状況"].ToString();
                            r["室温"] = reader["室温"].ToString();
                        }

                        r["GroupCode"] = reader["園児コード"].ToString();
                        r["CName"] = reader["名前"].ToString();
                        r["id"] = reader["id"].ToString();
                        if (x < チェック項目.Length)
                        {
                            int a = チェック項目[x].IndexOf("-");
                            int b = チェック項目[x].Length - a - 1;
                            string checkitem = チェック項目[x].Substring(0, a);
                            string result = チェック項目[x].Substring(a + 1, b);
                            r["チェック項目"] = checkitem;
                            r["健康状況"] = result;
                        }
                        if (x < 体温.Length)
                        {
                            int a = 体温[x].IndexOf("-");
                            int b = 体温[x].Length - a - 1;
                            string checkitem = 体温[x].Substring(0, a);
                            string result = 体温[x].Substring(a + 1, b);
                            r["検温時間"] = checkitem;
                            r["体温"] = result;
                        }

                        if (x < 排便.Length)
                        {
                            int a = 排便[x].IndexOf("-");
                            int b = 排便[x].Length - a - 1;
                            string checkitem = 排便[x].Substring(0, a);
                            string result = 排便[x].Substring(a + 1, b);
                            r["排便"] = checkitem;
                            r["回数"] = result;
                        }
                        r["行番号"] = (x + 1).ToString();

                        dt1.Rows.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "データ取得に失敗しました。" + ex.Message;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }
            return dt1;
        }
        /// <summary>
        /// EXCELに書き込む
        /// </summary>
        /// <param name="datetable"></param>
        /// <param name="dateTime"></param>
        private void Imprint(DataTable datetable, DateTime dateTime)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            newSheet.Cells[3, 4] = dateTime.ToString("D") + "( " + dateTime.ToString("ddd") + " )";
            newSheet.Cells[3, 4].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            newSheet.Columns["D:F"].ColumnWidth = 10.25;
            newSheet.Rows.RowHeight = 14.25;
            foreach (DataRow row in datetable.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row["園児名"].ToString()))
                {
                    newSheet.Columns[4].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    newSheet.Columns[5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    newSheet.Columns[6].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    newSheet.Cells[8, 3] = row["室温"] + " ℃";
                    newSheet.Cells[8, 3].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    newSheet.Cells[11 + 6 * c, 2] = row["園児名"];
                    newSheet.Cells[13 + 6 * c, 4] = row["体温"] + "   ℃";
                    newSheet.Cells[14 + 6 * c, 4] = "(" + row["検温時間"] + ")";
                    newSheet.Cells[13 + 6 * c, 15] = "'(  " + row["回数"] + "  )";
                    if (row["チェック項目"].ToString() == "機嫌")
                    {
                        switch (row["健康状況"].ToString())
                        {
                            case "良":
                                InputCircle(388, 153 + c * 85);
                                break;
                            case "普通":
                                InputCircle(416, 153 + c * 85);
                                break;
                            case "不良":
                                InputCircle(453, 153 + c * 85);
                                break;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(row["食事内容状況"].ToString()))
                    {
                        if (row["食事内容状況"].ToString() == "2/3")
                        {
                            InputCircle(684, 168 + c * 85);
                        }
                        else if (row["食事内容状況"].ToString() == "完食")
                        {
                            InputCircle(632, 168 + c * 85);
                        }
                        else
                        {
                            newSheet.Cells[15 + 6 * c, 12] = "(" + row["食事内容状況"] + ")";
                        }
                    }
                    c++;
                    b = 0;
                }
                else
                {
                    if (row["チェック項目"].ToString() == "しっしん")
                    {
                        switch (row["健康状況"].ToString())
                        {
                            case "有":
                                InputCircle(408, 168 + (c - 1) * 85);
                                break;
                            case "無":
                                InputCircle(433, 168 + (c - 1) * 85);
                                break;
                        }
                    }

                    if (row["チェック項目"].ToString() == "せき・はなみず")
                    {
                        switch (row["健康状況"].ToString())
                        {
                            case "有":
                                InputCircle(423, 183 + (c - 1) * 85);
                                break;
                            case "無":
                                InputCircle(445, 183 + (c - 1) * 85);
                                break;
                        }
                    }

                    if (row["チェック項目"].ToString() == "その他")
                    {
                        newSheet.Cells[15 + 6 * (c - 1), 7] = "その他(" + row["健康状況"] + ")";
                    }

                    if (!string.IsNullOrWhiteSpace(row["体温"].ToString()))
                    {
                        newSheet.Cells[13 + 6 * (c - 1), 5 + b] = row["体温"] + "   ℃";
                        newSheet.Cells[14 + 6 * (c - 1), 5 + b] = "(" + row["検温時間"] + ")";
                    }
                    if (!string.IsNullOrWhiteSpace(row["回数"].ToString()))
                    {
                        newSheet.Cells[14 + b + (c - 1) * 6, 15] = "'(  " + row["回数"] + "  )";
                    }
                    b++;
                }
                a++;
            }
            //プリント範囲を選択する
            newSheet.PageSetup.PrintArea = "$A$1:$O$" + (387 + a * 112).ToString();
        }
    }
}
