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

namespace ObstawianieWyscigow
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Klient janek = new Klient("Janek", 50, przyciskJanka, tekstJanka);
            Klient bartek= new Klient("Bartek", 75, przyciskBartka, tekstBartka);
            Klient arek = new Klient("Arek", 45, przyciskArka, tekstArka);
            janek.aktualizujDane();
            bartek.aktualizujDane();
            arek.aktualizujDane();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
