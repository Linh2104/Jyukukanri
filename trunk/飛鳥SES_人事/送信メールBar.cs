using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 飛鳥SES_人事
{
    public struct Par
    {
        public int progressBar_Value;
        public string label1;
        public string label2;
    }
    public partial class 送信メールBar : Form
    {

        public const int CUSTOM_MESSAGE = 0X400 + 2;
        public const int END_MESSAGE = 0X400 + 3;
        public 送信メールBar()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {
            switch (msg.Msg)
            {
                case CUSTOM_MESSAGE:
                    {
                        Par tmp_Par = new Par();
                        Type t = tmp_Par.GetType();
                        tmp_Par = (Par)(msg.GetLParam(t));

                        this.label1.Text = tmp_Par.label1;
                        this.label2.Text = tmp_Par.label2;
                        this.progressBar1.Value = tmp_Par.progressBar_Value;
                    }
                    break;
                case END_MESSAGE:
                    {
                        this.Close();
                    }
                    break;
                default:
                    base.WndProc(ref msg);
                    break;
            }
        }

        private void 送信メールBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((メール一斉配信)(this.Tag)).m_送信メールBarHandle = IntPtr.Zero;
        }

    }
}
