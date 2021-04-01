using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_JeuxSociete
{
   public class CategorieJeu
   {
      #region Static

      private static List<CategorieJeu> LstCategories = new List<CategorieJeu>();

      /// <summary>
      /// Fait la lecture du fichier de données et conserver la liste de catégories.
      /// </summary>
      /// <remarks>
      /// Si le fichier est inexistant, vide ou corrompu, une liste vide est implémentée.
      /// </remarks>
      public static void ChargerListeCategories()
      {
            string[] lignes = System.IO.File.ReadAllLines(@"ListeCategorieJeu.txt");

            foreach (string ligne in lignes)
            {
                LstCategories.Add(new CategorieJeu(ligne));
            }
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
            using (StreamWriter sw = new StreamWriter("ListeCategorieJeu.txt"))
            {
                foreach(CategorieJeu element in LstCategories)
                {
                    sw.WriteLine(element.Nom);
                }
            }
        }
      
      /// <summary>
      /// Permet d'obtenir la liste de catégories. 
      /// </summary>
      /// <returns>Une liste de catégories.</returns>
      public static List<CategorieJeu> ObtenirListe()
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
         bool estValide = false;
         int i = 0;

         while (!estValide && i < LstCategories.Count)
         {
            if (LstCategories[i].Nom == categorieVisee)
            {
               estValide = true;
            }

            i++;
         }

         return estValide;
      }

      #endregion

      public string Nom { get; set; }

      /// <summary>
      /// Constructeur de la classe CategorieJeu.
      /// </summary>
      /// <param name="nom">Le nom de la catégorie.</param>
      public CategorieJeu(string nom)
      {
         Nom = nom;
      }
   }
}
