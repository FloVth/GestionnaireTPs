using _2FAR_Gestion.Content;
using System.Windows;

namespace _2FAR_Gestion
{


    public partial class PageAccueil
    {
        //constructeur de la page d'acceuil (1ere page que l'utilisateur voit en ouvrant l'application)
        public PageAccueil()
        {
            InitializeComponent();
        }
        
        //aller sur la page de creation d'un tp
        private void CreationTpPage(object sender, RoutedEventArgs e)
        {
            if (this.Parent is MainWindow mw)
            {
                mw.Content = new MenuNavbar(new CreationModificationTp());
            }
        }
        //aller sur la page qui liste les tps
        private void ListeTpPage (object sender, RoutedEventArgs e)
        {
            if(this.Parent is MainWindow mw)
            {
                mw.Content = new MenuNavbar(new ListeTp());
            }
        }
        //aller sur la page qui liste les élèves
        private void ListeElevePage (object sender, RoutedEventArgs e)
        {
            if(this.Parent is MainWindow mw)
            {
                mw.Content = new MenuNavbar(new ListeEleves());
            }
        }
        
        //aller sur la page qui liste les promotions
        private void ListePromosPage(object sender, RoutedEventArgs e)
        {
            if (this.Parent is MainWindow mw)
            {
                mw.Content = new MenuNavbar(new ListePromos());
            }
        }

        //aller sur la page qui liste les demande de validation
        private void DemandeValidationPage ( object sender, RoutedEventArgs e)
        {
            if(this.Parent is MainWindow mw)
            {
                mw.Content = new MenuNavbar(new DemandeValidation());
            }
        }
    }
}
