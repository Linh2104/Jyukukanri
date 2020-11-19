using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ComDll;

namespace 飛鳥SES_人事
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            int processCount = 0;
            Process[] pa = Process.GetProcesses();//获取当前进程数组。  
            foreach (Process PTest in pa)
            {
                if (PTest.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    processCount += 1;
                }
            }
            if (processCount == 1)  
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 m_MainForm = new Form1();
                m_MainForm.m_ユーザ登録 = new ユーザ登録(Properties.Resources.SubSystemName, "人事", m_MainForm, Properties.Resources.人事1, Properties.Resources.toubu, Properties.Resources.mima, System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(196)))), ((int)(((byte)(102))))));
                Application.Run(m_MainForm.m_ユーザ登録);
            }
            else
            {
                MessageBox.Show("このプログラムは既に起動しています!", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
