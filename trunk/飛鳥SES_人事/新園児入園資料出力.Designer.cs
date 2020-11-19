using ComDll;

namespace 飛鳥SES_人事
{
    partial class 新園児入園資料出力
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
            this.lbl_list = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_error = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_print = new System.Windows.Forms.Button();
            this.rtxt_list = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_list
            // 
            this.lbl_list.AutoSize = true;
            this.lbl_list.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_list.Location = new System.Drawing.Point(25, 25);
            this.lbl_list.Name = "lbl_list";
            this.lbl_list.Size = new System.Drawing.Size(100, 23);
            this.lbl_list.TabIndex = 0;
            this.lbl_list.Text = "材料リスト：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_error});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(453, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_error
            // 
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(0, 17);
            // 
            // btn_print
            // 
            this.btn_print.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_print.Location = new System.Drawing.Point(125, 310);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(200, 30);
            this.btn_print.TabIndex = 8;
            this.btn_print.Text = "印　刷";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // rtxt_list
            // 
            this.rtxt_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxt_list.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rtxt_list.Location = new System.Drawing.Point(30, 50);
            this.rtxt_list.Name = "rtxt_list";
            this.rtxt_list.ReadOnly = true;
            this.rtxt_list.Size = new System.Drawing.Size(400, 250);
            this.rtxt_list.TabIndex = 9;
            this.rtxt_list.Text = "";
            // 
            // 新園児入園資料出力
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 373);
            this.Controls.Add(this.rtxt_list);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_list);
            this.Name = "新園児入園資料出力";
            this.Text = "新園児入園材料出力";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.新園児入園資料出力_FormClosed);
            this.Load += new System.EventHandler(this.新園児入園資料出力_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_list;
        private System.Windows.Forms.ToolStripStatusLabel lbl_error;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox rtxt_list;
    }
}