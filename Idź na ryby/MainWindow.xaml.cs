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

        private void start_Click(object sender, RoutedEventArgs e)
        {
            rozpocznijGrę();
        }

        private void rozpocznijGrę() 
        {
            if (String.IsNullOrEmpty(imie.Text)) {
                MessageBox.Show("Wpisz swoje imie!\nNie można jeszcze rozpocząć gry.");
                return;
            }

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
        }

        private void poproś_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
