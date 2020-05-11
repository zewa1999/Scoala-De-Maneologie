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
    public partial class GameWindow : Window
    {
        private List<TextBlock> Greseli { get; set; }
        private List<Button> ButoaneLitere { get; set; }
        Uri uri;
        public GameWindow()
        {
            InitializeComponent();

            if (!JocUtils.Initializat)
                JocUtils.Initializare();

            joc_grid.Visibility = Visibility.Collapsed;
            statistici_grid.Visibility = Visibility.Collapsed;

            list_statistics.ItemsSource = MainWindowUtils.Jucatori;

            Initializare_Greseli_Litere();
        }


        private void Initializare_Greseli_Litere()
        {

            ButoaneLitere = new List<Button>();
            ButoaneLitere.Add(btn_a);
            ButoaneLitere.Add(btn_b);
            ButoaneLitere.Add(btn_c);
            ButoaneLitere.Add(btn_d);
            ButoaneLitere.Add(btn_e);
            ButoaneLitere.Add(btn_f);
            ButoaneLitere.Add(btn_g);
            ButoaneLitere.Add(btn_h);
            ButoaneLitere.Add(btn_i);
            ButoaneLitere.Add(btn_j);
            ButoaneLitere.Add(btn_k);
            ButoaneLitere.Add(btn_l);
            ButoaneLitere.Add(btn_m);
            ButoaneLitere.Add(btn_n);
            ButoaneLitere.Add(btn_o);
            ButoaneLitere.Add(btn_p);
            ButoaneLitere.Add(btn_q);
            ButoaneLitere.Add(btn_r);
            ButoaneLitere.Add(btn_s);
            ButoaneLitere.Add(btn_t);
            ButoaneLitere.Add(btn_u);
            ButoaneLitere.Add(btn_v);
            ButoaneLitere.Add(btn_w);
            ButoaneLitere.Add(btn_x);
            ButoaneLitere.Add(btn_y);
            ButoaneLitere.Add(btn_z);



            Greseli = new List<TextBlock>();

            Greseli.Add(greseala1);
            Greseli.Add(greseala2);
            Greseli.Add(greseala3);
            Greseli.Add(greseala4);
            Greseli.Add(greseala5);
            Greseli.Add(greseala6);


        }

        private void InitializareEcranJoc()
        {
            Resetare_Litere();
            ResetGreseli();
            UpdateEcran();
        }


        private void Joc_nou_Click(object sender, RoutedEventArgs e)
        {
            Arata_joc();

            JocUtils.JocNou();

            InitializareEcranJoc();

        }


        private void Statistici_Click(object sender, RoutedEventArgs e)
        {
            Arata_statistici();
        }

        private void Afara_din_ghencea_Click(object sender, RoutedEventArgs e)
        {
            JocUtils.SfarsitJoc();

            Window window = new MainWindow();
            window.Show();

            Close();
            JocUtils.OpresteSunet();
            uri = new Uri("../../Resurse/Sunete/TepupPaPa.mp3", UriKind.Relative);

            JocUtils.StartSunet(uri);

        }


        private void Litera_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            JocUtils.JocCurent.IncearcaLitera(button.Content.ToString());

            UpdateEcran();

            Status_joc();

            button.IsEnabled = false;
        }

        private void UpdateEcran()
        {
            UpdateGreseli();
            txt_ghicire_cuvant.Text = JocUtils.JocCurent.UpdateText();
        }

        private void ResetGreseli()
        {
            foreach (TextBlock box in Greseli)
                box.Text = "";
        }

        private void UpdateGreseli()
        {
            int failedAttempts = JocUtils.JocCurent.IncercariGresite;

            if (failedAttempts > 0)
            {
                for (int i = 0; i < failedAttempts; ++i)
                    Greseli[i].Text = "X";
            }

        }

        private void Resetare_Litere()
        {
            foreach (Button button in ButoaneLitere)
            {
                button.IsEnabled = true;
            }
        }

        private void Disable_litere()
        {
            foreach (Button button in ButoaneLitere)
            {
                button.IsEnabled = false;
            }
        }

        private void Status_joc()
        {
            switch (JocUtils.GetStatusJoc())
            {
                case Joc.StatusJoc.Castigat:
                    {
                        uri = new Uri("../../Resurse/Sunete/BineMa.mp3", UriKind.Relative);
                        JocUtils.StartSunet(uri);

                        MessageBox.Show("BINE MAAA!!!", "BOMBA!", MessageBoxButton.OK);
                        Disable_litere();
                        JocUtils.SfarsitJoc();


                        break;
                    }

                case Joc.StatusJoc.Pierdut:
                    {
                        uri = new Uri("../../Resurse/Sunete/AiGrijaFraiere.mp3", UriKind.Relative);
                        JocUtils.StartSunet(uri);

                        MessageBox.Show($"Sa-ti fie rusine!!\nCuvantu' era: {JocUtils.JocCurent.Cuvant}.", "Ti-ai Luat-o!", MessageBoxButton.OK);
                        Disable_litere();
                        JocUtils.SfarsitJoc();
                        break;
                    }
            }
        }

        private void btn_opreste_manele_Click(object sender, RoutedEventArgs e)
        {
            JocUtils.OpresteSunet();
        }

        private void btn_start_manele_Click(object sender, RoutedEventArgs e)
        {
            Uri maneaUri = new Uri("../../Resurse/Sunete/Florin Salam Sistem.mp3", UriKind.Relative);
            JocUtils.StartSunet(maneaUri);
        }


        private void Arata_joc()
        {
            if (statistici_grid.IsVisible)
            {
                statistici_grid.Visibility = Visibility.Collapsed;
            }

            if (!joc_grid.IsVisible)
            {
                joc_grid.Visibility = Visibility.Visible;
            }
        }

        private void Arata_statistici()
        {
            if (joc_grid.IsVisible)
            {
                joc_grid.Visibility = Visibility.Collapsed;
            }

            if (!statistici_grid.IsVisible)
            {
                statistici_grid.Visibility = Visibility.Visible;
            }
        }


    }
}
