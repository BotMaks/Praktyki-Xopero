using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaczki
{
    class Kaczka//: IComparable<Kaczka>
    {
        public int rozmiar;
        public gatunekKaczki gatunek;
        public enum gatunekKaczki
        {
            Domowa,
            Krzyżówka, 
            Pekin,
            Piżmowa,
            Karolinka
        }
        public Kaczka() { }
        public Kaczka(gatunekKaczki gatunek, int rozmiar) {
            this.gatunek = gatunek;
            this.rozmiar = rozmiar;
        }

        public string info() { return string.Format("Gatunek: {0}, rozmiar: {1}", gatunek, rozmiar); }

        public override string ToString()
        {
            return string.Format("{0} - centymetrowa kaczka {1}", rozmiar, gatunek);
        }

        /*public int CompareTo(Kaczka kaczkaDoPorównania) {
            if(rozmiar > kaczkaDoPorównania.rozmiar) { return 1; }
            else if(rozmiar < kaczkaDoPorównania.rozmiar) { return -1; }
            else { return 0; }
        }*/
    }
}
