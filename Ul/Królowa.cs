using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ul
{
    class Królowa:Pszczoła
    {
        private int nrZmiany = 1;
        private Robotnica[] robotnice;
        private string raport;

        public Królowa() { }
        public Królowa(double waga, Robotnica[] robotnice) :base(waga) {
            this.robotnice = robotnice;
        }

        public bool przypiszPracę(string praca, int ilośćZmian)
        {
            foreach (Robotnica robotnica in robotnice) {
                if (robotnica.ileZmianZostało()==0) {
                    if(robotnica.pobierzPracę(praca, ilośćZmian))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string pracuj() {
            raport = string.Format("Zmiana numer {0}:\n", nrZmiany);
            int i = 1;
            foreach (Robotnica robotnica in robotnice) {
                robotnica.pracuj();
                if (robotnica.ileZmianZostało()==0) 
                {
                    raport += string.Format("Robotnica numer {0} nic nie robi.\n", i);
                }else if (robotnica.ileZmianZostało() == 1)
                {
                    raport += string.Format("Robotnica numer {0} skończy {1} po tej zmianie.\n", i, robotnica.aktualnaPraca);
                }
                else
                {
                    raport += string.Format("Robotnica numer {0} robi {1} przez {2} zmian.\n", i, robotnica.aktualnaPraca, robotnica.ileZmianZostało());
                }
                i++;
            }
            nrZmiany++;
            return raport;
        }

    }
}