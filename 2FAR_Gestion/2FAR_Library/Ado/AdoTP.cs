using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2FAR_Library.Ado
{
    public class AdoTP : AdoTache
    {
        /*
        * Entrée : connexion, listeTaches
        * Sortie : listeTP
        */
        public static List<TP> GetAdoTP(SqlConnection connexion, List<Tache> toutesLesTaches)
        {
            List<TP> tpListe = new List<TP>();

            try
            {
                string sql = "SELECT * FROM tp;";
                SqlCommand cmd = new SqlCommand(sql, connexion);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    tpListe.Add(new TP(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                foreach (TP tp in tpListe)
                {
                    foreach (Tache t in toutesLesTaches)
                    {
                        if (t.fk_id_tp == tp.idTP)
                        {
                            tp.tachesListe.Add(t);
                        }
                    }
                }
                connexion.Close();
                return tpListe;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'ado TP", "Vérification", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
            return tpListe;


        }
    }
}
