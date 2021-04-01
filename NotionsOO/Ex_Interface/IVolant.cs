using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Interface
{
    interface IVolant
    {
        int AltitudeMaximale { get; set; }

        void Voler();
    }
}
