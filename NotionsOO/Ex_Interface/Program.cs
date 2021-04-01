using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Oiseau cigogne = new Oiseau(4000);
            Camion mack = new Camion(10);
            Avion Bombardier = new Avion(12000, 5);

            cigogne.Voler();
            mack.Rouler();
            Bombardier.Rouler();
            Bombardier.Voler();

            Console.ReadKey();
        }
    }
}
