using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

using DAL;

namespace BLL
{
    public class DesPays
    {
        public static ObservableCollection<Pays> lesPays = new ObservableCollection<Pays>();
        public static void ChargerListePays()
        {
            DataTable dt = AccessDB.ConnecterBDPays();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var pays = new Pays
                {
                    NomPays = dt.Rows[i]["nomPays"].ToString()
                };
                lesPays.Add(pays);
            }
        }
    }
}
