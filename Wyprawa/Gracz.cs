using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Controls;

namespace Wyprawa
{
    class Gracz:Ruch
    {
        private Broń używanaBroń;
        public int zdrowie { get; private set; }
        private List<Broń> ekwipunek = new List<Broń>();
        public IEnumerable<string> bronie 
        { 
            get {
                List<string> nazwy = new List<string>();
                foreach(Broń broń in ekwipunek) { nazwy.Add(broń.nazwa); }
                return nazwy;
            } 
        }
        public Gracz(Gra gra, Point lokalizacja):base(gra, lokalizacja) 
        {
            zdrowie = 10;
        }
        public void otrzymanieObrażeń(int maxObrażenia, Random rand) 
        {
            zdrowie -= rand.Next(1, maxObrażenia);
        }
        public void zwiększenieZdrowia(int leczenie, Random rand) 
        {
            zdrowie += rand.Next(1, leczenie);
        }
        public void weźBroń(string nazwaBroni) 
        {
            foreach (Broń broń in ekwipunek) 
            {
                if (broń.nazwa == nazwaBroni) { używanaBroń = broń; }
            }
        }
        public void ruszSię(Key klawisz) 
        {
            base.lokalizacja = ruszSię(klawisz, gra.Bariera);
            if (!gra.bronieWPokoju.podniesiona)
            {
                if(otoczenie(this.lokalizacja, gra.bronieWPokoju.Lokalizacja, PrędkośćPoruszania))
                {
                    ekwipunek.Add(gra.bronieWPokoju);
                    gra.bronieWPokoju.podnieśBroń();
                }
            }
        }
        public void atak(Key klawisz, Random rand) 
        {
            if(używanaBroń != null && używanaBroń.podniesiona == true)
            {
                if(używanaBroń is IPotki)
                {
                    
                    używanaBroń.atak(klawisz, rand);
                    ekwipunek.Remove(używanaBroń);
                    
                }
                else
                {
                    używanaBroń.atak(klawisz, rand);
                }
            }
            MessageBox.Show("Nie wybrałeś żadnego przedmiotu!");   
        }
    }
}
