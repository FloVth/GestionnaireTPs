using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2FAR_Library.Graphique
{
    internal class Button_icon : Button
    {
        public Button_icon(string name, int SizeWidth, int SizeHeight, Action click)
        {
            // définit la taille du button
            Width = SizeWidth;
            Height = SizeHeight;

            // définit un icon au button
            Content = new PackIconModern
            {
                Kind = (PackIconModernKind)Enum.Parse(typeof(PackIconModernKind), name),
                Height = SizeHeight / 1.75,
                Width = SizeWidth / 1.75,
            };

            // bordur de 0
            BorderThickness = new Thickness(0);
            // couleur du logo white et fond transparent
            Foreground = Brushes.White;
            Background = Brushes.Transparent;

            // taille du logo = a la SizeHeight
            FontSize = SizeHeight;
            Margin = new Thickness(0, 20, 0, 0);

            // Gestionnaire de click pour l'action
            Click += (sender, e) => click.Invoke();
        }
    }

    public class Btn : Button
    {
        public Btn(string name, Action<object, EventArgs> click)
        {
            // positionnement Alignement
            HorizontalAlignment = HorizontalAlignment.Right;
            VerticalAlignment = VerticalAlignment.Center;
            // définition de la couleur blanche 
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("white"));
            //margin de 20 a droite
            Margin = new Thickness(0, 0, 20, 0);
            // text du button = a name
            Content = name;
            // background couleur violet
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5e17eb"));
            // couleur de la font en white
            Foreground = brush;
            // Gestionnaire de click pour action
            Click += (sender, e) => click(sender, e);

        }
    }

}
