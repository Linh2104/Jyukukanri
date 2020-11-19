using CCWin.SkinClass;
using ComDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public partial class 園児退園 : Form
    {
        #region 変数設定
        private string connectionString = ComClass.connectionString;
        //private string connectionString = "Data Source=DESKTOP-R5038PT\\SQLEXPRESS01;Initial Catalog=oa;Integrated Security=True";

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private byte[] UploadFileData = null;
        private string UploadFileName = string.Empty;
        private string UploadFileType = string.Empty;

        public bool isUpdate = false;
        public int code_園児;
        public string name_園児 = string.Empty;
        public string date_退園日 = string.Empty;

        private System.Data.DataTable selected_園児情報 = null;
        #endregion

        #region Main 処理
        public 園児退園()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期画面Load
        /// </summary>
        private void 園児退園_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                cmb_園児名前.Items.Add(string.Concat(code_園児.ToString(), "　", name_園児));
                cmb_園児名前.Enabled = false;
                dtp_退園日.Text = date_退園日;
                btn_登録.Text = "変更";

                string sqlcmd = string.Format(@"SELECT 
                                                 園児コード, 退園日, 退園事由
                                                FROM 
                                                 HL_JEC_園児退園情報
                                                WHERE 園児コード = '{0}'", code_園児);
                DataTable tblInfo = GetDatatable(sqlcmd);
                cmb_退園事由.SelectedItem = tblInfo.Rows[0]["退園事由"];
                //cmb_退園事由.SelectedIndex = 0;
                cmb_園児名前.SelectedIndex = 0;
            }
            else
            {
                FillDataToCMB();

                cmb_退園事由.SelectedIndex = 0;

                if (code_園児 != 0)
                {
                    cmb_園児名前.Text = string.Concat(code_園児.ToString(), "　", name_園児);
                    cmb_園児名前.Enabled = false;
                }
                else
                {
                    cmb_園児名前.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 画面が閉じる時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 園児退園_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_園児退園Handle.iHandle = IntPtr.Zero;
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

        private void FillDataToCMB()
        {
            string sqlcmd = string.Format(@"SELECT
                                             T1.園児コード,
                                             T1.名前,
                                             CONCAT(T1.園児コード, '　', T1.名前) as CodeName
                                            FROM
                                             HL_JEC_園児情報マスタ T1
                                            WHERE
                                             T1.退園日 IS NULL
                                            ORDER BY T1.名前");
            System.Data.DataTable cmbSource = GetDatatable(sqlcmd);
            cmb_園児名前.DisplayMember = "CodeName";
            cmb_園児名前.ValueMember = "園児コード";
            cmb_園児名前.DataSource = cmbSource;
        }

        #endregion

        #region CMB変更処理
        /// <summary>
        /// CMB退園事由の変更処理
        /// </summary>
        private void cmb_退園事由_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_退園事由.SelectedItem.ToString() == "その他")
            {
                txt_その他.Enabled = true;
            }
            else
            {
                txt_その他.Enabled = false;
                txt_その他.Text = "";
            }
        }

        /// <summary>
        /// CMB園児名前の変更処理
        /// </summary>
        private void cmb_園児名前_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if (isUpdate)
            {
                string sqlcmd = string.Format(@"SELECT 
                                                    a.園児コード,b.登園開始日, a.退園日, a.退園事由, a.保育事業利用終了ファイル名, a.備考
                                                FROM 
                                                    HL_JEC_園児退園情報 a
	                                                inner join
	                                                HL_JEC_園児情報マスタ b
                                                ON a.園児コード= b.園児コード
                                                WHERE 
                                                 a.園児コード = '{0}'", code_園児);
                selected_園児情報 = new System.Data.DataTable();
                selected_園児情報 = GetDatatable(sqlcmd);

                List<string> list_退園事由 = new List<string>() { "自己都合", "定年", "契約期間の満了", "移籍出向", "その他" };
                if (!list_退園事由.Contains(selected_園児情報.Rows[0]["退園事由"].ToString()))
                {
                    txt_その他.Text = selected_園児情報.Rows[0]["退園事由"].ToString();
                    txt_その他.Visible = true;
                    cmb_退園事由.SelectedIndex = 4;
                }
                txt_備考.Text = selected_園児情報.Rows[0]["備考"].ToString();
            }
            else
            {
                string sqlcmd = string.Format(@"SELECT 
                                                    a.園児コード,a.登園開始日
                                                FROM
                                                    HL_JEC_園児情報マスタ a
                                                 WHERE 
                                                    a.園児コード = '{0}'", cmb_園児名前.SelectedValue);
                selected_園児情報 = new System.Data.DataTable();
                selected_園児情報 = GetDatatable(sqlcmd);
            }
        }
        #endregion

        #region Button
        /// <summary>
        /// FilePath選択ボタン処理
        /// </summary>
        private void btn_選択_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            UploadFileData = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_保育事業利用終了ファイル.Text = Path.GetFullPath(openFileDialog.FileName);

                UploadFileData = File.ReadAllBytes(openFileDialog.FileName);
                UploadFileName = Path.GetFileName(openFileDialog.FileName);
                UploadFileType = Path.GetFileName(openFileDialog.FileName).Substring(Path.GetFileName(openFileDialog.FileName).LastIndexOf("."));

            }
        }

        /// <summary>
        /// キャンセルボタン処理
        /// </summary>
        private void btn_キャンセル_Click(object sender, EventArgs e)
        {
            ((Form1)(this.Tag)).m_園児退園Handle.iHandle = IntPtr.Zero;
            this.Close();
        }

        /// <summary>
        /// 登録・変更ボタン処理
        /// </summary>
        private void btn_登録_Click(object sender, EventArgs e)
        {
            code_園児 = isUpdate ? cmb_園児名前.Text.Substring(0, cmb_園児名前.Text.IndexOf("　")).ToInt32()
                                 : cmb_園児名前.SelectedValue.ToInt32();
            date_退園日 = dtp_退園日.Value.ToString("yyyy/MM/dd");
            string txt_退園事由 = (cmb_退園事由.SelectedIndex != 4) ? cmb_退園事由.SelectedItem.ToString() : txt_その他.Text;
            string txt備考 = txt_備考.Text;

            if (!CheckInput())
            {
                return;
            }

            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                sqlcon.Close();
                return;
            }
            SqlTransaction transaction = sqlcon.BeginTransaction();

            try
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlcon;
                sqlcom.Transaction = transaction;

                if (!isUpdate)
                {
                    //sqlcom.CommandText = string.Format(@"INSERT INTO HL_JEC_園児退園情報
                    //                                           (園児コード, 退園日, 退園事由, 
                    //                                           保育事業利用終了ファイル名, 保育事業利用終了ファイル, 備考)
                    //                                     VALUES
                    //                                           (@園児コード, @退園日, @退園事由, 
                    //                                            @保育事業利用終了ファイル名, @保育事業利用終了ファイル, @備考)");
                    //sqlcom.Parameters.AddWithValue("@園児コード", code_園児);
                    //sqlcom.Parameters.AddWithValue("@退園日", date_退園日);
                    //sqlcom.Parameters.AddWithValue("@退園事由", txt_退園事由);
                    //sqlcom.Parameters.AddWithValue("@保育事業利用終了ファイル名", UploadFileName);
                    //sqlcom.Parameters.AddWithValue("@保育事業利用終了ファイル", UploadFileData);
                    //sqlcom.Parameters.AddWithValue("@備考", txt備考);

                    sqlcom.CommandText = string.Format(@"INSERT INTO HL_JEC_保育園業務書類フォーマット
                                                               (ファイル名, ファイル, ファイルタイプ, 備考)
                                                         VALUES
                                                               (@ファイル名, @ファイル, @ファイルタイプ, @備考)");

                    sqlcom.Parameters.AddWithValue("@ファイルタイプ", "Excel");
                    sqlcom.Parameters.AddWithValue("@ファイル名", UploadFileName);
                    sqlcom.Parameters.AddWithValue("@ファイル", UploadFileData);
                    sqlcom.Parameters.AddWithValue("@備考", txt備考);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txt_保育事業利用終了ファイル.Text))
                    {
                        sqlcom.CommandText = string.Format(@"UPDATE HL_JEC_園児退園情報
                                                               SET  退園日= @退園日, 
                                                                    退園事由= @退園事由,
                                                                    保育事業利用終了ファイル名 = @保育事業利用終了ファイル名,
                                                                    保育事業利用終了ファイル = @保育事業利用終了ファイル,
                                                                    備考 = @備考
                                                            WHERE 園児コード = @園児コード");
                        sqlcom.Parameters.AddWithValue("@園児コード", code_園児);
                        sqlcom.Parameters.AddWithValue("@退園日", date_退園日);
                        sqlcom.Parameters.AddWithValue("@退園事由", txt_退園事由);
                        sqlcom.Parameters.AddWithValue("@保育事業利用終了ファイル名", UploadFileName);
                        sqlcom.Parameters.AddWithValue("@保育事業利用終了ファイル", UploadFileData);
                        sqlcom.Parameters.AddWithValue("@備考", txt備考);
                    }
                    else
                    {
                        sqlcom.CommandText = string.Format(@"UPDATE HL_JEC_園児退園情報
                                                               SET  退園日= @退園日, 
                                                                    退園事由= @退園事由,
                                                                    備考 = @備考
                                                            WHERE 園児コード = @園児コード");
                        sqlcom.Parameters.AddWithValue("@園児コード", code_園児);
                        sqlcom.Parameters.AddWithValue("@退園日", date_退園日);
                        sqlcom.Parameters.AddWithValue("@退園事由", txt_退園事由);
                        sqlcom.Parameters.AddWithValue("@備考", txt備考);
                    }
                }

                int result1 = sqlcom.ExecuteNonQuery();
                if (result1 == 1)
                {
                    //sqlcom.CommandText = string.Format(@"UPDATE HL_JEC_園児情報マスタ
                    //                            SET 退園日 = '{0}'
                    //                        WHERE 園児コード = '{1}'", date_退園日, code_園児);
                    //int result2 = sqlcom.ExecuteNonQuery();
                    //if (result2 == 1)
                    //{
                        transaction.Commit();
                        ((Form1)(Tag)).toolStripStatusLabel2.ForeColor = Color.Green;
                        ((Form1)(Tag)).toolStripStatusLabel2.Text = isUpdate ? string.Format("【{0}】さんの退園情報が正常に更新しました。", cmb_園児名前.Text)
                                                               : string.Format("【{0}】さんの退園情報が正常に登録しました。", cmb_園児名前.Text);
                        SendMessage(((Form1)(this.Tag)).m_園児情報一覧Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero).ToInt64();
                        this.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = isUpdate ? string.Format("【{0}】さんの更新処理に失敗しました。", cmb_園児名前.Text)
                                                     : string.Format("【{0}】さんの登録処理に失敗しました。", cmb_園児名前.Text);
            }
            finally
            {
                sqlcon?.Close();
            }
        }
        #endregion

        #region CheckInput
        private bool CheckInput()
        {
            string errMSG = string.Empty;

            if (dtp_退園日.Value < Convert.ToDateTime(selected_園児情報.Rows[0]["登園開始日"]))
            {
                errMSG = "退園日は入園日よりの過去日を記入できません。";
            }
            else if (cmb_退園事由.SelectedIndex == 4 && string.IsNullOrWhiteSpace(txt_その他.Text))
            {
                errMSG = "その他の退園事由を記入してください。";
            }
            else if (!isUpdate && string.IsNullOrWhiteSpace(txt_保育事業利用終了ファイル.Text))
            {
                errMSG = "保育事業利用終了ファイルを添付してください。";
            }
            if (!string.IsNullOrWhiteSpace(errMSG))
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = errMSG;
                return false;
            }
            return true;
        }
        #endregion

        #region Support処理

        /// <summary>
        /// 「必須」設定
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

                Font f = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

                int i = str.IndexOf("　[");
                string str_name = str.Substring(0, i);
                string str必須 = str.Substring(i, str.Length - i);

                for (int x = 0; x <= i; x++)
                {
                    if (x == i)
                    {
                        str必須 = " " + str必須;
                    }
                    else
                    {
                        str必須 = "   " + str必須;
                    }
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
        #endregion

    }
}
