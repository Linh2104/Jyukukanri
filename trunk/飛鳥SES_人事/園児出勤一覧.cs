using CCWin.SkinClass;
using ComDll;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace 飛鳥SES_人事
{
    public partial class 園児出勤一覧 : DockContent
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        //データベース接続情報
        private string connectionString = ComClass.connectionString;
        //園児
        private string child = string.Empty;
        //園児コード
        private string childcode = string.Empty;
        //園児名前
        private string childname = string.Empty;
        //タイトル名
        private string headertext = string.Empty;
        //日付
        private string date = string.Empty;
        //時間
        private string time = string.Empty;
        //変更前の値
        private string beforevalue = string.Empty;
        //変更後の値
        private string aftervalue = string.Empty;
        //編集フラッグ
        private bool change = false;
        //健康状況観察デフォルト
        private string consent = "機嫌-普通,しっしん-無,せき・はなみず-無";

        public 園児出勤一覧()
        {
            InitializeComponent();
        }


        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case ComClass.CUSTOM_MESSAGE:
                    {
                        DisplayGridView_園児出勤一覧();
                    }
                    break;

                default:
                    base.WndProc(ref msg);
                    break;
            }
        }

        private void 園児出勤一覧_Load(object sender, EventArgs e)
        {
            DisplayGridView_園児出勤一覧();
        }

        /// <summary>
        /// girdview検索、更新
        /// </summary>
        private void DisplayGridView_園児出勤一覧()
        {
            SqlConnection sqlcon = SQLLinkTest();
            if (sqlcon == null)
            {
                return;
            }

            string str_sqlcmd = string.Format(@"Select 
                                                    b.園児コード
                                                    , b.名前
                                                    , a.登園時間
                                                    , a.降園時間
                                                    , c.体温
                                                    , c.チェック項目
                                                    , a.欠勤
                                                    , a.早退
                                                    , a.遅刻
                                                    , a.備考
                                                From
                                                    HL_JEC_園児出勤一覧 As a
                                                    Right Join HL_JEC_園児情報マスタ As b
                                                       On a.園児コード = b.園児コード
                                                       And a.日付 = '{0}'
                                                    Left Join HL_JEC_園児健康状況観察 As c
                                                       On b.園児コード = c.園児コード
                                                       And c.日付 = '{0}'
                                                Order By
                                                    b.園児コード", datetime.Value.ToShortDateString());

            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
            gv_出勤一覧.Rows.Clear();

            int index = 0;
            try
            {
                while (reader.Read())
                {
                    if (
                        (reader["名前"].ToString().IndexOf(this.txt_検索.Text) < 0)
                        &&
                        (reader["園児コード"].ToString().IndexOf(this.txt_検索.Text) < 0)
                        &&
                        (reader["欠勤"].ToString().IndexOf(this.txt_検索.Text) < 0)
                        &&
                        (reader["早退"].ToString().IndexOf(this.txt_検索.Text) < 0)
                        &&
                        (reader["遅刻"].ToString().IndexOf(this.txt_検索.Text) < 0)
                        &&
                        (reader["備考"].ToString().IndexOf(this.txt_検索.Text) < 0)
                        )
                    {
                        continue;
                    }

                    DataGridViewRow tempRow = new DataGridViewRow();

                    tempRow.CreateCells(gv_出勤一覧);
                    tempRow.Cells[gv_出勤一覧.Columns["園児名"].Index].Value = reader["園児コード"].ToString() + " " + reader["名前"].ToString() ;
                    tempRow.Cells[gv_出勤一覧.Columns["園児名"].Index].ReadOnly = true;

                    //欠勤の場合、備考以外のセルが編集不可
                    if (!string.IsNullOrWhiteSpace(reader["欠勤"].ToString()))
                    {
                        tempRow.Cells[gv_出勤一覧.Columns["体温"].Index].Style.BackColor = Color.White;
                        tempRow.Cells[gv_出勤一覧.Columns["健康状況観察"].Index].Style.BackColor = Color.White;
                        tempRow.Cells[gv_出勤一覧.Columns["早退"].Index].Style.BackColor = Color.White;
                        tempRow.Cells[gv_出勤一覧.Columns["遅刻"].Index].Style.BackColor = Color.White;

                        tempRow.Cells[gv_出勤一覧.Columns["体温"].Index].ReadOnly = true;
                        tempRow.Cells[gv_出勤一覧.Columns["健康状況観察"].Index].ReadOnly = true;
                        tempRow.Cells[gv_出勤一覧.Columns["早退"].Index].ReadOnly = true;
                        tempRow.Cells[gv_出勤一覧.Columns["遅刻"].Index].ReadOnly = true;

                        tempRow.Cells[gv_出勤一覧.Columns["欠勤"].Index].Value = reader["欠勤"].ToString();
                    }
                    else
                    {
                        //登園時間のセルに情報がある場合、textboxに変更し、欠勤不可。
                        if (!string.IsNullOrWhiteSpace(reader["登園時間"].ToString()) && reader["登園時間"].ToString() != "00:00:00")
                        {
                            tempRow.Cells[gv_出勤一覧.Columns["登園時間"].Index] = new DataGridViewTextBoxCell();
                            tempRow.Cells[gv_出勤一覧.Columns["登園時間"].Index].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            tempRow.Cells[gv_出勤一覧.Columns["登園時間"].Index].Value = reader["登園時間"].ToString().Substring(0, 5);

                            tempRow.Cells[gv_出勤一覧.Columns["欠勤"].Index].ReadOnly = true;
                            tempRow.Cells[gv_出勤一覧.Columns["欠勤"].Index].Style.BackColor = Color.White;
                        }

                        //降園時間のセルに情報がある場合、textboxに変更する。
                        if (!string.IsNullOrWhiteSpace(reader["降園時間"].ToString()) && reader["降園時間"].ToString() != "00:00:00")
                        {
                            tempRow.Cells[gv_出勤一覧.Columns["降園時間"].Index] = new DataGridViewTextBoxCell();
                            tempRow.Cells[gv_出勤一覧.Columns["降園時間"].Index].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            tempRow.Cells[gv_出勤一覧.Columns["降園時間"].Index].Value = reader["降園時間"].ToString().Substring(0, 5);
                        }
                    }

                    string bodyTemp = reader["体温"].ToString();
                    bodyTemp = !bodyTemp.EndsWith(",") ? bodyTemp + "," : bodyTemp;
                    tempRow.Cells[gv_出勤一覧.Columns["体温"].Index].Value = !string.IsNullOrWhiteSpace(bodyTemp) ? MidStrEx_New(bodyTemp, "-", ",") : bodyTemp;
                    tempRow.Cells[gv_出勤一覧.Columns["体温原本"].Index].Value = reader["体温"].ToString();
                    tempRow.Cells[gv_出勤一覧.Columns["健康状況観察"].Index].Value = !string.IsNullOrWhiteSpace(reader["チェック項目"].ToString()) ? reader["チェック項目"].ToString() : consent;

                    tempRow.Cells[gv_出勤一覧.Columns["早退"].Index].Value = reader["早退"].ToString();
                    tempRow.Cells[gv_出勤一覧.Columns["遅刻"].Index].Value = reader["遅刻"].ToString();
                    tempRow.Cells[gv_出勤一覧.Columns["備考"].Index].Value = reader["備考"].ToString();

                    this.gv_出勤一覧.Rows.Add(tempRow);
                    index++;
                }
            }
            catch (Exception ex)
            {
                sslbl_メッセージ.ForeColor = Color.Red;
                sslbl_メッセージ.Text = "検索処理が失敗しました。" + ex.Message;
            }
            finally
            {
                reader?.Close();
                sqlcon?.Close();
            }

            this.sslbl_件数.Text = string.Format("{0}件", index);
            this.btn_検索.Focus();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_検索_Click(object sender, EventArgs e)
        {
            sslbl_メッセージ.Text = string.Empty;
            DisplayGridView_園児出勤一覧();
        }

        private void 園児出勤一覧_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_園児出勤一覧Handle.iHandle = IntPtr.Zero;
        }

        /// <summary>
        /// 右クリックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_出勤一覧_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    gv_出勤一覧.CurrentCell = clickedCell;
                    headertext = clickedCell.OwningColumn.HeaderText;
                    child = gv_出勤一覧.CurrentRow.Cells["園児名"].Value.ToString().Trim();
                    childcode = child.Substring(0, child.IndexOf(" "));

                    var relativeMousePosition = gv_出勤一覧.PointToClient(Cursor.Position);
                    contextMenuStrip1.Show(gv_出勤一覧, relativeMousePosition);
                }
            }
        }

        /// <summary>
        /// 一行のみ選択できる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_出勤一覧_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (gv_出勤一覧.Rows[e.RowIndex].Selected == false)
                    {
                        gv_出勤一覧.ClearSelection();
                        gv_出勤一覧.Rows[e.RowIndex].Selected = true;
                    }

                    if (gv_出勤一覧.SelectedRows.Count == 1)
                    {
                        gv_出勤一覧.CurrentCell = gv_出勤一覧.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                }
            }
        }

        /// <summary>
        /// セル内の値が変わる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_出勤一覧_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (change != true)
            {
                return;
            }

            child = gv_出勤一覧.CurrentRow.Cells["園児名"].Value.ToString().Trim();
            childcode = child.Substring(0, child.IndexOf(" "));
            childname = child.Substring(child.IndexOf(" ") + 1, child.Length - child.IndexOf(" ") - 1);
            headertext = gv_出勤一覧.Columns[gv_出勤一覧.CurrentCell.ColumnIndex].HeaderText;
            date = datetime.Value.Date.ToShortDateString();
            time = DateTime.Now.ToString("HH:mm");

            if (gv_出勤一覧.CurrentCell.Value != null)
            {
                aftervalue = gv_出勤一覧.CurrentCell.EditedFormattedValue.ToString().Trim();

                //登園、降園ボタンの場合は自動的にTime入力
                if (headertext == "登園時間" || headertext == "降園時間")
                {
                    if (gv_出勤一覧.CurrentCell.Value.ToString() == "登園" || gv_出勤一覧.CurrentCell.Value.ToString() == "降園")
                    {
                        aftervalue = time;
                    }
                    if (!string.IsNullOrWhiteSpace(aftervalue))
                    {
                        if (!IsTime(aftervalue))
                        {
                            sslbl_メッセージ.ForeColor = Color.Red;
                            sslbl_メッセージ.Text = string.Format(@"{0}のフォーマットが間違っています。", headertext);
                            return;
                        }
                    }
                }
            }
            else
            {
                aftervalue = string.Empty;
            }

            //変更前と変更後の値が同じの場合
            if (aftervalue == beforevalue)
            {
                return;
            }

            if (headertext == "体温℃" && !Is数字(aftervalue))
            {
                sslbl_メッセージ.ForeColor = Color.Red;
                sslbl_メッセージ.Text = "体温は数字のみを入力してください!";
                return;
            }

            SqlConnection sqlcon = SQLLinkTest();
            if (sqlcon == null)
            {
                return;
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            try
            {
                //体温セルは園児健康状況観察表へ
                if (headertext == "体温℃")
                {
                    string bodyTemp = gv_出勤一覧.CurrentRow.Cells["体温原本"].Value.ToString();
                    
                    if (!string.IsNullOrWhiteSpace(bodyTemp))
                    {
                        bodyTemp = !bodyTemp.EndsWith(",") ? bodyTemp + "," : bodyTemp;
                        int ii = bodyTemp.IndexOf('-');
                        int iu = bodyTemp.IndexOf(',');
                        string temp1 = bodyTemp.Substring(0, ii + 1);
                        string temp2 = bodyTemp.Substring(iu, bodyTemp.Length - iu);
                        aftervalue = temp1 + aftervalue + temp2;
                        aftervalue = aftervalue.EndsWith(",") ? aftervalue.Substring(0, aftervalue.Length - 1) : aftervalue;
                    }
                    else
                    {
                        aftervalue = time + "-" + aftervalue;
                    }

                    sqlcom.CommandText = string.Format(@"If Not Exists (Select 1 From HL_JEC_園児健康状況観察
                                                         Where 園児コード = {0} And 日付 = '{1}')
                                                         Insert Into HL_JEC_園児健康状況観察 (園児コード, 日付, 体温, チェック項目, 排便) 
                                                         Values ({0}, '{1}', '{2}', N'{3}', '軟便-0,普通-0,硬便-0') Else
                                                         Update HL_JEC_園児健康状況観察 Set 体温 = '{2}'
                                                         Where 園児コード = {0} And 日付 = '{1}'", childcode, date, aftervalue, consent);
                }
                //体温セル以外は園児出勤一覧へ
                else
                {
                    sqlcom.CommandText = string.Format(@"If Not Exists (Select 1 From HL_JEC_園児出勤一覧
                                                         Where 園児コード = {0} And 日付 = '{1}')
                                                         Insert Into HL_JEC_園児出勤一覧 (園児コード, 日付, {3})
                                                         Values ({0}, '{1}', '{2}') Else
                                                         Update HL_JEC_園児出勤一覧 Set {3} = '{2}'
                                                         Where 園児コード = {0} And 日付 = '{1}'", childcode, date, aftervalue, headertext);
                }

                if (sqlcom.ExecuteNonQuery() == 1)
                {
                    transaction.Commit();
                    sslbl_メッセージ.ForeColor = Color.Green;
                    sslbl_メッセージ.Text = string.Format(@"{0}の{1}が処理されました。", childname, headertext);

                    if (((Form1)(this.Tag)).m_健康診断Handle != null)
                    {
                        SendMessage(((Form1)(this.Tag)).m_健康診断Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                    }
                }
                else
                {
                    transaction.Rollback();
                    sslbl_メッセージ.ForeColor = Color.Red;
                    sslbl_メッセージ.Text = string.Format(@"{0}の{1}の処理が失敗しました。", childname, headertext);
                }
            }
            catch
            {
                transaction.Rollback();
                sslbl_メッセージ.ForeColor = Color.Red;
                sslbl_メッセージ.Text = string.Format(@"{0}の{1}の処理が失敗しました。", childname, headertext);
            }
            finally
            {
                sqlcon?.Close();
            }
            
            change = false;
            DisplayGridView_園児出勤一覧();
        }

　　　　/// <summary>
        /// セル内容が変更する前に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_出勤一覧_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            change = true;
            beforevalue = gv_出勤一覧.CurrentCell.Value == null ? string.Empty : gv_出勤一覧.CurrentCell.Value.ToString();
        }

        /// <summary>
        /// 登園、降園処理（登録、降園情報が登録されていない場合）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_出勤一覧_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            child = gv_出勤一覧.CurrentRow.Cells["園児名"].Value.ToString().Trim();
            childcode = child.Substring(0, child.IndexOf(" "));
            childname = child.Substring(child.IndexOf(" ") + 1, child.Length - child.IndexOf(" ") - 1);
            headertext = gv_出勤一覧.Columns[gv_出勤一覧.CurrentCell.ColumnIndex].HeaderText;
            date = datetime.Value.Date.ToShortDateString();
            time = DateTime.Now.ToString("HH:mm");

            //該当するセルはreturn
            if (headertext == "園児名" || headertext == "体温℃" || headertext == "備考" ||
                headertext == "欠勤" || headertext == "早退" || headertext == "遅刻")
            {
                return;
            }

            if (headertext == "健康状況観察")
            {
                //体温がない場合は変更できない
                if (string.IsNullOrWhiteSpace(gv_出勤一覧.CurrentRow.Cells["体温"].Value.ToString()))
                {
                    sslbl_メッセージ.ForeColor = Color.Red;
                    sslbl_メッセージ.Text = string.Format(@"{0}の体温を追加してから{1}の変更が可能になります。", childname, headertext);
                    return;
                }

                健康状況観察 m_NewForm健康状況観察 = new 健康状況観察();
                m_NewForm健康状況観察.value = gv_出勤一覧.CurrentRow.Cells["健康状況観察"].Value.ToString().Trim();
                m_NewForm健康状況観察.childcode = childcode;
                m_NewForm健康状況観察.date = date;
                m_NewForm健康状況観察.StartPosition = FormStartPosition.CenterParent;
                m_NewForm健康状況観察.ShowDialog();

                switch (m_NewForm健康状況観察.result)
                {
                    case 0:
                        sslbl_メッセージ.ForeColor = Color.Red;
                        sslbl_メッセージ.Text = "DBサーバーの接続が失敗しました。";
                        break;
                    case 1:
                        sslbl_メッセージ.ForeColor = Color.Green;
                        sslbl_メッセージ.Text = string.Format(@"{0}の{1}が変更しました。", childname, headertext);

                        if (((Form1)(this.Tag)).m_健康診断Handle != null)
                        {
                            SendMessage(((Form1)(this.Tag)).m_健康診断Handle.iHandle, ComClass.CUSTOM_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                        }
                        break;
                    case 2:
                        sslbl_メッセージ.ForeColor = Color.Red;
                        sslbl_メッセージ.Text = string.Format(@"{0}の{1}の変更が失敗しました。", childname, headertext);
                        break;
                    case 3:
                        sslbl_メッセージ.ForeColor = Color.Black;
                        sslbl_メッセージ.Text = string.Empty;
                        break;
                }

                m_NewForm健康状況観察.Dispose();
                DisplayGridView_園児出勤一覧();
                return;
            }

            //登園時間、降園時間セル
            SqlConnection sqlcon = SQLLinkTest();
            if (sqlcon == null)
            {
                return;
            }

            try
            {
                //該当園児がその日に欠勤するかどうかを確認する。欠勤の場合、登園、降園不可。
                string sqlcmd = string.Format(@"Select ISNULL((Select Top(1) 欠勤 From HL_JEC_園児出勤一覧 
                                                Where 園児コード = {0} And 日付 = '{1}'), 0)", childcode, date);

                SqlCommand sqlcom = new SqlCommand(sqlcmd, sqlcon);

                if (sqlcom.ExecuteScalar().ToString() != "0")
                {
                    sslbl_メッセージ.ForeColor = Color.Red;
                    sslbl_メッセージ.Text = string.Format(@"{0}が欠勤ですので、{1}の追加が失敗しました。", childname, headertext);
                }
                else
                {
                    if (headertext == "降園時間" && gv_出勤一覧.CurrentRow.Cells["登園時間"].Value.ToString() == "登園")
                    {
                        sslbl_メッセージ.ForeColor = Color.Red;
                        sslbl_メッセージ.Text = string.Format(@"先に{0}の登園時間を追加してください!", childname);
                        return;
                    }

                    change = true;
                    beforevalue = gv_出勤一覧.CurrentCell.Value == null ? string.Empty : gv_出勤一覧.CurrentCell.Value.ToString();
                    gv_出勤一覧.CurrentCell.Value = time;
                }
            }
            catch (Exception ex)
            {
                sslbl_メッセージ.ForeColor = Color.Red;
                sslbl_メッセージ.Text = ex.Message;
            }
            finally
            {
                sqlcon?.Close();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gv_出勤一覧.CurrentCell == null)
            {
                return;
            }

            SqlConnection sqlcon = SQLLinkTest();
            if (sqlcon == null)
            {
                return;
            }

            childcode = child.Substring(0, child.IndexOf(" "));
            date = datetime.Value.Date.ToShortDateString();

            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;

            try
            {
                sqlcom.CommandText = string.Format(@"Select 1 From HL_JEC_園児出勤一覧 Where 園児コード = {0}
                                                     And 日付 = '{1}'", childcode, date);

                if (sqlcom.ExecuteScalar() == null)
                {
                    contextMenuStrip1.Items[0].Enabled = false;
                }
                else
                {
                    contextMenuStrip1.Items[0].Enabled = true;
                }
            }
            catch
            {
                return;
            }
            finally
            {
                sqlcon?.Close();
            }
        }

        /// <summary>
        /// 情報のクリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = SQLLinkTest();
            if (sqlcon == null)
            {
                return;
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            try
            {
                child = gv_出勤一覧.CurrentRow.Cells["園児名"].Value.ToString().Trim();
                childcode = child.Substring(0, child.IndexOf(" "));
                childname = child.Substring(child.IndexOf(" "), child.Length - child.IndexOf(" "));
                date = datetime.Value.Date.ToShortDateString();

                sqlcom.CommandText = string.Format(@"Delete From HL_JEC_園児出勤一覧 Where 園児コード = {0}
                                                     And 日付 = '{1}'", childcode, date);

                if (sqlcom.ExecuteNonQuery() == 1)
                {
                    transaction.Commit();
                    sslbl_メッセージ.ForeColor = Color.Green;
                    sslbl_メッセージ.Text = string.Format(@"{0}のデータを正常にクリアしました.", childname);
                }
                else
                {
                    transaction.Rollback();
                    sslbl_メッセージ.ForeColor = Color.Red;
                    sslbl_メッセージ.Text = string.Format(@"{0}のデータのクリアが失敗しました.", childname);
                }
            }
            catch
            {
                transaction.Rollback();
                sslbl_メッセージ.ForeColor = Color.Red;
                sslbl_メッセージ.Text = string.Format(@"{0}のデータのクリアが失敗しました.", childname);
            }
            finally
            {
                sqlcon?.Close();
            }

            DisplayGridView_園児出勤一覧();
        }

        /// <summary>
        /// 日付が変わると、日付によって、検索を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datetime_ValueChanged(object sender, EventArgs e)
        {
            DisplayGridView_園児出勤一覧();
            datetime.Focus();
        }

        /// <summary>
        /// 欠勤、早退、遅刻原因のツリービュー内容を追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_出勤一覧_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dgvTree = e.Control as DataGridViewTreeViewEditingControl;

            if (dgvTree != null)
            {
                var root = new TreeNode("私用", 0, 0);
                var root2 = new TreeNode("病気", 0, 0);
                root2.Nodes.Add("下痢");
                root2.Nodes.Add("熱退");
                root2.Nodes.Add("嘔吐");
                var root3 = new TreeNode("自然災害", 0, 0);
                root3.Nodes.Add("地震");
                root3.Nodes.Add("台風");
                var root4 = new TreeNode("そのほか", 0, 0);
                dgvTree.TreeView.Nodes.Clear();
                dgvTree.TreeView.Nodes.Add(root);
                dgvTree.TreeView.Nodes.Add(root2);
                dgvTree.TreeView.Nodes.Add(root3);
                dgvTree.TreeView.Nodes.Add(root4);
                dgvTree.TreeView.ExpandAll();
            }
        }

        /// <summary>
        /// DBサーバーに接続が可能かどうか
        /// </summary>
        private SqlConnection SQLLinkTest()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);

            try
            {
                sqlcon.Open();
                return sqlcon;
            }
            catch
            {
                sslbl_メッセージ.ForeColor = Color.Red;
                sslbl_メッセージ.Text = "DBサーバーの接続が失敗しました。";
                sqlcon.Close();
                return null;
            }
        }

        /// <summary>
        /// 数字かどうかをチェック
        /// </summary>
        private bool Is数字(string value)
        {
            return Regex.IsMatch(value, @"^\d{1,7}(?:\.\d{0,2}$|$)");
        }

        /// <summary>
        /// 時間stringかどうかをチェック
        /// </summary>
        /// <param name="source">時間string(15:00)</param>
        /// <returns></returns>
        public static bool IsTime(string source)
        {
            return Regex.IsMatch(source, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d)$");
        }

        /// <summary>
        /// 指定された文字列と文字列間の部分を抽出
        /// </summary>
        private string MidStrEx_New(string sourse, string startstr, string endstr)
        {
            Regex rg = new Regex("(?<=(" + startstr + "))[.\\s\\S]*?(?=(" + endstr + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(sourse).Value;
        }
    }

    public class ComboBoxTreeView : ComboBox
    {
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;

        public ComboBoxTreeView()
        {
            TreeView treeView = new TreeView();
            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
            treeView.BorderStyle = BorderStyle.None;

            treeViewHost = new ToolStripControlHost(treeView);
            dropDown = new ToolStripDropDown();
            dropDown.Width = this.Width;
            dropDown.Items.Add(treeViewHost);
        }

        public void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = TreeView.SelectedNode.Text;
            dropDown.Close();
        }

        public TreeView TreeView
        {
            get 
            { 
                return treeViewHost.Control as TreeView; 
            }
        }

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeViewHost.Size = new Size(DropDownWidth - 2, DropDownHeight);
                dropDown.Show(this, 0, this.Height);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                ShowDropDown();
                return;
            }

            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }

            base.Dispose(disposing);
        }
    }

    public class DataGridViewTreeViewCell : DataGridViewTextBoxCell
    {
        public DataGridViewTreeViewCell()
        {

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewTreeViewEditingControl ctl = DataGridView.EditingControl as DataGridViewTreeViewEditingControl;
            ctl.Text = (string)this.Value;
        }

        public DataGridViewTreeViewEditingControl CtlChange(DataGridViewTreeViewEditingControl ctl, int rowIndex, object initialFormattedValue)
        {
            ctl.DropDownStyle = ComboBoxStyle.DropDownList;
            ctl.Text = (string)this.Value;

            return ctl;
        }

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewTreeViewEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return "";
            }
        }
    }

    public class DataGridViewTreeViewColumn : DataGridViewColumn
    {
        public DataGridViewTreeViewColumn() : base(new DataGridViewTreeViewCell())
        {

        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewTreeViewCell)))
                {
                    throw new InvalidCastException("DataGridViewTreeViewCellではありません");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class DataGridViewTreeViewEditingControl : ComboBoxTreeView, IDataGridViewEditingControl
    {
        protected int rowIndex;
        protected DataGridView dataGridView;
        protected bool valueChanged = false;

        public DataGridViewTreeViewEditingControl()
        {

        }

        //基本クラスをオーバーライドする
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            NotifyDataGridViewOfValueChange();
        }

        // テキスト値が変更されたら、DataGridViewに
        private void NotifyDataGridViewOfValueChange()
        {
            valueChanged = true;
            dataGridView.NotifyCurrentCellDirty(true);
        }

        /// <summary>
        /// セルを編集するとカーソルが表示される
        /// </summary>
        public Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.IBeam;
            }
        }

        /// <summary>
        ///DataGridViewを取るや設定する
        /// </summary>
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        /// <summary>
        /// フォーマットされた値を取るや設定する
        /// </summary>
        public object EditingControlFormattedValue
        {
            set
            {
                Text = value.ToString();
                NotifyDataGridViewOfValueChange();
            }
            get
            {
                return this.Text;
            }
        }

        /// <summary>
        /// テキスト値を取る
        /// </summary>
        /// <param name="context">エラーコンテキスト</param>
        /// <returns></returns>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Text;
        }

        /// <summary>
        /// キーボード編集
        /// </summary>
        /// <param name="keyData"></param>
        /// <param name="dataGridViewWantsInputKey"></param>
        /// <returns></returns>
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return false;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        public virtual bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// コントロールのインデックス
        /// </summary>
        public int EditingControlRowIndex
        {
            get
            {
                return this.rowIndex;
            }
            set
            {
                this.rowIndex = value;
            }
        }

        /// <summary>
        /// 様式を設定する
        /// </summary>
        /// <param name="dataGridViewCellStyle"></param>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        /// <summary>
        /// 値が変わるかどうか
        /// </summary>
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                this.valueChanged = value;
            }
        }
    }
}
