using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;


namespace Wyprawa
{
    class Gra
    {
        public List<Przeciwnik> przeciwnicy { get; private set; }
        public Broń bronieWPokoju { get; private set; }
        private Gracz gracz;
        public Point lokalizacjaGracza { get { return gracz.Lokalizacja; } }
        public int życieGracza { get { return gracz.zdrowie; } }
        public IEnumerable<string> bronieGracza { get { return gracz.bronie; } }
        private int poziom = 0;
        public int Poziom { get { return poziom; } }

        private Canvas bariera;
        public Canvas Bariera { get { return bariera; } }

        public Gra(Canvas bariera) 
        {
            this.bariera = bariera;
            gracz = new Gracz(this, new Point(15, 90));
        }
        public void ruch(Key klawisz, Random rand) 
        {
            gracz.ruszSię(klawisz);
            foreach(Przeciwnik przeciwnik in przeciwnicy)
            {
                uderzGracza(przeciwnik.ruszSię(rand), rand);
            }
        }
        public void weżBroń(string nazwaBroni) 
        {
            gracz.weźBroń(nazwaBroni);
        }
        public bool sprawdźEkwipunekGracza(string nazwaBroni) 
        {
            return gracz.bronie.Contains(nazwaBroni);
        }
        public void uderzGracza(int maxObrażenia, Random rand) 
        {
            gracz.otrzymanieObrażeń(maxObrażenia, rand);
        }
        public void podnieśZdrowieGracza(int leczenie, Random rand) 
        {
            gracz.zwiększenieZdrowia(leczenie, rand);
        }
        public void atak(Key klawisz, Random rand) 
        {
            gracz.atak(klawisz, rand);
            foreach (Przeciwnik przeciwnik in przeciwnicy) 
            {
                uderzGracza(przeciwnik.ruszSię(rand), rand);
            }
        }
        private Point podajLosoweMiejsce(Random rand) 
        {

            return new Point(rand.Next(0, Convert.ToInt32(bariera.ActualWidth)), 
                rand.Next(0, Convert.ToInt32(bariera.ActualHeight)));
        }
        public void nowyPoziom(Random rand)
        {
            poziom++;
            przeciwnicy = new List<Przeciwnik>();
            switch (poziom)
            {
                case 1:
                    przeciwnicy.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new Miecz(this, podajLosoweMiejsce(rand));
                    break;
                case 2:
                    przeciwnicy.Clear();
                    przeciwnicy.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new MałaPotka(this, podajLosoweMiejsce(rand));
                    break;
                case 3:
                    przeciwnicy.Clear();
                    przeciwnicy.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new Łuk(this, podajLosoweMiejsce(rand));
                    break;
                case 4:
                    przeciwnicy.Clear();
                    przeciwnicy.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    przeciwnicy.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    if (!sprawdźEkwipunekGracza("Łuk")) 
                    {
                        bronieWPokoju = new Łuk(this, podajLosoweMiejsce(rand));
                    }
                    else
                    {
                        bronieWPokoju = new MałaPotka(this, podajLosoweMiejsce(rand));
                    }
                    break;
                case 5:
                    przeciwnicy.Clear();
                    przeciwnicy.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    przeciwnicy.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new DużaPotka(this, podajLosoweMiejsce(rand));
                    break;
                case 6:
                    przeciwnicy.Clear();
                    przeciwnicy.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    przeciwnicy.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new Topór(this, podajLosoweMiejsce(rand));
                    break;
                case 7:
                    przeciwnicy.Clear();
                    przeciwnicy.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    przeciwnicy.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    przeciwnicy.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    if (!sprawdźEkwipunekGracza("Topór")) {
                        bronieWPokoju = new Topór(this, podajLosoweMiejsce(rand));
                    }
                    else
                    {
                        bronieWPokoju = new DużaPotka(this, podajLosoweMiejsce(rand));
                    }
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Przeszedłeś moja grę.", "Gratulacje!");
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }
    }
}