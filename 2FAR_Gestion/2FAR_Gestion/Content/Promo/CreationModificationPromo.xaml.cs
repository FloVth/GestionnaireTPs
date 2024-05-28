using _2FAR_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2FAR_Gestion.Content.Promo
{
    /// <summary>
    /// Logique d'interaction pour ActionPromos.xaml
    /// </summary>
    public partial class CreationModificationPromo : Page
    {
        private string ancienNom = String.Empty;
        
        //construction pour la création d'une promotion
        public CreationModificationPromo()
        {
            InitializeComponent();
        }

        //constructeur pour la modification d'une promotion
        public CreationModificationPromo(_2FAR_Library.Promo p)
        {
            ancienNom = p.nomPromo;
            InitializeComponent();

            lb_title.Content = "Modifier Une Promotion";
            tbx_nomPromo.Text = p.nomPromo;
        }

        //btn ajouter / modifier clické
        private void Boutton_clicke(object sender, RoutedEventArgs e)
        {
            //vérifier que l'entrée utilisateur est valide
            if (string.IsNullOrEmpty(tbx_nomPromo.Text))
            {
                //si entrée vide, l'indique à l'aide d'une messageBox
                MessageBox.Show("Veuillez remplir un nom avant d'ajouter");
                return;
            }
            else
            {
                //verifier que la promotion n'existe pas deja
                foreach (var p in Ados.listePromotions)
                {
                    if (p.nomPromo == tbx_nomPromo.Text)
                    {
                        MessageBox.Show("Cette promotion existe déjà.");
                        return;
                    }
                }
                if (ancienNom != String.Empty)
                {
                    //sinon, si la variable "ancien nom" a une valeur, renomer la promotion avec le nouveau nom
                    Ados.listePromotions.Where(p => p.nomPromo == ancienNom).First().nomPromo = tbx_nomPromo.Text;
                }
                else
                {
                    //sinon, cree la promotion
                    Ados.listePromotions.Add(new _2FAR_Library.Promo(Ados.listePromotions.Last().idPromo + 1, tbx_nomPromo.Text));
                }
            }
            //renvoyer sur la liste des promotions
            Application.Current.MainWindow.Content = new MenuNavbar(new ListePromos());
        }
    }
}

