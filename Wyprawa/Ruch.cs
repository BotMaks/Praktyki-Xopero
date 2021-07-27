using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace Wyprawa
{
    abstract class Ruch
    {
        private const int prędkośćPoruszania = 10;
        public int PrędkośćPoruszania { get { return prędkośćPoruszania; } }
        protected Point lokalizacja;
        public Point Lokalizacja { get { return lokalizacja; } }
        protected Gra gra;

        public Ruch(Gra gra, Point lokalizacja) 
        {
            this.gra = gra;
            this.lokalizacja = lokalizacja;
        }
        public bool otoczenie(Point lokalizacjaDoSprawdzenia, int dystans) 
        {
            if (Math.Abs(lokalizacja.X - lokalizacjaDoSprawdzenia.X) < dystans && (lokalizacja.Y - lokalizacjaDoSprawdzenia.Y) < dystans ) 
            {
                return true;
            }
            else { return false; }
        }
        public bool otoczenie (Point lokalizacjaSprawdzającego, Point lokalizacjaDoSprawdzenia, int dystans) 
        {
            lokalizacja = lokalizacjaSprawdzającego;
            return otoczenie(lokalizacjaSprawdzającego, dystans); 
        }
        public Point ruszSię(Key klawisz, Rectangle bariera) //
        {
            Point nowaLokalizacja = lokalizacja;

            switch (klawisz)
            {
                case Key.Up:
                    if (nowaLokalizacja.Y - prędkośćPoruszania >= bariera.Top) { nowaLokalizacja.Y -= prędkośćPoruszania; }
                    break;
                case Key.Down:
                    if (nowaLokalizacja.Y + prędkośćPoruszania <= bariera.Bottom) { nowaLokalizacja.Y += prędkośćPoruszania; }
                    break;
                case Key.Left:
                    if (nowaLokalizacja.X - prędkośćPoruszania >= bariera.Left) { nowaLokalizacja.X -= prędkośćPoruszania; }
                    break;
                case Key.Right:
                    if (nowaLokalizacja.X + prędkośćPoruszania >= bariera.Right) { nowaLokalizacja.X += prędkośćPoruszania; }
                    break;
                default: break;
            }
            return nowaLokalizacja;
        }

        public Point ruszSię(Key kierunek, Point punktStartowy, Rectangle bariera) 
        {
            lokalizacja = punktStartowy;
            return ruszSię(kierunek, bariera);
        }
    }
}
