using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LabBinding
{
    public class Etudiant : INotifyPropertyChanged
    {
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
                if (matricule != value)
                {
                    matricule = value;
                    NotifyPropertyChanged("Matricule");
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
                if (prenom != value)
                {
                    prenom = value;
                    NotifyPropertyChanged("Prenom");
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
                if (nom != value)
                {
                    nom = value;
                    NotifyPropertyChanged("Nom");
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
                if (email != value)
                {
                    email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
