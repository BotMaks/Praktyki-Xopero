using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Program_dla_Krystyny
{
    class Impreza
    {
        private int ilośćOsób;
        private double kosztJedzenia = 30;
        private bool dekoracje;
        private bool rabat;
        private double całkowityKoszt;
        public Impreza() { }

        public void ustawIlośćOsób(int ilośćOsób)
        {
            this.ilośćOsób = ilośćOsób;
        }

        public void ustawKosztJedzenia(bool opcjaZdrowa) {
            if (opcjaZdrowa)
            {
                rabat = true;
                kosztJedzenia = 30;
            }
            else
            {
                rabat = false;
                kosztJedzenia = 45;
            }
        }

        public void ustawDekoracje(bool dekoracje) {
            if (dekoracje) {
                this.dekoracje = true;
            }
            else{
                this.dekoracje = false;
            }
        }
        public string obliczCałkowityKoszt() {

            if (dekoracje == true) {
                całkowityKoszt = 50 + (ilośćOsób * kosztJedzenia) + (ilośćOsób * 15);
            }
            else
            {
                całkowityKoszt = 30 + (ilośćOsób * kosztJedzenia) + (ilośćOsób * 7.5);
            }
                if (rabat)
            {
                całkowityKoszt *= 0.95;
            }
            return Math.Round(całkowityKoszt,2).ToString();
        }
    }
}
