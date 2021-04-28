using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Debug
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Bienvenue aux nouvelles des Galaxies!");
            ParcourirLaListe();
            Console.ReadKey();
        }

        private static void ParcourirLaListe()
        {
            var lesGalaxies = new List<Galaxie>
            {
                new Galaxie() { Nom="Têtard", DistanceAnneesLumiere=420, TypeGalaxy=new TypeG('S')},
                new Galaxie() { Nom="Moulinet", DistanceAnneesLumiere=23, TypeGalaxy=new TypeG('S')},
                new Galaxie() { Nom="Roue de chariot", DistanceAnneesLumiere=500, TypeGalaxy=new TypeG('L')},
                new Galaxie() { Nom="Le petit nuage de Magellan", DistanceAnneesLumiere=.2, TypeGalaxy=new TypeG('I')},
                new Galaxie() { Nom="Galaxy d'andromède", DistanceAnneesLumiere=3, TypeGalaxy=new TypeG('S')},
                new Galaxie() { Nom="Maffei1", DistanceAnneesLumiere=11, TypeGalaxy=new TypeG('E')}
            };

            foreach (Galaxie laGalaxie in lesGalaxies)
            {
                Console.WriteLine(laGalaxie.Nom + " " + laGalaxie.DistanceAnneesLumiere + " " + laGalaxie.TypeGalaxy);
            }
        }
    }
}
