using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoalaDeManeologi
{
    class Joc
    {
        public enum StatusJoc
        {
            Castigat,
            mergeInca,
            Pierdut
        }

        private const uint maximGreseli = 6;

        public string Cuvant { get; set; }

        public string Incercari { get; set; }

        public int IncercariGresite { get; private set; }


        public Joc(string word)
        {
            Cuvant = word;
            Incercari = "";
            IncercariGresite = 0;
        }

        public Joc(string word, string attempts)
        {
            Cuvant = word;
            Incercari = attempts;
            IncercariGresite = 0;

            foreach (char c in Incercari)
                if (!Cuvant.Contains(c))
                    IncercariGresite++;
        }


        public StatusJoc GetStatusJoc()
        {
            if (ACastigat())
                return StatusJoc.Castigat;

            if (IncercariGresite == maximGreseli)
                return StatusJoc.Pierdut;

            return StatusJoc.mergeInca;
        }

        private bool ACastigat()
        {
            foreach (char c in Cuvant)
            {
                if (Char.IsLetter(c) && !Incercari.Contains(c))
                    return false;
            }

            return true;
        }

        public void IncearcaLitera(string c)
        {
            Incercari = Incercari + c;

            if (!Cuvant.Contains(c))
                IncercariGresite++;
        }

        public string UpdateText()
        {
            string text = "";

            foreach (char litera in Cuvant)
            {
                if (Char.IsLetter(litera))
                {
                    if (Incercari.Contains(litera))
                    {
                        text += litera + " ";
                    }
                    else
                    {
                        text += "_ ";
                    }
                }
                else
                {
                    text += litera + " ";
                }
            }

            return text;
        }
    }
}
