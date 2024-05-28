using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;



namespace _2FAR_Library.Graphique
{
    public class NavBar : StackPanel
    {
        public NavBar(Action PageCreateTp, Action PageListTP, Action PageVoirEleves, Action PageVoirPromos, Action DemandeValidation)
        {
            // position le stack panel en colonne 0
            Grid.SetColumn(this, 0);

            // Créer un pinceau avec la couleur hexadécimale
            var brush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#5e17eb"));
            Background = brush;
            // défini une width de 100
            Width = 100;
            // ajout un nouveau button avec comme taille 60*60 qui effectue l'action PageCreateTp
            Button_icon btnIco = new Button_icon("CabinetFiles", 60, 60, PageCreateTp);
            btnIco.ToolTip = "Crée un TP";
            Children.Add(btnIco);
            // ajout un nouveau button avec comme taille 60*60 qui effectue l'action PageListTP
            btnIco = new Button_icon("CabinetFilesVariant", 60, 60, PageListTP);
            btnIco.ToolTip = "Liste des TP";
            Children.Add(btnIco);
            // ajout un nouveau button avec comme taille 60*60 qui effectue l'action PageVoirEleve
            btnIco = new Button_icon("People", 60, 60, PageVoirEleves);
            btnIco.ToolTip = "Voir Les Eleves";
            Children.Add(btnIco);
            // ajout un nouveau button avec comme taille 60*60 qui effectue l'action PageVoirPromo
            btnIco = new Button_icon("PeopleMultiple", 60, 60, PageVoirPromos);
            btnIco.ToolTip = "Voir Les Promos";
            Children.Add(btnIco);
            // ajout un nouveau button avec comme taille 60*60 qui effectue l'action DemandeValidation
            btnIco = new Button_icon("Check", 60, 60, DemandeValidation);
            btnIco.ToolTip = "Voir Les Demandes De Validation";
            Children.Add(btnIco);
        }

    }

}
