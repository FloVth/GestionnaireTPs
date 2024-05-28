using System.Windows;
using System.Windows.Controls;
using _2FAR_Library.Graphique;
using _2FAR_Library;

namespace _2FAR_Gestion.Content
{
    public partial class MenuNavbar
    {
        //contructeur de navbar avec une page en parramettre qsui serra afficher
        public MenuNavbar( Page contentPage)
        {
            InitializeComponent();
            this.grd_Menu.Children.Add(new NavBar(CreerTP, ListeTP, ListeEleve, ListePromos, ListeDemandeValidation));
            this.frm_Page.Content = contentPage;
        }
        
        //aller sur la page de creation d'un tp
        private void CreerTP()
        {
            this.frm_Page.Content = new CreationModificationTp();
        }
        //aller sur la page qui liste les tps
        private void ListeTP()
        {
            this.frm_Page.Content = new ListeTp();
        }
        //aller sur la page qui liste les élèves
        private void ListeEleve()
        {
            this.frm_Page.Content = new ListeEleves();
        }
        //aller sur la page qui liste les promotions
        private void ListePromos()
        {
            this.frm_Page.Content = new ListePromos();
        }
        //aller sur la page qui liste les demande de validation
        private void ListeDemandeValidation()
        {
            this.frm_Page.Content = new DemandeValidation();
        }
    }
}
