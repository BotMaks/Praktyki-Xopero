using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idź_na_ryby
{
    class SortujWgWartości : IComparer<Karta>
    {
        public int Compare(Karta x, Karta y)
        {
            if (x.wartość > y.wartość) { return 1; }
            else if (x.wartość < y.wartość) { return -1; }
            if (x.kolor > y.kolor) { return 1; }
            else if (x.kolor < y.kolor) { return -1; }
            else { return 0; }
        }
    }
}
