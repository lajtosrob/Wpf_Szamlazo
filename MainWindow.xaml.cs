using System;
using System.Collections.Generic;
using System.IO;
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

namespace Wpf_Szamlazo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Tetel> tetelek = new List<Tetel>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            Tetel ujTetel = new Tetel(
                txtNev.Text,
                int.Parse(txtAr.Text),
                cbEgyseg.Text,
                Convert.ToDouble(sliMennyiseg.Value)
                ) ;

            tetelek.Add( ujTetel );

            dgTetelek.ItemsSource = tetelek ;
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(".\\tetelek.csv");

            foreach (var item in tetelek)
            {
                sw.WriteLine($"{item.TermekNev};{item.EgysegAr};{item.Egyseg};{item.Mennyiseg}");
            }

            sw.Close();
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("tetelek.csv");

            tetelek.Clear();
            dgTetelek.ItemsSource = tetelek;

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");

                Tetel adatsor = new Tetel(
                    line[0],
                    int.Parse(line[1]),
                    line[2],
                    Convert.ToDouble(line[3])
                    );

                tetelek.Add( adatsor );
            }

            sr.Close();

            dgTetelek.ItemsSource = tetelek;

        }

        private void cbEgyseg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
