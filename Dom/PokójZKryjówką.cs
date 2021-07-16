using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class PokójZKryjówką:Pokój, IKryjówka
    {
        public string nazwaKryjówki { get; private set; }
        public PokójZKryjówką(string nazwa, string ozdoby, string nazwaKryjówki):base(nazwa, ozdoby) {
            this.nazwaKryjówki = nazwaKryjówki;
        }
        public override string pobierzOpis
        {
            get
            {
                return string.Format("{0}\nKtoś może ukrywac się {1}.", base.pobierzOpis, nazwaKryjówki);
            }
        }
    }
}
