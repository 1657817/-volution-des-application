using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Warcraft
{
    public class Mouton : Unite
    {
        public Mouton()
        {

        }

        public override void Parler()
        {
            Console.WriteLine("Le mouton bêle!");
        }

        public override void Cliquer()
        {
            base.Cliquer();
            Exploser();
        }

        public void Exploser()
        {
            PointsVie = 0;
            Console.WriteLine("******* BOOM *******");
        }
    }
}
