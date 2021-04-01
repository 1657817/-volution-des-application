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

using MySql.Data.MySqlClient;

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
            string ma = tbMatricule.Text;
            string pr = tbPrenom.Text;
            string no = tbNom.Text;
            string em = tbEmail.Text;

            Etudiants.InsererNouvEtud(ma, pr, no, em);

            MessageBox.Show("Les données ont été inséré avec succès");

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

        private void addStudentsToBD(string ma, string no, string pr, string em)
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO etudiant (Matricule, Prenom, Nom, Email) VALUES ('" + ma + "', '" + pr + "', '" + no + "', '" + em + "')", conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Les données ont été inséré avec succès");
            } catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            } finally
            {
                conn.Close();
            }
        }
    }
}
