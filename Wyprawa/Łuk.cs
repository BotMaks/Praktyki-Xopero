using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    class Łuk:Broń
    {
        private const int zasięg = 30;
        private const int maxObrażenia = 1;

        public Łuk(Gra gra, Point lokalizacja):base(gra, lokalizacja) { }

        public override string nazwa { get { return "Łuk"; } }
        public override void atak(Key kierunek, Random rand)
        {
            zrańPrzeciwnika(kierunek, zasięg, maxObrażenia, rand);
        }
    }
}
