using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2FAR_Library.Ado
{
    public class AdoTache : AdoPromos
    {
        /*
        * Entrée : connexion
        * Sortie : listeTaches
        */
        public static List<Tache> getAdoTache(SqlConnection connexion)
        {
            List<Tache> taches = new List<Tache>();

            try
            {
                string sql = "SELECT * FROM tache;";
                SqlCommand cmd = new SqlCommand(sql, connexion);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    taches.Add(new Tache(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetBoolean(5), reader.GetBoolean(6), reader.GetInt32(7), reader.GetString(8)));
                connexion.Close();
                return taches;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erreur lors du chargement de l'ado Tache", "Vérification", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
            return taches;


        }
    }
}