using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using _2FAR_Library;

namespace _2FAR_Gestion.Content.Promo;

public partial class StatsTpPromo : Page
{
    //constructeur en fonction d'un tp
    public StatsTpPromo(_2FAR_Library.TP tp)
    {
        List<_2FAR_Library.Tache> tachesDuTp = Ados.listeTaches.Where(tache => tache.fk_id_tp == tp.idTP).ToList();

        InitializeComponent();
        //affichage des stats si il y a un tp
        if (tachesDuTp != null)
        {
            //creer une entete et l'afficher
            stp_liste_stats.Children.Add(new ConstructeurDeGrid(null));
            //pour chaques tache, cree une grid de statistiques et l'afficher
            foreach (var tache in tachesDuTp)
            {
                stp_liste_stats.Children.Add(new ConstructeurDeGrid(tache));
            }
        }
        //sinon afficher une erreur
        else
        {
            MessageBox.Show("Il n'y a aucune tache dans ce tp");
        }
    }
}


public class ConstructeurDeGrid : Grid
{
    public ConstructeurDeGrid(_2FAR_Library.Tache t)
    {
        //formatage de la grid (ajout des columns ...)
        for (int i = 6; i > 0; i--)
        {
            ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) } );
        }
        RowDefinitions.Add(new RowDefinition{ Height = new GridLength(1, GridUnitType.Auto)} );
        
        // si la tache est null, créé une entete
        if (t == null)
        {
            List<string> nomLabelListe = new List<string>() { "Tâche", "0%", "<50%", ">= 50%", "100%", "Total" };
            foreach (var str in nomLabelListe)
            {
                LabelToAdd lbl = new LabelToAdd(str, 15, true);
                Grid.SetColumn(lbl, nomLabelListe.IndexOf(str));
                this.Children.Add(lbl);
            }
        }
        //Sinon, cree une ligne de statistique pour la tache
        else
        {
                int pasCommence = 0;
                int infCinquante = 0;
                int supCinquante = 0;
                int finit = 0;
                
                //calcule de la ou en  sont les élèves pour la tache du tp (nombre deleves par "palier")
                foreach (var avancementTache in Ados.listeAvancementTaches.Where(ta => ta.tache.idTache == t.idTache))
                {
                    if (avancementTache.taux_avancement == 0)
                        pasCommence += 1;

                    else if (avancementTache.taux_avancement < 50)
                        infCinquante += 1;

                    else if (avancementTache.taux_avancement >= 50 && avancementTache.taux_avancement < 100)
                        supCinquante += 1;

                    else
                        finit += 1;
                    
                }
                
                //ecrire toute les données dans des labels préformaté et les mettres à la bonne place dans la grid
                LabelToAdd lbl = new LabelToAdd(t.titreTache, 13, true);
                Grid.SetColumn(lbl, 0);
                Grid.SetRow(lbl, 0);
                this.Children.Add(lbl);
                
                lbl = new LabelToAdd(pasCommence.ToString(), 13, false);
                Grid.SetColumn(lbl, 1);
                Grid.SetRow(lbl, 0);
                this.Children.Add(lbl);
                
                lbl = new LabelToAdd(infCinquante.ToString(), 13, false);
                Grid.SetColumn(lbl, 2);
                Grid.SetRow(lbl, 0);
                this.Children.Add(lbl);
                
                lbl = new LabelToAdd(supCinquante.ToString(), 13, false);
                Grid.SetColumn(lbl, 3);
                Grid.SetRow(lbl, 0);
                this.Children.Add(lbl);
                
                lbl = new LabelToAdd(finit.ToString(), 13, false);
                Grid.SetColumn(lbl, 4);
                Grid.SetRow(lbl, 0);
                this.Children.Add(lbl);
                
                lbl = new LabelToAdd((pasCommence + infCinquante + supCinquante + finit).ToString(), 13, false);
                Grid.SetColumn(lbl, 5);
                Grid.SetRow(lbl, 0);
                this.Children.Add(lbl);
        }
    }
}

//creer rapidement des labels préformaté
public class LabelToAdd : Label
{
    public LabelToAdd(string text, double size, bool isbold)
    {
        Content = text;
        FontSize = size;
        HorizontalContentAlignment = HorizontalAlignment.Center;
        HorizontalAlignment = HorizontalAlignment.Center;
        VerticalContentAlignment = VerticalAlignment.Center;
        VerticalAlignment = VerticalAlignment.Center;

        Padding = new Thickness(7, 7, 7, 7);
        
        if (isbold)
        {
            FontWeight = FontWeights.Bold;
        }
    }
}