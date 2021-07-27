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

namespace Wyprawa
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Gra gra;
        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            gra = new Gra(new System.Drawing.Rectangle(78, 57, 420, 155));
            gra.nowyPoziom(rand);
            aktualizujPostacie();
        }



        private void aktualizujPostacie()
        {
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key klawisz = e.Key;
        }

        private void mieczItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór miecza z ekwipunku
        }
        private void łukItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór łuku z ekwipunku
        }
        private void topórItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór toporu z ekwipunku
        }
        private void małaPotkaItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór małej potki z ekwipunku
        }
        private void dużaPotkaItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //wybór dużej potki z ekwipunku
        }
    }
}
