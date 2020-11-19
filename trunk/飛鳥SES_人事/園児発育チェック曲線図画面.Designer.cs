namespace 飛鳥SES_人事
{
    partial class 園児発育チェック曲線図画面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_性別 = new System.Windows.Forms.Label();
            this.lbl_生年月日 = new System.Windows.Forms.Label();
            this.txt_生年月日 = new System.Windows.Forms.TextBox();
            this.txt_年齢1 = new System.Windows.Forms.TextBox();
            this.txt_更新日1 = new System.Windows.Forms.TextBox();
            this.txt_身長1 = new System.Windows.Forms.TextBox();
            this.txt_体重1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl＿更新日 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_年齢2 = new System.Windows.Forms.TextBox();
            this.txt_更新日2 = new System.Windows.Forms.TextBox();
            this.txt_身長2 = new System.Windows.Forms.TextBox();
            this.txt_体重2 = new System.Windows.Forms.TextBox();
            this.txt_年齢3 = new System.Windows.Forms.TextBox();
            this.txt_更新日3 = new System.Windows.Forms.TextBox();
            this.txt_身長3 = new System.Windows.Forms.TextBox();
            this.txt_体重3 = new System.Windows.Forms.TextBox();
            this.txt_年齢4 = new System.Windows.Forms.TextBox();
            this.txt_更新日4 = new System.Windows.Forms.TextBox();
            this.txt_身長4 = new System.Windows.Forms.TextBox();
            this.txt_体重4 = new System.Windows.Forms.TextBox();
            this.txt_年齢5 = new System.Windows.Forms.TextBox();
            this.txt_更新日5 = new System.Windows.Forms.TextBox();
            this.txt_身長5 = new System.Windows.Forms.TextBox();
            this.txt_体重5 = new System.Windows.Forms.TextBox();
            this.btn_曲線図作成 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_身長 = new System.Windows.Forms.Label();
            this.lbl_体重 = new System.Windows.Forms.Label();
            this.lbl_年齢 = new System.Windows.Forms.Label();
            this.名前 = new System.Windows.Forms.Label();
            this.txt_名前 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_性別 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(117, 384);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1015, 406);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // lbl_性別
            // 
            this.lbl_性別.AutoSize = true;
            this.lbl_性別.Location = new System.Drawing.Point(119, 57);
            this.lbl_性別.Name = "lbl_性別";
            this.lbl_性別.Size = new System.Drawing.Size(37, 15);
            this.lbl_性別.TabIndex = 2;
            this.lbl_性別.Text = "性別";
            // 
            // lbl_生年月日
            // 
            this.lbl_生年月日.AutoSize = true;
            this.lbl_生年月日.Location = new System.Drawing.Point(119, 93);
            this.lbl_生年月日.Name = "lbl_生年月日";
            this.lbl_生年月日.Size = new System.Drawing.Size(67, 15);
            this.lbl_生年月日.TabIndex = 2;
            this.lbl_生年月日.Text = "生年月日";
            // 
            // txt_生年月日
            // 
            this.txt_生年月日.Location = new System.Drawing.Point(223, 82);
            this.txt_生年月日.Multiline = true;
            this.txt_生年月日.Name = "txt_生年月日";
            this.txt_生年月日.ReadOnly = true;
            this.txt_生年月日.Size = new System.Drawing.Size(174, 26);
            this.txt_生年月日.TabIndex = 4;
            // 
            // txt_年齢1
            // 
            this.txt_年齢1.Location = new System.Drawing.Point(117, 187);
            this.txt_年齢1.Name = "txt_年齢1";
            this.txt_年齢1.Size = new System.Drawing.Size(100, 25);
            this.txt_年齢1.TabIndex = 5;
            // 
            // txt_更新日1
            // 
            this.txt_更新日1.Location = new System.Drawing.Point(223, 187);
            this.txt_更新日1.Name = "txt_更新日1";
            this.txt_更新日1.Size = new System.Drawing.Size(100, 25);
            this.txt_更新日1.TabIndex = 6;
            // 
            // txt_身長1
            // 
            this.txt_身長1.Location = new System.Drawing.Point(330, 187);
            this.txt_身長1.Name = "txt_身長1";
            this.txt_身長1.Size = new System.Drawing.Size(100, 25);
            this.txt_身長1.TabIndex = 6;
            // 
            // txt_体重1
            // 
            this.txt_体重1.Location = new System.Drawing.Point(436, 187);
            this.txt_体重1.Name = "txt_体重1";
            this.txt_体重1.Size = new System.Drawing.Size(100, 25);
            this.txt_体重1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "暦年齢";
            // 
            // lbl＿更新日
            // 
            this.lbl＿更新日.AutoSize = true;
            this.lbl＿更新日.Location = new System.Drawing.Point(220, 169);
            this.lbl＿更新日.Name = "lbl＿更新日";
            this.lbl＿更新日.Size = new System.Drawing.Size(52, 15);
            this.lbl＿更新日.TabIndex = 2;
            this.lbl＿更新日.Text = "更新日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "身長（cm）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "体重(kg)";
            // 
            // txt_年齢2
            // 
            this.txt_年齢2.Location = new System.Drawing.Point(117, 218);
            this.txt_年齢2.Name = "txt_年齢2";
            this.txt_年齢2.Size = new System.Drawing.Size(100, 25);
            this.txt_年齢2.TabIndex = 5;
            // 
            // txt_更新日2
            // 
            this.txt_更新日2.Location = new System.Drawing.Point(223, 218);
            this.txt_更新日2.Name = "txt_更新日2";
            this.txt_更新日2.Size = new System.Drawing.Size(100, 25);
            this.txt_更新日2.TabIndex = 6;
            // 
            // txt_身長2
            // 
            this.txt_身長2.Location = new System.Drawing.Point(330, 218);
            this.txt_身長2.Name = "txt_身長2";
            this.txt_身長2.Size = new System.Drawing.Size(100, 25);
            this.txt_身長2.TabIndex = 6;
            // 
            // txt_体重2
            // 
            this.txt_体重2.Location = new System.Drawing.Point(436, 218);
            this.txt_体重2.Name = "txt_体重2";
            this.txt_体重2.Size = new System.Drawing.Size(100, 25);
            this.txt_体重2.TabIndex = 6;
            // 
            // txt_年齢3
            // 
            this.txt_年齢3.Location = new System.Drawing.Point(117, 249);
            this.txt_年齢3.Name = "txt_年齢3";
            this.txt_年齢3.Size = new System.Drawing.Size(100, 25);
            this.txt_年齢3.TabIndex = 5;
            // 
            // txt_更新日3
            // 
            this.txt_更新日3.Location = new System.Drawing.Point(223, 249);
            this.txt_更新日3.Name = "txt_更新日3";
            this.txt_更新日3.Size = new System.Drawing.Size(100, 25);
            this.txt_更新日3.TabIndex = 6;
            // 
            // txt_身長3
            // 
            this.txt_身長3.Location = new System.Drawing.Point(330, 249);
            this.txt_身長3.Name = "txt_身長3";
            this.txt_身長3.Size = new System.Drawing.Size(100, 25);
            this.txt_身長3.TabIndex = 6;
            // 
            // txt_体重3
            // 
            this.txt_体重3.Location = new System.Drawing.Point(436, 249);
            this.txt_体重3.Name = "txt_体重3";
            this.txt_体重3.Size = new System.Drawing.Size(100, 25);
            this.txt_体重3.TabIndex = 6;
            // 
            // txt_年齢4
            // 
            this.txt_年齢4.Location = new System.Drawing.Point(117, 280);
            this.txt_年齢4.Name = "txt_年齢4";
            this.txt_年齢4.Size = new System.Drawing.Size(100, 25);
            this.txt_年齢4.TabIndex = 5;
            // 
            // txt_更新日4
            // 
            this.txt_更新日4.Location = new System.Drawing.Point(223, 280);
            this.txt_更新日4.Name = "txt_更新日4";
            this.txt_更新日4.Size = new System.Drawing.Size(100, 25);
            this.txt_更新日4.TabIndex = 6;
            // 
            // txt_身長4
            // 
            this.txt_身長4.Location = new System.Drawing.Point(330, 280);
            this.txt_身長4.Name = "txt_身長4";
            this.txt_身長4.Size = new System.Drawing.Size(100, 25);
            this.txt_身長4.TabIndex = 6;
            // 
            // txt_体重4
            // 
            this.txt_体重4.Location = new System.Drawing.Point(436, 280);
            this.txt_体重4.Name = "txt_体重4";
            this.txt_体重4.Size = new System.Drawing.Size(100, 25);
            this.txt_体重4.TabIndex = 6;
            // 
            // txt_年齢5
            // 
            this.txt_年齢5.Location = new System.Drawing.Point(117, 311);
            this.txt_年齢5.Name = "txt_年齢5";
            this.txt_年齢5.Size = new System.Drawing.Size(100, 25);
            this.txt_年齢5.TabIndex = 5;
            // 
            // txt_更新日5
            // 
            this.txt_更新日5.Location = new System.Drawing.Point(223, 311);
            this.txt_更新日5.Name = "txt_更新日5";
            this.txt_更新日5.Size = new System.Drawing.Size(100, 25);
            this.txt_更新日5.TabIndex = 6;
            // 
            // txt_身長5
            // 
            this.txt_身長5.Location = new System.Drawing.Point(330, 311);
            this.txt_身長5.Name = "txt_身長5";
            this.txt_身長5.Size = new System.Drawing.Size(100, 25);
            this.txt_身長5.TabIndex = 6;
            // 
            // txt_体重5
            // 
            this.txt_体重5.Location = new System.Drawing.Point(436, 311);
            this.txt_体重5.Name = "txt_体重5";
            this.txt_体重5.Size = new System.Drawing.Size(100, 25);
            this.txt_体重5.TabIndex = 6;
            // 
            // btn_曲線図作成
            // 
            this.btn_曲線図作成.Location = new System.Drawing.Point(117, 342);
            this.btn_曲線図作成.Name = "btn_曲線図作成";
            this.btn_曲線図作成.Size = new System.Drawing.Size(143, 37);
            this.btn_曲線図作成.TabIndex = 7;
            this.btn_曲線図作成.Text = "曲線図作成";
            this.btn_曲線図作成.UseVisualStyleBackColor = true;
            this.btn_曲線図作成.Click += new System.EventHandler(this.btn_曲線図作成_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(114, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(519, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "下の表にお子さんの身長や体重と測定した年月日を入力してください。";
            // 
            // lbl_身長
            // 
            this.lbl_身長.AutoSize = true;
            this.lbl_身長.Location = new System.Drawing.Point(1085, 399);
            this.lbl_身長.Name = "lbl_身長";
            this.lbl_身長.Size = new System.Drawing.Size(0, 15);
            this.lbl_身長.TabIndex = 8;
            // 
            // lbl_体重
            // 
            this.lbl_体重.AutoSize = true;
            this.lbl_体重.Location = new System.Drawing.Point(1085, 423);
            this.lbl_体重.Name = "lbl_体重";
            this.lbl_体重.Size = new System.Drawing.Size(0, 15);
            this.lbl_体重.TabIndex = 8;
            // 
            // lbl_年齢
            // 
            this.lbl_年齢.AutoSize = true;
            this.lbl_年齢.Location = new System.Drawing.Point(197, 775);
            this.lbl_年齢.Name = "lbl_年齢";
            this.lbl_年齢.Size = new System.Drawing.Size(37, 15);
            this.lbl_年齢.TabIndex = 8;
            this.lbl_年齢.Text = "年齢";
            // 
            // 名前
            // 
            this.名前.AutoSize = true;
            this.名前.Location = new System.Drawing.Point(119, 16);
            this.名前.Name = "名前";
            this.名前.Size = new System.Drawing.Size(37, 15);
            this.名前.TabIndex = 2;
            this.名前.Text = "名前";
            // 
            // txt_名前
            // 
            this.txt_名前.Location = new System.Drawing.Point(223, 11);
            this.txt_名前.Multiline = true;
            this.txt_名前.Name = "txt_名前";
            this.txt_名前.ReadOnly = true;
            this.txt_名前.Size = new System.Drawing.Size(174, 26);
            this.txt_名前.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 808);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1322, 22);
            this.statusStrip1.TabIndex = 125;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // txt_性別
            // 
            this.txt_性別.Location = new System.Drawing.Point(223, 46);
            this.txt_性別.Multiline = true;
            this.txt_性別.Name = "txt_性別";
            this.txt_性別.ReadOnly = true;
            this.txt_性別.Size = new System.Drawing.Size(66, 26);
            this.txt_性別.TabIndex = 126;
            // 
            // 園児発育チェック曲線図画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 830);
            this.Controls.Add(this.txt_性別);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_年齢);
            this.Controls.Add(this.lbl_体重);
            this.Controls.Add(this.lbl_身長);
            this.Controls.Add(this.btn_曲線図作成);
            this.Controls.Add(this.txt_体重5);
            this.Controls.Add(this.txt_身長5);
            this.Controls.Add(this.txt_体重4);
            this.Controls.Add(this.txt_身長4);
            this.Controls.Add(this.txt_体重3);
            this.Controls.Add(this.txt_身長3);
            this.Controls.Add(this.txt_体重2);
            this.Controls.Add(this.txt_身長2);
            this.Controls.Add(this.txt_体重1);
            this.Controls.Add(this.txt_更新日5);
            this.Controls.Add(this.txt_身長1);
            this.Controls.Add(this.txt_更新日4);
            this.Controls.Add(this.txt_更新日3);
            this.Controls.Add(this.txt_年齢5);
            this.Controls.Add(this.txt_年齢4);
            this.Controls.Add(this.txt_更新日2);
            this.Controls.Add(this.txt_年齢3);
            this.Controls.Add(this.txt_年齢2);
            this.Controls.Add(this.txt_更新日1);
            this.Controls.Add(this.txt_年齢1);
            this.Controls.Add(this.txt_名前);
            this.Controls.Add(this.txt_生年月日);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl＿更新日);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_生年月日);
            this.Controls.Add(this.名前);
            this.Controls.Add(this.lbl_性別);
            this.Controls.Add(this.chart1);
            this.Name = "園児発育チェック曲線図画面";
            this.Text = "成長曲線図";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児発育チェック曲線図画面_FormClosed);
            this.Load += new System.EventHandler(this.園児発育チェック曲線図画面_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_性別;
        private System.Windows.Forms.Label lbl_生年月日;
        private System.Windows.Forms.TextBox txt_生年月日;
        private System.Windows.Forms.TextBox txt_年齢1;
        private System.Windows.Forms.TextBox txt_更新日1;
        private System.Windows.Forms.TextBox txt_身長1;
        private System.Windows.Forms.TextBox txt_体重1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl＿更新日;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_年齢2;
        private System.Windows.Forms.TextBox txt_更新日2;
        private System.Windows.Forms.TextBox txt_身長2;
        private System.Windows.Forms.TextBox txt_体重2;
        private System.Windows.Forms.TextBox txt_年齢3;
        private System.Windows.Forms.TextBox txt_更新日3;
        private System.Windows.Forms.TextBox txt_身長3;
        private System.Windows.Forms.TextBox txt_体重3;
        private System.Windows.Forms.TextBox txt_年齢4;
        private System.Windows.Forms.TextBox txt_更新日4;
        private System.Windows.Forms.TextBox txt_身長4;
        private System.Windows.Forms.TextBox txt_体重4;
        private System.Windows.Forms.TextBox txt_年齢5;
        private System.Windows.Forms.TextBox txt_更新日5;
        private System.Windows.Forms.TextBox txt_身長5;
        private System.Windows.Forms.TextBox txt_体重5;
        private System.Windows.Forms.Button btn_曲線図作成;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_身長;
        private System.Windows.Forms.Label lbl_体重;
        private System.Windows.Forms.Label lbl_年齢;
        private System.Windows.Forms.Label 名前;
        private System.Windows.Forms.TextBox txt_名前;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txt_性別;
    }
}