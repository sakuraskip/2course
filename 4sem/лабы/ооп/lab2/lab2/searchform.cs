using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace lab2
{
    
    public partial class searchform : UserControl
    {
        public event EventHandler DisplayComputers;

        public static string searchfilepath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab2\\lab2\\search.json";
        public static string _filepath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab2\\lab2\\computers.json";

        private string _computerName = "";
        private List<string> _videocards = new List<string>();
        private List<string> _computerTypes = new List<string>();

        public ComputerList pclist = loadFromXML(_filepath);

        public ComputerList SearchList = loadFromXML(searchfilepath);
        
        public searchform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region fields
            _videocards.Clear();
            _computerTypes.Clear();
            _computerName = textBox1.Text;
            if(checkBox1.Checked)
            {
                _videocards.Add(checkBox1.Text);
            }
            if(checkBox2.Checked)
            {
                _videocards.Add(checkBox2.Text);
            }
            if(checkBox3.Checked)
            {
                _videocards.Add(checkBox3.Text);
            }
            if(checkBox4.Checked)
            {
                _computerTypes.Add(checkBox4.Text);
            }
            if(checkBox5.Checked)
            {
                _computerTypes.Add(checkBox5.Text);
            }
            if(checkBox6.Checked)
            {
                _computerTypes.Add(checkBox6.Text);
            }
            #endregion
            List<Computer> result = getSearchResults();
            dataGridView1.DataSource = result;
            SearchList.list = result;

        }

        private List<Computer> getSearchResults()
        {
            List<Computer> result = new List<Computer>();
            HashSet<Computer> unique = new HashSet<Computer>();

            Regex regex = null;
            try
            {
                regex = new Regex(_computerName);
                
            }
            catch(Exception ex)
            {
            }
            foreach (var comp in pclist.list)
            {
                if (regex != null && regex.IsMatch(comp.name) && !string.IsNullOrEmpty(_computerName))
                {
                    unique.Add(comp);
                }
                else if (regex == null && comp.name.Contains(_computerName))
                {
                    unique.Add(comp);
                }

                if (_videocards.Count > 0 && _videocards.Contains(comp.videocard))
                {
                    unique.Add(comp);
                }

                if (_computerTypes.Count > 0 && _computerTypes.Contains(comp.type))
                {
                    unique.Add(comp);
                }
            }

            result.AddRange(unique); 
            return result;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            DisplayComputers?.Invoke(this, EventArgs.Empty);
        }

        private void searchform_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = pclist.list;

        }
        public static ComputerList loadFromXML(string _filepath)
        {
            if (File.Exists(_filepath))
            {
                string json = File.ReadAllText(_filepath);
                if (string.IsNullOrEmpty(json))
                {
                    return new ComputerList();
                }
                return JsonConvert.DeserializeObject<ComputerList>(json);
            }
            return new ComputerList();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Сохраняем...";
            string json = JsonConvert.SerializeObject(SearchList, Formatting.Indented);
            File.WriteAllText(searchfilepath, json);
            await Task.Delay(1500);
            button3.Text = "Сохранить результат поиска";
        }
        public void updateStatus(string action)
        {
            //toolStripStatusLabel1.Text = $"Время: {DateTime.Now}, последнее действие: {action}, кол-во объектов: {objCount}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            updateStatus("отфильтровал список компьютеров");
            //SearchPage?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //SearchPage?.Invoke(this, EventArgs.Empty);
        }

        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{
        //    textBox1.Text = "";
        //    errorLabel.Text = "";
        //    radioButton1.Checked = false;
        //    radioButton2.Checked = false;
        //    radioButton3.Checked = false;
        //    radioButton4.Checked = false;
        //    radioButton5.Checked = false;
        //    radioButton6.Checked = false;
        //    comboBox1.SelectedIndex = -1;
        //    comboBox2.SelectedIndex = -1;
        //    maskedTextBox1.Text = "";
        //    label4.Text = "Процессор: ";
        //    updateStatus("очистил все поля");
        //}

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var parent = this.FindForm();
            if (parent != null)
            {
                parent.Location = new Point(parent.Location.X, parent.Location.Y - 10);

            }
            updateStatus("переместил окно");

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var parent = this.FindForm();
            if (parent != null)
            {
                parent.Location = new Point(parent.Location.X, parent.Location.Y + 10);

            }
            updateStatus("переместил окно");

        }
    }
}
