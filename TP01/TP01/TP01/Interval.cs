using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    public class Interval
    {
        private const int ITRVMAX = 99;

        public int IntervalMin { get; set; }
        public int IntervalMax { get; set; }

        public Interval () { }

        public string VerifAjout(string intervalMin, string intervalMax, string intervalType)
        {
            int itrvMin = -1;
            int itrvMax = -1;
            string errMsg = "";
            if (!String.IsNullOrEmpty(intervalMax)) // On vérifi si l'interval maximum n'est pas un string vide.
            {
                if (int.TryParse(intervalMax, out _) && int.Parse(intervalMax) > 0 && int.Parse(intervalMax) <= ITRVMAX) // Si oui on vérifi si il s'agit d'un chiffre et que ce chiffre est entre 1 et 99.
                    itrvMax = int.Parse(intervalMax); // Puis on transforme le string en int.
                else // Si on ne peut pas le convertir ou qu'il n'est pas un nombre valide, on met un message d'erreur dans errMsg
                    errMsg += intervalType + " maximum invalide, doit être un chiffre entre 1 et 99 ou laissé vide pour la valeur par défaut (99)\n\n";
            }
            else
                itrvMax = ITRVMAX; // Si non on met l'interval maximum à 99.

            if (int.TryParse(intervalMin, out _) && int.Parse(intervalMin) > 0 && int.Parse(intervalMin) <= ITRVMAX) // On vérifi si l'interval minimum est un chiffre et que ce chiffre est entre 1 et 99.
                itrvMin = int.Parse(intervalMin); // Si oui, on le transforme en int
            else // Sinon on ajoute à errMsg un message d'erreur.
                errMsg += intervalType + " minimum invalide, doit être un chiffre entre 1 et 99\n\n"; 

            if (errMsg == "") // Ici on regarde qu'aucun message d'erreur en lien au minimum et maximum n'a été ajouté.
            {
                if (itrvMax > itrvMin) // Si aucune erreur, on vérifie que ageMax est plus grand que ageMin
                { // Si l'interval est valide on assigne les valeurs de itrvMin et itrvMax à IntervalMin et IntervalMax de l'object courrant
                    IntervalMin = itrvMin;
                    IntervalMax = itrvMax;
                    return ""; // Et on retourne un message d'erreur vide (sois pas d'erreur).
                }
                else
                    errMsg = "Interval invalide (" + intervalType + ")\n\n"; // Si l'interval n'est pas valide on ajouter le message d'erreur à errMsg.
            }
            return errMsg; // Si on est ici, une ou plusieurs erreurs ont été rencontré et on retourne le message d'erreur à afficher.
        }
    }
}
