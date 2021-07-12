using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObstawianieWyscigow
{
    class Zaklad
    {
        public int ilosc = 0;
        public int nrZawodnika;
        public Klient klientZakladu;

        public string opisZakladu(){
            if (ilosc == 0) { return string.Format("{0} nie zawarł zakładu", klientZakladu.imie); } 
            else {
                return string.Format("{0} postawił {1} zł na zawodnika numer {2}", klientZakladu.imie, ilosc, nrZawodnika);
            }
        }
        public int wyplata(int zwyciezca) {
            if (zwyciezca == nrZawodnika) {
                return ilosc;
            }
            else
            {
                return ilosc * (-1);
            }
        }
        public Zaklad() { }

        public Zaklad(int ilosc,int nrZawodnika,Klient klientZakladu) {
            this.ilosc = ilosc;
            this.nrZawodnika = nrZawodnika;
            this.klientZakladu = klientZakladu;
        }
    }
}
