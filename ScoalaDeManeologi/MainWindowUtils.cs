using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ScoalaDeManeologi
{
    class MainWindowUtils
    {
        public static Dictionary<string, Jucator> Jucatori { get; set; }
        private static string FisierJucatori { get; set; }

        public static bool Initializat { get; private set; }

        public static MediaPlayer ManelePlayer = new MediaPlayer();



        public static void Initializare()
        {

            FisierJucatori = "../../Resurse/jucatori.txt";
            InitializareJucatori();

            Initializat = true;
        }

        private static void InitializareJucatori()
        {
            Jucatori = new Dictionary<string, Jucator>();
            CitireJucatori();
        }


        private static void CitireJucatori()
        {
            string[] lines = System.IO.File.ReadAllLines(FisierJucatori);

            if (lines.Length > 0)
            {
                uint i = 0;
                while (i < lines.Length)
                {
                    string nume = lines[i++];
                    short jocuriJucate = short.Parse(lines[i++]);
                    short jocuriCastigate = short.Parse(lines[i++]);
                    Jucatori[nume] = (new Jucator(nume, jocuriJucate, jocuriCastigate));
                }

            }
        }

        public static void SalveazaJucatorii()
        {
            if (Jucatori.Count > 0)
            {
                string infoJucator = "";
                foreach (KeyValuePair<string, Jucator> jucator in Jucatori)
                {
                    infoJucator += jucator.Value.ToString();
                }

                System.IO.File.WriteAllText(FisierJucatori, infoJucator);
            }
            else
            {
                System.IO.File.WriteAllText(FisierJucatori, "");
            }
        }

        public static void AdaugaJucator(string nume)
        {
            if (!Jucatori.ContainsKey(nume) && nume != "")
                Jucatori[nume] = new Jucator(nume);
        }

        public static void StergeJucator(string nume)
        {
            Jucatori.Remove(nume);
        }

        public static void executeStartManea()
        {
            ManelePlayer.Open(new Uri("../../Resurse/Sunete/manea.mp3", UriKind.Relative));
            ManelePlayer.Play();
        }

        public static void executeStopManea()
        {
            ManelePlayer.Stop();
        }

    }
}
