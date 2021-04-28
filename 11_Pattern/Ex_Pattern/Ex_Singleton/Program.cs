using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto s1 = Auto.GetInstance();
            Auto s2 = Auto.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("S1 et S2 sont égal");
            } else
            {
                Console.WriteLine("Singleton ne fonctionne pas.");
            }
            Console.ReadKey();
        }
    }
}
