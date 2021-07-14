using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ul
{
    class Pszczoła
    {
        protected static double konsumpcjaMioduNaMg = 0.25;
        protected double waga;

        public Pszczoła(double waga) {
            this.waga = waga;
        }

        public double konsumpcjaMiodu()
        {
            return konsumpcjaMioduNaMg * waga;
        }
    }
}
