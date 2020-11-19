using ComDll;
using System;
using System.IO;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Office.Interop.Word;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;


namespace 飛鳥SES_人事
{
    public partial class 職員情報一覧 : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        private string connectionString = ComClass.connectionString;
        private bool isPrintOK = false;
        private string Selected_職員コード = string.Empty;
        private string Selected_園内職務 = string.Empty;
        public 職員情報一覧()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message msg)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
         
        }

        private void 職員情報一覧_Load(object sender, EventArgs e)
        {
            this.cmb_表示リスト.SelectedIndex = 0;
            this.cmb_在職状態リスト.SelectedIndex = 0;
            //  一覧表示
           // DisplayGridView();
        }

        /// <summary>
        /// フォームを閉める処理
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
        private void 職員情報一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_職員情報一覧Handle.iHandle = IntPtr.Zero;
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
        /// 初期表示
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayGridView()
        {
            switch (this.cmb_表示リスト.SelectedIndex)
            {
                case 0:
                    {
                        職員情報一覧表示();
                        this.gridView_職員情報一覧.Visible = true;
                        break;
                    }
                case 1:
                    {
                        職員資料一覧();
                        this.gridView_職員資料一覧.Visible = true;
                        break;
                    }

                default:
                    break;
            }

        }
        /// <summary>
        ///  職員資料一覧データ取得
        /// </summary>
        private void 職員情報一覧表示()
        {
            //メッセージをクリアする
            this.toolStripStatusLabel1.Text = "";

            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
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

            string str在職状態 = "";

            if (this.cmb_在職状態リスト.Text.Equals("在職のみ表示"))
            {
                str在職状態 = "在職";
            }
            else if (this.cmb_在職状態リスト.Text.Equals("退職のみ表示"))
            {
                str在職状態 = "退職";
            }

            string str_sqlcmd = string.Format(@"select DISTINCT   a.職員コード,
                                                    b.名前,
                                                    b.ローマ字表記,
                                                    b.カタカナ,
                                                    b.入職日,
                                                    b.退職日,
                                                    b.生年月日,
                                                    e.社員種別,
                                                    b.性別,
                                                    a.園内職務
                                                     from HL_JEC_職員情報 a  
                                                     left  join  HL_JINJI_社員マスタ b on a.職員コード = b.社員コード 
                                                     left  join HL_JINJI_社員在職状態 c on a.職員コード = c.社員コード 
                                                     left  join  HL_JINJI_社員情報 d on a.職員コード = c.社員コード
                                                     left  join HL_JINJI_社員在職状態 e on a.職員コード = e.社員コード
                                                     where e.在職状態 like '{0}%' and c.職務 = '保　育'", str在職状態);

            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            this.gridView_職員情報一覧.Rows.Clear();
            int index = 0;
            try
            {
                while (reader.Read())
                {
                    if (
                        (reader["職員コード"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["名前"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["ローマ字表記"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["カタカナ"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["入職日"].ToString().IndexOf(this.txt_search.Text) < 0)
                         &&
                        (reader["退職日"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["生年月日"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["社員種別"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["性別"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["園内職務"].ToString().IndexOf(this.txt_search.Text) < 0)
                        )
                    {
                        continue;
                    }
                    this.gridView_職員情報一覧.Rows.Add();
                    this.gridView_職員情報一覧.Rows[index].Cells["職員コード"].Value = reader["職員コード"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["氏名"].Value = reader["名前"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["ローマ字"].Value = reader["ローマ字表記"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["フリガナ"].Value = reader["カタカナ"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["入社日"].Value = reader["入職日"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["退職日"].Value = reader["退職日"].ToString().Equals("") ? "-" : reader["退職日"].ToString();
                    if (this.gridView_職員情報一覧.Rows[index].Cells["退職日"].Value.ToString() == "-")
                    {
                        this.gridView_職員情報一覧.Rows[index].Cells["退職日"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    this.gridView_職員情報一覧.Rows[index].Cells["生年月日"].Value = reader["生年月日"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["社員種別"].Value = reader["社員種別"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["性別"].Value = reader["性別"].ToString();
                    this.gridView_職員情報一覧.Rows[index].Cells["園内職務"].Value = reader["園内職務"].ToString();
                    index++;
                }
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
                this.toolStrip1.Text = string.Format("{0}件", index);
            }
        }
        /// <summary>
        /// 職員資料一覧データ取得
        /// </summary>
        private void 職員資料一覧()
        {
            //メッセージをクリアする
            this.toolStripStatusLabel1.Text = "";

            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
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

            string str在職状態 = "";

            if (this.cmb_在職状態リスト.Text.Equals("在職のみ表示"))
            {
                str在職状態 = "在職";
            }
            else if (this.cmb_在職状態リスト.Text.Equals("退職のみ表示"))
            {
                str在職状態 = "退職";
            }

            string str_sqlcmd = string.Format(@"select  DISTINCT    
                                                        a.職員コード,b.名前,a.資格証書名,a.履歴書名,a.秘密保持契約書名
                                                from 
                                                        HL_JEC_職員情報 a  
                                                left join 
                                                        HL_JINJI_社員在職状態 e on a.職員コード = e.社員コード
                                                left join    
                                                        HL_JINJI_社員マスタ b  on a.職員コード = b.社員コード
                                                where 
                                                        e.在職状態 like '{0}%'", str在職状態);

            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            this.gridView_職員資料一覧.Rows.Clear();
            int index = 0;
            try
            {
                while (reader.Read())
                {
                    if (
                        (reader["職員コード"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["名前"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                         (reader["資格証書名"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["履歴書名"].ToString().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (reader["秘密保持契約書名"].ToString().IndexOf(this.txt_search.Text) < 0)
                        )
                    {
                        continue;
                    }
                    this.gridView_職員資料一覧.Rows.Add();
                    this.gridView_職員資料一覧.Rows[index].Cells["社員コード"].Value = reader["職員コード"].ToString();
                    this.gridView_職員資料一覧.Rows[index].Cells["名前"].Value = reader["名前"].ToString();
                    this.gridView_職員資料一覧.Rows[index].Cells["資格証書"].Value = reader["資格証書名"].ToString().Equals("") ? "-" : reader["資格証書名"].ToString();
                    this.gridView_職員資料一覧.Rows[index].Cells["履歴書"].Value = reader["履歴書名"].ToString().Equals("") ? "-" : reader["履歴書名"].ToString();
                    this.gridView_職員資料一覧.Rows[index].Cells["秘密保持契約書"].Value = reader["秘密保持契約書名"].ToString().Equals("") ? "-" : reader["秘密保持契約書名"].ToString();
                    if (this.gridView_職員資料一覧.Rows[index].Cells["資格証書"].Value.ToString() == "-")
                    {
                        this.gridView_職員資料一覧.Rows[index].Cells["資格証書"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    if (this.gridView_職員資料一覧.Rows[index].Cells["履歴書"].Value.ToString() == "-")
                    {
                        this.gridView_職員資料一覧.Rows[index].Cells["履歴書"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    if (this.gridView_職員資料一覧.Rows[index].Cells["秘密保持契約書"].Value.ToString() == "-")
                    {
                        this.gridView_職員資料一覧.Rows[index].Cells["秘密保持契約書"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    //this.gridview_職員情報一覧.rows[index].cells["労働者名簿"].value = "aa";
                    //this.gridview_職員情報一覧.rows[index].cells["雇用契約書"].value = "aa";
                    index++;
                }
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
                this.toolStrip1.Text = string.Format("{0}件", index);
            }
        }
        /// <summary>
        /// 検索ボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click_1(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        // /// <summary>
        // /// 右クリックするとメニューを開く
        // /// </summary>
        // /// <param name="sender"></param>
        // /// <param name="e"></param>
        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            //メニューの箇所設定
            System.Drawing.Point startPosition = Cursor.Position;
            System.Drawing.Point point = this.gridView_職員情報一覧.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.gridView_職員情報一覧.HitTest(point.X, point.Y);

            this.gridView_職員情報一覧.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                this.gridView_職員情報一覧.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 在職状態変更表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_在職状態リスト_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayGridView();
        }

        /// <summary>
        /// 職員情報一覧または職員資料一覧に切り替えるより、データの更新と表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_表示リスト_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridView_職員情報一覧.Visible = false;
            this.gridView_職員資料一覧.Visible = false;

            switch (this.cmb_表示リスト.SelectedIndex)
            {
                case 0:
                    {
                        職員情報一覧表示();
                        this.gridView_職員情報一覧.Visible = true;                      
                        break;
                    }
                case 1:
                    {
                        職員資料一覧();
                        this.gridView_職員資料一覧.Visible = true;
                        break;
                    }

                default:
                    break;
            }

        }

        /// <summary>
        /// 園内職務変更
        /// </summary>
        /// <param name="選択した職員コード"></param>
        /// <param name="選択した園内職務"></param>
        private void 園内職務変更更新(string Code, string Cell, string Name)
        {
            //DBを接続し、失敗の場合エラーメッセージを表示する。
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
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
            string str_sqlcmd = string.Format(@"update  HL_JEC_職員情報 set 園内職務　= '{0}'
                                                     where 職員コード = {1}", Cell, Code);

            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            try
            {
                com.ExecuteNonQuery();
                toolStripStatusLabel1.ForeColor = Color.Green;
                toolStripStatusLabel1.Text = string.Format("「{0}」さんの園内職務 ： 「{1}」 へ変更しました.",Name,Cell) ;

            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format("「{0}」さんの園内職務は更新失敗しました.",Name);
            }

            sqlcon.Close();
        }

        /// <summary>
        /// ENTER押下よりのデータ取得して、表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplayGridView();
            }
        }
        
        /// <summary>
        ///　園内職務変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_職員情報一覧_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string Code = this.gridView_職員情報一覧.Rows[e.RowIndex].Cells["職員コード"].Value.ToString();
            string Cell = this.gridView_職員情報一覧.Rows[e.RowIndex].Cells["園内職務"].Value.ToString();
            string Name = this.gridView_職員情報一覧.Rows[e.RowIndex].Cells["氏名"].Value.ToString();
            if (Selected_園内職務 == Cell)
            {
                return;
            }
            園内職務変更更新(Code,  Cell,Name);
        }

        /// <summary>
        /// 職員情報変更画面呼び出し処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (this.gridView_職員情報一覧.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvRow;

                dgvRow = gridView_職員情報一覧.SelectedRows[0];

                if (!dgvRow.IsNewRow)
                {
                    if (((Form1)(this.Tag)).m_職員新規と変更Handle.iHandle != IntPtr.Zero)
                    {
                        BringWindowToTop(((Form1)(this.Tag)).m_職員新規と変更Handle.iHandle);
                        return;
                    }

                    職員新規と変更 NewForm_職員変更変更画面 = new 職員新規と変更(2, dgvRow.Cells["職員コード"].Value.ToString(),this, dgvRow.Cells["園内職務"].Value.ToString());

                    NewForm_職員変更変更画面.Tag = ((Form1)(this.Tag));
                    //Start Add chen 2020/10/19 園内職務を渡せるようになった
                    NewForm_職員変更変更画面.jname = dgvRow.Cells["園内職務"].Value.ToString();
                    //End Add chen 2020/10/19
                    NewForm_職員変更変更画面.Show();

                    ((Form1)(this.Tag)).m_職員新規と変更Handle.iHandle = NewForm_職員変更変更画面.Handle;
                    toolStripStatusLabel1.Text = "";
                }
            }
        }

        /// <summary>
        /// 退職画面を呼び出し処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退職ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView_職員情報一覧.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvRow;

                dgvRow = this.gridView_職員情報一覧.SelectedRows[0];

                if (!dgvRow.IsNewRow)
                {
                    if (((Form1)(this.Tag)).m_職員退園Handle.iHandle != IntPtr.Zero)
                    {
                        BringWindowToTop(((Form1)(this.Tag)).m_職員退園Handle.iHandle);
                        return;
                    }

                    退園 NewForm_職員退職画面 = new 退園 ( dgvRow.Cells["職員コード"].Value.ToString(),
                                                           dgvRow.Cells["氏名"].Value.ToString(),
                                                           dgvRow.Cells["園内職務"].Value.ToString(),this)
                    {
                        Tag = ((Form1)(this.Tag))
                    };
                    NewForm_職員退職画面.Show();

                    ((Form1)(this.Tag)).m_職員退園Handle.iHandle = NewForm_職員退職画面.Handle;
                    toolStripStatusLabel1.Text = "";

                }
            }
        }

        /// <summary>
        ///  セルのクリックより、資料の表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_職員資料一覧_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null || e.ColumnIndex <=　1|| e.RowIndex <= -1|| this.gridView_職員資料一覧.CurrentCell.Value.ToString() == "-")
            {
                return;
            }
            //画面項目
            string ID = this.gridView_職員資料一覧.CurrentRow.Cells["社員コード"].Value.ToString();
            string name = this.gridView_職員資料一覧.CurrentRow.Cells["名前"].Value.ToString();
            string column = this.gridView_職員資料一覧.Columns[this.gridView_職員資料一覧.CurrentCell.ColumnIndex].Name;

            SqlConnection sqlcon = new SqlConnection(ComClass.connectionString); //连接数据库

            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                return;
            }

            string sqlcmd = string.Format(@"Select * From [dbo].[HL_JEC_職員情報]   Where 職員コード = {0}", ID);

            try
            {
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();

                reader.Read();

                //ファイルなしの場合
                if (!reader.HasRows || string.IsNullOrEmpty(reader[column].ToString()))
                {
                    return;
                }

                string tempdir = @"C:\Windows\Temp\";

                string filename = gridView_職員資料一覧.CurrentCell.Value.ToString();
                string reNamePdf = tempdir  +  column + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                if (filename.Trim().ToLower().EndsWith(".jpg") || filename.Trim().ToLower().EndsWith(".jpeg") || filename.Trim().ToLower().EndsWith(".png"))
                {
                    File.WriteAllBytes(tempdir + filename, (byte[])reader[column]);
                    ConvertJpgToPdf(tempdir + filename, reNamePdf);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                }
                else if (filename.Trim().ToLower().EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                          filename.Trim().ToLower().EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                          filename.Trim().ToLower().EndsWith(".xlw", StringComparison.OrdinalIgnoreCase) ||
                          filename.Trim().ToLower().EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    File.WriteAllBytes(tempdir + filename, (byte[])reader[column]);
                    ConvertExcelToPDF(tempdir + filename, reNamePdf);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                }
                else if (".doc, .docx".Contains(filename.Substring(filename.LastIndexOf("."))))
                {
                    File.WriteAllBytes(tempdir + filename, (byte[])reader[column]);
                    ConvertWordToPDF(tempdir + filename, reNamePdf);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);

                }
                else
                {
                    File.WriteAllBytes(reNamePdf, (byte[])reader[column]);
                    ComClass.PDF表示(reNamePdf, Properties.Resources.人事);
                }

                toolStripStatusLabel1.Text = "";
                reader.Close();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format("名前:[{0}]{1}の表示処理に失敗しました。", name, column);
            }

            if (sqlcon != null)
            {
                sqlcon.Close();
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
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました。";
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
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = ex.ToString();
            }
            finally
            {
                sqlcon?.Close();
            }

            return null;
        }

        private void 一括印刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (e == null || this.gridView_職員資料一覧.CurrentCell.Value.ToString() == "" || this.gridView_職員資料一覧.CurrentCell.ColumnIndex < 0)
            {
                return;
            }
            string HeaderText = "";
            Selected_職員コード = gridView_職員資料一覧.CurrentRow.Cells["社員コード"].Value.ToString();
            string PrintFileName = gridView_職員資料一覧.CurrentRow.Cells["資格証書"].Value.ToString();
            string PrintFileName1 = gridView_職員資料一覧.CurrentRow.Cells["履歴書"].Value.ToString();
            string PrintFileName2 = gridView_職員資料一覧.CurrentRow.Cells["秘密保持契約書"].Value.ToString();

            if (PrintFileName!="-")
            {
                HeaderText = "資格証書";
                一括印刷用(HeaderText, PrintFileName);
            }
            if (PrintFileName1 != "-")
            {
                HeaderText = "履歴書";
                一括印刷用(HeaderText, PrintFileName1);
            }
            if (PrintFileName2 !="-")
            {
                HeaderText = "秘密保持契約書";
                一括印刷用(HeaderText, PrintFileName2);
            }
        }
        /// <summary>
        /// 一括印刷用
        /// </summary>
        /// <param name="Headtext"></param>
        private void 一括印刷用(string HeaderText, string PrintFileName)
        {
            string tmpdir = @"C:\Windows\Temp\";
            string PrintFileType = PrintFileName.ToLower().Substring(PrintFileName.LastIndexOf("."));
            byte[] PrintFileData = null;
            string rename = tmpdir + PrintFileName.Substring(0, PrintFileName.LastIndexOf(".")) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = string.Format("[{0}]の{1}が印刷中...", HeaderText, PrintFileName);


            string sqlcmd = string.Format(@"Select {0}, {0}名 from HL_JEC_職員情報 where 職員コード = '{1}'", HeaderText, Selected_職員コード);

            System.Data.DataTable getdatatable = GetDatatable(sqlcmd);

            if (gridView_職員資料一覧.CurrentCell.Value.ToString() == "-" || string.IsNullOrWhiteSpace(getdatatable.Rows[0][HeaderText].ToString()))
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format("{0}ファイルがありません。", HeaderText);
                isPrintOK = false;
                return;

            }

            PrintFileData = (byte[])getdatatable.Rows[0][HeaderText];
            File.WriteAllBytes(tmpdir + PrintFileName, PrintFileData);

            if (!tmpdir.Trim().Equals(""))
            {
                string FileName = HeaderText + "-" + DateTime.Now.ToString("yyyyMMddhhMM") + ".doc";
                object filepath = tmpdir + FileName;

                try
                {

                    if (".doc, .docx".Contains(PrintFileType))
                    {
                        ConvertWordToPDF(tmpdir + PrintFileName, rename);
                    }
                    else if (".jpg, .jpeg, .png".Contains(PrintFileType))
                    {
                        ConvertJpgToPdf(tmpdir + PrintFileName, rename);
                    }
                    else if (".xlsx, .xls, .xlw, .xml".Contains(PrintFileType))
                    {
                        ConvertJpgToPdf(tmpdir + PrintFileName, rename);
                    }
                    else if (PrintFileType == ".pdf")
                    {
                        FileInfo fi = new FileInfo(tmpdir + PrintFileName);
                        if (fi.Exists)
                        {
                            fi.MoveTo(rename);
                        }
                    }

                    using (PrintDialog Dialog = new PrintDialog())
                    {
                        Dialog.ShowDialog();

                        ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                        {
                            Verb = "print",
                            CreateNoWindow = true,
                            FileName = rename,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                        Process printProcess = new Process();
                        printProcess.StartInfo = printProcessInfo;
                        printProcess.Start();

                        printProcess.WaitForInputIdle();

                        System.Threading.Thread.Sleep(5000);

                        if (!printProcess.CloseMainWindow())
                        {
                            printProcess.Kill();
                        }
                    }

                    isPrintOK = true;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = ex.Message;
                }
                finally
                {
                    // KillFile(tmpdir, PrintFileName);
                    System.Threading.Thread.Sleep(5000);
                }
            }
            if (isPrintOK)
            {
                toolStripStatusLabel1.ForeColor = Color.Green;
                toolStripStatusLabel1.Text = string.Format("[{0}]の {1} の印刷が完了しました。", HeaderText, PrintFileName);
            }
        }
        /// <summary>
        /// ファイルをアップロードする処理
        /// </summary>
        private void アップロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView_職員資料一覧.CurrentCell.Value.ToString() == "" || this.gridView_職員資料一覧.CurrentCell.ColumnIndex <= 1)
            {
                return;
            }
            toolStripStatusLabel1.Text = "";
            byte[] UploadFileData = null;
            string UploadFileName = string.Empty;
            string UploadFileType = string.Empty;

            if (gridView_職員資料一覧.CurrentCell.Value.ToString() != "-")
            {
                string mess = string.Format("宛先には既に”{0}”という名前のファイルが保存します。ファイルを置き換えますか？", gridView_職員資料一覧.CurrentCell.Value.ToString());
                DialogResult res = MessageBox.Show(mess, "ファイルの置換またはスキップ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UploadFileData = File.ReadAllBytes(openFileDialog.FileName);
                UploadFileName = Path.GetFileName(openFileDialog.FileName);
                UploadFileType = Path.GetFileName(openFileDialog.FileName).Substring(Path.GetFileName(openFileDialog.FileName).LastIndexOf("."));
            }
            else
            {
                return;
            }

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました.";
                return;

            }

            int result = 0;
            string columnファイル名 = this.gridView_職員資料一覧.CurrentCell.OwningColumn.HeaderText+"名";
            string columnファイル = this.gridView_職員資料一覧.CurrentCell.OwningColumn.HeaderText ;
            string Selected_職員コード = this.gridView_職員資料一覧.CurrentRow.Cells["社員コード"].Value.ToString();

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            sqlcom.CommandText = string.Format($@"UPDATE
                                                         HL_JEC_職員情報
                                                        SET
                                                         {columnファイル名} = '{UploadFileName}',
                                                         {columnファイル} = @UploadFileData
                                                        WHERE
                                                         職員コード = '{Selected_職員コード}'");

            try
            {
                sqlcom.Parameters.AddWithValue("@UploadFileData", UploadFileData);

                result = sqlcom.ExecuteNonQuery();

                if (result == 1)
                {
                    transaction.Commit();

                    DisplayGridView();
                    toolStripStatusLabel1.ForeColor = Color.Green;
                    toolStripStatusLabel1.Text = string.Format("[ {0} ]のファイルをアップロードしました。", columnファイル);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format("[ {0} ]のファイルをアップロード失敗しました。" + ex.ToString(), columnファイル);
            }
            finally
            {
                sqlcon?.Close();
            }
        }
        /// <summary>
        /// ファイルをダウロードする処理
        /// </summary>
        private void ファイルダウンロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (this.gridView_職員資料一覧.CurrentCell.Value.ToString() == "" || this.gridView_職員資料一覧.CurrentCell.ColumnIndex <= 1)
                {
                    return;
                }

                string fileName = gridView_職員資料一覧.CurrentCell.Value.ToString();

                if (fileName == "-")
                {
                    return;
                }
                string HeaderText = gridView_職員資料一覧.CurrentCell.OwningColumn.HeaderText;
                Selected_職員コード = gridView_職員資料一覧.CurrentRow.Cells["社員コード"].Value.ToString();
            if (fileName?.Length == 0)
                {
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                    this.toolStripStatusLabel1.Text = string.Format("ファイル [{0}] がありません。", fileName);
                    return;
                }

                string sqlcmd = String.Format(@"Select {0}名, {0} From HL_JEC_職員情報 where 職員コード = '{1}'", HeaderText, Selected_職員コード);
                System.Data.DataTable getdata = GetDatatable(sqlcmd);

                bool isDownloadOk;
                if (string.IsNullOrEmpty(getdata.Rows[0][HeaderText].ToString()))
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = string.Format("名前:[{0}]{1}のデータがありません。", HeaderText, fileName);
                    isDownloadOk = false;
                    return;
                }

                try
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    byte[] fileData = (byte[])getdata.Rows[0][HeaderText];
                    string fileExtension = fileInfo.Extension;

                    using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                    {
                        saveFileDialog1.Filter = "Files (*" + fileExtension + ")|*" + fileExtension;
                        saveFileDialog1.Title = "Save File as";
                        saveFileDialog1.CheckPathExists = true;
                        saveFileDialog1.FileName = fileName;

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog1.FileName, fileData);
                            isDownloadOk = true;
                            if (isDownloadOk)
                            {
                                toolStripStatusLabel1.ForeColor = Color.Green;
                                toolStripStatusLabel1.Text = string.Format("ファイル [{0}] がダウンロードしました。", fileName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = ex.Message;
                }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            System.Drawing.Point startPosition = Cursor.Position;
            System.Drawing.Point point = this.gridView_職員資料一覧.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.gridView_職員資料一覧.HitTest(point.X, point.Y);
            this.gridView_職員資料一覧.ClearSelection();

            if (hitinfo.RowIndex >= 0)
            {
                this.gridView_職員資料一覧.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }

            string PrintFileName = gridView_職員資料一覧.CurrentRow.Cells["資格証書"].Value.ToString();
            string PrintFileName1 = gridView_職員資料一覧.CurrentRow.Cells["履歴書"].Value.ToString();
            string PrintFileName2 = gridView_職員資料一覧.CurrentRow.Cells["秘密保持契約書"].Value.ToString();

            if ( PrintFileName=="-"&& PrintFileName1 == "-" && PrintFileName2 == "-" )
            {
                contextMenuStrip2.Items[0].Enabled = false;
            }
            else
            {
                contextMenuStrip2.Items[0].Enabled = true;
            }
            if (gridView_職員資料一覧.CurrentCell.ColumnIndex <= 1)
            {
                contextMenuStrip2.Items[1].Enabled = false;
                contextMenuStrip2.Items[2].Enabled = false;
            }
            else if (gridView_職員資料一覧.CurrentCell.Value.ToString() == "-" )
            {
                contextMenuStrip2.Items[2].Enabled = false;
            }
            else
            {
                contextMenuStrip2.Items[1].Enabled = true;
                contextMenuStrip2.Items[2].Enabled = true;
            }
        }
        private void gridView_職員情報一覧_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                Selected_園内職務 = this.gridView_職員情報一覧.Rows[e.RowIndex].Cells["園内職務"].Value.ToString();
            }
            
        }

        private void 健康診断一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView_職員情報一覧.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvRow;

                dgvRow = gridView_職員情報一覧.SelectedRows[0];

                if (!dgvRow.IsNewRow)
                {
                    if (((Form1)(this.Tag)).m_職員健康診断書一覧Handle.iHandle != IntPtr.Zero)
                    {
                        BringWindowToTop(((Form1)(this.Tag)).m_職員健康診断書一覧Handle.iHandle);
                        return;
                    }

                    職員健康診断書一覧 NewForm_職員健康診断書一覧画面 = new 職員健康診断書一覧();

                    NewForm_職員健康診断書一覧画面.Tag = ((Form1)(this.Tag));
                    NewForm_職員健康診断書一覧画面.Show();

                    ((Form1)(this.Tag)).m_健康診断Handle.iHandle = NewForm_職員健康診断書一覧画面.Handle;
                    toolStripStatusLabel1.Text = "";
                }
            }
        }

        private void 検便記録一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridView_職員情報一覧.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvRow;

                dgvRow = gridView_職員情報一覧.SelectedRows[0];

                if (!dgvRow.IsNewRow)
                {
                    if (((Form1)(this.Tag)).m_健康診断Handle.iHandle != IntPtr.Zero)
                    {
                        BringWindowToTop(((Form1)(this.Tag)).m_健康診断Handle.iHandle);
                        return;
                    }

                    職員検便記録表 NewForm_検便記録一覧画面 = new 職員検便記録表();

                    NewForm_検便記録一覧画面.Tag = ((Form1)(this.Tag));
                    NewForm_検便記録一覧画面.Show();

                    ((Form1)(this.Tag)).m_健康診断Handle.iHandle = NewForm_検便記録一覧画面.Handle;
                    toolStripStatusLabel1.Text = "";
                }
            }
        }
    }
}
