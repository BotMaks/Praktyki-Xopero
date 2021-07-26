using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;


namespace Wyprawa
{
    class Gra
    {
        public IEnumerable<Przeciwnik> przeciwnicy { get; private set; }
        public Broń bronieWPokoju { get; private set; }
        private Gracz gracz;
        public Point lokalizacjaGracza { get { return gracz.Lokalizacja; } }
        public int życieGracza { get { return gracz.zdrowie; } }
        public IEnumerable<string> bronieGracza { get { return gracz.bronie; } }
        private int poziom = 0;
        public int Poziom { get { return poziom; } }

        private Rectangle bariera;
        public Rectangle Bariera { get { return bariera; } }

        public Gra(Rectangle bariera) 
        {
            this.bariera = bariera;
            gracz = new Gracz(this, new Point(bariera.Left + 10, bariera.Top + 70));
        }
        public void ruch(KeyEventArgs klawisz, Random rand) 
        {
            gracz.ruszSię(klawisz);
        }


    }
}
