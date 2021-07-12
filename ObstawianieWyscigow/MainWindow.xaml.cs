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

namespace ObstawianieWyscigow
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double minKwota=5;
        double maxKwota=15;
        public MainWindow()
        {
            InitializeComponent();
            Klient janek = new Klient("Janek", 50, przyciskJanka, tekstJanka);
            Klient bartek= new Klient("Bartek", 75, przyciskBartka, tekstBartka);
            Klient arek = new Klient("Arek", 45, przyciskArka, tekstArka);

            janek.aktualizujDane();
            bartek.aktualizujDane();
            arek.aktualizujDane();
            infoZaklad.Text=string.Format("Tylko zakłady od {0} do {1} zł", minKwota, maxKwota);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //tworzenie zakladu

            /*if (przyciskJanka.IsChecked==true) {
                janek.postawZaklad(kwota.SelectedItem, numerZawodnika.SelectedItem);
                janek.aktualizujDane();
            }
            else if (przyciskBartka.IsChecked == true) {
                bartek.postawZaklad(kwota.SelectedItem, numerZawodnika.SelectedItem);
                bartek.aktualizujDane();
            }
            else if(przyciskArka.IsChecked == true)
            {
                arek.postawZaklad(kwota.SelectedItem, numerZawodnika.SelectedItem);
                arek.aktualizujDane();
            }
            else{
                MessageBox.Show("Wybierz obstawiającego");    
            }*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Zawodnik zaw4 = new Zawodnik();
            string[] tab = {"zaw1", "zaw2", "zaw3", "zaw4"};
            zaw4.biegnij(zawodnik1,80,640,"(Canvas.Top)");
            Random random = new Random();
            int zwyciezca = random.Next(4);
            MessageBox.Show(string.Format("Zawodnik numer {0} wygrał wyscig!", zwyciezca+1));
        }
    }
}