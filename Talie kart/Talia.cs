using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talie_kart
{
    class Talia
    {
        private List<Karta> karty;
        private Random random = new Random();

        public Talia() 
        {
            karty = new List<Karta>();
            for (int kolor = 0; kolor < 4; kolor++) 
            {
                for(int wartość = 1; wartość < 14; wartość++)
                {
                    karty.Add(new Karta((Karta.Kolor)kolor, (Karta.Wartość)wartość));
                }
            }
        }
        public Talia(IEnumerable<Karta> początkoweKarty) 
        { 
            karty = new List<Karta>(początkoweKarty);
        }
        public int licznik 
        { 
            get 
            { return karty.Count; } 
        }

        public void dodaj(Karta kartaDoDodania)
        {
            karty.Add(kartaDoDodania);
        }
        public Karta wymiana(int index) 
        {
            Karta kartaDoWymiany = karty[index];
            karty.RemoveAt(index);
            return kartaDoWymiany;
        }
        public void mieszaj() 
        {
            List<Karta> noweKarty = new List<Karta>();
            while (karty.Count > 0) 
            {
                int kartaDoPrzeniesienia = random.Next(karty.Count);
                noweKarty.Add(karty[kartaDoPrzeniesienia]);
                karty.RemoveAt(kartaDoPrzeniesienia);
            }
            karty = noweKarty;
        }

        public IEnumerable<string> podajNazwyKart()
        {
            string[] nazwyKart = new string[karty.Count];
            for (int i =0; i < karty.Count; i++) 
            {
                nazwyKart[i] = karty[i].nazwa;
            }

            return nazwyKart;
        }

        public void sortuj() 
        {
            karty.Sort(new SortujWgKoloru());
        }
    }
}
