using lab4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для ShipDetails.xaml
    /// </summary>
    public partial class ShipDetails : Window
    {
        public ShipDetails(ShipModel detailship)
        {
            InitializeComponent();
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani");
            Cursor = customCursor;

            ShipDetailsModel model = new ShipDetailsModel(detailship);
            DataContext = model;
            if(model.CloseAction == null)
            {
                model.CloseAction = new Action(()=>this.Close());
            }
           
        }

       
    }
}
