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
using System.Threading;

namespace Dom
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ruchy;

        Miejsce aktualneMiejsce;

        PokójZDrzwiami salon;
        PokójZKryjówką jadalnia;
        PokójZDrzwiami kuchnia;
        Pokój schody;
        PokójZKryjówką korytarz;
        PokójZKryjówką łazienka;
        PokójZKryjówką sypialnia1;
        PokójZKryjówką sypialnia2;

        OtoczenieZDrzwiami przódPodwórka;
        OtoczenieZDrzwiami tyłPodwórka;
        OtoczenieZKryjówką ogródek;
        OtoczenieZKryjówką podjazd;

        Oponent oponent;

        public MainWindow()
        {
            InitializeComponent();
            stwórzObiekty();
            oponent = new Oponent(przódPodwórka);
            resetGry(false);
            
        }

        private void stwórzObiekty() {
            salon = new PokójZDrzwiami("Salon", "antyczny dywan", "w szafie ściennej" , "dębowe dzwi z mosiężną klamką");
            jadalnia = new PokójZKryjówką("Jadalnia", "kryszkałowy żyrandol", "w wysokiej szafce");
            kuchnia = new PokójZDrzwiami("Kuchnia", "nierdzewne stalowe sztućce", "w szafce", "rozsuwane dzwi");
            schody = new Pokój("Schody", "drewniana poręcz");
            korytarz = new PokójZKryjówką("Korytarz na górze", "Obrazek z psem", "w szafie ściennej");
            łazienka = new PokójZKryjówką("Łacienka", "umywalka i toaleta", "pod prysznicem");
            sypialnia1 = new PokójZKryjówką("Duża sypialnia", "duże łóżko", "pod łóżkiem");
            sypialnia2 = new PokójZKryjówką("Małą sypialnia", "małe łóżko", "pod łóżkiem");
            przódPodwórka = new OtoczenieZDrzwiami("Podwórko przed domem", false, "dębowe drzwi z mosiężną klamką");
            tyłPodwórka = new OtoczenieZDrzwiami("Podwórko za domem", true, "rozsuwane drzwi");
            ogródek = new OtoczenieZKryjówką("Ogródek", false, "w szopie");
            podjazd = new OtoczenieZKryjówką("Podjazd", true, "w garażu");

            jadalnia.wyjścia = new Miejsce[] { salon, kuchnia };
            salon.wyjścia = new Miejsce[] { jadalnia, schody };
            kuchnia.wyjścia = new Miejsce[] { jadalnia };
            schody.wyjścia = new Miejsce[] { salon, korytarz };
            korytarz.wyjścia = new Miejsce[] { schody, łazienka, sypialnia1, sypialnia2 };
            łazienka.wyjścia = new Miejsce[] { korytarz };
            sypialnia1.wyjścia = new Miejsce[] { korytarz };
            sypialnia2.wyjścia = new Miejsce[] { korytarz };

            przódPodwórka.wyjścia = new Miejsce[] { tyłPodwórka, ogródek, podjazd };
            tyłPodwórka.wyjścia = new Miejsce[] { przódPodwórka, ogródek, podjazd };
            ogródek.wyjścia = new Miejsce[] { przódPodwórka, tyłPodwórka };
            podjazd.wyjścia = new Miejsce[] { przódPodwórka, tyłPodwórka };

            salon.miejsceDrzwi = przódPodwórka;
            przódPodwórka.miejsceDrzwi = salon;

            kuchnia.miejsceDrzwi = tyłPodwórka;
            tyłPodwórka.miejsceDrzwi = kuchnia;
        }

        private void idźDoNowegoMiejsca(Miejsce noweMiejsce) {

            ruchy++;
            aktualneMiejsce = noweMiejsce;
            przerysujFormularz();
        }

        private void przerysujFormularz()
        {
            wyjścia.Items.Clear();
            foreach (Miejsce wyjście in aktualneMiejsce.wyjścia)
            {
                wyjścia.Items.Add(wyjście.nazwa);
            }
            wyjścia.SelectedIndex = 0;

            opis.Text = string.Format("(Ruch numer: {1}\n{0})", aktualneMiejsce.pobierzOpis, ruchy);

            if(aktualneMiejsce is IKryjówka)
            {
                IKryjówka kryjówka = aktualneMiejsce as IKryjówka;
                sprawdź.Content = string.Format("Sprawdź {0}", kryjówka.nazwaKryjówki);
                sprawdź.Visibility = Visibility.Visible;
            }
            else
            {
                sprawdź.Visibility = Visibility.Collapsed;
            }

            if (aktualneMiejsce is IMaZewenętrzneDrzwi)
            {
                idźPrzezDrzwi.Visibility = Visibility.Visible;
            }
            else
            {
                idźPrzezDrzwi.Visibility = Visibility.Collapsed;
            }
        }

        private void resetGry(bool wyświetlWiadomość) {
            if (wyświetlWiadomość)
            {
                MessageBox.Show(string.Format("Odnalazłeś mnie w {0} ruchach!", ruchy));
                IKryjówka znaleziony = aktualneMiejsce as IKryjówka;
                opis.Text = string.Format("Znalazłeś oponenta w {0} ruchach!\nUkrywał się w {1}.", ruchy, znaleziony.nazwaKryjówki);
            }
            ruchy = 0;
            kryjSię.Visibility = Visibility.Visible;
            idźTutaj.Visibility = Visibility.Collapsed;
            sprawdź.Visibility = Visibility.Collapsed;
            idźPrzezDrzwi.Visibility = Visibility.Collapsed;
            wyjścia.Visibility = Visibility.Collapsed;
        }

        private void idźTutaj_Click(object sender, RoutedEventArgs e)
        {
            idźDoNowegoMiejsca(aktualneMiejsce.wyjścia[wyjścia.SelectedIndex]);
        }

        private void idźPrzezDrzwi_Click(object sender, RoutedEventArgs e)
        {
            IMaZewenętrzneDrzwi maZewenętrzneDrzwi = aktualneMiejsce as IMaZewenętrzneDrzwi;
            idźDoNowegoMiejsca(maZewenętrzneDrzwi.miejsceDrzwi);
        }

        private void sprawdź_Click(object sender, RoutedEventArgs e)
        {
            ruchy++;
            if (oponent.sprawdź(aktualneMiejsce)) {
                resetGry(true);
            }
            else
            {
                przerysujFormularz();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kryjSię_Click(object sender, RoutedEventArgs e)
        {
            kryjSię.Visibility = Visibility.Collapsed;

            for (int i=1; i<=10; i++) {
                oponent.poruszSię();
                opis.Text = i + "...";
                Thread.Sleep(1000);
            }
            opis.Text = "Gotowy czy nie - nadchodzę!";
            Thread.Sleep(1000);
            idźTutaj.Visibility = Visibility.Visible;
            wyjścia.Visibility = Visibility.Visible;
            idźDoNowegoMiejsca(salon);
        }
    }
}
