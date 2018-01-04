namespace Chess
{
    partial class Form2
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Button3 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button3
            // 
            this.Button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Button3.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.ForeColor = System.Drawing.Color.White;
            this.Button3.Location = new System.Drawing.Point(38, 701);
            this.Button3.Margin = new System.Windows.Forms.Padding(8);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(200, 85);
            this.Button3.TabIndex = 112;
            this.Button3.Text = "Broadcast";
            this.Button3.UseVisualStyleBackColor = false;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Button1.Font = new System.Drawing.Font("Bahnschrift", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(38, 574);
            this.Button1.Margin = new System.Windows.Forms.Padding(8);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(200, 85);
            this.Button1.TabIndex = 110;
            this.Button1.Text = "LOG IN";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox1.Font = new System.Drawing.Font("Bahnschrift", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.Location = new System.Drawing.Point(273, 404);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(8);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(342, 52);
            this.TextBox1.TabIndex = 107;
            this.TextBox1.Text = "18.216.242.191";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Bahnschrift", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(71, 404);
            this.Label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(158, 41);
            this.Label1.TabIndex = 106;
            this.Label1.Text = "Server IP";
            // 
            // TextBox3
            // 
            this.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox3.Font = new System.Drawing.Font("Bahnschrift", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox3.Location = new System.Drawing.Point(273, 477);
            this.TextBox3.Margin = new System.Windows.Forms.Padding(8);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(342, 52);
            this.TextBox3.TabIndex = 105;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Bahnschrift", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(17, 481);
            this.Label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(211, 41);
            this.Label4.TabIndex = 104;
            this.Label4.Text = "Player Name";
            // 
            // ListBox1
            // 
            this.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox1.Font = new System.Drawing.Font("微軟正黑體", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 42;
            this.ListBox1.Location = new System.Drawing.Point(275, 554);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(8);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(340, 380);
            this.ListBox1.TabIndex = 102;
            // 
            // Button2
            // 
            this.Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button2.Enabled = false;
            this.Button2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(1339, 840);
            this.Button2.Margin = new System.Windows.Forms.Padding(8);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(226, 81);
            this.Button2.TabIndex = 101;
            this.Button2.Text = "SEND";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // TextBox4
            // 
            this.TextBox4.Font = new System.Drawing.Font("Bahnschrift", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox4.Location = new System.Drawing.Point(679, 38);
            this.TextBox4.Margin = new System.Windows.Forms.Padding(8);
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox4.Size = new System.Drawing.Size(886, 784);
            this.TextBox4.TabIndex = 100;
            // 
            // TextBox5
            // 
            this.TextBox5.BackColor = System.Drawing.Color.White;
            this.TextBox5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox5.Location = new System.Drawing.Point(679, 853);
            this.TextBox5.Margin = new System.Windows.Forms.Padding(8);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(636, 55);
            this.TextBox5.TabIndex = 99;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(95)))), ((int)(((byte)(115)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(95)))), ((int)(((byte)(115)))));
            this.button4.Font = new System.Drawing.Font("Bahnschrift", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(38, 823);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 85);
            this.button4.TabIndex = 113;
            this.button4.Text = "INVITE";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Chess.Properties.Resources._32fdec66_b333_4a4a_affe_0b03cfbcfee4;
            this.pictureBox1.Location = new System.Drawing.Point(36, -82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 643);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1626, 982);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.TextBox5);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "Form2";
            this.Text = "TCP聊天室客戶端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.TextBox TextBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

