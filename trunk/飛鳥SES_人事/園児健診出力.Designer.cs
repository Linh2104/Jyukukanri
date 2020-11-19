namespace 飛鳥SES_人事
{
    partial class 園児健診出力
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
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_output = new System.Windows.Forms.Button();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_from
            // 
            this.dtp_from.Location = new System.Drawing.Point(27, 28);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(120, 19);
            this.dtp_from.TabIndex = 126;
            // 
            // dtp_to
            // 
            this.dtp_to.Location = new System.Drawing.Point(199, 28);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(120, 19);
            this.dtp_to.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(164, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 21);
            this.label1.TabIndex = 128;
            this.label1.Text = "~";
            // 
            // btn_output
            // 
            this.btn_output.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_output.Location = new System.Drawing.Point(357, 27);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(77, 24);
            this.btn_output.TabIndex = 129;
            this.btn_output.Text = "出力";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.Btn_output_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 53);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(473, 22);
            this.statusStrip1.TabIndex = 130;
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
            // 園児健診出力
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 75);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.dtp_from);
            this.Name = "園児健診出力";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "園児健診出力";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_output;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}