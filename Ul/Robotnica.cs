using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ul
{
    class Robotnica:Pszczoła
    {
        private string[] prace;
        private int zmianyDoPrzepracowania;
        private int zmianyPrzepracowane;
        private string aktualnaPraca="";
        
        public Robotnica(double waga, string[] prace):base(waga) {
            this.prace = prace;
        }
        public bool pobierzPracę(string pracaDoZrobienia, int ileZmian) {
            
            foreach(string praca in prace)
            {
                if (praca == pracaDoZrobienia)
                {
                    aktualnaPraca = pracaDoZrobienia;
                    zmianyDoPrzepracowania = ileZmian;
                    return true;
                }
            }

            return false;
        }
        public void pracuj()
        {
            if (zmianyDoPrzepracowania > zmianyPrzepracowane) { zmianyPrzepracowane++; }
        }

        public bool czySkończyłes() {

            if (zmianyDoPrzepracowania == zmianyPrzepracowane)
            {
                aktualnaPraca = "";
                zmianyDoPrzepracowania = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
