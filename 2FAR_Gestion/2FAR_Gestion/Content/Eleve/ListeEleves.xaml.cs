using _2FAR_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using _2FAR_Gestion.Content;
using _2FAR_Gestion.Content.Eleve;
using _2FAR_Library.Ado;
using Promo = _2FAR_Library.Promo;
using MahApps.Metro.Controls;

namespace _2FAR_Gestion
{
    public partial class ListeEleves 
    {
        //Constructeur de la liste des éléves
        public ListeEleves()
        {
            InitializeComponent();

            List<string> labelPromo = new List<string>();

            // afficher dans la combobox la list des promo par leurs nom
            foreach (_2FAR_Library.Promo p in Ados.listePromotions)
            {
                labelPromo.Add(p.nomPromo);
            }

            cbb_promotion.ItemsSource = labelPromo;

            dtg_liste_utilisateur.ItemsSource = Ados.listeUtilisateurs;
        }
        
        // Aller sur la page d'ajout d'éléves
        public void ajouter_eleve(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MenuNavbar(new AjouterEleve());
        }
        
        //mettre la liste de promotion en invisible
        private void cbb_promo_invisible(object sender, EventArgs e)
        {
            lbl_promotion.Visibility = Visibility.Hidden;
        }

        //action quand la texte box de recherche est cliqué
        private void tbx_recherche_est_cible(object sender, RoutedEventArgs e)
        {
            tbx_recherche.Clear();
            lbl_recherche.Visibility= Visibility.Hidden;
        }

        //action quand la texte box de recherche n'est plus ciblé dans l'application et que l'utilisateur recherche au moin 1 charactère
        private void tbx_recherche_nest_plus_cible(object sender, RoutedEventArgs e)
        {
            if (tbx_recherche.Text.Length < 1)
            {
                lbl_recherche.Visibility = Visibility.Visible;
            }
        }
        
        //action quand l'input de la texte box de recherche est changer
        private void tbx_recherche_texte_change(object sender, TextChangedEventArgs e)
        {
            List<_2FAR_Library.Utilisateur> elevesfiltrer = FiltrerEleves(tbx_recherche.Text);
            dtg_liste_utilisateur.ItemsSource =  elevesfiltrer;
        }
        
        //fonction que filtre les eleves en fonction des information selectionner par l'utilisateur Retourne une liste d'utilisateurs
        private List<_2FAR_Library.Utilisateur> FiltrerEleves(string texteRecherche)
        {
            //verification qu'une promotion est séléctioné, si c'est le cas, recherche en fonction de la promotion 
            if (cbb_promotion.Text != "")
            {
                List<_2FAR_Library.Utilisateur> utilisateurs = Ados.listeUtilisateurs.Where(Utilisateur => Utilisateur.fk_id_promo == Ados.listePromotions.Where(p => p.nomPromo == cbb_promotion.Text).First().idPromo).ToList();
                return utilisateurs.Where(Utilisateur =>
            Utilisateur.nomUtilisateur.ToLower().Contains(texteRecherche.ToLower()) ||
            Utilisateur.prenomUtilisateur.ToLower().Contains(texteRecherche.ToLower()) ||
            Utilisateur.mailUtilisateur.ToLower().Contains(texteRecherche.ToLower()))
            .ToList();
            }
            //sinon, recherche uniquement en fonction du champ de la texte box
            else
            return AdoUtilisateur.getAdoUtilisateur(Connexion.GetConn()).Where(Utilisateur =>
            Utilisateur.nomUtilisateur.ToLower().Contains(texteRecherche.ToLower()) ||
            Utilisateur.prenomUtilisateur.ToLower().Contains(texteRecherche.ToLower()) ||
            Utilisateur.mailUtilisateur.ToLower().Contains(texteRecherche.ToLower()))
            .ToList();
        }



        //action quand la selection de la liste de promotion est changer
        private void cbb_promotion_selection_change(object sender, SelectionChangedEventArgs e)
        {
            string item = (string)cbb_promotion.SelectedItem;
            List<_2FAR_Library.Utilisateur> elevesfiltrer = FiltrerElevesParPromo(item);
            dtg_liste_utilisateur.ItemsSource = elevesfiltrer;
        }

        
        //Fonction pour filtrer les éléves par promo
        private List<_2FAR_Library.Utilisateur> FiltrerElevesParPromo(string nomDePromo)
        {
            //si la recherche d'eleve retourne quelque chose, retourne les eleves de cette liste qui on la meme promo que celle passer en paramettre
            if (!string.IsNullOrEmpty(tbx_recherche.Text))
            {
                List<_2FAR_Library.Utilisateur> elevesfiltrer = FiltrerEleves(tbx_recherche.Text);
                return elevesfiltrer.Where(Utilisateur => Utilisateur.fk_id_promo == Ados.listePromotions.Where(p => p.nomPromo == nomDePromo).First().idPromo).ToList();

            }
            // sinon, retourne les eleves de cette liste qui on la meme promo que celle selectioné dans la liste de promo
            else
                return Ados.listeUtilisateurs.Where(Utilisateur => Utilisateur.fk_id_promo == Ados.listePromotions.Where(p => p.nomPromo == nomDePromo).First().idPromo).ToList();
        }
        
        //Recharge la page pour vidé tout les inputs
        private void remise_a_zero(object sender, EventArgs e)
        {
            if (tbx_recherche is TextBox)
            {
                Application.Current.MainWindow.Content = new MenuNavbar(new ListeEleves());

            }
                
        }
    }
}
