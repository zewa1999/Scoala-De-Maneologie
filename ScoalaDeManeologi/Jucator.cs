using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoalaDeManeologi
{
    class Jucator
    {
        public string Nume { get; set; }

        public short NrJocuriJucate { get; set; }
        public short NrJocuriCastigate { get; set; }

        public Jucator(string name)
        {
            Nume = name;
            NrJocuriJucate = 0;
            NrJocuriCastigate = 0;
        }

        public Jucator(string name, short gamesPlayed, short gamesWon)
        {
            Nume = name;
            NrJocuriJucate = gamesPlayed;
            NrJocuriCastigate = gamesWon;
        }

        public override string ToString()
        {
            return
                $"{Nume}\n" +
                $"{NrJocuriJucate}\n" +
                $"{NrJocuriCastigate}\n";
        }
    }
}
