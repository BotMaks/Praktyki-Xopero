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
            gracz.ruszSię(klawisz.Key);
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
        public void atak(KeyEventArgs klawisz, Random rand) 
        {
            gracz.atak(klawisz.Key, rand);
            foreach (Przeciwnik przeciwnik in przeciwnicy) 
            {
                przeciwnik.ruszSię(rand);
            }
        }
        private Point podajLosoweMiejsce(Random rand) 
        {
            return new Point(bariera.Left + rand.Next(bariera.Right / 10 - bariera.Left / 10) * 10, 
                bariera.Top + rand.Next(bariera.Bottom / 10 - bariera.Top / 10) * 10);
        }
        public void nowyPoziom(Random rand)
        {
            poziom++;
            List<Przeciwnik> przeciwnicy1 = new List<Przeciwnik>();
            switch (poziom)
            {
                case 1:
                    przeciwnicy1.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new Miecz(this, podajLosoweMiejsce(rand));
                    break;
                case 2:
                    przeciwnicy1.Clear();
                    przeciwnicy1.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new MałaPotka(this, podajLosoweMiejsce(rand));
                    break;
                case 3:
                    przeciwnicy1.Clear();
                    przeciwnicy1.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new Łuk(this, podajLosoweMiejsce(rand));
                    break;
                case 4:
                    przeciwnicy1.Clear();
                    przeciwnicy1.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    przeciwnicy1.Add(new Duch(this, podajLosoweMiejsce(rand)));
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
                    przeciwnicy1.Clear();
                    przeciwnicy1.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    przeciwnicy1.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new DużaPotka(this, podajLosoweMiejsce(rand));
                    break;
                case 6:
                    przeciwnicy1.Clear();
                    przeciwnicy1.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    przeciwnicy1.Add(new Upiór(this, podajLosoweMiejsce(rand)));
                    bronieWPokoju = new Topór(this, podajLosoweMiejsce(rand));
                    break;
                case 7:
                    przeciwnicy1.Clear();
                    przeciwnicy1.Add(new Nietoperz(this, podajLosoweMiejsce(rand)));
                    przeciwnicy1.Add(new Duch(this, podajLosoweMiejsce(rand)));
                    przeciwnicy1.Add(new Upiór(this, podajLosoweMiejsce(rand)));
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