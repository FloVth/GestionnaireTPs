using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using _2FAR_Gestion.Content.TP;
using _2FAR_Library;
using _2FAR_Library.Graphique;
using SkiaSharp;

namespace _2FAR_Gestion.Content.Promo;

public partial class ListeTpPromos
{
    //instentiation de la liste des tp en fonction du promotion a l'ouverture de la page.
    public ListeTpPromos(_2FAR_Library.Promo promo)
    {
        InitializeComponent();
        foreach (var TPAttribuer in Ados.listeAttributions)
            if (TPAttribuer.promotion.idPromo == promo.idPromo)
                stp_liste_tp.Children.Add(new Carte(TPAttribuer.tp.nomTP, TPAttribuer.tp.descriptionTP, new Dictionary<string, Action<object, EventArgs>>{ {"Statistiques",statistiques}, {"Notes",note}, { "Modifier",modifier}},20,15,TPAttribuer.tp));
    }

    //afficher la page de statistiques du tp quand le boutton est clické
    private void statistiques(object o, EventArgs e)
    {
        if (o is Btn b && b.Parent is StackPanel s && s.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.TP tp)
        {
            Application.Current.MainWindow.Content = new MenuNavbar(new StatsTpPromo(tp));
        }
    }
    //afficher la page de modification d'un tp quand le boutton est clické

    private void modifier(object o, EventArgs e)
    {
        if (o is Btn b && b.Parent is StackPanel s && s.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.TP tp)
        {
            Application.Current.MainWindow.Content = new MenuNavbar(new CreationModificationTp(Ados.listeAttributions.Where(at => at.tp.idTP == tp.idTP).First()));
        }
    }
    private void note (object o, EventArgs e )
    {
        if (o is Btn b && b.Parent is StackPanel s && s.Parent is Grid g && g.Parent is Carte c && c.objectCarte is _2FAR_Library.TP tp)
        {
            _2FAR_Library.Promo promotion = null;
            foreach (var attribuer in Ados.listeAttributions)
            {
                if(attribuer.tp.idTP == tp.idTP)
                {
                     promotion = attribuer.promotion;
                }
            }
            Application.Current.MainWindow.Content = new MenuNavbar(new ListeNoteTp(tp, promotion ));
        }

    }
}