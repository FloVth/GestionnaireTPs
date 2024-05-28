using System;
using System.Collections.Generic;
using System.Windows;
using _2FAR_Library;
using _2FAR_Gestion.Content;
using _2FAR_Gestion.Content.Tache;
using System.Windows.Controls;
using _2FAR_Gestion.Content.TP;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using _2FAR_Gestion.Content.Promo;
using _2FAR_Library.Graphique;

namespace _2FAR_Gestion
{
    public partial class ListeTp
    {
        //constructeur de la liste des tps
        public ListeTp()
        {
            Dictionary<string,Action<object, EventArgs>> actionsBoutton = new Dictionary<string,Action<object, EventArgs>> { {"Voir Les Taches",consulter},{"Modifier",modifier},{"Statistiques",statistiques},{"Supprimer",supprimer}};
            
            InitializeComponent();
            
            //ajouter chaques tp dans la liste des tps avec leur nombre de taches
            foreach (var tp in Ados.listeTP)
            {
                int count = 0;
                foreach (var tache in Ados.listeTaches)
                {
                    if (tache.fk_id_tp == tp.idTP)
                    {
                        count++;
                    }
                }
                this.stp_liste_tp.Children.Add(new Carte(tp.nomTP + "\nTaches :" + count , tp.descriptionTP, actionsBoutton, 15, 14, tp));
            }
        }
        
        //quand le boutton voir les taches du tp est cliqué, aller sur la page listeTaches avec en parrametre le tp en question
        private void consulter(object o, EventArgs e)
        {
            if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.TP tp)
            {
                Application.Current.MainWindow.Content = new MenuNavbar(new ListeTaches((TP)tp));
            }
        }
        //quand le boutton modifier est cliqué, aller sur la page de creation et de modification d'un tp avec en parrametre le tp en question
        private void modifier(object o, EventArgs e)
        {
            if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.TP tp)
            {
                Application.Current.MainWindow.Content = new MenuNavbar(new CreationModificationTp(Ados.listeAttributions.Where(at => at.tp.idTP == tp.idTP).First()));
            }
        }

        //quand le boutton supprimer est cliquer, supprimer le tp en question
        private void supprimer(object o, EventArgs e)
        {
            //verrifier que l'utilisateur veux réelement supprimer le tp
            if (MessageBox.Show("Étes-Vous sur de vouloir supprimer ce TP", "Vérification", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
            {
                if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c)
                {
                    var tp = c.objectCarte;
                    var idtp = 0;

                    if (tp is _2FAR_Library.TP)
                    {

                        // Utilisation d'une boucle for inversée pour éviter les problèmes de modification de la liste
                        for (int i = Ados.listeTP.Count - 1; i >= 0; i--)
                        {
                            if (Ados.listeTP[i] == (TP)tp)
                            {
                                Ados.listeTP[i].idTP = idtp;
                                Ados.listeTP.RemoveAt(i);
                            }
                        }


                        // Utilisation d'une boucle for inversée pour éviter les problèmes de modification de la liste
                        for (int i = Ados.listeAttributions.Count - 1; i >= 0; i--)
                        {
                            var a = Ados.listeAttributions[i];

                            if (a.tp == tp)
                            {
                                Ados.listeAttributions.RemoveAt(i);
                            }
                        }


                        // Utilisation d'une boucle for inversée pour éviter les problèmes de modification de la liste
                        for (int i = Ados.listeTaches.Count - 1; i >= 0; i--)
                        {
                            var t = Ados.listeTaches[i];
                            if (t.fk_id_tp == idtp )
                            {
                                Ados.listeTaches.RemoveAt(i);
                            }
                        }

                        // Utilisation d'une boucle for inversée pour éviter les problèmes de modification de la liste
                        for (int i = Ados.listeAttenteValidations.Count - 1; i >= 0; i--)
                        {
                            var v = Ados.listeAttenteValidations[i];
                            if (v.tache.fk_id_tp == idtp)
                            {
                                Ados.listeAttenteValidations.RemoveAt(i);
                            }
                        }

                    }
                    //refraichir la liste des tps
                    Application.Current.MainWindow.Content = new MenuNavbar(new ListeTp());
                }
            }
        }

        private void add_tp(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Content = new MenuNavbar(new CreationModificationTp());
        }
        
        //afficher la page de statistiques du tp quand le boutton est clické
        private void statistiques(object o, EventArgs e)
        {
            if (o is Btn b && b.Parent is StackPanel s && s.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.TP tp)
            {
                Application.Current.MainWindow.Content = new MenuNavbar(new StatsTpPromo(tp));
            }
        }
       
    }
}
