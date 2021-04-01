using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Warcraft
{
    public abstract class Unite
    {
        protected int PointsVie { get; set; }

        public Unite()
        {

        }

        public virtual void Cliquer()
        {
            Parler();
        }

        public abstract void Parler();
    }
}
