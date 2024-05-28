using System;
using System.Collections.Generic;
using System.Windows;
using _2FAR_Library;
using _2FAR_Gestion.Content;
using _2FAR_Gestion.Content.Promo;
using System.Windows.Controls;
using _2FAR_Gestion.Content.TP;
using System.Linq;
using _2FAR_Library.Graphique;

namespace _2FAR_Gestion
{
    public partial class ListePromos
    {
        public ListePromos()
        {
            Dictionary<string, Action<object, EventArgs>> actionsBoutton = new Dictionary<string, Action<object, EventArgs>> { { "Voir les tps", Voir_Les_Tps }, { "Modifier", Modifier }, { "Supprimer", Supprimer } };

            InitializeComponent();

            foreach (var promo in Ados.listePromotions)
            {
                int count = 0;
                foreach (var utilisateur in Ados.listeUtilisateurs) {
                    if (utilisateur.fk_id_promo == promo.idPromo)
                    {
                        count++;
                    }
                 }
                this.stp_liste_promotion.Children.Add(new Carte("Nombre d'élève : " + count.ToString(), promo.nomPromo, actionsBoutton, 18, 25, promo));
            }
        }

        private void Voir_Les_Tps(object o, EventArgs e)
        {
            if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.Promo promo)
            { 
                Application.Current.MainWindow.Content = new MenuNavbar(new ListeTpPromos((Promo)promo));
            }
        }
        private void Modifier(object o, EventArgs e)
        {

            if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.Promo promo)
            { 
                Application.Current.MainWindow.Content = new MenuNavbar(new CreationModificationPromo(promo));

            }
        }

        private void Supprimer(object o, EventArgs e)
        {
            //supprimer la promo et les tp associés
            MessageBoxResult result = MessageBox.Show("Étes-Vous sur de vouloir supprimer cette promo", "Vérification", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (o is _2FAR_Library.Graphique.Btn b && b.Parent is StackPanel st && st.Parent is Grid g && g.Parent is Carte c)
                {
                    var promo = c.objectCarte;
                    var idPromo = 0;
                    Promo p = null;
                    if (promo is _2FAR_Library.Promo)
                    {
                        
                        // Utilisation d'une boucle for inversée pour éviter les problèmes de modification de la liste
                        for (int i = Ados.listePromotions.Count - 1; i >= 0; i--)
                        {
                            //Supprimer les TPAttribuer de la promo
                            for (int j = Ados.listeAttributions.Count - 1; j >= 0; j--)
                            {
                                if (Ados.listeAttributions[j].promotion.idPromo == Ados.listePromotions[i].idPromo)
                                {
                                    Ados.listeAttributions.Remove(Ados.listeAttributions[j]);
                                }
                            }
                            //Supprimer la promo
                            if (Ados.listePromotions[i] == (Promo)promo)
                            {
                                p = Ados.listePromotions[i];
                                Ados.listePromotions[i].idPromo = idPromo;
                                Ados.listePromotions.RemoveAt(i);
                            }
                            
                        }
                        for (int i = Ados.listeUtilisateurs.Count - 1; i >= 0; i--)
                        {
                            //supprimer les attenteValidation relatives aux eleves de la promo supprimée
                            for (int j = Ados.listeAttenteValidations.Count - 1; j >= 0; j-- )
                            {
                                if (Ados.listeUtilisateurs[i].idUtilisateur == Ados.listeAttenteValidations[j].utilisateur.idUtilisateur)
                                {
                                    Ados.listeAttenteValidations.Remove(Ados.listeAttenteValidations[j]);
                                }
                            }
                            //supprimer les avancementTaches relatifs aux eleves de la promo supprimée
                            for (int j = Ados.listeAvancementTaches.Count - 1; j >= 0; j-- )
                            {
                                if (Ados.listeUtilisateurs[i].idUtilisateur == Ados.listeAvancementTaches[j].utilisateur.idUtilisateur)
                                {
                                    Ados.listeAvancementTaches.Remove(Ados.listeAvancementTaches[j]);
                                }
                            }
                            //supprimer les validation relatives aux eleves de la promo supprimée
                            for(int j = Ados.listeValidations.Count - 1; j >= 0; j--)
                            {
                                if (Ados.listeUtilisateurs[i].idUtilisateur == Ados.listeValidations[j].utilisateurValider.idUtilisateur)
                                {
                                    Ados.listeValidations.Remove(Ados.listeValidations[j]);
                                }
                            }
                            //supprimer les eleves de la promo supprimée
                            foreach (Utilisateur u in p.utilisateurList)
                            {
                                if (Ados.listeUtilisateurs[i].idUtilisateur == u.idUtilisateur)
                                {
                                    Ados.listeUtilisateurs.RemoveAt(i);
                                }
                             }
                        }
                    }
                    Application.Current.MainWindow.Content = new MenuNavbar(new ListePromos());
                }
            }
            //message quand la message box à buggé.
            else if (result != MessageBoxResult.Cancel)
            {
                MessageBox.Show("Erreur Inconnue");
            }
        }

        //afficher la page de creation de promotion quand le boutton + est clické
        private void Ajouter_Promo(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MenuNavbar(new CreationModificationPromo());
        }
        
        
    }
}
