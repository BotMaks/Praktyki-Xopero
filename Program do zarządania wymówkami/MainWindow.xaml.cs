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


namespace Program_do_zarządania_wymówkami
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ścieżka;
        string[] pliki;
        string schowekNaTytuł;
        Wymówka aktualnaWymówka = new Wymówka();
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            schowekNaTytuł = this.Title;
        }
        

        private void folderButton_Click(object sender, RoutedEventArgs e)
        {
            using(System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                fbd.Description = "Wybierz folder z wymówkami";
                System.Windows.Forms.DialogResult wynik = fbd.ShowDialog();
                if (wynik == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) 
                {
                    ścieżka = fbd.SelectedPath;
                    pliki = Directory.GetFiles(fbd.SelectedPath);

                    aktualnaWymówka = new Wymówka(ścieżka);

                    zapiszButton.IsEnabled = true;
                    otwórzButton.IsEnabled = true;
                    losowaWymówkaButton.IsEnabled = true;
                    wymówkaTextBox.IsEnabled = true;
                    wynikiTextBox.IsEnabled = true;
                    ostatnioUżyteDatePicker.IsEnabled = true;
                    return;
                }
            }

            MessageBox.Show("Podano niepoprawne dane!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void otwórzButton_Click(object sender, RoutedEventArgs e)
        {
            if (!sprawdźZmiany())
            {
                using (System.Windows.Forms.OpenFileDialog otwórz = new System.Windows.Forms.OpenFileDialog())
                {
                    otwórz.InitialDirectory = ścieżka;
                    otwórz.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                    otwórz.Title = "Wybierz plik z wymówką";
                    System.Windows.Forms.DialogResult wynik = otwórz.ShowDialog();
                    if (wynik == System.Windows.Forms.DialogResult.OK)
                    {
                        aktualnaWymówka.otwórzWymówkę(otwórz.FileName, wymówkaTextBox, wynikiTextBox, ostatnioUżyteDatePicker);
                        aktualnaWymówka.podajDatęUtworzeniaPliku(dataPlikuLabel, otwórz.FileName);
                    }
                }
            }
        }
        private void losowaWymówkaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!sprawdźZmiany())
            {
                aktualnaWymówka = new Wymówka(rand, ścieżka);
                aktualnaWymówka.podajDatęUtworzeniaPliku(dataPlikuLabel, aktualnaWymówka.nazwa);
                aktualnaWymówka.otwórzWymówkę(aktualnaWymówka.nazwa, wymówkaTextBox, wynikiTextBox, ostatnioUżyteDatePicker);
            }
        }

        private void zapiszButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(wymówkaTextBox.Text) || String.IsNullOrEmpty(wynikiTextBox.Text) || (ostatnioUżyteDatePicker.SelectedDate == null))
            {
                MessageBox.Show("Podaj wszystkie dane!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            using(System.Windows.Forms.SaveFileDialog zapisz = new System.Windows.Forms.SaveFileDialog())
            {
                zapisz.InitialDirectory = ścieżka;
                zapisz.Title = "Wybierz plik w którym zapiszesz swoją wymówkę";
                zapisz.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                System.Windows.Forms.DialogResult wynik = zapisz.ShowDialog();
                if (wynik == System.Windows.Forms.DialogResult.OK)
                {
                    aktualnaWymówka.zapiszWymówkę(zapisz.FileName, wymówkaTextBox, wynikiTextBox, ostatnioUżyteDatePicker);
                    aktualnaWymówka.podajDatęUtworzeniaPliku(dataPlikuLabel, zapisz.FileName);
                }
            }
        }
        private bool sprawdźZmiany()
        {
            if (aktualnaWymówka.nazwa != wymówkaTextBox.Text || aktualnaWymówka.wynik != wynikiTextBox.Text || aktualnaWymówka.ostatnioUżyta != ostatnioUżyteDatePicker.SelectedDate)
            {
                MessageBoxResult odpowiedź = MessageBox.Show("Bierząca wymówka nie zostałą zapisana!\nCzy kontynuować?", "Ostrzeżenie", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (odpowiedź == MessageBoxResult.No)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
