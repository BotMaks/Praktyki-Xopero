using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talie_kart
{
    class SortujWgKoloru: IComparer<Karta>
    {
        public int Compare(Karta x, Karta y)
        {
            if (x.kolor > y.kolor) { return 1; }
            else if (x.kolor < y.kolor) { return -1; }
            if (x.wartość > y.wartość) { return 1; }
            else if (x.wartość < y.wartość) { return -1; }
            else { return 0; }
        }
    }
}
