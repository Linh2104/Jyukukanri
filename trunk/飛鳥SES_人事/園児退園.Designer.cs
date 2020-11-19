namespace 飛鳥SES_人事
{
    partial class 園児退園
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
            this.lbl_園児名前 = new System.Windows.Forms.Label();
            this.cmb_園児名前 = new System.Windows.Forms.ComboBox();
            this.cmb_退園事由 = new System.Windows.Forms.ComboBox();
            this.dtp_退園日 = new System.Windows.Forms.DateTimePicker();
            this.txt_その他 = new System.Windows.Forms.TextBox();
            this.txt_保育事業利用終了ファイル = new System.Windows.Forms.TextBox();
            this.lbl_保育事業利用終了ファイル = new System.Windows.Forms.Label();
            this.lbl_退園事由 = new System.Windows.Forms.Label();
            this.退園日 = new System.Windows.Forms.Label();
            this.btn_選択 = new System.Windows.Forms.Button();
            this.btn_登録 = new System.Windows.Forms.Button();
            this.btn_キャンセル = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_備考 = new System.Windows.Forms.Label();
            this.txt_備考 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_園児名前
            // 
            this.lbl_園児名前.AutoSize = true;
            this.lbl_園児名前.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_園児名前.Location = new System.Drawing.Point(59, 28);
            this.lbl_園児名前.Name = "lbl_園児名前";
            this.lbl_園児名前.Size = new System.Drawing.Size(41, 20);
            this.lbl_園児名前.TabIndex = 0;
            this.lbl_園児名前.Text = "名前";
            // 
            // cmb_園児名前
            // 
            this.cmb_園児名前.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_園児名前.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_園児名前.FormattingEnabled = true;
            this.cmb_園児名前.Location = new System.Drawing.Point(217, 29);
            this.cmb_園児名前.Name = "cmb_園児名前";
            this.cmb_園児名前.Size = new System.Drawing.Size(263, 28);
            this.cmb_園児名前.TabIndex = 0;
            this.cmb_園児名前.SelectedIndexChanged += new System.EventHandler(this.cmb_園児名前_SelectedIndexChanged);
            // 
            // cmb_退園事由
            // 
            this.cmb_退園事由.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_退園事由.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.cmb_退園事由.FormattingEnabled = true;
            this.cmb_退園事由.Items.AddRange(new object[] {
            "自己都合",
            "定年",
            "契約期間の満了",
            "移籍出向",
            "その他"});
            this.cmb_退園事由.Location = new System.Drawing.Point(217, 107);
            this.cmb_退園事由.Name = "cmb_退園事由";
            this.cmb_退園事由.Size = new System.Drawing.Size(263, 28);
            this.cmb_退園事由.TabIndex = 2;
            this.cmb_退園事由.SelectedIndexChanged += new System.EventHandler(this.cmb_退園事由_SelectedIndexChanged);
            // 
            // dtp_退園日
            // 
            this.dtp_退園日.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.dtp_退園日.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_退園日.Location = new System.Drawing.Point(217, 63);
            this.dtp_退園日.Name = "dtp_退園日";
            this.dtp_退園日.Size = new System.Drawing.Size(263, 28);
            this.dtp_退園日.TabIndex = 1;
            // 
            // txt_その他
            // 
            this.txt_その他.Enabled = false;
            this.txt_その他.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_その他.Location = new System.Drawing.Point(217, 152);
            this.txt_その他.MaxLength = 500;
            this.txt_その他.Multiline = true;
            this.txt_その他.Name = "txt_その他";
            this.txt_その他.Size = new System.Drawing.Size(263, 64);
            this.txt_その他.TabIndex = 3;
            // 
            // txt_保育事業利用終了ファイル
            // 
            this.txt_保育事業利用終了ファイル.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_保育事業利用終了ファイル.Location = new System.Drawing.Point(218, 263);
            this.txt_保育事業利用終了ファイル.Name = "txt_保育事業利用終了ファイル";
            this.txt_保育事業利用終了ファイル.ReadOnly = true;
            this.txt_保育事業利用終了ファイル.Size = new System.Drawing.Size(215, 28);
            this.txt_保育事業利用終了ファイル.TabIndex = 9;
            // 
            // lbl_保育事業利用終了ファイル
            // 
            this.lbl_保育事業利用終了ファイル.AutoSize = true;
            this.lbl_保育事業利用終了ファイル.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_保育事業利用終了ファイル.Location = new System.Drawing.Point(59, 234);
            this.lbl_保育事業利用終了ファイル.Name = "lbl_保育事業利用終了ファイル";
            this.lbl_保育事業利用終了ファイル.Size = new System.Drawing.Size(210, 20);
            this.lbl_保育事業利用終了ファイル.TabIndex = 10;
            this.lbl_保育事業利用終了ファイル.Text = "保育事業利用終了書　[必須]";
            this.lbl_保育事業利用終了ファイル.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_退園事由
            // 
            this.lbl_退園事由.AutoSize = true;
            this.lbl_退園事由.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_退園事由.Location = new System.Drawing.Point(59, 110);
            this.lbl_退園事由.Name = "lbl_退園事由";
            this.lbl_退園事由.Size = new System.Drawing.Size(73, 20);
            this.lbl_退園事由.TabIndex = 12;
            this.lbl_退園事由.Text = "退園事由";
            // 
            // 退園日
            // 
            this.退園日.AutoSize = true;
            this.退園日.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.退園日.Location = new System.Drawing.Point(59, 66);
            this.退園日.Name = "退園日";
            this.退園日.Size = new System.Drawing.Size(57, 20);
            this.退園日.TabIndex = 13;
            this.退園日.Text = "退園日";
            // 
            // btn_選択
            // 
            this.btn_選択.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_選択.Location = new System.Drawing.Point(439, 262);
            this.btn_選択.Name = "btn_選択";
            this.btn_選択.Size = new System.Drawing.Size(41, 29);
            this.btn_選択.TabIndex = 4;
            this.btn_選択.Text = "・・・";
            this.btn_選択.UseVisualStyleBackColor = true;
            this.btn_選択.Click += new System.EventHandler(this.btn_選択_Click);
            // 
            // btn_登録
            // 
            this.btn_登録.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_登録.Location = new System.Drawing.Point(176, 385);
            this.btn_登録.Name = "btn_登録";
            this.btn_登録.Size = new System.Drawing.Size(89, 29);
            this.btn_登録.TabIndex = 6;
            this.btn_登録.Text = "登録";
            this.btn_登録.UseVisualStyleBackColor = true;
            this.btn_登録.Click += new System.EventHandler(this.btn_登録_Click);
            // 
            // btn_キャンセル
            // 
            this.btn_キャンセル.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_キャンセル.Location = new System.Drawing.Point(310, 385);
            this.btn_キャンセル.Name = "btn_キャンセル";
            this.btn_キャンセル.Size = new System.Drawing.Size(89, 29);
            this.btn_キャンセル.TabIndex = 7;
            this.btn_キャンセル.Text = "キャンセル";
            this.btn_キャンセル.UseVisualStyleBackColor = true;
            this.btn_キャンセル.Click += new System.EventHandler(this.btn_キャンセル_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(577, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_備考
            // 
            this.lbl_備考.AutoSize = true;
            this.lbl_備考.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_備考.Location = new System.Drawing.Point(59, 306);
            this.lbl_備考.Name = "lbl_備考";
            this.lbl_備考.Size = new System.Drawing.Size(41, 20);
            this.lbl_備考.TabIndex = 19;
            this.lbl_備考.Text = "備考";
            // 
            // txt_備考
            // 
            this.txt_備考.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.txt_備考.Location = new System.Drawing.Point(217, 303);
            this.txt_備考.MaxLength = 500;
            this.txt_備考.Multiline = true;
            this.txt_備考.Name = "txt_備考";
            this.txt_備考.Size = new System.Drawing.Size(263, 64);
            this.txt_備考.TabIndex = 5;
            // 
            // 園児退園
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 445);
            this.Controls.Add(this.txt_備考);
            this.Controls.Add(this.lbl_備考);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_キャンセル);
            this.Controls.Add(this.btn_登録);
            this.Controls.Add(this.btn_選択);
            this.Controls.Add(this.退園日);
            this.Controls.Add(this.lbl_退園事由);
            this.Controls.Add(this.lbl_保育事業利用終了ファイル);
            this.Controls.Add(this.txt_保育事業利用終了ファイル);
            this.Controls.Add(this.txt_その他);
            this.Controls.Add(this.dtp_退園日);
            this.Controls.Add(this.cmb_退園事由);
            this.Controls.Add(this.cmb_園児名前);
            this.Controls.Add(this.lbl_園児名前);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "園児退園";
            this.Text = "園児退園";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.園児退園_FormClosed);
            this.Load += new System.EventHandler(this.園児退園_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_園児名前;
        private System.Windows.Forms.ComboBox cmb_園児名前;
        private System.Windows.Forms.ComboBox cmb_退園事由;
        private System.Windows.Forms.DateTimePicker dtp_退園日;
        private System.Windows.Forms.TextBox txt_その他;
        private System.Windows.Forms.TextBox txt_保育事業利用終了ファイル;
        private System.Windows.Forms.Label lbl_保育事業利用終了ファイル;
        private System.Windows.Forms.Label lbl_退園事由;
        private System.Windows.Forms.Label 退園日;
        private System.Windows.Forms.Button btn_選択;
        private System.Windows.Forms.Button btn_登録;
        private System.Windows.Forms.Button btn_キャンセル;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lbl_備考;
        private System.Windows.Forms.TextBox txt_備考;
    }
}