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
        private int zmianyDoPrzepracowania=0;
        private int zmianyPrzepracowane=0;
        public string aktualnaPraca="";
        private const double pobórNaZmiane = 0.65;

        public Robotnica() { }
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
                    zmianyPrzepracowane = 0;
                    return true;
                }
            }

            return false;
        }
        public bool pracuj()
        {
            if (zmianyDoPrzepracowania > 0) 
            { 
                zmianyDoPrzepracowania--;
                zmianyPrzepracowane++;
                return true;
            }
            else
            {
                zmianyPrzepracowane = 0;
            }
            return false;
        }

        public int ileZmianZostało() {

            if (zmianyDoPrzepracowania == 0)
            {
                aktualnaPraca = "";
            }
            
            return zmianyDoPrzepracowania;
            
        }

        public override double konsumpcjaMiodu()
        {
            double pobórMiodu = base.konsumpcjaMiodu();
            pobórMiodu += pobórNaZmiane * zmianyPrzepracowane;

            return pobórMiodu;
        }
    }
}
