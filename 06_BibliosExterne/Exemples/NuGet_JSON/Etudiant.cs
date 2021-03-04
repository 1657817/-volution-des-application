using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
// Bibliothèque pour la gestion des données des étudiants
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace DataGrid
{
    public class Etudiant : INotifyPropertyChanged
    {
        private const string NOM_FICHIER = "fEtudiants.json";
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private string matricule;
        private string prenom;
        private string nom;
        private string email;
        public string Matricule
        {
            get
            {
                return matricule;
            }
            set
            {
                if (this.matricule != value)
                {
                    this.matricule = value;
                    this.NotifyPropertyChanged("Matricule");
                }
            }
        }
        public string Prenom
        {
            get
            {
                return prenom;
            }
            set
            {
                if (this.prenom != value)
                {
                    this.prenom = value;
                    this.NotifyPropertyChanged("Prenom");
                }
            }
        }
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                if (this.nom != value)
                {
                    this.nom = value;
                    this.NotifyPropertyChanged("Nom");
                }
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged("Email");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public static void ChargerFichier()
        {
            StreamReader fichierEtudiants;
            string json;

            fichierEtudiants = new StreamReader(File.OpenRead(NOM_FICHIER));

            json = fichierEtudiants.ReadLine();

            fichierEtudiants.Close(); // On doit fermer le fichier(streamReader) après la lecture

            UC_GestionEtud.etudiants = JsonConvert.DeserializeObject<ObservableCollection<Etudiant>>(json);
        }
    }
}
