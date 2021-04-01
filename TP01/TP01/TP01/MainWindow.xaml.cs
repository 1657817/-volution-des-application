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
using System.IO;
using System.Collections.ObjectModel;

namespace TP01
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // On charge la liste de jeux et de catégories
            JeuSociete.ChargerListeJeux();
            CategorieJeu.ChargerListeCategories();
            LoadCatInit(); // On charge les catégories dans la fenêtre ajout.
            // On assigne les itemsSource de la page ajout. (Pour les deux listbox de catégorie)
            lsbCatInit.ItemsSource = lstCatNonUtil;
            lsbCatCurrent.ItemsSource = lstSelCat;

            dgJeux.ItemsSource = JeuSociete.jeux; // On assigne le itemsSource du dataGrid de jeux.
            lsbJeuSupp.ItemsSource = JeuSociete.jeux; // Assignation de la liste de jeux à 
        }

        #region NAVIGATION

        private void BtnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Méthode qui ouvre la fenêtre de gestion des catégories
        /// </summary>
        private void BtnOpenGestionCat_Click(object sender, RoutedEventArgs e)
        {
            winCategorie modalCategorie = new winCategorie();
            modalCategorie.ShowDialog();
            LoadCatInit(); // Reload des catégories pour l'ajout.
            dgJeux.Items.Refresh(); // On refresh les items du datagrid dgJeux pour afficher les modifications.
            SetModifCat(jeu); // On recharge les catégorie du jeux en cours de modification pour afficher les changements.
        }

        #endregion

        #region AFFICHAGE

        /// <summary>
        /// Méthode activer par le bouton modifier de l'onglet affichage
        /// Elle peuple la page de modification avec les données du jeu sélectionner puis l'affiche.
        /// Si aucun jeu n'est séléctionner, elle affiche une erreur.
        /// </summary>
        private void BtnModif_Click(object sender, RoutedEventArgs e)
        {
            if (dgJeux.SelectedItem != null)
            {
                JeuSociete jeuMod = (dgJeux.SelectedItem as JeuSociete);
                jeu = jeuMod; // On assigne ici dans jeu le jeu à modifier.
                // les cinq lignes suivante insère les données à modifier dans le formulaire de modification.
                txbAgeMaxMod.Text = jeuMod.MaximumAge.ToString();
                txbAgeMinMod.Text = jeuMod.MinimumAge.ToString();
                txbMaxJoueurMod.Text = jeuMod.MaximumJoueurs.ToString();
                txbMinJoueurMod.Text = jeuMod.MinimumJoueurs.ToString();
                txbGameNameMod.Text = jeuMod.Nom;
                SetModifCat(jeuMod); // Ici on ajoute on ajoute les catégories utilisé et non utilisé dans le formulaire.
                // Puis on affiche le formulaire
                dkpAffichage.Visibility = Visibility.Hidden;
                grdModif.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Aucun jeu selectionné !", "ERREUR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region MODIFICATION

        ObservableCollection<CategorieJeu> lstSelCatMod; // La liste des catégories du jeu à modifier.
        ObservableCollection<CategorieJeu> lstCatNonUtilMod; // La liste des catégorie non utilisé par le jeu à modifié.
        JeuSociete jeu; // Le jeu à modifié.

        /// <summary>
        /// Méthode qui vérifie et si valide sauvegarde les nouvelles données du jeu modifié.
        /// </summary>
        private void BtnConfirmerMod_Click(object sender, RoutedEventArgs e)
        {
            String errMsg = "";
            Interval itrvAge = new Interval();
            Interval itrvJoueur = new Interval();

            // On regarde ici si le champ nom est vide ou s'il correspond à un jeu qui n'est pas celui qu'on cherche à modifier.
            if (String.IsNullOrEmpty(txbGameNameMod.Text) || (JeuSociete.JeuExiste(txbGameNameMod.Text) && !(txbGameNameMod.Text == jeu.Nom)))
                errMsg += "Nom invalide\n\n"; // Si il l'est, on envoie une erreur à errMsg

            // Ici on envoie les intervals d'age et de joueur pour vérification et assignation. On recoit les messages d'erreur s'il y a lieu dans la variable errMsg.
            errMsg += itrvAge.VerifAjout(txbAgeMinMod.Text, txbAgeMaxMod.Text, "Age") + itrvJoueur.VerifAjout(txbMinJoueurMod.Text, txbMaxJoueurMod.Text, "Joueur");

            if (lstSelCatMod.Count == 0) // On vérifie ici si on a aucune catégorie sélectionné.
                errMsg += "Au moins une catégorie est requise\n\n";

            if (errMsg == "") // On vérifie qu'aucun message d'erreur n'a été recut des vérification.
            {
                // On insère ici les nouvelles données dans le jeu qu'on veut modifier.
                jeu.LstCategorie = new List<CategorieJeu>(lstSelCatMod);
                jeu.Nom = txbGameNameMod.Text;
                jeu.MinimumAge = itrvAge.IntervalMin;
                jeu.MaximumAge = itrvAge.IntervalMax;
                jeu.MinimumJoueurs = itrvJoueur.IntervalMin;
                jeu.MaximumJoueurs = itrvJoueur.IntervalMax;
                // On retourne à l'affichage de la liste de jeux.
                grdModif.Visibility = Visibility.Hidden;
                dkpAffichage.Visibility = Visibility.Visible;
                
                dgJeux.Items.Refresh(); // On refresh les données du datagrid pour afficher les modifications.
                Sauvegarder(); // Puis on sauvegarde les données modifié.
            }
            else
                MessageBox.Show(errMsg, "", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        /// <summary>
        /// Méthode pour ajouter une catégorie à la liste de catégorie du jeu à modifier
        /// </summary>
        private void BtnAddCatMod_Click(object sender, RoutedEventArgs e)
        {
            if (lsbCatInitMod.SelectedItem != null) //On vérifie si on a une catégorie de sélectionner pour l'ajout.
            {
                if (lstSelCatMod.Count < 5) // On accepte d'ajouter des catégories tant que le nombre de catégories maximal (5) n'est pas atteint.
                {
                    lstSelCatMod.Add((lsbCatInitMod.SelectedItem as CategorieJeu));
                    lstCatNonUtilMod.Remove((lsbCatInitMod.SelectedItem as CategorieJeu));
                }
                else
                    MessageBox.Show("Impossible d'ajouter une catégorie, le nombre maximal (5) a été atteint", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Méthode pour enlever une catégorie à la liste de catégorie du jeu à modifier
        /// </summary>
        private void BtnRmvCatMod_Click(object sender, RoutedEventArgs e)
        {
            if (lsbCatCurrentMod.SelectedItem != null) //On vérifie si on a une catégorie de sélectionner pour la suppression.
            {
                lstCatNonUtilMod.Add((lsbCatCurrentMod.SelectedItem as CategorieJeu));
                lstSelCatMod.Remove((lsbCatCurrentMod.SelectedItem as CategorieJeu));
            }
        }

        private void BtnRetourMod_Click(object sender, RoutedEventArgs e)
        {
            dkpAffichage.Visibility = Visibility.Visible; // On affiche l'interface de la liste de jeux.
            grdModif.Visibility = Visibility.Hidden; // On cache l'interface de modification.
        }

        #endregion

        #region AJOUT

        private ObservableCollection<CategorieJeu> lstCatNonUtil = new ObservableCollection<CategorieJeu>(); // Liste des catégories non utilisé par le jeu à ajouter.
        private ObservableCollection<CategorieJeu> lstSelCat = new ObservableCollection<CategorieJeu>(); // Liste des catégories utilisé par le jeu à ajouter.

        /// <summary>
        /// Méthode pour ajouter une catégorie à la liste de catégorie du nouveau jeu
        /// </summary>
        private void BtnAddCat_Click(object sender, RoutedEventArgs e)
        {
            if (lsbCatInit.SelectedItem != null) //On vérifie si on a une catégorie de sélectionner pour l'ajout.
            {
                if (lstSelCat.Count < 5) // On accepte d'ajouter des catégories tant que le nombre de catégories maximal (5) n'est pas atteint.
                {
                    lstSelCat.Add((lsbCatInit.SelectedItem as CategorieJeu));
                    lstCatNonUtil.Remove((lsbCatInit.SelectedItem as CategorieJeu));
                }
                else
                    MessageBox.Show("Impossible d'ajouter une catégorie, le nombre maximal (5) a été atteint", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Méthode pour enlever une catégorie à la liste de catégorie du nouveau jeu
        /// </summary>
        private void BtnRmvCat_Click(object sender, RoutedEventArgs e)
        {
            if (lsbCatCurrent.SelectedItem != null) //On vérifie si on a une catégorie de sélectionner pour la suppression.
            {
                lstCatNonUtil.Add((lsbCatCurrent.SelectedItem as CategorieJeu)); // On ajoute la catégorie sélectionner dans la liste de catégorie non utilisé.
                lstSelCat.Remove((lsbCatCurrent.SelectedItem as CategorieJeu)); // Et on l'enlève de celle des catégorie utilisé.
            }
        }

        /// <summary>
        /// Méthode qui valide les données du jeu à ajouter et le sauvegarde si il est valide.
        /// </summary>
        private void BtnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            String errMsg = "";
            Interval itrvAge = new Interval();
            Interval itrvJoueur = new Interval();
            if (String.IsNullOrEmpty(txbGameName.Text) || JeuSociete.JeuExiste(txbGameName.Text)) // Ici on valide que le champ nom n'est pas vide et qu'il ne correspond pas à un jeu existant.
                errMsg += "Nom invalide\n\n"; // S'il est vide ou qu'il correspond au nom d'un jeu existant on ajout un message d'erreur à errMsg.

            // Ici on envoie les intervals d'age et de joueur pour vérification et assignation. On recoit les messages d'erreur s'il y a lieu dans la variable errMsg.
            errMsg += itrvAge.VerifAjout(txbAgeMin.Text, txbAgeMax.Text, "Age") + itrvJoueur.VerifAjout(txbMinJoueur.Text, txbMaxJoueur.Text, "Joueur");

            if (lstSelCat.Count == 0) // Ici on regarde si aucune catégorie n'est sélectionner.
                errMsg += "Au moins une catégorie est requise\n\n"; // Si oui, on ajoute le message d'erreur à errMsg.

            if (errMsg == "") // On entre ici si on a recut aucun message d'erreur des vérifications précédente.
            {
                JeuSociete.jeux.Add(new JeuSociete(txbGameName.Text, itrvJoueur, itrvAge, new List<CategorieJeu>(lstSelCat))); // Si on a aucune erreurs, on ajoute le nouveaui jeu à jeux
                MessageBox.Show("Jeux ajouter avec succès", "", MessageBoxButton.OK);
                ResetForm(); // On remet à zéro le formulaire.
                Sauvegarder(); // Et on sauvegarde les données.
            }
            else // Si on a recut une ou plusieurs erreurs, on les affiches.
                MessageBox.Show(errMsg, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Méthode qui remet à zéro le formulaire d'ajout
        /// </summary>
        private void ResetForm()
        {
            // On vide tout les champs du formulaire
            txbAgeMax.Clear();
            txbAgeMin.Clear();
            txbGameName.Clear();
            txbMaxJoueur.Clear();
            txbMinJoueur.Clear();
            LoadCatInit(); // Et on reste les catégories
        }

        /// <summary>
        /// Méthode qui charge les catégories pour la page d'ajout de jeu.
        /// </summary>
        private void LoadCatInit()
        {
            lstCatNonUtil.Clear(); // On vide la liste de catégories non utilisé.
            foreach (CategorieJeu categorie in CategorieJeu.ObtenirListe())
            {
                lstCatNonUtil.Add(categorie); // On ajoute dans la liste de catégorie non utilisé toutes les catégories disponibles.
            }
            lstSelCat.Clear(); // On vide la liste de catégories utilisé.
        }

        #endregion

        #region SUPPRESSION

        /// <summary>
        /// Méthode appellé lors du click sur le bouton supprimer.
        /// Supprime le jeu sélectionné dans la listbox.
        /// </summary>
        private void BtnSupp_Click(object sender, RoutedEventArgs e)
        {
            if (lsbJeuSupp.SelectedItem != null) // On vérifie si un jeu est sélectionner.
            { // Si un jeu est sélectionné on procède à le supprimer de jeux et de sauvegarder les données du programme.
                MessageBox.Show("Le jeu a été supprimé", "", MessageBoxButton.OK, MessageBoxImage.Information);
                JeuSociete.jeux.Remove((lsbJeuSupp.SelectedItem as JeuSociete));
                Sauvegarder();
            }
        }

        #endregion

        #region AUTRE

        /// <summary>
        /// Méthode qui sauvegarde les listes de jeux et de catégories dans les fichiers JSON correspondant.
        /// </summary>
        public static void Sauvegarder()
        {
            CategorieJeu.EnregistrerListeCategories();
            JeuSociete.EnregistrerListeJeux();
        }

        /// <summary>
        /// Méthode qui charge les catégorie du jeu à modifier dans les observable collection prévu à cet effet.
        /// </summary>
        /// <param name="jeuMod">Le jeu à modifier</param>
        private void SetModifCat(JeuSociete jeuMod)
        {
            if (jeuMod != null) // On vérifie si jeuMod n'est pas null
            {
                lstSelCatMod = new ObservableCollection<CategorieJeu>(); // On reset lstSelCatMod pour préparer la collection à recevoir les nouvelles données.
                foreach (CategorieJeu categorie in jeuMod.LstCategorie)
                {
                    lstSelCatMod.Add(categorie); // On insère toutes les catégories du jeu dans la collection des jeux sélectionné.
                }
                lsbCatCurrentMod.ItemsSource = lstSelCatMod; // Et on remet la collection comme itemSource de la listbox. 
                lstCatNonUtilMod = new ObservableCollection<CategorieJeu>();
                foreach (CategorieJeu cat in CategorieJeu.ObtenirListe())
                {
                    if (!jeu.EstDeCategorie(cat)) lstCatNonUtilMod.Add(cat); // On insère les catégories dans la collection lstCatNonUtilMod si la catégorie en question n'est pas dans le jeu à modifier.
                }
                lsbCatInitMod.ItemsSource = lstCatNonUtilMod;
            }
        }
        #endregion
    }
}
