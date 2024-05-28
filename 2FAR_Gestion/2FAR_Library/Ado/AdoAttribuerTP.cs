using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2FAR_Library.Ado
{
     public class AdoTPAttribuer : AdoTP
    {
        /*
         * Entrée : connexion, listeTP, listePromotions
         * Sortie : listeTPAttribuer
         */
        public static List<TPAttribuer>  getAdoTPAttribuer(SqlConnection connexion, List<TP> tousLesTps, List<Promo> touteLesPromotions)
        {
            List<TPAttribuer> TPAttribuerListe = new List<TPAttribuer>();
            try
            {
                string sql = "SELECT * FROM etre_attribuer";
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)connexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foreach (Promo p in touteLesPromotions)
                    {
                        foreach (TP t in tousLesTps)
                        {
                            if (reader.GetInt32(2) == t.idTP && reader.GetInt32(3) == p.idPromo)
                            {
                                TPAttribuerListe.Add(new TPAttribuer(reader.GetDateTime(0), reader.GetBoolean(1),
                                    t, p));
                            }
                        }
                    }
                }
                connexion.Close();
                return TPAttribuerListe;
            }
            catch 
            {
                MessageBox.Show("Erreur lors du chargement de l'ado TP Attribuer", "Vérification", MessageBoxButton.OK);
                Application.Current.Shutdown();
            }
            return TPAttribuerListe;

        }
    }
}
