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

namespace DataGrid
{
    /// <summary>
    /// Logique d'interaction pour UC_AjoutEtud.xaml
    /// </summary>
    public partial class UC_AjoutEtud : UserControl
    {
        public UC_AjoutEtud()
        {
            InitializeComponent();
        }

        private void btnValider_click(object sender, RoutedEventArgs e)
        {
            // Ajout du nouveau étudiant dans la liste des étudiants
            UC_GestionEtud.etudiants.Add(new Etudiant
            {
                Matricule = tbMatricule.Text,
                Prenom = tbPrenom.Text,
                Nom = tbNom.Text,
                Email = tbEmail.Text
            });
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.gPrincipal.Children.Remove(mw.ContenuEcran);

            mw.ContenuEcran = mw.GestEtud; // On remplace dans l'écran principal les user control à afficher
            Grid.SetRow(mw.ContenuEcran, 1);
            mw.gPrincipal.Children.Add(mw.ContenuEcran);

            tbMatricule.Text = "";
            tbPrenom.Text = "";
            tbNom.Text = "";
            tbEmail.Text = "";
        }
    }
}
