using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_JeuxSociete
{
   public class Program
   {
      // Touche du chiffre 1.
      private const int VALEUR_ASCII_CHIFFRE_1 = 49;
      // Touche de N.
      private const int VALEUR_ASCII_LETTRE_N = 78;
      // Touche de O.
      private const int VALEUR_ASCII_LETTRE_O = 79;
      // Un age qui signifie "pas de limite".
      private const int MAXIMUM_AGE = 99;

      private static List<JeuSociete> LstJeux { get; set; }

      static void Main(string[] args)
      {
         // Charger la liste des catégories en mémoire.
         CategorieJeu.ChargerListeCategories();

         // Obtenir la liste des jeux.
         LstJeux = JeuSociete.ChargerListeJeux();

         AfficherTitre();

         // Éxécution du menu principal. Quand on sort de ce menu, on quitte l'appliction.
         AfficherMenuPrincipal();

         // Confirmation de la sauvegarde avant de fermer l'application.
         AfficherOptionConfirmerSauvegarde();
      }

      #region Menus et options

      /// <summary>
      /// Affiche et gère le menu principal.
      /// </summary>
      private static void AfficherMenuPrincipal()
      {
         int touche;
         bool quitterMenu = false;

         do
         {
            Console.WriteLine("- Menu principal -");
            Console.WriteLine("1. Afficher la liste des jeux.");
            Console.WriteLine("2. Ajouter un jeu.");
            Console.WriteLine("3. Supprimer un jeu.");
            Console.WriteLine("4. Gérer les catégories de jeu.");
            Console.WriteLine("5. Quitter.");
            Console.Write("=> ");

            touche = LireTouche();

            Console.WriteLine();
            Console.WriteLine("-----");

            if (touche >= VALEUR_ASCII_CHIFFRE_1 && touche <= VALEUR_ASCII_CHIFFRE_1 + 3)
            {
               switch (touche)
               {
                  case VALEUR_ASCII_CHIFFRE_1:
                     AfficherOptionListeJeux();
                     break;
                  case VALEUR_ASCII_CHIFFRE_1 + 1:
                     AfficherOptionAjouterJeu();
                     break;
                  case VALEUR_ASCII_CHIFFRE_1 + 2:
                     AfficherOptionSupprimerJeu();
                     break;
                  case VALEUR_ASCII_CHIFFRE_1 + 3:
                     AfficherMenuGererCategories();
                     break;
               }
            }
            else if (touche == VALEUR_ASCII_CHIFFRE_1 + 4)
            {
               quitterMenu = true;
            }
            else
            {
               Console.WriteLine();
               Console.WriteLine("Entrée invalide.");
               Console.WriteLine();
            }
         }
         while (!quitterMenu);
      }

      /// <summary>
      /// Permet de lister les jeux et leurs détails.
      /// </summary>
      private static void AfficherOptionListeJeux()
      {
         int touche;
         int maxLecture = VALEUR_ASCII_CHIFFRE_1 + LstJeux.Count;
         bool quitterMenu = false;

         AfficherListeJeux();

         do
         {
            Console.Write(Indenter(1) + "Numéro de jeu à voir en détails (0 pour revenir au menu principal) => ");

            touche = LireTouche();

            Console.WriteLine();
            Console.WriteLine();

            if (touche >= VALEUR_ASCII_CHIFFRE_1 && touche < maxLecture)
            {
               AfficherDetailsJeu(true, true, LstJeux[touche - VALEUR_ASCII_CHIFFRE_1]);

               quitterMenu = true;
            }
            else if (touche == VALEUR_ASCII_CHIFFRE_1 - 1)
            {
               quitterMenu = true;
            }
            else
            {
               Console.WriteLine(Indenter(1) + "Entrée invalide.");
               Console.WriteLine();
            }
         }while (!quitterMenu);
      }

      /// <summary>
      /// Permet d'ajouter un jeu.
      /// </summary>
      private static void AfficherOptionAjouterJeu()
      {
         int touche;
         bool entreeValide;
         JeuSociete jeu;
         StringBuilder ligneCategories = new StringBuilder();
         StringBuilder infoCategories = new StringBuilder();

         Console.WriteLine(Indenter(1) + "- Ajout d'un jeu -");

         jeu = LectureNouveauJeu();

         LectureCategoriesJeu(jeu);

         // Confirmation de l'entrée du nouveau jeu.
         entreeValide = false;
         do
         {
            Console.Write(Indenter(1) + "Ajouter << " + jeu.Nom + " >>" + " (O/N) ? ");
            touche = LireTouche();
            Console.WriteLine();

            // On vérifie les majuscules et minuscules.
            if (touche == VALEUR_ASCII_LETTRE_O || touche == VALEUR_ASCII_LETTRE_O + 32)
            {
               LstJeux.Add(jeu);

               Console.WriteLine(Indenter(1) + "Jeu ajouté.");
               entreeValide = true;
            }
            else if (touche == VALEUR_ASCII_LETTRE_N || touche == VALEUR_ASCII_LETTRE_N + 32)
            {
               Console.WriteLine(Indenter(1) + "Ajout annulé.");
               entreeValide = true;
            }
            else
            {
               Console.WriteLine(Indenter(1) + "Entrée invalide.");
            }
         }
         while (!entreeValide);

         Console.WriteLine();
      }

      /// <summary>
      /// Permet de supprimer un jeu.
      /// </summary>
      private static void AfficherOptionSupprimerJeu()
      {
         int entreeNumerique;
         bool quitterOption;
         StringBuilder messageConfirmation = new StringBuilder();

         Console.WriteLine(Indenter(1) + "- Suppression d'un jeu -");
         AfficherListeJeux();

         quitterOption = false;
         do
         {
            Console.Write(Indenter(1) + "Numéro du jeu à supprimer (0 pour annuler) ? ");
            entreeNumerique = LireEntreeNumerique();
            Console.WriteLine();

            if (entreeNumerique == -1)
            {
               Console.WriteLine(Indenter(1) + "Entrée invalide.");
               Console.WriteLine();
            }
            else if (entreeNumerique == 0)
            {
               quitterOption = true;
            }
            else
            {
               if (entreeNumerique <= LstJeux.Count)
               {
                  messageConfirmation.Append(Indenter(1)).Append("Le jeu << ")
                                     .Append(LstJeux[entreeNumerique - 1].Nom)
                                     .Append(" >> a été supprimé.");

                  LstJeux.RemoveAt(entreeNumerique - 1);

                  Console.WriteLine(messageConfirmation);
                  Console.WriteLine();

                  quitterOption = true;
               }
               else
               {
                  Console.WriteLine(Indenter(1) + "Il n'y a pas d'entrée #" + entreeNumerique + ".");
                  Console.WriteLine();
               }
            }
         }
         while (!quitterOption);
      }

      /// <summary>
      /// Affiche et gère le menu de gestion des catégories.
      /// </summary>
      public static void AfficherMenuGererCategories()
      {
         int touche;
         bool quitterMenu = false;

         do
         {
            Console.WriteLine(Indenter(1) + "- Gestion des catégories -");
            Console.WriteLine(Indenter(1) + "1. Afficher la liste des catégories.");
            Console.WriteLine(Indenter(1) + "2. Ajouter une catégorie.");
            Console.WriteLine(Indenter(1) + "3. Supprimer une catégorie.");
            Console.WriteLine(Indenter(1) + "4. Retour au menu principal.");
            Console.Write(Indenter(1) + "=> ");

            touche = LireTouche();

            Console.WriteLine();
            Console.WriteLine(Indenter(1) + "-----");

            // En unicode, 49 est le chiffre 1.
            if (touche >= VALEUR_ASCII_CHIFFRE_1 && touche <= VALEUR_ASCII_CHIFFRE_1 + 2)
            {
               switch (touche)
               {
                  case VALEUR_ASCII_CHIFFRE_1:
                     AfficherListeCategories(true, false, null);
                     break;
                  case VALEUR_ASCII_CHIFFRE_1 + 1:
                     AfficherOptionAjouterCategorie();
                     break;
                  case VALEUR_ASCII_CHIFFRE_1 + 2:
                     AfficherOptionSupprimerCategorie();
                     break;
               }
            }
            else if (touche == VALEUR_ASCII_CHIFFRE_1 + 3)
            {
               quitterMenu = true;
            }
            else
            {
               Console.WriteLine();
               Console.WriteLine("Entrée invalide.");
               Console.WriteLine();
            }
         }
         while (!quitterMenu);
      }

      /// <summary>
      /// Permet d'ajouter une nouvelle catégorie.
      /// </summary>
      public static void AfficherOptionAjouterCategorie()
      {
         string nomCategorie;

         Console.Write(Indenter(2) + "Nom de la nouvelle catégorie ? ");
         nomCategorie = LireChaine();

         Console.WriteLine();

         if (nomCategorie.Length != 0)
         {
            CategorieJeu.ObtenirListe().Add(new CategorieJeu(nomCategorie));

            Console.WriteLine(Indenter(2) + "Catégorie << " + nomCategorie + " >> ajoutée.");
         }
         else
         {
            Console.WriteLine(Indenter(2) + "Aucune catégorie n'a été ajoutée.");
         }

         Console.WriteLine();
      }

      /// <summary>
      /// Permet de supprimer une catégorie parmi toutes celles qui existent.
      /// </summary>
      public static void AfficherOptionSupprimerCategorie()
      {
         int entreeNumerique;
         bool quitterOption;
         List<CategorieJeu> lstCategories;

         quitterOption = false;
         do
         {
            AfficherListeCategories(false, false, null);

            Console.Write(Indenter(2) + "Numéro de la catégorie à supprimer (0 pour quitter) ? ");
            entreeNumerique = LireEntreeNumerique();

            lstCategories = CategorieJeu.ObtenirListe();
            if (entreeNumerique > 0 && entreeNumerique <= lstCategories.Count)
            {
               lstCategories.RemoveAt(entreeNumerique - 1);
            }
            else if (entreeNumerique == 0)
            {
               quitterOption = true;
            }
            else
            {
               Console.WriteLine();
               Console.WriteLine(Indenter(2) + "Entrée invalide.");
               Console.WriteLine();
            }
         }
         while (!quitterOption);
      }

      /// <summary>
      /// Permet de sauvegarder les données de jeu et de catégories en mémoire (avec demande de confirmation).
      /// </summary>
      private static void AfficherOptionConfirmerSauvegarde()
      {
         int touche;
         bool entreeValide;

         entreeValide = false;
         do
         {
            Console.Write("Sauvegarder les données avant de quitter (O/N) ? ");
            touche = LireTouche();
            Console.WriteLine();

            // En Unicode, on cherche les touches N(78), O(79), n(110) ou o(111).
            if (touche == VALEUR_ASCII_LETTRE_O || touche == VALEUR_ASCII_LETTRE_O + 32)
            {
               JeuSociete.EnregistrerListeJeux(LstJeux);
               CategorieJeu.EnregistrerListeCategories();

               Console.WriteLine("Données sauvegardées.");
               Console.ReadKey();

               entreeValide = true;
            }
            else if (touche == VALEUR_ASCII_LETTRE_N || touche == VALEUR_ASCII_LETTRE_N + 32)
            {
               Console.WriteLine("Aucune modification aux données.");
               Console.ReadKey();

               entreeValide = true;
            }
            else
            {
               Console.WriteLine("Entrée invalide.");
            }
         }
         while (!entreeValide);
      }

      #endregion

      #region Affichages

      /// <summary>
      /// Affiche le titre de l'application.
      /// </summary>
      private static void AfficherTitre()
      {
         Console.WriteLine("Bienvenu à l'application ArmoireJeux(tm).");
         Console.WriteLine();
      }

      /// <summary>
      /// Affiche la liste des jeux en mémoire.
      /// </summary>
      private static void AfficherListeJeux()
      {
         int compteur = 0;
         StringBuilder infoListeJeu = new StringBuilder();

         Console.WriteLine(Indenter(1) + "- Liste des jeux -");

         foreach (JeuSociete jeu in LstJeux)
         {
            compteur++;

            infoListeJeu.Clear();
            infoListeJeu.Append(Indenter(1)).Append(compteur).Append(". ");
            infoListeJeu.Append(jeu.Nom);


            Console.WriteLine(infoListeJeu.ToString());
         }

         Console.WriteLine();
      }

      /// <summary>
      /// Affiche les détails d'un jeu.
      /// </summary>
      /// <param name="modeSimple">Détermine si l'affiche des catégories doit être en mode simple ou pas.</param>
      /// <param name="afficherJeu">Détermine si l'affichage doit être fait pour le jeu seulement ou toutes les catégories.</param>
      /// <param name="jeu">Le jeu dont il faut afficher les détails.</param>
      public static void AfficherDetailsJeu(bool modeSimple, bool afficherJeu, JeuSociete jeu)
      {
         StringBuilder ligneCategories = new StringBuilder();
         StringBuilder infoJeu = new StringBuilder();

         // Le nom.
         infoJeu.Append(Indenter(1)).Append("Jeu : ").AppendLine(jeu.Nom);

         // Le nombre de joueurs.
         infoJeu.Append(Indenter(1)).Append("Nombre de joueurs : ");
         if (jeu.MinimumJoueurs != jeu.MaximumJoueurs)
         {
            infoJeu.Append(jeu.MinimumJoueurs).Append(" à ").Append(jeu.MaximumJoueurs).AppendLine(" joueurs");
         }
         else
         {
            infoJeu.Append(jeu.MinimumJoueurs).AppendLine(" joueurs");
         }

         // L'age.
         infoJeu.Append(Indenter(1)).Append("Age : ").Append(jeu.MinimumAge);
         if (jeu.MaximumAge == MAXIMUM_AGE)
         {
            infoJeu.AppendLine("+ ans");
         }
         else if (jeu.MinimumAge != jeu.MaximumAge)
         {
            infoJeu.Append(" à ").Append(jeu.MaximumAge).AppendLine(" ans");
         }
         else
         {
            infoJeu.AppendLine(" ans");
         }
         Console.WriteLine(infoJeu.ToString());

         AfficherListeCategories(modeSimple, afficherJeu, jeu);
      }

      /// <summary>
      /// Affiche une liste de catégories.
      /// </summary>
      /// <param name="modeSimple">Affiche en format de liste à puce simple (true) ou sur deux colonnes (false).</param>
      /// <param name="afficherJeu">Affiche seulement les catégories du jeu reçu en paramêtre (true) ou toutes les catégories existantes (false).</param>
      /// <param name="jeu">Le jeu à utiliser pour l'affichage (soit pour sa liste, soit pour cocher des éléments.</param>
      public static void AfficherListeCategories(bool modeSimple, bool afficherJeu, JeuSociete jeu)
      {
         int compteur;
         StringBuilder ligneCategories = new StringBuilder();
         StringBuilder infoCategories = new StringBuilder();
         List<CategorieJeu> lstCategoriesAffichees = new List<CategorieJeu>();

         if (afficherJeu)
         {
            if (jeu != null)
            {
               lstCategoriesAffichees = jeu.LstCategorie;
            }
            else
            {
               lstCategoriesAffichees = new List<CategorieJeu>();
            }
         }
         else
         {
            lstCategoriesAffichees = CategorieJeu.ObtenirListe();
         }

         // Afficher en mode simple.
         if (modeSimple)
         {
            infoCategories.Append(Indenter(1)).AppendLine("Catégories");

            foreach (CategorieJeu c in lstCategoriesAffichees)
            {
               infoCategories.Append(Indenter(2)).Append("- ").AppendLine(c.Nom);
            }
         }
         else
         {
            compteur = 1;

            foreach (CategorieJeu cat in lstCategoriesAffichees)
            {
               if (compteur % 2 == 1)
               {
                  ligneCategories.Clear().Append(Indenter(1)).Append(compteur).Append(". [");
                  if (jeu != null && jeu.EstDeCategorie(cat))
                  {
                     ligneCategories.Append("X");
                  }
                  else
                  {
                     ligneCategories.Append(" ");
                  }
                  ligneCategories.Append("]").Append(cat.Nom);
               }
               else
               {
                  ligneCategories.Append(AlignerColonne(40, ligneCategories.Length)).Append(compteur).Append(". [");
                  if (jeu != null && jeu.EstDeCategorie(cat))
                  {
                     ligneCategories.Append("X");
                  }
                  else
                  {
                     ligneCategories.Append(" ");
                  }
                  ligneCategories.Append("]").AppendLine(cat.Nom);
                  infoCategories.Append(ligneCategories);
               }

               compteur++;
            }

            // Ajouter la ligne s'il n'y a qu'un seul élément.
            if (compteur % 2 == 0)
            {
               infoCategories.AppendLine(ligneCategories.ToString());
            }
         }

         Console.WriteLine(infoCategories);
      }

      /// <summary>
      /// Retourne des espaces à utiliser pour indenter du texte.
      /// </summary>
      /// <param name="valeur">Combien de fois il faut indenter.</param>
      /// <returns>Les espaces à ajouter.</returns>
      private static string Indenter(int valeur)
      {
         StringBuilder indentation = new StringBuilder();

         for (int i = 1; i <= valeur; i++)
         {
            // Les espaces ajoutés pour une indentation.
            indentation.Append("   ");
         }

         return indentation.ToString();
      }

      /// <summary>
      /// Retourne des espaces à utiliser pour aligner une colonne.
      /// </summary>
      /// <param name="valeur">La position de départ de la colonne.</param>
      /// <param name="taille">La taille du texte déjà présent.</param>
      /// <returns>Les espaces à ajouter.</returns>
      private static string AlignerColonne(int valeur, int taille)
      {
         StringBuilder indentation = new StringBuilder();

         for (int i = valeur - taille; i > 0; i--)
         {
            indentation.Append(" ");
         }

         return indentation.ToString();
      }

      #endregion

      #region Fonctions de lecture

      /// <summary>
      /// Fait la lecture de la prochaine touche entrée au clavier.
      /// </summary>
      /// <returns>La valeur Unicode correspondant à la touche entrée.</returns>
      private static int LireTouche()
      {
         ConsoleKeyInfo choixMenu = Console.ReadKey();

         return Convert.ToInt32(choixMenu.KeyChar);
      }

      /// <summary>
      /// Fait la lecture d'une entrée faite au clavier.
      /// </summary>
      /// <returns>La valeur numérique de l'entrée. Retourne (-1) si l'entrée est négative ou non numérique.</returns>
      private static int LireEntreeNumerique()
      {
         int resultat;

         string choixMenu = Console.ReadLine();
         try
         {
            resultat = Convert.ToInt32(choixMenu);

            // Une valeur numérique négative est invalide.
            if (resultat < 0)
            {
               resultat = -1;
            }

         }
         catch (FormatException)
         {
            resultat = -1;
         }

         return resultat;
      }

      /// <summary>
      /// Fait la lecture d'une chaine au clavier.
      /// </summary>
      /// <returns>La chaine entrée.</returns>
      private static string LireChaine()
      {
         return Console.ReadLine();
      }

      /// <summary>
      ///  Fait la lecture des informations requises pour créer un nouveau JeuSociete.
      /// </summary>
      /// <returns>Le nouveau jeu.</returns>
      private static JeuSociete LectureNouveauJeu()
      {
         string nom;
         int minJoueur, maxJoueur, minAge, maxAge;
         bool entreeValide;

         // Lecture du nom.
         Console.Write(Indenter(1) + "Nom ? ");
         nom = LireChaine();

         // Lecture de l'intervalle de nombre de joueurs.
         entreeValide = false;
         do
         {
            Console.Write(Indenter(1) + "Nombre de joueurs minimal ? ");
            minJoueur = LireEntreeNumerique();

            Console.Write(Indenter(1) + "Nombre de joueurs maximal ? ");
            maxJoueur = LireEntreeNumerique();

            if (minJoueur >= 0 && maxJoueur >= 0)
            {
               if (minJoueur <= maxJoueur)
               {
                  entreeValide = true;
               }
               else
               {
                  Console.WriteLine(Indenter(1) + "Le nombre de joueurs minimal doit être plus petit ou égal à au nombre maximal.");
               }
            }
            else
            {
               Console.WriteLine(Indenter(1) + "Un nombre de joueurs ne peut pas être négatif.");
            }
         }
         while (!entreeValide);

         // Lecture de l'intervalle d'age.
         entreeValide = false;
         do
         {
            Console.Write(Indenter(1) + "Age minimum ? ");
            minAge = LireEntreeNumerique();

            Console.Write(Indenter(1) + "Age maximum (0 pour aucun) ? ");
            maxAge = LireEntreeNumerique();

            if (minAge >= 0 && maxAge >= 0)
            {
               if (maxAge == 0 || minAge <= maxAge)
               {
                  if (maxAge == 0)
                  {
                     maxAge = MAXIMUM_AGE;
                  }

                  entreeValide = true;
               }
               else
               {
                  Console.WriteLine(Indenter(1) + "L'age minimum doit être plus petit ou égal à l'age maximum.");
               }
            }
            else
            {
               Console.WriteLine(Indenter(1) + "Un age ne peut pas être négatif.");
            }
         }
         while (!entreeValide);

         return (new JeuSociete(nom, minJoueur, maxJoueur, minAge, maxAge));
      }

      /// <summary>
      /// Permet d'ajouter ou de retirer des catégories pour un jeu.
      /// </summary>
      /// <param name="jeu">Le jeu dont on traite les catégories.</param>
      /// <returns>Le jeu modifié.</returns>
      private static void LectureCategoriesJeu(JeuSociete jeu)
      {
         int entreeNumerique;
         int nbrCategories = CategorieJeu.ObtenirListe().Count;
         bool quitterOption;
         CategorieJeu categorieChoisie;

         quitterOption = false;
         do
         {
            //Console.WriteLine(Indenter(1) + "- Nouveau jeu -");
            Console.WriteLine();
            AfficherDetailsJeu(false, false, jeu);

            Console.Write(Indenter(1) + "Numéro de la catégorie à ajouter ou retirer (0 pour terminer) => ");

            entreeNumerique = LireEntreeNumerique();

            if (entreeNumerique > 0 && entreeNumerique < nbrCategories)
            {
               categorieChoisie = CategorieJeu.ObtenirListe()[entreeNumerique - 1];

               if (jeu.EstDeCategorie(categorieChoisie))
               {
                  jeu.RetirerCategorie(categorieChoisie);
               }
               else
               {
                  jeu.AjouterCategorie(categorieChoisie);
               }
            }
            else if (entreeNumerique == 0)
            {
               quitterOption = true;
            }
            else
            {
               Console.WriteLine(Indenter(1) + "Entrée invalide.");
               Console.WriteLine();
            }
         }
         while (!quitterOption);
      }

      #endregion
   }
}
