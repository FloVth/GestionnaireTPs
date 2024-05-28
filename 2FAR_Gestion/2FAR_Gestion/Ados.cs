using System.Collections.Generic;
using _2FAR_Library;
using _2FAR_Library.Ado;

namespace _2FAR_Gestion;

public class Ados
{
    public static List<AttendreValidation> listeAttenteValidations;
    public static List<TPAttribuer> listeAttributions;
    public static List<Valider> listeValidations;
    public static List<AvancementTache> listeAvancementTaches;
    public static List<Promo> listePromotions;
    public static List<Utilisateur> listeUtilisateurs;
    public static List<Tache> listeTaches;
    public static List<TP> listeTP;

    public static void GetAdos()
    {
        listeTaches = AdoTache.getAdoTache(Connexion.GetConn());
        listeTP = AdoTP.GetAdoTP(Connexion.GetConn(), listeTaches); // taches
            

        listeUtilisateurs = AdoUtilisateur.getAdoUtilisateur(Connexion.GetConn());
        listePromotions = AdoPromos.getAdoPromos(Connexion.GetConn(), listeUtilisateurs); // utilisateurs

        listeAttributions = AdoTPAttribuer.getAdoTPAttribuer(Connexion.GetConn(), listeTP, listePromotions); //TP ET PROMO

        listeAttenteValidations = AdoAttendreValidation.getAdoAttendreValidation(Connexion.GetConn(), listeUtilisateurs, listeTaches); //utilisateurs ET Taches
        listeValidations = AdoValider.getAdoValider(Connexion.GetConn(), listeUtilisateurs, listeTaches); //Utilisateurs taches
        listeAvancementTaches = AdoAvancementTache.getAdoAvancementTache(Connexion.GetConn(), listeUtilisateurs, listeTaches); //utilisateurs et taches
    }
}