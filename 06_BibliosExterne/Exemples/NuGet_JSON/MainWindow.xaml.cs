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
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;

namespace DataGrid
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserControl ContenuEcran { get; set; }
        public UserControl ContenuEcranCol2 { get; set; }

        public UC_GestionEtud GestEtud = new UC_GestionEtud();
        public UC_Smiley smiley = new UC_Smiley();

        public MainWindow()
        {
            InitializeComponent();

            ContenuEcran = GestEtud;
            Grid.SetRow(ContenuEcran, 0);
            Grid.SetColumn(ContenuEcran, 0);

            gPrincipal.Children.Add(ContenuEcran);

            // Pour le deuxième controle dans l'écran
            ContenuEcranCol2 = smiley;
            Grid.SetRow(ContenuEcranCol2, 0);
            Grid.SetColumn(ContenuEcranCol2, 1);

            gPrincipal.Children.Add(ContenuEcranCol2);
        }

        public static void ReecrireFichier()
        {
            string json = JsonConvert.SerializeObject(UC_GestionEtud.etudiants);

            File.WriteAllText("fEtudiants.json", json);
        }

    }
}
