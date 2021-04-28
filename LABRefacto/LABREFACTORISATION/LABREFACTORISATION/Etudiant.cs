using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABREFACTORISATION
{
    class Etudiant
    {
        private string _matricule;
        private string _nom;
        private double _noteInfo;
        private double _noteMath;
        
        public Etudiant(string matricule, string nom, double noteInfo, double noteMath)
        {
            _matricule = matricule;
            _nom = nom;
            _noteInfo = noteInfo;
            _noteMath = noteMath;
        }

        public double MoyennePrincipale()
        {
            return (_noteInfo + _noteMath + 1) / 2;
        }

        public double MoyenneRattrapage()
        {
            return (_noteInfo + _noteMath) / 2;
        }
    }
}
