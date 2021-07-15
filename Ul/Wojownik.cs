using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ul
{
    class Wojownik:Robotnica
    {
        public int poziomAlarmu { get; private set; }
        public int długośćŻądła { get; private set; }
        public bool ostrzenieŻądła(int długość) { return true; }
        public bool szukajOponenta() { return true; }
        public void żądlOponenta(string oponent) { }
    }
}
