using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ScoalaDeManeologi
{
    class JocUtils
    {

        public static Joc JocCurent { get; set; }

        private static string Fisier_Cuvinte { get; set; }
        private static List<string> Cuvinte { get; set; }
        public static MediaPlayer SoundPlayer = new MediaPlayer();

        public static Jucator User { get; set; }

        public static bool Initializat { get; private set; }




        public static void Initializare()
        {

            Fisier_Cuvinte = "../../Resurse/Personalitati.txt";
            InitializareCuvinte();

            Initializat = true;
        }


        private static void CitesteCuvinte(List<string> listaCuvinte, string Fisier_Cuvinte)
        {
            string[] linii = System.IO.File.ReadAllLines(Fisier_Cuvinte);

            foreach (string line in linii)
                listaCuvinte.Add(line.ToUpper());
        }

        private static void InitializareCuvinte()
        {
            Cuvinte = new List<string>();

            CitesteCuvinte(Cuvinte, Fisier_Cuvinte);
        }

        private static string GenerareCuvant()
        {
            Random rand = new Random();
            return Cuvinte[rand.Next(0, Cuvinte.Count)];
        }


        public static void JocNou()
        {
            JocCurent = new Joc(GenerareCuvant());
        }


        public static Joc.StatusJoc GetStatusJoc()
        {
            return JocCurent.GetStatusJoc();
        }

        public static void SfarsitJoc()
        {
            if (JocCurent != null)
            {
                switch (JocCurent.GetStatusJoc())
                {
                    case Joc.StatusJoc.Castigat:
                        {
                            User.NrJocuriCastigate++;
                            User.NrJocuriJucate++;
                            break;
                        }
                    case Joc.StatusJoc.mergeInca:
                        {
                            User.NrJocuriJucate++;
                            break;
                        }

                    case Joc.StatusJoc.Pierdut:
                        {
                            User.NrJocuriJucate++;
                            break;
                        }
                }

                JocCurent = null;
            }
        }

        public static void StartSunet(Uri fisier)
        {
            SoundPlayer.Open(fisier);
            SoundPlayer.Play();
        }

        public static void OpresteSunet()
        {
            SoundPlayer.Stop();
        }
    }
}
