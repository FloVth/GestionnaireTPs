namespace _2FAR_Library
{
    public class Tache
    {
        //public TP tpTache { get; set; }
        public int idTache { get; set; }

        public string titreTache { get; set; }
        public string descriptionTache { get; set; }
        public bool isCheckpoint { get; set; }
        public int ordreTache { get; set; }
        public double pointTache { get; set; }
        public bool isBonus { get; set; }
        public bool isActif { get; set; }

        public int fk_id_tp { get; set; }

        public Tache( int _idtache, string _descriptiontache, bool _ischeckpoint, int _ordretache, int _pointtache, bool _isbonus, bool _isactif, int _fkidtp, string _titreTache)
        {
            this.idTache = _idtache;
            this.descriptionTache = _descriptiontache;
            this.isCheckpoint = _ischeckpoint;
            this.ordreTache = _ordretache;
            this.pointTache = _pointtache;
            this.isBonus = _isbonus;
            this.isActif = _isactif;
            this.fk_id_tp = _fkidtp;
            this.titreTache = _titreTache;
        }
    }
}
