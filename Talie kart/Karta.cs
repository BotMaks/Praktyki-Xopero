using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talie_kart
{
    class Karta
    {
        public enum Kolor {
            pik,
            kier,
            trefl,
            karo
        }
        public enum Wartość {
            As = 1,
            dwa = 2,
            trzy = 3,
            cztery = 4,
            pięć = 5,
            sześć = 6,
            siedem = 7,
            osiem = 8,
            dziewięć = 9,
            dziesięć = 10,
            walet = 11,
            królowa = 12,
            król = 13
        }

        public Kolor kolor { get; set; }
        public Wartość wartość { get; set; }

        public Karta(Kolor kolor, Wartość wartość) {
            this.kolor = kolor;
            this.wartość = wartość;
        }
        public string nazwa { 
            get 
            {
                return wartość.ToString() + " " + kolor.ToString();
            } 
        }
        public override string ToString()
        {
            return nazwa;
        }
        public static bool czyKartaSięZgadza(Karta kartaDoSprawdzenia, Kolor kolor) {
            if (kartaDoSprawdzenia.kolor == kolor) { return true; }
            else { return false; }
        }
        public static bool czyKartaSięZgadza(Karta kartaDoSprawdzenia, Wartość wartość)
        {
            if (kartaDoSprawdzenia.wartość == wartość) { return true; }
            else { return false; }
        }
    }
}
