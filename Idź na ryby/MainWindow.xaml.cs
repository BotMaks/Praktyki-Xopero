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

namespace Idź_na_ryby
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
        private Gra gra;

        private void start_Click(object sender, RoutedEventArgs e)
        {
            rozpocznijGrę();
        }
        private void poproś_Click(object sender, RoutedEventArgs e)
        {
            przebiegGry.Text = "";
            if(rękaGracza.SelectedIndex < 0) 
            {
                MessageBox.Show("Wybierz kartę!");
                return;
            }
            if (gra.zagrajRundę(rękaGracza.SelectedIndex))
            {
                przebiegGry.Text += "Zwycięzcą jest ..." + gra.podajZwycięzce();
                pary.Text = gra.wypiszPary();
                poproś.IsEnabled = false;
            }
            else 
            {
                aktualizujPrzebieg();
            }
        }

        private void rozpocznijGrę() 
        {
            if (String.IsNullOrEmpty(imie.Text)) {
                MessageBox.Show("Wpisz swoje imie!\nNie można jeszcze rozpocząć gry.");
                return;
            }
            gra = new Gra(imie.Text, new List<string> { "Grześ", "-" }, przebiegGry);

            Visibility widoczny = Visibility.Visible;
            przebiegGryInfo.Visibility = widoczny;
            przebiegGry.Visibility = widoczny;
            rękaGraczaInfo.Visibility = widoczny;
            rękaGracza.Visibility = widoczny;
            poproś.Visibility = widoczny;
            paryInfo.Visibility = widoczny;
            pary.Visibility = widoczny;
            start.Visibility = Visibility.Collapsed;
            imie.IsEnabled = false;

            aktualizujPrzebieg();
        }
         private void aktualizujPrzebieg() 
         {
            rękaGracza.Items.Clear();
            foreach (String nazwaKarty in gra.podajNazwęKartyGracza()) 
            {
                rękaGracza.Items.Add(nazwaKarty);
            }
            pary.Text = gra.wypiszPary();
            przebiegGry.Text += gra.opiszRękęGracza();
         }

    }
}
