using ComDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 飛鳥SES_人事
{
    public partial class 園児発育チェック曲線図画面 : Form
    {
        public string ename;
        private string connectionString = ComClass.connectionString;
        // 准备数据 
        ArrayList list_身長 = new ArrayList();
        ArrayList list_体重 = new ArrayList();
        ArrayList list_更新日 = new ArrayList();
        ArrayList list_年齢 = new ArrayList();
        ArrayList list_身長object = new ArrayList();
        ArrayList list_体重object = new ArrayList();
        ArrayList list_更新日object = new ArrayList();
        ArrayList list_年齢object = new ArrayList();
        public 園児発育チェック曲線図画面()
        {
            InitializeComponent();

            Series series = chart1.Series[0];
            // 画样条曲线（Spline）
            series.ChartType = SeriesChartType.Spline;
            // 线宽2个像素
            series.BorderWidth = 2;
            // 线的颜色：红色
            series.Color = System.Drawing.Color.Red;
            // 图示上的文字
            series.LegendText = "標準";

            Series series1 = chart1.Series[1];
            // 画样条曲线（Spline）
            series1.ChartType = SeriesChartType.Spline;
            // 线宽2个像素
            series1.BorderWidth = 2;
            // 线的颜色：红色
            series1.Color = System.Drawing.Color.Blue;
            // 图示上的文字
            series1.LegendText = "身長";

            Series series2 = chart1.Series[2];
            // 画样条曲线（Spline）
            series2.ChartType = SeriesChartType.Spline;
            // 线宽2个像素
            series2.BorderWidth = 2;
            // 线的颜色：红色
            series2.Color = System.Drawing.Color.Green;
            // 图示上的文字
            series2.LegendText = "体重";

           

            // 设置显示范围
            ChartArea chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 20;
            chartArea.AxisY.Minimum = 0d;
            chartArea.AxisY.Maximum = 140d;

            list_身長object.Add(txt_身長1);
            list_身長object.Add(txt_身長2);
            list_身長object.Add(txt_身長3);
            list_身長object.Add(txt_身長4);
            list_身長object.Add(txt_身長5);

            list_体重object.Add(txt_体重1);
            list_体重object.Add(txt_体重2);
            list_体重object.Add(txt_体重3);
            list_体重object.Add(txt_体重4);
            list_体重object.Add(txt_体重5);

            list_更新日object.Add(txt_更新日1);
            list_更新日object.Add(txt_更新日2);
            list_更新日object.Add(txt_更新日3);
            list_更新日object.Add(txt_更新日4);
            list_更新日object.Add(txt_更新日5);

            list_年齢object.Add(txt_年齢1);
            list_年齢object.Add(txt_年齢2);
            list_年齢object.Add(txt_年齢3);
            list_年齢object.Add(txt_年齢4);
            list_年齢object.Add(txt_年齢5);

        }

        private void btn_曲線図作成_Click(object sender, EventArgs e)
        {
            float x1 = float.Parse(txt_身長1.Text.Equals("")? "0" : txt_身長1.Text);
            float x2 = float.Parse(txt_身長2.Text.Equals("") ? "0" : txt_身長2.Text);
            float x3 = float.Parse(txt_身長3.Text.Equals("")? "0" : txt_身長3.Text);
            float x4 = float.Parse(txt_身長4.Text.Equals("")? "0" : txt_身長4.Text);
            float x5 = float.Parse(txt_身長5.Text.Equals("")? "0" : txt_身長5.Text);
            float x6 = float.Parse(txt_体重1.Text.Equals("")? "0" : txt_体重1.Text);
            float x7 = float.Parse(txt_体重2.Text.Equals("")? "0" : txt_体重2.Text);
            float x8 = float.Parse(txt_体重3.Text.Equals("")? "0" : txt_体重3.Text);
            float x9 = float.Parse(txt_体重4.Text.Equals("")? "0" : txt_体重4.Text);
            float x10 = float.Parse(txt_体重5.Text.Equals("")? "0" : txt_体重5.Text);

            // 准备数据 
            float[] values = { 10, 20, 30, 40, 50 };
            float[] values2 = { x1, x2, x3, x4, x5 };
            float[] values3 = { x6, x7, x8, x9, x10 };
            // 在chart中显示数据
            int x = 0;
            foreach (float v in values)
            {
                if (v!=0)
                {
                    this.chart1.Series[0].Points.AddXY(x, v);
                }
                x++;
            }
             x = 0;
            foreach (float v in values2)
            {
                if (v!=0)
                {
                    this.chart1.Series[1].Points.AddXY(x, v);
                    x++;
                }
            }
             x = 0;
            foreach (float v in values3)
            {
                if (v!=0)
                {
                    this.chart1.Series[2].Points.AddXY(x, v);
                    x++;
                }
            }
        }
        /// <summary>
        /// 園児発育データ表示
        /// </summary>
        private void DisplayView()
        {
            //メッセージをクリアする
            this.toolStripStatusLabel1.Text = "";

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
            string str_sqlcmd =string.Format( @"select distinct 
                                                         a.名前,a.生年月日,a.性別,b.身長,b.体重,b.測定日
                                                from 
                                                        HL_JEC_園児情報マスタ a  
                                                inner join    
                                                        HL_JEC_園児発育状況 b  on a.園児コード = b.園児コード
                                                where a.名前= '{0}' ",ename);

            SqlCommand com = new SqlCommand(str_sqlcmd, sqlcon);
            SqlDataReader reader = com.ExecuteReader();
         
            try
            {  //表示データを入れる
                txt_名前.Text = ename;
                int count = 0;
                while (reader.Read())
                {
                    txt_生年月日.Text = reader["生年月日"].ToString().Substring(0,10);
                    txt_性別.Text = reader["性別"].ToString();
                    list_身長.Add(reader["身長"].ToString());
                    list_体重.Add(reader["体重"].ToString());
                    list_更新日.Add(reader["測定日"].ToString());


                    if ( 0 <= count && count <= 4)
                    {
                        TextBox high = (TextBox)list_身長object[count];
                        high.Text = list_身長[count].ToString();

                        TextBox weight = (TextBox)list_体重object[count];
                        weight.Text = list_体重[count].ToString();

                        TextBox time = (TextBox)list_更新日object[count];
                        time.Text = list_更新日[count].ToString().Substring(0, 10);

                        TextBox year = (TextBox)list_年齢object[count];
                        year.Text = (int.Parse(time.Text.Substring(0,4))-int.Parse(txt_生年月日.Text.Substring(0,4))).ToString();
                    }
                    count++;
                  
                }
            }
            

            catch (Exception ex)
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = "データ取得に失敗しました." + ex.Message;
                return;
            }
            finally
            {
                reader.Close();
                if (sqlcon != null)
                {
                    sqlcon.Close();
                }
            }
        }
        private void 園児発育チェック曲線図画面_Load(object sender, EventArgs e)
        {
            DisplayView();
        }

        private void 園児発育チェック曲線図画面_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)(this.Tag)).m_園児発育チェック曲線図画面Handle.iHandle = IntPtr.Zero;
        }
    }
}
