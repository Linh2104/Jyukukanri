using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.SqlClient;
using LumiSoft.Net.MIME;
using ComDll;

namespace 飛鳥SES_人事
{
    public partial class メール一斉配信 : DockContent
    {
        public 送信メールBar m_メール送信BarForm = null;
        public IntPtr m_送信メールBarHandle = IntPtr.Zero;
        public List<OneMail> m_ToCcBcc = null;

        public bool m_送信停止 = false;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            IntPtr wParam,         // 参数1
            ref Par lParam //参数2
        );

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public メール一斉配信()
        {
            InitializeComponent();
        }

        private void メール一斉配信_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];

            int index = 0;
            //Copy file from external application
            foreach (string srcfile in files)
            {
                if (File.Exists(srcfile))
                {
                    //labelCurFolder.Text = fileInfo.DirectoryName;

                    //Show file name
                    ListViewItem itemName = new ListViewItem(srcfile);
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(srcfile);
                    itemName.Text = fileInfo.Name;
                    itemName.Tag = srcfile;

                    //Show file icon
                    System.Drawing.Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(srcfile);

                    if (listView1.SmallImageList == null)
                    {
                        ImageList imgLst = new ImageList();
                        imgLst.Images.Add(fileIcon);
                        listView1.SmallImageList = imgLst;//小图标模式下 显示这个图标
                        listView1.LargeImageList = imgLst;//大图标模式下 显示这个图标
                        listView1.StateImageList = imgLst;
                    }
                    else
                    {
                        listView1.SmallImageList.Images.Add(fileIcon);
                        listView1.SmallImageList.Images.Add(fileIcon);
                        listView1.SmallImageList.Images.Add(fileIcon);
                    }


                    //Show file size                    
                    long size = fileInfo.Length;                    

                    String strSize;
                    if (size < 1024)
                    {
                        strSize = String.Format("{0:###}B", (float)size );
                    }
                    else if (size < 1024 * 1024)
                    {
                        strSize = String.Format("{0:###.##}KB", (float)size / 1024);
                    }
                    else if (size < 1024 * 1024 * 1024)
                    {
                        strSize = String.Format("{0:###.##}MB", (float)size / (1024 * 1024));
                    }
                    else
                    {
                        strSize = String.Format("{0:###.##}GB", (float)size / (1024 * 1024 * 1024));
                    }

                    ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem();
                    subItem1.Text = strSize;
                    itemName.SubItems.Add(subItem1);

                    ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem();
                    subItem2.Text = fileInfo.DirectoryName;
                    itemName.SubItems.Add(subItem2);

                    this.listView1.Items.Add(itemName);
                    this.listView1.Items[this.listView1.Items.Count -1].ImageIndex = listView1.SmallImageList.Images.Count - 1;

                    index++;
                }
                else if (Directory.Exists(srcfile))
                {
                }
            }
        }

        private void メール一斉配信_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                foreach(ListViewItem tmp in this.listView1.SelectedItems)
                {
                    this.listView1.Items.Remove(tmp);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("送信します。よろしいですか？", "確認", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!送信準備())
                {
                    return;
                }

                m_メール送信BarForm = new 送信メールBar();
                m_メール送信BarForm.Show();
                m_メール送信BarForm.progressBar1.Maximum = 100;
                m_メール送信BarForm.progressBar1.Value = 0;
                m_メール送信BarForm.progressBar1.Step = 1;
                m_メール送信BarForm.Tag = this;
                m_送信メールBarHandle = m_メール送信BarForm.Handle;

                this.m_送信停止 = false;

                Thread thread = new Thread(new ThreadStart(送信スレッド));
                thread.IsBackground = true;
                thread.Start();

                this.button1.Visible = false;
                this.button7.Visible = true;
            }
        }

        public bool 送信エラーチェック()
        {
            if (this.textBox3.Text.Equals(""))
            {
                MessageBox.Show("件名が入力されていません。");
                return false;
            }

            if (this.textBox2.Text.Equals(""))
            {
                MessageBox.Show("本文が入力されていません。");
                return false;
            }

            if (this.textBox2.Text.IndexOf("%G%") < 0)
            {
                MessageBox.Show("本文が学校名の入替文字「%G%」を含まれていません。");
                return false;
            }

            if (this.textBox2.Text.IndexOf("%T%") < 0)
            {
                MessageBox.Show("本文がキャリアセンター担当者名の入替文字「%T%」を含まれていません。");
                return false;
            }

            return true;
        }

        public List<OneMail> MakeToCcBcc()
        {
            string User = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;

            List<OneMail> ToCcBcc = new List<OneMail>();
            List<string> 送信済み営業共通List = new List<string>();                

            string connectionString = "";

            connectionString = ComClass.connectionString;

            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("サーバーがつなげない！インターネット接続をチェックしてください。");

                return null;
            }

            string str_sqlcmd = string.Format(@"select aaa.学校名,bbb.* from HL_JINJI_学校情報 aaa,HL_JINJI_キャリアセンター担当者情報 bbb where aaa.学校ID = bbb.学校ID");

            SqlCommand com = new SqlCommand(str_sqlcmd, conn);

            SqlDataReader reader = com.ExecuteReader();

            int info_Index = 0;

            while (reader.Read())
            {
                OneMail tmp_TCB = new OneMail();
                tmp_TCB.会社名 = reader["学校名"].ToString();
                tmp_TCB.担当者 = reader["キャリアセンター担当者"].ToString();

                tmp_TCB.TO.Add(reader["メール"].ToString());

                foreach (ListViewItem tmpFujian in this.listView1.Items)
                {
                    tmp_TCB.FUJIAN.Add((string)tmpFujian.Tag);
                }

                string body = this.textBox2.Text;

                string subject = this.textBox3.Text;

                body = body.Replace("%G%", tmp_TCB.会社名);
                body = body.Replace("%T%", tmp_TCB.担当者);
                body = body.Replace("%g%", tmp_TCB.会社名);
                body = body.Replace("%t%", tmp_TCB.担当者);
                body = body.Replace("%Ｇ%", tmp_TCB.会社名);
                body = body.Replace("%Ｔ%", tmp_TCB.担当者);
                body = body.Replace("%ｇ%", tmp_TCB.会社名);
                body = body.Replace("%ｔ%", tmp_TCB.担当者);

                subject = subject.Replace("%G%", tmp_TCB.会社名);
                subject = subject.Replace("%T%", tmp_TCB.担当者);
                subject = subject.Replace("%g%", tmp_TCB.会社名);
                subject = subject.Replace("%t%", tmp_TCB.担当者);
                subject = subject.Replace("%Ｇ%", tmp_TCB.会社名);
                subject = subject.Replace("%Ｔ%", tmp_TCB.担当者);
                subject = subject.Replace("%ｇ%", tmp_TCB.会社名);
                subject = subject.Replace("%ｔ%", tmp_TCB.担当者);

                tmp_TCB.body = body;
                tmp_TCB.subject = subject;

                if ((tmp_TCB.TO.Count != 0)
                    || (tmp_TCB.CC.Count != 0)
                    || (tmp_TCB.BCC.Count != 0))
                {
                    ToCcBcc.Add(tmp_TCB);
                }

                if (info_Index == 0)
                {
                    OneMail Info_TCB = new OneMail();

                    Info_TCB.TO.Add(((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ);
                    Info_TCB.BCC.Add("info@hl-soft.co.jp");

                    Info_TCB.body = body;
                    Info_TCB.subject = "【一斉配信】" + subject;

                    foreach (ListViewItem tmpFujian in this.listView1.Items)
                    {
                        Info_TCB.FUJIAN.Add((string)tmpFujian.Tag);
                    }

                    ToCcBcc.Add(Info_TCB);
                }

                info_Index++;

            }

            reader.Close();
            conn.Close();

            return ToCcBcc;
        }

        public bool 送信準備(bool test = false)  //test :テスト送信
        {
            if (!送信エラーチェック())
            {                
                return false;
            }

            if (this.m_送信メールBarHandle != IntPtr.Zero)
            {
                MessageBox.Show("送信中です！");
                return false;
            }

            List<OneMail> ToCcBcc = new List<OneMail>();

            ToCcBcc = MakeToCcBcc();

            m_ToCcBcc = ToCcBcc;

            return true;
        }

        public void ThreadMessageBox(object o,EventArgs e)
        {
            送信結果 送信結果Form = (送信結果)o;
            送信結果Form.Show();
        }

        public void 送信スレッド()
        {
            int index = 0;
            int count = m_ToCcBcc.Count;
            int 成功Count = 0;
            int 失敗Count = 0;
            string 送信Name = "";

            string User = ((Form1)(this.Tag)).m_ユーザ登録.m_ログイン_ユーザ;
            string Name = "";
            string Password = "";

            string connectionString = "";

            connectionString = ComClass.connectionString;

            SqlConnection conn = new SqlConnection(connectionString); //连接数据库

            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("サーバーがつなげない！インターネット接続をチェックしてください。");

                return;
            }

            string str_sqlcmd = string.Format(@"select * from HL_EIGYO_ユーザ where ユーザ = '{0}'", User);

            SqlCommand com = new SqlCommand(str_sqlcmd, conn);

            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                Name = reader["氏名"].ToString();
                Password = reader["メールパスワード"].ToString();
            }

            reader.Close();
            conn.Close();

            SendMail Smail = new SendMail(User, Name, Password);

            try
            {
                送信結果 送信結果Form = new 送信結果();
                foreach (OneMail tmp in m_ToCcBcc)
                {
                    if (this.m_送信停止)
                    {
                        SendMessage(m_送信メールBarHandle, 送信メールBar.END_MESSAGE, IntPtr.Zero, IntPtr.Zero);
                        return;
                    }

                    if (tmp.TO.Count != 0)
                    {
                        送信Name = tmp.TO[0];
                        送信ProgressBar(tmp.TO[0], index, count);
                    }
                    else if (tmp.CC.Count != 0)
                    {
                        送信Name = tmp.CC[0];
                        送信ProgressBar(tmp.CC[0], index, count);
                    }
                    else if (tmp.BCC.Count != 0)
                    {
                        送信Name = tmp.BCC[0];
                        送信ProgressBar(tmp.BCC[0], index, count);
                    }
                    else
                    {
                        index++;
                        continue;
                    }

                    index++;

                    string strErrMessage = "";
                    int 失敗回数 = 0;
                    while (!Smail.Send(tmp.TO, tmp.CC, tmp.BCC, tmp.subject, tmp.body, tmp.FUJIAN, ref strErrMessage))
                    {
                        失敗回数++;

                        if (失敗回数 == 3)
                        {
                            break;
                        }

                        Thread.Sleep(1000);
                    }

                    if (失敗回数 < 3)
                    {
                        成功Count++;
                    }
                    else
                    {

                        if (失敗Count == 0)
                        {
                            送信結果Form.textBox1.Text = 送信Name + "：" + strErrMessage;
                        }
                        else
                        {
                            送信結果Form.textBox1.Text = 送信結果Form.textBox1.Text + "\r\n" + 送信Name + "：" + strErrMessage;
                        }
                        失敗Count++;
                    }

                    Thread.Sleep(80);
                }


                SendMessage(m_送信メールBarHandle, 送信メールBar.END_MESSAGE, IntPtr.Zero, IntPtr.Zero);

                if (失敗Count == 0)
                {
                    MessageBox.Show("送信成功しました。");
                }
                else
                {
                    送信結果Form.label1.Text = "送信成功数：" + 成功Count + "、" + "送信失敗数：" + 失敗Count;
                    this.BeginInvoke(new EventHandler(ThreadMessageBox), 送信結果Form);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void メール一斉配信_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_メール一斉配信Handle.iHandle = IntPtr.Zero;
        }

        private void メール一斉配信_DockStateChanged(object sender, EventArgs e)
        {
            if (((Form1)(this.Tag)).m_メール一斉配信Handle.iHandle != IntPtr.Zero)
            {
                ((Form1)(this.Tag)).m_メール一斉配信Handle.iHandle = this.Handle;
            }
        }

        // add start by WYY
        public void 送信ProgressBar(string name, int index, int count)
        {
            Par tmp_Par = new Par();
            tmp_Par.label1 = "to：" + name;
            tmp_Par.label2 = (++index).ToString() + "/" + count.ToString();
            tmp_Par.progressBar_Value = (int)(index * 100 / count);
            long result = SendMessage(m_送信メールBarHandle, 送信メールBar.CUSTOM_MESSAGE, IntPtr.Zero, ref tmp_Par).ToInt64();
        }



        private void button7_Click(object sender, EventArgs e)
        {
            this.m_送信停止 = true;
            this.button7.Visible = false;
            this.button1.Visible = true;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            開くToolStripMenuItem_Click(sender, e);
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmpDir = @"C:\Windows\Temp\";
            if (this.listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listView1.SelectedItems)
                {
                    if (item.Tag is MIME_Entity)
                    {
                        MIME_Entity entity = (MIME_Entity)item.Tag;

                        File.WriteAllBytes(tmpDir + item.Text, ((MIME_b_SinglepartBase)entity.Body).Data);

                        Thread.Sleep(1000);

                        System.Diagnostics.Process.Start(tmpDir + item.Text);
                    }
                    else
                    {
                        string FileName = (string)item.Tag;

                        System.Diagnostics.Process.Start(FileName);
                    }
                }
            }
        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tmp in this.listView1.SelectedItems)
            {
                this.listView1.Items.Remove(tmp);
            }
        }
    }
}
