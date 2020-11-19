using ComDll;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace 飛鳥SES_人事
{
    public partial class 職員検便記録表 : DockContent
    {
        #region 変数設定
        private string connectionString = ComClass.connectionString;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);

        private string selectedname_職員 = string.Empty;
        private string selectedCode_職員 = string.Empty;
        private string selectedYear = string.Empty;
        private string selectedStatus = string.Empty;
        private string beforeValue = string.Empty;
        private bool isUpdate = false;

        private System.Data.DataTable table_FileUploadedMemberList;
        private System.Data.DataTable table_HaveNotUploadMemberList;
        private System.Data.DataTable table_TotalList;
        private System.Data.DataTable dvgSource;

        #endregion

        #region Main 処理
        public 職員検便記録表()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期画面Load
        /// </summary>
        private void 職員検便記録表_Load(object sender, EventArgs e)
        {
            selectedYear = dtp_年度.Value.ToString("yyyy");

            cmb_状態.SelectedIndex = 0;
            selectedStatus = cmb_状態.Text;
            dtp_年度.MaxDate = DateTime.Now;

            DisplayGridView(dtp_年度.Value.ToString("yyyy"), selectedStatus);

        }

        /// <summary>
        /// 画面が閉じる時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 職員検便記録表_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_職員検便記録表Handle.iHandle = IntPtr.Zero;
        }

        #endregion
                
        #region データ設定と取得
        /// <summary>
        /// DBから呼び出すデータをテーブルに作成用
        /// </summary>
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

        private void GetData(string Selected_年度)
        {
            selectedYear = dtp_年度.Value.ToString("yyyy");
            string sqlcmd_FileUploadedMemberList = string.Format(@"SELECT
	                                                                    T2.職員コード,
	                                                                    T2.名前,
	                                                                    T1.検便日付,
	                                                                    T1.アップロード日付,
	                                                                    T1.定期検便ファイル名
                                                                    FROM
	                                                                    (
		                                                                    select
			                                                                    b.職員コード,
			                                                                    a.名前,
			                                                                    a.入職日,
			                                                                    a.退職日
		                                                                    from
			                                                                    HL_JINJI_社員マスタ a
			                                                                    inner join
				                                                                    HL_JEC_職員情報 b
			                                                                    on	a.社員コード = b.職員コード
		                                                                    where
			                                                                    year(a.入職日) <= '{0}'
		                                                                    and	(
				                                                                    year(a.退職日) IS NULL
			                                                                    Or	year(a.退職日) >= '{0}'
			                                                                    )
	                                                                    ) as T2
	                                                                    inner join
		                                                                    HL_JEC_検便一覧表　T1
	                                                                    on	T1.職員コード = T2.職員コード
                                                                    WHERE
	                                                                    year(T1.検便日付) = '{0}'
                                                                    ORDER BY
	                                                                    職員コード", Selected_年度);

            table_FileUploadedMemberList = new System.Data.DataTable();
            table_FileUploadedMemberList.Rows.Clear();
            table_FileUploadedMemberList = GetDatatable(sqlcmd_FileUploadedMemberList);


            string sqlcmd_HaveNotUploadMemberList = string.Format(@"select
	                                                                    T3.職員コード,
	                                                                    T4.名前
                                                                    from
	                                                                    HL_JINJI_社員マスタ T4
	                                                                    inner join
		                                                                    HL_JEC_職員情報 T3
	                                                                    on	T4.社員コード = T3.職員コード
                                                                    where
	                                                                    (T3.職員コード not in(
			                                                                    SELECT
				                                                                    T2.職員コード
			                                                                    FROM
				                                                                    (
					                                                                    select
						                                                                    b.職員コード,
						                                                                    a.名前,
						                                                                    a.入職日,
						                                                                    a.退職日
					                                                                    from
						                                                                    HL_JINJI_社員マスタ a
						                                                                    inner join
							                                                                    HL_JEC_職員情報 b
						                                                                    on	a.社員コード = b.職員コード
				                                                                    ) as T2
				                                                                    inner join
					                                                                    HL_JEC_検便一覧表　T1
				                                                                    on	T1.職員コード = T2.職員コード
			                                                                    WHERE
				                                                                    year(T1.検便日付) = '{0}'
		                                                                    ))
                                                                    and	year(T4.入職日) <= '{0}'
                                                                    and	(
		                                                                    year(T4.退職日) IS NULL
	                                                                    Or	year(T4.退職日) >= '{0}'
	                                                                    )
                                                                    ORDER BY
	                                                                    T3.職員コード", Selected_年度);
            table_HaveNotUploadMemberList = new System.Data.DataTable();
            table_HaveNotUploadMemberList.Rows.Clear();
            table_HaveNotUploadMemberList = GetDatatable(sqlcmd_HaveNotUploadMemberList);
            table_HaveNotUploadMemberList.Columns.Add("検便日付", typeof(string));
            table_HaveNotUploadMemberList.Columns.Add("アップロード日付", typeof(string));
            table_HaveNotUploadMemberList.Columns.Add("定期検便ファイル名", typeof(string));


            table_TotalList = new System.Data.DataTable();
            table_TotalList.Columns.Add("職員コード", typeof(string));
            table_TotalList.Columns.Add("名前", typeof(string));
            table_TotalList.Columns.Add("検便日付", typeof(string));
            table_TotalList.Columns.Add("アップロード日付", typeof(string));
            table_TotalList.Columns.Add("定期検便ファイル名", typeof(string));


            table_TotalList = table_FileUploadedMemberList.Copy();

            foreach (DataRow dr2 in table_HaveNotUploadMemberList.Rows)
            {
                table_TotalList.Rows.Add(dr2.ItemArray);
            }
        }
        #endregion

        #region DVG処理

        /// <summary>
        /// 画面リストの選択によって、該当するDGVをLoad
        /// </summary>
        private void DisplayGridView(string selectedYear, string selectedStatus)
        {
            int index = 0;
            dvgSource = new System.Data.DataTable();
            dataGridView1.Rows.Clear();

            GetData(selectedYear);
            
            if (selectedStatus == "ALL") 
            {
                dvgSource = table_TotalList;
            }
            else if (selectedStatus == "アップロード済み")
            {
                dvgSource = table_FileUploadedMemberList;
            }
            else if (selectedStatus == "未アップロード")
            {
                dvgSource = table_HaveNotUploadMemberList;
            }
            try
            {
                foreach (DataRow dataRow in dvgSource.Rows)
                {
                    if ((dataRow["職員コード"].ToString().ToLower().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (dataRow["名前"].ToString().ToLower().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (dataRow["検便日付"].ToString().ToLower().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (dataRow["アップロード日付"].ToString().ToLower().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (dataRow["定期検便ファイル名"].ToString().ToLower().IndexOf(this.txt_search.Text) < 0)
                        &&
                        (dataRow["定期検便ファイル"].ToString().ToLower().IndexOf(this.txt_search.Text) < 0)
                        )
                    {
                        continue;
                    }
                    //Rowにデータ入れ
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["職員コード"].Value = string.IsNullOrWhiteSpace(dataRow["職員コード"].ToString()) ? "-" : dataRow["職員コード"].ToString();
                    dataGridView1.Rows[index].Cells["名前"].Value = string.IsNullOrWhiteSpace(dataRow["名前"].ToString()) ? "-" : dataRow["名前"].ToString();
                    dataGridView1.Rows[index].Cells["検便日付"].Value = string.IsNullOrWhiteSpace(dataRow["検便日付"].ToString()) ? "-" : Convert.ToDateTime(dataRow["検便日付"]).ToString("yyyy/MM/dd");
                    dataGridView1.Rows[index].Cells["アップロード日付"].Value = string.IsNullOrWhiteSpace(dataRow["アップロード日付"].ToString()) ? "-" : Convert.ToDateTime(dataRow["アップロード日付"]).ToString("yyyy/MM/dd");
                    dataGridView1.Rows[index].Cells["定期検便ファイル"].Value = string.IsNullOrWhiteSpace(dataRow["定期検便ファイル名"].ToString()) ? "-" : dataRow["定期検便ファイル名"].ToString();

                    foreach (DataGridViewCell gridCell in dataGridView1.Rows[index].Cells)
                    {
                        if (gridCell.Value.ToString() == "-")
                        {
                            dataGridView1.Rows[index].Cells[gridCell.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        if (gridCell.Value.ToString() == "-" && ( gridCell.OwningColumn.HeaderText == "検便日付" || gridCell.OwningColumn.HeaderText == "定期検便ファイル"))
                        {
                            dataGridView1.Rows[index].Cells[gridCell.ColumnIndex].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].Cells[gridCell.ColumnIndex].Style.ForeColor = Color.Black;
                            dataGridView1.Rows[index].Cells[gridCell.ColumnIndex].ReadOnly = true;
                        }
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = ex.Message;
                return;
            }

            toolStripStatusLabel1.Text = string.Format("{0}件", index);
        }

        /// <summary>
        /// 定期検便ファイル名のカラムはファイルがある場合PDFファイルとしてPreviewする
        /// </summary>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripStatusLabel2.Text = string.Empty;
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";

            if (dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString() == "-" || string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString()))
            {
                return;
            }

            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "検便日付")
            {
                isUpdate = true;
                beforeValue = dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString();
            }
            else if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "定期検便ファイル")
            {
                string tempdir = @"C:\Windows\Temp\";
                string date_検便日付 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["検便日付"].Value).ToString("yyyy-MM-dd");
                selectedCode_職員 = dataGridView1.CurrentRow.Cells["職員コード"].Value.ToString();

                if (dataGridView1.CurrentCell.Value.ToString() == "-" || string.IsNullOrWhiteSpace(dataGridView1.CurrentCell.Value.ToString()))
                {
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = string.Format("[ 定期検便ファイル ]の添付ファイルがありません。");
                    return;
                }

                string uploadFileName = dataGridView1.CurrentCell.Value.ToString();
                byte[] uploadFileData = null;
                string renameFile = tempdir + uploadFileName.Substring(0, uploadFileName.LastIndexOf(".")) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                string sqlcmd = string.Format(@"SELECT 
                                                    定期検便ファイル名, 
                                                    定期検便ファイル 
                                                FROM 
                                                    HL_JEC_検便一覧表　
                                                WHERE 
                                                    職員コード = '{0}' AND
                                                    検便日付 = '{1}'", selectedCode_職員, date_検便日付);

                try
                {
                    System.Data.DataTable tablegetdata = GetDatatable(sqlcmd);
                    uploadFileData = (byte[])tablegetdata.Rows[0]["定期検便ファイル"];

                    if (uploadFileName.Trim().ToLower().EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        uploadFileName.Trim().ToLower().EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        uploadFileName.Trim().ToLower().EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + uploadFileName, uploadFileData);
                        ConvertJPEGToPDF(tempdir + uploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                    else if (uploadFileName.Trim().ToLower().EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                            uploadFileName.Trim().ToLower().EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                            uploadFileName.Trim().ToLower().EndsWith(".xlw", StringComparison.OrdinalIgnoreCase) ||
                            uploadFileName.Trim().ToLower().EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        File.WriteAllBytes(tempdir + uploadFileName, uploadFileData);
                        ConvertExcelToPDF(tempdir + uploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }
                    else if (".doc, .docx".Contains(uploadFileName.Substring(uploadFileName.LastIndexOf("."))))
                    {
                        File.WriteAllBytes(tempdir + uploadFileName, uploadFileData);
                        ConvertWordToPDF(tempdir + uploadFileName, renameFile);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);

                    }
                    else
                    {
                        File.WriteAllBytes(renameFile, uploadFileData);
                        ComClass.PDF表示(renameFile, Properties.Resources.人事);
                    }

                }
                catch (Exception ex)
                {
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = ex.ToString() + string.Format("[{1}]さんの[{0}]のファイル呼び込みに失敗しました。", uploadFileName, dataGridView1.CurrentRow.Cells["名前"].Value.ToString());
                    return;
                }
                finally
                {
                    KillFile(tempdir, uploadFileName);
                }
            }
        }

        /// <summary>
        /// セルにクリックする時の処理
        /// </summary>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    selectedCode_職員 = this.dataGridView1.CurrentRow.Cells["職員コード"].Value.ToString();
                    selectedname_職員 = this.dataGridView1.CurrentRow.Cells["名前"].Value.ToString();

                    var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                    this.contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
                }
            }
        }

        /// <summary>
        /// 1行選択の処理
        /// </summary>
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }

                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];


                        if (dtp_年度.Value.Year < DateTime.Now.Year)
                        {
                            contextMenuStrip1.Items[1].Enabled = false;
                            contextMenuStrip1.Items[2].Enabled = false;

                            if (dataGridView1.CurrentRow.Cells["定期検便ファイル"].Value.ToString() == "-")
                            {
                                contextMenuStrip1.Items[0].Enabled = false;
                            }
                            else
                            {
                                contextMenuStrip1.Items[0].Enabled = true;
                            }
                        }
                        else
                        {
                            contextMenuStrip1.Items[1].Enabled = true;

                            if (dataGridView1.CurrentRow.Cells["定期検便ファイル"].Value.ToString() == "-")
                            {
                                contextMenuStrip1.Items[0].Enabled = false;
                                contextMenuStrip1.Items[2].Enabled = false;
                            }
                            else
                            {
                                contextMenuStrip1.Items[0].Enabled = true;
                                contextMenuStrip1.Items[2].Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// DGVのセルを直接に編集する時の処理
        /// </summary>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isUpdate && dataGridView1.CurrentCell.EditedFormattedValue.ToString() != beforeValue)
            {
                //情報習得
                int id_職員 = Convert.ToInt32(dataGridView1.CurrentRow.Cells["職員コード"].Value);
                string name_職員 = dataGridView1.CurrentRow.Cells["名前"].Value.ToString();
                string before_検便日付 = beforeValue;
                string new_検便日付 = dataGridView1.CurrentCell.EditedFormattedValue.ToString();
                string time_アップロード日付 = dataGridView1.CurrentRow.Cells["アップロード日付"].Value.ToString();
                string name_定期検便ファイル名 = dataGridView1.CurrentRow.Cells["定期検便ファイル"].Value.ToString();
                byte[] data__定期検便ファイル = null;

                if (!CheckInput(id_職員.ToString(), name_職員, "検便日付", new_検便日付))
                {
                    isUpdate = false;
                    DisplayGridView(selectedYear, selectedStatus);
                    return;
                }

                new_検便日付 = DateTime.Parse(dataGridView1.CurrentCell.EditedFormattedValue.ToString()).ToString("yyyy/MM/dd");
                string sqlcmd1 = string.Format(@"Select
                                                定期検便ファイル名, 
                                                定期検便ファイル 
                                            From 
                                                HL_JEC_検便一覧表 
                                            Where 
                                                職員コード = '{0}'
                                            and 検便日付 = '{1}'", id_職員, before_検便日付);
                System.Data.DataTable tb1 = GetDatatable(sqlcmd1);
                //var datarow = table_FileUploadedMemberList.AsEnumerable().Where(x => x.Field<int>("職員コード") == id_職員 && x.Field<DateTime>("検便日付") == Convert.ToDateTime(beforeValue)).FirstOrDefault();
                data__定期検便ファイル = (byte[])tb1.Rows[0]["定期検便ファイル"];

                SqlConnection sqlcon = new SqlConnection(connectionString);
                try
                {
                    sqlcon.Open();
                }
                catch
                {
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = "DBサーバーの接続に失敗しました。";
                    sqlcon.Close();
                }

                SqlTransaction transaction = sqlcon.BeginTransaction();

                try
                {
                    SqlCommand sqlcom = new SqlCommand();
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;


                    //旧情報を削除
                    sqlcom.CommandText = string.Format(@"Delete From HL_JEC_検便一覧表 where 職員コード = '{0}' and 検便日付 = '{1}'", id_職員, before_検便日付);
                    int result = sqlcom.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //新情報を入れる

                        if (name_定期検便ファイル名 == "-")
                        {
                            sqlcom.CommandText = string.Format(@"INSERT INTO HL_JEC_検便一覧表
                                                       ([職員コード]
                                                       ,[検便日付]
                                                       ,[アップロード日付]
                                                       ,[定期検便ファイル]
                                                       ,[定期検便ファイル名])
                                                 VALUES
                                                       ( '{0}'
                                                       , '{1}'
                                                       , '{2}'
                                                       , NULL
                                                       , NULL)",
                                                           id_職員, new_検便日付, time_アップロード日付);
                        }
                        else
                        {
                            sqlcom.CommandText = string.Format(@"INSERT INTO HL_JEC_検便一覧表
                                                       ([職員コード]
                                                       ,[検便日付]
                                                       ,[アップロード日付]
                                                       ,[定期検便ファイル]
                                                       ,[定期検便ファイル名])
                                                 VALUES
                                                       ('{0}'
                                                       ,'{1}'
                                                       ,'{2}'
                                                       , @uploadFileData
                                                       ,'{3}')",
                                                        id_職員, new_検便日付, time_アップロード日付, name_定期検便ファイル名);
                            sqlcom.Parameters.AddWithValue("@uploadFileData", data__定期検便ファイル);
                        }

                        int result2 = sqlcom.ExecuteNonQuery();

                        if (result2 == 1)
                        {
                            transaction.Commit();
                            isUpdate = false;
                            DisplayGridView(selectedYear, selectedStatus);
                            toolStripStatusLabel2.ForeColor = Color.Green;
                            toolStripStatusLabel2.Text = string.Format("[{0}　{1}]さんの情報を正常に更新しました", id_職員, name_職員);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    isUpdate = false;
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = string.Format("[{0}　{1}]さんの情報更新が失敗しました。", id_職員, name_職員);
                    return;
                }
                finally
                {
                    sqlcon?.Close();
                }
            }
        }

        /// <summary>
        /// DGVのセル修正が終わる時の処理
        /// </summary>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            isUpdate = false;
        }

        #endregion

        #region ContextMenuStrip
        /// <summary>
        /// ダウンロードメニュー
        /// </summary>
        private void ダウンロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";

            string fileName = dataGridView1.CurrentRow.Cells["定期検便ファイル"].Value.ToString();
            string date_検便日付 = dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString();
            selectedCode_職員 = dataGridView1.CurrentRow.Cells["職員コード"].Value.ToString();
            if (fileName == "-")
            {
                this.toolStripStatusLabel2.ForeColor = Color.Red;
                this.toolStripStatusLabel2.Text = string.Format("添付ファイル [{0}] がありません。", fileName);
                return;
            }

            string sqlcmd = String.Format(@"Select
                                                定期検便ファイル名, 
                                                定期検便ファイル 
                                            From 
                                                HL_JEC_検便一覧表 
                                            Where 
                                                職員コード = '{0}'
                                            and 検便日付 = '{1}'", selectedCode_職員, date_検便日付);
            System.Data.DataTable getdata = GetDatatable(sqlcmd);

            bool isDownloadOk;
            if (string.IsNullOrEmpty(getdata.Rows[0]["定期検便ファイル"].ToString()))
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{1}]さんの検便日付[{0}]の添付ファイルがありません。", date_検便日付, dataGridView1.CurrentRow.Cells["名前"].Value.ToString());
                isDownloadOk = false;
                return;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                byte[] fileData = (byte[])getdata.Rows[0]["定期検便ファイル"];
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
                            toolStripStatusLabel2.ForeColor = Color.Green;
                            toolStripStatusLabel2.Text = string.Format("[{1}]さんの添付ファイル [{0}] がダウンロードしました。", fileName, dataGridView1.CurrentRow.Cells["名前"].Value.ToString());
                        }
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
        /// アップロードメニュー
        /// </summary>
        private void アップロードToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = string.Empty;
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";

            string id_職員 = dataGridView1.CurrentRow.Cells["職員コード"].Value.ToString();
            string name_職員 = dataGridView1.CurrentRow.Cells["名前"].Value.ToString();
            string date_検便日付 = (dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString() == "-") ? string.Format(selectedYear+ "-" + DateTime.Now.ToString("MM-dd")) : dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString();
            string updateDate = (dataGridView1.CurrentRow.Cells["アップロード日付"].Value.ToString() == "-") ? DateTime.Now.ToString("yyyy-MM-dd") : dataGridView1.CurrentRow.Cells["アップロード日付"].Value.ToString();
            string uploadFileName = string.Empty;
            byte[] uploadFileData = null;

            if (dtp_年度.Value.Year > DateTime.Now.Year)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}]年度はまだアップロードできません。", dtp_年度.Value.ToString("yyyy"));
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                uploadFileData = File.ReadAllBytes(openFileDialog.FileName);
                uploadFileName = Path.GetFileName(openFileDialog.FileName);

                SqlConnection sqlcon = new SqlConnection(connectionString); //连接数据库

                try
                {
                    sqlcon.Open();
                }
                catch
                {
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = "サーバーがつなげない！インターネット接続をチェックしてください。";
                    return;
                }

                SqlTransaction transaction = sqlcon.BeginTransaction();

                try
                {
                    SqlCommand sqlcom = new SqlCommand();
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;

                    if (dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString() == "-")  //Insert new Data
                    {
                        sqlcom.CommandText = string.Format(@"INSERT INTO HL_JEC_検便一覧表
                                                       ([職員コード]
                                                       ,[検便日付]
                                                       ,[アップロード日付]
                                                       ,[定期検便ファイル]
                                                       ,[定期検便ファイル名])
                                                 VALUES
                                                       ('{0}'
                                                       ,'{1}'
                                                       ,'{2}'
                                                       , @uploadFileData
                                                       ,'{3}')",
                                                  id_職員, date_検便日付, updateDate, uploadFileName);
                        sqlcom.Parameters.AddWithValue("@uploadFileData", uploadFileData);
                    }
                    else //Update Data
                    {
                        sqlcom.CommandText = string.Format(@"UPDATE [dbo].[HL_JEC_検便一覧表]
                                                               SET [アップロード日付] = @日付
                                                                  ,[定期検便ファイル] = @定期検便ファイル
                                                                  ,[定期検便ファイル名] = @定期検便ファイル名
                                                             WHERE 職員コード = @職員コード
                                                             AND 検便日付 = @検便日付");

                        sqlcom.Parameters.AddWithValue("@日付", updateDate);
                        sqlcom.Parameters.AddWithValue("@定期検便ファイル", uploadFileData);
                        sqlcom.Parameters.AddWithValue("@定期検便ファイル名", uploadFileName);
                        sqlcom.Parameters.AddWithValue("@職員コード", id_職員);
                        sqlcom.Parameters.AddWithValue("@検便日付", date_検便日付);
                    }
                    int result = sqlcom.ExecuteNonQuery();
                    if (result == 1)
                    {
                        transaction.Commit();
                        toolStripStatusLabel2.ForeColor = Color.Green;
                        toolStripStatusLabel2.Text = string.Format("[{0}　{1}]さんの情報を追加しました", name_職員, id_職員);

                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = string.Format("[{0}　{1}]さんの情報追加が失敗しました。", name_職員, id_職員);
                }
                finally
                {
                    sqlcon?.Close();
                    DisplayGridView(selectedYear, selectedStatus);
                }
            }
        }

        /// <summary>
        /// 削除メニュー
        /// </summary>
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";
            
            selectedCode_職員 = dataGridView1.CurrentRow.Cells["職員コード"].Value.ToString();
            string date_検便日付 = dataGridView1.CurrentRow.Cells["検便日付"].Value.ToString();
            int result = 0;

            if (date_検便日付 == "-")
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}　{1}]さんの検便ファイルがまだアップロードしないため、削除できません。",selectedCode_職員, dataGridView1.CurrentRow.Cells["名前"].Value.ToString());
                return;
            }

            if (dtp_年度.Value.Year > DateTime.Now.Year)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}]年度はまだ削除できません。", dtp_年度.Value.ToString("yyyy"));
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
                sqlcon.Close();
            }

            SqlTransaction transaction = sqlcon.BeginTransaction();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.Transaction = transaction;

            try
            {
                string sqlcmd = string.Format("DELETE FROM HL_JEC_検便一覧表 WHERE 職員コード = '{0}' AND 検便日付 = '{1}'", selectedCode_職員, date_検便日付);

                sqlcom.CommandText = sqlcmd;
                result = sqlcom.ExecuteNonQuery();

                if (result == 1)
                {
                    transaction.Commit();
                    toolStripStatusLabel2.ForeColor = Color.Green;
                    toolStripStatusLabel2.Text = string.Format("[{1}　{2}]さんの検便日付 [{0}]の情報を正常に削除しました。", date_検便日付, selectedCode_職員, dataGridView1.CurrentRow.Cells["名前"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{1}　{2}]さんの検便日付 [{0}]の情報削除が失敗しました。", date_検便日付, selectedCode_職員, dataGridView1.CurrentRow.Cells["名前"].Value.ToString());
            }
            finally
            {
                sqlcon?.Close();
                DisplayGridView(selectedYear, selectedStatus);
            }
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

            var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

            using (FileStream stream = new FileStream(rename2PDF, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream);
                document.Open();

                using (FileStream imagestream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imagestream);
                    if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
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
            Microsoft.Office.Interop.Excel.Application application = null;
            Microsoft.Office.Interop.Excel.Workbook workBook = null;
            try
            {
                application = new Microsoft.Office.Interop.Excel.Application();
                workBook = application.Workbooks.Open(excelfile, Type.Missing, Type.Missing, Type.Missing);
                workBook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, rename2PDF, Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard, true, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

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
            Microsoft.Office.Interop.Word.Application application = null;
            Microsoft.Office.Interop.Word.Document document = null;
            object misValue = System.Reflection.Missing.Value;
            try
            {
                application = new Microsoft.Office.Interop.Word.Application();
                document = application.Documents.Open(wordfile);
                document.Activate();
                document.ExportAsFixedFormat(rename2PDF, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
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
                    document.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges, Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat, false);
                    document = null;
                }
                if (application != null)
                {
                    application.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges, Type.Missing, Type.Missing);
                    application = null;

                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
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

        #endregion

        #region Button
        /// <summary>
        /// 更新のボタン処理
        /// </summary>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DisplayGridView(dtp_年度.Value.ToString("yyyy"), cmb_状態.Text);
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";
            toolStripStatusLabel2.Text = "";
        }


        #endregion

        #region DatimePicker
        /// <summary>
        /// 年度を変更時の処理
        /// </summary>
        private void dtp_年度_ValueChanged(object sender, EventArgs e)
        {
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";
            toolStripStatusLabel2.Text = "";

            selectedYear = dtp_年度.Value.ToString().Substring(0,4);

            DisplayGridView(selectedYear, selectedStatus);
        }

        #endregion

        #region 検索欄処理
        /// <summary>
        /// 検索欄のEnterキーの処理
        /// </summary>
        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplayGridView(dtp_年度.Value.ToString("yyyy"), cmb_状態.Text);
                ((Form1)(Tag)).toolStripStatusLabel2.Text = "";
                toolStripStatusLabel2.Text = "";
            }
        }

        #endregion

        #region CMB処理
        /// <summary>
        /// CMB状態変更時の処理
        /// </summary>
        private void cmb_状態_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Form1)(Tag)).toolStripStatusLabel2.Text = "";
            toolStripStatusLabel2.Text = "";

            selectedStatus = cmb_状態.Text;
            DisplayGridView(selectedYear, selectedStatus);
        }
        #endregion

        #region CheckInput

        /// <summary>
        /// Check Input Data when Update DGV
        /// </summary>
        /// <returns></returns>
        private bool CheckInput(string code_職員, string name_職員, string ColumnName, string CellValue)
        {
            string errMsg = string.Empty;
            
            switch (ColumnName)
            {
                case "検便日付":
                    if (string.IsNullOrWhiteSpace(CellValue))
                    {
                        errMsg = "日付が未入力です。";
                    }
                    else if (CellValue.IndexOf(",") > 0)
                    {
                        errMsg = "日付に許可されない文字「,」が入りました。";
                    }
                    else if (CellValue.Substring(0,4) != selectedYear)
                    {
                        errMsg =　string.Format("検便日付は選択されている年度 [{0}] の以外に変更できません。", selectedYear);
                    }
                    else
                    {
                        try
                        {
                            //日付形式チェック
                            DateTime.Parse(CellValue);
                        }
                        catch
                        {
                            errMsg = "日付に正しい日付の形式を入力してください。";
                        }
                    }
                    break;
                default:
                    break;
            }

            if (errMsg != "")
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = string.Format("[{0}　{1}]さんの情報変更が失敗しました。", code_職員, name_職員) + errMsg;
                return false;
            }
            return true;
        }

        #endregion

    }
}
