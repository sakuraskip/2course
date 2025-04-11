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
using System.ComponentModel.DataAnnotations;

namespace lab2
{
    public partial class UserControl1 : UserControl
    {
        private bool panelDocked = false;

        
        private static string _filepath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab2\\lab2\\computers.json";
        public Computer computer;
        public event EventHandler ChangeCPU;
        public event EventHandler DisplayComputers;
        public event EventHandler SearchPage;

        private int objCount = lab2.displayComputers.loadFromXML(_filepath).list.Count;
        private string lastAction = "";
        public UserControl1()
        {
            InitializeComponent();
            computer = new Computer();
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.Validating += maskedTextBox_validation;

        }

        public void updateStatus(string action)
        {
            toolStripStatusLabel1.Text = $"Время: {DateTime.Now}, последнее действие: {action}, кол-во объектов: {objCount}";
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
            
            computer.name = textBox1.Text;
            if (radioButton1.Checked)
            {
                computer.type = "Сервер";
            }
            else if (radioButton2.Checked)
            {
                computer.type = "Персональный";
            }
            else if(radioButton3.Checked)
            {
                computer.type = "Ноутбук";
            }
            if(radioButton4.Checked)
            {
                computer.videocard = "IntelArc580";
            }
            else if (radioButton5.Checked)
            {
                computer.videocard = "Radeon6700xt";
            }
            else if (radioButton6.Checked)
            {
                computer.videocard = "Gt630";
            }
            switch(comboBox1.SelectedIndex)
            {
                case 0: computer.ramtype = "DDR3";break;
                case 1: computer.ramtype = "DDR4";break;
                case 2: computer.ramtype = "DDR5";break;
                default:break;
            }
            switch(comboBox2.SelectedIndex)
            {
                case 0: computer.memorytype = "HDD";break;
                case 1: computer.memorytype = "SSD";break;
                case 2: computer.memorytype = "M2 SSD";break;
                default:break;
            }
            computer.RAM = Convert.ToInt32(numericUpDown2.Value);
            computer.Memory = Convert.ToInt32(numericUpDown1.Value);
            computer.buydate = maskedTextBox1.Text;
            computer.calcPrice();
            if (!checkFields())
            {
                return;
            }
            saveToXML(computer);
            errorLabel.Text = "Компьютер сохранен";
            updateStatus("Сохранил компьютер");
        }
        private void saveToXML(Computer computer)
        {
            ComputerList pclist = displayComputers.loadFromXML(_filepath);
            pclist.list.Add(computer);

            string json = JsonConvert.SerializeObject(pclist,Formatting.Indented);
            File.WriteAllText(_filepath,json);
            
        }
        private bool checkFields()
        {
            errorLabel.Text = "";
            var validationResults = GetValidationResults(computer);
            if(validationResults.Count>0)
            {
                errorLabel.Text = validationResults[0].ErrorMessage;
                return false;
            }

           
            progressBar1.Value = 20;
           
            progressBar1.Value = 40;
         
            progressBar1.Value = 60;
           
            if((computer.processor == null) ||string.IsNullOrEmpty(computer.processor.Модель))
            {
                errorLabel.Text = "не выбран процессор";
                return false;
            }
            progressBar1.Value = 100;

            return true;

        }
        private List<ValidationResult> GetValidationResults(Computer computer)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(computer);

            bool isvalid = Validator.TryValidateObject(computer, validationContext, validationResults, true);

            return validationResults;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateStatus("Выбирал процессор");

            ChangeCPU?.Invoke(this, EventArgs.Empty);
        }

        private void displayAll_Click(object sender, EventArgs e)
        {
            updateStatus("посмотрел все компьютеры");
            DisplayComputers?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateStatus("посмотрел информацию");
            modalform form = new modalform();
            form.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            updateStatus("отфильтровал список компьютеров");
            SearchPage?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SearchPage?.Invoke(this,EventArgs.Empty);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            errorLabel.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            maskedTextBox1.Text = "";
            label4.Text = "Процессор: ";
            updateStatus("очистил все поля")    ;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var parent = this.FindForm();
            if(parent != null)
            {
                parent.Location = new Point(parent.Location.X, parent.Location.Y - 30);
                

            }
            updateStatus("переместил окно");

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var parent = this.FindForm();
            if (parent != null)
            {
                parent.Location = new Point(parent.Location.X, parent.Location.Y + 30);

            }
            updateStatus("переместил окно");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = !toolStrip1.Visible;
            if(toolStrip1.Visible)
            {
                button4.Text = "Скрыть";
            }
            else
            {
                button4.Text = "Показать";
            }
            updateStatus("скрыл видимость панели инструментов");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(panelDocked)
            {
                toolStripContainer1.Dock = DockStyle.Top;
                panelDocked = false;
            }
            else
            {
                toolStripContainer1.Dock = DockStyle.Bottom;
                panelDocked = true;
            }
            updateStatus("переместил панель инструментов");

        }
    }
}
