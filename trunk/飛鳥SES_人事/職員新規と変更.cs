using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;
using ComDll;


namespace 飛鳥SES_人事
{
    public partial class 職員新規と変更 : DockContent
    {
        /// <summary>
        /// テスト用
        /// </summary>
        public 職員新規と変更()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        職員情報一覧 ownerform;
        private string str_gyoumu;

        //Start Add chen 2020/10/19　職務名情報を渡す
        public string jname;
        //End add chen 2020/10/19
        /// <summary>
        /// コンストラクターの引数による画面分岐
        /// </summary>
        /// <param name="pattern">新規の場合：pattern = 1；変更の場合：pattern = 2</param>
        /// <param name="fatherID">親画面選択した行の職員コード</param>
        public 職員新規と変更(int pattern, string fatherID, 職員情報一覧 owner,string Str_gyoumu)
        {
            InitializeComponent();
            executePattern = pattern;
            currentID = fatherID;
            ownerform = owner;
            str_gyoumu = Str_gyoumu;
        }

        /// <summary>
        /// コンストラクターの引数による画面分岐
        /// </summary>
        /// <param name="pattern">新規の場合：pattern = 1；変更の場合：pattern = 2</param>
        /// <param name="fatherID">親画面選択した行の職員コード</param>
        public 職員新規と変更(int pattern, string fatherID)
        {
            InitializeComponent();
            executePattern = pattern;
            currentID = fatherID;
        }
        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 職員新規と変更_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            //Start Mod chen 2020/10/19　一覧画面の職務名を渡すになった
            CodeInit();
            if (!string.IsNullOrEmpty(cmb_id.Text))
            {

                cmb_jname.Text = jname;
            }
            else
            {
                cmb_jname.SelectedIndex = 0;
            }
            //End Mod chen 2020/10/19 
         
        }

        //string connectionString = "integrated security = true;server=DESKTOP-VAS78BQ;database=oa;connection timeout=10;";
        string connectionString = ComClass.connectionString;
        string currentID = string.Empty;
        int executePattern;
        List<string> checkresult = new List<string>();

        /// <summary>
        /// 職員コンボボックスの項目取得
        /// </summary>
        public void CodeInit()
        {

            //connectionString = ComClass.connectionString;
            SqlConnection connection = new SqlConnection(connectionString); //连接数据库
            SqlDataReader reader = null;

            try
            {
                //start mod chenriming 2020/10/19 在職状態の検索条件を変更した
                string str_sqlcmd = string.Format(@"select a.社員コード, a.名前 from  HL_JINJI_社員マスタ a,HL_JINJI_社員在職状態_NEW b where 在職状態 ='在職 '");
                //end mod chenriming 2020/10/19 
                str_sqlcmd += string.Format(@"and a.社員コード=b.社員コード ");
                str_sqlcmd += string.Format(@"and b.職務='保 育' ");
                if (executePattern == 1)
                {
                    str_sqlcmd += string.Format(@"and a.社員コード not in (select 職員コード from HL_JEC_職員情報) ");
                }
                else if (executePattern == 2)
                {
                    str_sqlcmd += string.Format(@"and a.社員コード = {0} ", currentID);
                }

                connection.Open();

                SqlCommand com = new SqlCommand(str_sqlcmd, connection);

                reader = com.ExecuteReader();

                this.cmb_id.Items.Clear();

                while (reader.Read())
                {
                    this.cmb_id.Items.Add(reader["社員コード"].ToString() + "　" + reader["名前"].ToString());
                }

                if (this.cmb_id.Items.Count > 0 && executePattern == 1)
                {
                    this.cmb_id.SelectedIndex = -1;
                }
                else if (this.cmb_id.Items.Count > 0 && executePattern == 2)
                {
                    this.cmb_id.SelectedIndex = 0;
                    cmb_id.Enabled = false;
                }


            }
            catch (Exception)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";

            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }
        }

        /// <summary>
        /// 選択した職員による情報自動入力
        /// </summary>
        private void AutoFill()
        {

            //connectionString = ComClass.connectionString;

            SqlConnection connection = new SqlConnection(connectionString); //连接数据库
            SqlDataReader reader = null;

            try
            {
                currentID = cmb_id.Text.Split(new char[] { '　' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            catch (Exception)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "職員コード・氏名の入力書式が正しくありません。";
            }

            try
            {

                string str_sqlcmd = string.Format(@"select a.社員コード,a.名前,a.カタカナ,a.ローマ字表記,a.MYNumber,a.生年月日,b.携帯,b.メール,c.社員種別,a.入職日 ");
                str_sqlcmd += string.Format(@"from HL_JINJI_社員マスタ a,HL_JINJI_社員情報_NEW b,HL_JINJI_社員在職状態_NEW c ");
                str_sqlcmd += string.Format(@"where a.社員コード=b.社員コード  ");
                str_sqlcmd += string.Format(@"and a.社員コード=c.社員コード  ");
                str_sqlcmd += string.Format(@"and a.社員コード={0}  ", currentID);

                connection.Open();

                SqlCommand AutoFillCmd = new SqlCommand(str_sqlcmd, connection);

                reader = AutoFillCmd.ExecuteReader();

                while (reader.Read())
                {
                    txt_kana.Text = Convert.ToString(reader["カタカナ"]);
                    txt_roma.Text = Convert.ToString(reader["ローマ字表記"]);
                    txt_mynum.Text = Convert.ToString(reader["MYNumber"]);
                    txt_bday.Text = Convert.ToString(reader["生年月日"]);
                    txt_phone.Text = Convert.ToString(reader["携帯"]);
                    txt_mail.Text = Convert.ToString(reader["メール"]);
                    txt_jtype.Text = Convert.ToString(reader["社員種別"]);
                    txt_edate.Text = Convert.ToString(reader["入職日"]);
                }

            }
            catch (Exception)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";

            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }
        }

        /// <summary>
        /// 職員コンボボックス選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_id.SelectedIndex != -1)
            {
                AutoFill();
            }
        }

        /// <summary>
        /// 必須標記を描く
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

                Font f = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

                int i = str.IndexOf("  [");
                string str_name = str.Substring(0, i);
                string str必須 = str.Substring(i, str.Length - i);
                str必須 = str必須.Replace(" ", "");

                for (int x = 0; x <= i; x++)
                {
                    str必須 = "　" + str必須;
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
        /// OpenFileDialogでファイルを選択、パスを戻す
        /// </summary>
        /// <returns>選択したファイルのパスを戻し、もしくは無効の場合は空白を戻す</returns>
        private string GetFilePath()
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                string ex = Path.GetExtension(filedialog.FileName);
                string[] str = new string[] { ".pdf", ".jpg", ".jpeg", ".png", ".xls", "xlsx" };
                if (!((IList)str).Contains(ex))
                {
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text += string.Format("選択したファイルが正しくありません。");
                    return "";
                }
                else
                {
                    return filedialog.FileName;
                }
            }
            return "";
        }


        /// <summary>
        /// ファイルをBinary化し、DBのImage列に保存 
        /// </summary>
        /// <param name="FilePath">ファイルパス</param>
        /// <param name="FileType">ファイル種別</param>
        private void FileUpload(string FilePath, string FileType, SqlConnection connection, SqlTransaction transaction, ref int error)
        {
            if (FilePath == "")
            {
                return;
            }
            try
            {
                FileInfo fi = new FileInfo(FilePath);
                FileStream fs = fi.OpenRead();
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                SqlCommand FileUploadCmd = new SqlCommand();
                FileUploadCmd.Connection = connection;
                FileUploadCmd.CommandType = CommandType.Text;
                FileUploadCmd.Transaction = transaction;

                if (FileType != "健康診断書")
                {
                    FileUploadCmd.CommandText = string.Format(@"update  HL_JEC_職員情報  set {0} = @file , {0}名 = '{1}' where 職員コード = {2}", FileType, Path.GetFileName(FilePath), currentID);
                }
                else
                {
                    if (executePattern == 1)
                    {
                        FileUploadCmd.CommandText = string.Format(@"insert into HL_JEC_健康診断一覧画面マスタ (職員コード,日付,ファイル,ファイル名,年度,健康診断類別) values ('{0}','{1}','{2}','{3}','{4}','{5}')", currentID, DateTime.Now.ToString(), FileType, Path.GetFileName(FilePath), DateTime.Now.Year.ToString(), "入園前健康診断");
                    }
                    else if (executePattern == 2)
                    {
                        FileUploadCmd.CommandText = string.Format(@"update  HL_JEC_健康診断一覧画面マスタ  set {0} = @file , {0}名 = '{1}' where 職員コード = {2} and 健康診断類別='入園前健康診断'", "ファイル", Path.GetFileName(FilePath), currentID);
                    }
                }

                SqlParameter spFile = new SqlParameter("@file", SqlDbType.Image);
                spFile.Value = bytes;
                FileUploadCmd.Parameters.Add(spFile);
                int AdaptedRows = FileUploadCmd.ExecuteNonQuery();
                if (AdaptedRows == 0)
                {
                    error++;
                    toolStripStatusLabel1.Text += string.Format("{0}アップロード失敗しました", FileType);
                }

            }
            catch (Exception)
            {
                error++;
                toolStripStatusLabel1.Text += string.Format("{0}アップロード失敗しました", FileType);
            }
        }

        /// <summary>
        /// DBに接続、追加・変更操作を行い
        /// </summary>
        private void ExecuteUpdate()
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
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                connection?.Close();
                return;
            }

            try
            {
                SqlCommand DataUpdateCmd = new SqlCommand();
                DataUpdateCmd.Connection = connection;
                DataUpdateCmd.CommandType = CommandType.Text;
                DataUpdateCmd.Transaction = transaction;

                if (executePattern == 1)
                {
                    DataUpdateCmd.CommandText = string.Format(@"insert into HL_JEC_職員情報 (職員コード,園内職務) values ('{0}','{1}')", currentID, cmb_jname.SelectedItem.ToString());
                }
                else if (executePattern == 2)
                {
                    DataUpdateCmd.CommandText = string.Format(@"update HL_JEC_職員情報 set 園内職務= '{0}' where 職員コード='{1}'", cmb_jname.SelectedItem.ToString(), currentID);
                }


                int AdaptedRows = DataUpdateCmd.ExecuteNonQuery();
                if (AdaptedRows == 0)
                {
                    error++;
                }

                FileUpload(txt_rireki.Text, "履歴書", connection, transaction, ref error);
                FileUpload(txt_kenshin.Text, "健康診断書", connection, transaction, ref error);
                FileUpload(txt_shikaku.Text, "資格証書", connection, transaction, ref error);
                FileUpload(txt_himitsu.Text, "秘密保持契約書", connection, transaction, ref error);

                if (error == 0)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
                connection.Close();

                SendMessage(((Form1)(this.Tag)).m_職員情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero).ToInt64();

                //Start Add chen 2020/10/19  更新成功メッセージの表示を変更した
                if (ownerform != null )
                {
                    ownerform.toolStripStatusLabel1.ForeColor = Color.Green;
                    ownerform.toolStripStatusLabel1.Text = string.Format("職員コード：{0} さんの職員情報を正常に更新しました。", currentID);
                    this.Close();
                }
                else
                {
                    this.toolStripStatusLabel1.Text = string.Format("職員コード：{0} さんの入園手続きを正常に終了しました。", currentID);
                    this.toolStripStatusLabel1.ForeColor = Color.Green;
                    CodeInit();
                    txt_kana.Text = string.Empty;
                    txt_roma.Text = string.Empty;
                    txt_mynum.Text = string.Empty;
                    txt_bday.Text = string.Empty;
                    txt_phone.Text = string.Empty;
                    txt_mail.Text = string.Empty;
                    txt_jtype.Text = string.Empty;
                    txt_edate.Text = string.Empty;
                    cmb_jname.SelectedIndex = 0;
                }
                //End Add chen 2020/10/19
                //if ( ownerform != null && executePattern == 2 && error ==0 && str_gyoumu!= cmb_jname.SelectedItem.ToString())
                //{
                //    ownerform.toolStripStatusLabel1.ForeColor = Color.Green;
                //    ownerform.toolStripStatusLabel1.Text = string.Format("職員コード：{0} さんの園内職務を正常に更新しました。", currentID);
                //}
             
            }
            catch (Exception)
            {
                transaction?.Rollback();
                connection?.Close();
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "登録処理が失敗しました。";
            }

        }

        private void bt_upload_rireki_Click(object sender, EventArgs e)
        {
            txt_rireki.Text = GetFilePath();
        }

        private void bt_upload_kenshin_Click(object sender, EventArgs e)
        {
            txt_kenshin.Text = GetFilePath();
        }

        private void bt_upload_shikaku_Click(object sender, EventArgs e)
        {
            txt_shikaku.Text = GetFilePath();
        }

        private void bt_upload_himitsu_Click(object sender, EventArgs e)
        {
            txt_himitsu.Text = GetFilePath();
        }

        /// <summary>
        /// 入力チェック後、更新を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_add_Click(object sender, EventArgs e)
        {
            if (InputCheck())
            {
                ExecuteUpdate();
            }
            else
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = string.Format("未入力項目があります【{0}】。登録処理が失敗しました。", string.Join(",", checkresult));
            }
        }

        

        /// <summary>
        /// 入力チェック枠、既存データチェック
        /// </summary>
        /// <returns></returns>
        private bool InputCheck()
        {
            checkresult.Clear();
            //職員入力チェック・職名入力チェック
            if (cmb_id.SelectedIndex != -1 /*&& cmb_jname.SelectedIndex != -1 && txt_rireki.Text != "" && txt_kenshin.Text != "" && txt_shikaku.Text != "" && txt_himitsu.Text != ""*/)
            {               
                return true;
            }
            else
            {
                if (cmb_id.SelectedIndex == -1)
                {
                    checkresult.Add("職員");
                }
                return false;
            }
        }

        private void 職員新規と変更_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_職員新規と変更Handle.iHandle = IntPtr.Zero;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
