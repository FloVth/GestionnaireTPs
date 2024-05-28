using System.Collections.Generic;
using System.Linq;
using System.Windows;
using _2FAR_Library;

namespace _2FAR_Gestion.Content.Eleve
{
    public partial class AjouterEleve
    {
        //constructeur d'ajout d'eleves
        public AjouterEleve()
        {
            InitializeComponent();
            
            //verification qu'il y a au moin une promotion sinon erreur
            if (Ados.listePromotions != null)
            {

                List<string> labelPromo = new List<string>();

                foreach (_2FAR_Library.Promo p in Ados.listePromotions)
                {
                    labelPromo.Add(p.nomPromo);
                }

                cbb_promo.ItemsSource = labelPromo;
                cbb_promo.SelectedItem = cbb_promo.Items[0];
            }
            else
                MessageBox.Show("Il n'y a pas de promotion, vous ne pourrez pas créé d'éléves", "Vérification", MessageBoxButton.OK);
        }
        
        //valider la creation d'un éléve
        private void Valider_OnClick(object sender, RoutedEventArgs e)
        {
            //verification du remplissage des champs
            if (string.IsNullOrWhiteSpace(tbx_nom.Text) || string.IsNullOrWhiteSpace(tbx_prenom.Text) || string.IsNullOrWhiteSpace(tbx_mail.Text) || string.IsNullOrWhiteSpace(tbx_mdp.Text) || string.IsNullOrWhiteSpace(cbb_promo.Text) || cbb_promo.SelectedItem == null)
            {
                MessageBox.Show("Erreur, tout les champs sont obligatoire", "Vérification", MessageBoxButton.OK);
            }
            else
            { 
                //creation de l'eleve avec un promotion qui existe, sinon mettre une erreur
                _2FAR_Library.Promo promoEleve = Ados.listePromotions.Where(p => p.nomPromo == cbb_promo.Text).First();
                if (promoEleve == null)
                {
                    MessageBox.Show("Erreur, la promo n'existe pas", "Vérification", MessageBoxButton.OK);
                    return;
                }
                else
                    Ados.listeUtilisateurs.Add(new Utilisateur(Ados.listeUtilisateurs.Count == 0? 1: Ados.listeUtilisateurs.Last().idUtilisateur + 1 , tbx_nom.Text, tbx_prenom.Text, tbx_mail.Text, tbx_mdp.Text, false, promoEleve.idPromo, promoEleve.nomPromo));
                //retour sur la liste des éléves.
                Application.Current.MainWindow.Content = new MenuNavbar(new ListeEleves());

            }
        }
    }
}
