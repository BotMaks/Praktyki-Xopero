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

namespace Ul
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Królowa królowa = new Królowa();
        bool prawda;
        public MainWindow()
        {
            InitializeComponent();
            Robotnica[] robotnice = new Robotnica[4]; 
            robotnice[0] = new Robotnica(0.1, new String[] {"Zbieranie nektaru", "Wytwarzanie miodu"});
            robotnice[1] = new Robotnica(0.1, new String[] {"Pielęgnacja jaj", "Nauczanie pszczółek"});
            robotnice[2] = new Robotnica(0.1, new String[] { "Utrzymywanie ula", "Patrol z żądłami" });
            robotnice[3] = new Robotnica(0.1, new String[] {"Zbieranie nektaru", "Wytwarzanie miodu", "Pielęgnacja jaj", "Nauczanie pszczółek", "Utrzymywanie ula", "Patrol z żądłami"});
            królowa = new Królowa(0.18, robotnice);
        }

        private void przypiszPracę_Click(object sender, RoutedEventArgs e)
        {
            try {

                prawda = królowa.przypiszPracę(nazwaPracy.Text, Convert.ToInt32(ileZmian.Text));
                if (prawda == false)
                {
                    MessageBox.Show("Żadna wolna pszczoła nie może wykonać tej pracy!");
                }
                else { MessageBox.Show("Praca została przydzielona!"); }
            }
            catch(Exception)
            {
                MessageBox.Show("Brak wystarczających danych!");
            }
        }

        private void następnaZmiana_Click(object sender, RoutedEventArgs e)
        {
            raportZmiany.Text = królowa.pracuj();
        }
    }
}
