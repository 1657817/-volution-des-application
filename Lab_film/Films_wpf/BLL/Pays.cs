using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BLL
{
    public class Pays
    {
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private String _nomPays;

        public String NomPays
        {
            get
            {
                return _nomPays;
            }
            set
            {
                if (_nomPays != value)
                {
                    _nomPays = value;
                    this.NotifyPropertyChanged("NomPays");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
