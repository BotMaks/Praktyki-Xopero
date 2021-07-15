using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ul
{
    interface IWojownik
    {
        int poziomAlarmu { get;  }
        int długośćŻądła { get; set; }
        bool szukajOponenta();
        bool ostrzenieŻądła(int długość);

    }
}
