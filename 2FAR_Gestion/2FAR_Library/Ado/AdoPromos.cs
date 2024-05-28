using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2FAR_Library.Ado
{
        /*
        * Entrée : connexion, listeUtilisateurs
        * Sortie : listePromotions
        */
    public class AdoPromos : AdoUtilisateur
    {
       
        public static List<Promo> getAdoPromos(SqlConnection connexion, List<Utilisateur> tousLesUtilisateurs) 
        {

            List<Promo> promotions = new List<Promo>();

            try
            {
                string sql = "SELECT * FROM promotion";
                SqlCommand cmd = new SqlCommand(sql, connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    promotions.Add(new Promo(reader.GetInt32(0), reader.GetString(1)));
                foreach (Promo p in promotions)
                {
                    foreach (Utilisateur u in tousLesUtilisateurs)
                    {
                        if (u.fk_id_promo == p.idPromo)
                        {
                            p.utilisateurList.Add(u);
                        }
                    }
                }
                connexion.Close();
                return promotions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'ado promotion", "vérification", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
            return promotions;

        }
    }
}
