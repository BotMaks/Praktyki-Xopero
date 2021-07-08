using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
namespace program1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            DodajOponenta();
        }

        private void DodajOponenta()
        {
            ContentControl oponent = new ContentControl();
            oponent.Template = Resources["Oponent"] as ControlTemplate;
            AnimujOponenta(oponent, 0, playArea.ActualWidth - 100, "(Canvas.Left)");
            AnimujOponenta(oponent, random.Next((int)playArea.ActualHeight - 100), random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");
            playArea.Children.Add(oponent);
        }

        private void AnimujOponenta(ContentControl oponent, double poczatek, double koniec, string infoDoAnimacji)
        {
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever};
            DoubleAnimation animacja = new DoubleAnimation() {From = poczatek, To = koniec, Duration = new Duration(TimeSpan.FromSeconds(random.Next(3,5)))};
            Storyboard.SetTarget(animacja, oponent);
            Storyboard.SetTargetProperty(animacja, new PropertyPath(infoDoAnimacji));
            storyboard.Children.Add(animacja);
            storyboard.Begin();
        }
    }
}
