using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Warcraft
{
    class Program
    {
        public static void Main(string[] args)
        {
            Peon Thrall = new Peon();
            Paysan Wrynn = new Paysan();
            Mouton Pouf = new Mouton();

            List<Unite> listeUnite = new List<Unite>();
            listeUnite.Add(Thrall);
            listeUnite.Add(Wrynn);
            listeUnite.Add(Pouf);

            Console.WriteLine("On clique sur nos trois unité... \n");

            foreach (Unite u in listeUnite)
            {
                u.Cliquer();
            }

            Console.ReadKey();
        }
    }
}
