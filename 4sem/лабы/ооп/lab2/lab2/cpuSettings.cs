using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace lab2
{
    public partial class cpuSettings : UserControl
    {
        public event EventHandler SwitchBack;
        public Computer computer;
        public cpuSettings()
        {
            InitializeComponent();
        }

        private void saveCpu_click(object sender, EventArgs e)
        {
            computer.processor = new Processor();
            errorLabel.Text = "";
            if(!checkFields())
            {
                errorLabel.Text = "не все поля заполнены";
                return;
         
            }
            if (radioButton1.Checked)
            {
                computer.processor.производитель = Processor.Производитель.Intel;
            }
            else if(radioButton2.Checked)
            {
                computer.processor.производитель = Processor.Производитель.AMD;
            }
            else if(radioButton3.Checked)
            {
                computer.processor.производитель = Processor.Производитель.Байкал;
            }
            computer.processor.Серия = comboBox1.SelectedItem.ToString();
            computer.processor.Модель = label8.Text;
            computer.processor.количество_ядер = Convert.ToInt32(label9.Text);
            computer.processor.Frequency = label10.Text;
            computer.processor.Cache = Convert.ToInt32(label11.Text);

        }

        private bool checkFields()
        {
            RadioButton[] buttons = { radioButton1, radioButton2, radioButton3 };
            bool radiobool = false;
            foreach (RadioButton button in buttons)
            {
                if(button.Checked)
                {
                    radiobool = true;
                }
            }
            progressBar1.Value = 35;
            if(!radiobool)
            {
                return false;
            }
            progressBar1.Value = 70;

            if (comboBox1.SelectedIndex == -1)
            {
                return false;
            }
            progressBar1.Value = 100;
            return true;

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            if(radioButton1.Checked)
            {
                comboBox1.Items.Add("Core i7");
                comboBox1.Items.Add("Core i5");
            }
            else if(radioButton2.Checked)
            {
                comboBox1.Items.Add("Ryzen 5");
                comboBox1.Items.Add("Ryzen 7");
            }
            else if (radioButton3.Checked)
            {
                comboBox1.Items.Add("Байкал-Т");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Core i7":
                    {
                        label8.Text += "i7-11700";
                        label9.Text += "8";
                        label10.Text += "3.6ГГц";
                        label11.Text += "16";
                        break;
                    }
                case "Core i5":
                    {
                        label8.Text += "i5-11400";
                        label9.Text += "6";
                        label10.Text += "2.6ГГц";
                        label11.Text += "12";
                        break;
                    }

                case "Ryzen 5":
                    {
                        label8.Text += "r5 5600X";
                        label9.Text += "6";
                        label10.Text += "3.7ГГц";
                        label11.Text += "32";
                        break;
                    }

                case "Ryzen 7":
                    {
                        label8.Text += "r7 5800X";
                        label9.Text += "8";
                        label10.Text += "3.8ГГц";
                        label11.Text += "32";
                        break;
                    }

                case "Байкал-Т":
                    {
                        label8.Text += "Байкал БТ-1000";
                        label9.Text += "4";
                        label10.Text += "1.5ГГц";
                        label11.Text += "4";
                        break;
                    }
            }
        }

        private void switchback_Click(object sender, EventArgs e)
        {
            SwitchBack?.Invoke(this,EventArgs.Empty);
        }
    }
}
