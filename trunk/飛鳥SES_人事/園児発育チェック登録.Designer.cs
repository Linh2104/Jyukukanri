namespace 飛鳥SES_人事
{
    partial class 園児発育チェック登録
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
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmb_id = new System.Windows.Forms.ComboBox();
            this.lbl_園児 = new System.Windows.Forms.Label();
            this.lbl_胸囲 = new System.Windows.Forms.Label();
            this.lbl_頭囲 = new System.Windows.Forms.Label();
            this.lbl_栄養状況 = new System.Windows.Forms.Label();
            this.lbl_身長 = new System.Windows.Forms.Label();
            this.lbl_体重 = new System.Windows.Forms.Label();
            this.lbl_更新日 = new System.Windows.Forms.Label();
            this.bt_back = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.txt_身長 = new System.Windows.Forms.TextBox();
            this.txt_体重 = new System.Windows.Forms.TextBox();
            this.datetime = new System.Windows.Forms.DateTimePicker();
            this.txt_頭囲 = new System.Windows.Forms.TextBox();
            this.txt_胸囲 = new System.Windows.Forms.TextBox();
            this.cmb_栄養状況 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
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
            // cmb_id
            // 
            this.cmb_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_id.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.cmb_id.FormattingEnabled = true;
            this.cmb_id.Location = new System.Drawing.Point(191, 77);
            this.cmb_id.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_id.Name = "cmb_id";
            this.cmb_id.Size = new System.Drawing.Size(212, 33);
            this.cmb_id.TabIndex = 126;
            // 
            // lbl_園児
            // 
            this.lbl_園児.AutoSize = true;
            this.lbl_園児.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_園児.Location = new System.Drawing.Point(79, 80);
            this.lbl_園児.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_園児.Name = "lbl_園児";
            this.lbl_園児.Size = new System.Drawing.Size(52, 25);
            this.lbl_園児.TabIndex = 127;
            this.lbl_園児.Text = "園児";
            // 
            // lbl_胸囲
            // 
            this.lbl_胸囲.AutoSize = true;
            this.lbl_胸囲.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_胸囲.Location = new System.Drawing.Point(79, 176);
            this.lbl_胸囲.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_胸囲.Name = "lbl_胸囲";
            this.lbl_胸囲.Size = new System.Drawing.Size(52, 25);
            this.lbl_胸囲.TabIndex = 127;
            this.lbl_胸囲.Text = "胸囲";
            // 
            // lbl_頭囲
            // 
            this.lbl_頭囲.AutoSize = true;
            this.lbl_頭囲.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_頭囲.Location = new System.Drawing.Point(79, 275);
            this.lbl_頭囲.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_頭囲.Name = "lbl_頭囲";
            this.lbl_頭囲.Size = new System.Drawing.Size(52, 25);
            this.lbl_頭囲.TabIndex = 127;
            this.lbl_頭囲.Text = "頭囲";
            // 
            // lbl_栄養状況
            // 
            this.lbl_栄養状況.AutoSize = true;
            this.lbl_栄養状況.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_栄養状況.Location = new System.Drawing.Point(79, 372);
            this.lbl_栄養状況.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_栄養状況.Name = "lbl_栄養状況";
            this.lbl_栄養状況.Size = new System.Drawing.Size(92, 25);
            this.lbl_栄養状況.TabIndex = 127;
            this.lbl_栄養状況.Text = "栄養状況";
            // 
            // lbl_身長
            // 
            this.lbl_身長.AutoSize = true;
            this.lbl_身長.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_身長.Location = new System.Drawing.Point(434, 182);
            this.lbl_身長.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_身長.Name = "lbl_身長";
            this.lbl_身長.Size = new System.Drawing.Size(104, 25);
            this.lbl_身長.TabIndex = 127;
            this.lbl_身長.Text = "身長(cm)";
            // 
            // lbl_体重
            // 
            this.lbl_体重.AutoSize = true;
            this.lbl_体重.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_体重.Location = new System.Drawing.Point(434, 283);
            this.lbl_体重.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_体重.Name = "lbl_体重";
            this.lbl_体重.Size = new System.Drawing.Size(98, 25);
            this.lbl_体重.TabIndex = 127;
            this.lbl_体重.Text = "体重(kg)";
            // 
            // lbl_更新日
            // 
            this.lbl_更新日.AutoSize = true;
            this.lbl_更新日.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_更新日.Location = new System.Drawing.Point(434, 82);
            this.lbl_更新日.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_更新日.Name = "lbl_更新日";
            this.lbl_更新日.Size = new System.Drawing.Size(72, 25);
            this.lbl_更新日.TabIndex = 127;
            this.lbl_更新日.Text = "更新日";
            // 
            // bt_back
            // 
            this.bt_back.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.bt_back.Location = new System.Drawing.Point(526, 443);
            this.bt_back.Margin = new System.Windows.Forms.Padding(4);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(144, 39);
            this.bt_back.TabIndex = 129;
            this.bt_back.Text = "キャンセル";
            this.bt_back.UseVisualStyleBackColor = true;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // bt_add
            // 
            this.bt_add.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.bt_add.Location = new System.Drawing.Point(305, 443);
            this.bt_add.Margin = new System.Windows.Forms.Padding(4);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(144, 39);
            this.bt_add.TabIndex = 128;
            this.bt_add.Text = "登録";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // txt_身長
            // 
            this.txt_身長.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_身長.Location = new System.Drawing.Point(551, 182);
            this.txt_身長.Margin = new System.Windows.Forms.Padding(4);
            this.txt_身長.Name = "txt_身長";
            this.txt_身長.Size = new System.Drawing.Size(132, 33);
            this.txt_身長.TabIndex = 130;
            // 
            // txt_体重
            // 
            this.txt_体重.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_体重.Location = new System.Drawing.Point(551, 280);
            this.txt_体重.Margin = new System.Windows.Forms.Padding(4);
            this.txt_体重.Name = "txt_体重";
            this.txt_体重.Size = new System.Drawing.Size(140, 33);
            this.txt_体重.TabIndex = 130;
            // 
            // datetime
            // 
            this.datetime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datetime.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.datetime.Location = new System.Drawing.Point(551, 77);
            this.datetime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(212, 36);
            this.datetime.TabIndex = 131;
            // 
            // txt_頭囲
            // 
            this.txt_頭囲.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_頭囲.Location = new System.Drawing.Point(191, 272);
            this.txt_頭囲.Margin = new System.Windows.Forms.Padding(4);
            this.txt_頭囲.Name = "txt_頭囲";
            this.txt_頭囲.Size = new System.Drawing.Size(132, 33);
            this.txt_頭囲.TabIndex = 130;
            // 
            // txt_胸囲
            // 
            this.txt_胸囲.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_胸囲.Location = new System.Drawing.Point(191, 176);
            this.txt_胸囲.Margin = new System.Windows.Forms.Padding(4);
            this.txt_胸囲.Name = "txt_胸囲";
            this.txt_胸囲.Size = new System.Drawing.Size(132, 33);
            this.txt_胸囲.TabIndex = 130;
            // 
            // cmb_栄養状況
            // 
            this.cmb_栄養状況.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_栄養状況.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_栄養状況.FormattingEnabled = true;
            this.cmb_栄養状況.Items.AddRange(new object[] {
            "上等",
            "中等",
            "下等"});
            this.cmb_栄養状況.Location = new System.Drawing.Point(191, 369);
            this.cmb_栄養状況.Name = "cmb_栄養状況";
            this.cmb_栄養状況.Size = new System.Drawing.Size(132, 33);
            this.cmb_栄養状況.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(187, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 133;
            this.label6.Text = "【必須】";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(187, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 133;
            this.label1.Text = "【必須】";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(547, 257);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 133;
            this.label2.Text = "【必須】";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(547, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 133;
            this.label3.Text = "【必須】";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(187, 347);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 133;
            this.label4.Text = "【必須】";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(80, 294);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 19);
            this.label5.TabIndex = 133;
            // 
            // 園児発育チェック登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 560);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_栄養状況);
            this.Controls.Add(this.datetime);
            this.Controls.Add(this.txt_体重);
            this.Controls.Add(this.txt_胸囲);
            this.Controls.Add(this.txt_頭囲);
            this.Controls.Add(this.txt_身長);
            this.Controls.Add(this.bt_back);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.lbl_更新日);
            this.Controls.Add(this.lbl_栄養状況);
            this.Controls.Add(this.lbl_体重);
            this.Controls.Add(this.lbl_身長);
            this.Controls.Add(this.lbl_頭囲);
            this.Controls.Add(this.lbl_胸囲);
            this.Controls.Add(this.lbl_園児);
            this.Controls.Add(this.cmb_id);
            this.Controls.Add(this.statusStrip1);
            this.Name = "園児発育チェック登録";
            this.Text = "園児発育チェック登録";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児発育チェック登録_FormClosed);
            this.Load += new System.EventHandler(this.園児発育チェック登録_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox cmb_id;
        private System.Windows.Forms.Label lbl_園児;
        private System.Windows.Forms.Label lbl_胸囲;
        private System.Windows.Forms.Label lbl_頭囲;
        private System.Windows.Forms.Label lbl_栄養状況;
        private System.Windows.Forms.Label lbl_身長;
        private System.Windows.Forms.Label lbl_体重;
        private System.Windows.Forms.Label lbl_更新日;
        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.TextBox txt_身長;
        private System.Windows.Forms.TextBox txt_体重;
        private System.Windows.Forms.DateTimePicker datetime;
        private System.Windows.Forms.TextBox txt_頭囲;
        private System.Windows.Forms.TextBox txt_胸囲;
        private System.Windows.Forms.ComboBox cmb_栄養状況;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}