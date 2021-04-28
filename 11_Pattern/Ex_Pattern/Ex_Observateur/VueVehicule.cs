using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Observateur
{
    class VueVehicule : IObservateur
    {
        Vehicule vehicule;
        string texte = "";

        public VueVehicule(Vehicule vehicule)
        {
            this.vehicule = vehicule;

            // À la création de l'objet VueVehicule, on l'ajoute comme observateur de vehicule.
            this.vehicule.Ajouter(this);

            Actualiser();
        }

        public void Actualiser()
        {
            texte = "Description : " + vehicule.Description + ", Prix : " + vehicule.Prix + "\n";
        }

        public void Afficher()
        {
            Console.WriteLine(texte);
        }
    }
}
