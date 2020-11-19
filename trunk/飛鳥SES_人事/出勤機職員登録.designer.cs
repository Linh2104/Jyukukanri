namespace 飛鳥SES_人事
{
    partial class 出勤機職員登録
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
            this.lbl_出勤機 = new System.Windows.Forms.Label();
            this.lbl_登録コード = new System.Windows.Forms.Label();
            this.lbl_職員コード = new System.Windows.Forms.Label();
            this.cmb_出勤機 = new System.Windows.Forms.ComboBox();
            this.txt_登録コード = new System.Windows.Forms.TextBox();
            this.cmb_職員コード = new System.Windows.Forms.ComboBox();
            this.btn_登録 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sslbl_エラーメッセージ = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_出勤機
            // 
            this.lbl_出勤機.AutoSize = true;
            this.lbl_出勤機.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_出勤機.Location = new System.Drawing.Point(118, 70);
            this.lbl_出勤機.Name = "lbl_出勤機";
            this.lbl_出勤機.Size = new System.Drawing.Size(59, 16);
            this.lbl_出勤機.TabIndex = 0;
            this.lbl_出勤機.Text = "出勤機";
            // 
            // lbl_登録コード
            // 
            this.lbl_登録コード.AutoSize = true;
            this.lbl_登録コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_登録コード.Location = new System.Drawing.Point(118, 138);
            this.lbl_登録コード.Name = "lbl_登録コード";
            this.lbl_登録コード.Size = new System.Drawing.Size(139, 16);
            this.lbl_登録コード.TabIndex = 1;
            this.lbl_登録コード.Text = "登録コード　[必須]";
            this.lbl_登録コード.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_職員コード
            // 
            this.lbl_職員コード.AutoSize = true;
            this.lbl_職員コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_職員コード.Location = new System.Drawing.Point(118, 217);
            this.lbl_職員コード.Name = "lbl_職員コード";
            this.lbl_職員コード.Size = new System.Drawing.Size(100, 16);
            this.lbl_職員コード.TabIndex = 2;
            this.lbl_職員コード.Text = "職員　[必須]";
            this.lbl_職員コード.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // cmb_出勤機
            // 
            this.cmb_出勤機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_出勤機.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_出勤機.FormattingEnabled = true;
            this.cmb_出勤機.Location = new System.Drawing.Point(285, 67);
            this.cmb_出勤機.MaxLength = 20;
            this.cmb_出勤機.Name = "cmb_出勤機";
            this.cmb_出勤機.Size = new System.Drawing.Size(121, 24);
            this.cmb_出勤機.TabIndex = 4;
            // 
            // txt_登録コード
            // 
            this.txt_登録コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_登録コード.Location = new System.Drawing.Point(285, 135);
            this.txt_登録コード.Name = "txt_登録コード";
            this.txt_登録コード.Size = new System.Drawing.Size(121, 23);
            this.txt_登録コード.TabIndex = 5;
            // 
            // cmb_職員コード
            // 
            this.cmb_職員コード.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_職員コード.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_職員コード.FormattingEnabled = true;
            this.cmb_職員コード.Location = new System.Drawing.Point(285, 214);
            this.cmb_職員コード.Name = "cmb_職員コード";
            this.cmb_職員コード.Size = new System.Drawing.Size(180, 24);
            this.cmb_職員コード.TabIndex = 6;
            // 
            // btn_登録
            // 
            this.btn_登録.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_登録.Location = new System.Drawing.Point(242, 312);
            this.btn_登録.Name = "btn_登録";
            this.btn_登録.Size = new System.Drawing.Size(91, 34);
            this.btn_登録.TabIndex = 8;
            this.btn_登録.Text = "登録";
            this.btn_登録.UseVisualStyleBackColor = true;
            this.btn_登録.Click += new System.EventHandler(this.btn_登録_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslbl_エラーメッセージ});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(569, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sslbl_エラーメッセージ
            // 
            this.sslbl_エラーメッセージ.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sslbl_エラーメッセージ.Name = "sslbl_エラーメッセージ";
            this.sslbl_エラーメッセージ.Size = new System.Drawing.Size(0, 17);
            // 
            // 出勤機職員登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 414);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_登録);
            this.Controls.Add(this.cmb_職員コード);
            this.Controls.Add(this.txt_登録コード);
            this.Controls.Add(this.cmb_出勤機);
            this.Controls.Add(this.lbl_職員コード);
            this.Controls.Add(this.lbl_登録コード);
            this.Controls.Add(this.lbl_出勤機);
            this.Name = "出勤機職員登録";
            this.Text = "出勤機職員登録";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.出勤機職員登録_FormClosed);
            this.Load += new System.EventHandler(this.出勤機ユーザ登録_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_出勤機;
        private System.Windows.Forms.Label lbl_登録コード;
        private System.Windows.Forms.Label lbl_職員コード;
        private System.Windows.Forms.ComboBox cmb_出勤機;
        private System.Windows.Forms.TextBox txt_登録コード;
        private System.Windows.Forms.ComboBox cmb_職員コード;
        private System.Windows.Forms.Button btn_登録;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sslbl_エラーメッセージ;
    }
}