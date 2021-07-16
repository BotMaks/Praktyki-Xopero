using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    abstract class Miejsce
    {
        public Miejsce[] wyjścia;
        public string nazwa { get; private set; }
        
        public Miejsce(string nazwa) {
            this.nazwa = nazwa;
        }
        public virtual string pobierzOpis {
            get{
                string opis = string.Format("Stoisz w: {0}. \nWidzisz wyjścia do następujących lokalizacji: ", nazwa);
                foreach(Miejsce wyjście in wyjścia) {
                    opis += string.Format(" {0}", wyjście.nazwa);
                }
                opis += ".";
                return opis;
            }
        }
    }
}
