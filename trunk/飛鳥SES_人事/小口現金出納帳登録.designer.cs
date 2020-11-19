namespace 飛鳥SES_人事
{
    partial class 小口現金出納帳登録
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
            this.lbl_nyuukin = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_kamoku = new System.Windows.Forms.Label();
            this.cmb_kamoku = new System.Windows.Forms.ComboBox();
            this.txt_bikou = new System.Windows.Forms.TextBox();
            this.btn_insert = new System.Windows.Forms.Button();
            this.chk_nyuukin = new System.Windows.Forms.CheckBox();
            this.chk_syukkin = new System.Windows.Forms.CheckBox();
            this.lbl_syukkin = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_bikou = new System.Windows.Forms.Label();
            this.lbl_kingaku = new System.Windows.Forms.Label();
            this.lbl_syukkinsyo = new System.Windows.Forms.Label();
            this.txt_kingaku = new System.Windows.Forms.TextBox();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.lbl_zandaka = new System.Windows.Forms.Label();
            this.lbl_nyuukinsyo = new System.Windows.Forms.Label();
            this.lbl_tekiyou = new System.Windows.Forms.Label();
            this.txt_kamoku = new System.Windows.Forms.TextBox();
            this.txt_zandaka = new System.Windows.Forms.TextBox();
            this.txt_tekiyou = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new ComDll.HL_StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_errorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_nyuukin
            // 
            this.lbl_nyuukin.AutoSize = true;
            this.lbl_nyuukin.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_nyuukin.Location = new System.Drawing.Point(30, 25);
            this.lbl_nyuukin.Name = "lbl_nyuukin";
            this.lbl_nyuukin.Size = new System.Drawing.Size(40, 23);
            this.lbl_nyuukin.TabIndex = 0;
            this.lbl_nyuukin.Text = "入金";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_date.Location = new System.Drawing.Point(30, 70);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(99, 23);
            this.lbl_date.TabIndex = 0;
            this.lbl_date.Text = "日付　[必須]";
            this.lbl_date.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_kamoku
            // 
            this.lbl_kamoku.AutoSize = true;
            this.lbl_kamoku.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_kamoku.Location = new System.Drawing.Point(30, 120);
            this.lbl_kamoku.Name = "lbl_kamoku";
            this.lbl_kamoku.Size = new System.Drawing.Size(129, 23);
            this.lbl_kamoku.TabIndex = 0;
            this.lbl_kamoku.Text = "勘定科目　[必須]";
            this.lbl_kamoku.Visible = false;
            this.lbl_kamoku.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // cmb_kamoku
            // 
            this.cmb_kamoku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_kamoku.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_kamoku.FormattingEnabled = true;
            this.cmb_kamoku.Location = new System.Drawing.Point(250, 120);
            this.cmb_kamoku.MaxLength = 20;
            this.cmb_kamoku.Name = "cmb_kamoku";
            this.cmb_kamoku.Size = new System.Drawing.Size(149, 31);
            this.cmb_kamoku.TabIndex = 4;
            this.cmb_kamoku.Visible = false;
            this.cmb_kamoku.SelectedValueChanged += new System.EventHandler(this.cmb_kamoku_SelectedValueChanged);
            // 
            // txt_bikou
            // 
            this.txt_bikou.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_bikou.Location = new System.Drawing.Point(250, 120);
            this.txt_bikou.MaxLength = 50;
            this.txt_bikou.Name = "txt_bikou";
            this.txt_bikou.Size = new System.Drawing.Size(149, 30);
            this.txt_bikou.TabIndex = 6;
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_insert.Location = new System.Drawing.Point(323, 343);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(107, 34);
            this.btn_insert.TabIndex = 11;
            this.btn_insert.Text = "登録";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // chk_nyuukin
            // 
            this.chk_nyuukin.AutoSize = true;
            this.chk_nyuukin.Checked = true;
            this.chk_nyuukin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_nyuukin.Location = new System.Drawing.Point(100, 29);
            this.chk_nyuukin.Name = "chk_nyuukin";
            this.chk_nyuukin.Size = new System.Drawing.Size(15, 14);
            this.chk_nyuukin.TabIndex = 1;
            this.chk_nyuukin.UseVisualStyleBackColor = true;
            this.chk_nyuukin.CheckedChanged += new System.EventHandler(this.chk_nyuukin_CheckedChanged);
            // 
            // chk_syukkin
            // 
            this.chk_syukkin.AutoSize = true;
            this.chk_syukkin.Location = new System.Drawing.Point(215, 29);
            this.chk_syukkin.Name = "chk_syukkin";
            this.chk_syukkin.Size = new System.Drawing.Size(15, 14);
            this.chk_syukkin.TabIndex = 2;
            this.chk_syukkin.UseVisualStyleBackColor = true;
            this.chk_syukkin.CheckedChanged += new System.EventHandler(this.chk_syukkin_CheckedChanged);
            // 
            // lbl_syukkin
            // 
            this.lbl_syukkin.AutoSize = true;
            this.lbl_syukkin.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_syukkin.Location = new System.Drawing.Point(145, 25);
            this.lbl_syukkin.Name = "lbl_syukkin";
            this.lbl_syukkin.Size = new System.Drawing.Size(40, 23);
            this.lbl_syukkin.TabIndex = 0;
            this.lbl_syukkin.Text = "出金";
            // 
            // dtp_date
            // 
            this.dtp_date.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtp_date.Location = new System.Drawing.Point(250, 70);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(149, 30);
            this.dtp_date.TabIndex = 3;
            // 
            // lbl_bikou
            // 
            this.lbl_bikou.AutoSize = true;
            this.lbl_bikou.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_bikou.Location = new System.Drawing.Point(30, 120);
            this.lbl_bikou.Name = "lbl_bikou";
            this.lbl_bikou.Size = new System.Drawing.Size(40, 23);
            this.lbl_bikou.TabIndex = 0;
            this.lbl_bikou.Text = "備考";
            // 
            // lbl_kingaku
            // 
            this.lbl_kingaku.AutoSize = true;
            this.lbl_kingaku.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_kingaku.Location = new System.Drawing.Point(30, 170);
            this.lbl_kingaku.Name = "lbl_kingaku";
            this.lbl_kingaku.Size = new System.Drawing.Size(99, 23);
            this.lbl_kingaku.TabIndex = 19;
            this.lbl_kingaku.Text = "金額　[必須]";
            this.lbl_kingaku.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_syukkinsyo
            // 
            this.lbl_syukkinsyo.AutoSize = true;
            this.lbl_syukkinsyo.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_syukkinsyo.Location = new System.Drawing.Point(30, 270);
            this.lbl_syukkinsyo.Name = "lbl_syukkinsyo";
            this.lbl_syukkinsyo.Size = new System.Drawing.Size(198, 23);
            this.lbl_syukkinsyo.TabIndex = 20;
            this.lbl_syukkinsyo.Text = "領収書/出金証明書　[必須]";
            this.lbl_syukkinsyo.Visible = false;
            this.lbl_syukkinsyo.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // txt_kingaku
            // 
            this.txt_kingaku.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_kingaku.Location = new System.Drawing.Point(250, 170);
            this.txt_kingaku.MaxLength = 12;
            this.txt_kingaku.Name = "txt_kingaku";
            this.txt_kingaku.Size = new System.Drawing.Size(149, 30);
            this.txt_kingaku.TabIndex = 8;
            this.txt_kingaku.Text = "￥";
            this.txt_kingaku.TextChanged += new System.EventHandler(this.txt_kingaku_TextChanged);
            this.txt_kingaku.Validated += new System.EventHandler(this.txt_kingaku_Validated);
            // 
            // txt_file
            // 
            this.txt_file.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_file.Location = new System.Drawing.Point(250, 220);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(149, 30);
            this.txt_file.TabIndex = 9;
            this.txt_file.TextChanged += new System.EventHandler(this.txt_file_TextChanged);
            // 
            // btn_file
            // 
            this.btn_file.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_file.Location = new System.Drawing.Point(440, 218);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(149, 34);
            this.btn_file.TabIndex = 10;
            this.btn_file.Text = "ファイル選択";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_update.Location = new System.Drawing.Point(323, 343);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(107, 34);
            this.btn_update.TabIndex = 12;
            this.btn_update.Text = "変更";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_delete.Location = new System.Drawing.Point(492, 343);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(107, 34);
            this.btn_delete.TabIndex = 13;
            this.btn_delete.Text = "削除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // lbl_zandaka
            // 
            this.lbl_zandaka.AutoSize = true;
            this.lbl_zandaka.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_zandaka.Location = new System.Drawing.Point(440, 170);
            this.lbl_zandaka.Name = "lbl_zandaka";
            this.lbl_zandaka.Size = new System.Drawing.Size(40, 23);
            this.lbl_zandaka.TabIndex = 27;
            this.lbl_zandaka.Text = "残高";
            // 
            // lbl_nyuukinsyo
            // 
            this.lbl_nyuukinsyo.AutoSize = true;
            this.lbl_nyuukinsyo.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_nyuukinsyo.Location = new System.Drawing.Point(30, 220);
            this.lbl_nyuukinsyo.Name = "lbl_nyuukinsyo";
            this.lbl_nyuukinsyo.Size = new System.Drawing.Size(144, 23);
            this.lbl_nyuukinsyo.TabIndex = 29;
            this.lbl_nyuukinsyo.Text = "入金申請書　[必須]";
            this.lbl_nyuukinsyo.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // lbl_tekiyou
            // 
            this.lbl_tekiyou.AutoSize = true;
            this.lbl_tekiyou.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_tekiyou.Location = new System.Drawing.Point(30, 170);
            this.lbl_tekiyou.Name = "lbl_tekiyou";
            this.lbl_tekiyou.Size = new System.Drawing.Size(99, 23);
            this.lbl_tekiyou.TabIndex = 30;
            this.lbl_tekiyou.Text = "摘要　[必須]";
            this.lbl_tekiyou.Visible = false;
            this.lbl_tekiyou.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_必須_Paint);
            // 
            // txt_kamoku
            // 
            this.txt_kamoku.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_kamoku.Location = new System.Drawing.Point(440, 120);
            this.txt_kamoku.MaxLength = 50;
            this.txt_kamoku.Name = "txt_kamoku";
            this.txt_kamoku.Size = new System.Drawing.Size(149, 30);
            this.txt_kamoku.TabIndex = 5;
            this.txt_kamoku.Visible = false;
            // 
            // txt_zandaka
            // 
            this.txt_zandaka.Enabled = false;
            this.txt_zandaka.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_zandaka.Location = new System.Drawing.Point(520, 170);
            this.txt_zandaka.MaxLength = 12;
            this.txt_zandaka.Name = "txt_zandaka";
            this.txt_zandaka.Size = new System.Drawing.Size(149, 30);
            this.txt_zandaka.TabIndex = 32;
            this.txt_zandaka.Text = "￥";
            this.txt_zandaka.TextChanged += new System.EventHandler(this.txt_zandaka_TextChanged);
            this.txt_zandaka.Validated += new System.EventHandler(this.txt_zandaka_Validated);
            // 
            // txt_tekiyou
            // 
            this.txt_tekiyou.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_tekiyou.Location = new System.Drawing.Point(250, 170);
            this.txt_tekiyou.MaxLength = 50;
            this.txt_tekiyou.Name = "txt_tekiyou";
            this.txt_tekiyou.Size = new System.Drawing.Size(149, 30);
            this.txt_tekiyou.TabIndex = 7;
            this.txt_tekiyou.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1,
            this.lbl_errorMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(708, 22);
            this.statusStrip1.TabIndex = 124;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_errorMessage
            // 
            this.lbl_errorMessage.Name = "lbl_errorMessage";
            this.lbl_errorMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // 小口現金出納帳登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 418);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt_tekiyou);
            this.Controls.Add(this.txt_zandaka);
            this.Controls.Add(this.txt_kamoku);
            this.Controls.Add(this.lbl_tekiyou);
            this.Controls.Add(this.lbl_nyuukinsyo);
            this.Controls.Add(this.lbl_zandaka);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.txt_file);
            this.Controls.Add(this.txt_kingaku);
            this.Controls.Add(this.lbl_syukkinsyo);
            this.Controls.Add(this.lbl_kingaku);
            this.Controls.Add(this.lbl_bikou);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.lbl_syukkin);
            this.Controls.Add(this.chk_syukkin);
            this.Controls.Add(this.chk_nyuukin);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.txt_bikou);
            this.Controls.Add(this.cmb_kamoku);
            this.Controls.Add(this.lbl_kamoku);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_nyuukin);
            this.Name = "小口現金出納帳登録";
            this.Text = "小口現金出納帳登録";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.小口現金出納帳登録_FormClosed);
            this.Load += new System.EventHandler(this.小口現金出納帳登録_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nyuukin;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_kamoku;
        private System.Windows.Forms.ComboBox cmb_kamoku;
        private System.Windows.Forms.TextBox txt_bikou;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.CheckBox chk_nyuukin;
        private System.Windows.Forms.CheckBox chk_syukkin;
        private System.Windows.Forms.Label lbl_syukkin;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label lbl_bikou;
        private System.Windows.Forms.Label lbl_kingaku;
        private System.Windows.Forms.Label lbl_syukkinsyo;
        private System.Windows.Forms.TextBox txt_kingaku;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lbl_zandaka;
        private System.Windows.Forms.Label lbl_nyuukinsyo;
        private System.Windows.Forms.Label lbl_tekiyou;
        private System.Windows.Forms.TextBox txt_kamoku;
        private System.Windows.Forms.TextBox txt_zandaka;
        private System.Windows.Forms.TextBox txt_tekiyou;
        private ComDll.HL_StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_errorMessage;
    }
}