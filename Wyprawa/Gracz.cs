using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Wyprawa
{
    class Gracz:Ruch
    {
        private Broń posiadanaBroń;
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
                if (broń.nazwa == nazwaBroni) { posiadanaBroń = broń; }
            }
        }
        public void ruszSię(KeyEventArgs klawisz) 
        { 
            //dokończ to
        }
    }
}
