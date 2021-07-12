using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace ObstawianieWyscigow
{
    class Zawodnik
    {
        public int pozycjaStartowa;
        public int dlugoscTrasy;
        public Image obraz = null;
        public int polozenie;
        public Random random = new Random();

        public Zawodnik() { }

        public bool biegnij(double poczatek, double koniec, double czas) {
            DoubleAnimation animacja = new DoubleAnimation() { From = poczatek, To = koniec, Duration = new Duration(TimeSpan.FromSeconds(czas)) };
            
            return true;
        }

        public void doStartu() { }
    }
}
