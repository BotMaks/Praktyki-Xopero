using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Program_dla_Krystyny
{
    class Impreza
    {
        protected int ilośćOsób;
        protected bool dekoracje;
        protected double całkowityKoszt;
        public Impreza() { }

        public void ustawIlośćOsób(int ilośćOsób)
        {
            this.ilośćOsób = ilośćOsób;
        }

        

        public void ustawDekoracje(bool dekoracje) {
            if (dekoracje) {
                this.dekoracje = true;
            }
            else{
                this.dekoracje = false;
            }
        }
        
    }
}
