using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idź_na_ryby
{
    class Karta
    {
        private static string[] nazwy0 = new string[]
            {
            "", "asów", "dwójek", "trójek", "czwórek", "piątek", "szóstek", "siódemek", "ósemek", "dziewiątek", "dziesiątek", "waletów", "dam", "króli"
            };
        private static string[] nazwy1 = new string[]
            {
                "", "asa", "dwójkę", "trójkę", "czwórkę", "piątkę", "szóstkę", "siódemkę", "ósemkę", "dziewiątkę", "dziesiątkę", "waleta", "damę", "króla"
            };
        private static string[] nazwy2IWięcej = new string[] 
            {
                "", "asy", "dwójki", "trójki", "czwórki", "piątki", "szóstki", "siódemki", "ósemki", "dziewiątki", "dziesiątki", "walety", "damy", "króle"
            };

        public static string odmiana(Karta.Wartość wartość, int ilość) 
        {
            if(ilość == 0) 
            { 
                return nazwy0[(int)wartość]; 
            }
            else if (ilość == 1) 
            { 
                return nazwy1[(int)wartość]; 
            }
            else 
            { 
                return nazwy2IWięcej[(int)wartość]; 
            }
        }
        public enum Kolor
        {
            pik,
            kier,
            trefl,
            karo
        }
        public enum Wartość
        {
            As = 1,
            dwa = 2,
            trzy = 3,
            cztery = 4,
            pięć = 5,
            sześć = 6,
            siedem = 7,
            osiem = 8,
            dziewięć = 9,
            dziesięć = 10,
            walet = 11,
            dama = 12,
            król = 13
        }

        public Kolor kolor { get; set; }
        public Wartość wartość { get; set; }

        public Karta(Kolor kolor, Wartość wartość)
        {
            this.kolor = kolor;
            this.wartość = wartość;
        }
        public string nazwa
        {
            get
            {
                return wartość.ToString() + " " + kolor.ToString();
            }
        }
        public override string ToString()
        {
            return nazwa;
        }
    }
}
