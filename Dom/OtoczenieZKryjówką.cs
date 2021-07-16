using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class OtoczenieZKryjówką:Otoczenie, IKryjówka
    {
        public string nazwaKryjówki { get; private set; }
        public OtoczenieZKryjówką(string nazwa, bool gorąco, string nazwaKryjówki) : base(nazwa, gorąco) {
            this.nazwaKryjówki = nazwaKryjówki;
        }
        public override string pobierzOpis
        {
            get
            {
                return string.Format("{0} \nKtoś może się ukrywać w {1}.",base.pobierzOpis, nazwaKryjówki);
            }
        }
    }
}
