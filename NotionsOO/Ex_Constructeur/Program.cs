using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Constructeur
{
    public class Program
    {
        static void Main(string[] args)
        {
            Secretaire sec1 = new Secretaire(true, 4);
            int nbSemVac = sec1.SemainesVacances;
            Console.WriteLine("Secrétaire 1 : \nNombre de semaines de vacances : " + nbSemVac);

            Secretaire sec2 = new Secretaire(true);
            nbSemVac = sec2.SemainesVacances;
            Console.WriteLine("Secrétaire 2 : \nNombre de semaines de vacances : " + nbSemVac);

            Secretaire sec3 = new Secretaire();
            nbSemVac = sec3.SemainesVacances;
            Console.WriteLine("Secrétaire 3 : \nNombre de semaines de vacances : " + nbSemVac);


            Console.ReadKey();
        }
    }
}
