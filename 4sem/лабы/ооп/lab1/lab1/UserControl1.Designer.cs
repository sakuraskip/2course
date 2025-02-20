namespace lab1
{
    partial class UserControl1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F);
            this.label1.Location = new System.Drawing.Point(573, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "бинарный калькулятор!!!";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.textBox1.Location = new System.Drawing.Point(71, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 47);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.textBox2.Location = new System.Drawing.Point(71, 471);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(247, 47);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.14286F);
            this.label2.Location = new System.Drawing.Point(102, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 51);
            this.label2.TabIndex = 3;
            this.label2.Text = "число 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.14286F);
            this.label3.Location = new System.Drawing.Point(102, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 51);
            this.label3.TabIndex = 4;
            this.label3.Text = "число 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.14286F);
            this.label4.Location = new System.Drawing.Point(1196, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 51);
            this.label4.TabIndex = 5;
            this.label4.Text = "Результат: ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.14286F);
            this.button1.Location = new System.Drawing.Point(433, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 82);
            this.button1.TabIndex = 6;
            this.button1.Text = "побитовое и";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.14286F);
            this.button2.Location = new System.Drawing.Point(433, 436);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(267, 82);
            this.button2.TabIndex = 7;
            this.button2.Text = "побитовое или";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.button3.Location = new System.Drawing.Point(782, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(277, 82);
            this.button3.TabIndex = 8;
            this.button3.Text = "исключающее или";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.button4.Location = new System.Drawing.Point(782, 436);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(277, 82);
            this.button4.TabIndex = 9;
            this.button4.Text = "побитовое не  (число 1)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.14286F);
            this.label5.Location = new System.Drawing.Point(574, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 51);
            this.label5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.14286F);
            this.label6.Location = new System.Drawing.Point(63, 620);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(429, 44);
            this.label6.TabIndex = 11;
            this.label6.Text = "Восьмеричная запись: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.14286F);
            this.label7.Location = new System.Drawing.Point(63, 706);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 44);
            this.label7.TabIndex = 12;
            this.label7.Text = "двоичная: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.14286F);
            this.label8.Location = new System.Drawing.Point(63, 796);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(397, 44);
            this.label8.TabIndex = 13;
            this.label8.Text = "шестнадцатеричная: ";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F);
            this.button5.Location = new System.Drawing.Point(627, 945);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(462, 118);
            this.button5.TabIndex = 14;
            this.button5.Text = "Очистка";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1758, 1175);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
    }
}
