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

namespace Ex_LiveCharts.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SeriesCollection SC { get; set; }
        public string[] Labels { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            SC = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Chiffre d'affaire",
                    Values = new ChartValues<double>{14826, 21345, 76243, 59991, 100200 }
                }
            };

            SC[0].Values.Add((double)100254);

            Labels = new[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin" };

            SC.Add(
                new LineSeries
                {
                    Title = "Marge brute",
                    Values = new ChartValues<double> { 6152.79, 8973.3, 12075.52, 22022.88, 36169.8 }
                });
            SC[1].Values.Add((double)46615.57);

            DataContext = this;
        }
    }
}
