using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

using DAL;

namespace BLL
{
    public class Films
    {
        public static ObservableCollection<Film> films = new ObservableCollection<Film>();
        public static void ChargerListeFilm()
        {
            DataTable dt = AccessDB.ConnecterBDFilm();
            //var filmList = new ObservableCollection<Film>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var film = new Film
                {
                    Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                    Titre = dt.Rows[i]["Titre"].ToString(),
                    Annee = int.Parse(dt.Rows[i]["Annee"].ToString()),
                    Pays = dt.Rows[i]["Pays"].ToString()
                };
                films.Add(film);
            }
        }
    }
}
