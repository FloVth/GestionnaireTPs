using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2FAR_Library.Ado
{
    public class AdoAttendreValidation : AdoTache
    {

        /*
         * Entrée : connexion, listeUtilisateur, listeTaches
         * Sortie : liste des taches en attentes de validation
         */
        public static List<AttendreValidation> getAdoAttendreValidation(SqlConnection connexion, List<Utilisateur> tousLesUtilisateurs, List<Tache> toutesLesTaches)
        {
            List<AttendreValidation> attendreValidationListe = new List<AttendreValidation>();
            try
            {
                string sql = "SELECT * FROM attendre_validation ORDER BY dte_demande DESC;";
                SqlCommand cmd = new SqlCommand(sql, connexion);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foreach (Utilisateur u in tousLesUtilisateurs)
                    {
                        foreach (Tache t in toutesLesTaches)
                        {
                            if (reader.GetInt32(1) == u.idUtilisateur && reader.GetInt32(2) == t.idTache)
                            {
                                attendreValidationListe.Add(new AttendreValidation(reader.GetDateTime(0).ToString(), u, t));
                            }
                        }
                    }
                }
                connexion.Close();
                return attendreValidationListe;
            } catch (Exception e)
            {
                MessageBox.Show("Erreur lors du chargement de l'ado AttendreValidation", "Vérification", MessageBoxButton.OK);
                
            }
            return attendreValidationListe;

        } 
            
        }
    }

