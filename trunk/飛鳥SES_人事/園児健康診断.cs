using ComDll;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace 飛鳥SES_人事
{
    public partial class 園児健康診断 : DockContent
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        //public const string connectionString = "Server=DESKTOP-EPSQBR1\\SQLEXPRESS;Database=oa;Integrated Security=True";
        public string connectionString = ComClass.connectionString;
        private string beforeValue = "";
        private bool IsUpdating = false;
        DataTable dt = null;
        public FromHandleBox m_健康診断Handle = new FromHandleBox();
        public DateTime datatime { get; set; }
        public string name { get; set; }
        public string FileName { get; set;}
        bool Isregist = false;
        bool Isoutput = false;

        public 園児健康診断()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case ComClass.CUSTOM_MESSAGE:
                    {
                        if(Isoutput==false)
                        {
                            DisplayGridView(datatime);
                            if (Isregist)
                            {
                                toolStripStatusLabel1.ForeColor = Color.Green;
                                toolStripStatusLabel1.Text = name + "を正常に登録しました。";
                                Isregist = false;
                            }
                            else
                            {
                                toolStripStatusLabel1.ForeColor = Color.Green;
                                toolStripStatusLabel1.Text = name + "を正常に更新しました。";
                            }
                        }
                        else
                        {
                            toolStripStatusLabel1.ForeColor = Color.Green;
                            toolStripStatusLabel1.Text = FileName + "出力しました。";
                            Isoutput = false;
                        }
                       
                    }
                    break;
                default:
                    base.WndProc(ref msg);
                    break;
            }
        }
        private void 児童健康状況一覧_Load(object sender, EventArgs e)
        {
            //メッセージをクリアする
            toolStripStatusLabel1.Text = "";
            DisplayGridView(dtp_日付.Value);
            OpenGridViewDetail();
        }

        /// <summary>
        /// 初期表示
        /// 検索処理
        /// </summary>
        /// <param name="time"></param>        
        private void DisplayGridView(DateTime time)
        {
            //画面値を取得
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました.";
                toolStrip1.Text = string.Format("{0}件", 0);
                return;
            }
            dtp_日付.Value = time;
            string str_sqlcmd = string.Format(@"select a.園児コード,a.名前,b.日付,b.チェック項目,b.体温,b.食事内容状況,b.室温,b.排便, b.id                                        
　　　　　　　　　　　　　　　　              from  HL_JEC_園児情報マスタ a left join  HL_JEC_園児健康状況観察 b  on a.園児コード = b.園児コード
                                              Where b.日付 = '{0}' order by a.園児コード", time);
            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            dataGridView_健康診断.Rows.Clear();
            //toolStripStatusLabel1.Text = "";
            int index = 0;
            dt = new DataTable();
            dt.Columns.Add("園児コード");
            dt.Columns.Add("園児名");
            dt.Columns.Add("日付");
            dt.Columns.Add("室温");
            dt.Columns.Add("体温");
            dt.Columns.Add("検温時間");
            dt.Columns.Add("チェック項目");
            dt.Columns.Add("健康状況");
            dt.Columns.Add("排便");
            dt.Columns.Add("回数");
            dt.Columns.Add("食事内容状況");
            dt.Columns.Add("GroupCode");
            dt.Columns.Add("CName");
            dt.Columns.Add("行番号");
            dt.Columns.Add("id");

            int 件数 = 0;
            try
            {
                while (reader.Read())
                {
                    if (
                          (reader["名前"].ToString().IndexOf(txt_search.Text) < 0)
                          &&
                          (reader["園児コード"].ToString().IndexOf(txt_search.Text) < 0)
                          )
                    {
                        continue;
                    }
                    int preindex = index;

                    //dt.Rows.Add();
                    string[] チェック項目 = reader["チェック項目"].ToString().Split(',');
                    string[] 体温 = reader["体温"].ToString().Split(',');
                    string[] 排便 = reader["排便"].ToString().Split(',');

                    int rowIndex = (new int[] { チェック項目.Length, 体温.Length, 排便.Length }).Max();

                    for (int x = 0; x < rowIndex; x++)
                    {
                        DataRow r = dt.NewRow();
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

                        dt.Rows.Add(r);
                    }
                    件数++;
                }
                int 行数 = dt.Rows.Count;
                for (int i = 0; i < 行数; i++)
                {
                    dataGridView_健康診断.Rows.Add();
                    dataGridView_健康診断.Rows[i].Cells["園児コード"].Value = (dt.Rows[i]["園児コード"] == null ? string.Empty : dt.Rows[i]["園児コード"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["園児コード"].ReadOnly = true;
                    dataGridView_健康診断.Rows[i].Cells["園児名"].Value = (dt.Rows[i]["園児名"] == null ? string.Empty : dt.Rows[i]["園児名"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["園児名"].ReadOnly = true;
                    dataGridView_健康診断.Rows[i].Cells["日付"].Value = (dt.Rows[i]["日付"] == null ? string.Empty : dt.Rows[i]["日付"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["日付"].ReadOnly = true;
                    dataGridView_健康診断.Rows[i].Cells["室温"].Value = (dt.Rows[i]["室温"] == null ? string.Empty : dt.Rows[i]["室温"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["体温"].Value = (dt.Rows[i]["体温"] == null ? string.Empty : dt.Rows[i]["体温"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["検温時間"].Value = (dt.Rows[i]["検温時間"] == null ? string.Empty : dt.Rows[i]["検温時間"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["チェック項目"].Value = (dt.Rows[i]["チェック項目"] == null ? string.Empty : dt.Rows[i]["チェック項目"].ToString());
                    if (dataGridView_健康診断.Rows[i].Cells["チェック項目"].Value.ToString() == "機嫌")
                    {
                        ((DataGridViewComboBoxCell)(dataGridView_健康診断.Rows[i].Cells["健康状況"])).Items.Add("良");
                        ((DataGridViewComboBoxCell)(dataGridView_健康診断.Rows[i].Cells["健康状況"])).Items.Add("普通");
                        ((DataGridViewComboBoxCell)(dataGridView_健康診断.Rows[i].Cells["健康状況"])).Items.Add("不良");
                    }
                    else
                    {
                        ((DataGridViewComboBoxCell)(dataGridView_健康診断.Rows[i].Cells["健康状況"])).Items.Add("有");
                        ((DataGridViewComboBoxCell)(dataGridView_健康診断.Rows[i].Cells["健康状況"])).Items.Add("無");
                    }
                    if (dataGridView_健康診断.Rows[i].Cells["チェック項目"].Value.ToString() == "その他")
                    {
                        dataGridView_健康診断.Rows[i].Cells["健康状況"] = new DataGridViewTextBoxCell();
                    }
                    dataGridView_健康診断.Rows[i].Cells["健康状況"].Value = (dt.Rows[i]["健康状況"] == null ? string.Empty : dt.Rows[i]["健康状況"].ToString().Trim());
                    dataGridView_健康診断.Rows[i].Cells["排便"].Value = (dt.Rows[i]["排便"] == null ? string.Empty : dt.Rows[i]["排便"].ToString());
                    dataGridView_健康診断.Rows[i].Cells["回数"].Value = (dt.Rows[i]["回数"] == null ? string.Empty : dt.Rows[i]["回数"].ToString().Trim());
                    string 食事 = string.IsNullOrWhiteSpace(dt.Rows[i]["食事内容状況"].ToString()) ? string.Empty : dt.Rows[i]["食事内容状況"].ToString().Trim();
                    dataGridView_健康診断.Rows[i].Cells["食事内容状況"].Value = 食事;
                    dataGridView_健康診断.Rows[i].Cells["GroupCode"].Value = (dt.Rows[i]["GroupCode"] == null ? string.Empty : dt.Rows[i]["GroupCode"].ToString().Trim());
                    dataGridView_健康診断.Rows[i].Cells["CName"].Value = (dt.Rows[i]["CName"] == null ? string.Empty : dt.Rows[i]["CName"].ToString().Trim());
                    dataGridView_健康診断.Rows[i].Cells["行番号"].Value = (dt.Rows[i]["行番号"] == null ? string.Empty : dt.Rows[i]["行番号"].ToString().Trim());
                    dataGridView_健康診断.Rows[i].Cells["id"].Value = (dt.Rows[i]["id"] == null ? string.Empty : dt.Rows[i]["id"].ToString().Trim());

                    if (!string.IsNullOrWhiteSpace(dt.Rows[i]["園児コード"].ToString()))
                    {
                        dataGridView_健康診断.Rows[i].HeaderCell.Value = "-";
                        dataGridView_健康診断.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    //空白セル
                    foreach (DataGridViewCell gvCell in dataGridView_健康診断.Rows[i].Cells)
                    {
                        if (string.IsNullOrWhiteSpace(gvCell.Value.ToString()) || gvCell.Value.ToString() == string.Empty)
                        {
                            if (gvCell.Value.ToString() != "食内容状況" && dataGridView_健康診断.Rows[i].Cells["行番号"].Value.ToString() != "1")
                            {
                                gvCell.Style.BackColor = Color.White;
                                gvCell.ReadOnly = true;
                                dataGridView_健康診断.Rows[i].Cells[gvCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "検索処理に失敗しました。" + ex.Message;
                return;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
                toolStrip1.Text = string.Format("{0}件", 件数);
            }
        }
        /// <summary>
        /// 行首をクリックイベント
        /// すべて表示
        /// 行を隠す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_児童健康状況一覧_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int count = dataGridView_健康診断.CurrentRow.Index;
            if (dataGridView_健康診断.CurrentRow.HeaderCell.Value != null)
            {
                bool state = IsUpdating;
                IsUpdating = false;
                string openStyle = dataGridView_健康診断.CurrentRow.HeaderCell.Value.ToString();

                try
                {
                    while (dataGridView_健康診断.Rows.Count - 1 > count)
                    {
                        if (dataGridView_健康診断.Rows[count].Cells["GroupCode"].Value.ToString()
                        == dataGridView_健康診断.Rows[count + 1].Cells["GroupCode"].Value.ToString())
                        {
                            dataGridView_健康診断.Rows[count + 1].Visible = openStyle == "+";
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    dataGridView_健康診断.CurrentRow.HeaderCell.Value = openStyle == "+" ? "-" : "+";
                    IsUpdating = state;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = ex.Message;
                    return;
                }
            }
            else
            {
                return;
            }
        }
　　　　/// <summary>
　　　　///"+"ボタンイベント
　　　　///行をすべて表示
　　　　/// </summary>
　　　　/// <param name="sender"></param>
　　　　/// <param name="e"></param>
        private void Btn_全て表示_Click(object sender, EventArgs e)
        {
            OpenGridViewDetail();
        }

        /// <summary>
        /// 行をすべて表示
        /// </summary>
        /// <param name="type"></param>
        private void OpenGridViewDetail(bool type = true)
        {
            try
            {
                int count = dataGridView_健康診断.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (type)
                    {
                        if (dataGridView_健康診断.Rows[i].HeaderCell.Value == null)
                        {
                            dataGridView_健康診断.Rows[i].Visible = true;
                        }
                        else
                        {
                            dataGridView_健康診断.Rows[i].HeaderCell.Value = "-";
                        }
                    }
                    else
                    {
                        if (dataGridView_健康診断.Rows[i].HeaderCell.Value != null)
                        {
                            if (dataGridView_健康診断.Rows[i].HeaderCell.Value.ToString() == "-")
                            {
                                dataGridView_健康診断.Rows[i].HeaderCell.Value = "+";
                            }
                        }
                        else
                        {
                            dataGridView_健康診断.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = ex.Message;
                return;
            }
        }
        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_search_Click(object sender, EventArgs e)
        {
            //メッセージをクリアする
            toolStripStatusLabel1.Text = "";
            IsUpdating = false;
            DisplayGridView(dtp_日付.Value);
            OpenGridViewDetail(false);
        }
        /// <summary>
        /// "-"ボタンイベント
        /// 行を隠す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_隠す_Click(object sender, EventArgs e)
        {
            OpenGridViewDetail(false);
        }
        /// <summary>
        /// 変更前のバリューを取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_児童健康状況一覧_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsUpdating = true;
            toolStripStatusLabel1.Text = "";
            beforeValue = dataGridView_健康診断.CurrentCell.EditedFormattedValue.ToString();
        }
        /// <summary>
        /// 更新イベント
        /// </summary>
        /// <param name="columname"></param>
        /// <param name="value"></param>
        /// <param name="groupcode"></param>
        /// <param name="num"></param>
        /// <param name="gvColName"></param>
        private void Update_GridViewRow(string columname, string value, string groupcode, string num, string[] gvColName = null)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库
            try
            {
                sqlcon.Open();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "DBサーバーの接続に失敗しました。";
            }
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;

            //更新行う
            try
            {
                if (columname == "体温" || columname == "チェック項目" || columname == "排便")
                {
                    List<DataRow> rows = dt.AsEnumerable().Where(r => r["GroupCode"].ToString() == groupcode).ToList();

                    string a = string.Empty;
                    foreach (DataRow r in rows)
                    {
                        if (r["行番号"].ToString() == num)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                a += value + ",";
                            }
                        }
                        else if (r[columname].ToString() != "")
                        {
                            a += string.Format("{0}-{1},", r[gvColName[0]].ToString(), r[gvColName[1]].ToString());
                        }
                    }
                    value = a.Substring(0, a.Length - 1);
                }
                string id = dataGridView_健康診断.CurrentRow.Cells["id"].Value.ToString();
                sqlcom.CommandText = string.Format(@"UPDATE HL_JEC_園児健康状況観察 SET {0} = N'{1}' where  id= '{2}'",
                                                    columname, value, id);
                int result = sqlcom.ExecuteNonQuery();
                if (result != 1)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = dataGridView_健康診断.CurrentRow.Cells["CName"].Value.ToString()
                        + "の更新処理が失敗しました。";
                }
                else
                {
                    toolStripStatusLabel1.ForeColor = Color.Green;
                    toolStripStatusLabel1.Text = dataGridView_健康診断.CurrentRow.Cells["CName"].Value.ToString()
                   + "を正常に更新しました。";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = dataGridView_健康診断.CurrentRow.Cells["CName"].Value.ToString()
                                             + "の更新処理が失敗しました。" + ex.Message;
                return;
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
        /// 変更後のバリューを獲得する
        /// 更新する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_児童健康状況一覧_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsUpdating)
                {
                    string name = dataGridView_健康診断.CurrentRow.Cells["園児名"].Value.ToString();
                    string columname = dataGridView_健康診断.Columns[dataGridView_健康診断.CurrentCell.ColumnIndex].Name;
                    string value = dataGridView_健康診断.CurrentCell.EditedFormattedValue.ToString();
                    string id = dataGridView_健康診断.CurrentRow.Cells["GroupCode"].Value.ToString();
                    string 行番号 = dataGridView_健康診断.Rows[dataGridView_健康診断.CurrentCell.RowIndex].Cells["行番号"].Value.ToString();

                    if (beforeValue != value)
                    {
                        if (columname == "体温" && value == string.Empty)
                        {
                            toolStripStatusLabel1.ForeColor = Color.Red;
                            toolStripStatusLabel1.Text = "体温を入力してください.";
                            return;
                        }
                        if (columname == "検温時間" && value == string.Empty)
                        {
                            toolStripStatusLabel1.ForeColor = Color.Red;
                            toolStripStatusLabel1.Text = "検温時間を入力してください.";
                            return;
                        }
                        if (columname == "室温" && value == string.Empty)
                        {
                            toolStripStatusLabel1.ForeColor = Color.Red;
                            toolStripStatusLabel1.Text = "室温を入力してください.";
                            return;
                        }
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            double d = 0.0;
                            if ((columname == "体温" || columname == "室温" || columname == "回数")
                                && !Double.TryParse(value, out d))
                            {
                                toolStripStatusLabel1.ForeColor = Color.Red;
                                toolStripStatusLabel1.Text = "数字を入力してください.";
                                return;
                            }
                            else if ((columname == "体温" && (decimal.Parse(value) >= 45 || decimal.Parse(value) <= 30))
                                   || (columname == "室温" && (decimal.Parse(value) <= -30 || decimal.Parse(value) >= 45))
                                   || (columname == "回数" && int.Parse(value) < 0))
                                 {
                                     dataGridView_健康診断.CurrentCell.Value = beforeValue;
                                     toolStripStatusLabel1.ForeColor = Color.Red;
                                     if (columname == "回数")
                                     {
                                         toolStripStatusLabel1.Text = name + "の更新処理が失敗しました。負数を入力しないでください";
                                     }
                                     else
                                     {
                                         toolStripStatusLabel1.Text = name + "の更新処理が失敗しました。正しい温度を入力してください";
                                     }
                                     return;
                                 }
                        }

                        string[] gvColName = null;
                        switch (columname)
                        {
                            case "体温":
                            case "検温時間":
                                if (string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["検温時間"].EditedFormattedValue.ToString())
                                    && string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["体温"].EditedFormattedValue.ToString()))
                                {
                                    value = string.Empty;
                                }
                                else
                                {
                                    value = dataGridView_健康診断.CurrentRow.Cells["検温時間"].EditedFormattedValue.ToString() + "-" +
                                            dataGridView_健康診断.CurrentRow.Cells["体温"].EditedFormattedValue.ToString();
                                }
                                columname = "体温";
                                gvColName = new string[] { "検温時間", "体温" };
                                break;

                            case "チェック項目":
                            case "健康状況":
                                if (string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["チェック項目"].EditedFormattedValue.ToString())
                                    && string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["健康状況"].EditedFormattedValue.ToString()))
                                {
                                    value = string.Empty;
                                }
                                else if (dataGridView_健康診断.CurrentRow.Cells["チェック項目"].EditedFormattedValue.ToString() == "その他"
                                     && string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["健康状況"].EditedFormattedValue.ToString()))
                                {
                                    value = string.Empty;
                                }
                                else
                                {
                                    value = dataGridView_健康診断.CurrentRow.Cells["チェック項目"].EditedFormattedValue.ToString() + "-" +
                                            dataGridView_健康診断.CurrentRow.Cells["健康状況"].EditedFormattedValue.ToString();
                                }
                                columname = "チェック項目";
                                gvColName = new string[] { "チェック項目", "健康状況" };
                                break;
                            case "排便":
                            case "回数":
                                if (string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["排便"].EditedFormattedValue.ToString())
                                   && string.IsNullOrWhiteSpace(dataGridView_健康診断.CurrentRow.Cells["回数"].EditedFormattedValue.ToString()))
                                {
                                    value = string.Empty;
                                }
                                else
                                {
                                    value = dataGridView_健康診断.CurrentRow.Cells["排便"].EditedFormattedValue.ToString() + "-" +
                                            (dataGridView_健康診断.CurrentRow.Cells["回数"].EditedFormattedValue.ToString() == string.Empty ? "0"
                                            : dataGridView_健康診断.CurrentRow.Cells["回数"].EditedFormattedValue.ToString());
                                }
                                columname = "排便";
                                gvColName = new string[] { "排便", "回数" };
                                break;
                            default:
                                break;
                        }
                        Update_GridViewRow(columname, value, id, dataGridView_健康診断.CurrentRow.Cells["行番号"].Value.ToString(), gvColName);
                        IsUpdating = false;
                        DisplayGridView(dtp_日付.Value);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = dataGridView_健康診断.CurrentRow.Cells["CName"].Value.ToString()
                                            + "の更新処理が失敗しました。" + ex.Message;
                return;
            }
        }
        /// <summary>
        /// CeLLの線を設定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_児童健康状況一覧_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            // 1行目や列ヘッダ、行ヘッダの場合は何もしない
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                e.AdvancedBorderStyle.Top = dataGridView_健康診断.AdvancedCellBorderStyle.Top;
                e.AdvancedBorderStyle.Bottom = dataGridView_健康診断.AdvancedCellBorderStyle.Bottom;
                e.AdvancedBorderStyle.Right = dataGridView_健康診断.AdvancedCellBorderStyle.Right;
                e.AdvancedBorderStyle.Left = dataGridView_健康診断.AdvancedCellBorderStyle.Left;
                return;
            }
            if (dataGridView_健康診断.Rows[e.RowIndex].Cells["GroupCode"].Value.ToString() == dataGridView_健康診断.Rows[e.RowIndex - 1].Cells["GroupCode"].Value.ToString()
                && (e.ColumnIndex < 5))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                dataGridView_健康診断.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
            }
            else if (string.IsNullOrWhiteSpace(dataGridView_健康診断.Rows[e.RowIndex].Cells[5].Value.ToString())
                     && string.IsNullOrWhiteSpace(dataGridView_健康診断.Rows[e.RowIndex].Cells[6].Value.ToString())
                     && (e.ColumnIndex < 7))
                 {
                     e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                     e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                     e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                     dataGridView_健康診断.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                 }
            else if (string.IsNullOrWhiteSpace(dataGridView_健康診断.Rows[e.RowIndex].Cells[9].Value.ToString()) &&
                    string.IsNullOrWhiteSpace(dataGridView_健康診断.Rows[e.RowIndex].Cells[10].Value.ToString())
                    && (e.ColumnIndex > 8))
                 {
                     e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                     e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                     e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                     dataGridView_健康診断.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = Color.White;
                 }
                 else
                 {
                     e.AdvancedBorderStyle.Top = dataGridView_健康診断.AdvancedCellBorderStyle.Top;
                     e.AdvancedBorderStyle.Bottom = dataGridView_健康診断.AdvancedCellBorderStyle.Bottom;
                     e.AdvancedBorderStyle.Right = dataGridView_健康診断.AdvancedCellBorderStyle.Right;
                     e.AdvancedBorderStyle.Left = dataGridView_健康診断.AdvancedCellBorderStyle.Left;
                 }
        }

        private void 健康診断_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_健康診断Handle.iHandle = IntPtr.Zero;
        }
        /// <summary>
        /// 登録画面に遷移する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_regist_Click(object sender, EventArgs e)
        {
            園児健康診断登録 m_NewForm健康診断登録 = new 園児健康診断登録();
            m_NewForm健康診断登録.Tag = this.Tag;
            m_NewForm健康診断登録.Owner = this;//重要的一步，主要是使健康診断登録的Owner指针指向健康診断
            m_NewForm健康診断登録.Show();
            Isregist = true;
            //this.Close();
        }
        /// <summary>
        /// メニューを選択して
        /// 変更画面に遷移する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            園児健康診断登録 m_NewForm健康診断登録 = new 園児健康診断登録();
            m_NewForm健康診断登録.Tag = this.Tag;
            m_NewForm健康診断登録.Owner = this;//重要的一步，主要是使健康診断登録的Owner指针指向健康診断
            m_NewForm健康診断登録.code = dataGridView_健康診断.Rows[dataGridView_健康診断.CurrentCell.RowIndex].Cells["GroupCode"].Value.ToString();
            m_NewForm健康診断登録.time = dataGridView_健康診断.Rows[dataGridView_健康診断.CurrentCell.RowIndex].Cells["日付"].Value.ToString();
            m_NewForm健康診断登録.Show();
        }
        /// <summary>
        /// 行の右クリックのメニュー設定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point startPosition = Cursor.Position;
            Point point = this.dataGridView_健康診断.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = this.dataGridView_健康診断.HitTest(point.X, point.Y);
            this.dataGridView_健康診断.ClearSelection();
            if (hitinfo.RowIndex >= 0 &&
                dataGridView_健康診断.Rows[(hitinfo.RowIndex)].Cells["行番号"].Value.ToString() == "1")
            {
                this.dataGridView_健康診断.Rows[hitinfo.RowIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 出力画面に遷移する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_output_Click(object sender, EventArgs e)
        {
            園児健診出力 m_NewForm園児健診出力 = new 園児健診出力();
            m_NewForm園児健診出力.Tag = this.Tag;
            m_NewForm園児健診出力.Owner = this;//重要的一步，主要是使健康診断登録的Owner指针指向健康診断
            m_NewForm園児健診出力.Show();
            Isoutput = true;
        }
        /// <summary>
        /// 日付を変更するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_日付_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            DisplayGridView(dtp_日付.Value);
            OpenGridViewDetail(false);
        }
    }
}
