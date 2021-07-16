using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class OtoczenieZDrzwiami:Otoczenie, IMaZewenętrzneDrzwi
    {
        public string opisDrzwi { get; private set; }
        public Miejsce miejsceDrzwi { get; set; }
        public OtoczenieZDrzwiami(string nazwa, bool gorąco, string opisDrzwi):base(nazwa, gorąco) {
            this.opisDrzwi = opisDrzwi;
        }
        public override string pobierzOpis
        {
            get
            {
                return string.Format("{0} \nWidzisz teraz {1}.",base.pobierzOpis , opisDrzwi);
            }
        }
    }
}
