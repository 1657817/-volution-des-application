using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Calcul.Instance.V1 = 12;
            Calcul.Instance.V2 = 7.5;
            double somme = Calcul.Instance.Addition();
            double diff = Calcul.Instance.Soustraction();
            Console.WriteLine("Somme : " + somme + "\n" + "Diff : " + diff);
            Console.ReadKey();
        }
    }
}
