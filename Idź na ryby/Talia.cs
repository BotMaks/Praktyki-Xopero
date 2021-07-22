using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idź_na_ryby
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
                for (int wartość = 1; wartość < 14; wartość++)
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
            for (int i = 0; i < karty.Count; i++)
            {
                nazwyKart[i] = karty[i].nazwa;
            }

            return nazwyKart;
        }
        public Karta sprawdź(int nrKarty)
        {
            return karty[nrKarty];
        }
        public Karta wymiana() 
        { 
            return wymiana(0); 
        }
        public bool zawieraKarte(Karta.Wartość wartość) 
        {
            foreach(Karta karta in karty)
            {
                if (karta.wartość == wartość) { return true; }
            }
            return false;
        }
        public Talia wyciągnijKarty(Karta.Wartość wartość)
        {
            Talia taliaDoZwrócenia = new Talia(new Karta[] { });
            for (int i = karty.Count - 1; i >= 0; i--)
            {
                if (karty[i].wartość == wartość) { taliaDoZwrócenia.dodaj(wymiana(i)); }
            }
            return taliaDoZwrócenia;
        }
        public bool maParę(Karta.Wartość wartość) 
        {
            int ilośćKart = 0;
            foreach (Karta karta in karty) 
            {
                if(karta.wartość == wartość) 
                {
                    ilośćKart++;
                }
            }
            if(ilośćKart == 4) { return true; }
            else { return false; }
        }
        public void sortujWgWartości() 
        {
            karty.Sort(new SortujWgWartości());
        }
    }
}