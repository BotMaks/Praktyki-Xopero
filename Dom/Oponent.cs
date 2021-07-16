using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    class Oponent
    {
        private Random random;
        private Miejsce mojeMiejsce;
        public Oponent(Miejsce początkoweMiejsce) {
            mojeMiejsce = początkoweMiejsce;
            random = new Random();
        }
        public void poruszSię()
        {
            bool ukryty = false;
            while (!ukryty)
            {
                if (mojeMiejsce is IMaZewenętrzneDrzwi) {
                    IMaZewenętrzneDrzwi miejsceZDrzwiami = mojeMiejsce as IMaZewenętrzneDrzwi;
                    if (random.Next(2) == 1) {
                        mojeMiejsce = miejsceZDrzwiami.miejsceDrzwi;
                    }
                }
                int rand = random.Next(mojeMiejsce.wyjścia.Length);
                mojeMiejsce = mojeMiejsce.wyjścia[rand];
                if(mojeMiejsce is IKryjówka)
                {
                    ukryty = true;
                }
            }
        }
        public bool sprawdź(Miejsce miejsceDoSprawdzenia)
        {
            if(miejsceDoSprawdzenia != mojeMiejsce) { return false; }
            else { return true; }
        }
    }
}
