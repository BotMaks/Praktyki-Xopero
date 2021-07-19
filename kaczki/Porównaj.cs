using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaczki
{
    class Porównaj:IComparer<Kaczka>
    {
        public enum kryterium
        {
            rozmiarPotemGatunek,
            gatunekPotemRozmiar
        }

        public kryterium kryteria;

        public int Compare(Kaczka x, Kaczka y)
        {
            if(kryteria == kryterium.rozmiarPotemGatunek) {
                if (x.rozmiar < y.rozmiar) { return -1; }
                else if (x.rozmiar > y.rozmiar) { return 1; }
                if(x.gatunek < y.gatunek) { return -1; }
                else if(x.gatunek > y.gatunek) { return 1; }
                else { return 0; }
            }
            else
            {
                if (x.gatunek < y.gatunek) { return -1; }
                else if(x.gatunek > y.gatunek){ return 1; }
                if(x.rozmiar < y.rozmiar) { return -1; }
                else if(x.rozmiar > y.rozmiar) { return 1; }
                else { return 0; }
            }
            
        }
    }
}
