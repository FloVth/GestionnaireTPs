using System.Collections.Generic;

namespace _2FAR_Library
{
    public class Promo
    {
        public List<Utilisateur>? utilisateurList { get; set; } 
        public int idPromo { get; set; }
        public string nomPromo { get; set; }

        public Promo(List<Utilisateur> userlist, int idpromo, string nompromo)
        {
            this.utilisateurList = userlist;
            this.idPromo = idpromo;
            this.nomPromo = nompromo;
        }

        public Promo(int idpromo, string nompromo)
        {
            this.utilisateurList = new List<Utilisateur>();
            this.idPromo=idpromo;
            this.nomPromo=nompromo;
        }
    }
}
