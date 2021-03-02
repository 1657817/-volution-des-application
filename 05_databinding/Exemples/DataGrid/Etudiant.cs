using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataGrid
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
    }
}
