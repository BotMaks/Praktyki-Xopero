using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    class Nietoperz:Przeciwnik
    {
        public Nietoperz(Gra gra, Point lokalizacja):base(gra, lokalizacja, 6) { }
        public override void ruszSię(Random rand)
        {
            if (zdrowie > 0) {
                if (rand.Next(1, 2) == 1)
                {
                    //porusza się w stronę gracza
                    Key kierunek = znajdźKierunekGracza(gra.lokalizacjaGracza);
                    ruszSię(kierunek, this.lokalizacja, gra.Bariera);
                }
                else
                {
                    //wykonuje losowy ruch
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            ruszSię(Key.Up, this.lokalizacja, gra.Bariera);
                            break;
                        case 2:
                            ruszSię(Key.Left, this.lokalizacja, gra.Bariera);
                            break;
                        case 3:
                            ruszSię(Key.Right, this.lokalizacja, gra.Bariera);
                            break;
                        case 4:
                            ruszSię(Key.Down, this.lokalizacja, gra.Bariera);
                            break;
                        default: 
                            break;
                    }
                }
            }
        }
    }
}
