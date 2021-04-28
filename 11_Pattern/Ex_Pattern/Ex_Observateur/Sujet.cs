using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Observateur
{
    public abstract class Sujet
    {
        // Pour chaque sujet, on a 0 ou plusieurs observateur.
        List<IObservateur> observateurs = new List<IObservateur>();

        // Ajouter un nouvel observateur.
        public void Ajouter(IObservateur observateur)
        {
            observateurs.Add(observateur);
        }

        // Retirer un observateur.
        public void Enlever(IObservateur observateur)
        {
            observateurs.Remove(observateur);
        }

        // Notifier les observateur d'un changement.
        public void Notifier()
        {
            foreach (IObservateur observateur in observateurs)
            {
                observateur.Actualiser();
            }
        }
    }
}
