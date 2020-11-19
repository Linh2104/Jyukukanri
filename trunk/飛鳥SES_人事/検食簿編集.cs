using System;
using ComDll;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Data.SqlClient;

namespace 飛鳥SES_人事
{
    public partial class 検食簿編集 : DockContent
    {
        private string connectionString = "Data Source=DESKTOP-R5038PT\\SQLEXPRESS01;Initial Catalog=oa;Integrated Security=True";
        //private string connectionString = ComClass.connectionString;

        //各変量
        string checkcode = string.Empty;
        int checkid;
        string date = DateTime.Now.ToString("yyyy/MM/dd");
        string time = string.Empty;
        string diff = string.Empty;
        string user = string.Empty;
        int time1 = 120000;
        int time2 = 150000;
        int time3 = 0;

        //各行献立名
        string food1 = string.Empty;
        string food2 = string.Empty;
        string food3 = string.Empty;
        string food4 = string.Empty;
        string food5 = string.Empty;

        //各行献立名リストのコード
        string foodnum1 = string.Empty;
        string foodnum2 = string.Empty;
        string foodnum3 = string.Empty;
        string foodnum4 = string.Empty;
        string foodnum5 = string.Empty;

        //各行味付
        string taste1 = string.Empty;
        string taste2 = string.Empty;
        string taste3 = string.Empty;
        string taste4 = string.Empty;
        string taste5 = string.Empty;

        //各行盛付
        string arrange1 = string.Empty;
        string arrange2 = string.Empty;
        string arrange3 = string.Empty;
        string arrange4 = string.Empty;
        string arrange5 = string.Empty;

        //各行分量
        string portion1 = string.Empty;
        string portion2 = string.Empty;
        string portion3 = string.Empty;
        string portion4 = string.Empty;
        string portion5 = string.Empty;

        //衛生所見等
        string heath = string.Empty;
        //備考
        string remark = string.Empty;

        DataSet temp = new DataSet();
        public 検食簿編集()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 必須項目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label4_Paint(object sender, PaintEventArgs e)
        {
            Label strLbl = (Label)sender;
            string str = strLbl.Text;

            if (str.Contains("必須"))
            {
                strLbl.ForeColor = Color.FromArgb(240, 240, 240);

                Font f = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));


                int i = str.IndexOf("　[");
                string str_name = str.Substring(0, i);
                string str必須 = str.Substring(i, str.Length - i);

                if (str.Contains("MyNumber"))
                {
                    i = i - 2;
                }

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
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 検食簿編集_Load(object sender, EventArgs e)

        {
            lbl_today.Text = date;
            GetCheckID();
            txt_notice.Text = @" 1,「区分」の「九時おやつ」を選択した場合は、時間を「12:00」以前の時間に設定してください。" + "\r\n "
                            + @"2,「区分」の「昼食」を選択した場合は、時間を「12:00」から「15:00」までの時間に設定してください。" + "\r\n "
                            + @"3,「区分」の「三時おやつ」を選択した場合は、時間を15:00」以降の時間に設定してください。" + "\r\n "
                            + @"4,　二つ以上の献立名をチェックする場合、チェックボックスをチェックしてからデータを選択してください。";
            GetGoodslist(cmb_food1, cmb_food1.Name.ToString());
            cmb_part.Enabled = true;
        }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        /// <param name="msg"></param>
        private void Msg(string msg)
        {
            toolStripStatusLabel1.ForeColor = Color.Red;
            toolStripStatusLabel1.Text = msg;
        }

        /// <summary>
        /// チェックコードを獲得する
        /// </summary>
        private void GetCheckID()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                Msg("DBサーバーの接続に失敗しました。");
                return;
            }


            string sqlcmd = "SELECT MAX(チェックコード) as チェックコード FROM HL_JEC_検食簿";
            SqlCommand com = new SqlCommand(sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    checkcode = reader["チェックコード"].ToString();
                    if (string.IsNullOrEmpty(checkcode))
                    {
                        checkid = 1;
                    }
                    else
                    {
                        checkid = Convert.ToInt16(checkcode);
                    }
                }
            }
            catch (Exception ex)
            {
                Msg("最大チェックコードの獲得は失敗しました。" + ex.Message);
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
        }

        /// <summary>
        /// コントロールから値を獲得
        /// </summary>
        private void DataApply()
        {
            time = dtp_time.Value.ToString("HH:mm:ss");
            time3 = Convert.ToInt32(time.Replace(":", ""));
            diff = cmb_part.Text;
            food1 = cmb_food1.Text;
            foodnum1 = cmb_food1.SelectedValue.ToString();
            taste1 = cmb_taste1.Text;
            arrange1 = cmb_arrange1.Text;
            portion1 = cmb_portion1.Text;
            heath = txt_health.Text;
            remark = txt_remark.Text;
            user = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ氏名;

            if (chk_box1.Checked)
            {
                food2 = cmb_food2.Text;
                foodnum2 = cmb_food2.SelectedValue.ToString();
                taste2 = cmb_taste2.Text;
                arrange2 = cmb_arrange2.Text;
                portion2 = cmb_portion2.Text;
            }
            if (chk_box2.Checked)
            {
                food3 = cmb_food3.Text;
                foodnum3 = cmb_food3.SelectedValue.ToString();
                taste3 = cmb_taste3.Text;
                arrange3 = cmb_arrange3.Text;
                portion3 = cmb_portion3.Text;
            }
            if (chk_box3.Checked)
            {
                food4 = cmb_food4.Text;
                foodnum4 = cmb_food4.SelectedValue.ToString();
                taste4 = cmb_taste4.Text;
                arrange4 = cmb_arrange4.Text;
                portion4 = cmb_portion4.Text;
            }
            if (chk_box4.Checked)
            {
                food5 = cmb_food5.Text;
                foodnum5 = cmb_food5.SelectedValue.ToString();
                taste5 = cmb_taste5.Text;
                arrange5 = cmb_arrange4.Text;
                portion5 = cmb_portion5.Text;
            }
        }

        /// <summary>
        /// エラーチェック
        /// </summary>
        /// <returns></returns>
        private bool DataCheck()
        {

            if (string.IsNullOrEmpty(diff))
            {
                Msg("[区分]を選択してください。");
                return false;
            }
            if (diff == "九時おやつ" && time3 > time1)
            {
                Msg("「区分」の「九時おやつ」を選択した場合は、時間を「12:00」以前の時間に設定してください。");
                return false;
            }
            if (diff == "昼食" && (time3 < time1 || time3 > time2))
            {
                Msg("「区分」の「昼食」を選択した場合は、時間を「12:00」から「15:00」までの時間に設定してください。");
                return false;
            }
            if (diff == "三時おやつ" && time3 < time2)
            {
                Msg("「区分」の「三時おやつ」を選択した場合は、時間を「15:00」以降の時間に設定してください。");
                return false;
            }
            if (string.IsNullOrEmpty(food1))
            {
                Msg("[献立名1]を選択してください。");
                return false;
            }
            if (string.IsNullOrEmpty(taste1))
            {
                Msg("[献立名1]の行の[味付]を選択してください。");
                return false;
            }
            if (string.IsNullOrEmpty(arrange1))
            {
                Msg("[献立名1]の行の[盛付]を選択してください。");
                return false;
            }
            if (string.IsNullOrEmpty(portion1))
            {
                Msg("[献立名1]の行の[分量]を選択してください。");
                return false;
            }
            if (chk_box1.Checked)
            {
                if (string.IsNullOrEmpty(food2))
                {
                    Msg("[献立名2]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(taste2))
                {
                    Msg("[献立名2]の行の[味付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(arrange2))
                {
                    Msg("[献立名2]の行の[盛付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(portion2))
                {
                    Msg("[献立名2]の行の[分量]を選択してください。");
                    return false;
                }
            }
            if (chk_box2.Checked)
            {
                if (string.IsNullOrEmpty(food3))
                {
                    Msg("[献立名3]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(taste3))
                {
                    Msg("[献立名3]の行の[味付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(arrange3))
                {
                    Msg("[献立名3]の行の[盛付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(portion3))
                {
                    Msg("[献立名3]の行の[分量]を選択してください。");
                    return false;
                }
            }
            if (chk_box3.Checked)
            {
                if (string.IsNullOrEmpty(food4))
                {
                    Msg("[献立名4]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(taste4))
                {
                    Msg("[献立名4]の行の[味付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(arrange4))
                {
                    Msg("[献立名4]の行の[盛付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(portion4))
                {
                    Msg("[献立名4]の行の[分量]を選択してください。");
                    return false;
                }
            }
            if (chk_box4.Checked)
            {
                if (string.IsNullOrEmpty(food5))
                {
                    Msg("[献立名5]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(taste5))
                {
                    Msg("[献立名5]の行の[味付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(arrange5))
                {
                    Msg("[献立名5]の行の[盛付]を選択してください。");
                    return false;
                }
                if (string.IsNullOrEmpty(portion5))
                {
                    Msg("[献立名5]の行の[分量]を選択してください。");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 各行献立名リストを獲得する
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="cmb_name"></param>
        private void GetGoodslist(ComboBox cmb, string cmb_name)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                Msg("DBサーバーの接続に失敗しました。");
                return;
            }

            string sqlcmd = "select * from HL_JEC_品物リスト where 種類 != '消耗品'";
            try
            {
                SqlDataAdapter sqltb = new SqlDataAdapter(sqlcmd, sqlcon);
                sqltb.Fill(temp, cmb_name);
                cmb.DataSource = temp.Tables[cmb_name];
                cmb.DisplayMember = "品物";
                cmb.ValueMember = "品物コード";
                temp = new DataSet();
            }
            catch (Exception ex)
            {
                Msg("品物リストの獲得は失敗しました。" + ex.Message);
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

        //checkboxの事件
        private void chk_box1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_box1.Checked)
            {
                chk_box2.Enabled = true;
                cmb_food2.Enabled = true;
                cmb_taste2.Enabled = true;
                cmb_arrange2.Enabled = true;
                cmb_portion2.Enabled = true;
                lbl_food2.Text = "献立名2　[必須]";
                lbl_taste2.Text = "味付　[必須]";
                lbl_arrange2.Text = "盛付　[必須]";
                lbl_portion2.Text = "分量　[必須]";
                GetGoodslist(cmb_food2, cmb_food2.Name.ToString());
            }
            else
            {
                chk_box2.Enabled = false;
                chk_box2.Checked = false;
                cmb_food2.Enabled = false;
                cmb_taste2.Enabled = false;
                cmb_arrange2.Enabled = false;
                cmb_portion2.Enabled = false;
                lbl_food2.Text = "献立名2";
                lbl_taste2.Text = "味付";
                lbl_arrange2.Text = "盛付";
                lbl_portion2.Text = "分量";
                cmb_taste2.SelectedIndex = -1;
                cmb_arrange2.SelectedIndex = -1;
                cmb_portion2.SelectedIndex = -1;
            }
        }

        private void chk_box2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_box2.Checked)
            {
                chk_box3.Enabled = true;
                cmb_food3.Enabled = true;
                cmb_taste3.Enabled = true;
                cmb_arrange3.Enabled = true;
                cmb_portion3.Enabled = true;
                lbl_food3.Text = "献立名3　[必須]";
                lbl_taste3.Text = "味付　[必須]";
                lbl_arrange3.Text = "盛付　[必須]";
                lbl_portion3.Text = "分量　[必須]";
                GetGoodslist(cmb_food3, cmb_food3.Name.ToString());
            }
            else
            {
                chk_box3.Enabled = false;
                chk_box3.Checked = false;
                cmb_food3.Enabled = false;
                cmb_taste3.Enabled = false;
                cmb_arrange3.Enabled = false;
                cmb_portion3.Enabled = false;
                lbl_food3.Text = "献立名3";
                lbl_taste3.Text = "味付";
                lbl_arrange3.Text = "盛付";
                lbl_portion3.Text = "分量";
                cmb_taste3.SelectedIndex = -1;
                cmb_arrange3.SelectedIndex = -1;
                cmb_portion3.SelectedIndex = -1;
            }
        }

        private void chk_box3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_box3.Checked)
            {
                chk_box4.Enabled = true;
                cmb_food4.Enabled = true;
                cmb_taste4.Enabled = true;
                cmb_arrange4.Enabled = true;
                cmb_portion4.Enabled = true;
                lbl_food4.Text = "献立名4　[必須]";
                lbl_taste4.Text = "味付　[必須]";
                lbl_arrange4.Text = "盛付　[必須]";
                lbl_portion4.Text = "分量　[必須]";
                GetGoodslist(cmb_food4, cmb_food4.Name.ToString());
            }
            else
            {
                chk_box4.Enabled = false;
                chk_box4.Checked = false;
                cmb_food4.Enabled = false;
                cmb_taste4.Enabled = false;
                cmb_arrange4.Enabled = false;
                cmb_portion4.Enabled = false;
                lbl_food4.Text = "献立名4";
                lbl_taste4.Text = "味付";
                lbl_arrange4.Text = "盛付";
                lbl_portion4.Text = "分量";
                cmb_taste4.SelectedIndex = -1;
                cmb_arrange4.SelectedIndex = -1;
                cmb_portion4.SelectedIndex = -1;
            }
        }

        private void chk_box4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_box4.Checked)
            {
                cmb_food5.Enabled = true;
                cmb_taste5.Enabled = true;
                cmb_arrange5.Enabled = true;
                cmb_portion5.Enabled = true;
                lbl_food5.Text = "献立名5　[必須]";
                lbl_taste5.Text = "味付　[必須]";
                lbl_arrange5.Text = "盛付　[必須]";
                lbl_portion5.Text = "分量　[必須]";
                GetGoodslist(cmb_food5, cmb_food5.Name.ToString());
            }
            else
            {
                cmb_food5.Enabled = false;
                cmb_taste5.Enabled = false;
                cmb_arrange5.Enabled = false;
                cmb_portion5.Enabled = false;
                lbl_food5.Text = "献立名5";
                lbl_taste5.Text = "味付";
                lbl_arrange5.Text = "盛付";
                lbl_portion5.Text = "分量";
                cmb_taste5.SelectedIndex = -1;
                cmb_arrange5.SelectedIndex = -1;
                cmb_portion5.SelectedIndex = -1;
            }
        }
        //checkboxの事件

        /// <summary>
        /// 登録する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, EventArgs e)
        {
            DataApply();
            if (!DataCheck())
            {
                return;
            }

            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                Msg("DBサーバーの接続に失敗しました.");
                return;
            }
            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;
            int result = 0;
            try
            {
                string sqlcmd = @"insert into HL_JEC_検食簿 values({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}')";
                sqlcom.CommandText = string.Format(sqlcmd, checkid + 1, date, time, foodnum1, taste1, arrange1, portion1, user, heath, remark);
                result = sqlcom.ExecuteNonQuery();
                if (chk_box1.Checked && result == 1)
                {
                    sqlcom.CommandText = string.Format(sqlcmd, checkid + 2, date, time, foodnum2, taste2, arrange2, portion2, user, heath, remark);
                    result += sqlcom.ExecuteNonQuery();
                }
                if (chk_box2.Checked && result == 2)
                {
                    sqlcom.CommandText = string.Format(sqlcmd, checkid + 3, date, time, foodnum3, taste3, arrange3, portion3, user, heath, remark);
                    result += sqlcom.ExecuteNonQuery();
                }
                if (chk_box3.Checked && result == 3)
                {
                    sqlcom.CommandText = string.Format(sqlcmd, checkid + 4, date, time, foodnum4, taste4, arrange4, portion4, user, heath, remark);
                    result += sqlcom.ExecuteNonQuery();
                }
                if (chk_box4.Checked && result == 4)
                {
                    sqlcom.CommandText = string.Format(sqlcmd, checkid + 5, date, time, foodnum5, taste5, arrange5, portion5, user, heath, remark);
                    result += sqlcom.ExecuteNonQuery();
                }
                transaction.Commit();
                this.Close();
            }
            catch (Exception ex)
            {
                Msg("登録処理に失敗しました。" + ex.Message);
                transaction.Rollback();
            }
            finally
            {
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }
        }

        private void 検食簿編集_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_検食簿編集Handle.iHandle = IntPtr.Zero;
        }
    }
}
