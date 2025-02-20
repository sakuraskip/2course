using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private UserControl1 userControl1;
        private cpuSettings control2;
        private displayComputers control3;
        public Form1()
        {
            InitializeComponent();
            Computer computer = new Computer();
            userControl1 = new UserControl1();
            control2 = new cpuSettings();
            control3 = new displayComputers();
            this.Controls.Add(userControl1);
            
            userControl1.Dock = DockStyle.Fill; // Растягиваем на всю форму
            userControl1.ChangeCPU += changeCPU;
            control2.SwitchBack += SwitchBack;
            //control3.SwitchBack += SwitchBack;
            userControl1.DisplayComputers += displayComputers_event;
           

        }

        private void displayComputers_event(object sender, EventArgs e)
        {
            userControl1.Hide();
            this.Controls.Add(control3);
            control3.Dock = DockStyle.Fill;
            control3.Show();

        }
        private void SwitchBack(object sender, EventArgs e)
        {
           
            control2.Hide();
            control3.Hide();
            this.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            userControl1.Show();
            userControl1.computer = control2.computer;
        }
        private void changeCPU(object sender, EventArgs e)
        {
            userControl1.Hide();
            this.Controls.Add(control2);
            control2.Dock = DockStyle.Fill;
            control2.Show();
            control2.computer = userControl1.computer;
        }

    }
}
