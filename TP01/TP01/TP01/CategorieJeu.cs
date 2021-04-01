using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TP01
{
    public class CategorieJeu : IEquatable<CategorieJeu>
    {
        // MODIF Ajout du système pour notifier le système d'un changement de propriété.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #region Static

        private static ObservableCollection<CategorieJeu> LstCategories = new ObservableCollection<CategorieJeu>(); // MODIF Changement de list à observableCollection

        /// <summary>
        /// Fait la lecture du fichier de données et conserver la liste de catégories.
        /// </summary>
        /// <remarks>
        /// Si le fichier est inexistant, vide ou corrompu, une liste vide est implémentée.
        /// </remarks>
        public static void ChargerListeCategories()
        { // MODIF Changement en faveur d'un système qui lit un fichier JSON au lieux d'un fichier texte.
            StreamReader fichierCategories;
            string json;

            fichierCategories = new StreamReader(File.OpenRead(NOM_FICHIER));

            json = fichierCategories.ReadLine();

            fichierCategories.Close();

            CategorieJeu.LstCategories = JsonConvert.DeserializeObject<ObservableCollection<CategorieJeu>>(json);
        }

        /// <summary>
        /// Enregistre la liste de categories dans le fichier de données.
        /// </summary>
        /// <remarks>
        /// Le contenu existant est écrasé à l'écriture.
        /// Si le fichier n'existe pas, il sera créé.
        /// </remarks>
        public static void EnregistrerListeCategories()
        {
            // -MODIF Retrait du code pour la sauvegarde dans le fichier text en faveur de celle pour sauvegarder dans le fichier JSON
            string json = JsonConvert.SerializeObject(LstCategories);
            File.WriteAllText(NOM_FICHIER, json);
        }

        /// <summary>
        /// Permet d'obtenir la liste de catégories. 
        /// </summary>
        /// <returns>Une liste de catégories.</returns>
        public static ObservableCollection<CategorieJeu> ObtenirListe()
        {
            return LstCategories;
        }

        /// <summary>
        /// Permet d'indiquer si une catégorie fait partie de la liste des catégories en mémoire.
        /// </summary>
        /// <param name="categorieVisee">La catégorie à vérifier.</param>
        /// <returns>True si la catégorie se trouve dans la liste, false sinon.</returns>
        public static bool EstValide(string categorieVisee)
        {
            // MODIF Simplification avec la commande Any.
            // Elle parcours la liste et retourne true si la condition indiqué est vrai.
            return LstCategories.Any(cat => cat.Nom == categorieVisee);
        }

        // MODIF Ajout et utilisation de l'interface IEquatable pour voir si la catégorie passé est identique à la catégorie courrante.
        public bool Equals(CategorieJeu other)
        {
            return this._nom == other.Nom;
        }

        #endregion
        private const string NOM_FICHIER = "ListeCategorieJeu.json";

        // MODIF Ajout d'une variable privé nom
        private string _nom;

        public string Nom { 
            get { return _nom; } 
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    NotifyPropertyChanged("Nom");
                }
            }
        }

        /// <summary>
        /// Constructeur de la classe CategorieJeu.
        /// </summary>
        /// <param name="nom">Le nom de la catégorie.</param>
        public CategorieJeu(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Fonction qui vérifie si la catégorie courante peut être supprimer
        /// </summary>
        /// <returns>Retourne false si un jeu ayant la catégorie n'a que celle la, sinon true</returns>
        public bool CanBeSafelyDeleted ()
        {
            if (JeuSociete.jeux.Any(jeu => jeu.EstDeCategorie(this) && jeu.LstCategorie.Count == 1)) // Ici on vérifi si un des jeux contient la catégorie et qu'il n'en a pas d'autre.
            {
                return false; // Si oui on retourne false pour dire que la catégorie ne peut pas être supprimé.
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
