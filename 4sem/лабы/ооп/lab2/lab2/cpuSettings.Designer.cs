namespace lab2
{
    partial class cpuSettings
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveCpu = new System.Windows.Forms.Button();
            this.switchback = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.14286F);
            this.label1.Location = new System.Drawing.Point(551, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Процессор";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.14286F);
            this.errorLabel.Location = new System.Drawing.Point(391, 90);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 44);
            this.errorLabel.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label2.Location = new System.Drawing.Point(39, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 40);
            this.label2.TabIndex = 29;
            this.label2.Text = "Производитель";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.radioButton1.Location = new System.Drawing.Point(46, 197);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 37);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Intel";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.radioButton2.Location = new System.Drawing.Point(167, 197);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 37);
            this.radioButton2.TabIndex = 31;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "AMD";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.radioButton3.Location = new System.Drawing.Point(297, 197);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(139, 37);
            this.radioButton3.TabIndex = 32;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Байкал";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label3.Location = new System.Drawing.Point(39, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 40);
            this.label3.TabIndex = 33;
            this.label3.Text = "Серия: ";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(46, 325);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 46);
            this.comboBox1.TabIndex = 34;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label4.Location = new System.Drawing.Point(39, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 40);
            this.label4.TabIndex = 35;
            this.label4.Text = "Модель:  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label5.Location = new System.Drawing.Point(39, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 40);
            this.label5.TabIndex = 37;
            this.label5.Text = "Количество ядер: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label6.Location = new System.Drawing.Point(39, 566);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 40);
            this.label6.TabIndex = 38;
            this.label6.Text = "Частота: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label7.Location = new System.Drawing.Point(39, 642);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 40);
            this.label7.TabIndex = 39;
            this.label7.Text = "Кеш L3(Мб): ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(945, 327);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(344, 39);
            this.progressBar1.TabIndex = 41;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // saveCpu
            // 
            this.saveCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.saveCpu.Location = new System.Drawing.Point(945, 197);
            this.saveCpu.Name = "saveCpu";
            this.saveCpu.Size = new System.Drawing.Size(344, 81);
            this.saveCpu.TabIndex = 40;
            this.saveCpu.Text = "Сохранить";
            this.saveCpu.UseVisualStyleBackColor = true;
            this.saveCpu.Click += new System.EventHandler(this.saveCpu_click);
            // 
            // switchback
            // 
            this.switchback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14286F);
            this.switchback.Location = new System.Drawing.Point(945, 656);
            this.switchback.Name = "switchback";
            this.switchback.Size = new System.Drawing.Size(344, 81);
            this.switchback.TabIndex = 42;
            this.switchback.Text = "Назад";
            this.switchback.UseVisualStyleBackColor = true;
            this.switchback.Click += new System.EventHandler(this.switchback_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label8.Location = new System.Drawing.Point(186, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 40);
            this.label8.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label9.Location = new System.Drawing.Point(346, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 40);
            this.label9.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label10.Location = new System.Drawing.Point(198, 566);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 40);
            this.label10.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.14286F);
            this.label11.Location = new System.Drawing.Point(186, 642);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 40);
            this.label11.TabIndex = 46;
            // 
            // cpuSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.switchback);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.saveCpu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label1);
            this.Name = "cpuSettings";
            this.Size = new System.Drawing.Size(1370, 1029);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button saveCpu;
        private System.Windows.Forms.Button switchback;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
