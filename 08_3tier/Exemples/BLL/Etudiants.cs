using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

using DAL;

namespace BLL
{
    public class Etudiants
    {
        public static ObservableCollection<Etudiant> etudiants = new ObservableCollection<Etudiant>();
        
        public static void ChargerListeEtudiant()
        {
            // Appel de la fonction dans AccessDB pour la connection à la bd
            DataTable dt = AccessDB.ConnecterBD();
            var etudiantsList = new ObservableCollection<Etudiant>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var etu = new Etudiant
                {
                    Matricule = dt.Rows[i]["Matricule"].ToString(),
                    Nom = dt.Rows[i]["Nom"].ToString(),
                    Prenom = dt.Rows[i]["Prenom"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString()
                };
                etudiantsList.Add(etu);
            }
            etudiants = etudiantsList;
        }

        public static void InsererNouvEtud(string ma, string pr, string no, string em)
        {
            

            // Ajout du nouveau étudiant dans la liste des étudiants
            etudiants.Add(new Etudiant
            {
                Matricule = ma,
                Prenom = pr,
                Nom = no,
                Email = em
            });

            // Appel de la méthode qui permet d'insérer les données du nouveau étudiant dans la base de données
            AccessDB.addStudentsToBD(ma, no, pr, em);
        }

        public static void ModifierEtudiant(string matricul, string nom, string prenom, string email)
        {
            AccessDB.UpdateOne(matricul, nom, prenom, email);
        }

        public static void SupprimerEtudiant(string matricule)
        {
            foreach (Etudiant et in etudiants)
            {
                if (et.Matricule == matricule)
                {
                    etudiants.Remove(et);
                    break;
                }
            }
            AccessDB.DeleteOne(matricule);
        }

    }
}
