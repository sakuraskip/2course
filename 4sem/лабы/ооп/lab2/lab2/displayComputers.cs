using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab2
{
    public partial class displayComputers : UserControl
    {
        public event EventHandler SwitchBack;
        public string _filepath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab2\\lab2\\computers.json";
        public displayComputers()
        {
            InitializeComponent();
        }

        private void displayComputers_Load(object sender, EventArgs e)
        {
            ComputerList list = loadFromXML(_filepath);
            dataGridView1.DataSource = list.list;
        }
        public static ComputerList loadFromXML(string _filepath)
        {
            if(File.Exists(_filepath))
            {
                string json = File.ReadAllText(_filepath);
                if(string.IsNullOrEmpty(json)) 
                {
                    return new ComputerList();
                }
                return JsonConvert.DeserializeObject<ComputerList>(json);
            }
            return new ComputerList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
