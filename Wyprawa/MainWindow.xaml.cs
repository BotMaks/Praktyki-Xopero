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

namespace Wyprawa
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Gra gra;
        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            gra = new Gra(plansza);
            gra.nowyPoziom(rand);
            aktualizujPostacie();
        }



        private void aktualizujPostacie()
        {
            plansza.Children.Clear();
            plansza.Children.Add(graczGrafika);
            Canvas.SetLeft(graczGrafika, gra.lokalizacjaGracza.X);
            Canvas.SetTop(graczGrafika, gra.lokalizacjaGracza.Y);
            graczText.Text = "Zdrowie gracza";
            zdrowieGraczText.Text = gra.życieGracza.ToString();

            pierwszyPrzeciwnikText.Text = "";
            drugiPrzeciwnikText.Text = "";
            int pokazaniPrzeciwnicy = 0;


            TextBlock[] zdrowiePrzeciwnika = { zdrowiePierwszegoPrzeciwnika, zdrowieDrugiegoPrzeciwnika };
            foreach (Przeciwnik przeciwnik in gra.przeciwnicy) 
            {
                if(przeciwnik is Nietoperz)
                {
                    if (przeciwnik.zdrowie > 0)
                    {
                        plansza.Children.Add(nietoperzGrafika);
                        Canvas.SetLeft(nietoperzGrafika, przeciwnik.Lokalizacja.X);
                        Canvas.SetTop(nietoperzGrafika, przeciwnik.Lokalizacja.Y);

                        zdrowiePrzeciwnika[pokazaniPrzeciwnicy].Text = przeciwnik.zdrowie.ToString();
                        pokazaniPrzeciwnicy++;
                    }
                }
                if(przeciwnik is Duch) 
                {
                    if (przeciwnik.zdrowie > 0)
                    {
                        plansza.Children.Add(duchGrafika);
                        Canvas.SetLeft(duchGrafika, przeciwnik.Lokalizacja.X);
                        Canvas.SetTop(duchGrafika, przeciwnik.Lokalizacja.Y);

                        zdrowiePrzeciwnika[pokazaniPrzeciwnicy].Text = przeciwnik.zdrowie.ToString();
                        pokazaniPrzeciwnicy++;
                    }
                }
                if(przeciwnik is Upiór) 
                {
                    if (przeciwnik.zdrowie > 0)
                    {
                        plansza.Children.Add(upiórGrafika);
                        Canvas.SetLeft(upiórGrafika, przeciwnik.Lokalizacja.X);
                        Canvas.SetTop(upiórGrafika, przeciwnik.Lokalizacja.Y);

                        zdrowiePrzeciwnika[pokazaniPrzeciwnicy].Text = przeciwnik.zdrowie.ToString();
                        pokazaniPrzeciwnicy++;
                    }
                }
            }
            if (pokazaniPrzeciwnicy >= 0) 
            { 
                pierwszyPrzeciwnikText.Text = "Pierwszy przeciwnik"; 
                if(pokazaniPrzeciwnicy >= 1)
                {
                    drugiPrzeciwnikText.Text = "Drugi przeciwnik";
                }
            }
            mieczGrafika.Visibility = Visibility.Collapsed;
            łukGrafika.Visibility = Visibility.Collapsed;
            topórGrafika.Visibility = Visibility.Collapsed;
            małaPotkaGrafika.Visibility = Visibility.Collapsed;
            dużaPotkaGrafika.Visibility = Visibility.Collapsed;
            Image kontrolaPrzedmiotów = null;
            switch (gra.bronieWPokoju.nazwa)
            {
                case "Miecz":
                    kontrolaPrzedmiotów = mieczGrafika;
                    break;
                case "Łuk":
                    kontrolaPrzedmiotów = łukGrafika;
                    break;
                case "Topór":
                    kontrolaPrzedmiotów = topórGrafika;
                    break;
                case "Mała potka":
                    kontrolaPrzedmiotów = małaPotkaGrafika;
                    break;
                case "Duża potka":
                    kontrolaPrzedmiotów = dużaPotkaGrafika;
                    break;
                default:
                    break;
            }
            kontrolaPrzedmiotów.Visibility = Visibility.Visible;

            mieczItem.Visibility = Visibility.Collapsed;
            łukItem.Visibility = Visibility.Collapsed;
            topórItem.Visibility = Visibility.Collapsed;
            małaPotkaItem.Visibility = Visibility.Collapsed;
            dużaPotkaItem.Visibility = Visibility.Collapsed;
            if (gra.sprawdźEkwipunekGracza("Miecz")) { mieczItem.Visibility = Visibility.Visible; }
            if (gra.sprawdźEkwipunekGracza("Łuk")) { łukItem.Visibility = Visibility.Visible; }
            if (gra.sprawdźEkwipunekGracza("Topór")) { topórItem.Visibility = Visibility.Visible; }
            if (gra.sprawdźEkwipunekGracza("Mała potka")) { małaPotkaItem.Visibility = Visibility.Visible; }
            if (gra.sprawdźEkwipunekGracza("Duża potka")) { dużaPotkaItem.Visibility = Visibility.Visible; }


            Canvas.SetLeft(kontrolaPrzedmiotów, gra.bronieWPokoju.Lokalizacja.X);
            Canvas.SetTop(kontrolaPrzedmiotów, gra.bronieWPokoju.Lokalizacja.Y);
            if (gra.bronieWPokoju.podniesiona) { kontrolaPrzedmiotów.Visibility = Visibility.Collapsed; }

            if(gra.życieGracza <= 0) 
            {
                MessageBox.Show("Zostałeś zabity"); 
                this.Close();
            }
            if(pokazaniPrzeciwnicy <= 0)
            {
                MessageBox.Show("Pokonałeś przeciwników na tym poziomie!");
                gra.nowyPoziom(rand);

            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key klawisz = e.Key;
            if(klawisz == Key.Up || klawisz == Key.Down || klawisz == Key.Left || klawisz == Key.Right)
            {
                //gracz się przemieszcza
                gra.ruch(klawisz, rand);
                aktualizujPostacie();
            }else if (klawisz == Key.W || klawisz == Key.S || klawisz == Key.A || klawisz == Key.D)
            {
                //gracz atakuje/używa przedmiotu
                gra.atak(klawisz, rand);
                aktualizujPostacie();
            }
            else { MessageBox.Show("Wcisnięto nieprawidłowy klawisz", "Błąd"); }
        }

        private void mieczItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór miecza z ekwipunku
        }
        private void łukItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór łuku z ekwipunku
        }
        private void topórItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór toporu z ekwipunku
        }
        private void małaPotkaItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór małej potki z ekwipunku
        }
        private void dużaPotkaItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór dużej potki z ekwipunku
        }
    }
}
