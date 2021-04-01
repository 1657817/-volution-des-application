using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Constructeur
{
    public class Secretaire : Employe
    {
        public bool FormationStenographie { get; set; }

        /*public Secretaire(bool formSteno)
        {
            FormationStenographie = formSteno;
        }*/

        /*public Secretaire(bool formSteno, int nbSemaines) : base(3)
        {
            FormationStenographie = formSteno;
        }*/

        public Secretaire(bool formSteno, int nbSemaines): base(nbSemaines)
        {
            FormationStenographie = formSteno;
        }

        public Secretaire(bool formSteno): this(formSteno, 3)
        {
            FormationStenographie = formSteno;
        }

        public Secretaire(): base(6)
        {
            
        }
    }
}
