using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObstawianieWyscigow
{
    class Klient
    {
        public string imie;
        public int konto;
        public RadioButton mojPrzycisk;
        public Label mojTekst;
        public Zaklad mojZaklad = new Zaklad();

        public Klient() { }

        public Klient(string imie, int konto, RadioButton mojPrzycisk, Label mojTekst) {
            this.imie = imie;
            this.konto = konto;
            this.mojPrzycisk = mojPrzycisk;
            this.mojTekst = mojTekst;
        }
        public void aktualizujDane() {
            mojPrzycisk.Text = string.Format("{0} ma {1} zł", imie, konto);
            /*if (mojZaklad) {
                mojTekst.Text = string.Format("{0}");
            }
            else
            {
                mojTekst.Text = string.Format("");
            }*/
        }
        public void wyczyscZaklad() { }

        /*public bool postawZaklad(int ilosc, int zawodnik) {
            Zaklad mojZaklad = new Zaklad(ilosc, zawodnik, this);
            if () { }
            return ;
        }*/
        public void pobierzZaklad() { }
    }
}
