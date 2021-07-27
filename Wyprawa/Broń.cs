using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    abstract class Broń:Ruch
    {
        public bool podniesiona { get; private set; }
        public Broń(Gra gra, Point lokalizacja)
            :base(gra, lokalizacja) 
        { podniesiona = false; }
        public void podnieśBroń() { podniesiona = true; }
        public abstract string nazwa { get; }
        public abstract void atak(Key kierunek, Random rand);
        protected bool zrańPrzeciwnika(Key kierunek, int zasięg, int obrażenia, Random rand) 
        {
            Point cel = gra.lokalizacjaGracza;
            for(int dystans = 0; dystans < zasięg; dystans++)
            {
                foreach (Przeciwnik przeciwnik in gra.przeciwnicy) 
                {
                    if (otoczenie(przeciwnik.Lokalizacja, cel, dystans)) 
                    {
                        przeciwnik.otrzymajObrażenia(obrażenia, rand);
                        return true;
                    }
                }
                cel = ruszSię(kierunek, cel, gra.Bariera);
            }
            return false;
        }
    }
}
