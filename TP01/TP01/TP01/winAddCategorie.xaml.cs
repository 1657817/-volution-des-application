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
using System.Windows.Shapes;

namespace TP01
{
    /// <summary>
    /// Logique d'interaction pour winAddCategorie.xaml
    /// </summary>
    public partial class winAddCategorie : Window
    {
        public winAddCategorie()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode pour ajouter une nouvelle catégorie.
        /// </summary>
        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txbxCatAjouter.Text)) // On vérifie que le textbox correspondant au nom de la nouvelle catégorie n'est pas vide.
            {
                if (!CategorieJeu.ObtenirListe().Contains(new CategorieJeu(txbxCatAjouter.Text))) // Si elle ne l'est pas, on vérifie que la nouvelle catégorie proposé n'existe pas déjà.
                {
                    // Si elle n'existe pas déjà, on l'ajoute à la liste de catégories.
                    CategorieJeu.ObtenirListe().Add(new CategorieJeu(txbxCatAjouter.Text));
                    MainWindow.Sauvegarder(); // Et on sauvegarde les modification.
                    MessageBox.Show("Catégorie ajouter", "", MessageBoxButton.OK);
                    txbxCatAjouter.Clear();
                }
                else
                    MessageBox.Show("La catégories " + txbxCatAjouter.Text + " existe déjà.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("La nom de la catégorie ne peut pas être vide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
