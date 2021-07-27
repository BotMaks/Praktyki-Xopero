using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;

namespace Wyprawa
{
    class Topór:Broń
    {
        private const int zasięg = 20;
        private const int maxObrażenia = 6;

        public Topór(Gra gra, Point lokalizacja):base(gra, lokalizacja) { }

        public override string nazwa { get { return "Topór"; } }
        public override void atak(Key kierunek, Random rand)
        {
            if (!zrańPrzeciwnika(Key.Up, zasięg, maxObrażenia, rand)) 
            {
                if(!zrańPrzeciwnika(Key.Right, zasięg, maxObrażenia, rand))
                {
                    if(!zrańPrzeciwnika(Key.Down, zasięg, maxObrażenia, rand))
                    {
                        zrańPrzeciwnika(Key.Left, zasięg, maxObrażenia, rand);
                    }
                }
            }
        }
    }
}
