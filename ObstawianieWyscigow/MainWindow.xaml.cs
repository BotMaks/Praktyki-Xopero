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
        Klient janek;
        Klient bartek;
        Klient arek;
        bool prawda;
        public MainWindow()
        {
            InitializeComponent();
            this.janek = new Klient("Janek", 50, przyciskJanka, tekstJanka);
            this.bartek= new Klient("Bartek", 75, przyciskBartka, tekstBartka);
            this.arek = new Klient("Arek", 45, przyciskArka, tekstArka);

            janek.aktualizujDane();
            bartek.aktualizujDane();
            arek.aktualizujDane();
            infoZaklad.Text=string.Format("Tylko zakłady od {0} do {1} zł", minKwota, maxKwota);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //tworzenie zakladu

            if (przyciskJanka.IsChecked== true && kwota.SelectedIndex > -1 && numerZawodnika.SelectedIndex > -1)
            {
                prawda = janek.postawZaklad(kwota.SelectedIndex+5,numerZawodnika.SelectedIndex+1);
                if (prawda == false) { MessageBox.Show("Zakład nie został prawidłowo wprowadzony"); }
                janek.aktualizujDane();
            }
            else if (przyciskBartka.IsChecked == true && kwota.SelectedIndex > -1 && numerZawodnika.SelectedIndex > -1) {
                prawda = bartek.postawZaklad(kwota.SelectedIndex+5, numerZawodnika.SelectedIndex+1);
                if (prawda == false) { MessageBox.Show("Zakład nie został prawidłowo wprowadzony"); }

                bartek.aktualizujDane();
            }
            else if(przyciskArka.IsChecked == true && kwota.SelectedIndex > -1 && numerZawodnika.SelectedIndex > -1)
            {
                prawda = arek.postawZaklad(kwota.SelectedIndex+5, numerZawodnika.SelectedIndex+1);
                if (prawda == false) { MessageBox.Show("Zakład nie został prawidłowo wprowadzony"); }
                arek.aktualizujDane();
            }
            else{
                MessageBox.Show("Wybierz wszystkie opcje");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Zawodnik zaw1 = new Zawodnik();
            Zawodnik zaw2 = new Zawodnik();
            Zawodnik zaw3 = new Zawodnik();
            Zawodnik zaw4 = new Zawodnik();


            Zawodnik[] zawodnicy = { zaw1,zaw2,zaw3,zaw4 };
            ContentControl[] tab = {zawodnik1, zawodnik2, zawodnik3, zawodnik4};
            double[] wyniki = new double[4];
            Random random = new Random();
            int zwyciezca = 0;
            int frajer = 0;

            for (int i=0; i<4; i++)
            {
                wyniki[i] = random.NextDouble()*(8-4)+4;
                zawodnicy[i].biegnij(tab[i], wyniki[i]);
                
            }
            for(int i=1; i < 4; i++)
            {
                if (wyniki[zwyciezca] > wyniki[i]) {
                    zwyciezca = i;
                }
                if (wyniki[frajer] < wyniki[i])
                {
                    frajer = i;
                }
            }

                MessageBox.Show(string.Format("Zawodnik numer {0} wygrał wyscig!\nA {1} to frajer", zwyciezca+1, frajer+1));
            for (int i; i<4,i++) {
            zawodnicy[i].doStartu(tab[i]);
            }

        }

        private void przyciskJanka_Checked(object sender, RoutedEventArgs e)
        {
            imie.Text = "Janek";
        }

        private void przyciskBartka_Checked(object sender, RoutedEventArgs e)
        {
            imie.Text = "Bartek";
        }

        private void przyciskArka_Checked(object sender, RoutedEventArgs e)
        {
            imie.Text = "Arek";
        }
    }
}