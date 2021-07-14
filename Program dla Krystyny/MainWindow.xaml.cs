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

namespace Program_dla_Krystyny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zwykla impreza = new Zwykla();
        Urodziny urodziny = new Urodziny();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void opcjaZdrowa_Click(object sender, RoutedEventArgs e)
        {
            impreza.ustawKosztJedzenia(opcjaZdrowa.IsChecked.Value);
            kosztImprezy.Text = impreza.obliczCałkowityKoszt();
        }

        private void ilośćOsób_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                impreza.ustawIlośćOsób(Convert.ToInt32(ilośćOsób.Text));
                kosztImprezy.Text = impreza.obliczCałkowityKoszt();
            }
            catch(Exception)
            {
                MessageBox.Show("Wprowadź prawidłową ilość osób!");
            }
        }

        private void dekoracje_Click(object sender, RoutedEventArgs e)
        {
            impreza.ustawDekoracje(dekoracje.IsChecked.Value);
            kosztImprezy.Text = impreza.obliczCałkowityKoszt();
        }

        private void ilośćOsóbUrodziny_TextChanged(object sender, TextChangedEventArgs e)
        {
            try {
                urodziny.ustawIlośćOsób(Convert.ToInt32(ilośćOsóbUrodziny.Text));
                kosztUrodziny.Text = urodziny.obliczCałkowityKoszt();
            }
            catch (Exception) {
                MessageBox.Show("Wprowadź prawidłową ilość osób!");
            }
        }

        private void dekoracjeUrodziny_Click(object sender, RoutedEventArgs e)
        {
            urodziny.ustawDekoracje(dekoracjeUrodziny.IsChecked.Value);
            kosztUrodziny.Text = urodziny.obliczCałkowityKoszt();
        }

        private void napis_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool i = urodziny.zmieńNapis(napis.Text);
            if (i==false) { MessageBox.Show("Za długi napis!"); }
            kosztUrodziny.Text = urodziny.obliczCałkowityKoszt();
        }
    }
}
