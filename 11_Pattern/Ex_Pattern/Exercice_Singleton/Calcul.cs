using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_Singleton
{
    class Calcul
    {
        // Variable static privé de type Auto
        private static Calcul instance;

        // Constructeur privé
        private Calcul()
        {

        }

        // Méthode statique
        public static Calcul Instance
        {
            get
            {   // Si on a pas encore d'instance, alors on créé l'objet;
                if (instance == null)
                {
                    instance = new Calcul();
                }
                return instance;
            }
        }

        public double V1 { get; set; }
        public double V2 { get; set; }

        public double Addition()
        {
            return V1 + V2;
        }

        public double Soustraction()
        {
            return V1 - V2;
        }
    }
}
