using ComDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public partial class 園児健康診断登録 : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public 園児健康診断登録()
        {
            InitializeComponent();
        }
        public string time { get; set; }
        public string code { get; set; }
        string 園児名 = string.Empty;
        private string connectionString = ComClass.connectionString;
        double d = 0.0;
        int i = 0;
        private void SetTimepicker()
        {          
            time_1.CustomFormat = " ";
            time_1.Format = DateTimePickerFormat.Custom;
            time_1.Text = "";
            time_2.CustomFormat = " ";
            time_2.Format = DateTimePickerFormat.Custom;
            time_2.Text = "";
            time_3.CustomFormat = " ";
            time_3.Format = DateTimePickerFormat.Custom;
            time_3.Text = "";
        }

        private void 健康診断登録_Load(object sender, EventArgs e)
        {
            SetCmb名前リスト();
            SetTimepicker();
            if (string.IsNullOrWhiteSpace(code)&& string.IsNullOrWhiteSpace(time))
            {
                Display(dateTimePicker1.Value.ToString("yyy/MM/dd"), cmb_名前.SelectedValue.ToString());
            }
            else
            {
                btn_登録.Text = "更新";
                this.Text = "健康診断更新";
                dateTimePicker1.Enabled = false;
                cmb_名前.Enabled = false;
                Display(time, code);
            }
        }
        /// <summary>
        /// 名前リストを獲得する
        /// </summary>
        private void SetCmb名前リスト()
        {
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
            try
            {
                string sqlcmd = "Select T1.園児コード , T1.名前 as 園児名 , (cast(T1.園児コード as varchar)+'　'+  T1.名前)as 名前 from HL_JEC_園児情報マスタ AS T1 Where 1 = 1";
                SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlcmd, sqlcon);
                sqlDa.Fill(dt);
                cmb_名前.DisplayMember = "名前";
                cmb_名前.ValueMember = "園児コード";
                cmb_名前.DataSource = dt;              
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format(@"園児名の獲得処理に失敗しました。" + ex.Message);
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
        /// 健康状況未入力提示
        /// </summary>
        /// <param name="chaecktext"></param>
        private void　健康状況入力提示(string chaecktext)
        {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = chaecktext + "の状況を選択してしてください.";
        }
        /// <summary>
        /// 体温チェック
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="checkname"></param>
        private void 体温チェック(string temperature, string checkname)
        {  
        }
        /// <summary>
        /// 回数に入力チェック
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type"></param>
        private void 排便チェック　(string content, string type)
        {           
            if (!int.TryParse(content, out i))
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = type + "の回数に数字を入力してください.";
            }
            if (int.Parse(content) < 0)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = type + "の回数にに負数を入力してないでください.";
            }
        }
        /// <summary>
        /// 未入力チェック
        /// </summary>
        /// <param name="a"></param>
        private void  入力提示(string a)
        {
            toolStripStatusLabel1.ForeColor = Color.Red;
            toolStripStatusLabel1.Text = a+"を入力してください.";          
        }
        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_登録_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_室温.Text))
            {
                入力提示("室温");
                return;
            }
            if (!string.IsNullOrEmpty(txt_室温.Text))
            {
                if (!Double.TryParse(txt_室温.Text, out d))
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text =  "室温に数字を入力してください.";
                    return;
                }
                if ((Double.Parse(txt_室温.Text)) > 45.0 || (Double.Parse(txt_室温.Text)) < -30)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "室温に正しい温度を入力してください.";
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(txt_体温1.Text))
            {
                入力提示("体温1");
                return;
            }
            else if (string.IsNullOrWhiteSpace(time_1.Text) && !string.IsNullOrWhiteSpace(txt_体温1.Text))
            {
                入力提示("測温時間1");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txt_体温2.Text) && 
                    (!string.IsNullOrWhiteSpace(txt_体温3.Text) || !string.IsNullOrWhiteSpace(time_3.Text)))
            {
                入力提示("体温2");
                return;
            }         
            else if (!string.IsNullOrWhiteSpace(time_2.Text) && string.IsNullOrWhiteSpace(txt_体温2.Text))
            {
                入力提示("体温2");
                return;
            }
            else if (string.IsNullOrWhiteSpace(time_2.Text) && !string.IsNullOrWhiteSpace(txt_体温2.Text))
            {
                入力提示("測温時間2");
                return;
            }
            else if (!string.IsNullOrWhiteSpace(time_3.Text) && string.IsNullOrWhiteSpace(txt_体温3.Text))
            {
                入力提示("体温3");
                return;
            }
            else if (string.IsNullOrWhiteSpace(time_3.Text) && !string.IsNullOrWhiteSpace(txt_体温3.Text))
            {
                入力提示("測温時間3");
                return;
            }
            if (!string.IsNullOrEmpty(txt_体温1.Text))
            {
                if (!Double.TryParse(txt_体温1.Text, out d))
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "体温1に数字を入力してください.";
                    return;
                }
                if ((Double.Parse(txt_体温1.Text)) > 45.0 || (Double.Parse(txt_体温1.Text)) < 30)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "体温1に正しい温度を入力してください.";
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txt_体温2.Text))
            {
                if (!Double.TryParse(txt_体温2.Text, out d))
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "体温2に数字を入力してください.";
                    return;
                }
                if ((Double.Parse(txt_体温2.Text)) > 45.0 || (Double.Parse(txt_体温2.Text)) < 30)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "体温2に正しい温度を入力してください.";
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txt_体温3.Text))
            {
                if (!Double.TryParse(txt_体温3.Text, out d))
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "体温3に数字を入力してください.";
                    return;
                }
                if ((Double.Parse(txt_体温3.Text)) > 45.0 || (Double.Parse(txt_体温3.Text)) < 30)
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "体温3に正しい温度を入力してください.";
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace((cmb_機嫌.SelectedItem == null ? string.Empty : cmb_機嫌.SelectedItem.ToString())))
            {
                健康状況入力提示("機嫌");
                return;
            }
            if (string.IsNullOrWhiteSpace((cmb_しっしん.SelectedItem == null ? string.Empty : cmb_しっしん.SelectedItem.ToString())))
            {
                健康状況入力提示("しっしん");
                return;
            }
            if (string.IsNullOrWhiteSpace((cmb_せきはなみず.SelectedItem == null ? string.Empty : cmb_せきはなみず.SelectedItem.ToString())))
            {
                健康状況入力提示("せき・はなみず");
                return;
            }
            if (cmb_食事状況.SelectedItem != null && cmb_食事状況.SelectedItem.ToString() == "その他" && string.IsNullOrWhiteSpace(txt_他.Text))
            {
                入力提示("食事内容状況");
                return;
            }
            排便チェック(txt_硬便.Text, "硬便");
            排便チェック(txt_普通.Text, "普通");
            排便チェック(txt_軟便.Text, "軟便");
            string code = cmb_名前.SelectedValue.ToString();
            string date = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string roomdegree = txt_室温.Text == "" ? "" : txt_室温.Text;
            List<string> list = new List<string>();
            string a1 = (string.IsNullOrWhiteSpace(time_1.Text) ? "" : (time_1.Value.ToString("HH:mm:ss") + "-")) + (txt_体温1.Text == "" ? "" : (txt_体温1.Text));
            string a2 = (string.IsNullOrWhiteSpace(time_2.Text) ? "" : (time_2.Value.ToString("HH:mm:ss") + "-")) + (txt_体温2.Text == "" ? "" : (txt_体温2.Text));
            string a3 = (string.IsNullOrWhiteSpace(time_3.Text) ? "" : (time_3.Value.ToString("HH:mm:ss") + "-")) + (txt_体温3.Text == "" ? "" : (txt_体温3.Text));
            if (!string.IsNullOrEmpty(a1))
            {
                list.Add(a1);
            }
            if (!string.IsNullOrEmpty(a2))
            {
                list.Add(a2);
            }
            if (!string.IsNullOrEmpty(a3))
            {
                list.Add(a3);
            }
            string 体温 = string.Join(",", list.ToArray());
            List<string> list2 = new List<string>();
            string 機嫌 = cmb_機嫌.SelectedItem == null ? "" : ("機嫌-" + cmb_機嫌.SelectedItem.ToString());
            string しっしん = cmb_しっしん.SelectedItem == null ? "" : ("しっしん-" + cmb_しっしん.SelectedItem.ToString());
            string せきはなみず = cmb_せきはなみず.SelectedItem == null ? "" : ("せき・はなみず-" + cmb_せきはなみず.SelectedItem.ToString());
            string その他 =string.IsNullOrWhiteSpace( txt_その他.Text)? "" : ("その他-" + txt_その他.Text);
            if (!string.IsNullOrEmpty(機嫌))
            {
                list2.Add(機嫌);
            }
            if (!string.IsNullOrEmpty(しっしん))
            {
                list2.Add(しっしん);
            }
            if (!string.IsNullOrEmpty(せきはなみず))
            {
                list2.Add(せきはなみず);
            }
            if (!string.IsNullOrEmpty(その他))
            {
                list2.Add(その他);
            }
            string チェック項目 = string.Join(",", list2.ToArray());
            string 状況 = (cmb_食事状況.SelectedItem == null ? string.Empty : cmb_食事状況.SelectedItem.ToString());
            string 食事状況=(状況　==　"その他" ? txt_他.Text: 状況);
            List<string> list3 = new List<string>();
            string 軟便1 = "軟便-" + txt_軟便.Text;
            string 硬便1 = "硬便-" + txt_硬便.Text;
            string 普通1 = "普通-" + txt_普通.Text;
            string 軟便 = txt_軟便.Text == "" ? "" : 軟便1;
            string 普通 = txt_普通.Text == "" ? "" : 普通1;
            string 硬便 = txt_硬便.Text == "" ? "" : 硬便1;
            if (!string.IsNullOrEmpty(軟便))
            {
                list3.Add(軟便);
            }
            if (!string.IsNullOrEmpty(普通))
            {
                list3.Add(普通);
            }
            if (!string.IsNullOrEmpty(硬便))
            {
                list3.Add(硬便);
            }
            string 排便状況 = string.Join(",", list3.ToArray());
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
            SqlTransaction traction = sqlcon.BeginTransaction();
            try
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlcon;
                sqlcom.Transaction = traction;
                sqlcom.CommandText = string.Format(@"if exists(select * from HL_JEC_園児健康状況観察 where 園児コード = {0} and 日付='{1}')
                                                 begin
                                                        UPDATE HL_JEC_園児健康状況観察 SET [室温]='{2}',[体温]='{3}', [チェック項目]=N'{4}',
                                                        食事内容状況='{5}',排便='{6}' WHERE 園児コード = {0} and 日付='{1}';
                                                 end
                                                 else
                                                 begin
                                                        Insert HL_JEC_園児健康状況観察
                                                       (園児コード,日付,室温,体温,チェック項目,食事内容状況,排便) values( 
                                                       '{0}','{1}','{2}','{3}',N'{4}','{5}','{6}') 
                                                     end", code, date, roomdegree, 体温, チェック項目, 食事状況, 排便状況);

                int result = sqlcom.ExecuteNonQuery();
                if (result == 1)
                {
                    traction.Commit();

                    if (((Form1)(this.Tag)).m_健康診断Handle != null)
                    {
                    //    健康診断 m_NewForm健康診断 = new 健康診断();
                        園児健康診断 m_NewForm健康診断 = (園児健康診断)this.Owner;//把健康診断登録的父窗口指针赋给健康診断
                        m_NewForm健康診断.datatime = dateTimePicker1.Value;
                        m_NewForm健康診断.name = 園児名;
                        SendMessage(((Form1)(this.Tag)).m_健康診断Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                    }
                    this.Close();
                }
                else
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "登録が失敗しました.";
                    return;                  
                }

            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "登録が失敗しました." + ex.Message;
                traction.Rollback();
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
        /// 初期表示/画面表示
        /// </summary>
        /// <param name="time"></param>
        /// <param name="code"></param>
        private void Display(string time, string code)
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
                return;
            }

            string str_sqlcmd = string.Format(@"select a.名前, a.園児コード,b.日付,b.チェック項目,b.体温,b.食事内容状況,b.室温,b.排便                                             
　　　　　　　　　　　　　　　　              from HL_JEC_園児情報マスタ a 
                                              left join HL_JEC_園児健康状況観察 b
                                              on a.園児コード = b.園児コード
                                              and b.日付 = '{0}'where a.園児コード = '{1}'", time, code);
            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                dateTimePicker1.Value = Convert.ToDateTime(time);
                txt_室温.Text = reader["室温"].ToString();
                cmb_名前.SelectedValue = code;
                園児名 = reader["名前"].ToString();
                if (!string.IsNullOrEmpty(reader["チェック項目"].ToString()))
                {
                    string[] チェック項目 = reader["チェック項目"].ToString().Split(',');
                    foreach (string str in チェック項目)
                    {                       
                        int a = str.IndexOf("-");
                        int b = str.Length - a - 1;
                        string checkitem = str.Substring(0, a);
                        string result = str.Substring(a + 1, b);
                        if (checkitem == "機嫌")
                        {
                            cmb_機嫌.SelectedItem = result;
                        }
                        else if (checkitem == "しっしん")
                        {
                            cmb_しっしん.SelectedItem = result;
                        }
                        else if (checkitem == "せき・はなみず")
                        {
                            cmb_せきはなみず.SelectedItem = result;
                        }
                        else if (checkitem != "せき・はなみず" && checkitem != "しっしん" && checkitem != "機嫌")
                        {
                            txt_その他.Text = result;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(reader["体温"].ToString()))
                {
                    string[] 体温 = reader["体温"].ToString().Split(',');
                    int count = 体温.Length;
                    for (int i = 0; i < count; i++)
                    {
                        string str = 体温[i];
                        int a = str.IndexOf("-");
                        int b = str.Length - a - 1;
                        string 検温時間 = str.Substring(0, a);
                        string result = str.Substring(a + 1, b);
                        switch (i)
                        {
                            case 0:
                                time_1.CustomFormat = "HH:mm:ss";
                                time_1.Format = DateTimePickerFormat.Custom;
                                time_1.Value = DateTime.Parse(検温時間);
                                txt_体温1.Text = result;
                                break;
                            case 1:
                                time_2.CustomFormat = "HH:mm:ss";
                                time_2.Format = DateTimePickerFormat.Custom;
                                time_2.Value = DateTime.Parse(検温時間);
                                txt_体温2.Text = result;
                                break;
                            case 2:
                                time_3.CustomFormat = "HH:mm:ss";
                                time_3.Format = DateTimePickerFormat.Custom;
                                time_3.Value = DateTime.Parse(検温時間);
                                txt_体温3.Text = result;
                                break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(reader["排便"].ToString()))
                {
                    string[] 排便 = reader["排便"].ToString().Split(',');
                    foreach (string str in 排便)
                    {
                        int a = str.IndexOf("-");
                        int b = str.Length - a - 1;
                        string 排便種類 = str.Substring(0, a);
                        string result = str.Substring(a + 1, b);
                        switch (排便種類)
                        {
                            case "硬便":
                                txt_硬便.Text = result;
                                break;
                            case "普通":
                                txt_普通.Text = result;
                                break;
                            case "軟便":
                                txt_軟便.Text = result;
                                break;
                        }
                    }
                    if(!string.IsNullOrWhiteSpace(reader["食事内容状況"].ToString()) 
                        && reader["食事内容状況"].ToString()!="2/3"&& reader["食事内容状況"].ToString() != "完食")
                    {
                        cmb_食事状況.SelectedItem = "その他";
                        txt_他.Text = reader["食事内容状況"].ToString();
                    }
                    else
                    {
                        cmb_食事状況.SelectedItem = reader["食事内容状況"].ToString();
                    }   
                }
            }
        }
        /// <summary>
        /// 日付変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Clear();
            SetTimepicker();
            Display(dateTimePicker1.Value.ToString("yyy/MM/dd"), cmb_名前.SelectedValue.ToString());
            toolStripStatusLabel1.Text = "";  
        }
        /// <summary>
        /// 名前変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_名前_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            SetTimepicker();
            Display(dateTimePicker1.Value.ToString("yyy/MM/dd"), cmb_名前.SelectedValue.ToString());
            toolStripStatusLabel1.Text = "";
        }
        /// <summary>
        /// すべての画面値をクリアする
        /// </summary>
        private void Clear()
        {
            txt_室温.Text = "";
            time_1.Value = DateTime.Parse((DateTime.Now.TimeOfDay.ToString()));
            time_2.Value = DateTime.Parse((DateTime.Now.TimeOfDay.ToString()));
            time_3.Value = DateTime.Parse((DateTime.Now.TimeOfDay.ToString()));
            txt_体温1.Text = "";
            txt_体温2.Text = "";
            txt_体温3.Text = "";
            cmb_機嫌.SelectedItem = null;
            cmb_しっしん.SelectedItem = null;
            cmb_せきはなみず.SelectedItem = null;
            cmb_食事状況.SelectedItem = null;
            txt_その他.Text = "";
            txt_軟便.Text = "0";
            txt_普通.Text = "0";
            txt_硬便.Text = "0";
        }
        /// <summary>
        /// 必須追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_必須_Paint(object sender, PaintEventArgs e)
        {
            Label strLbl = (Label)sender;
            string str = strLbl.Text;

            if (str.Contains("必須"))
            {
                strLbl.ForeColor = Color.FromArgb(240, 240, 240);
                Font f = new Font("メイリオ", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));

                int i = str.IndexOf("　[");
                string str_name = str.Substring(0, i);
                string str必須 = str.Substring(i, str.Length - i);
                for (int x = 0; x <= i; x++)
                {
                    str必須 = "   " + str必須;
                }

                Point point = new Point(((Label)sender).Padding.Right, ((Label)sender).Padding.Top);
                TextRenderer.DrawText(e.Graphics, str必須, f, point, Color.Red);
                TextRenderer.DrawText(e.Graphics, str_name, ((Label)sender).Font, point, Color.Black);
            }
            else
            {
                strLbl.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// システム時間を獲得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Time_1_MouseDown(object sender, MouseEventArgs e)
        {
            time_1.Text = DateTime.Now.ToString("HH:mm:ss");
            time_1.CustomFormat = "HH:mm:ss";
            time_1.Format = DateTimePickerFormat.Custom;          
        }
        /// <summary>
        /// システム時間を獲得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Time_2_MouseDown(object sender, MouseEventArgs e)
        {
            time_2.Text = DateTime.Now.ToString("HH:mm:ss");
            time_2.CustomFormat = "HH:mm:ss";
            time_2.Format = DateTimePickerFormat.Custom;
        }
        /// <summary>
        /// システム時間を獲得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Time_3_MouseDown(object sender, MouseEventArgs e)
        {
            time_3.Text = DateTime.Now.ToString("HH:mm:ss");
            time_3.CustomFormat = "HH:mm:ss";
            time_3.Format = DateTimePickerFormat.Custom;
        }
        /// <summary>
        /// 体温が空白の場合、対応測温時間が空白にする
        /// </summary>
        private void time1()
        {
            if (string.IsNullOrWhiteSpace(txt_体温1.Text))
            {
                time_1.Text = "";
                time_1.CustomFormat = " ";
                time_1.Format = DateTimePickerFormat.Custom;
               
            }        
        }
        /// <summary>
        /// 体温が空白の場合、対応測温時間が空白にする
        /// </summary>
        private void time2()
        {
            if (string.IsNullOrWhiteSpace(txt_体温2.Text))
            {
                time_2.Text = "";
                time_2.CustomFormat = " ";
                time_2.Format = DateTimePickerFormat.Custom;
                
            }
        }
        /// <summary>
        /// 体温が空白の場合、対応測温時間が空白にする
        /// </summary>
        private void time3()
        {
            if (string.IsNullOrWhiteSpace(txt_体温3.Text))
            {
                time_3.Text = "";
                time_3.CustomFormat = " ";
                time_3.Format = DateTimePickerFormat.Custom;
                
            }
        }
        /// <summary>
        /// 体温のTEXTBOXに離れる場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_体温1_Leave(object sender, EventArgs e)
        {
            time1();
        }
        /// <summary>
        /// 体温のTEXTBOXに離れる場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_体温2_Leave(object sender, EventArgs e)
        {
            time2();
        }
        /// <summary>
        /// 体温のTEXTBOXに離れる場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_体温3_Leave(object sender, EventArgs e)
        {
            time3();
        }
        /// <summary>
        /// 食事内容状況の'その他'を選択する場合、TEXTBOX表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_食事状況_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cmb_食事状況.SelectedItem != null)
            {
                if (cmb_食事状況.SelectedItem.ToString() == "その他")
                {
                    txt_他.Visible = true;
                }
                else
                {
                    txt_他.Clear();
                    txt_他.Visible = false;
                }
            }
           else
            {
                txt_他.Clear();
                txt_他.Visible = false;
            }
            
        }
    }
}
