using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace Program_do_zarządania_wymówkami
{
    class Wymówka
    {
        public string nazwa { get; set; }
        public string wynik { get; set; }
        public string ścieżka { get; set; }
        public DateTime? ostatnioUżyta { get; set; }

        public Wymówka() { ścieżka = ""; }
    
        public Wymówka(string ścieżka) 
        {
            this.ścieżka = ścieżka;
            nazwa = "";
            wynik = "";
            ostatnioUżyta = null;
        }

        public Wymówka(Random rand, string ścieżka) 
        {
            this.ścieżka = ścieżka;
            string[] pliki = Directory.GetFiles(ścieżka, "*.txt");
            this.nazwa = pliki[rand.Next(pliki.Length)];
            
        }

        public void zapiszWymówkę(string nazwa, TextBox wymówka, TextBox opis, DatePicker data) 
        {
            using (StreamWriter zapisz = new StreamWriter(nazwa)) 
            {
                zapisz.WriteLine(wymówka.Text);
                zapisz.WriteLine(opis.Text);
                zapisz.WriteLine(data.SelectedDate);
            }
            this.nazwa = wymówka.Text;
            this.wynik = opis.Text;
            this.ostatnioUżyta = Convert.ToDateTime(data.SelectedDate);
                
        }

        public void otwórzWymówkę(string nazwa, TextBox wymówka, TextBox opis, DatePicker data) 
        {
            using (StreamReader czytaj = new StreamReader(nazwa)) 
            {
                while (!czytaj.EndOfStream) {
                    wymówka.Text = czytaj.ReadLine();
                    opis.Text = czytaj.ReadLine();
                    data.SelectedDate = Convert.ToDateTime(czytaj.ReadLine());
                }
            }
            this.nazwa = wymówka.Text;
            this.wynik = opis.Text;
            this.ostatnioUżyta = Convert.ToDateTime(data.SelectedDate);
        }
        public void podajDatęUtworzeniaPliku(Label dataPlikuLabel, string nazwaPliku)
        {
            
            string stworzenie = Convert.ToString(File.GetCreationTime(nazwaPliku));
            dataPlikuLabel.Content = stworzenie;
        }
    }
}
