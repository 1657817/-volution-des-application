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

    /// <summary>
    /// Classe qui représente un jeu de société.
    /// Les données initiales proviennent de https://boardgamegeek.com
    /// </summary>
    public class JeuSociete : IEquatable<JeuSociete>
    {
        // -MODIF Ajout de la constante ayant le nom du fichier JSON
        private const string NOM_FICHIER = "ListeJeuSociete.json";

        // MODIF Ajout de la liste de jeux
        public static ObservableCollection<JeuSociete> jeux = new ObservableCollection<JeuSociete>();

        // MODIF Ajout du système pour notifier le système d'un changement de propriété.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        // MODIF Ajout des variables privées. Ajout de _ devant le nom des variable pour indiquer des variables privés
        private string _nom;
        private int _minimumJoueurs;
        private int _maximumJoueurs;
        private int _minimumAge;
        private int _maximumAge;
        private List<CategorieJeu> _lstCategorie = new List<CategorieJeu>();

        // MODIF Changements des propriété pour qu'il notifie les observable collection des changements
        public string Nom
        {
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

        public int MinimumJoueurs
        {
            get { return _minimumJoueurs; }
            set
            {
                if (_minimumJoueurs != value)
                {
                    _minimumJoueurs = value;
                    NotifyPropertyChanged("IntervalAge");
                }
            }
        }

        public int MaximumJoueurs
        {
            get { return _maximumJoueurs; }
            set
            {
                if (_maximumJoueurs != value)
                {
                    _maximumJoueurs = value;
                    NotifyPropertyChanged("IntervalAge");
                }
            }
        }

        public int MinimumAge
        {
            get { return _minimumAge; }
            set
            {
                if (_minimumAge != value)
                {
                    _minimumAge = value;
                    NotifyPropertyChanged("IntervalAge");
                }
            }
        }

        public int MaximumAge
        {
            get { return _maximumAge; }
            set
            {
                if (_maximumAge != value)
                {
                    _maximumAge = value;
                    NotifyPropertyChanged("IntervalAge");
                }
            }
        }

        public List<CategorieJeu> LstCategorie
        {
            get { return _lstCategorie; }
            set
            {
                if (_lstCategorie != value)
                {
                    _lstCategorie = value;
                    NotifyPropertyChanged("LstCategorie");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // MODIF Retrait des constructeur utilisant les valeurs minimum/maximum en faveur d'un utilisant des objets d'intervals,

        /// <summary>
        /// Constructeur utilisé à l'ajout d'un nouveau jeu.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="intervalJ"></param>
        /// <param name="intervalA"></param>
        /// <param name="lstCat"></param>
        public JeuSociete(string nom, Interval intervalJ, Interval intervalA, List<CategorieJeu> lstCat)
        {
            Nom = nom;
            _minimumAge = intervalA.IntervalMin;
            _maximumAge = intervalA.IntervalMax;
            _minimumJoueurs = intervalJ.IntervalMin;
            _maximumJoueurs = intervalJ.IntervalMax;
            LstCategorie = lstCat;
        }
        public JeuSociete()
        {

        }

        public static void ChargerListeJeux() // MODIFQ1 Changement du type de méthode de List<JeuSociete> à void puisqu'on ne retourne rien.
        {
            // -MODIFQ1 retrait du code en lien avec la lecture de fichier txt en faveur du nouveau code avec newtonSoft.json
            try
            {
                StreamReader fichierJeu;
                string json;

                fichierJeu = new StreamReader(File.OpenRead(NOM_FICHIER)); // On récupère le fichier de jeux en lecture.

                json = fichierJeu.ReadLine(); // On lit la ligne de données.

                fichierJeu.Close(); // On ferme le streamReader.

                jeux = JsonConvert.DeserializeObject<ObservableCollection<JeuSociete>>(json); // On converti la ligne de données en observableCollection de l'objet JeuSociete.
            }
            catch (Exception)
            {
                jeux = new ObservableCollection<JeuSociete>(); // Si le fichier n'existe pas, on crée une liste de jeux vide.
            }
        }

        /// <summary>
        /// Enregistre la liste de jeux dans un fichier JSON.
        /// </summary>
        /// <remarks>
        /// Le contenu existant est écrasé à l'écriture.
        /// Si le fichier n'existe pas, il sera créé.
        /// </remarks>
        public static void EnregistrerListeJeux()
        {
            // MODIFQ1 Retrait du code pour la sauvegarde dans le fichier text en faveur de celle pour sauvegarder dans le fichier JSON
            string json = JsonConvert.SerializeObject(jeux); // Ici on sérialize la liste de jeux en JSON.
            File.WriteAllText(NOM_FICHIER, json); // Et on l'écrit dans le texte
        }

        /// <summary>
        /// Permet d'ajouter une catégorie au jeu (si cette catégorie est valide).
        /// </summary>
        /// <param name="nouvelleCategorie">La nouvelle catégorie.</param>
        public void AjouterCategorie(CategorieJeu nouvelleCategorie)
        {
            if (CategorieJeu.EstValide(nouvelleCategorie.Nom))
            { // Si la catégorie passé en paramètre est valide (elle existe), on l'ajoute au jeu courrant.
                _lstCategorie.Add(nouvelleCategorie);
            }
        }

        /// <summary>
        /// Permet de retirer une catégorie d'un jeu. 
        /// </summary>
        /// <param name="ancienneCategorie"></param>
        public void RetirerCategorie(CategorieJeu ancienneCategorie)
        {
            _lstCategorie.Remove(ancienneCategorie);
        }

        /// <summary>
        /// Permet de vérifier si le jeu est d'une catégorie précise.
        /// </summary>
        /// <param name="categorie">La catégorie à vérifier.</param>
        /// <returns>True si le jeu est de la catégorie à vérifier, false sinon.</returns>
        public bool EstDeCategorie(CategorieJeu categorie)
        {
            return LstCategorie.Contains(categorie);
        }

        /// <summary>
        /// Méthode qui vérifie si un jeu avec le nom fournie existe
        /// </summary>
        /// <param name="nomJeu">Nom du jeu à vérifié</param>
        /// <returns></returns>
        public static bool JeuExiste(string nomJeu)
        {
            // MODIF Utilisation de any pour vérifier si un des jeux a déjà le nom passé en paramètre.
            return jeux.Any(jeu => jeu.Nom == nomJeu);
        }

        // MODIF Implémentation de l'interface IEquatable pour vérifier si deux objects JeuSociete sont identique.
        public bool Equals(JeuSociete other)
        {
            return this._nom == other.Nom &&
                   this._minimumAge == other.MinimumAge &&
                   this._maximumAge == other.MaximumAge &&
                   this._minimumJoueurs == other.MinimumJoueurs &&
                   this._maximumJoueurs == other.MaximumJoueurs &&
                   this._lstCategorie == other.LstCategorie;
        }
    }
}
