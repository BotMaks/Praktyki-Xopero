using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ObstawianieWyscigow
{
    class Zawodnik
    {
        public int pozycjaStartowa;
        public int dlugoscTrasy;
        public Image obraz;
        public int polozenie;
        public Random random;

        Zawodnik() { }

        public bool biegnij() {
            return true;
        }

        public void doStartu() { }
    }
}
