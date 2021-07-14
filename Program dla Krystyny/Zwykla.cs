using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_dla_Krystyny
{
    class Zwykla:Impreza
    {
        private double kosztJedzenia = 30;
        private bool rabat;
        public Zwykla() { }

        public void ustawKosztJedzenia(bool opcjaZdrowa)
        {
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

        public string obliczCałkowityKoszt()
        {

            if (dekoracje == true)
            {
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
            return Math.Round(całkowityKoszt, 2).ToString();
        }
    }
}
