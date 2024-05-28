using System.Net.Mime;
using _2FAR_Gestion.Content.Eleve;
using _2FAR_Gestion.Content;
using System.Windows;
using _2FAR_Gestion.Content.TP;
using _2FAR_Library.Ado;
using _2FAR_Library;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Windows.Controls;

namespace _2FAR_Gestion
{
    public partial class CreationModificationTp
    {
        private TPAttribuer TPAttribuer { get; set; } = null;
        
        //constructeur pour la création d'un tp
        public CreationModificationTp()
        {
            InitializeComponent();
            dtp_date.SelectedDate = DateTime.Now;
            List<string> promo_string = new List<string>();
            foreach (var item in Ados.listePromotions)
            {
                promo_string.Add(item.nomPromo);
            }
            cbb_promo_tp.ItemsSource = promo_string;
                    
        }
        
        //constructeur pour la modification d'un tp
        public CreationModificationTp(_2FAR_Library.TPAttribuer TPAttribuer)
        {

            this.TPAttribuer = TPAttribuer;
            
            InitializeComponent();
            btn_Validation.Content = " Valider la Modification du TP";

            //recuperation des nom de promotions
            List<string> promo_string = new List<string>();
            foreach (var item in Ados.listePromotions)
            {
                promo_string.Add(item.nomPromo);
            }
            cbb_promo_tp.ItemsSource = promo_string;
            
            tbx_nom_tp.Text = TPAttribuer.tp.nomTP;
            tbx_description_tp.Text = TPAttribuer.tp.descriptionTP;

            //selection de la promotion du tpattribuer si elle existe dans la liste
            if (promo_string.Contains(TPAttribuer.promotion.nomPromo))
            {
                cbb_promo_tp.SelectedItem = TPAttribuer.promotion.nomPromo;
            }
            
            //date du datepicker = date du tpattribuer
            if (TPAttribuer.dte_fin.HasValue)
            {
                dtp_date.SelectedDate = TPAttribuer.dte_fin.Value;
            }
        }

        //creation/modification du tp
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //verfication que tt les champs sont remplits
            if (string.IsNullOrWhiteSpace(tbx_nom_tp.Text) || string.IsNullOrWhiteSpace(tbx_description_tp.Text) || string.IsNullOrWhiteSpace(cbb_promo_tp.Text) || cbb_promo_tp.SelectedItem == null || /*dtp_date.SelectedDate < DateTime.Now ||*/ dtp_date.SelectedDate == null)
            {
                MessageBox.Show("Erreur, tout les champs sont obligatoire", "Vérification", MessageBoxButton.OK);
            }
            //si la verification est passer sans echec
            else
            {
                //verification que la prommotion de l'élève existe
                _2FAR_Library.Promo promoEleve = null;
                foreach (var p in Ados.listePromotions)
                {
                    if (cbb_promo_tp.Text == p.nomPromo)
                    {
                        promoEleve = p; 
                    }
                }
                //si elle n'este pas:
                if (promoEleve == null)
                {
                    MessageBox.Show("Erreur, la promo n'existe pas", "Vérification", MessageBoxButton.OK);
                }
                //si elle existe:
                else
                {
                    //si cest une modification, recreer le tp et l'atribution avec les nouvelles infomations mais les anciens ids et renvoyer sur la liste de tp
                    if (TPAttribuer != null)
                    {
                        Ados.listeTP.Remove(Ados.listeTP.Where(Tp => Tp.idTP == TPAttribuer.tp.idTP).First());
                        Ados.listeTP.Add(new TP(TPAttribuer.tp.idTP, tbx_nom_tp.Text, tbx_description_tp.Text));
                        
                        Ados.listeAttributions.Remove(Ados.listeAttributions.Where(at => at.promotion.nomPromo == TPAttribuer.promotion.nomPromo && at.tp.idTP == TPAttribuer.tp.idTP).First());
                        Ados.listeAttributions.Add(new TPAttribuer(dtp_date.SelectedDate.Value, TPAttribuer.is_actif, Ados.listeTP.Where(Tp => Tp.idTP == TPAttribuer.tp.idTP).First(),Ados.listePromotions.Where(Promo => Promo.nomPromo == cbb_promo_tp.SelectedItem).First() ));

                        Application.Current.MainWindow.Content = new MenuNavbar(new ListeTp());
                        // return est utilisé pour ne pas acceder a la page tache tp
                        return;
                    }
                    //sinon creer le tp et l'atribution et renvoyer sur la liste de tp
                    else
                    {
                        Ados.listeTP.Add(new TP(Ados.listeTP.Last().idTP + 1, tbx_nom_tp.Text, tbx_description_tp.Text));
                        Ados.listeAttributions.Add(new TPAttribuer((DateTime)dtp_date.SelectedDate, true, Ados.listeTP.Last(), promoEleve));
                    }

                    Application.Current.MainWindow.Content = new MenuNavbar(new CreationTachesTp(Ados.listeTP.Last()));
                }
            }
        }
        
        private void fontchange(object sender, SizeChangedEventArgs e ) 
        {
            AdjustDatePickerFontSize();
        }

        private void AdjustDatePickerFontSize()
        {
            // Ajuster la taille de police en fonction de la taille de la fenêtre
            double newFontSize = CalculateResponsiveFontSize();

            // Appliquer la nouvelle taille de police au DatePicker
            dtp_date.FontSize = newFontSize;
            cbb_promo_tp.FontSize = newFontSize-4;
        }

        private double CalculateResponsiveFontSize()
        {
            // Vous pouvez définir votre propre logique pour calculer la taille de police en fonction de la taille de la fenêtre,
            // la résolution de l'écran, ou tout autre critère.

            // Par exemple, vous pouvez utiliser une formule proportionnelle en fonction de la largeur de la fenêtre :
            double ratio = this.ActualWidth / 800.0; // Ajustez 800 en fonction de vos besoins
            double baseFontSize = 15; // Taille de police de base
            double newFontSize = baseFontSize * ratio;

            // Assurez-vous que la nouvelle taille de police ne devient pas trop petite ou trop grande
            newFontSize = Math.Max(newFontSize, 15.0); // Taille minimale
            newFontSize = Math.Min(newFontSize, 35.0); // Taille maximale

            return newFontSize;
        }
    }
 }
