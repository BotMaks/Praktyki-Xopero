using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    abstract class Przeciwnik:Ruch
    {
        private const int dystansOdGracza = 25;

        public int zdrowie { get; private set; }
        public bool śmierć { 
            get
            {
                if (zdrowie <= 0) { return true; }
                else { return false; }
            } 
        }
        public Przeciwnik(Gra gra, Point lokalizacja, int zdrowie)
            :base(gra, lokalizacja) 
        {
            this.zdrowie = zdrowie;
        }
        public abstract void ruszSię(Random rand);
        public void otrzymajObrażenia(int maxObrażenia, Random rand) 
        {
            zdrowie -= rand.Next(1, maxObrażenia);
        }
        protected bool obokGracza() 
        {
            return otoczenie(gra.lokalizacjaGracza, dystansOdGracza);
        }
        protected Key znajdźKierunekGracza(Point lokalizacjaGracza)
        {
            Key kierunek;
            if (lokalizacjaGracza.X > lokalizacja.X + 10) { kierunek = Key.Right; }
            else if(lokalizacjaGracza.X < lokalizacja.X - 10) { kierunek = Key.Left; }
            else if(lokalizacjaGracza.Y < lokalizacja.Y - 10) { kierunek = Key.Up; }
            else { kierunek = Key.Down; }

            return kierunek;
        }
    }
}
