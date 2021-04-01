using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Interface
{
    public class Oiseau : IVolant
    {
        public int AltitudeMaximale { get; set; }

        public Oiseau(int AltitudeMaximale)
        {
            this.AltitudeMaximale = AltitudeMaximale;
        }

        public void Voler()
        {
            Console.WriteLine("Un oiseau vole à une altitude maximale de " + AltitudeMaximale + "mètres");
        }
    }
}
