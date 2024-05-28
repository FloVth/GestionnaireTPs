using System;
using System.Collections.Generic;
using System.Windows;
using _2FAR_Library;
using _2FAR_Gestion.Content;
using _2FAR_Gestion.Content.TP;
using _2FAR_Gestion.Content.Tache;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Linq;
using System.Windows.Documents;

namespace _2FAR_Gestion.Content.Tache
{
    public partial class ListeTaches
    {
        _2FAR_Library.TP leTP = null;
        
        //constructeur de la page listetache en fonction du tp
        public ListeTaches(_2FAR_Library.TP tp)
        {
            leTP = tp;
            InitializeComponent();

            //si il y a des taches dans le tp
            if(tp.tachesListe !=  null)
            {
                List<_2FAR_Library.Tache> listeTriee = tp.tachesListe.OrderBy(t => t.ordreTache).ToList();

                //afficher toutes les taches du tp dans la liste des taches
                foreach (var tache in listeTriee)
                {
                    this.stp_liste_tache.Children.Add(new Carte(tache.titreTache, tache.descriptionTache, new Dictionary<string, Action<object, EventArgs>> { { "Supprimer", supprimer } }, 15, 14, tache));
                }
            }
            //sinon, afficher une erreur
            else
            {
                MessageBox.Show("Il n'y à pas de taches dans ce tp", "Vérification", MessageBoxButton.OK);
            }
        }
        
        //quand la taches est supprimer
        private void supprimer(object o, EventArgs e)
        {
            //verification de la demande de suppréssion
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette tâche ?", "Vérification", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.Tache tache)
                {
                    //supprimer la tache
                    var taches = Ados.listeTP.Where(tp => tp.idTP == leTP.idTP).First().tachesListe;
                    taches.Remove(taches.Where(t => t.idTache == tache.idTache).First());
                    Ados.listeTP.Where(tp => tp.idTP == leTP.idTP).First().tachesListe = taches;

                    Ados.listeTaches.Remove(Ados.listeTaches.Where(t => t.idTache == tache.idTache).First());

                    //actualiser la liste des taches du tp
                    Application.Current.MainWindow.Content = new MenuNavbar(new ListeTaches(leTP));
                }
            }
        }

        private void add_tache(object o, EventArgs e)
        {
            Application.Current.MainWindow.Content = new MenuNavbar(new CreationTachesTp(leTP));
        }
    }
 
}
