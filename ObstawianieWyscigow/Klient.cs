using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ObstawianieWyscigow
{
    class Klient
    {
        public string imie;
        public int konto;
        public RadioButton mojPrzycisk;
        public Label mojTekst;
        public Zaklad mojZaklad;

        public Klient() { }

        public Klient(string imie, int konto, RadioButton mojPrzycisk, Label mojTekst) {
            this.imie = imie;
            this.konto = konto;
            this.mojPrzycisk = mojPrzycisk;
            this.mojTekst = mojTekst;
        }
        public void aktualizujDane() {
            mojPrzycisk.Content = string.Format("{0} ma {1} zł", imie, konto);
            if (mojZaklad != null) {
                mojTekst.Content = string.Format("{0} stawia {1} zł na zawodnika numer {2}", imie, mojZaklad.ilosc, mojZaklad.nrZawodnika+1);
            }
            else
            {
                mojTekst.Content = string.Format("{0} nie zawarł zakładu", imie);
            }
        }
        public void wyczyscZaklad() {
            mojZaklad = null;
        }

        public bool postawZaklad(int ilosc, int zawodnik) {

            if (konto >= ilosc)
            {
                Zaklad mojZaklad = new Zaklad(ilosc, zawodnik, this);
                return true;
            }
            else { return false; }
        }
        public void pobierzZaklad(int zwyciezca) {
            konto += mojZaklad.wyplata(zwyciezca);
        }
    }
}
