using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;


namespace Wyprawa
{
    class Upiór: Przeciwnik
    {
        public Upiór(Gra gra, Point lokalizacja, int zdrowie) : base(gra, lokalizacja, 10) { }

        public override void ruszSię(Random rand)
        {
            if (zdrowie > 0)
            {
                if (rand.Next(1,3)>3)
                {
                    Key kierunek = znajdźKierunekGracza(gra.lokalizacjaGracza);
                    ruszSię(kierunek, this.lokalizacja, gra.Bariera);
                }
            }
        }
    }
}
