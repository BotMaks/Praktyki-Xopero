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

        public void biegnij(Image zawodnik, double poczatek, double koniec, string infoDoAnimacji) {
            //nie działa

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animacja = new DoubleAnimation() { From = poczatek, To = koniec, Duration = new Duration(TimeSpan.FromSeconds(5)) };
            Storyboard.SetTarget(animacja, zawodnik);
            Storyboard.SetTargetProperty(animacja, new PropertyPath(infoDoAnimacji));
            storyboard.Begin();
        }

        public void doStartu(Image zawodnik) {
            
        }
    }
}
