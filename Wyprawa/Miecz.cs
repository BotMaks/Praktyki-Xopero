using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Forms;

namespace Wyprawa
{
    class Miecz : Broń
    {
        private const int zasięg = 10;
        private const int maxObrażenia = 3;
        public Miecz(Gra gra, Point lokalizacja) : base(gra, lokalizacja) { }
        public override string nazwa { get { return "Miecz"; } }
        public override void atak(Key kierunek, Random rand)
        {
            Key kierunek2 = Key.None;
            Key kierunek3 = Key.None;
            switch (kierunek)
            {
                case Key.Up:
                    kierunek2 = Key.Right;
                    kierunek3 = Key.Left;
                    break;
                case Key.Right:
                    kierunek2 = Key.Down;
                    kierunek3 = Key.Up;
                    break;
                case Key.Down:
                    kierunek2 = Key.Left;
                    kierunek3 = Key.Right;
                    break;
                case Key.Left:
                    kierunek2 = Key.Up;
                    kierunek3 = Key.Down;
                    break;
                default:
                    MessageBox.Show("Zły klawisz", "Błąd");
                    break;
            }

            if(!zrańPrzeciwnika(kierunek, zasięg, maxObrażenia, rand))
            {
                if(!zrańPrzeciwnika(kierunek2, zasięg, maxObrażenia, rand))
                {
                    zrańPrzeciwnika(kierunek3, zasięg, maxObrażenia, rand);
                }
            }
             
                
            
        }
    }
}
