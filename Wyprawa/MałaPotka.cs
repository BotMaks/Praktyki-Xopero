using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    class MałaPotka:Broń, IPotki
    {
        public bool użyta { get; set; }


        public MałaPotka(Gra gra, Point lokalizacja):base(gra, lokalizacja) { użyta = false; }

        public override string nazwa { get { return "Potka many"; } }
        public override void atak(Key kierunek, Random rand)
        {
            gra.podnieśZdrowieGracza(5, rand);
            użyta = true;
        }
    }
}
