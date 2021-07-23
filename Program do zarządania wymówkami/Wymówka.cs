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
        public string ostatnioUżyta { get; set; }

        public Wymówka() { ścieżka = ""; }
    
        public Wymówka(string ścieżka) 
        {
            this.ścieżka = ścieżka;
            nazwa = "";
            wynik = "";
            ostatnioUżyta = "";
        }

        public Wymówka(Random rand, string ścieżka) 
        {
            this.ścieżka = ścieżka;
            string[] pliki = Directory.GetFiles(ścieżka, "*.txt");
            this.nazwa = pliki[rand.Next(pliki.Length)];
            
        }

        public void zapiszWymówkę(string nazwa, TextBox wymówka, TextBox opis, TextBox data) 
        {
            using (StreamWriter zapisz = new StreamWriter(nazwa)) 
            {
                zapisz.WriteLine(wymówka.Text);
                zapisz.WriteLine(opis.Text);
                zapisz.WriteLine(data.Text);
            }
            this.nazwa = wymówka.Text;
            this.wynik = opis.Text;
            this.ostatnioUżyta = data.Text;
                
        }

        public void otwórzWymówkę(string nazwa, TextBox wymówka, TextBox opis, TextBox data) 
        {
            using (StreamReader czytaj = new StreamReader(nazwa)) 
            {
                while (!czytaj.EndOfStream) {
                    wymówka.Text = czytaj.ReadLine();
                    opis.Text = czytaj.ReadLine();
                    data.Text = czytaj.ReadLine();
                }
            }
            this.nazwa = wymówka.Text;
            this.wynik = opis.Text;
            this.ostatnioUżyta = data.Text;
        }
    }
}
