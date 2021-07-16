using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class Pokój: Miejsce
    {
        private string ozdoby;
        public Pokój(string nazwa, string ozdoby):base(nazwa) {
            this.ozdoby = ozdoby;
        }

        public override string pobierzOpis {
            get
            {
                return string.Format("{0} \nWidzisz tutaj {1} .", base.pobierzOpis, ozdoby);
            }
        }
    }
}
