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

namespace Talie_kart
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Talia talia1;
        Talia talia2;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            resetujTalie(1);
            resetujTalie(2);
            przetasujTalie(1);
            przetasujTalie(2);
        }

        public void przetasujTalie(int nrTalii) 
        {
            if (nrTalii == 1) 
            {
                talia1tekst.Items.Clear();
                foreach(string nazwa in talia1.podajNazwyKart())
                {
                    talia1tekst.Items.Add(nazwa);
                }
                talia1tytuł.Text = string.Format("Zestaw 1 ({0} kart)", talia1.licznik);
            }else 
            {
                talia2tekst.Items.Clear();
                foreach (string nazwa in talia2.podajNazwyKart()) 
                {
                    talia2tekst.Items.Add(nazwa);
                }
                talia2tytuł.Text = string.Format("Zestaw 2 ({0} kart)", talia2.licznik);
            }
        }
        public void resetujTalie(int nrTalii) 
        {
            if (nrTalii == 1) 
            {
                int ilośćKart = random.Next(1, 11);
                talia1 = new Talia(new Karta[] { });
                for(int i=0; i < ilośćKart; i++)
                {
                    talia1.dodaj(new Karta((Karta.Kolor)random.Next(4), (Karta.Wartość)random.Next(1, 14)));
                }
                talia1.mieszaj();
            }
            else
            {
                talia2 = new Talia();
            }
        }

        private void przywróć1_Click(object sender, RoutedEventArgs e)
        {
            resetujTalie(1);
            przetasujTalie(1);
        }

        private void przywróć2_Click(object sender, RoutedEventArgs e)
        {
            resetujTalie(2);
            przetasujTalie(2);
        }

        private void wymieszaj1_Click(object sender, RoutedEventArgs e)
        {
            talia1.mieszaj();
            przetasujTalie(1);
        }

        private void wymieszaj2_Click(object sender, RoutedEventArgs e)
        {
            talia2.mieszaj();
            przetasujTalie(2);
        }

        private void przenieśDo1_Click(object sender, RoutedEventArgs e)
        {
            if (talia2tekst.SelectedIndex >= 0) 
            {
                if (talia2.licznik > 0) 
                {
                    talia1.dodaj(talia2.wymiana(talia2tekst.SelectedIndex));
                }
            }
            przetasujTalie(1);
            przetasujTalie(2);
        }

        private void przenieśDo2_Click(object sender, RoutedEventArgs e)
        {
            if (talia1tekst.SelectedIndex >= 0) 
            {
                if (talia1.licznik > 0) 
                {
                    talia2.dodaj(talia1.wymiana(talia1tekst.SelectedIndex));
                }
            }
            przetasujTalie(1);
            przetasujTalie(2);
        }
    }
}
