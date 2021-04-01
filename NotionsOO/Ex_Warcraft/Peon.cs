using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Warcraft
{
    public class Peon : Horde
    {
        protected int pointsVie;

        public Peon()
        {
            pointsVie = 250;
        }

        public override void Parler()
        {
            Console.WriteLine("Le péon parle!");
        }
    }
}
