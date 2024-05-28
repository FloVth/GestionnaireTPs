namespace _2FAR_Library
{
    public class Utilisateur
    {
        public int fk_id_promo { get; set; }
        public int idUtilisateur { get; set; }
        public string nomUtilisateur { get; set; }
        public string prenomUtilisateur { get; set; }
        public string mailUtilisateur { get; set; }
        public string mdpUtilisateur { get; set; }
        public bool isAdmin { get; set; }
        public string nomPromo {  get; set; }
            


        public Utilisateur( int idutilisateur, string nomutilisateur, string prenomutilisateur, string mailutilisateur, string mdputilisateur, bool isadmin, int promoutilisateur, string nomPromo)
        {
            this.fk_id_promo = promoutilisateur;
            this.idUtilisateur = idutilisateur;
            this.nomUtilisateur = nomutilisateur;
            this.prenomUtilisateur = prenomutilisateur;
            this.mailUtilisateur = mailutilisateur;
            this.mdpUtilisateur = mdputilisateur;
            this.isAdmin = isadmin;
            this.nomPromo = nomPromo;
        }
    }
}
