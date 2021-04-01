using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Polymorphisme
{
    public class Point
    {
        private int x = 0;
        private int y = 0;

        public Point()
        {

        }

        public Point(int i, int j)
        {
            x = i;
            y = j;
        }

        public void Afficher()
        {
            Console.WriteLine(x + " " + y);
        }

        // Méthode qui permet de surcharger l'opérateur +
        // Les méthode de surcharge doivent toujours être statique (static)
        public static Point operator +(Point p1, Point p2)
        {
            Point p = new Point();

            p.x = p1.x + p2.x;
            p.y = p1.y + p2.y;

            return p;
        }
    }
}
