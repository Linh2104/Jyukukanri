using ComDll;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Excel = Microsoft.Office.Interop.Excel;

namespace 飛鳥SES_人事
{
    public partial class 検食簿一覧 : DockContent
    {   //接続コマンド
        private string connectionString = "Data Source=DESKTOP-R5038PT\\SQLEXPRESS01;Initial Catalog=oa;Integrated Security=True";
        //private string connectionString = ComClass.connectionString;
        //画面各コントロールのデータ
        string date = string.Empty;
        string datelast = string.Empty;
        int diff;
        string search = string.Empty;
        string user = string.Empty;
        //DGVを編集することの判断
        bool change = false;
        //区分を判断する時間値
        DateTime asa = Convert.ToDateTime("12:00:00");
        DateTime gogo = Convert.ToDateTime("15:00:00");
        DateTime temp;

        //excelの保存
        string tmpDir;
        string filename;
        //excelに関する新規定義
        Excel.Application app = new Excel.Application();
        Excel.Workbook workbook;
        Excel.Worksheet worksheet;
        Excel.Range range1;
        //DGVの学値を臨時的に保存する値
        string tempdate = string.Empty;
        string temptime = string.Empty;
        string tempfood = string.Empty;
        string tempaji = string.Empty;
        string tempmori = string.Empty;
        string tempbun = string.Empty;
        string temptantou = string.Empty;
        string tempclean = string.Empty;
        DateTime temptimediff;
        //excelの作成のリファレンスの値
        int datenum = 1;
        int array = 0;
        int foodcount1 = 0;
        int foodcount2 = 0;
        int foodcount3 = 0;

        public 検食簿一覧()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {
            switch (msg.Msg)
            {
                case ComClass.CUSTOM_MESSAGE:
                    {
                        DisplayGridView();
                    }
                    break;

                default:
                    base.WndProc(ref msg);
                    break;
            }
        }

        /// <summary>
        /// DGVを表示
        /// </summary>
        private void DisplayGridView()
        {
            //初期化する
            toolStripStatusLabel2.ForeColor = Color.Green;
            toolStripStatusLabel2.Text = "";
            change = false;
            gv_foodcheck.Rows.Clear();

            //databaseに接続する
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                return;
            }

            //画面各データを獲得する
            date = dtp_date.Value.ToString();
            datelast = dtp_datelast.Value.ToString();
            search = txt_search.Text;
            diff = cmb_diff.SelectedIndex;
            
            //sqlコマンド
            string sqlcmd = string.Format(@"select t1.*,t2.品物 from HL_JEC_検食簿 as t1
                                            left join HL_JEC_品物リスト as t2
                                            on t1.品物コード=t2.品物コード
                                            where t1.日付 >='{0}' and  t1.日付 <='{1}' ", date, datelast);
            sqlcmd += Kubun(diff);

            SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            int Index = 0;
            try
            {
                while (reader.Read())
                {
                    if ((reader["日付"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["時間"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["品物"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["味付"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["盛付"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["分量"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["担当者"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["衛生所見等"].ToString().IndexOf(search) < 0)
                        &&
                        (reader["備考"].ToString().IndexOf(search) < 0)
                        )
                    {
                        continue;
                    }

                    this.gv_foodcheck.Rows.Add();
                    gv_foodcheck.Rows[Index].Cells["チェックコード"].Value = reader["チェックコード"].ToString();
                    gv_foodcheck.Rows[Index].Cells["日付"].Value = reader["日付"].ToString().Replace(" 0:00:00", "");
                    string tempdate = gv_foodcheck.Rows[Index].Cells["日付"].Value.ToString();
                    gv_foodcheck.Rows[Index].Cells["時間"].Value = reader["時間"].ToString();
                    gv_foodcheck.Rows[Index].Cells["献立名"].Value = reader["品物"].ToString();
                    gv_foodcheck.Rows[Index].Cells["味付"].Value = reader["味付"].ToString();
                    gv_foodcheck.Rows[Index].Cells["盛付"].Value = reader["盛付"].ToString();
                    gv_foodcheck.Rows[Index].Cells["分量"].Value = reader["分量"].ToString();
                    gv_foodcheck.Rows[Index].Cells["担当者"].Value = reader["担当者"].ToString();
                    gv_foodcheck.Rows[Index].Cells["衛生所見等"].Value = reader["衛生所見等"].ToString();
                    gv_foodcheck.Rows[Index].Cells["備考"].Value = reader["備考"].ToString();

                    //当日でないデータの処理
                    if (Convert.ToDateTime(tempdate) != Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")))
                    {
                        gv_foodcheck.Rows[Index].ReadOnly = true;
                        gv_foodcheck.Rows[Index].Cells["日付"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["日付"].Style.ForeColor = Color.White;
                        gv_foodcheck.Rows[Index].Cells["時間"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["時間"].Style.ForeColor = Color.White;
                        gv_foodcheck.Rows[Index].Cells["献立名"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["献立名"].Style.ForeColor = Color.White;
                        gv_foodcheck.Rows[Index].Cells["味付"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["盛付"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["分量"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["担当者"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["担当者"].Style.ForeColor = Color.White;
                        gv_foodcheck.Rows[Index].Cells["衛生所見等"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["衛生所見等"].Style.ForeColor = Color.White;
                        gv_foodcheck.Rows[Index].Cells["備考"].Style.BackColor = Color.Gray;
                        gv_foodcheck.Rows[Index].Cells["備考"].Style.ForeColor = Color.White;
                    }
                    //当日のデータの処理
                    else
                    {
                        temp = Convert.ToDateTime(reader["時間"].ToString());
                        if (temp < asa)
                        {
                            gv_foodcheck.Rows[Index].Cells["時間"].Style.BackColor = Color.Yellow;
                        }
                        else if (temp > gogo)
                        {
                            gv_foodcheck.Rows[Index].Cells["時間"].Style.BackColor = Color.Plum;
                        }
                        else
                        {
                            gv_foodcheck.Rows[Index].Cells["時間"].Style.BackColor = Color.Orange;
                        }
                    }

                    Index++;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検食簿一覧は表示できない。もう一度表示してください。" + ex.Message;
                return;
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                    reader.Close();
                }
            }
            change = true;
            //件数を表す
            toolStripStatusLabel2.ForeColor = Color.Black;
            toolStripStatusLabel2.Text = string.Format("{0}件の結果", Index.ToString());

        }

        /// <summary>
        /// 区分を選択する
        /// </summary>
        /// <param name="diff"></cmb_diffのIndex値>
        /// <returns></returns>
        private string Kubun(int diff)
        {
            string jyoken = string.Empty;
            switch (diff)
            {
                case 0:
                    jyoken = " order by t1.日付 desc";
                    break;
                case 1:
                    jyoken = "and t1.時間 <= '12:00:00' order by t1.日付 desc";
                    break;
                case 2:
                    jyoken = "and  t1.時間 < '15:00:00' and t1.時間 >' 12:00:00' order by t1.日付 desc";
                    break;
                case 3:
                    jyoken = "and t1.時間 >= '15:00:00' order by t1.日付 desc";
                    break;
            }

            return jyoken;
        }

        /// <summary>
        /// 初期画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 検食簿一覧_Load(object sender, EventArgs e)
        {
            dtp_date.Value = DateTime.Now;
            dtp_datelast.Value = DateTime.Now;
            cmb_diff.SelectedIndex = 0;
            DisplayGridView();
        }

        /// <summary>
        /// 画面を閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 検食簿一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_検食簿一覧Handle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// DGVの値を編集する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_foodcheck_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || !change)
            {
                return;
            }

            gv_foodcheck.CurrentCell.Selected = true;

            string checkid = gv_foodcheck.Rows[e.RowIndex].Cells["チェックコード"].Value.ToString();
            string user = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ氏名;
            string taste = gv_foodcheck.Rows[e.RowIndex].Cells["味付"].Value.ToString();
            string arrange = gv_foodcheck.Rows[e.RowIndex].Cells["盛付"].Value.ToString();
            string portion = gv_foodcheck.Rows[e.RowIndex].Cells["分量"].Value.ToString();
            string clean = gv_foodcheck.Rows[e.RowIndex].Cells["衛生所見等"].Value.ToString();
            string remark = gv_foodcheck.Rows[e.RowIndex].Cells["備考"].Value.ToString();
            int result = 0;
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                return;
            }

            try
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlcon;
                string sqlcmd = @"Update HL_JEC_検食簿 set  味付='{0}'
                                                           ,盛付 = '{1}'
                                                           ,分量 = '{2}'
                                                           ,担当者 = '{3}'
　　　　　　　　　　　　　　　　　　　　　　　　　　　　　 ,衛生所見等 = '{4}'
　　　　　　　　　　　　　　　　　　　　　　　　　　　　　 ,備考 = '{5}'
                                                            where チェックコード = {6}";
                sqlcom.CommandText = string.Format(sqlcmd, taste, arrange, portion, user, clean, remark, checkid);
                result = sqlcom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format(@"更新処理に失敗しました。" + ex.Message);
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }

            DisplayGridView();
            if (result == 1)
            {
                toolStripStatusLabel2.ForeColor = Color.Green;
                toolStripStatusLabel2.Text = string.Format(@"情報は成功に更新しました。");
            }

        }

        /// <summary>
        /// dtp_dateの値を変更する時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_date_Leave(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// 区分を変更する時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_diff_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// 検索ボタンを押す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// 検食簿導出ボタンを押す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_download_Click(object sender, EventArgs e)
        {
            int foodcount1 = 0;
            int foodcount2 = 0;
            int foodcount3 = 0;

            //区分は「All」かどうかを完成する
            if (cmb_diff.Text != "All")
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "区分を「All」に選択してください。";
                return;
            }

            //databaseに接続し、元excelファイルをダウンロードする
            string sql = @"select * from HL_JEC_保育園業務書類フォーマット where ファイル名='00_25検食簿'";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                return;
            }
            try
            {
                SqlCommand com = new SqlCommand(sql, sqlcon);
                SqlDataReader reader = com.ExecuteReader();
                tmpDir = @"C:\Windows\Temp\";
                filename = tmpDir + "00_25検食簿" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xls";

                if (reader.Read())
                {
                    try
                    {
                        File.WriteAllBytes(filename, (byte[])reader["ファイル"]);
                    }
                    catch
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = "ファイルの獲得は失敗しました.";
                        reader.Close();
                        return;
                    }
                }
                //ダウンロードしたファイルを開く
                app = new Excel.Application();
                workbook = app.Workbooks.Open(filename);
                worksheet = (Excel.Worksheet)workbook.Worksheets["Sheet1"];
                worksheet.Name = "検食簿";
                range1 = null;
                //導出する必要な検食簿の数を獲得する
                tempdate = gv_foodcheck.Rows[0].Cells["日付"].Value.ToString();
                datenum = 1;
                for (int i = 0; i < gv_foodcheck.Rows.Count; i++)
                {
                    if (tempdate != gv_foodcheck.Rows[i].Cells["日付"].Value.ToString())
                    {
                        tempdate = gv_foodcheck.Rows[i].Cells["日付"].Value.ToString();
                        datenum++;
                    }
                    else
                    {
                        continue;
                    }
                }
                //検食簿をコピーする
                for (int i = 1; i < datenum; i++)
                {
                    Excel.Range RngToCopy = worksheet.get_Range("A1", "J21").EntireRow;
                    RngToCopy.Copy();
                    RngToCopy.Insert(Shift: (Excel.XlDirection.xlDown));
                }
                //日付を入力し、日付の配列を作る。
                string[] datearr = new string[datenum];
                array = 0;
                tempdate = gv_foodcheck.Rows[0].Cells["日付"].Value.ToString();
                datearr[array] = tempdate;
                range1 = worksheet.Range["B3"];
                range1.NumberFormat = "@";
                app.Cells[3, 2] = gv_foodcheck.Rows[0].Cells["日付"].Value.ToString();
                for (int i = 0; i < gv_foodcheck.Rows.Count; i++)
                {
                    if (tempdate != gv_foodcheck.Rows[i].Cells["日付"].Value.ToString())
                    {
                        array++;
                        tempdate = gv_foodcheck.Rows[i].Cells["日付"].Value.ToString();
                        datearr[array] = tempdate;
                        range1 = worksheet.Range["B" + (array * 21 + 3).ToString()];
                        range1.NumberFormat = "@";
                        app.Cells[(array * 21 + 3), 2] = tempdate;

                    }
                    else
                    {
                        continue;
                    }
                }
                //各値を一行ずつで入力する。
                array = 0;
                for (int i = 0; i < gv_foodcheck.Rows.Count; i++)
                {
                    InputData(i);

                    if (datearr[array] == tempdate)
                    {
                        if (temptimediff <= asa)
                        {
                            app.Cells[(array * 21) + 6, 3] = temptantou;
                            app.Cells[(array * 21) + 9, 3] = temptime.Substring(0, temptime.Length - 3);
                            app.Cells[(array * 21) + 6 + foodcount1, 4] = tempfood;
                            app.Cells[(array * 21) + 6 + foodcount1, 8] = tempclean;

                            if (tempaji == "良")
                            {
                                InputCircle(349, (array * 475) + 127 + (22 * foodcount1));
                            }
                            else if (tempaji == "薄")
                            {
                                InputCircle(373, (array * 475) + 127 + (22 * foodcount1));
                            }
                            else if (tempaji == "濃")
                            {
                                InputCircle(394, (array * 475) + 127 + (22 * foodcount1));
                            }

                            if (tempmori == "良")
                            {
                                InputCircle(437, (array * 475) + 127 + (22 * foodcount1));
                            }
                            else if (tempmori == "普")
                            {
                                InputCircle(457, (array * 483) + 131 + (22 * foodcount1));
                            }
                            else if (tempmori == "悪")
                            {
                                InputCircle(482, (array * 475) + 127 + (22 * foodcount1));
                            }

                            if (tempbun == "適")
                            {
                                InputCircle(527, (array * 475) + 127 + (22 * foodcount1));
                            }
                            else if (tempbun == "多")
                            {
                                InputCircle(548, (array * 475) + 127 + (22 * foodcount1));
                            }
                            else if (tempbun == "少")
                            {
                                InputCircle(571, (array * 475) + 127 + (22 * foodcount1));
                            }
                            foodcount1++;
                        }
                        else if (temptimediff > asa && temptimediff < gogo)
                        {

                            app.Cells[(array * 21) + 10, 3] = temptantou;
                            app.Cells[(array * 21) + 15, 3] = temptime.Substring(0, temptime.Length - 3);
                            app.Cells[(array * 21) + 10 + foodcount2, 4] = tempfood;
                            app.Cells[(array * 21) + 10 + foodcount2, 8] = tempclean;

                            if (tempaji == "良")
                            {
                                InputCircle(349, (array * 475) + 217 + (22 * foodcount2));
                            }
                            else if (tempaji == "薄")
                            {
                                InputCircle(369, (array * 475) + 217 + (22 * foodcount2));
                            }
                            else if (tempaji == "濃")
                            {
                                InputCircle(394, (array * 475) + 217 + (22 * foodcount2));
                            }

                            if (tempmori == "良")
                            {
                                InputCircle(437, (array * 475) + 217 + (22 * foodcount2));
                            }
                            else if (tempmori == "普")
                            {
                                InputCircle(458, (array * 475) + 217 + (22 * foodcount2));
                            }
                            else if (tempmori == "悪")
                            {
                                InputCircle(482, (array * 475) + 217 + (22 * foodcount2));
                            }

                            if (tempbun == "適")
                            {
                                InputCircle(527, (array * 475) + 217 + (22 * foodcount2));
                            }
                            else if (tempbun == "多")
                            {
                                InputCircle(548, (array * 475) + 217 + (22 * foodcount2));
                            }
                            else if (tempbun == "少")
                            {
                                InputCircle(571, (array * 475) + 217 + (22 * foodcount2));
                            }
                            foodcount2++;
                        }
                        else if (temptimediff >= gogo)
                        {
                            app.Cells[(array * 21) + 16, 3] = temptantou;
                            app.Cells[(array * 21) + 20, 3] = temptime.Substring(0, temptime.Length - 3);
                            app.Cells[(array * 21) + 16 + foodcount3, 4] = tempfood;
                            app.Cells[(array * 21) + 16 + foodcount3, 8] = tempclean;

                            if (tempaji == "良")
                            {
                                InputCircle(349, (array * 475) + 346 + (22 * foodcount3));
                            }
                            else if (tempaji == "薄")
                            {
                                InputCircle(369, (array * 475) + 346 + (22 * foodcount3));
                            }
                            else if (tempaji == "濃")
                            {
                                InputCircle(394, (array * 475) + 346 + (22 * foodcount3));
                            }

                            if (tempmori == "良")
                            {
                                InputCircle(437, (array * 475) + 346 + (22 * foodcount3));
                            }
                            else if (tempmori == "普")
                            {
                                InputCircle(458, (array * 475) + 346 + (22 * foodcount3));
                            }
                            else if (tempmori == "悪")
                            {
                                InputCircle(482, (array * 475) + 346 + (22 * foodcount3));
                            }

                            if (tempbun == "適")
                            {
                                InputCircle(527, (array * 475) + 346 + (22 * foodcount3));
                            }
                            else if (tempbun == "多")
                            {
                                InputCircle(548, (array * 475) + 346 + (22 * foodcount3));
                            }
                            else if (tempbun == "少")
                            {
                                InputCircle(571, (array * 475) + 346 + (22 * foodcount3));
                            }
                            foodcount3++;
                        }

                    }
                    else
                    {
                        array++;
                        foodcount1 = 0;
                        foodcount2 = 0;
                        foodcount3 = 0;
                        i--;
                    }
                }
                //プリント範囲を選択する
                worksheet.PageSetup.PrintArea = "$A$1:$J$" + (21*(array+1)).ToString();
                reader.Close();
                workbook.Save();
                app.Quit();
                Killexcel.Kill(app);
                //ダウンロードダイヤログを表示する
                OpenFileDialog openFileDialog = new OpenFileDialog();
                FileInfo fileInfo = new FileInfo("検食簿.xls");
                byte[] fileData = ReadFileToByte(filename);
                string fileExtension = fileInfo.Extension;
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Filter = "Files (*" + fileExtension + ")|*" + fileExtension;
                    saveFileDialog1.Title = "Save File as";
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.FileName = "検食簿"+DateTime.Now.ToString("yyyyMMdd_hhmmss")+".xls";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog1.FileName, fileData);
                        toolStripStatusLabel2.ForeColor = Color.Green;
                        toolStripStatusLabel2.Text = string.Format("検食簿はダウンロードしました。");

                    }
                    else
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = string.Format("添付ファイルのダウンロードがキャンセルされました。");
                        return;
                    }
                }
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検食簿の生成は失敗しました。";
                return;
            }
            finally
            {
                sqlcon.Close();

                KillFile(tmpDir, filename);

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

        /// <summary>
        /// excelの図形(〇)を入力する
        /// </summary>
        /// <param name="xlength"></場所の値>
        /// <param name="ylength"></場所の値>
        private void InputCircle(float xlength, float ylength)
        {
            Excel.Shape maru = worksheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval, xlength, ylength, 20, 20);
            maru.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            maru.Line.ForeColor.RGB = ColorTranslator.ToOle(Color.Red);
        }

        /// <summary>
        /// 臨時的な値を入力する
        /// </summary>
        /// <param name="i"></param>
        private void InputData(int i)
        {
            tempdate = gv_foodcheck.Rows[i].Cells["日付"].Value.ToString();
            temptime = gv_foodcheck.Rows[i].Cells["時間"].Value.ToString();
            temptimediff = Convert.ToDateTime(temptime);
            tempfood = gv_foodcheck.Rows[i].Cells["献立名"].Value.ToString();
            tempaji = gv_foodcheck.Rows[i].Cells["味付"].Value.ToString();
            tempmori = gv_foodcheck.Rows[i].Cells["盛付"].Value.ToString();
            tempbun = gv_foodcheck.Rows[i].Cells["分量"].Value.ToString();
            temptantou = gv_foodcheck.Rows[i].Cells["担当者"].Value.ToString();
            tempclean = gv_foodcheck.Rows[i].Cells["衛生所見等"].Value.ToString();
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
            catch(Exception ex)
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }
    }
}
