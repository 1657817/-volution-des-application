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

        public static ObservableCollection<Etudiant> etudiants = new ObservableCollection<Etudiant>();

        private UC_AjoutEtud EcranAjoutEtud = new UC_AjoutEtud();

        public UC_GestionEtud()
        {
            InitializeComponent();

            // Appel de la méthode qui charge le contenu du fichier de données (json)
            //Etudiant.ChargerFichier();

            dgEtudiant.ItemsSource = etudiants;

            DataContext = this;
            ConnecterBD();
        }

        private void ConnecterBD()
        {
            MessageBox.Show("Connecxion à la base de donnée");
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM etudiant", conn); // Préparation de la requète SQL

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();     // using System.Data

                adp.Fill(ds, "etudiant");

                var dt = ds.Tables["etudiant"];

                var etudiantsList = new ObservableCollection<Etudiant>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var etu = new Etudiant
                    {
                        Matricule = dt.Rows[i]["Matricule"].ToString(),
                        Nom = dt.Rows[i]["Nom"].ToString(),
                        Prenom = dt.Rows[i]["Prenom"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString()
                    };

                    etudiantsList.Add(etu);
                }
                etudiants = etudiantsList;
                dgEtudiant.ItemsSource = etudiants;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
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
            /*MessageBox.Show(
                "Matricule : " + (dgEtudiant.SelectedItem as Etudiant).Matricule +
                "\nNom : " + (dgEtudiant.SelectedItem as Etudiant).Nom +
                "\nPrenom : " + (dgEtudiant.SelectedItem as Etudiant).Prenom +
                "\nEmail : " + (dgEtudiant.SelectedItem as Etudiant).Email);*/

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
                MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("UPDATE etudiant SET Matricule = '" + valMat + "',  Nom ='" + valNo + "' , Prenom ='" + valPre + "', Email ='" + valEma + "' WHERE Matricule = " + valMat, conn);

                    MySqlDataReader myReader;

                    myReader = cmd.ExecuteReader();

                    MessageBox.Show("Les données ont été modifié avec succès");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }

            //MainWindow.ReecrireFichier();
        }

        private void btnSuppEtudiant_Click(object sender, RoutedEventArgs e)
        {
            if (dgEtudiant.SelectedItem != null)
            {
                string valMat = (dgEtudiant.SelectedItem as Etudiant).Matricule;
                MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

                try
                {
                    conn.Open();
                    string cmdString = "DELETE FROM etudiant WHERE matricule = '" + valMat + "'";

                    MySqlCommand cmd = new MySqlCommand(cmdString, conn);

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();

                    // Supression de l'étudiant de l'observable collection
                    etudiants.Remove((dgEtudiant.SelectedItem as Etudiant));

                    MessageBox.Show("Étudiant supprimé de la collection observable");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }

            }
        }

    }
}
