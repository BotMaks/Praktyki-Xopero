using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    class DużaPotka:Broń, IPotki
    {
        public bool użyta { get; set; }

        public DużaPotka(Gra gra, Point lokalizacja):base(gra, lokalizacja) { użyta = false; }

        public override string nazwa { get { return "Duża potka"; } }

        public override void atak(Key kierunek, Random rand)
        {
            gra.podnieśZdrowieGracza(10, rand);
            użyta = true;
        }
    }
}
