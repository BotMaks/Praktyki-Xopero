using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class PokójZDrzwiami:Pokój, IMaZewenętrzneDrzwi
    {
        public string opisDrzwi { get; private set; }
        public Miejsce miejsceDrzwi { get; set; }
        public PokójZDrzwiami(string nazwa, string ozdoby, string opisDrzwi):base(nazwa, ozdoby) {
            this.opisDrzwi = opisDrzwi;
        }
    }
}
