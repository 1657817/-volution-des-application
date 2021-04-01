using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_JeuxSociete
{
   /// <summary>
   /// Classe qui représente un jeu de société.
   /// Les données initiales proviennent de https://boardgamegeek.com
   /// </summary>
   public class JeuSociete
   {
        public string Nom { get; set; }

        public int MinimumJoueurs { get; set; }

        public int MaximumJoueurs { get; set; }

        public int MinimumAge { get; set; }

        public int MaximumAge { get; set; } // On met un maximum de 99 ans quand il n'y a pas réellement de limite.

        public List<CategorieJeu> LstCategorie { get; set; }

        /// <summary>
        /// Fait la lecture du fichier de données et retourne une liste de jeux.
        /// </summary>
        /// <remarks>
        /// Si le fichier est inexistant, vide ou corrompu, la méthode retourne une liste vide.
        /// </remarks>
        /// <returns>Une liste de jeux.</returns>
        public static List<JeuSociete> ChargerListeJeux()
        {
            string[] lignes = System.IO.File.ReadAllLines(@"ListeJeuSociete.txt");

            List<JeuSociete> lstJeux = new List<JeuSociete>();


            foreach (string ligne in lignes)
            {

                List<CategorieJeu> LstCat = new List<CategorieJeu>();

                string[] champsLigne = ligne.Split(':');

                string NomJ = champsLigne[0];
                int MinimunJoueursJ = Int32.Parse(champsLigne[1]);
                int MaximumJoueursJ = Int32.Parse(champsLigne[2]);
                int MinimumAgeJ = Int32.Parse(champsLigne[3]);
                int MaximumAgeJ = Int32.Parse(champsLigne[4]);

                string[] CategoriesJ = champsLigne[5].Split(',');

                foreach (string categorie in CategoriesJ)
                {
                    LstCat.Add(new CategorieJeu(categorie));
                }

                lstJeux.Add(new JeuSociete(NomJ, MinimunJoueursJ, MaximumJoueursJ, MinimumAgeJ, MaximumAgeJ, LstCat));
            }
            return lstJeux;
      }

      /// <summary>
      /// Enregistre la liste de jeux reçue dans le fichier de données.
      /// </summary>
      /// <remarks>
      /// Le contenu existant est écrasé à l'écriture.
      /// Si le fichier n'existe pas, il sera créé.
      /// </remarks>
      /// <param name="lst">La liste des jeux qui doit être enregistrée dans le fichier.</param>
      public static void EnregistrerListeJeux(List<JeuSociete> lst)
      {
            using (StreamWriter sw = new StreamWriter("ListeJeuSociete.txt"))
            {
                foreach (JeuSociete element in lst)
                {
                    StringBuilder ligne = new StringBuilder();

                    ligne.Append(element.Nom + ":"
                        + element.MinimumJoueurs + ":"
                        + element.MaximumJoueurs + ":"
                        + element.MinimumAge + ":"
                        + element.MaximumAge + ":");
                    
                    for(int i=0;i<element.LstCategorie.Count;i++)
                    {
                        if (i < element.LstCategorie.Count - 1)
                            ligne.Append(element.LstCategorie[i].Nom + ",");
                        else
                            ligne.Append(element.LstCategorie[i].Nom);
                    }

                    sw.WriteLine(ligne);
                }
            }
      }      

      /// <summary>
      /// Contructeur de la classe JeuSociete
      /// </summary>
      /// <param name="nom">Le nom du jeu.</param>
      /// <param name="minJoueurs">Le nombre minimal de joueurs.</param>
      /// <param name="maxJoueurs">Le nombre maximal de joueurs.</param>
      /// <param name="minAge">Le minimum d'age requis pour jouer.</param>
      /// <param name="maxAge">Le maximum d'age recommandé pour jouer.</param>
      /// <remarks>
      /// La gestion des catégories d'un jeu se fait par les méthodes de la classe.
      /// </remarks>
      public JeuSociete(string nom, int minJoueurs, int maxJoueurs, int minAge, int maxAge, List<CategorieJeu> lstCat)
      {
         Nom = nom;
         MinimumJoueurs = minJoueurs;
         MaximumJoueurs = maxJoueurs;
         MinimumAge = minAge;
         MaximumAge = maxAge;

         LstCategorie = lstCat;
      }

        public JeuSociete(string nom, int minJoueurs, int maxJoueurs, int minAge, int maxAge)
        {
            Nom = nom;
            MinimumJoueurs = minJoueurs;
            MaximumJoueurs = maxJoueurs;
            MinimumAge = minAge;
            MaximumAge = maxAge;

            LstCategorie = new List<CategorieJeu>();
        }

        /// <summary>
        /// Permet d'ajouter une catégorie au jeu (si cette catégorie est valide).
        /// </summary>
        /// <param name="nouvelleCategorie">La nouvelle catégorie.</param>
        public void AjouterCategorie(CategorieJeu nouvelleCategorie)
      {
         if (CategorieJeu.EstValide(nouvelleCategorie.Nom))
         {
            LstCategorie.Add(nouvelleCategorie);
         }
      }

      /// <summary>
      /// Permet de retirer une catégorie d'un jeu. 
      /// </summary>
      /// <param name="ancienneCategorie"></param>
      public void RetirerCategorie(CategorieJeu ancienneCategorie)
      {
         LstCategorie.Remove(ancienneCategorie);
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


   }
}
