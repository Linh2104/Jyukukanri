namespace 飛鳥SES_人事
{
    partial class 出勤記録新規追加
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(出勤記録新規追加));
            this.rbtn_Attflg02 = new System.Windows.Forms.RadioButton();
            this.rbtn_Attflg01 = new System.Windows.Forms.RadioButton();
            this.cmb_Employee = new System.Windows.Forms.ComboBox();
            this.lbl_Employee = new System.Windows.Forms.Label();
            this.txt_AddDateTime = new System.Windows.Forms.TextBox();
            this.lbl_AttDateTime = new System.Windows.Forms.Label();
            this.lbl_AttFlg = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Register = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslbl_エラーメッセージ = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_Attflg02
            // 
            this.rbtn_Attflg02.AutoSize = true;
            this.rbtn_Attflg02.Location = new System.Drawing.Point(317, 85);
            this.rbtn_Attflg02.Name = "rbtn_Attflg02";
            this.rbtn_Attflg02.Size = new System.Drawing.Size(47, 16);
            this.rbtn_Attflg02.TabIndex = 147;
            this.rbtn_Attflg02.TabStop = true;
            this.rbtn_Attflg02.Text = "退勤";
            this.rbtn_Attflg02.UseVisualStyleBackColor = true;
            // 
            // rbtn_Attflg01
            // 
            this.rbtn_Attflg01.AutoSize = true;
            this.rbtn_Attflg01.Location = new System.Drawing.Point(189, 85);
            this.rbtn_Attflg01.Name = "rbtn_Attflg01";
            this.rbtn_Attflg01.Size = new System.Drawing.Size(47, 16);
            this.rbtn_Attflg01.TabIndex = 146;
            this.rbtn_Attflg01.TabStop = true;
            this.rbtn_Attflg01.Text = "出勤";
            this.rbtn_Attflg01.UseVisualStyleBackColor = true;
            // 
            // cmb_Employee
            // 
            this.cmb_Employee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Employee.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_Employee.FormattingEnabled = true;
            this.cmb_Employee.Items.AddRange(new object[] {
            "ALL"});
            this.cmb_Employee.Location = new System.Drawing.Point(189, 31);
            this.cmb_Employee.Name = "cmb_Employee";
            this.cmb_Employee.Size = new System.Drawing.Size(216, 29);
            this.cmb_Employee.TabIndex = 145;
            // 
            // lbl_Employee
            // 
            this.lbl_Employee.AutoSize = true;
            this.lbl_Employee.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Employee.Location = new System.Drawing.Point(41, 37);
            this.lbl_Employee.Name = "lbl_Employee";
            this.lbl_Employee.Size = new System.Drawing.Size(40, 23);
            this.lbl_Employee.TabIndex = 144;
            this.lbl_Employee.Text = "職員";
            // 
            // txt_AddDateTime
            // 
            this.txt_AddDateTime.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.txt_AddDateTime.Location = new System.Drawing.Point(189, 127);
            this.txt_AddDateTime.MaxLength = 20;
            this.txt_AddDateTime.Name = "txt_AddDateTime";
            this.txt_AddDateTime.Size = new System.Drawing.Size(216, 26);
            this.txt_AddDateTime.TabIndex = 141;
            // 
            // lbl_AttDateTime
            // 
            this.lbl_AttDateTime.AutoSize = true;
            this.lbl_AttDateTime.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_AttDateTime.Location = new System.Drawing.Point(41, 130);
            this.lbl_AttDateTime.Name = "lbl_AttDateTime";
            this.lbl_AttDateTime.Size = new System.Drawing.Size(85, 23);
            this.lbl_AttDateTime.TabIndex = 140;
            this.lbl_AttDateTime.Text = "出退勤時間";
            // 
            // lbl_AttFlg
            // 
            this.lbl_AttFlg.AutoSize = true;
            this.lbl_AttFlg.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_AttFlg.Location = new System.Drawing.Point(41, 83);
            this.lbl_AttFlg.Name = "lbl_AttFlg";
            this.lbl_AttFlg.Size = new System.Drawing.Size(100, 23);
            this.lbl_AttFlg.TabIndex = 139;
            this.lbl_AttFlg.Text = "出退勤フラグ";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_Clear.Location = new System.Drawing.Point(308, 179);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(97, 28);
            this.btn_Clear.TabIndex = 143;
            this.btn_Clear.Text = "クリア";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Register
            // 
            this.btn_Register.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_Register.Location = new System.Drawing.Point(189, 179);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(97, 28);
            this.btn_Register.TabIndex = 142;
            this.btn_Register.Text = "登録";
            this.btn_Register.UseVisualStyleBackColor = true;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbl_エラーメッセージ});
            this.statusStrip1.Location = new System.Drawing.Point(0, 253);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(506, 22);
            this.statusStrip1.TabIndex = 148;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbl_エラーメッセージ
            // 
            this.sslbl_エラーメッセージ.Name = "sslbl_エラーメッセージ";
            this.sslbl_エラーメッセージ.Size = new System.Drawing.Size(0, 17);
            // 
            // 出勤記録新規追加
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 275);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rbtn_Attflg02);
            this.Controls.Add(this.rbtn_Attflg01);
            this.Controls.Add(this.cmb_Employee);
            this.Controls.Add(this.lbl_Employee);
            this.Controls.Add(this.txt_AddDateTime);
            this.Controls.Add(this.lbl_AttDateTime);
            this.Controls.Add(this.lbl_AttFlg);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Register);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "出勤記録新規追加";
            this.Text = "出勤記録新規追加";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_Attflg02;
        private System.Windows.Forms.RadioButton rbtn_Attflg01;
        public System.Windows.Forms.ComboBox cmb_Employee;
        private System.Windows.Forms.Label lbl_Employee;
        private System.Windows.Forms.TextBox txt_AddDateTime;
        private System.Windows.Forms.Label lbl_AttDateTime;
        private System.Windows.Forms.Label lbl_AttFlg;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_エラーメッセージ;
    }
}