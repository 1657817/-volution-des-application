using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_debug
{
    public class TypeG
    {
        public TypeG(char type)
        {
            switch (type)
            {
                case 'S':
                    TypeGa = lesTypes.Spirale;
                    break;
                case 'E':
                    TypeGa = lesTypes.Elliptique;
                    break;
                case 'I':
                    TypeGa = lesTypes.Irreguliere;
                    break;
                case 'L':
                    TypeGa = lesTypes.Lenticulaire;
                    break;
                default:
                    break;
            }
        }
        public object TypeGa { get; set; }
        private enum lesTypes { Spirale, Elliptique, Irreguliere, Lenticulaire }
    }
}
