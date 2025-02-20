using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab2
{
    public partial class UserControl1 : UserControl
    {
        public Computer computer;
        public event EventHandler ChangeCPU;
        public event EventHandler DisplayComputers;
        public UserControl1()
        {
            InitializeComponent();
            computer = new Computer();
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.Validating += maskedTextBox_validation;
        }

        private void maskedTextBox_validation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!DateTime.TryParse(maskedTextBox1.Text,out _))
            {
                errorLabel.Text = "Неверная дата покупки";
            }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void idtextbox_keypress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void savecomputer_Click(object sender, EventArgs e)
        {
            if(!checkFields())
            {
                return;
            }
            if (radioButton1.Checked)
            {
                computer.type = Computer.computerType.Сервер;
            }
            else if (radioButton2.Checked)
            {
                computer.type = Computer.computerType.Персональный;
            }
            else if(radioButton3.Checked)
            {
                computer.type = Computer.computerType.Ноутбук;
            }
            if(radioButton4.Checked)
            {
                computer.videocard = Computer.Videocard.IntelArc580;
            }
            else if (radioButton5.Checked)
            {
                computer.videocard = Computer.Videocard.Radeon6700xt;
            }
            else if (radioButton6.Checked)
            {
                computer.videocard = Computer.Videocard.Gt630;
            }
            computer.buydate = maskedTextBox1.Text;
          saveToXML(computer);
            errorLabel.Text = "Компьютер сохранен";
        }
        private void saveToXML(Computer computer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Computer));
            using(StreamWriter wr = new StreamWriter("computers.xml"))
            {
                serializer.Serialize(wr, computer);
            }
        }
        private bool checkFields()
        {
            errorLabel.Text = "";
            RadioButton[] buttons = { radioButton1, radioButton2, radioButton3, radioButton4, radioButton5, radioButton6 };
            short radiocounter = 0;
            foreach (RadioButton button in buttons)
            {
                if (button.Checked)
                {
                    radiocounter++;
                }
            }
            if (radiocounter != 2)
            {
                errorLabel.Text = "Не выбран тип компьютера либо видеокарта";
                return false;
            }
            progressBar1.Value = 20;
            if(comboBox1.SelectedIndex == -1)
            {
                errorLabel.Text = "не выбран тип озу";
                return false;
            }
            progressBar1.Value = 40;
            if(comboBox2.SelectedIndex == -1)
            {
                errorLabel.Text = "не выбран тип диска";
                return false;
            }
            progressBar1.Value = 60;
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || !maskedTextBox1.MaskFull)
            {
                maskedTextBox1.BackColor = Color.Coral;
                errorLabel.Text = "Пустая или неверная дата приобретения";
                return false;
            }
            if((computer.processor == null) ||string.IsNullOrEmpty(computer.processor.Модель))
            {
                errorLabel.Text = "не выбран процессор";
                return false;
            }
            progressBar1.Value = 100;

            return true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeCPU?.Invoke(this, EventArgs.Empty);
        }

        private void displayAll_Click(object sender, EventArgs e)
        {
            DisplayComputers?.Invoke(this, EventArgs.Empty);
        }

        
    }
}
