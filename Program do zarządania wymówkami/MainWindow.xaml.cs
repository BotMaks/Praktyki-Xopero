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
using System.IO;
//using Microsoft.Win32;
//using System.Windows.Forms;

namespace Program_do_zarządania_wymówkami
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

        private void folderButton_Click(object sender, RoutedEventArgs e)
        {
            using(System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult wynik = fbd.ShowDialog();
                if (wynik == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) 
                {
                    string ścieżka = fbd.SelectedPath;
                    string[] pliki = Directory.GetFiles(fbd.SelectedPath);

                    
                    MessageBox.Show(string.Format("Podana ścieżka: {0}\nZnalezione pliki: {1}", ścieżka, pliki.Length));
                }
            }

            MessageBox.Show("Podano niepoprawne dane!", "Błąd");
            /*OpenFileDialog wybierzFolder = new OpenFileDialog();
            string ścieżka = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            wybierzFolder.InitialDirectory = @ścieżka;
            wybierzFolder;
            Nullable<bool> wynik = wybierzFolder.ShowDialog();
            if (wynik == true)
            {
                string nazwaPliku = wybierzFolder.FileName;
            }
            else { MessageBox.Show("Nie wybrałeś folderu"); }*/
        }

        private void zapiszButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void otwórzButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void losowaWymówkaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
