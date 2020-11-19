using ComDll;
using Microsoft.Office.Interop.Word;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using CCWin.SkinClass;

namespace 飛鳥SES_人事
{
    public partial class 園児情報一覧 : DockContent
    {
        #region 変数設定

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        private string connectionString = ComClass.connectionString;

        private int CmbSelected画面;
        private bool Editing = false;
        private string BeforeValue = string.Empty;
        private string Selected_園児コード = string.Empty;
        private string columnName = string.Empty;
        private bool isPrintOK = false;

        #endregion

        #region Main処理

        public 園児情報一覧()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case ComClass.CUSTOM_MESSAGE:
                    {
                        DisplayGridView(CmbSelected画面);
                    }
                    break;

                default:
                    base.WndProc(ref msg);
                    break;
            }
        }

        /// <summary>
        /// 初期画面Load
        /// </summary>
        private void 園児情報一覧_Load(object sender, EventArgs e)
        {
            cmb_gridview.SelectedIndex = 0;
        }

        /// <summary>
        /// 画面が閉じる時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 園児情報一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_園児情報一覧Handle.iHandle = IntPtr.Zero;
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
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました。";
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
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = ex.ToString();
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
        /// 画面リストの選択によって、該当するDGVをLoad
        /// </summary>
        private void DisplayGridView(int CmbSelected画面)
        {
            switch (CmbSelected画面)
            {
                //0: 園児情報一覧
                case 0:
                    SetupAndFillDataCase0();
                    break;

                //1:園児緊急連絡先
                case 1:
                    SetupAndFillDataCase1();
                    break;

                //2:園児健康情報
                case 2:
                    SetupAndFillDataCase2();
                    break;

                //3:園児入園材料
                case 3:
                    SetupAndFillDataCase3();
                    break;

                //４：園児退園材料
                case 4:
                    SetupAndFillDataCase4();
                    break;

                default:
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = "初期画面の設定が失敗しました。";
                    return;
            }
        }

        /// <summary>
        /// 園児情報一覧画面の設定とデータ取得
        /// </summary>
        private void SetupAndFillDataCase0()
        {
            int index = 0;
            string sqlcmd = string.Format(@"SELECT * FROM HL_JEC_園児情報マスタ");

            DateGV.Rows.Clear();
            DateGV.Columns.Clear();

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return;
            }

            DataGridViewComboBoxColumn cmb_sex = new DataGridViewComboBoxColumn
            {
                HeaderText = "性別",
                Name = "性別"
            };
            cmb_sex.Items.Add("男");
            cmb_sex.Items.Add("女");

            DataGridViewComboBoxColumn cmb_コース = new DataGridViewComboBoxColumn
            {
                HeaderText = "コース",
                Name = "コース"
            };
            cmb_コース.Items.Add("通常　 8:00~18:00");
            cmb_コース.Items.Add("延長1　8:00~19:00");
            cmb_コース.Items.Add("延長2　7:30~19:00");

            //カラム作成
            DateGV.Columns.Add("園児コード", "園児コード");
            DateGV.Columns.Add("名前", "名前");
            DateGV.Columns.Add("フリガナ", "フリガナ");
            DateGV.Columns.Add(cmb_sex);
            DateGV.Columns.Add("生年月日", "生年月日");
            DateGV.Columns.Add("電話番号", "電話番号");
            DateGV.Columns.Add("郵便番号", "郵便番号");
            DateGV.Columns.Add("住所", "住所");
            DateGV.Columns.Add("メール", "メール");
            DateGV.Columns.Add("登園開始日", "登園開始日");
            DateGV.Columns.Add(cmb_コース);
            DateGV.Columns.Add("備考", "備考");
            DateGV.Columns.Add("退園日", "退園日");

            DateGV.ReadOnly = false;
            DateGV.Columns["園児コード"].Visible = false;

            //Set datetime's format of the columns
            DateGV.Columns["生年月日"].DefaultCellStyle.Format = "yyyy/MM/dd";
            DateGV.Columns["登園開始日"].DefaultCellStyle.Format = "yyyy/MM/dd";
            DateGV.Columns["退園日"].DefaultCellStyle.Format = "yyyy/MM/dd";

            //Set columns's length
            ((DataGridViewTextBoxColumn)DateGV.Columns["フリガナ"]).MaxInputLength = 50;
            ((DataGridViewTextBoxColumn)DateGV.Columns["生年月日"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)DateGV.Columns["電話番号"]).MaxInputLength = 13;
            ((DataGridViewTextBoxColumn)DateGV.Columns["郵便番号"]).MaxInputLength = 8;
            ((DataGridViewTextBoxColumn)DateGV.Columns["住所"]).MaxInputLength = 200;
            ((DataGridViewTextBoxColumn)DateGV.Columns["メール"]).MaxInputLength = 100;
            ((DataGridViewTextBoxColumn)DateGV.Columns["登園開始日"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)DateGV.Columns["備考"]).MaxInputLength = 500;
            ((DataGridViewTextBoxColumn)DateGV.Columns["退園日"]).MaxInputLength = 10;

            try
            {
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["園児コード"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["名前"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["性別"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["フリガナ"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["生年月日"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["電話番号"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["郵便番号"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["住所"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["メール"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["登園開始日"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["コース"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["備考"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["退園日"].ToString().IndexOf(txt_search.Text) < 0))
                    {
                        continue;
                    }

                    //Rowにデータ入れ
                    DateGV.Rows.Add();
                    DateGV.Rows[index].Cells["園児コード"].Value = string.IsNullOrWhiteSpace(reader["園児コード"].ToString()) ? "-" : reader["園児コード"].ToString();
                    DateGV.Rows[index].Cells["名前"].Value = string.IsNullOrWhiteSpace(reader["名前"].ToString()) ? "-" : reader["名前"].ToString();
                    DateGV.Rows[index].Cells["性別"].Value = string.IsNullOrWhiteSpace(reader["性別"].ToString()) ? "-" : reader["性別"].ToString();
                    DateGV.Rows[index].Cells["フリガナ"].Value = string.IsNullOrWhiteSpace(reader["フリガナ"].ToString()) ? "-" : reader["フリガナ"].ToString();
                    DateGV.Rows[index].Cells["生年月日"].Value = string.IsNullOrWhiteSpace(reader["生年月日"].ToString()) ? "-" : Convert.ToDateTime(reader["生年月日"]).ToString("yyyy/MM/dd");
                    DateGV.Rows[index].Cells["電話番号"].Value = string.IsNullOrWhiteSpace(reader["電話番号"].ToString()) ? "-" : reader["電話番号"].ToString();
                    DateGV.Rows[index].Cells["郵便番号"].Value = string.IsNullOrWhiteSpace(reader["郵便番号"].ToString()) ? "-" : reader["郵便番号"].ToString();
                    DateGV.Rows[index].Cells["住所"].Value = string.IsNullOrWhiteSpace(reader["住所"].ToString()) ? "-" : reader["住所"].ToString();
                    DateGV.Rows[index].Cells["メール"].Value = string.IsNullOrWhiteSpace(reader["メール"].ToString()) ? "-" : reader["メール"].ToString();
                    DateGV.Rows[index].Cells["登園開始日"].Value = string.IsNullOrWhiteSpace(reader["登園開始日"].ToString()) ? "-" : Convert.ToDateTime(reader["登園開始日"]).ToString("yyyy/MM/dd");

                    string course = reader["コース"].ToString() ?? "通常";
                    switch(course)
                    {
                        case "通常":
                            DateGV.Rows[index].Cells["コース"].Value = "通常　 8:00~18:00";
                            break;
                        case "延長1":
                            DateGV.Rows[index].Cells["コース"].Value = "延長1　8:00~19:00";
                            break;
                        case "延長2":
                            DateGV.Rows[index].Cells["コース"].Value = "延長2　7:30~19:00";
                            break;
                        default:
                            DateGV.Rows[index].Cells["コース"].Value = "通常　 8:00~18:00";
                            break;
                    }

                    DateGV.Rows[index].Cells["備考"].Value = string.IsNullOrWhiteSpace(reader["備考"].ToString()) ? "-" : reader["備考"].ToString();
                    DateGV.Rows[index].Cells["退園日"].Value = string.IsNullOrWhiteSpace(reader["退園日"].ToString()) ? "-" : Convert.ToDateTime(reader["退園日"]).ToString("yyyy/MM/dd");

                    foreach (DataGridViewCell gridCell in DateGV.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() != "-")
                        {
                            if (gridCell.OwningColumn.HeaderText == "名前" ||
                                gridCell.OwningColumn.HeaderText == "フリガナ" ||
                                gridCell.OwningColumn.HeaderText == "住所" ||
                                gridCell.OwningColumn.HeaderText == "メール" ||
                                gridCell.OwningColumn.HeaderText == "備考")
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            else if (gridCell.OwningColumn.HeaderText == "性別" || gridCell.OwningColumn.HeaderText == "コース")
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                        }
                    }
                    index++;
                }
                reader?.Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                sqlcon?.Close();
            }

            toolStripStatusLabel1.Text = string.Format("{0}件", index);
        }

        /// <summary>
        /// 園児緊急連絡先画面の設定とデータ取得
        /// </summary>
        private void SetupAndFillDataCase1()
        {
            int index = 0;
            string sqlcmd = string.Format(@"SELECT
	                                            b.名前,
	                                            a.*
                                            FROM
	                                            HL_JEC_園児緊急連絡先 a
                                            LEFT JOIN
	                                            HL_JEC_園児情報マスタ b
                                            ON a.園児コード= b.園児コード");

            DateGV.Rows.Clear();
            DateGV.Columns.Clear();

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return;
            }

            //カラム作成
            DateGV.Columns.Add("名前", "名前");
            DateGV.Columns.Add("園児コード", "園児コード");
            DateGV.Columns.Add("氏名_1", "氏名_1");
            DateGV.Columns.Add("続柄_1", "続柄_1");
            DateGV.Columns.Add("電話番号_1", "電話番号_1");
            DateGV.Columns.Add("勤務先名_1", "勤務先名_1");
            DateGV.Columns.Add("氏名_2", "氏名_2");
            DateGV.Columns.Add("続柄_2", "続柄_2");
            DateGV.Columns.Add("電話番号_2", "電話番号_2");
            DateGV.Columns.Add("勤務先名_2", "勤務先名_2");
            DateGV.Columns.Add("氏名_3", "氏名_3");
            DateGV.Columns.Add("続柄_3", "続柄_3");
            DateGV.Columns.Add("電話番号_3", "電話番号_3");
            DateGV.Columns.Add("勤務先名_3", "勤務先名_3");
            DateGV.Columns.Add("氏名_4", "氏名_4");
            DateGV.Columns.Add("続柄_4", "続柄_4");
            DateGV.Columns.Add("電話番号_4", "電話番号_4");
            DateGV.Columns.Add("勤務先名_4", "勤務先名_4");

            DateGV.ReadOnly = false;
            DateGV.Columns["名前"].ReadOnly = true;
            DateGV.Columns["園児コード"].Visible = false;
            
            //Set columns's length
            ((DataGridViewTextBoxColumn)DateGV.Columns["氏名_1"]).MaxInputLength = 50;
            ((DataGridViewTextBoxColumn)DateGV.Columns["続柄_1"]).MaxInputLength = 20;
            ((DataGridViewTextBoxColumn)DateGV.Columns["電話番号_1"]).MaxInputLength = 13;
            ((DataGridViewTextBoxColumn)DateGV.Columns["勤務先名_1"]).MaxInputLength = 100;
            ((DataGridViewTextBoxColumn)DateGV.Columns["氏名_2"]).MaxInputLength = 50;
            ((DataGridViewTextBoxColumn)DateGV.Columns["続柄_2"]).MaxInputLength = 20;
            ((DataGridViewTextBoxColumn)DateGV.Columns["電話番号_2"]).MaxInputLength = 13;
            ((DataGridViewTextBoxColumn)DateGV.Columns["勤務先名_2"]).MaxInputLength = 100;
            ((DataGridViewTextBoxColumn)DateGV.Columns["氏名_3"]).MaxInputLength = 50;
            ((DataGridViewTextBoxColumn)DateGV.Columns["続柄_3"]).MaxInputLength = 20;
            ((DataGridViewTextBoxColumn)DateGV.Columns["電話番号_3"]).MaxInputLength = 13;
            ((DataGridViewTextBoxColumn)DateGV.Columns["勤務先名_3"]).MaxInputLength = 100;
            ((DataGridViewTextBoxColumn)DateGV.Columns["氏名_4"]).MaxInputLength = 50;
            ((DataGridViewTextBoxColumn)DateGV.Columns["続柄_4"]).MaxInputLength = 20;
            ((DataGridViewTextBoxColumn)DateGV.Columns["電話番号_4"]).MaxInputLength = 13;
            ((DataGridViewTextBoxColumn)DateGV.Columns["勤務先名_4"]).MaxInputLength = 100;

            try
            {
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    if (
                        (reader["名前"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["園児コード"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["氏名_1"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["続柄_1"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["電話番号_1"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["勤務先名_1"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["氏名_2"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["続柄_2"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["電話番号_2"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["勤務先名_2"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["氏名_3"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["続柄_3"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["電話番号_3"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["勤務先名_3"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["氏名_4"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["続柄_4"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["電話番号_4"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["勤務先名_4"].ToString().IndexOf(txt_search.Text) < 0))
                    {
                        continue;
                    }

                    //Rowにデータ入れ
                    DateGV.Rows.Add();
                    DateGV.Rows[index].Cells["名前"].Value = string.IsNullOrWhiteSpace(reader["名前"].ToString()) ? "-" : reader["名前"].ToString();
                    DateGV.Rows[index].Cells["園児コード"].Value = string.IsNullOrWhiteSpace(reader["園児コード"].ToString()) ? "-" : reader["園児コード"].ToString();
                    DateGV.Rows[index].Cells["氏名_1"].Value = string.IsNullOrWhiteSpace(reader["氏名_1"].ToString()) ? "-" : reader["氏名_1"].ToString();
                    DateGV.Rows[index].Cells["続柄_1"].Value = string.IsNullOrWhiteSpace(reader["続柄_1"].ToString()) ? "-" : reader["続柄_1"].ToString();
                    DateGV.Rows[index].Cells["電話番号_1"].Value = string.IsNullOrWhiteSpace(reader["電話番号_1"].ToString()) ? "-" : reader["電話番号_1"].ToString();
                    DateGV.Rows[index].Cells["勤務先名_1"].Value = string.IsNullOrWhiteSpace(reader["勤務先名_1"].ToString()) ? "-" : reader["勤務先名_1"].ToString();
                    DateGV.Rows[index].Cells["氏名_2"].Value = string.IsNullOrWhiteSpace(reader["氏名_2"].ToString()) ? "-" : reader["氏名_2"].ToString();
                    DateGV.Rows[index].Cells["続柄_2"].Value = string.IsNullOrWhiteSpace(reader["続柄_2"].ToString()) ? "-" : reader["続柄_2"].ToString();
                    DateGV.Rows[index].Cells["電話番号_2"].Value = string.IsNullOrWhiteSpace(reader["電話番号_2"].ToString()) ? "-" : reader["電話番号_2"].ToString();
                    DateGV.Rows[index].Cells["勤務先名_2"].Value = string.IsNullOrWhiteSpace(reader["勤務先名_2"].ToString()) ? "-" : reader["勤務先名_2"].ToString();
                    DateGV.Rows[index].Cells["氏名_3"].Value = string.IsNullOrWhiteSpace(reader["氏名_3"].ToString()) ? "-" : reader["氏名_3"].ToString();
                    DateGV.Rows[index].Cells["続柄_3"].Value = string.IsNullOrWhiteSpace(reader["続柄_3"].ToString()) ? "-" : reader["続柄_3"].ToString();
                    DateGV.Rows[index].Cells["電話番号_3"].Value = string.IsNullOrWhiteSpace(reader["電話番号_3"].ToString()) ? "-" : reader["電話番号_3"].ToString();
                    DateGV.Rows[index].Cells["勤務先名_3"].Value = string.IsNullOrWhiteSpace(reader["勤務先名_3"].ToString()) ? "-" : reader["勤務先名_3"].ToString();
                    DateGV.Rows[index].Cells["氏名_4"].Value = string.IsNullOrWhiteSpace(reader["氏名_4"].ToString()) ? "-" : reader["氏名_4"].ToString();
                    DateGV.Rows[index].Cells["続柄_4"].Value = string.IsNullOrWhiteSpace(reader["続柄_4"].ToString()) ? "-" : reader["続柄_4"].ToString();
                    DateGV.Rows[index].Cells["電話番号_4"].Value = string.IsNullOrWhiteSpace(reader["電話番号_4"].ToString()) ? "-" : reader["電話番号_4"].ToString();
                    DateGV.Rows[index].Cells["勤務先名_4"].Value = string.IsNullOrWhiteSpace(reader["勤務先名_4"].ToString()) ? "-" : reader["勤務先名_4"].ToString();

                    foreach (DataGridViewCell gridCell in DateGV.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() != "-")
                        {
                            if (gridCell.OwningColumn.HeaderText == "電話番号_1" ||
                                gridCell.OwningColumn.HeaderText == "電話番号_2" ||
                                gridCell.OwningColumn.HeaderText == "電話番号_3" ||
                                gridCell.OwningColumn.HeaderText == "電話番号_4")
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                            else
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                    }
                    index++;
                }
                reader?.Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                sqlcon?.Close();
            }

            toolStripStatusLabel1.Text = string.Format("{0}件", index);
        }

        /// <summary>
        /// 園児健康情報画面の設定とデータ取得
        /// </summary>
        private void SetupAndFillDataCase2()
        {
            int index = 0;
            string sqlcmd = string.Format(@"SELECT
	                                            b.名前,
	                                            a.*
                                            FROM
	                                            HL_JEC_園児健康情報 a
                                            LEFT JOIN
	                                            HL_JEC_園児情報マスタ b
                                            ON a.園児コード= b.園児コード");

            DateGV.Rows.Clear();
            DateGV.Columns.Clear();

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return;
            }

            DataGridViewComboBoxColumn cmb_ひきつけ = new DataGridViewComboBoxColumn
            {
                HeaderText = "ひきつけ",
                Name = "ひきつけ"
            };
            cmb_ひきつけ.Items.Add("有");
            cmb_ひきつけ.Items.Add("無");

            DataGridViewComboBoxColumn cmb_呼吸心疾患 = new DataGridViewComboBoxColumn
            {
                HeaderText = "呼吸心疾患",
                Name = "呼吸心疾患"
            };
            cmb_呼吸心疾患.Items.Add("有");
            cmb_呼吸心疾患.Items.Add("無");

            DataGridViewComboBoxColumn cmb_食物アレルギー = new DataGridViewComboBoxColumn
            {
                HeaderText = "食物アレルギー",
                Name = "食物アレルギー"
            };
            cmb_食物アレルギー.Items.Add("有");
            cmb_食物アレルギー.Items.Add("無");

            //カラム作成
            DateGV.Columns.Add("名前", "名前");
            DateGV.Columns.Add("園児コード", "園児コード");
            DateGV.Columns.Add("平熱", "平熱");
            DateGV.Columns.Add(cmb_ひきつけ);
            DateGV.Columns.Add(cmb_呼吸心疾患);
            DateGV.Columns.Add(cmb_食物アレルギー);
            DateGV.Columns.Add("その他アレルギー", "その他アレルギー");
            DateGV.Columns.Add("既往症", "既往症");
            DateGV.Columns.Add("詳細", "詳細");

            DateGV.ReadOnly = false;
            DateGV.Columns["園児コード"].Visible = false;
            DateGV.Columns["名前"].ReadOnly = true;

            //Set columns'length
            ((DataGridViewTextBoxColumn)DateGV.Columns["平熱"]).MaxInputLength = 4;
            ((DataGridViewTextBoxColumn)DateGV.Columns["詳細"]).MaxInputLength = 500;

            try
            {
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["名前"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["園児コード"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["平熱"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["ひきつけ"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["呼吸心疾患"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["食物アレルギー"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["その他アレルギー"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["既往症"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["詳細"].ToString().IndexOf(txt_search.Text) < 0))
                    {
                        continue;
                    }

                    //Rowにデータ入れ
                    DateGV.Rows.Add();
                    DateGV.Rows[index].Cells["名前"].Value = string.IsNullOrWhiteSpace(reader["名前"].ToString()) ? "-" : reader["名前"].ToString();
                    DateGV.Rows[index].Cells["園児コード"].Value = string.IsNullOrWhiteSpace(reader["園児コード"].ToString()) ? "-" : reader["園児コード"].ToString();
                    DateGV.Rows[index].Cells["平熱"].Value = string.IsNullOrWhiteSpace(reader["平熱"].ToString()) ? "-" : reader["平熱"].ToString();
                    DateGV.Rows[index].Cells["ひきつけ"].Value = string.IsNullOrWhiteSpace(reader["ひきつけ"].ToString()) ? "-" : reader["ひきつけ"].ToString();
                    DateGV.Rows[index].Cells["呼吸心疾患"].Value = string.IsNullOrWhiteSpace(reader["呼吸心疾患"].ToString()) ? "-" : reader["呼吸心疾患"].ToString();
                    DateGV.Rows[index].Cells["食物アレルギー"].Value = string.IsNullOrWhiteSpace(reader["食物アレルギー"].ToString()) ? "-" : reader["食物アレルギー"].ToString();
                    DateGV.Rows[index].Cells["その他アレルギー"].Value = string.IsNullOrWhiteSpace(reader["その他アレルギー"].ToString()) ? "-" : reader["その他アレルギー"].ToString();
                    DateGV.Rows[index].Cells["既往症"].Value = string.IsNullOrWhiteSpace(reader["既往症"].ToString()) ? "-" : reader["既往症"].ToString();
                    DateGV.Rows[index].Cells["詳細"].Value = string.IsNullOrWhiteSpace(reader["詳細"].ToString()) ? "-" : reader["詳細"].ToString();

                    foreach (DataGridViewCell gridCell in DateGV.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() != "-")
                        {
                            if (gridCell.OwningColumn.HeaderText == "平熱")
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                            else
                            {
                                DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                    }
                    index++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                sqlcon?.Close();
            }

            toolStripStatusLabel1.Text = string.Format("{0}件", index);
        }

        /// <summary>
        /// 園児入園材料画面の設定とデータ取得
        /// </summary>
        private void SetupAndFillDataCase3()
        {
            int index = 0;
            string sqlcmd = string.Format(@"SELECT
	                                            a.園児コード,
	                                            b.名前,
	                                            a.母子手帳ファイル名,
	                                            a.健康保険ファイル名,
	                                            a.医療証ファイル名,
	                                            a.入園登録申込書ファイル名,
	                                            a.登園前健康診断ファイル名,
	                                            a.緊急連絡電話表ファイル名,
	                                            a.児童調査票ファイル名,
	                                            a.健康調査票ファイル名,
	                                            a.保育事業利用報告書ファイル名,
	                                            a.撮影契約書ファイル名,
	                                            a.個人情報取扱同意書ファイル名,
	                                            a.共済給付制度同意書ファイル名
                                            FROM
	                                            HL_JEC_園児入園材料 a
	                                        LEFT JOIN
		                                        HL_JEC_園児情報マスタ b
                                            ON  a.園児コード = b.園児コード");

            DateGV.Rows.Clear();
            DateGV.Columns.Clear();

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return;
            }

            //カラム作成
            DateGV.Columns.Add("園児コード", "園児コード");
            DateGV.Columns.Add("名前", "名前");
            DateGV.Columns.Add("入園登録申込書ファイル名", "入園登録申込書");
            DateGV.Columns.Add("母子手帳ファイル名", "母子手帳");
            DateGV.Columns.Add("健康保険ファイル名", "健康保険");
            DateGV.Columns.Add("医療証ファイル名", "医療証");
            DateGV.Columns.Add("登園前健康診断ファイル名", "登園前健康診断");
            DateGV.Columns.Add("緊急連絡電話表ファイル名", "緊急連絡電話表");
            DateGV.Columns.Add("児童調査票ファイル名", "児童調査票");
            DateGV.Columns.Add("健康調査票ファイル名", "健康調査票");
            DateGV.Columns.Add("保育事業利用報告書ファイル名", "保育事業利用報告書");
            DateGV.Columns.Add("撮影契約書ファイル名", "撮影契約書");
            DateGV.Columns.Add("個人情報取扱同意書ファイル名", "個人情報取扱同意書");
            DateGV.Columns.Add("共済給付制度同意書ファイル名", "共済給付制度同意書");

            DateGV.Columns["園児コード"].Visible = false;
            DateGV.ReadOnly = true;

            try
            {
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["園児コード"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["名前"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["母子手帳ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["健康保険ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["医療証ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["入園登録申込書ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["登園前健康診断ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["緊急連絡電話表ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["児童調査票ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["健康調査票ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["保育事業利用報告書ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["撮影契約書ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["個人情報取扱同意書ファイル名"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["共済給付制度同意書ファイル名"].ToString().IndexOf(txt_search.Text) < 0))
                    {
                        continue;
                    }

                    //Rowにデータ入れ
                    DateGV.Rows.Add();
                    DateGV.Rows[index].Cells["園児コード"].Value = string.IsNullOrWhiteSpace(reader["園児コード"].ToString()) ? "-" : reader["園児コード"].ToString();
                    DateGV.Rows[index].Cells["名前"].Value = string.IsNullOrWhiteSpace(reader["名前"].ToString()) ? "-" : reader["名前"].ToString();
                    DateGV.Rows[index].Cells["母子手帳ファイル名"].Value = string.IsNullOrWhiteSpace(reader["母子手帳ファイル名"].ToString()) ? "-" : reader["母子手帳ファイル名"].ToString();
                    DateGV.Rows[index].Cells["健康保険ファイル名"].Value = string.IsNullOrWhiteSpace(reader["健康保険ファイル名"].ToString()) ? "-" : reader["健康保険ファイル名"].ToString();
                    DateGV.Rows[index].Cells["医療証ファイル名"].Value = string.IsNullOrWhiteSpace(reader["医療証ファイル名"].ToString()) ? "-" : reader["医療証ファイル名"].ToString();
                    DateGV.Rows[index].Cells["入園登録申込書ファイル名"].Value = string.IsNullOrWhiteSpace(reader["入園登録申込書ファイル名"].ToString()) ? "-" : reader["入園登録申込書ファイル名"].ToString();
                    DateGV.Rows[index].Cells["登園前健康診断ファイル名"].Value = string.IsNullOrWhiteSpace(reader["登園前健康診断ファイル名"].ToString()) ? "-" : reader["登園前健康診断ファイル名"].ToString();
                    DateGV.Rows[index].Cells["緊急連絡電話表ファイル名"].Value = string.IsNullOrWhiteSpace(reader["緊急連絡電話表ファイル名"].ToString()) ? "-" : reader["緊急連絡電話表ファイル名"].ToString();
                    DateGV.Rows[index].Cells["児童調査票ファイル名"].Value = string.IsNullOrWhiteSpace(reader["児童調査票ファイル名"].ToString()) ? "-" : reader["児童調査票ファイル名"].ToString();
                    DateGV.Rows[index].Cells["健康調査票ファイル名"].Value = string.IsNullOrWhiteSpace(reader["健康調査票ファイル名"].ToString()) ? "-" : reader["健康調査票ファイル名"].ToString();
                    DateGV.Rows[index].Cells["保育事業利用報告書ファイル名"].Value = string.IsNullOrWhiteSpace(reader["保育事業利用報告書ファイル名"].ToString()) ? "-" : reader["保育事業利用報告書ファイル名"].ToString();
                    DateGV.Rows[index].Cells["撮影契約書ファイル名"].Value = string.IsNullOrWhiteSpace(reader["撮影契約書ファイル名"].ToString()) ? "-" : reader["撮影契約書ファイル名"].ToString();
                    DateGV.Rows[index].Cells["個人情報取扱同意書ファイル名"].Value = string.IsNullOrWhiteSpace(reader["個人情報取扱同意書ファイル名"].ToString()) ? "-" : reader["個人情報取扱同意書ファイル名"].ToString();
                    DateGV.Rows[index].Cells["共済給付制度同意書ファイル名"].Value = string.IsNullOrWhiteSpace(reader["共済給付制度同意書ファイル名"].ToString()) ? "-" : reader["共済給付制度同意書ファイル名"].ToString();

                    foreach (DataGridViewCell gridCell in DateGV.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() != "-")
                        {
                            DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                    index++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                sqlcon?.Close();
            }

            toolStripStatusLabel1.Text = string.Format("{0}件", index);
        }

        /// <summary>
        /// 園児退園書類画面の設定とデータ取得
        /// </summary>
        private void SetupAndFillDataCase4()
        {
            int index = 0;
            string sqlcmd = string.Format(@"SELECT 
                                                    a.園児コード,b.名前, a.退園日, a.退園事由, a.保育事業利用終了ファイル名, a.備考
                                                FROM 
                                                    HL_JEC_園児退園情報 a
	                                                inner join
	                                                HL_JEC_園児情報マスタ b
                                                ON a.園児コード= b.園児コード");

            DateGV.Rows.Clear();
            DateGV.Columns.Clear();

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return;
            }

            //カラム作成
            DateGV.Columns.Add("園児コード", "園児コード");
            DateGV.Columns.Add("名前", "名前");
            DateGV.Columns.Add("退園日", "退園日");
            DateGV.Columns.Add("退園事由", "退園事由");
            DateGV.Columns.Add("保育事業利用終了ファイル", "保育事業利用終了ファイル");
            DateGV.Columns.Add("備考", "備考");
            DateGV.ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["園児コード"]).ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["園児コード"]).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ((DataGridViewTextBoxColumn)DateGV.Columns["名前"]).ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["名前"]).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ((DataGridViewTextBoxColumn)DateGV.Columns["退園日"]).ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["退園日"]).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ((DataGridViewTextBoxColumn)DateGV.Columns["退園日"]).DefaultCellStyle.Format = "yyyy/MM/dd";

            ((DataGridViewTextBoxColumn)DateGV.Columns["退園事由"]).ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["退園事由"]).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((DataGridViewTextBoxColumn)DateGV.Columns["退園事由"]).MaxInputLength = 500;

            ((DataGridViewTextBoxColumn)DateGV.Columns["保育事業利用終了ファイル"]).ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["保育事業利用終了ファイル"]).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ((DataGridViewTextBoxColumn)DateGV.Columns["備考"]).ReadOnly = true;
            ((DataGridViewTextBoxColumn)DateGV.Columns["備考"]).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            try
            {
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    if ((reader["園児コード"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["名前"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["退園日"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["退園事由"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["備考"].ToString().IndexOf(txt_search.Text) < 0) &&
                        (reader["保育事業利用終了ファイル名"].ToString().IndexOf(txt_search.Text) < 0))
                    {
                        continue;
                    }

                    //Rowにデータ入れ
                    DateGV.Rows.Add();
                    DateGV.Rows[index].Cells["園児コード"].Value = string.IsNullOrWhiteSpace(reader["園児コード"].ToString()) ? "-" : reader["園児コード"].ToString();
                    DateGV.Rows[index].Cells["名前"].Value = string.IsNullOrWhiteSpace(reader["名前"].ToString()) ? "-" : reader["名前"].ToString();
                    DateGV.Rows[index].Cells["退園日"].Value = string.IsNullOrWhiteSpace(reader["退園日"].ToString()) ? "-" : Convert.ToDateTime(reader["退園日"]).ToString("yyyy/MM/dd");
                    DateGV.Rows[index].Cells["退園事由"].Value = string.IsNullOrWhiteSpace(reader["退園事由"].ToString()) ? "-" : reader["退園事由"].ToString();
                    DateGV.Rows[index].Cells["保育事業利用終了ファイル"].Value = string.IsNullOrWhiteSpace(reader["保育事業利用終了ファイル名"].ToString()) ? "-" : reader["保育事業利用終了ファイル名"].ToString();
                    DateGV.Rows[index].Cells["備考"].Value = string.IsNullOrWhiteSpace(reader["備考"].ToString()) ? "-" : reader["備考"].ToString();

                    foreach (DataGridViewCell gridCell in DateGV.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() != "-")
                        {
                            DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        if (gridCell.OwningColumn.Name != "保育事業利用終了ファイル")
                        {
                            DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.BackColor = Color.White;
                            DateGV.Rows[index].Cells[gridCell.ColumnIndex].Style.ForeColor = Color.Black;
                        }
                    }


                    index++;
                
                }
                reader?.Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "検索処理に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                sqlcon?.Close();
            }

            toolStripStatusLabel1.Text = string.Format("{0}件", index);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dvg = sender as DataGridView;

            if (e.Control.GetType().Equals(typeof(DataGridViewComboBoxEditingControl)))
            {
                //CellがCombo boxの場合
                DataGridViewComboBoxEditingControl editingControl = e.Control as DataGridViewComboBoxEditingControl;
                editingControl.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;

                    cb.DrawMode = DrawMode.OwnerDrawFixed;
                    cb.DrawItem -= this.cb_DrawItem;
                    cb.DrawItem += this.cb_DrawItem;
                }
            }
        }

        /// <summary>
        /// DVGのCMBセル変更イベント処理
        /// </summary>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs args)
        {
            Editing = false;

            ComboBox cmb = sender as ComboBox;
            cmb.Leave += new EventHandler(cmb_Leave);

            if (DateGV.CurrentCell.FormattedValue.ToString() != DateGV.CurrentCell.EditedFormattedValue.ToString())
            {
                string code_園児 = DateGV.CurrentRow.Cells["園児コード"].Value.ToString();
                string name_園児 = DateGV.CurrentRow.Cells["名前"].Value.ToString();
                string columnName = DateGV.CurrentCell.OwningColumn.HeaderText;
                string cellValue = DateGV.CurrentCell.EditedFormattedValue.ToString();

                Update_GridView(CmbSelected画面, code_園児, columnName, cellValue, name_園児);
            }
        }

        /// <summary>
        /// コンボックスを離れるときにイベントを削除する
        /// </summary>
        private void cmb_Leave(object sender, EventArgs args)
        {
            ComboBox cmb = sender as ComboBox;
            cmb.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        }

        /// <summary>
        /// DGVのセルにDoubleClick処理
        /// 園児情報一覧画面、園児緊急連絡先、園児健康情報の全セルと園児入園材料の園児名前のセルのみの場合はセル編集
        /// 園児入園材料画面の園児名前以外はファイルがある場合PDFファイルとしてPreviewする
        /// </summary>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripStatusLabel2.Text = string.Empty;
            string HeaderText = DateGV.CurrentCell.OwningColumn.HeaderText;
            string code園児 = DateGV.CurrentRow.Cells["園児コード"].Value.ToString();
            string name園児 = DateGV.CurrentRow.Cells["名前"].Value.ToString();
            string tempdir = @"C:\Windows\Temp\";

            switch (CmbSelected画面)
            {
                case 0:
                    BeforeValue = DateGV.CurrentCell.Value.ToString();
                    Editing = true;
                    break;
                case 1:
                case 2:
                    if (HeaderText == "名前")
                    {
                        return;
                    }
                    BeforeValue = DateGV.CurrentCell.Value.ToString();
                    Editing = true;
                    break;
                case 3:
                case 4:
                    if ((CmbSelected画面 == 3 && HeaderText == "名前") ||
                        (CmbSelected画面 ==4 && HeaderText != "保育事業利用終了ファイル"))
                    {
                        return;
                    }
                    if (DateGV.CurrentCell.Value.ToString() == "-" || string.IsNullOrWhiteSpace(DateGV.CurrentCell.Value.ToString()))
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = string.Format("[{0}]の添付ファイルがありません。", HeaderText);
                        return;
                    }

                    string UploadFileName = DateGV.CurrentCell.Value.ToString();
                    string renameFile = tempdir + Path.GetFileNameWithoutExtension(UploadFileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                    string sqlcmd = CmbSelected画面 == 3 ? string.Format(@"SELECT {1} FROM HL_JEC_園児入園材料 WHERE 園児コード = {0}", code園児, HeaderText + "ファイル")
                                                         : string.Format(@"SELECT 
                                                                             保育事業利用終了ファイル
                                                                            FROM 
                                                                             HL_JEC_園児退園情報
                                                                            WHERE
                                                                             園児コード = '{0}'", code園児);

                    try
                    {
                        System.Data.DataTable tablegetdata = GetDatatable(sqlcmd);
                        byte[] UploadFileData = (byte[])tablegetdata.Rows[0][0];
                        
                        switch (Path.GetExtension(UploadFileName.Trim()).ToLower())
                        {
                            case ".jpg":
                            case ".jpeg":
                            case ".png":
                                File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                                ConvertJPEGToPDF(tempdir + UploadFileName, renameFile);
                                ComClass.PDF表示(renameFile, Properties.Resources.人事);
                                break;
                            case ".xlsx":
                            case ".xls":
                            case ".xlw":
                            case ".xml":
                                File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                                ConvertExcelToPDF(tempdir + UploadFileName, renameFile);
                                ComClass.PDF表示(renameFile, Properties.Resources.人事);
                                break;
                            case ".doc":
                            case ".docx":
                                File.WriteAllBytes(tempdir + UploadFileName, UploadFileData);
                                toolStripStatusLabel2.ForeColor = Color.Green;
                                toolStripStatusLabel2.Text = "Wordファイル出力中…";

                                ConvertWordToPDF(tempdir + UploadFileName, renameFile);

                                toolStripStatusLabel2.ForeColor = Color.Black;
                                toolStripStatusLabel2.Text = string.Empty;
                                ComClass.PDF表示(renameFile, Properties.Resources.人事);
                                break;
                            case ".pdf":
                                File.WriteAllBytes(renameFile, UploadFileData);
                                ComClass.PDF表示(renameFile, Properties.Resources.人事);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = ex.ToString() + string.Format("園児名前[{0}]ー[{1}]のファイル呼び込みに失敗しました。", name園児, UploadFileName);
                    }
                    finally
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        KillFile(tempdir, UploadFileName);
                    }
                    break;
            }
        }

        /// <summary>
        /// セルの編集終了時の処理
        /// </summary>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Editing = false;
        }

        /// <summary>
        /// 1セルのみ選択の処理
        /// </summary>
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CmbSelected画面 == 3 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (DateGV.Rows[e.RowIndex].Selected == false)
                    {
                        DateGV.ClearSelection();
                        DateGV.Rows[e.RowIndex].Selected = true;
                    }
                    if (DateGV.SelectedRows.Count == 1)
                    {
                        DateGV.CurrentCell = DateGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                }
            }
        }

        /// <summary>
        /// セルにクリックする時の処理
        /// </summary>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                DateGV.CurrentCell = clickedCell;
                columnName = clickedCell.OwningColumn.HeaderText;
                Selected_園児コード = DateGV.CurrentRow.Cells["園児コード"].Value.ToString();

                var relativeMousePosition = DateGV.PointToClient(Cursor.Position);
                if (CmbSelected画面 == 3 && e.ColumnIndex > 1)
                {
                    contextMenuStrip1.Show(DateGV, relativeMousePosition);
                }
                else if (CmbSelected画面 == 4)
                {
                    contextMenuStrip2.Show(DateGV, relativeMousePosition);
                }
                else if (CmbSelected画面 == 0)
                {
                    contextMenuStrip3.Show(DateGV, relativeMousePosition);
                }
            }
        }

        /// <summary>
        /// セルの値が変わる時の処理
        /// 園児情報一覧画面、園児緊急連絡先、園児健康情報の全セルと園児入園材料の園児名前のセルのみ　編集可
        /// 園児入園材料の園児名前のセル以外は　直接編集不可
        /// </summary>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Editing)
            {
                return;
            }
            else
            {
                if (BeforeValue == "-" && string.IsNullOrWhiteSpace(DateGV.CurrentCell.EditedFormattedValue.ToString()))
                {
                    DateGV.CurrentCell.Value = BeforeValue;
                    DateGV.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }

                if (DateGV.CurrentCell.EditedFormattedValue.ToString() != BeforeValue)
                {
                    DataGridViewRow row_editing = DateGV.CurrentRow;
                    if (row_editing != null)
                    {
                        string code_園児 = DateGV.CurrentRow.Cells["園児コード"].Value.ToString();
                        string ColumnName = DateGV.CurrentCell.OwningColumn.HeaderText;
                        string cellvalue = DateGV.CurrentCell.EditedFormattedValue.ToString();
                        string name = ColumnName == "名前" ? BeforeValue : DateGV.CurrentRow.Cells["名前"].Value.ToString();

                        Update_GridView(CmbSelected画面, code_園児, ColumnName, cellvalue, name);
                    }
                }
            }
        }

        private bool Update_GridView(int Selected_画面, string code_園児, string ColumnName, string CellValue, string name)
        {
            bool IsUpdateing = false;
            string TableName = string.Empty;
            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return IsUpdateing;
            }

            if (Selected_画面 == 0 && ColumnName == "コース")
            {
                CellValue = CellValue.Substring(0, CellValue.IndexOf("　"));
            }

            switch (Selected_画面)
            {
                case 0:
                    TableName = "HL_JEC_園児情報マスタ";
                    break;
                case 1:
                    TableName = "HL_JEC_園児緊急連絡先";
                    break;
                case 2:
                    TableName = "HL_JEC_園児健康情報";
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            if (!CheckInput(sqlcon, TableName, code_園児, name, ColumnName, CellValue))
            {
                DisplayGridView(CmbSelected画面);
                return IsUpdateing;
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            try
            {
                string sqlcmd = (string.IsNullOrWhiteSpace(CellValue)) ?
                                 string.Format(@"UPDATE {0} SET {1} = NULL WHERE 園児コード = '{2}'", TableName, ColumnName, code_園児) :
                                 string.Format(@"UPDATE {0} SET {1} = '{2}' WHERE 園児コード = '{3}'", TableName, ColumnName, CellValue, code_園児);

                sqlcom.CommandText = sqlcmd;
                int result = sqlcom.ExecuteNonQuery();

                if (result == 1)
                {
                    if (ColumnName == "退園日")
                    {
                        sqlcom.CommandText = string.Format(@"UPDATE HL_JEC_園児退園情報 SET 退園日 = '{0}' WHERE 園児コード = '{1}'", CellValue, code_園児);
                        int result2 = sqlcom.ExecuteNonQuery();
                        if (result2 == 1)
                        {
                            transaction.Commit();
                            toolStripStatusLabel2.ForeColor = Color.Green;
                            toolStripStatusLabel2.Text = (ColumnName == "名前") ?
                                                          string.Format("[{0} {1}] さんの情報が正常に更新しました。", code_園児, name) :
                                                          string.Format("[{0} {1}] さんの情報が正常に更新しました。", code_園児, name);
                        }
                    }
                    else
                    {
                        transaction.Commit();

                        toolStripStatusLabel2.ForeColor = Color.Green;
                        toolStripStatusLabel2.Text = (ColumnName == "名前") ?
                                                      string.Format("[{0} {1}] さんの情報が正常に更新しました。", code_園児, name) :
                                                      string.Format("[{0} {1}] さんの情報が正常に更新しました。", code_園児, name);

                    }
                    IsUpdateing = true;
                    if (((Form1)(this.Tag)).m_園児情報一覧Handle != null)
                    {
                        SendMessage(((Form1)(this.Tag)).m_園児情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                    }
                }
            }
            catch
            {
                transaction.Rollback();
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}] さんの更新処理が失敗しました。", name);
                DisplayGridView(CmbSelected画面);
                return IsUpdateing;
            }
            finally
            {
                sqlcon?.Close();
            }
            return IsUpdateing;
        }

        #endregion

        #region ボタン処理
        private void btn_search_Click(object sender, EventArgs e)
        {
            ((Form1)(Tag)).toolStripStatusLabel2.Text = string.Empty;
            toolStripStatusLabel2.Text = string.Empty;

            DisplayGridView(CmbSelected画面);
        }

        #endregion

        #region ContextMenu

        /// <summary>
        /// 園児入園材料画面のメニューが開いてる時の処理
        /// </summary>
        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //メニューの箇所設定
            System.Drawing.Point startPosition = Cursor.Position;

            System.Drawing.Point point = DateGV.PointToClient(startPosition);
            DataGridView.HitTestInfo hitinfo;
            hitinfo = DateGV.HitTest(point.X, point.Y);

            DateGV.ClearSelection();
            if (hitinfo.RowIndex >= 0)
            {
                DateGV.Rows[hitinfo.RowIndex].Cells[hitinfo.ColumnIndex].Selected = true;
            }
            else
            {
                e.Cancel = true;
            }
        }


        /// <summary>
        /// 指定ファイルを印刷する処理
        /// </summary>
        private void 印刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string HeaderText = DateGV.CurrentCell.OwningColumn.HeaderText;
            string name園児 = DateGV.CurrentRow.Cells["名前"].Value.ToString();
            string tmpdir = @"C:\Windows\Temp\";
            string PrintFileName = DateGV.CurrentCell.Value.ToString();

            if (PrintFileName == "-" || string.IsNullOrWhiteSpace(PrintFileName))
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}]の印刷ファイルが見つかりません。", HeaderText);
                return;
            }

            string PrintFileType = PrintFileName.ToLower().Substring(PrintFileName.LastIndexOf("."));
            string rename = tmpdir + PrintFileName.Substring(0, PrintFileName.LastIndexOf(".")) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            
            toolStripStatusLabel2.ForeColor = Color.Black;
            toolStripStatusLabel2.Text = string.Format("[{0}]の{1}が印刷中...", HeaderText, PrintFileName);

            string sqlcmd = string.Format(@"Select {0}ファイル from HL_JEC_園児入園材料 where 園児コード = '{1}'", HeaderText, Selected_園児コード);

            System.Data.DataTable getdatatable = GetDatatable(sqlcmd);

            if (string.IsNullOrWhiteSpace(getdatatable.Rows[0][HeaderText + "ファイル"].ToString()))
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}]のファイルがありません。", HeaderText);
                isPrintOK = false;
                return;
            }

            byte[] PrintFileData = (byte[])getdatatable.Rows[0][HeaderText + "ファイル"];
            File.WriteAllBytes(tmpdir + PrintFileName, PrintFileData);

            if (!tmpdir.Trim().Equals(""))
            {
                try
                {
                    if (".doc, .docx".Contains(PrintFileType))
                    {
                        ConvertWordToPDF(tmpdir + PrintFileName, rename);
                    }
                    else if (".jpg, .jpeg, .png".Contains(PrintFileType))
                    {
                        ConvertJPEGToPDF(tmpdir + PrintFileName, rename);
                    }
                    else if (".xlsx, .xls, .xlw, .xml".Contains(PrintFileType))
                    {
                        ConvertExcelToPDF(tmpdir + PrintFileName, rename);
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
                        if (Dialog.ShowDialog() == DialogResult.OK)
                        {
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
                            isPrintOK = true;
                        }
                        else
                        {
                            toolStripStatusLabel2.ForeColor = Color.Red;
                            toolStripStatusLabel2.Text = string.Format("[{0}] の{1}の印刷がキャンセルされました。", HeaderText, PrintFileName);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = ex.Message;
                }
                finally
                {
                    KillFile(tmpdir, PrintFileName);
                }
            }
            if (isPrintOK)
            {
                toolStripStatusLabel2.ForeColor = Color.Green;
                toolStripStatusLabel2.Text = string.Format("園児名前：[{0}]－[{1}]の {2} の印刷が完了しました。", name園児, HeaderText, PrintFileName);
            }
        }

        /// <summary>
        /// ファイルをアップロードする処理
        /// </summary>
        private void アップロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            byte[] UploadFileData = null;
            string UploadFileName = string.Empty;
            string code園児 = DateGV.CurrentRow.Cells["園児コード"].Value.ToString();
            string name園児 = DateGV.CurrentRow.Cells["名前"].Value.ToString();
            string Filename = CmbSelected画面 == 3 ? DateGV.CurrentCell.Value.ToString() : DateGV.CurrentRow.Cells["保育事業利用終了ファイル"].Value.ToString();

            if (DateGV.CurrentCell.Value.ToString() != "-")
            {
                string mess = string.Format("宛先には既に”{0}”という名前のファイルが保存します。ファイルを置き換えますか？", Filename);
                DialogResult res = MessageBox.Show(mess, "ファイルの置換またはスキップ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "すべてファイル|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UploadFileData = File.ReadAllBytes(openFileDialog.FileName);
                UploadFileName = Path.GetFileName(openFileDialog.FileName);
            }
            else
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "アップロードがキャンセルされました。";
                return;
            }

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                return;
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            if (CmbSelected画面 == 3)
            {
                sqlcom.CommandText = string.Format(@"UPDATE
                                                     HL_JEC_園児入園材料
                                                 SET
                                                     {0}ファイル名 = N'{1}',
                                                     {0}ファイル = @UploadFileData
                                                 WHERE
                                                     園児コード = '{2}'", columnName, UploadFileName, Selected_園児コード);

                sqlcom.Parameters.AddWithValue("@UploadFileData", UploadFileData);
            }
            else if (CmbSelected画面 == 4)
            {
                sqlcom.CommandText = string.Format(@"UPDATE HL_JEC_園児退園情報
                                                       SET 保育事業利用終了ファイル名 = @保育事業利用終了ファイル名,
                                                           保育事業利用終了ファイル = @保育事業利用終了ファイル
                                                    WHERE 園児コード = @園児コード");
                sqlcom.Parameters.AddWithValue("保育事業利用終了ファイル名", UploadFileName);
                sqlcom.Parameters.AddWithValue("保育事業利用終了ファイル", UploadFileData);
                sqlcom.Parameters.AddWithValue("園児コード", Selected_園児コード);
            }

            try
            {

                int result = sqlcom.ExecuteNonQuery();

                if (result == 1)
                {
                    transaction.Commit();
                    toolStripStatusLabel2.ForeColor = Color.Green;
                    toolStripStatusLabel2.Text = string.Format("【{0}　{1}】さんの [ {2} ]ファイルをアップロードしました。", code園児 ,name園児, columnName);

                    if (((Form1)(this.Tag)).m_園児情報一覧Handle != null)
                    {
                        SendMessage(((Form1)(this.Tag)).m_園児情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                    }
                }
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("【{0}　{1}】さんの [ {2} ]ファイルをアップロード失敗しました。", code園児, name園児, columnName);
                DisplayGridView(CmbSelected画面);
            }
            finally
            {
                sqlcon?.Close();
            }
        }

        /// <summary>
        /// ファイルをダウロードする処理
        /// </summary>
        private void ダウンロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = DateGV.CurrentCell.Value.ToString();
            string HeaderText = DateGV.CurrentCell.OwningColumn.HeaderText;

            if (fileName?.Length == 0)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("添付ファイル [{0}] がありません。", fileName);
                return;
            }

            string sqlcmd = string.Format("SELECT {0}ファイル名, {0}ファイル FROM HL_JEC_園児入園材料 WHERE 園児コード = '{1}'", HeaderText, Selected_園児コード);
            System.Data.DataTable getdata = GetDatatable(sqlcmd);

            if (string.IsNullOrEmpty(getdata.Rows[0][HeaderText + "ファイル"].ToString()))
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}]の{1}という添付ファイルがありません。", HeaderText, fileName);
                return;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                byte[] fileData = (byte[])getdata.Rows[0][HeaderText + "ファイル"];
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
                        toolStripStatusLabel2.ForeColor = Color.Green;
                        toolStripStatusLabel2.Text = string.Format("添付ファイル [{0}] がダウンロードしました。", fileName);
                    }
                    else
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = string.Format("添付ファイル [{0}] のダウンロードがキャンセルされました。", fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = ex.Message;
            }
        }

        /// <summary>
        /// 園児情報一覧画面の退園メニューと園児退園書類画面の変更メニューが使う処理
        /// </summary>
        private void 変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            if (((Form1)(this.Tag)).m_園児退園Handle.iHandle != IntPtr.Zero)
            {
                BringWindowToTop(((Form1)(this.Tag)).m_園児退園Handle.iHandle);
                return;
            }
            園児退園 NewForm_園児退園 = new 園児退園();
            NewForm_園児退園.Tag = ((Form1)(Tag));
            NewForm_園児退園.code_園児 = Selected_園児コード.ToInt32();
            NewForm_園児退園.name_園児 = DateGV.CurrentRow.Cells["名前"].Value.ToString();
            NewForm_園児退園.date_退園日 = DateGV.CurrentRow.Cells["退園日"].Value.ToString();

            // 園児情報一覧画面の退園メニュー
            if (CmbSelected画面 == 0)
            {
                //退園日のカラムに値がない場合、退園の新規登録画面に移動する
                if (DateGV.CurrentRow.Cells["退園日"].Value.ToString() == "-")
                {
                    NewForm_園児退園.isUpdate = false;
                }
                //退園日のカラムに値がある場合、退園の変更画面に移動する
                else
                {
                    NewForm_園児退園.isUpdate = true;
                }
            }
            // 園児退園書類画面の変更メニュー
            else if (CmbSelected画面 == 4)
            {
                NewForm_園児退園.isUpdate = true;
            }
            NewForm_園児退園.Show();

            ((Form1)(this.Tag)).m_園児退園Handle.iHandle = NewForm_園児退園.Handle;
        }

        /// <summary>
        /// 園児退園書類画面の退園キャンセルメニュー
        /// </summary>
        private void 退園キャンセルToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            string code_園児 = DateGV.CurrentRow.Cells["園児コード"].Value.ToString();
            string name = DateGV.CurrentRow.Cells["名前"].Value.ToString();

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon?.Open();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました.";
                sqlcon.Close();
                return;
            }
            SqlTransaction transaction = sqlcon.BeginTransaction();

            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            try
            {
                sqlcom.CommandText = string.Format(@"DELETE FROM HL_JEC_園児退園情報
                                                    WHERE 園児コード = '{0}'", code_園児);
                int result1 = sqlcom.ExecuteNonQuery();
                if (result1 == 1)
                {
                    sqlcom.CommandText = string.Format(@"UPDATE [dbo].[HL_JEC_園児情報マスタ]
                                                           SET [退園日] = NULL
                                                        WHERE 園児コード ='{0}'", code_園児);
                    int result2 = sqlcom.ExecuteNonQuery();
                    if (result2 == 1)
                    {
                        transaction.Commit();
                        toolStripStatusLabel2.ForeColor = Color.Green;
                        toolStripStatusLabel2.Text = string.Format("[{0} {1}] さんの退園手続きが正常にキャンセルしました。", code_園児, name);

                        if (((Form1)(this.Tag)).m_園児情報一覧Handle != null)
                        {
                            SendMessage(((Form1)(this.Tag)).m_園児情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0} {1}] さんの退園手続きのキャンセル処理が失敗しました。", code_園児, name);
                DisplayGridView(CmbSelected画面);
            }
        }

        #endregion

        #region CMB処理

        /// <summary>
        /// 画面リストのCMBが変更時の処理
        /// </summary>
        private void cmb_gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0:園児情報一覧
            //1:園児緊急連絡先
            //2:園児健康情報
            //3:園児入園材料
            CmbSelected画面 = cmb_gridview.SelectedIndex;
            toolStripStatusLabel2.Text = string.Empty;

            Editing = false;
            DisplayGridView(CmbSelected画面);

            if (CmbSelected画面 != 3)
            {
                contextMenuStrip1.Visible = false;
            }
        }

        #endregion

        #region InputCheck

        /// <summary>
        /// 入力データチェック
        /// </summary>
        /// <returns>true/false</returns>
        private bool CheckInput(SqlConnection sqlcon, string TableName, string code_園児, string name_園児, string ColumnName, string CellValue)
        {
            string ErrMsg = string.Empty;
            string sqlcmd = string.Format(@"SELECT ISNULL((SELECT TOP(1) 1 FROM {1} WHERE 園児コード = {0}), 0)", code_園児, TableName);
            
            SqlCommand sqlcom = new SqlCommand(sqlcmd, sqlcon);

            try
            {
                int result = sqlcom.ExecuteScalar().ToInt32();
                if (result != 1)
                {
                    //園児コードが存在しない場合エラー
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = string.Format(@"園児名前 [{0}] が登録されていません.", name_園児);

                    sqlcon?.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "園児リストのチェック処理にエラーが発生しました。" + ex.Message;

                sqlcon?.Close();
                return false;
            }

            //園児情報一覧
            if (TableName == "HL_JEC_園児情報マスタ")
            {
                switch (ColumnName)
                {
                    case "名前":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "名前未入力です。";
                        }
                        else if (CellValue.IndexOf(" ") > 0)
                        {
                            ErrMsg = "名前に許可されない文字'半角SPACE' が入りました。";
                        }
                        else if (CellValue.IndexOf("　") == -1)
                        {
                            ErrMsg = "姓と名の間に '全角SPACE' を挿入してください!";
                        }
                        else if (CellValue.IndexOf("　") != CellValue.LastIndexOf("　"))
                        {
                            ErrMsg = "名前に '全角SPACE' は二つ以上入力しないでください!";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "名前に許可されない文字「,」が入りました。";
                        }

                        break;
                    case "フリガナ":
                        //カタカナ
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "カタカナ未入力です。";
                        }
                        else if (CellValue.IndexOf(" ") > 0)
                        {
                            ErrMsg = "カタカナに許可されない文字'半角SPACE' が入りました。";
                        }
                        else if (CellValue.IndexOf("　") == -1)
                        {
                            ErrMsg = "カタカナの姓と名の間に '全角SPACE' を挿入してください!";
                        }
                        else if (CellValue.IndexOf("　") != CellValue.LastIndexOf("　"))
                        {
                            ErrMsg = "カタカナに '全角SPACE' は二つ以上入力しないでください!";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "カタカナに許可されない文字「,」が入りました。";
                        }
                        else if (!ComClass.IsFullKatakana(CellValue.Replace("　", "")))
                        {
                            ErrMsg = "カタカナは全角カタカナでご入力ください！";
                        }
                        break;
                    case "生年月日":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "生年月日が未入力です。";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "生年月日に許可されない文字「,」が入りました。";
                        }
                        else
                        {
                            try
                            {
                                //日付形式チェック
                                DateTime.Parse(CellValue);
                                if (DateTime.Compare(Convert.ToDateTime(CellValue), DateTime.Now) >= 0)
                                {
                                    ErrMsg = "現在の日付より未来日を入力できません。もう一度確認してください。";
                                }
                            }
                            catch
                            {
                                ErrMsg = "生年月日に正しい日付の形式を入力してください。";
                            }
                        }
                        break;
                    case "電話番号":
                        //携帯
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "電話番号未入力です。";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "電話番号に許可されない文字「,」が入りました。";
                        }
                        else if (!ISTEL(CellValue))
                        {
                            ErrMsg = "電話番号のフォーマットが間違っています!";
                        }
                        break;
                    case "メール":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "メール未入力です。";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "メールに許可されない文字「,」が入りました。";
                        }
                        else if (!IsValidEmail(CellValue))
                        {
                            ErrMsg = "メールのフォーマットが間違っています!";
                        }
                        break;
                    case "郵便番号":
                        //郵便番号
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "郵便番号未入力です。";
                        }
                        else if (!Is郵便番号(CellValue))
                        {
                            ErrMsg = "郵便番号が間違っています!";
                        }
                        break;
                    case "住所":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "住所未入力です。";
                        }
                        break;
                    case "登園開始日":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "登園開始日未入力です。";
                        }
                        else
                        {
                            try
                            {
                                //日付形式チェック
                                DateTime.Parse(CellValue);
                                if (Convert.ToDateTime(CellValue) < Convert.ToDateTime(DateGV.CurrentRow.Cells["生年月日"].Value))
                                {
                                    ErrMsg = "登園開始日は園児の生年月日より過去日を入力できません。";
                                }
                            }
                            catch
                            {
                                ErrMsg = "登園開始日に正しい日付の形式を入力してください。";
                            }
                        }
                        break;
                    case "コース":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "コース未入力です。";
                        }
                        break;
                    case "退園日":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "";
                        }
                        else
                        {
                            try
                            {
                                //日付形式チェック
                                DateTime.Parse(CellValue);
                                if (Convert.ToDateTime(CellValue) < Convert.ToDateTime(DateGV.CurrentRow.Cells["生年月日"].Value))
                                {
                                    ErrMsg = "退園日は園児の生年月日より過去日を入力できません。";
                                }
                            }
                            catch
                            {
                                ErrMsg = "退園日に正しい日付の形式を入力してください。";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            //園児緊急連絡先
            if (TableName == "HL_JEC_園児緊急連絡先")
            {
                switch (ColumnName)
                {
                    case "氏名_1":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "氏名_1未入力です。";
                        }
                        else if (CellValue.IndexOf(" ") > 0)
                        {
                            ErrMsg = "氏名_1に許可されない文字'半角SPACE' が入りました。";
                        }
                        else if (CellValue.IndexOf("　") == -1)
                        {
                            ErrMsg = "姓と名の間に '全角SPACE' を挿入してください!";
                        }
                        else if (CellValue.IndexOf("　") != CellValue.LastIndexOf("　"))
                        {
                            ErrMsg = "氏名_1に '全角SPACE' は二つ以上入力しないでください!";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "氏名_1に許可されない文字「,」が入りました。";
                        }
                        break;
                    case "続柄_1":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "続柄_1未入力です。";
                        }
                        break;
                    case "電話番号_1":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "電話番号_1未入力です。";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "電話番号_1に許可されない文字「,」が入りました。";
                        }
                        else if (!ISTEL(CellValue))
                        {
                            ErrMsg = "電話番号_1のフォーマットが間違っています!";
                        }
                        break;
                    case "勤務先名_1":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "勤務先名_1未入力です。";
                        }
                        break;
                    case "氏名_2":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "氏名_2未入力です。";
                        }
                        else if (CellValue.IndexOf(" ") > 0)
                        {
                            ErrMsg = "氏名_2に許可されない文字'半角SPACE' が入りました。";
                        }
                        else if (CellValue.IndexOf("　") == -1)
                        {
                            ErrMsg = "姓と名の間に '全角SPACE' を挿入してください!";
                        }
                        else if (CellValue.IndexOf("　") != CellValue.LastIndexOf("　"))
                        {
                            ErrMsg = "氏名_2に '全角SPACE' は二つ以上入力しないでください!";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "氏名_2に許可されない文字「,」が入りました。";
                        }
                        break;
                    case "続柄_2":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "続柄_2未入力です。";
                        }
                        break;
                    case "電話番号_2":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "電話番号_2未入力です。";
                        }
                        else if (CellValue.IndexOf(",") > 0)
                        {
                            ErrMsg = "電話番号_2に許可されない文字「,」が入りました。";
                        }
                        else if (!ISTEL(CellValue))
                        {
                            ErrMsg = "電話番号_2のフォーマットが間違っています!";
                        }
                        break;
                    case "勤務先名_2":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "勤務先名_2未入力です。";
                        }
                        break;
                    case "氏名_3":
                        if (!string.IsNullOrWhiteSpace(CellValue))
                        {
                            if (CellValue.IndexOf(" ") > 0)
                            {
                                ErrMsg = "氏名_3に許可されない文字'半角SPACE' が入りました。";
                            }
                            else if (CellValue.IndexOf("　") == -1)
                            {
                                ErrMsg = "姓と名の間に '全角SPACE' を挿入してください!";
                            }
                            else if (CellValue.IndexOf("　") != CellValue.LastIndexOf("　"))
                            {
                                ErrMsg = "氏名_3に '全角SPACE' は二つ以上入力しないでください!";
                            }
                            else if (CellValue.IndexOf(",") > 0)
                            {
                                ErrMsg = "氏名_3に許可されない文字「,」が入りました。";
                            }
                        }
                        break;
                    case "電話番号_3":
                        if (!string.IsNullOrWhiteSpace(CellValue))
                        {
                            if (CellValue.IndexOf(",") > 0)
                            {
                                ErrMsg = "電話番号_3に許可されない文字「,」が入りました。";
                            }
                            else if (!ISTEL(CellValue))
                            {
                                ErrMsg = "電話番号_3のフォーマットが間違っています!";
                            }
                        }
                        break;
                    case "氏名_4":
                        if (!string.IsNullOrWhiteSpace(CellValue))
                        {
                            if (CellValue.IndexOf(" ") > 0)
                            {
                                ErrMsg = "氏名4に許可されない文字'半角SPACE' が入りました。";
                            }
                            else if (CellValue.IndexOf("　") == -1)
                            {
                                ErrMsg = "姓と名の間に '全角SPACE' を挿入してください!";
                            }
                            else if (CellValue.IndexOf("　") != CellValue.LastIndexOf("　"))
                            {
                                ErrMsg = "氏名_4に '全角SPACE' は二つ以上入力しないでください!";
                            }
                            else if (CellValue.IndexOf(",") > 0)
                            {
                                ErrMsg = "氏名_4に許可されない文字「,」が入りました。";
                            }
                        }
                        break;
                    case "電話番号_4":
                        if (!string.IsNullOrWhiteSpace(CellValue))
                        {
                            if (CellValue.IndexOf(",") > 0)
                            {
                                ErrMsg = "電話番号_4に許可されない文字「,」が入りました。";
                            }
                            else if (!ISTEL(CellValue))
                            {
                                ErrMsg = "電話番号_4のフォーマットが間違っています!";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            //園児健康情報
            if (TableName == "HL_JEC_園児健康情報")
            {
                switch (ColumnName)
                {
                    case "平熱":
                        if (string.IsNullOrWhiteSpace(CellValue))
                        {
                            ErrMsg = "平熱未入力です。";
                        }
                        else
                        {
                            if (!Is数字(CellValue))
                            {
                                ErrMsg = "平熱に数字のみを入力してください!";
                            }
                            else if (Convert.ToDecimal(CellValue) < 30 || Convert.ToDecimal(CellValue) > 40)
                            {
                                ErrMsg = "平熱を正しく入力してください!";
                            }
                        }
                        break;
                    case "詳細":
                        sqlcmd = string.Format(@"SELECT * FROM {1} WHERE 園児コード = {0}", code_園児, TableName);

                        sqlcom = new SqlCommand(sqlcmd, sqlcon);
                        SqlDataReader reader = sqlcom.ExecuteReader();

                        try
                        {
                            if (reader.Read())
                            {
                                if (reader["ひきつけ"].ToString().Equals("有") ||
                                    reader["呼吸心疾患"].ToString().Equals("有") ||
                                    reader["食物アレルギー"].ToString().Equals("有") ||
                                    reader["その他アレルギー"].ToString().Equals("有") ||
                                    reader["既往症"].ToString().Equals("有"))
                                {
                                    if (string.IsNullOrWhiteSpace(CellValue))
                                    {
                                        ErrMsg = "詳細未入力です。";
                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            toolStripStatusLabel2.ForeColor = Color.Red;
                            toolStripStatusLabel2.Text = "園児リストのチェック処理にエラーが発生しました。" + ex.Message;

                            sqlcon?.Close();
                            return false;
                        }
                        finally
                        {
                            reader?.Close();
                        }
                        break;
                    default:
                        break;
                }
            }
            
            if (ErrMsg != string.Empty)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}]さんの情報変更が失敗しました。", name_園児) + ErrMsg;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 数字かどうかをチェック
        /// </summary>
        private bool Is数字(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{1,7}(?:\.\d{0,2}$|$)");
        }

        /// <summary>
        ///携帯番号チェック
        /// </summary>
        private bool ISTEL(string str_url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url, @"\A0\d{1,4}-\d{1,4}-\d{4}\z");
        }

        /// <summary>
        ///メールチェック
        /// </summary>
        private bool IsValidEmail(string strIn)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" + @"|(([\w-]+\.)+))([a-zA-Z]{2,5}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        ///郵便番号チェック
        /// </summary>
        private bool Is郵便番号(string strIn)
        {
            if (strIn.Substring(0, 1) == "〒")
            {
                strIn = strIn.Substring(1, strIn.Length - 1);
            }
            return System.Text.RegularExpressions.Regex.IsMatch(strIn, "^[0-9]{3}[-]?[0-9]{4}$");
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
                workBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, rename2PDF, Excel.XlFixedFormatQuality.xlQualityMinimum,
                                             true, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = ex.Message;
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

            try
            {
                application = new Word.Application();
                document = application.Documents.Open(wordfile);
                document.ExportAsFixedFormat(rename2PDF, WdExportFormat.wdExportFormatPDF, false, 
                                             WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument,
                                             0, 0, WdExportItem.wdExportDocumentContent, true, true, WdExportCreateBookmarks.wdExportCreateHeadingBookmarks,
                                             true, true, false, Type.Missing);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = ex.Message;
            }
            finally
            {
                if (document != null)
                {
                    document.Close(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdOriginalDocumentFormat, false);
                    document = null;
                }
                if (application != null)
                {
                    application.Quit(WdSaveOptions.wdDoNotSaveChanges, Type.Missing, Type.Missing);
                    application = null;
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

        /// <summary>
        /// CMBを再び手作りに描く
        /// </summary>
        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            // Non-sourced vs sourced examples.
            string value = cb.Items[e.Index].ToString();
            if (e.Index >= 0)
            {
                using (Brush forebrush = new SolidBrush(cb.ForeColor))
                using (Brush backbrush = new SolidBrush(cb.BackColor))
                {
                    e.Graphics.FillRectangle(backbrush, e.Bounds);
                    e.DrawBackground();
                    e.DrawFocusRectangle();
                    e.Graphics.DrawString(value, e.Font, forebrush, e.Bounds);
                }
            }
        }



        #endregion

    }
}
