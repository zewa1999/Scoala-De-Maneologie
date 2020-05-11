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

namespace ScoalaDeManeologi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!MainWindowUtils.Initializat)
                MainWindowUtils.Initializare();

            list_users.ItemsSource = MainWindowUtils.Jucatori.Keys;
        }


        private void btn_Jucator_Nou(object sender, RoutedEventArgs e)
        {
            Window userWindow = new NewUserWindow();
            userWindow.Show();
            Close();
        }

        private void btn_Sterge_Jucator(object sender, RoutedEventArgs e)
        {
            if (list_users.SelectedItem != null)
            {
                MainWindowUtils.StergeJucator(list_users.SelectedItem.ToString());
                list_users.Items.Refresh();
            }
        }

        private void btn_IncepeJoc(object sender, RoutedEventArgs e)
        {
            if (list_users.SelectedItem != null)
            {
                JocUtils.User = MainWindowUtils.Jucatori[list_users.SelectedItem.ToString()];

                Window gameWindow = new GameWindow();
                gameWindow.Show();

                Close();
            }

            MainWindowUtils.executeStopManea();
        }

        private void btn_Opreste_Manea(object sender, RoutedEventArgs e)
        {

            MainWindowUtils.executeStopManea();
        }

        private void btn_Start_Manea(object sender, RoutedEventArgs e)
        {
            MainWindowUtils.executeStartManea();

        }

        private void btn_Afara_Din_Ghencea(object sender, RoutedEventArgs e)
        {
            MainWindowUtils.SalveazaJucatorii();
            Close();
        }





    }
}
