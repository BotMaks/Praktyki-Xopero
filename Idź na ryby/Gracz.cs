using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Idź_na_ryby
{
    class Gracz
    {
        private string imie;
        public string nazwa { get { return imie; } }
        private Random random;
        private Talia ręka;
        private TextBox przebieg;
        public Gracz(string imie, Random random, TextBox przebieg) 
        {
            this.imie = imie;
            this.random = random;
            this.przebieg = przebieg;
            this.ręka = new Talia(new Karta[] { });
            przebieg.Text += imie + " przyłączył się do gry.\n";
        }
        public int licznikKart { get { return ręka.licznik; } }
        public void weźKartę(Karta karta) { ręka.dodaj(karta); }
        public IEnumerable<string> podajNazwęKart() { return ręka.podajNazwyKart(); }
        public Karta sprawdź(int nrKarty) { return ręka.sprawdź(nrKarty); }
        public  void sortujRękę() { ręka.sortujWgWartości(); }
        public IEnumerable<Karta.Wartość> sprawdźCzyGrupa()
        {
            List<Karta.Wartość> pary = new List<Karta.Wartość>();
            for (int i = 1; i <= 13; i++) 
            {
                Karta.Wartość wartość = (Karta.Wartość)i;
                int ile = 0;
                for (int karta = 0; karta < ręka.licznik; karta++) 
                {
                    if (ręka.sprawdź(karta).wartość == wartość) { ile++; }    
                }
                if(ile == 4) 
                {
                    pary.Add(wartość);
                    for(int karta = ręka.licznik - 1; karta >= 0; karta--)
                    {
                        ręka.wymiana(karta);
                    }
                }
                
            }
            return pary;
        }
        public Karta.Wartość dajLosowąWartość()
        {
            Karta losowaKarta = ręka.sprawdź(random.Next(ręka.licznik));
            return losowaKarta.wartość;
        }
        public Talia czyMaszKartę(Karta.Wartość wartość) 
        {
            Talia mojeKarty = ręka.wyciągnijKarty(wartość);
            przebieg.Text += string.Format(">{0} ma {1} {2}\n", nazwa, mojeKarty.licznik, Karta.odmiana(wartość, mojeKarty.licznik));
            return mojeKarty;
        }
        public void poprośKartę(List<Gracz> gracze, int mójIndex, Talia stos) 
        { 
            if(stos.licznik > 0)
            {
                if(ręka.licznik == 0) { ręka.dodaj(stos.wymiana()); }
            }
            Karta.Wartość losowaWartość = dajLosowąWartość();
            poprośKartę(gracze, mójIndex, stos, losowaWartość);
        }
        public void poprośKartę(List<Gracz> gracze, int mójIndex, Talia stos, Karta.Wartość wartość) 
        {
            przebieg.Text += string.Format("{0} pyta, czy ktoś ma {1}\n", nazwa, Karta.odmiana(wartość, 1));
            int ilośćOddanychKart = 0;
            for (int i = 0; i < gracze.Count; i++) 
            {
                if (i != mójIndex) 
                {
                    Gracz gracz = gracze[i];
                    Talia oddaneKarty = gracz.czyMaszKartę(wartość);
                    ilośćOddanychKart += oddaneKarty.licznik;
                    while(oddaneKarty.licznik > 0) 
                    {
                        ręka.dodaj(oddaneKarty.wymiana());
                    }
                }
            }
            if(ilośćOddanychKart == 0)
            {
                przebieg.Text += string.Format("{0} pobrał kartę z kupki.\n", nazwa);
                ręka.dodaj(stos.wymiana());
            }
        }
    }
}
