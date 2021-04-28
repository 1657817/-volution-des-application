using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class AccessDB
    {
        public static DataTable ConnecterBDFilm()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=lesfilms;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM film", conn); // Préparation de la requète SQL

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();     // using System.Data

                adp.Fill(ds, "film");

                var dt = ds.Tables["film"];

                return dt;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public static DataTable ConnecterBDPays()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=lesfilms;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM pays", conn); // Préparation de la requète SQL

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();     // using System.Data

                adp.Fill(ds, "pays");

                var dt = ds.Tables["pays"];

                return dt;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
