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

namespace DataGrid
{
    /// <summary>
    /// Logique d'interaction pour UC_GestionEtud.xaml
    /// </summary>
    public partial class UC_GestionEtud : UserControl
    {

        public static ObservableCollection<Etudiant> etudiants = new ObservableCollection<Etudiant>();

        private UC_AjoutEtud EcranAjoutEtud = new UC_AjoutEtud();

        public UC_GestionEtud()
        {
            InitializeComponent();
            /*etudiants.Add(new Etudiant()
            {
                Matricule = "1657817",
                Prenom = "Jordan",
                Nom = "Côté",
                Email = "test@email.com"
            });
            etudiants.Add(new Etudiant()
            {
                Matricule = "1234567",
                Prenom = "Bob",
                Nom = "Sieger",
                Email = "bob@email.com"
            });
            etudiants.Add(new Etudiant()
            {
                Matricule = "7654321",
                Prenom = "Timmy",
                Nom = "McFace",
                Email = "timmy@email.com"
            });*/

            // Appel de la méthode qui charge le contenu du fichier de données (json)
            Etudiant.ChargerFichier();

            dgEtudiant.ItemsSource = etudiants;
        }

        private void btnAjouterEtudiant_Click(object sender, RoutedEventArgs e)
        {
            /*
            InputDialog inputDialog0 = new InputDialog("Ajout", "Veuillez entrer le matricule : ", "0000000");
            string matriculeAJ = "";
            if (inputDialog0.ShowDialog() == true)
            {
                matriculeAJ = inputDialog0.Reponse;
            }

            InputDialog inputDialog1 = new InputDialog("Ajout", "Veuillez entrer le prénom : ", "John");
            string prenomAJ = "";
            if (inputDialog1.ShowDialog() == true)
            {
                prenomAJ = inputDialog1.Reponse;
            }

            InputDialog inputDialog2 = new InputDialog("Ajout", "Veuillez entrer le nom : ", "Doe");
            string nomAJ = "";
            if (inputDialog2.ShowDialog() == true)
            {
                nomAJ = inputDialog2.Reponse;
            }

            InputDialog inputDialog3 = new InputDialog("Ajout", "Veuillez entrer le email : ", "test@email.com");
            string emailAJ = "";
            if (inputDialog3.ShowDialog() == true)
            {
                emailAJ = inputDialog3.Reponse;
            }

            etudiants.Add(new Etudiant()
            {
                Matricule = matriculeAJ,
                Prenom = prenomAJ,
                Nom = nomAJ,
                Email = emailAJ
            });*/

            MainWindow mw = (MainWindow) Application.Current.MainWindow;

            mw.gPrincipal.Children.Remove(mw.ContenuEcran);

            // Ici on ajoute dans la fenêtre principal le userControl UC_AjoutEtud
            mw.ContenuEcran = EcranAjoutEtud;
            Grid.SetRow(mw.ContenuEcran, 1);
            mw.gPrincipal.Children.Add(mw.ContenuEcran);
        }

        private void btnModifEtudiant_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Matricule : " + (dgEtudiant.SelectedItem as Etudiant).Matricule +
                "\nNom : " + (dgEtudiant.SelectedItem as Etudiant).Nom +
                "\nPrenom : " + (dgEtudiant.SelectedItem as Etudiant).Prenom +
                "\nEmail : " + (dgEtudiant.SelectedItem as Etudiant).Email);

            MainWindow.ReecrireFichier();
        }

        private void btnSuppEtudiant_Click(object sender, RoutedEventArgs e)
        {
            if (dgEtudiant.SelectedItem != null)
            {
                etudiants.Remove((dgEtudiant.SelectedItem as Etudiant));
                MainWindow.ReecrireFichier();
            }
        }

    }
}
