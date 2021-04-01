using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Interface
{
    public class Avion : IVolant, IRoulant
    {
        public int AltitudeMaximale { get; set; }
        public int NombreRoues { get; set; }

        public Avion(int AltitudeMaximale, int NombreRoues)
        {
            this.AltitudeMaximale = AltitudeMaximale;
            this.NombreRoues = NombreRoues;
        }

        public void Rouler()
        {
            Console.WriteLine("L'avion roule gràce à " + NombreRoues + " roues");
        }

        public void Voler()
        {
            Console.WriteLine("Un avion vole à une altitude maximale de " + AltitudeMaximale + "mètres");
        }
    }
}
