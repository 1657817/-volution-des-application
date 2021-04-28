using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BLL
{
    public class Film
    {
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private int _id;
        private string _titre;
        private int _annee;
        private string _pays;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (this._id != value)
                {
                    this._id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }
        public string Titre
        {
            get
            {
                return _titre;
            }
            set
            {
                if (this._titre != value)
                {
                    this._titre = value;
                    this.NotifyPropertyChanged("Titre");
                }
            }
        }
        public int Annee
        {
            get
            {
                return _annee;
            }
            set
            {
                if (this._annee != value)
                {
                    this._annee = value;
                    this.NotifyPropertyChanged("Annee");
                }
            }
        }
        public string Pays
        {
            get
            {
                return _pays;
            }
            set
            {
                if (this._pays != value)
                {
                    this._pays = value;
                    this.NotifyPropertyChanged("Pays");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
