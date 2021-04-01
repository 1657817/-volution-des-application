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
using BLL;

// Manipulation d'une base de données MySQL
using System.Data;
using MySql.Data.MySqlClient;

namespace DataGrid
{
    /// <summary>
    /// Logique d'interaction pour UC_GestionEtud.xaml
    /// </summary>
    public partial class UC_GestionEtud : UserControl
    {

        private UC_AjoutEtud EcranAjoutEtud = new UC_AjoutEtud();

        public UC_GestionEtud()
        {
            InitializeComponent();

            DataContext = this;
            Etudiants.ChargerListeEtudiant();
            dgEtudiant.ItemsSource = Etudiants.etudiants;
        }

        private void btnAjouterEtudiant_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mw = (MainWindow)Application.Current.MainWindow;

            mw.gPrincipal.Children.Remove(mw.ContenuEcran);

            // Ici on ajoute dans la fenêtre principal le userControl UC_AjoutEtud
            mw.ContenuEcran = EcranAjoutEtud;
            Grid.SetRow(mw.ContenuEcran, 1);
            mw.gPrincipal.Children.Add(mw.ContenuEcran);
        }

        public string mat, no, pre, ema;

        private void LigneDG_dblClick(object sender, MouseButtonEventArgs e)
        {
            mat = (dgEtudiant.SelectedItem as Etudiant).Matricule;
            no = (dgEtudiant.SelectedItem as Etudiant).Nom;
            pre = (dgEtudiant.SelectedItem as Etudiant).Prenom;
            ema = (dgEtudiant.SelectedItem as Etudiant).Email;
        }

        private void btnModifEtudiant_Click(object sender, RoutedEventArgs e)
        {
            string valMat = (dgEtudiant.SelectedItem as Etudiant).Matricule;
            string valNo = (dgEtudiant.SelectedItem as Etudiant).Nom;
            string valPre = (dgEtudiant.SelectedItem as Etudiant).Prenom;
            string valEma = (dgEtudiant.SelectedItem as Etudiant).Email;

            if (mat != valMat)
            {
                MessageBox.Show("Il n'est pas permit de changer le matricule");

                (dgEtudiant.SelectedItem as Etudiant).Matricule = mat;
                (dgEtudiant.SelectedItem as Etudiant).Nom = no;
                (dgEtudiant.SelectedItem as Etudiant).Prenom = pre;
                (dgEtudiant.SelectedItem as Etudiant).Email = ema;
            }
            else
            {
                Etudiants.ModifierEtudiant(valMat, valNo, valPre, valEma);
                MessageBox.Show("Données ajouter avec succès");
            }
        }

        private void btnSuppEtudiant_Click(object sender, RoutedEventArgs e)
        {
            if (dgEtudiant.SelectedItem != null)
            {
                string valMat = (dgEtudiant.SelectedItem as Etudiant).Matricule;
                Etudiants.SupprimerEtudiant(valMat);
                MessageBox.Show("Etudiant supprimé");
            }
        }

    }
}
