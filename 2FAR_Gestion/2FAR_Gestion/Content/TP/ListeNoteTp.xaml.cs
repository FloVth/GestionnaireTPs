using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _2FAR_Library;

namespace _2FAR_Gestion.Content.TP
{
    /// <summary>
    /// Logique d'interaction pour ListeNoteTp.xaml
    /// </summary>
    public partial class ListeNoteTp : Page
    {
        _2FAR_Library.TP leTp = null;
        _2FAR_Library.Promo laPromo = null;

        public ListeNoteTp(_2FAR_Library.TP tp, _2FAR_Library.Promo promo)
        {
            InitializeComponent();
            leTp = tp;
            laPromo = promo;
            foreach (var utilisateur in laPromo.utilisateurList)
            {
                int count = 0;
                int loopTache = 0;
                if (utilisateur.fk_id_promo == laPromo.idPromo && utilisateur.isAdmin == false)
                {
                    foreach (var tache in leTp.tachesListe)
                    {
                        if (tache.fk_id_tp == leTp.idTP)
                        {
                            loopTache++;
                            foreach (var validation in Ados.listeValidations)
                            {
                                if (validation.utilisateurValider.idUtilisateur == utilisateur.idUtilisateur && validation.tacheValider.idTache == tache.idTache && validation.isJuste == true)
                                {
                                    count = count + ((int)tache.pointTache);
                                }
                            }
                        }
                    }
                this.stp_note_tp.Children.Add(new Carte(utilisateur.nomUtilisateur + " " + utilisateur.prenomUtilisateur, "Note : " + count, null, 15, 14, tp));
                }
            }
            
            
        }
    }
}
