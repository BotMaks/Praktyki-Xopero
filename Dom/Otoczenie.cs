using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class Otoczenie:Miejsce
    {
        private bool gorąco;
        public Otoczenie(string nazwa, bool gorąco):base(nazwa) {
            this.gorąco = gorąco;
        }
        public override string pobierzOpis
        {
            get
            {
                string nowyOpis = base.pobierzOpis;
                if (gorąco)
                {
                    nowyOpis += "\nTutaj jest gorąco fest.";
                }
                return nowyOpis;
            }
        }
    }
}
