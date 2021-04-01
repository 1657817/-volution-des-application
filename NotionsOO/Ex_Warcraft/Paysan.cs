using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Warcraft
{
    public class Paysan : Horde
    {

        public Paysan()
        {

        }

        public override void Parler()
        {
            Console.WriteLine("Paysan parle");
        }

    }
}
