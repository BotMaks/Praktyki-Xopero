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

namespace kaczki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Random random = new Random();
        List<Kaczka> kaczki = new List<Kaczka>()
        {
            new Kaczka() { gatunek = Kaczka.gatunekKaczki.Domowa, rozmiar = 62 },
            new Kaczka() { gatunek = Kaczka.gatunekKaczki.Piżmowa, rozmiar = 70 },
            new Kaczka() { gatunek = Kaczka.gatunekKaczki.Karolinka, rozmiar = 55 },
            new Kaczka() { gatunek = Kaczka.gatunekKaczki.Piżmowa, rozmiar = 62 },
            new Kaczka() { gatunek = Kaczka.gatunekKaczki.Domowa, rozmiar = 70 },
            new Kaczka() { gatunek = Kaczka.gatunekKaczki.Pekin, rozmiar = 64 },
        };
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<5;i++){
                kaczki.Add(new Kaczka((Kaczka.gatunekKaczki)random.Next(5), random.Next(55, 70)));
            }

            mojeKaczki.Text = "";
            foreach (Kaczka kaczka in kaczki) {
                mojeKaczki.Text += string.Format("{0}\n",kaczka.info());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Porównaj porównajRozmiar = new Porównaj();
            porównajRozmiar.kryteria = Porównaj.kryterium.rozmiarPotemGatunek;
            kaczki.Sort(porównajRozmiar);
            mojeKaczki.Text = "";
            foreach (Kaczka kaczka in kaczki)
            {
                mojeKaczki.Text += string.Format("{0}\n", kaczka.info());
            };
        }

    }
}
