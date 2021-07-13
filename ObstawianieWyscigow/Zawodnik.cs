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
        public double czas;
        public Zawodnik() { }

        public void biegnij(ContentControl zawodnik, double czas) {
            
            this.czas = czas;
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animacja = new DoubleAnimation() { From = 0, To = 640, Duration = new Duration(TimeSpan.FromSeconds(czas)) };
            Storyboard.SetTarget(animacja, zawodnik);
            Storyboard.SetTargetProperty(animacja, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(animacja);
            storyboard.Begin();
        }

        public void doStartu(ContentControl zawodnik) {
            Canvas.SetLeft(zawodnik, 0);
        }
    }
}
