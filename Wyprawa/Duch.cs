using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    class Duch:Przeciwnik
    {
        public Duch(Gra gra, Point lokalizacja, int zdrowie) : base(gra, lokalizacja, 8) { }

        public override void ruszSię(Random rand)
        {
            if (zdrowie>0) {
                if (rand.Next(1, 3) == 1)
                {
                    Key kierunek = znajdźKierunekGracza(gra.lokalizacjaGracza);
                    ruszSię(kierunek, this.lokalizacja, gra.Bariera);
                } 
            }
        }
    }
}
