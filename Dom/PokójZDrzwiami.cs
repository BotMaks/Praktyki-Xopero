using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class PokójZDrzwiami:PokójZKryjówką, IMaZewenętrzneDrzwi
    {
        public string opisDrzwi { get; private set; }
        public Miejsce miejsceDrzwi { get; set; }
        public PokójZDrzwiami(string nazwa, string ozdoby, string nazwaKryjówki, string opisDrzwi):base(nazwa, ozdoby, nazwaKryjówki) {
            this.opisDrzwi = opisDrzwi;
        }
    }
}
