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
        Impreza impreza = new Impreza();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void kosztImprezy_Loaded(object sender, RoutedEventArgs e)
        {

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
                MessageBox.Show("Wprowadź poprawne dane!");
            }
        }

        private void dekoracje_Click(object sender, RoutedEventArgs e)
        {
            impreza.ustawDekoracje(dekoracje.IsChecked.Value);
            kosztImprezy.Text = impreza.obliczCałkowityKoszt();
        }
    }
}
