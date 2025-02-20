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
        public displayComputers()
        {
            InitializeComponent();
        }

        private void displayComputers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = loadFromXML();
        }
        private List<Computer> loadFromXML()
        {
            List<Computer> computers = new List<Computer>();
            XmlSerializer serializer = new XmlSerializer(typeof(Computer));

            using (StreamReader rd = new StreamReader("computers.xml"))
            {
                computers.Add((Computer)serializer.Deserialize(rd));
            }//СОЗДАТЬ LIST КАК ПОЛЕ В КЛАССЕ, КОМПЬЮТЕРЫ ДОБАВЛЯТЬ УЖЕ В НЕГО, СЕРИАЛИЗОВАТЬ И ДЕСЕРИАЛИЗОВАТЬ НУЖНО ЕГО
            return computers;
        }
    }
}
