namespace 飛鳥SES_人事
{
    partial class 退園
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
            this.lbl_職員 = new System.Windows.Forms.Label();
            this.lbl_園内職務 = new System.Windows.Forms.Label();
            this.btn_キャンセル = new System.Windows.Forms.Button();
            this.txt_職員 = new System.Windows.Forms.TextBox();
            this.txt_園内職務 = new System.Windows.Forms.TextBox();
            this.btn_退園 = new System.Windows.Forms.Button();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_職員
            // 
            this.lbl_職員.AutoSize = true;
            this.lbl_職員.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_職員.Location = new System.Drawing.Point(81, 69);
            this.lbl_職員.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_職員.Name = "lbl_職員";
            this.lbl_職員.Size = new System.Drawing.Size(52, 25);
            this.lbl_職員.TabIndex = 1;
            this.lbl_職員.Text = "職員";
            // 
            // lbl_園内職務
            // 
            this.lbl_園内職務.AutoSize = true;
            this.lbl_園内職務.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_園内職務.Location = new System.Drawing.Point(81, 158);
            this.lbl_園内職務.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_園内職務.Name = "lbl_園内職務";
            this.lbl_園内職務.Size = new System.Drawing.Size(92, 25);
            this.lbl_園内職務.TabIndex = 1;
            this.lbl_園内職務.Text = "園内職務";
            // 
            // btn_キャンセル
            // 
            this.btn_キャンセル.Location = new System.Drawing.Point(333, 257);
            this.btn_キャンセル.Name = "btn_キャンセル";
            this.btn_キャンセル.Size = new System.Drawing.Size(125, 46);
            this.btn_キャンセル.TabIndex = 2;
            this.btn_キャンセル.Text = "キャンセル";
            this.btn_キャンセル.UseVisualStyleBackColor = true;
            this.btn_キャンセル.Click += new System.EventHandler(this.btn_キャンセル_Click);
            // 
            // txt_職員
            // 
            this.txt_職員.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_職員.Location = new System.Drawing.Point(215, 69);
            this.txt_職員.Margin = new System.Windows.Forms.Padding(4);
            this.txt_職員.Name = "txt_職員";
            this.txt_職員.ReadOnly = true;
            this.txt_職員.Size = new System.Drawing.Size(212, 33);
            this.txt_職員.TabIndex = 8;
            // 
            // txt_園内職務
            // 
            this.txt_園内職務.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_園内職務.Location = new System.Drawing.Point(215, 155);
            this.txt_園内職務.Margin = new System.Windows.Forms.Padding(4);
            this.txt_園内職務.Name = "txt_園内職務";
            this.txt_園内職務.ReadOnly = true;
            this.txt_園内職務.Size = new System.Drawing.Size(212, 33);
            this.txt_園内職務.TabIndex = 8;
            // 
            // btn_退園
            // 
            this.btn_退園.Location = new System.Drawing.Point(151, 257);
            this.btn_退園.Name = "btn_退園";
            this.btn_退園.Size = new System.Drawing.Size(125, 46);
            this.btn_退園.TabIndex = 2;
            this.btn_退園.Text = "退園";
            this.btn_退園.UseVisualStyleBackColor = true;
            this.btn_退園.Click += new System.EventHandler(this.btn_退園_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(629, 22);
            this.statusStrip1.TabIndex = 124;
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
            // 退園
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 374);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt_園内職務);
            this.Controls.Add(this.txt_職員);
            this.Controls.Add(this.btn_退園);
            this.Controls.Add(this.btn_キャンセル);
            this.Controls.Add(this.lbl_園内職務);
            this.Controls.Add(this.lbl_職員);
            this.Name = "退園";
            this.Text = "退園";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.退園_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_職員;
        private System.Windows.Forms.Label lbl_園内職務;
        private System.Windows.Forms.Button btn_キャンセル;
        private System.Windows.Forms.TextBox txt_職員;
        private System.Windows.Forms.TextBox txt_園内職務;
        private System.Windows.Forms.Button btn_退園;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}