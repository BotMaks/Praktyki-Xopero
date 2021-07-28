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
        public Upiór(Gra gra, Point lokalizacja) : base(gra, lokalizacja, 10) { }

        public override int ruszSię(Random rand)
        {
            if (zdrowie > 0)
            {
                if (rand.Next(1,3)>3)
                {
                    Key kierunek = znajdźKierunekGracza(gra.lokalizacjaGracza);
                    ruszSię(kierunek, this.lokalizacja, gra.Bariera);
                }
                if (obokGracza())
                {
                    return rand.Next(1, 4);
                }
                else { return 0; }
            }
            else 
            { 
                return 0; 
            }
        }
    }
}
