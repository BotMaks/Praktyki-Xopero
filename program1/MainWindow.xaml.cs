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
using System.Drawing;
using System.Configuration;
using System.IO;

namespace program1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        DispatcherTimer timerOponenta = new DispatcherTimer();
        DispatcherTimer timerCelu = new DispatcherTimer();
        bool zlapCzlowieka = false;

        static string czytaj = File.ReadAllText(@"C:\Users\xopero\source\repos\Praktyki-Xopero\program1\najWynik.txt");
        int najlepszyWynik = Convert.ToInt32(czytaj);
        int wynik = 0;

        public MainWindow()
        {
            InitializeComponent();
            tekstKoncowy.Visibility = Visibility.Collapsed;
            timerOponenta.Tick += TimerOponenta_Tick;
            timerCelu.Tick += TimerCelu_Tick;
        }

        private void TimerCelu_Tick(object sender, EventArgs e)
        {
            pasekPostepu.Value += 1;
            if (pasekPostepu.Value >= pasekPostepu.Maximum) {
               WylaczGre();
            }
        }

        private void WylaczGre() {
            if (!playArea.Children.Contains(tekstKoncowy)) {
                timerOponenta.Stop();
                timerCelu.Stop();
                zlapCzlowieka = false;
                startButton.Visibility = Visibility.Visible;
                playArea.Children.Add(tekstKoncowy);
                if (wynik>najlepszyWynik) { najlepszyWynik = wynik; }
                najWynik.Text = "Najlepszy wynik: " + najlepszyWynik;
                File.WriteAllText(@"C:\Users\xopero\source\repos\Praktyki-Xopero\program1\najWynik.txt", Convert.ToString(najlepszyWynik));
            }
        }

        private void TimerOponenta_Tick(object sender, EventArgs e)
        {
            DodajOponenta();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            timerOponenta.Interval = TimeSpan.FromSeconds(4 - wyborTrudnosci.SelectedIndex);
            if (wyborTrudnosci.SelectedIndex == 0)
            {
                timerCelu.Interval = TimeSpan.FromSeconds(0.15);
            }
            else if (wyborTrudnosci.SelectedIndex == 1)
            {
                timerCelu.Interval = TimeSpan.FromSeconds(0.1);
            }
            else if (wyborTrudnosci.SelectedIndex == 2)
            {
                timerCelu.Interval = TimeSpan.FromSeconds(0.08);
            }
            else if (wyborTrudnosci.SelectedIndex == 3)
            {
                timerCelu.Interval = TimeSpan.FromSeconds(0.05);
            }
            RozpocznijGre();
        }

        private void RozpocznijGre() {
            wynik = 0;
            czlowiek.IsHitTestVisible = true;
            zlapCzlowieka = false;
            pasekPostepu.Value = 0;
            startButton.Visibility = Visibility.Collapsed;
            playArea.Children.Clear();
            DodajOponenta();
            playArea.Children.Add(czlowiek);
            playArea.Children.Add(cel);
            timerOponenta.Start();
            timerCelu.Start();

        }
        private void DodajOponenta()
        {
            ContentControl oponent = new ContentControl();
            oponent.Template = Resources["Oponent"] as ControlTemplate;
            AnimujOponenta(oponent, 0, playArea.ActualWidth - 70, "(Canvas.Left)");
            AnimujOponenta(oponent, random.Next((int)playArea.ActualHeight - 70), random.Next((int)playArea.ActualHeight - 70), "(Canvas.Top)");
            playArea.Children.Add(oponent);

            oponent.MouseEnter += Oponent_MouseEnter;
        }

        private void Oponent_MouseEnter(object sender, MouseEventArgs e)
        {
            if (zlapCzlowieka) {
                WylaczGre();
            }
        }

        private void AnimujOponenta(ContentControl oponent, double poczatek, double koniec, string infoDoAnimacji)
        {
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever};
            DoubleAnimation animacja = new DoubleAnimation() {From = poczatek, To = koniec, Duration = new Duration(TimeSpan.FromSeconds(random.Next(4 - wyborTrudnosci.SelectedIndex, 6 - wyborTrudnosci.SelectedIndex)))};
            Storyboard.SetTarget(animacja, oponent);
            Storyboard.SetTargetProperty(animacja, new PropertyPath(infoDoAnimacji));
            storyboard.Children.Add(animacja);
            storyboard.Begin();
        }

        private void czlowiek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (timerOponenta.IsEnabled)
            {
                zlapCzlowieka = true;
                czlowiek.IsHitTestVisible = false;
            }
        }

        private void cel_MouseMove(object sender, MouseEventArgs e)
        {
            if (timerCelu.IsEnabled && zlapCzlowieka) {
                wynik += 1 * (wyborTrudnosci.SelectedIndex + 1);
                twojWynik.Text = "Twój wynik: "+wynik;
                pasekPostepu.Value = 0;
                Canvas.SetLeft(cel, random.Next(100, (int)playArea.ActualWidth - 100));
                Canvas.SetTop(cel, random.Next(100, (int)playArea.ActualHeight - 100));
                Canvas.SetLeft(czlowiek, random.Next(100, (int)playArea.ActualWidth - 100));
                Canvas.SetTop(czlowiek, random.Next(100, (int)playArea.ActualHeight - 100));
               
                zlapCzlowieka = false;
                czlowiek.IsHitTestVisible = true;
            }
        }

        private void playArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (zlapCzlowieka) {
                Point pozycjaKursora = e.GetPosition(null);
                Point relatywnaPozycja = grid.TransformToVisual(playArea).Transform(pozycjaKursora);
                if ((Math.Abs(relatywnaPozycja.X - Canvas.GetLeft(czlowiek)) > czlowiek.ActualWidth * 3)
                    || (Math.Abs(relatywnaPozycja.Y - Canvas.GetTop(czlowiek)) > czlowiek.ActualHeight * 3))
                {
                    zlapCzlowieka = false;
                    czlowiek.IsHitTestVisible = true;
                }
                else {
                    Canvas.SetLeft(czlowiek, relatywnaPozycja.X - czlowiek.ActualWidth / 2);
                    Canvas.SetTop(czlowiek, relatywnaPozycja.Y - czlowiek.ActualHeight / 2);
                }
            }
        }

        private void playArea_MouseLeave(object sender, MouseEventArgs e)
        {
            if (zlapCzlowieka) {
                WylaczGre();
            }
        }
    }
}
