using System.Collections.Generic;
namespace _2FAR_Library
{
    public class TP
    {
       public List<Tache>? tachesListe {  get; set; }
        public int idTP { get; set; }
        public string nomTP { get; set; }
        public string descriptionTP { get; set; }


        public TP(List<Tache> tachesListe, int idtp, string nomtp, string descriptiontp)
        {
            this.tachesListe = tachesListe;
            this.idTP = idtp;
            this.nomTP = nomtp;
            this.descriptionTP = descriptiontp;
        }

        public TP(int idtp, string nomtp, string descriptiontp)
        {
            this.tachesListe = new List<Tache>();
            this.idTP = idtp;
            this.nomTP = nomtp;
            this.descriptionTP = descriptiontp;
        }
    }
}
