using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_dla_Krystyny
{
    class Urodziny:Impreza
    {
        private double kosztTortuZNapisami;
        private string napis = "";
        private int kosztTortu;

        public Urodziny() { }

        public void rozmiarTortu() {
            if (ilośćOsób <= 4) { kosztTortu = 40; }
            else { kosztTortu = 75; }
        }

        public bool zmieńNapis(string napis) {
            
            napis = napis.Replace(" ", "");
            if (ilośćOsób <= 4 && napis.Length>16 || ilośćOsób > 4 && napis.Length>40) { return false; }

            this.napis = napis;

            return true;
        }

        public string obliczCałkowityKoszt() {

            napis = napis.Replace(" ", "");
            kosztTortuZNapisami = kosztTortu + (napis.Length * 0.25);

            if (dekoracje == true)
            {
                całkowityKoszt = 50 + (ilośćOsób * 15) + kosztTortuZNapisami;
            }
            else
            {
                całkowityKoszt = 30 + (ilośćOsób * 7.5) + kosztTortuZNapisami;
            }
            return Convert.ToString(Math.Round(całkowityKoszt, 2));
        }
    }
}
