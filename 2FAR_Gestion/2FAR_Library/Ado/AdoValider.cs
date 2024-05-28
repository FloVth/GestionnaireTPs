using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace _2FAR_Library.Ado
{
    public class AdoValider : AdoTache 
    {
        /*
         * Entrée : connexion, listeUtilisateurs, listeTaches
         * Sortie : listeValider
         */
        public static List<Valider> getAdoValider(SqlConnection connexion, List<Utilisateur> tousLesUtilisateurs, List<Tache> toutesLesTaches)
        {
            List<Valider> validerListe = new List<Valider>();

            try
            {
                string sql = "SELECT * FROM valider;";
                SqlCommand cmd = new SqlCommand(sql, connexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foreach (Utilisateur u in tousLesUtilisateurs)
                    {
                        foreach (Tache t in toutesLesTaches)
                        {
                            if (reader.GetInt32(2) == u.idUtilisateur && reader.GetInt32(3) == t.idTache)
                            {
                                validerListe.Add(new Valider(t, u, reader.GetString(0), reader.GetBoolean(1)));
                            }
                        }
                    }
                }
                connexion.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'ado Valider", "Vérification", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
            return validerListe;

        }
    }
}
