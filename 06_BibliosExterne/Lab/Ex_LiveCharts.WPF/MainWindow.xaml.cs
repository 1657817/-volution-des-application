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
// Pour créer des graphiques
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;

namespace Ex_LiveCharts.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static ObservableCollection<Bilan> bilan = new ObservableCollection<Bilan>();

        public SeriesCollection SC { get; set; }
        public string[] Labels { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Bilan.ChargerFichier();

            SC = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Chiffre d'affaire",
                    Values = new ChartValues<double>{}
                }
            };

            Labels = new[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin" };

            SC.Add(
                new LineSeries
                {
                    Title = "Marge brute",
                    Values = new ChartValues<double> {}
                });

            foreach (Bilan unBilan in bilan)
            {
                SC[0].Values.Add((double)unBilan.ChiffreAffaire);
                SC[1].Values.Add((double)unBilan.MargeBrute);
            }

            DataContext = this;
        }
    }
}
