using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Constructeur
{
    public class Employe
    {
        public int SemainesVacances { get; set; }

        public Employe(int nbSemaines)
        {
            SemainesVacances = nbSemaines;
        }

        public Employe()
        {

        }
    }
}
