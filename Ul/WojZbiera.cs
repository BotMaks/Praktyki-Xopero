using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ul
{
    class WojZbiera: Robotnica, IZbieracz, IWojownik
    {
        public int poziomAlarmu{ get; private set; }
        public int długośćŻądła { get; set; }
        public int nektar { get; set; }
        public bool szukajOponenta() { return true; }
        public bool ostrzenieŻądła(int długość) { return true; }
        public void znajdźKwiatek() { }
        public void zbierzNektar() { }
        public void zwróćDoUla() { }
    }
}
