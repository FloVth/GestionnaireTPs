using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using _2FAR_Library.Graphique;
using System.Reflection.Metadata;
using MahApps.Metro.Controls;
using System.Windows.Media.Converters;

namespace _2FAR_Library
{
    public class Form_taches : Grid
    {
        public bool valide { get; set; }
        
        private NumericUpDown nud_ordre {  get; set; }

        private TextBox tbx_intitule { get; set; }

        private TextBox tbx_desc {  get; set; }

        private NumericUpDown nud_point { get; set; }

        private CheckBox ckb_checkpoint { get; set; }

        private CheckBox ckb_bonus { get; set; }



        public int ordre { get; set; }
        public string? intitule { get; set; }
        public string? desc { get; set; }
        public int points { get; set; }
        public bool checkpoint {  get; set; }
        public bool bonus { get; set; }
        
       

        public Form_taches() 
        {   
            // défini le fond en violet
            // position de la form_taches
            this.HorizontalAlignment = HorizontalAlignment.Center;
            // épaisseur de 40 en dessus de la form_tache
            this.Margin = new Thickness(0,0,0,40);


            var myBorder = new Border();
            myBorder.Background = (new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#5e17eb")));
            myBorder.BorderBrush = Brushes.Black;
            myBorder.BorderThickness = new Thickness(2);
            myBorder.CornerRadius = new CornerRadius(45);
            myBorder.Padding = new Thickness(115);
            Grid.SetColumn(myBorder, 0);
            Grid.SetColumnSpan(myBorder, 3);
            Grid.SetRow(myBorder, 0);
            Grid.SetRowSpan(myBorder, 7);
            this.Children.Add(myBorder);


            for (int i = 0; i < 8; i++) //faire 8 lignes
            {
                this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
            }

            for (int i = 0; i < 3; i++) //faire 3 colonnes
            {
                this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }


            Label titre_ordre = new Label();
            // Défini le texte de titre_ordre
            titre_ordre.Content = "ordre";
            // postionnement de titre_ordre
            titre_ordre.HorizontalAlignment = HorizontalAlignment.Center;
            titre_ordre.VerticalAlignment = VerticalAlignment.Center;
            // taille établie a 12
            titre_ordre.FontSize = 12;

            // Police en Blanc et en Gras
            titre_ordre.Foreground = Brushes.White;
            titre_ordre.FontWeight = FontWeights.Bold;

            // Positionnement de titre_ordre en colonne 0 ligne 1
            Grid.SetColumn(titre_ordre, 0);
            Grid.SetRow(titre_ordre, 1);

            // Ajoute de titre ordre en enfant de form_tache
            this.Children.Add(titre_ordre);



            
            // box de chiffre
            nud_ordre = new NumericUpDown();
            // margin de 20 en bas
            nud_ordre.Margin = new Thickness(0,0,0,20);
            // fond en blanc
            nud_ordre.Background = Brushes.White;
            // cache les button up & down
            nud_ordre.HideUpDownButtons = true;
            // box visible
            nud_ordre.Visibility = Visibility.Visible;
            // définit la taille a 100
            nud_ordre.Width = 100;
            // positionnement de la box
            nud_ordre.HorizontalAlignment = HorizontalAlignment.Center;

            // position de la box de chiffre en colone 0 et en ligne 2
            Grid.SetColumn(nud_ordre, 0);
            Grid.SetRow(nud_ordre, 2);
            // Ajout du label en tant qu'enfant de form_tach
            this.Children.Add(nud_ordre);



            Label titre_intitule = new Label();
            // définit le text
            titre_intitule.Content = "Intitulé";
            // positionnement du label
            titre_intitule.HorizontalAlignment = HorizontalAlignment.Center;
            titre_intitule.VerticalAlignment = VerticalAlignment.Center;
            // établie la taille a 12
            titre_intitule.FontSize = 12;

            // met la couleur de la font en blanc et en gras
            titre_intitule.Foreground = Brushes.White;
            titre_intitule.FontWeight = FontWeights.Bold;

            // position de la box de chiffre en colone 0 et en ligne 3
            Grid.SetColumn(titre_intitule, 0);
            Grid.SetRow(titre_intitule, 3);
            // Ajout du label en tant qu'enfant de form_tach
            this.Children.Add(titre_intitule);



            tbx_intitule = new TextBox();
            //met une margin a 40 a left et 5 en bas
            tbx_intitule.Margin = new Thickness(40, 0, 0, 5);
            // Défini la width a 400
            tbx_intitule.Width = 400;

            // position de la textbox en colone 0 et en ligne 4
            Grid.SetColumn(tbx_intitule, 0);
            Grid.SetRow(tbx_intitule, 4);
            // Ajout du textbox en tant qu'enfant de form_tach
            this.Children.Add(tbx_intitule);


            Label titre_desc = new Label();
            // définit le text
            titre_desc.Content = "Description";
            // positionnement du label
            titre_desc.HorizontalAlignment = HorizontalAlignment.Center;
            titre_desc.VerticalAlignment = VerticalAlignment.Center;
            // établie la taille a 12
            titre_desc.FontSize = 12;
            // met la couleur de la font en blanc et en gras
            titre_desc.Foreground = Brushes.White;
            titre_desc.FontWeight = FontWeights.Bold;

            // position de label en colone 1 et en ligne 3

            Grid.SetColumn(titre_desc, 1);
            Grid.SetRow(titre_desc, 3);

            this.Children.Add(titre_desc);



            tbx_desc = new TextBox();
            //met une margin a 40 a left et 5 en bas et en haut et 15 a droite
            tbx_desc.Margin = new Thickness(40, 5, 15, 5);
            // Défini la width a 400
            tbx_desc.MinWidth = 400;
            // position de textbox en colone 1 et en ligne 4 et prend 2 colonne  
            Grid.SetColumn(tbx_desc, 1);
            Grid.SetRow(tbx_desc, 4);
            Grid.SetColumnSpan(tbx_desc, 2);
            // Ajout du textbox en tant qu'enfant de form_tach
            this.Children.Add(tbx_desc);



            Label titre_point = new Label();
            // définit le text
            titre_point.Content = "Points";
            // positionnement du label
            titre_point.HorizontalAlignment = HorizontalAlignment.Center;
            titre_point.VerticalAlignment = VerticalAlignment.Center;
            // établie la taille a 12
            titre_point.FontSize = 12;
            // met la couleur de la font en blanc et en gras
            titre_point.Foreground = Brushes.White;
            titre_point.FontWeight = FontWeights.Bold;
            // position de textbox en colone 0 et en ligne 5  
            Grid.SetColumn(titre_point, 0);
            Grid.SetRow(titre_point, 5);
            this.Children.Add(titre_point);



            nud_point = new NumericUpDown();
            //met une margin a 20 en bas
            nud_point.Margin = new Thickness(0, 0, 0, 20);
            // met la couleur du fond en blanc 
            nud_point.Background = Brushes.White;
            // cache les button up & down
            nud_point.HideUpDownButtons = true;
            // box visible
            nud_point.Visibility = Visibility.Visible;
            // définit la taille a 100
            nud_point.Width = 100;
            // positionnement
            nud_point.HorizontalAlignment = HorizontalAlignment.Center;
            // position de num en colone 0 et en ligne 6  
            Grid.SetColumn(nud_point, 0);
            Grid.SetRow(nud_point, 6);
            // ajoute la num en enfant de form_tache
            this.Children.Add(nud_point);



            Label titre_checkpoint = new Label();
            // défini le text de checkpoint
            titre_checkpoint.Content = "Checkpoints";
            // défini le positionnement
            titre_checkpoint.HorizontalAlignment = HorizontalAlignment.Center;
            titre_checkpoint.VerticalAlignment = VerticalAlignment.Center;
            // ajuste la taille de la font a 12
            titre_checkpoint.FontSize = 12;
            // met la font en blanc et gras
            titre_checkpoint.Foreground = Brushes.White;
            titre_checkpoint.FontWeight = FontWeights.Bold;
            // met le label en position colonne 1 et ligne 5
            Grid.SetColumn(titre_checkpoint, 1);
            Grid.SetRow(titre_checkpoint, 5);
            // ajoute l'enfant a form_tache
            this.Children.Add(titre_checkpoint);



            ckb_checkpoint = new CheckBox();
            // défini le positionnement
            ckb_checkpoint.HorizontalAlignment = HorizontalAlignment.Center;
            ckb_checkpoint.VerticalAlignment = VerticalAlignment.Center;
            // positionne en colonne 1 et ligne 6
            Grid.SetColumn(ckb_checkpoint, 1);
            Grid.SetRow(ckb_checkpoint, 6);
            // ajoute enfant de form_tache
            this.Children.Add(ckb_checkpoint);



            Label titre_bonus = new Label();
            // défini le text de checkpoint
            titre_bonus.Content = "Bonus";
            // défini le positionnement
            titre_bonus.HorizontalAlignment = HorizontalAlignment.Center;
            titre_bonus.VerticalAlignment = VerticalAlignment.Center;
            // ajuste la taille de la font a 12
            titre_bonus.FontSize = 12;
            // met la font en blanc et gras
            titre_bonus.Foreground = Brushes.White;
            titre_bonus.FontWeight = FontWeights.Bold;

            // positionne en colonne 2 et ligne 5
            Grid.SetColumn(titre_bonus, 2);
            Grid.SetRow(titre_bonus, 5);
            // ajoute enfant a form_tache
            this.Children.Add(titre_bonus);


            ckb_bonus = new CheckBox();
            // défini le positionnement
            ckb_bonus.HorizontalAlignment = HorizontalAlignment.Center;
            ckb_bonus.VerticalAlignment = VerticalAlignment.Center;
            // positionne en colonne 2 et ligne 6
            Grid.SetColumn(ckb_bonus, 2);
            Grid.SetRow(ckb_bonus, 6);
            // ajoute enfant a form_tache
            this.Children.Add(ckb_bonus);

        }

        // returne ckb_bonus
        public CheckBox GetCkb_bonus()
        {
            return ckb_bonus;
        }

        // défini les valeurs entré par l'utilisateur
        public void GetFieldValues(CheckBox ckb_bonus)
        {
                ordre = Convert.ToInt32(nud_ordre.Value);
                intitule = tbx_intitule.Text;
                desc = tbx_desc.Text;
                points = Convert.ToInt32(nud_point.Value);
                checkpoint = Convert.ToBoolean(ckb_checkpoint.IsChecked);
                bonus = Convert.ToBoolean(ckb_bonus.IsChecked);
        }

        // vérifie si les champs sont complet ou conforme 
        public Boolean ChampsComplet(double? ordre, string intitule, string desc, double? points)
        {
            if (ordre < 0 || ordre > 20  || intitule == string.Empty || intitule == null || intitule == "" || desc == string.Empty || desc == null || desc == "" || points < 0 || points >5)
            { 
                return valide = false;
            }

            else
            {
                return valide = true;
            }         
        }



    }
}
