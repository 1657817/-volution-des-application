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
    /// Logique d'interaction pour winCategorie.xaml
    /// </summary>
    public partial class winCategorie : Window
    {
        public winCategorie()
        {
            InitializeComponent();
            ACategorieSel(false);
            lsbCategorie.ItemsSource = CategorieJeu.ObtenirListe();
        }

        /// <summary>
        /// Méthode qui s'active au changement de catégorie sélectionné et change l'affichage est les contrôle en fonction
        /// de la catégorie sélectionner (ou manque de catégorie sélectionné).
        /// </summary>
        private void LsbCategorie_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (lsbCategorie.SelectedItem != null) // On entre ici si une catégorie est sélectionné.
            {
                int nbApparition = 0;
                foreach (JeuSociete jeu in JeuSociete.jeux)
                {
                    if (jeu.EstDeCategorie((lsbCategorie.SelectedItem as CategorieJeu)))
                    { // On parcours tous les jeux de la liste de jeu et pour chacun qui contient cette catégorie, on incrémente le compteur d'apparition.
                        nbApparition++;
                    }
                }
                txbxCatName.Text = (lsbCategorie.SelectedItem as CategorieJeu).Nom; // On affiche le nom de la catégorie dans le textbox de modification.
                txbNbUtilisation.Text = nbApparition.ToString(); // On affiche le nombre de fois que la catégorie est utilisé.
                ACategorieSel(true); // Et on affiche l'affichage pour la catégorie sélectionné et active les boutons.
            }
            else
            { // Ici si aucune catégorie sélectionné.
                ACategorieSel(false); // On cache l'affichage pour la catégorie sélectionné et désactive les boutons.
                // Et remet l'affichage de catégorie sélectionné à zéro.
                txbxCatName.Text = "";
                txbNbUtilisation.Text = "0";
            }
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Méthode qui permet de supprimer une catégorie.
        /// </summary>
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            CategorieJeu catASupp = (lsbCategorie.SelectedItem as CategorieJeu); // On enregistre la catégorie à supprimer.
            if (catASupp.CanBeSafelyDeleted()) // On vérifie si la catégorie peut être supprimer de facon sécuritaire (que ce n'est pas la dernière catégorie d'un jeu).
            {
                foreach (JeuSociete jeu in JeuSociete.jeux)
                {
                    if (jeu.EstDeCategorie(catASupp)) // On parcours tous les jeux et pour ceux qui contiennent la catégories, on l'enlève.
                        jeu.RetirerCategorie(catASupp);
                }
                CategorieJeu.ObtenirListe().Remove(catASupp); // Finalement on l'enlève de la liste de catégories.
                MainWindow.Sauvegarder(); // Et on sauvegarde les modifications.
            }
            else
                MessageBox.Show("Impossible de supprimer la catégorie", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Méthode qui affiche la fenêtre d'ajout de catégories.
        /// </summary>
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            winAddCategorie modalAddCategorie = new winAddCategorie();
            modalAddCategorie.ShowDialog();
        }

        /// <summary>
        /// Méthode qui dépendemment de si une catégorie est sélectionné, affiche le groupbox de détails ou le cache et
        /// désactive ou active les bouton lier à la modification et suppression de catégorie
        /// </summary>
        /// <param name="estSel"></param>
        private void ACategorieSel(bool estSel)
        {
            if (estSel)
            { // Si une catégorie est sélectionner
                // On affiche l'affichage d'info des catégories et on cache l'alerte d'aucune catégorie sélectionné.
                gpbCatNotSel.Visibility = Visibility.Hidden;
                gpbCatSel.Visibility = Visibility.Visible;
                // Et on active les boutons lié à la modification et la suppression de catégories.
                btnSupprimer.IsEnabled = true;
                btnModifier.IsEnabled = true;
            }
            else
            { // Si non ...
                gpbCatNotSel.Visibility = Visibility.Visible; // Sinon on affiche qu'aucune catégorie est sélectionné.
                gpbCatSel.Visibility = Visibility.Hidden;
                // Et on désactive les boutons lié à la modification et la suppression de catégories.
                btnSupprimer.IsEnabled = false;
                btnModifier.IsEnabled = false;
            }
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            CategorieJeu catAvantMod = new CategorieJeu((lsbCategorie.SelectedItem as CategorieJeu).Nom); // On garde en mémoire ici la catégorie avant sa modification.

            if (!CategorieJeu.EstValide(txbxCatName.Text)) // Ici on vérifie que le nom de catégorie ne correspond pas au nom d'une catégorie existante.
            {
                int indexCat = CategorieJeu.ObtenirListe().IndexOf((lsbCategorie.SelectedItem as CategorieJeu)); // Si elle ne l'est pas, on récupère l'index de la catégorie à modifier.
                CategorieJeu.ObtenirListe()[indexCat].Nom = txbxCatName.Text; // Et on modifie le nom de la catégorie à modifier
                foreach (JeuSociete jeu in JeuSociete.jeux) // Ici on parcours tout les jeux pour modifier la catégorie.
                {
                    if (jeu.EstDeCategorie(catAvantMod)) // Si le jeux contient la catégorie à modifier.
                    {
                        jeu.RetirerCategorie(catAvantMod); // On retire cette catégorie.
                        jeu.AjouterCategorie(CategorieJeu.ObtenirListe()[indexCat]); // Et on la remplace par l'ancienne.
                    }
                }
                MainWindow.Sauvegarder();
            }
            else
            {
                if (txbxCatName.Text != catAvantMod.Nom)
                    MessageBox.Show("La catégories " + txbxCatName.Text + " existe déjà.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            lsbCategorie.Items.Refresh();
        }
    }
}
