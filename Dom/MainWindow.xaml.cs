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

namespace Dom
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Miejsce aktualneMiejsce;

        PokójZDrzwiami salon;
        Pokój jadalnia;
        PokójZDrzwiami kuchnia;

        OtoczenieZDrzwiami przódPodwórka;
        OtoczenieZDrzwiami tyłPodwórka;
        Otoczenie ogródek;

        public MainWindow()
        {
            InitializeComponent();
            stwórzObiekty();
            idźDoNowegoMiejsca(salon);
        }

        private void stwórzObiekty() {
            salon = new PokójZDrzwiami("Salon", "antyczny dywan", "dębowe dzwi z mosiężną klamką");
            jadalnia = new Pokój("Jadalnia", "kryszkałowy żyrandol");
            kuchnia = new PokójZDrzwiami("Kuchnia", "nierdzewne stalowe sztućce", "rozsuwane dzwi");

            przódPodwórka = new OtoczenieZDrzwiami("Podwórko przed domem", false, "dębowe drzwi z mosiężną klamką");
            tyłPodwórka = new OtoczenieZDrzwiami("Podwórko za domem", true, "rozsuwane drzwi");
            ogródek = new Otoczenie("Ogródek", false);

            jadalnia.wyjścia = new Miejsce[] { salon, kuchnia };
            salon.wyjścia = new Miejsce[] { jadalnia };
            kuchnia.wyjścia = new Miejsce[] { jadalnia };
            
            przódPodwórka.wyjścia = new Miejsce[] { tyłPodwórka, ogródek };
            tyłPodwórka.wyjścia = new Miejsce[] { przódPodwórka, ogródek };
            ogródek.wyjścia = new Miejsce[] { przódPodwórka, tyłPodwórka };

            salon.miejsceDrzwi = przódPodwórka;
            przódPodwórka.miejsceDrzwi = salon;

            kuchnia.miejsceDrzwi = tyłPodwórka;
            tyłPodwórka.miejsceDrzwi = kuchnia;
        }

        private void idźDoNowegoMiejsca(Miejsce noweMiejsce) {
            aktualneMiejsce = noweMiejsce;

            wyjścia.Items.Clear();
            for(int i=0; i<aktualneMiejsce.wyjścia.Length; i++)
            {
                wyjścia.Items.Add(aktualneMiejsce.wyjścia[i].nazwa);
            }
            wyjścia.SelectedIndex = 0;

            opis.Text = aktualneMiejsce.pobierzOpis;

            if(aktualneMiejsce is IMaZewenętrzneDrzwi)
            {
                idźPrzezDrzwi.Visibility = Visibility.Visible;
            }
            else
            {
                idźPrzezDrzwi.Visibility = Visibility.Collapsed;
            }


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
    }
}
