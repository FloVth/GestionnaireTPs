using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2FAR_Library
{
    public class AvancementTache
    {
        public int taux_avancement {  get; set; }  
        public Tache tache { get; set; }
        public Utilisateur utilisateur { get; set; }

        public AvancementTache(int tauxAvancement, Tache _tache, Utilisateur _utilisateur) 
        {
            this.taux_avancement = tauxAvancement;
            this.tache = _tache;
            this.utilisateur = _utilisateur;
        }
    }
}
