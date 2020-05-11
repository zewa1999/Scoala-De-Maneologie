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
using System.Windows.Shapes;

namespace ScoalaDeManeologi
{
    public partial class NewUserWindow : Window
    {
        public NewUserWindow()
        {
            InitializeComponent();
        }

        private void btn_Adauga_Manelar(object sender, RoutedEventArgs e)
        {
            MainWindowUtils.AdaugaJucator(txtBox_name.Text);
            inchideFereastra();
        }

        private void btn_FaraManelar(object sender, RoutedEventArgs e)
        {
            inchideFereastra();
        }

        private void inchideFereastra()
        {
            Window fereastra = new MainWindow();
            fereastra.Show();
            Close();
        }
    }
}
