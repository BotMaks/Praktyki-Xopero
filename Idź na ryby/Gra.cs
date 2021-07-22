using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Idź_na_ryby
{
    class Gra
    {
        private List<Gracz> gracze;
        private Dictionary<Karta.Wartość, Gracz> posiada;
        private Talia stos;
        private TextBox przebieg;
        public Gra(string nazwaGracza, IEnumerable<string> gracze, TextBox przebieg) 
        {
            Random random = new Random();
            this.przebieg = przebieg;
            this.gracze = new List<Gracz>();
            this.gracze.Add(new Gracz(nazwaGracza, random, przebieg));
            foreach (string gracz in gracze) 
            {
                this.gracze.Add(new Gracz(gracz, random, przebieg));
            }
            posiada = new Dictionary<Karta.Wartość, Gracz>();
            stos = new Talia();
            wymiana();
            this.gracze[0].sortujRękę();
        }
        public void wymiana()
        {
            stos.mieszaj();
            for (int i = 0; i < 5; i++) 
            {
                foreach (Gracz gracz in gracze) 
                {
                    gracz.weźKartę(stos.wymiana());
                }
            }
            foreach (Gracz gracz in gracze) 
            {
                wyciągnijParę(gracz);
            }
        }
        public bool wyciągnijParę(Gracz gracz) 
        {
            IEnumerable<Karta.Wartość> wyciągniętePary = gracz.sprawdźCzyGrupa();
            foreach (Karta.Wartość wartość in wyciągniętePary) 
            {
                posiada.Add(wartość, gracz);
            }
            if (gracz.licznikKart == 0) { return true; }
            return false;
        }
        public bool zagrajRundę(int wybranaKarta) 
        {
            Karta.Wartość kartaDoPobrania = gracze[0].sprawdź(wybranaKarta).wartość;
            for (int i = 0; i < gracze.Count; i++) 
            {
                if(i == 0) { gracze[0].poprośKartę(gracze, 0, stos, kartaDoPobrania); }
                else { gracze[i].poprośKartę(gracze, i, stos); }
                if (wyciągnijParę(gracze[i]))
                {
                    przebieg.Text += string.Format("{0} ciągnie karty\n", gracze[i].nazwa);
                    int karty = 0;
                    while (karty < 5 && stos.licznik > 0)
                    {
                        gracze[i].weźKartę(stos.wymiana());
                        karty++;
                    }
                }
                gracze[0].sortujRękę();
                if (stos.licznik == 0) 
                {
                    przebieg.Text += "Na kupce nie ma żadnych kart. Gra skończona!\n";
                    return true;
                }
            }
            return false;
        }
        public string wypiszPary() 
        {
            string ktoMaJakąParę = "";
            foreach (Karta.Wartość wartość in posiada.Keys) 
            {
                ktoMaJakąParę = string.Format("{0} ma grupę {1}\n", posiada[wartość].nazwa, Karta.odmiana(wartość, 0));
            }
            return ktoMaJakąParę;
        }
        public string podajZwycięzce() 
        {
            Dictionary<string, int> zwycięzcy = new Dictionary<string, int>();
            foreach (Karta.Wartość wartość in posiada.Keys) 
            {
                string nazwa = posiada[wartość].nazwa;
                if (zwycięzcy.ContainsKey(nazwa)) { zwycięzcy[nazwa]++; }
                else { zwycięzcy.Add(nazwa, 1); }
            }
            int najwięcejPar = 0;
            foreach (string imie in zwycięzcy.Keys) 
            {
                if(zwycięzcy[imie] > najwięcejPar) { najwięcejPar = zwycięzcy[imie]; }
            }
            bool remis = false;
            string listaZwycięzców = "";
            foreach(string imie in zwycięzcy.Keys)
            {
                if(zwycięzcy[imie] == najwięcejPar) 
                {
                    if (!String.IsNullOrEmpty(listaZwycięzców)) 
                    {
                        listaZwycięzców += " i ";
                        remis = true;
                    }
                    listaZwycięzców += imie;
                }
            }
            listaZwycięzców += string.Format(": {0} grupy ", najwięcejPar);
            if (remis) { return "Remis pomiędzy " + listaZwycięzców; }
            else { return listaZwycięzców; }
        }
        public IEnumerable<string> podajNazwęKartyGracza() 
        {
            return gracze[0].podajNazwęKart();
        }
        public string opiszRękęGracza() 
        {
            string opis = "";
            for (int i = 0; i < gracze.Count; i++) 
            {
                opis += string.Format("{0} ma {1}", gracze[i].nazwa, gracze[i].licznikKart);
                if(gracze[i].licznikKart == 1) { opis += " kartę.\n"; }
                else if(gracze[i].licznikKart == 2) { opis += " karty.\n"; }
                else { opis += " kart.\n"; }
            }
            opis += string.Format("Na kupce pozostało {0} kart.\n", stos.licznik);
            return opis;
        }
    }
}