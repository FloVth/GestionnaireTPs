using _2FAR_Library.Graphique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Btn = _2FAR_Library.Graphique.Btn;

namespace _2FAR_Library
{
    public class Carte : Border
    {
        // création d'un objet pour passé un object dans la carte
        public object? objectCarte;
        public Carte(string title, string content, Dictionary<string, Action<object , EventArgs >> actionButtons, int TitleSize, int DescSize, object? objetcarte)
        {
            // bordure de couleur violet  de taille 1
            BorderBrush = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#5e17eb"));
            BorderThickness = new Thickness(1);

            // positionnement de la carte
            this.HorizontalAlignment = HorizontalAlignment.Stretch;

            // margin de 20 autour de la carte
            this.Margin = new Thickness(20, 20, 20, 20);

            //je passe l'objet carte du constructeur en variable
            objectCarte = objetcarte;

            // crée une grid de 3 colonnes
            Grid grid = new Grid();
            for (int i = 0; i < 3; i++) //faire 3 column
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // met un margin de 20 autour de la grid
            grid.Margin = new Thickness(20, 20, 20, 20);

            // ajoute la grid en tant qu'enfant
            Child = grid;

            // crée une nouvelle frame
            Frame card = new Frame();
            // met le background en violet
            card.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5e17eb"));

            // positionnement de la frame 
            card.HorizontalAlignment = HorizontalAlignment.Stretch;
            card.VerticalAlignment = VerticalAlignment.Stretch;

            // positon de la frame dans la grid en position colonne 0
            Grid.SetColumn(card, 0);
            // ajout de la frame en tant qu'enfant
            grid.Children.Add(card);
            

            // crée un textblock
            TextBlock cardTitle = new TextBlock();

            // positionnement du textblock
            cardTitle.HorizontalAlignment = HorizontalAlignment.Center;
            cardTitle.VerticalAlignment = VerticalAlignment.Center;

            // défini le text du texblock par la variable
            cardTitle.Text = title;
            // Défini le texte qui revient a la ligne automatiquement
            cardTitle.TextWrapping = TextWrapping.Wrap;
            // couleur de la font en blanc
            cardTitle.Foreground = Brushes.White;
            // défini la taille de la font
            cardTitle.FontSize = TitleSize;
            // défini l'épaisseur de la font
            cardTitle.FontWeight = FontWeights.Bold;
            // défini un margin de 5 autour de la texblock
            cardTitle.Margin = new Thickness(5, 5, 5, 5);
            // défini le contenu de la card par la textbox
            card.Content = cardTitle;

            // crée un nouveau textblock
            TextBlock cardContent = new TextBlock();
            // Défini le texte qui revient a la ligne automatiquement
            cardContent.TextWrapping = TextWrapping.Wrap;
            // positionnement du textblock
            cardContent.HorizontalAlignment = HorizontalAlignment.Center;
            cardContent.VerticalAlignment = VerticalAlignment.Center;
            // défini le text du texblock par la variable
            cardContent.Text = content;
            // couleur de la font en blanc
            cardContent.Foreground = Brushes.Black;
            // défini la taille de la font
            cardContent.FontSize = DescSize;
            // défini l'épaisseur de la font
            cardContent.FontWeight = FontWeights.Bold;
            // défini un padding de 15 a l'interieur de la texblock
            cardContent.Padding = new Thickness(15);

            // position de la textbloc dans la grid en position colonne 1
            Grid.SetColumn(cardContent, 1);
            // L'ajout en tant qu'enfant a la grid
            grid.Children.Add(cardContent);


            // Crée un stackPanel
            StackPanel stackPanel = new StackPanel();
            // Positionnement du stackPanel
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;

           
            if (actionButtons != null)
            {
                // pour chaque action dans le dictionnaire actionbutton
                foreach (var action in actionButtons)
                {
                    // Crée un nouveau btn avec comme param le nom de l'action et l'action
                    Btn button = new Btn(action.Key, action.Value);
                    // margin de 5 en haut et en bas du button
                    button.Margin = new Thickness(0, 5, 0, 5);
                    // Positionnement du button
                    button.HorizontalAlignment = HorizontalAlignment.Stretch;
                    button.VerticalAlignment = VerticalAlignment.Stretch;
                    // Taille du button
                    button.Height = 40;

                    if (action.Key == "Supprimer")
                    {
                        // Mettre le button supprimer en rouge
                        button.Background = Brushes.Red;
                    }
                    if (action.Key == "Statistiques")
                    {
                        // Mettre le button stat en vert
                        button.Background = Brushes.ForestGreen;
                    }
                    // ajoute le buttons au stackpanel
                    stackPanel.Children.Add(button);
                } 
            }
            // position le stackPanel a la position colonne 2 de la grid
            Grid.SetColumn(stackPanel, 2);
            // ajoute le stack panel a la grid
            grid.Children.Add(stackPanel);
        }
    }
}
