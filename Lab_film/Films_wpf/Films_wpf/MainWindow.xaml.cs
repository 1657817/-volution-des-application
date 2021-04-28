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

using BLL;

namespace Films_wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Films.ChargerListeFilm();
            DesPays.ChargerListePays();
            dgFilm.ItemsSource = Films.films;
            cboId.ItemsSource = Films.films;
            cboPays.ItemsSource = DesPays.lesPays;
        }

        private void CboId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtTitre.Text = (cboId.SelectedItem as Film).Titre;
            txtPays.Text = (cboId.SelectedItem as Film).Pays;
            txtAnnee.Text = (cboId.SelectedItem as Film).Annee.ToString();
        }
    }
}
