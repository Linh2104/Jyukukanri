using ComDll;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public partial class 小口現金出納帳登録 : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private string connectionString = ComClass.connectionString;
        private string zandaka = "\0";
        public string currentID = string.Empty;
        public int executePattern;
        public string user = string.Empty;
        private string filename = string.Empty;
        private string kamoku = string.Empty;
        private bool fileChangeFlag = false;
        public bool update = false;
        public bool delete = false;
        public 小口現金出納帳登録()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクターの引数による画面分岐
        /// </summary>
        /// <param name="pattern">新規の場合：pattern = 1；変更の場合：pattern = 2</param>
        /// <param name="syutsnyukinID">一覧画面選択した行の出入金コード</param>
        public 小口現金出納帳登録(int pattern, string syutsnyukinID)
        {
            InitializeComponent();
            executePattern = pattern;
            currentID = syutsnyukinID;
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 小口現金出納帳登録_Load(object sender, EventArgs e)
        {
            SetKamokuComboxList();
            if (currentID != string.Empty)
            {
                executePattern = 2;
                btn_insert.Visible = false;
                btn_update.Visible = true;
                btn_delete.Visible = true;
                this.Text = "小口現金出納帳変更";
                SetChangeData(currentID);
            }
            else
            {
                btn_insert.Visible = true;
                btn_update.Visible = false;
                btn_delete.Visible = false;
                user = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
                executePattern = 1;
                this.Text = "小口現金出納帳登録";
                //残高、勘定科目コンボボックス値を設定する
                SetZandaka();
            }
        }

        /// <summary>
        /// 画面リフレッシュ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 小口現金出納帳登録_Refresh()
        {
            if (executePattern == 2)
            {
                this.Close();
            }
            else
            {
                dtp_date.Value = DateTime.Now;
                txt_kingaku.Text = string.Empty;
                txt_file.Text = string.Empty;
                SetZandaka();
                SetKamokuComboxList();
                if (chk_nyuukin.Checked == true)
                {
                    txt_bikou.Text = string.Empty;
                }
                else
                {
                    txt_tekiyou.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// 変更画面初期設定
        /// </summary>
        public void SetChangeData(string currentID)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_errorMessage.Text = "サーバとの接続に失敗しました、インターネット接続を確認してください。.";
                lbl_errorMessage.ForeColor = Color.Red;
                return;
            }
            try
            {
                string str_sqlcmd = "SELECT * FROM HL_JEC_小口現金出納帳 WHERE 出入金コード=" + currentID;
                SqlDataAdapter sqlDa = new SqlDataAdapter(str_sqlcmd, sqlcon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                dtp_date.Value = Convert.ToDateTime(dt.Rows[0]["日付"]);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["入金"].ToString()))
                {
                    filename = dt.Rows[0]["入金申請書名称"].ToString();
                    chk_nyuukin.Checked = true;
                    chk_syukkin.Checked = false;
                    chk_syukkin.Enabled = false;
                    chk_nyuukin.Enabled = false;
                    txt_bikou.Text = dt.Rows[0]["備考"].ToString();
                    txt_kingaku.Text = dt.Rows[0]["入金"].ToString();
                    txt_file.Text = dt.Rows[0]["入金申請書名称"].ToString();
                }
                else
                {
                    filename = dt.Rows[0]["出金証明書名称"].ToString();
                    chk_nyuukin.Checked = false;
                    chk_syukkin.Checked = true;
                    chk_syukkin.Enabled = false;
                    chk_nyuukin.Enabled = false;
                    cmb_kamoku.Text = dt.Rows[0]["勘定科目"].ToString();
                    txt_tekiyou.Text = dt.Rows[0]["摘要"].ToString();
                    txt_kingaku.Text = dt.Rows[0]["出金"].ToString();
                    txt_file.Text = dt.Rows[0]["出金証明書名称"].ToString();
                }
                txt_zandaka.Text = dt.Rows[0]["残高"].ToString();
                zandaka = dt.Rows[0]["残高"].ToString();
            }
            catch (Exception ex)
            {
                lbl_errorMessage.Text = "変更画面初期設定が失敗しました." + ex.Message;
                lbl_errorMessage.ForeColor = Color.Red;
            }
            sqlcon.Close();
        }

        /// <summary>
        /// 残高値を設定する
        /// </summary>
        public void SetZandaka()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_errorMessage.Text = "サーバとの接続に失敗しました、インターネット接続を確認してください。.";
                lbl_errorMessage.ForeColor = Color.Red;
                return;
            }
            try
            {
                string str_sqlcmd = "SELECT top 1 出入金コード,残高 FROM HL_JEC_小口現金出納帳 ORDER BY 出入金コード desc";
                SqlDataAdapter sqlDa = new SqlDataAdapter(str_sqlcmd, sqlcon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                txt_zandaka.Text = dt.Rows[0]["残高"].ToString();
                zandaka = dt.Rows[0]["残高"].ToString();

                if (executePattern == 1)
                {
                    currentID = ComClass.KinngakuAdd(dt.Rows[0]["出入金コード"].ToString(), "1");
                }
            }
            catch (Exception ex)
            {
                lbl_errorMessage.Text = "残高の設定が失敗しました." + ex.Message;
                lbl_errorMessage.ForeColor = Color.Red;
            }
            sqlcon.Close();
        }

        /// <summary>
        /// 勘定科目コンボボックス値を設定する
        /// </summary>
        public void SetKamokuComboxList()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            try
            {
                sqlcon.Open();
            }
            catch
            {
                lbl_errorMessage.Text = "サーバとの接続に失敗しました、インターネット接続を確認してください。.";
                lbl_errorMessage.ForeColor = Color.Red;
                return;
            }
            try
            {
                string str_sqlcmd = "SELECT 勘定項目コード,勘定項目名 FROM HL_JEC_勘定項目 ORDER BY 勘定項目コード";
                SqlDataAdapter sqlDa = new SqlDataAdapter(str_sqlcmd, sqlcon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                DataRow dr = dt.NewRow();
                dr["勘定項目コード"] = "0";
                dr["勘定項目名"] = "ほか";
                dt.Rows.InsertAt(dr, 0);
                cmb_kamoku.DisplayMember = "勘定項目名";
                cmb_kamoku.ValueMember = "勘定項目コード";
                cmb_kamoku.DataSource = dt;
                cmb_kamoku.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                lbl_errorMessage.Text = "勘定項目の設定が失敗しました." + ex.Message;
                lbl_errorMessage.ForeColor = Color.Red;
            }
            sqlcon.Close();

            if (cmb_kamoku.Items.Count == 0)
            {
                lbl_errorMessage.Text = "勘定項目の取得が失敗しました.";
                lbl_errorMessage.ForeColor = Color.Red;
                return;
            }
        }

        /// <summary>
        /// 入金チェック変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_nyuukin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_nyuukin.Checked == false)
            {
                chk_syukkin.Checked = true;
                lbl_kamoku.Visible = true;
                cmb_kamoku.Visible = true;
                lbl_tekiyou.Visible = true;
                txt_tekiyou.Visible = true;
                lbl_bikou.Visible = false;
                txt_bikou.Visible = false;
                lbl_syukkinsyo.Visible = true;
                lbl_nyuukinsyo.Visible = false;
                lbl_kingaku.Location = new System.Drawing.Point(30, 220);
                txt_kingaku.Location = new System.Drawing.Point(250, 220);
                lbl_zandaka.Location = new System.Drawing.Point(440, 220);
                txt_zandaka.Location = new System.Drawing.Point(520, 220);
                txt_file.Location = new System.Drawing.Point(250, 270);
                btn_file.Location = new System.Drawing.Point(440, 270);
            }
            else
            {
                chk_syukkin.Checked = false;
                lbl_kamoku.Visible = false;
                cmb_kamoku.Visible = false;
                lbl_tekiyou.Visible = false;
                txt_tekiyou.Visible = false;
                lbl_bikou.Visible = true;
                txt_bikou.Visible = true;
                lbl_syukkinsyo.Visible = false;
                lbl_nyuukinsyo.Visible = true;
                lbl_kingaku.Location = new System.Drawing.Point(30, 170);
                txt_kingaku.Location = new System.Drawing.Point(250, 170);
                lbl_zandaka.Location = new System.Drawing.Point(440, 170);
                txt_zandaka.Location = new System.Drawing.Point(520, 170);
                txt_file.Location = new System.Drawing.Point(250, 220);
                btn_file.Location = new System.Drawing.Point(440, 220);
            }
        }

        /// <summary>
        /// 出金チェック変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_syukkin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_syukkin.Checked == true)
            {
                chk_nyuukin.Checked = false;
                lbl_kamoku.Visible = true;
                cmb_kamoku.Visible = true;
                lbl_tekiyou.Visible = true;
                txt_tekiyou.Visible = true;
                lbl_bikou.Visible = false;
                txt_bikou.Visible = false;
                lbl_syukkinsyo.Visible = true;
                lbl_nyuukinsyo.Visible = false;
                lbl_kingaku.Location = new System.Drawing.Point(30, 220);
                txt_kingaku.Location = new System.Drawing.Point(250, 220);
                lbl_zandaka.Location = new System.Drawing.Point(440, 220);
                txt_zandaka.Location = new System.Drawing.Point(520, 220);
                txt_file.Location = new System.Drawing.Point(250, 270);
                btn_file.Location = new System.Drawing.Point(440, 270);
            }
            else
            {
                chk_nyuukin.Checked = true;
                lbl_kamoku.Visible = false;
                cmb_kamoku.Visible = false;
                lbl_tekiyou.Visible = false;
                txt_tekiyou.Visible = false;
                lbl_bikou.Visible = true;
                txt_bikou.Visible = true;
                lbl_syukkinsyo.Visible = false;
                lbl_nyuukinsyo.Visible = true;
                lbl_kingaku.Location = new System.Drawing.Point(30, 170);
                txt_kingaku.Location = new System.Drawing.Point(250, 170);
                lbl_zandaka.Location = new System.Drawing.Point(440, 170);
                txt_zandaka.Location = new System.Drawing.Point(520, 170);
                txt_file.Location = new System.Drawing.Point(250, 220);
                btn_file.Location = new System.Drawing.Point(440, 220);
            }
        }

        private void KamokuInsert()
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
                DataUpdateCmd.CommandText = string.Format(@"insert into HL_JEC_勘定項目 (勘定項目名) values ('{0}')", txt_kamoku.Text);
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
            }
            catch
            {
                transaction?.Rollback();
                connection?.Close();
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = "勘定科目の登録は失敗しました。";
            }
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (InputCheck())
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
                    if (txt_kamoku.Visible == true)
                    {
                        KamokuInsert();
                        kamoku = txt_kamoku.Text;
                    }
                    if (chk_nyuukin.Checked == true)
                    {
                        DataUpdateCmd.CommandText = string.Format(@"insert into HL_JEC_小口現金出納帳 (出入金コード,日付,備考,入金,残高,作成者,作成日時) Values ({0},'{1}','{2}','{3}','{4}','{5}','{6}')", Convert.ToInt16(currentID), dtp_date.Value, txt_bikou.Text, ComClass.KinngageToNum(txt_kingaku.Text), ComClass.KinngageToNum(txt_zandaka.Text), user, DateTime.Now);
                    }
                    else if (chk_syukkin.Checked == true)
                    {
                        DataUpdateCmd.CommandText = string.Format(@"insert into HL_JEC_小口現金出納帳 (出入金コード,日付,勘定科目,摘要,出金,残高,作成者,作成日時) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", Convert.ToInt16(currentID), dtp_date.Value, kamoku, txt_tekiyou.Text, ComClass.KinngageToNum(txt_kingaku.Text), ComClass.KinngageToNum(txt_zandaka.Text), user, DateTime.Now);
                    }
                    int AdaptedRows = DataUpdateCmd.ExecuteNonQuery();
                    if (AdaptedRows == 0)
                    {
                        error++;
                    }
                    if (chk_nyuukin.Checked == true)
                    {
                        FileUpload(txt_file.Text, "入金申請書", connection, transaction, ref error);
                    }
                    else if (chk_syukkin.Checked == true)
                    {
                        FileUpload(txt_file.Text, "出金証明書", connection, transaction, ref error);
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
                    SetZandaka();
                    SetKamokuComboxList();
                    lbl_errorMessage.ForeColor = Color.Green;
                    lbl_errorMessage.Text = "小口現金出納帳を登録しました。";
                    小口現金出納帳登録_Refresh();
                }
                catch
                {
                    transaction?.Rollback();
                    connection?.Close();
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "小口現金出納帳の登録は失敗しました。";
                }
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (InputCheck())
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
                    if (txt_kamoku.Visible == true)
                    {
                        KamokuInsert();
                        kamoku = txt_kamoku.Text;
                    }
                    if (chk_nyuukin.Checked == true)
                    {
                        DataUpdateCmd.CommandText = string.Format(@"update HL_JEC_小口現金出納帳 set 日付= '{0}' , 備考= '{1}' , 入金= '{2}', 残高= '{3}', 更新者= '{4}', 更新日時= '{5}' where 出入金コード={6}", dtp_date.Value, txt_bikou.Text, ComClass.KinngageToNum(txt_kingaku.Text), ComClass.KinngageToNum(txt_zandaka.Text), user, DateTime.Now, Convert.ToInt32(currentID));
                    }
                    else if (chk_syukkin.Checked == true)
                    {
                        DataUpdateCmd.CommandText = string.Format(@"update HL_JEC_小口現金出納帳 set 日付= '{0}' , 勘定科目= '{1}' , 摘要= '{2}' , 出金= '{3}', 残高= '{4}', 更新者= '{5}', 更新日時= '{6}' where 出入金コード={7}", dtp_date.Value, kamoku, txt_tekiyou.Text, ComClass.KinngageToNum(txt_kingaku.Text), ComClass.KinngageToNum(txt_zandaka.Text), user, DateTime.Now, Convert.ToInt32(currentID));
                    }
                    int AdaptedRows = DataUpdateCmd.ExecuteNonQuery();
                    if (AdaptedRows == 0)
                    {
                        error++;
                    }
                    if(fileChangeFlag == true)
                    {
                        if (chk_nyuukin.Checked == true)
                        {
                            FileUpload(txt_file.Text, "入金申請書", connection, transaction, ref error);
                        }
                        else if (chk_syukkin.Checked == true)
                        {
                            FileUpload(txt_file.Text, "出金証明書", connection, transaction, ref error);
                        }
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
                    update = true;
                    小口現金出納帳登録_Refresh();
                }
                catch
                {
                    transaction?.Rollback();
                    connection?.Close();
                    lbl_errorMessage.ForeColor = Color.Red;
                    lbl_errorMessage.Text = "小口現金出納帳の更新は失敗しました。";
                }
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
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
                DataUpdateCmd.CommandText = string.Format("update HL_JEC_小口現金出納帳 set 削除フラグ= '1' where 出入金コード=" + currentID);
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
                delete = true;
                小口現金出納帳登録_Refresh();
            }
            catch
            {
                transaction?.Rollback();
                connection?.Close();
                lbl_errorMessage.ForeColor = Color.Red;
                lbl_errorMessage.Text = "小口現金出納帳の削除は失敗しました。";
            }
        }

        /// <summary>
        /// 勘定科目コンボボックス値変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_kamoku_SelectedValueChanged(object sender, EventArgs e)
        {
            kamoku = cmb_kamoku.Text;
            if (chk_syukkin.Checked == true && cmb_kamoku.SelectedValue != null && cmb_kamoku.SelectedValue.ToString() == "0")
            {
                txt_kamoku.Visible = true;
            }
            else
            {
                txt_kamoku.Visible = false;
            }
        }

        /// <summary>
        /// ファイル選択クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_file_Click(object sender, EventArgs e)
        {
            txt_file.Text = GetFilePath();
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
                string[] str = new string[] { ".pdf", ".xls", ".xlsx" };
                if (!((IList)str).Contains(ex))
                {
                    lbl_errorMessage.Text = "PDF/Excelファイルを選択してください。";
                    lbl_errorMessage.ForeColor = Color.Red;
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

                if (chk_nyuukin.Checked == true)
                {
                    FileUploadCmd.CommandText = string.Format(@"update  HL_JEC_小口現金出納帳  set 入金申請書 = @file , 入金申請書名称 = '{0}' where 出入金コード = {1}", Path.GetFileName(FilePath), Convert.ToInt32(currentID));
                }
                else if (chk_syukkin.Checked == true)
                {
                    FileUploadCmd.CommandText = string.Format(@"update  HL_JEC_小口現金出納帳  set 出金証明書 = @file , 出金証明書名称 = '{0}' where 出入金コード = {1}", Path.GetFileName(FilePath), Convert.ToInt32(currentID));
                }

                SqlParameter spFile = new SqlParameter("@file", SqlDbType.Image);
                spFile.Value = bytes;
                FileUploadCmd.Parameters.Add(spFile);
                int AdaptedRows = FileUploadCmd.ExecuteNonQuery();
                if (AdaptedRows == 0)
                {
                    error++;
                    lbl_errorMessage.Text += string.Format("{0}アップロード失敗しました", FileType);
                }

            }
            catch (Exception)
            {
                error++;
                lbl_errorMessage.Text += string.Format("{0}アップロード失敗しました", FileType);
            }
        }

        /// <summary>
        /// 入力チェック枠、既存データチェック
        /// </summary>
        /// <returns></returns>
        private bool InputCheck()
        {
            if (string.IsNullOrWhiteSpace(txt_kingaku.Text.Replace("￥", "")))
            {
                lbl_errorMessage.Text = "金額を入力してください。";
                lbl_errorMessage.ForeColor = Color.Red;
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt_file.Text))
            {
                lbl_errorMessage.Text = "アップロードファイルを選択してください。";
                lbl_errorMessage.ForeColor = Color.Red;
                return false;
            }
            else if (chk_syukkin.Checked == true && cmb_kamoku.SelectedIndex == -1)
            {
                lbl_errorMessage.Text = "勘定科目を入力してください。";
                lbl_errorMessage.ForeColor = Color.Red;
                return false;
            }
            else if (chk_syukkin.Checked == true && txt_kamoku.Visible == true && string.IsNullOrWhiteSpace(txt_kamoku.Text))
            {
                lbl_errorMessage.Text = "勘定科目を入力してください。";
                lbl_errorMessage.ForeColor = Color.Red;
                return false;
            }
            else if (chk_syukkin.Checked == true && string.IsNullOrWhiteSpace(txt_tekiyou.Text))
            {
                lbl_errorMessage.Text = "摘要を入力してください。";
                lbl_errorMessage.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        /// <summary>
        /// ラベル文字色設定
        /// </summary>
        private void lbl_必須_Paint(object sender, PaintEventArgs e)
        {
            Label strLbl = (Label)sender;
            string str = strLbl.Text;

            if (str.Contains("必須"))
            {
                strLbl.ForeColor = Color.FromArgb(240, 240, 240);

                Font f = new Font("メイリオ", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(128)));

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

        private void txt_kingaku_Validated(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ComClass.numToKinngake(((TextBox)sender).Text);
        }

        private void txt_kingaku_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ComClass.numToKinngake(((TextBox)sender).Text);
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            if (chk_nyuukin.Checked == true)
            {
                txt_zandaka.Text = ComClass.KinngakuAdd(zandaka, ((TextBox)sender).Text);
            }
            else
            {
                txt_zandaka.Text = ComClass.KinngakuSub(zandaka, ((TextBox)sender).Text);
            }
        }

        private void txt_zandaka_Validated(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ComClass.numToKinngake(((TextBox)sender).Text);
        }

        private void txt_zandaka_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ComClass.numToKinngake(((TextBox)sender).Text);
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }

        private void txt_file_TextChanged(object sender, EventArgs e)
        {
            if (executePattern == 2 && txt_file.Text != filename)
            {
                fileChangeFlag = true;
            }
        }

        private void 小口現金出納帳登録_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(executePattern == 1)
            {
                ((Form1)(this.Tag)).m_小口現金出納帳Handle.iHandle = IntPtr.Zero;
            }
        }
    }
}