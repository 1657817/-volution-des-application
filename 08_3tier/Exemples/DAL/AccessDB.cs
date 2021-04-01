using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

// Manipulation d'une base de données MySQL
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class AccessDB
    {
        public static DataTable ConnecterBD()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM etudiant", conn); // Préparation de la requète SQL

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();     // using System.Data

                adp.Fill(ds, "etudiant");

                var dt = ds.Tables["etudiant"];

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

        public static void addStudentsToBD(string ma, string no, string pr, string em)
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO etudiant (Matricule, Prenom, Nom, Email) VALUES ('" + ma + "', '" + pr + "', '" + no + "', '" + em + "')", conn);
                cmd.ExecuteNonQuery();

                
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static void UpdateOne(string ma, string no, string pr, string em)
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE etudiant SET Matricule = '" + valMat + "',  Nom ='" + valNo + "' , Prenom ='" + valPre + "', Email ='" + valEma + "' WHERE Matricule = " + valMat, conn);

                MySqlDataReader myReader;

                myReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DeleteOne(string ma)
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=gestion_etudiants;UID=root;PASSWORD=;");

            try
            {
                conn.Open();
                string cmdString = "DELETE FROM etudiant WHERE matricule = '" + ma + "'";

                MySqlCommand cmd = new MySqlCommand(cmdString, conn);

                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
