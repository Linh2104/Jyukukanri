namespace 飛鳥SES_人事
{
    partial class 健康状況観察
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
            this.lbl_機嫌 = new System.Windows.Forms.Label();
            this.lbl_しっしん = new System.Windows.Forms.Label();
            this.lbl_せき = new System.Windows.Forms.Label();
            this.lbl_その他 = new System.Windows.Forms.Label();
            this.cmb_機嫌 = new System.Windows.Forms.ComboBox();
            this.cmb_しっしん = new System.Windows.Forms.ComboBox();
            this.cmb_せき = new System.Windows.Forms.ComboBox();
            this.txt_その他 = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_機嫌
            // 
            this.lbl_機嫌.AutoSize = true;
            this.lbl_機嫌.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_機嫌.Location = new System.Drawing.Point(25, 25);
            this.lbl_機嫌.Name = "lbl_機嫌";
            this.lbl_機嫌.Size = new System.Drawing.Size(40, 23);
            this.lbl_機嫌.TabIndex = 0;
            this.lbl_機嫌.Text = "機嫌";
            // 
            // lbl_しっしん
            // 
            this.lbl_しっしん.AutoSize = true;
            this.lbl_しっしん.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_しっしん.Location = new System.Drawing.Point(25, 75);
            this.lbl_しっしん.Name = "lbl_しっしん";
            this.lbl_しっしん.Size = new System.Drawing.Size(70, 23);
            this.lbl_しっしん.TabIndex = 1;
            this.lbl_しっしん.Text = "しっしん";
            // 
            // lbl_せき
            // 
            this.lbl_せき.AutoSize = true;
            this.lbl_せき.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_せき.Location = new System.Drawing.Point(25, 125);
            this.lbl_せき.Name = "lbl_せき";
            this.lbl_せき.Size = new System.Drawing.Size(115, 23);
            this.lbl_せき.TabIndex = 2;
            this.lbl_せき.Text = "せき・はなみず";
            // 
            // lbl_その他
            // 
            this.lbl_その他.AutoSize = true;
            this.lbl_その他.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_その他.Location = new System.Drawing.Point(25, 175);
            this.lbl_その他.Name = "lbl_その他";
            this.lbl_その他.Size = new System.Drawing.Size(55, 23);
            this.lbl_その他.TabIndex = 3;
            this.lbl_その他.Text = "その他";
            // 
            // cmb_機嫌
            // 
            this.cmb_機嫌.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_機嫌.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_機嫌.FormattingEnabled = true;
            this.cmb_機嫌.Items.AddRange(new object[] {
            "良",
            "普通",
            "不良"});
            this.cmb_機嫌.Location = new System.Drawing.Point(175, 20);
            this.cmb_機嫌.Name = "cmb_機嫌";
            this.cmb_機嫌.Size = new System.Drawing.Size(100, 31);
            this.cmb_機嫌.TabIndex = 4;
            // 
            // cmb_しっしん
            // 
            this.cmb_しっしん.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_しっしん.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_しっしん.FormattingEnabled = true;
            this.cmb_しっしん.Items.AddRange(new object[] {
            "有",
            "無"});
            this.cmb_しっしん.Location = new System.Drawing.Point(175, 70);
            this.cmb_しっしん.Name = "cmb_しっしん";
            this.cmb_しっしん.Size = new System.Drawing.Size(100, 31);
            this.cmb_しっしん.TabIndex = 5;
            // 
            // cmb_せき
            // 
            this.cmb_せき.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_せき.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_せき.FormattingEnabled = true;
            this.cmb_せき.Items.AddRange(new object[] {
            "有",
            "無"});
            this.cmb_せき.Location = new System.Drawing.Point(175, 120);
            this.cmb_せき.Name = "cmb_せき";
            this.cmb_せき.Size = new System.Drawing.Size(100, 31);
            this.cmb_せき.TabIndex = 6;
            // 
            // txt_その他
            // 
            this.txt_その他.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_その他.Location = new System.Drawing.Point(175, 170);
            this.txt_その他.MaxLength = 73;
            this.txt_その他.Name = "txt_その他";
            this.txt_その他.Size = new System.Drawing.Size(200, 30);
            this.txt_その他.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_save.Location = new System.Drawing.Point(75, 225);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(100, 30);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "変更";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_cancel.Location = new System.Drawing.Point(225, 225);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 30);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "キャンセル";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // 健康状況観察
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_その他);
            this.Controls.Add(this.cmb_せき);
            this.Controls.Add(this.cmb_しっしん);
            this.Controls.Add(this.cmb_機嫌);
            this.Controls.Add(this.lbl_その他);
            this.Controls.Add(this.lbl_せき);
            this.Controls.Add(this.lbl_しっしん);
            this.Controls.Add(this.lbl_機嫌);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "健康状況観察";
            this.Text = "健康状況観察";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_機嫌;
        private System.Windows.Forms.Label lbl_しっしん;
        private System.Windows.Forms.Label lbl_せき;
        private System.Windows.Forms.Label lbl_その他;
        private System.Windows.Forms.ComboBox cmb_機嫌;
        private System.Windows.Forms.ComboBox cmb_しっしん;
        private System.Windows.Forms.ComboBox cmb_せき;
        private System.Windows.Forms.TextBox txt_その他;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
    }
}