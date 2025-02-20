using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "Результат: ";
                label5.Text = "";
                
                if (!Int32.TryParse(textBox2.Text, out int num2))
                {
                    label5.Text = "неверно введено число 2";
                    
                    return;
                }
                if (!Int32.TryParse(textBox1.Text, out int num1))
                {
                    label5.Text = "Неверно введено число 1";
                    return;
                }
                int num = num1 & num2;
                label4.Text += num;
                convertNumbers(num);
            }
            catch(Exception ex)
            {
                label5.Text = ex.Message;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                label4.Text = "Результат: ";
                label5.Text = "";

               
                if (!Int32.TryParse(textBox2.Text, out int num2))
                {
                    label5.Text = "неверно введено число 2";
                    return;

                }
                if (!Int32.TryParse(textBox1.Text, out int num1))
                {
                    label5.Text = "Неверно введено число 1";
                    return;

                }
                int num = num1 | num2;
                label4.Text += num;
                convertNumbers(num);
            }
            catch (Exception ex)
            {
                label5.Text = ex.Message;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "Результат: ";
                label5.Text = "";

                
                if (!Int32.TryParse(textBox2.Text, out int num2))
                {
                    label5.Text = "неверно введено число 2";
                    return;

                }
                if (!Int32.TryParse(textBox1.Text, out int num1))
                {
                    label5.Text = "Неверно введено число 1";
                    return;

                }
                int num = num1 ^ num2;
                label4.Text += num;
                convertNumbers(num);
            }
            catch (Exception ex)
            {
                label5.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "Результат: ";
                label5.Text = "";

                if (!Int32.TryParse(textBox1.Text, out int num1))
                {
                    label5.Text = "Неверно введено число 1";
                    return;

                }

                int num = ~num1;
                label4.Text += num;
                convertNumbers(num);
            }
            catch (Exception ex)
            {
                label5.Text = ex.Message;
            }
        }
        private void convertNumbers(int num)
        {
            if(num <0)
            {
                label6.Text = $"восьмеричная: {Convert.ToString(Math.Abs(num+1), 8)}";
            }
            else
            {
                label6.Text = $"восьмеричная: {Convert.ToString(Math.Abs(num), 8)}";

            }

            label7.Text = $"двоичная: {Convert.ToString(num, 2)}";
            label8.Text = $"шестнадцатеричная: { Convert.ToString(num, 16)}";

        }

        private void button5_Click(object sender, EventArgs e)
        {

            label4.Text = "Результат: ";
            label5.Text = "";
            label6.Text = "восьмеричная: ";
            label7.Text = "двоичная: ";
            label8.Text = "шестнадцатеричная: ";
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
