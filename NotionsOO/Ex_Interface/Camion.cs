using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Interface
{
    public class Camion : IRoulant
    {
        public int NombreRoues { get; set; }

        public Camion(int NombreRoues)
        {
            this.NombreRoues = NombreRoues;
        }

        public void Rouler()
        {
            Console.WriteLine("Le camion roule gràce à " + NombreRoues + " roues");
        }
    }
}
