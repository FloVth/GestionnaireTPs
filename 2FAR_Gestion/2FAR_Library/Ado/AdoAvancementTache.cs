using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2FAR_Library.Ado
{
    public class AdoAvancementTache : AdoTache
    {
        /*
         * Entrée : connexion, listeUtilisateurs, listeTaches
         * Sortie : listeAvancementTache
         */
        public static List<AvancementTache> getAdoAvancementTache(SqlConnection connexion, List<Utilisateur> tousLesUtilisateurs, List<Tache> toutesLesTaches)
        {

            List<AvancementTache> avancementTaches = new List<AvancementTache>();
            try 
            {
                string sql = "SELECT * FROM avancement_tache";
                SqlCommand cmd = new SqlCommand(sql, connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foreach (Tache t in toutesLesTaches)
                    {
                        foreach (Utilisateur u in tousLesUtilisateurs)
                        {
                            if (t.idTache == reader.GetInt32(0) && u.idUtilisateur == reader.GetInt32(1))
                            {
                                avancementTaches.Add(new AvancementTache(reader.GetInt32(2), t, u));
                            }
                        }
                    }
                }
                connexion.Close();
                return avancementTaches;
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'ado Avancement Tache", "Vérification", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
            return avancementTaches;
        }

    }
}
