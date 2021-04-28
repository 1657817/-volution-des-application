using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Singleton
{
    // Utilisation du patron Singleton
    public class Auto
    {
        // Variable static privé de type Auto
        private static Auto instance;

        // Constructeur privé
        private Auto()
        {

        }

        // Méthode statique
        public static Auto GetInstance()
        {
            // Si on a pas encore d'instance, alors on créé l'objet;
            if (instance == null)
            {
                instance = new Auto();
            }
            return instance;
        }
    }
}
