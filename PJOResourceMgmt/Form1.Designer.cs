namespace PJOMgmt
{
    partial class PJOForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRsrcAdd = new System.Windows.Forms.Button();
            this.btnRsrcDel = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.ddlUrl = new System.Windows.Forms.ComboBox();
            this.lblRsrcCnt = new System.Windows.Forms.Label();
            this.lblAfterResourceCount = new System.Windows.Forms.Label();
            this.txtAug = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCnt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCnt = new System.Windows.Forms.Label();
            this.lblDataCnt = new System.Windows.Forms.Label();
            this.lblCurrentCnt = new System.Windows.Forms.Label();
            this.txtAdditional = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStdRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRsrcAdd
            // 
            this.btnRsrcAdd.Location = new System.Drawing.Point(220, 143);
            this.btnRsrcAdd.Name = "btnRsrcAdd";
            this.btnRsrcAdd.Size = new System.Drawing.Size(75, 25);
            this.btnRsrcAdd.TabIndex = 0;
            this.btnRsrcAdd.Text = "追加";
            this.btnRsrcAdd.UseVisualStyleBackColor = true;
            this.btnRsrcAdd.Click += new System.EventHandler(this.btnRsrcAdd_Click);
            // 
            // btnRsrcDel
            // 
            this.btnRsrcDel.Location = new System.Drawing.Point(139, 143);
            this.btnRsrcDel.Name = "btnRsrcDel";
            this.btnRsrcDel.Size = new System.Drawing.Size(75, 25);
            this.btnRsrcDel.TabIndex = 1;
            this.btnRsrcDel.Text = "削除";
            this.btnRsrcDel.UseVisualStyleBackColor = true;
            this.btnRsrcDel.Click += new System.EventHandler(this.btnRsrcDel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(526, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(78, 24);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(526, 20);
            this.txtAccount.TabIndex = 3;
            // 
            // ddlUrl
            // 
            this.ddlUrl.FormattingEnabled = true;
            this.ddlUrl.Location = new System.Drawing.Point(78, 89);
            this.ddlUrl.Name = "ddlUrl";
            this.ddlUrl.Size = new System.Drawing.Size(526, 21);
            this.ddlUrl.TabIndex = 4;
            // 
            // lblRsrcCnt
            // 
            this.lblRsrcCnt.AutoSize = true;
            this.lblRsrcCnt.Location = new System.Drawing.Point(834, 24);
            this.lblRsrcCnt.Name = "lblRsrcCnt";
            this.lblRsrcCnt.Size = new System.Drawing.Size(0, 13);
            this.lblRsrcCnt.TabIndex = 5;
            // 
            // lblAfterResourceCount
            // 
            this.lblAfterResourceCount.AutoSize = true;
            this.lblAfterResourceCount.Location = new System.Drawing.Point(717, 20);
            this.lblAfterResourceCount.Name = "lblAfterResourceCount";
            this.lblAfterResourceCount.Size = new System.Drawing.Size(119, 13);
            this.lblAfterResourceCount.TabIndex = 6;
            this.lblAfterResourceCount.Text = "投入するリソースの件数";
            // 
            // txtAug
            // 
            this.txtAug.Location = new System.Drawing.Point(908, 16);
            this.txtAug.Name = "txtAug";
            this.txtAug.Size = new System.Drawing.Size(51, 20);
            this.txtAug.TabIndex = 7;
            this.txtAug.Text = "v";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(872, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "×";
            // 
            // btnCnt
            // 
            this.btnCnt.Location = new System.Drawing.Point(58, 143);
            this.btnCnt.Name = "btnCnt";
            this.btnCnt.Size = new System.Drawing.Size(75, 25);
            this.btnCnt.TabIndex = 9;
            this.btnCnt.Text = "件数取得";
            this.btnCnt.UseVisualStyleBackColor = true;
            this.btnCnt.Click += new System.EventHandler(this.btnCnt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(717, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "現在のリソースの件数";
            // 
            // lblCnt
            // 
            this.lblCnt.AutoSize = true;
            this.lblCnt.Location = new System.Drawing.Point(891, 59);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(0, 13);
            this.lblCnt.TabIndex = 11;
            // 
            // lblDataCnt
            // 
            this.lblDataCnt.AutoSize = true;
            this.lblDataCnt.Location = new System.Drawing.Point(840, 20);
            this.lblDataCnt.Name = "lblDataCnt";
            this.lblDataCnt.Size = new System.Drawing.Size(23, 13);
            this.lblDataCnt.TabIndex = 12;
            this.lblDataCnt.Text = "NU";
            // 
            // lblCurrentCnt
            // 
            this.lblCurrentCnt.AutoSize = true;
            this.lblCurrentCnt.Location = new System.Drawing.Point(840, 59);
            this.lblCurrentCnt.Name = "lblCurrentCnt";
            this.lblCurrentCnt.Size = new System.Drawing.Size(23, 13);
            this.lblCurrentCnt.TabIndex = 13;
            this.lblCurrentCnt.Text = "NU";
            // 
            // txtAdditional
            // 
            this.txtAdditional.Location = new System.Drawing.Point(719, 90);
            this.txtAdditional.Name = "txtAdditional";
            this.txtAdditional.Size = new System.Drawing.Size(51, 20);
            this.txtAdditional.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "ResourceField";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "標準単価設定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "強制チェックイン";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(52, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "プロパティマップ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "しぇあぽぞーん";
            // 
            // txtStdRate
            // 
            this.txtStdRate.Location = new System.Drawing.Point(153, 232);
            this.txtStdRate.Name = "txtStdRate";
            this.txtStdRate.Size = new System.Drawing.Size(75, 20);
            this.txtStdRate.TabIndex = 20;
            // 
            // PJOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 670);
            this.Controls.Add(this.txtStdRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAdditional);
            this.Controls.Add(this.lblCurrentCnt);
            this.Controls.Add(this.lblDataCnt);
            this.Controls.Add(this.lblCnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCnt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAug);
            this.Controls.Add(this.lblAfterResourceCount);
            this.Controls.Add(this.lblRsrcCnt);
            this.Controls.Add(this.ddlUrl);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnRsrcDel);
            this.Controls.Add(this.btnRsrcAdd);
            this.Name = "PJOForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRsrcAdd;
        private System.Windows.Forms.Button btnRsrcDel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox ddlUrl;
        private System.Windows.Forms.Label lblRsrcCnt;
        private System.Windows.Forms.Label lblAfterResourceCount;
        private System.Windows.Forms.TextBox txtAug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCnt;
        private System.Windows.Forms.Label lblDataCnt;
        private System.Windows.Forms.Label lblCurrentCnt;
        private System.Windows.Forms.TextBox txtAdditional;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStdRate;
    }
}

