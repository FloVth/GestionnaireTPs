using _2FAR_Gestion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2FAR_Library;

namespace _2FAR_Gestion
{
    public class AdoToDB
    {
        public static void suppressionDB()
        {
            //suppression des tables

            SqlCommand cmdDelete = new SqlCommand { Connection = Connexion.GetConn() };
            cmdDelete.CommandText = "DELETE FROM valider";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM avancement_tache";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM etre_attribuer";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM avancement_tache";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM attendre_validation";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM utilisateur";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM promotion";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM tache";
            cmdDelete.ExecuteNonQuery();
            cmdDelete.CommandText = "DELETE FROM tp";
            cmdDelete.ExecuteNonQuery();

            cmdDelete.Connection.Close();

            //remettre les autoincrement à 1 
            SqlCommand cmd = new SqlCommand { Connection = Connexion.GetConn() };


            cmd.CommandText = "DBCC CHECKIDENT (promotion, RESEED, 0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DBCC CHECKIDENT (utilisateur, RESEED, 0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DBCC CHECKIDENT (tp, RESEED, 0)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DBCC CHECKIDENT (tache, RESEED, 0)";
            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }

        public static void reinsertionDB()
        {
            //inserer les données 
            // Ordre Promo -> Utilisateur -> TP -> Tache -> Attribuer_TP -> Valider -> Attendre_validation -> Avancement_tache



            SqlCommand cmdInsert = new SqlCommand { Connection = Connexion.GetConn() };


            foreach (Promo p in Ados.listePromotions)
            {
                string sqlPromo = "INSERT INTO promotion (nom_promotion) VALUES (@nom_promotion)";
                cmdInsert.CommandText = sqlPromo;
                cmdInsert.Parameters.AddWithValue("@nom_promotion", p.nomPromo);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (Utilisateur u in Ados.listeUtilisateurs)
            {
                string sqlUtilisateur = "INSERT INTO utilisateur (nom_utilisateur, prenom_utilisateur, mail_utilisateur, mdp_utilisateur, is_admin, fk_id_promo) VALUES (@nom_utilisateur, @prenom_utilisateur, @mail_utilisateur, @mdp_utilisateur, @is_admin, @fk_id_promo)";
                cmdInsert.CommandText = sqlUtilisateur;
                cmdInsert.Parameters.AddWithValue("@nom_utilisateur", u.nomUtilisateur);
                cmdInsert.Parameters.AddWithValue("@prenom_utilisateur", u.prenomUtilisateur);
                cmdInsert.Parameters.AddWithValue("@mail_utilisateur", u.mailUtilisateur);
                cmdInsert.Parameters.AddWithValue("@mdp_utilisateur", u.mdpUtilisateur);
                cmdInsert.Parameters.AddWithValue("@is_admin", u.isAdmin);
                cmdInsert.Parameters.AddWithValue("@fk_id_promo", u.fk_id_promo);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (TP t in Ados.listeTP)
            {
                string sqlTP = "INSERT INTO tp (nom_tp, description_tp) VALUES (@nom_tp, @description_tp)";
                cmdInsert.CommandText = sqlTP;
                cmdInsert.Parameters.AddWithValue("@nom_tp", t.nomTP);
                cmdInsert.Parameters.AddWithValue("@description_tp", t.descriptionTP);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (Tache t in Ados.listeTaches)
            {
                string sqlTache = "INSERT INTO tache (description_tache, ordre_tache, point_etape, is_bonus, is_actif, fk_id_tp, titre_tache, is_checkpoint) VALUES (@description_tache, @ordre_tache, @point_tache, @is_bonus, @is_actif, @fk_id_tp, @titre_tache, @is_checkpoint)";
                cmdInsert.CommandText = sqlTache;
                cmdInsert.Parameters.AddWithValue("@description_tache", t.descriptionTache);
                cmdInsert.Parameters.AddWithValue("@ordre_tache", t.ordreTache);
                cmdInsert.Parameters.AddWithValue("@point_tache", t.pointTache);
                cmdInsert.Parameters.AddWithValue("@is_bonus", t.isBonus);
                cmdInsert.Parameters.AddWithValue("@is_actif", t.isActif);
                cmdInsert.Parameters.AddWithValue("@fk_id_tp", t.fk_id_tp);
                cmdInsert.Parameters.AddWithValue("@titre_tache", t.titreTache);
                cmdInsert.Parameters.AddWithValue("@is_checkpoint", t.isCheckpoint);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (TPAttribuer a in Ados.listeAttributions)
            {
                string sqlAttributionTP = "INSERT INTO etre_attribuer (dte_fin, is_actif, fk_id_tp, fk_id_promo) VALUES (@dte_fin, @is_actif, @fk_id_tp, @fk_id_promo)";
                cmdInsert.CommandText = sqlAttributionTP;
                cmdInsert.Parameters.AddWithValue("@dte_fin", a.dte_fin);
                cmdInsert.Parameters.AddWithValue("@is_actif", a.is_actif);
                cmdInsert.Parameters.AddWithValue("@fk_id_tp", a.tp.idTP);
                cmdInsert.Parameters.AddWithValue("@fk_id_promo", a.promotion.idPromo);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (Valider v in Ados.listeValidations)
            {
                string sqlValidationTP = "INSERT INTO valider (reponse, is_valide, fk_id_utilisateur,fk_id_tache) VALUES (@reponse, @is_valide, @fk_id_utilisateur, @fk_id_tache)";
                cmdInsert.CommandText = sqlValidationTP;
                cmdInsert.Parameters.AddWithValue("@reponse", v.reponse);
                cmdInsert.Parameters.AddWithValue("@is_valide", v.isJuste);
                cmdInsert.Parameters.AddWithValue("@fk_id_utilisateur", v.utilisateurValider.idUtilisateur);
                cmdInsert.Parameters.AddWithValue("@fk_id_tache", v.tacheValider.idTache);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (AttendreValidation v in Ados.listeAttenteValidations)
            {
                string sqlAttenteValidationTP = "INSERT INTO attendre_validation (dte_demande, fk_id_utilisateur, fk_id_tache) VALUES (@dte_demande, @fk_id_utilisateur, @fk_id_tache)";
                cmdInsert.CommandText = sqlAttenteValidationTP;
                cmdInsert.Parameters.AddWithValue("@dte_demande", v.dte_demande);
                cmdInsert.Parameters.AddWithValue("@fk_id_utilisateur", v.utilisateur.idUtilisateur);
                cmdInsert.Parameters.AddWithValue("@fk_id_tache", v.tache.idTache);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }

            foreach (AvancementTache a in Ados.listeAvancementTaches)
            {
                string sqlAvancementTP = "INSERT INTO avancement_tache (fk_id_tache, fk_id_utilisateur, taux_avancement) VALUES (@fk_id_tache, @fk_id_utilisateur, @taux_avancement)";
                cmdInsert.CommandText = sqlAvancementTP;
                cmdInsert.Parameters.AddWithValue("@fk_id_tache", a.tache.idTache);
                cmdInsert.Parameters.AddWithValue("@fk_id_utilisateur", a.utilisateur.idUtilisateur);
                cmdInsert.Parameters.AddWithValue("@taux_avancement", a.taux_avancement);
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Parameters.Clear();
            }
            cmdInsert.Connection.Close();

        
        }
    }
}
