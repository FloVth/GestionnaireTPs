using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _2FAR_Library;
using _2FAR_Library.Ado;
using System.Data.SqlClient;
using System.ComponentModel;


namespace _2FAR_Gestion
{
    public partial class MainWindow : MetroWindow
    {


        public MainWindow()
        {
            Ados.GetAdos();
            
            
            InitializeComponent();
            this.Content = new PageAccueil();

            this.Closing += (object? sender, CancelEventArgs e) =>
            {
                MainWindow_Closing();
            };
              
        }

        private void MainWindow_Closing()
        {
            //exception essayer suppression et reinsertion sinon message box
            try
            {
                AdoToDB.suppressionDB();
                AdoToDB.reinsertionDB();
            } catch (Exception e)
            {
                MessageBox.Show("Réinsertion des données echouée");
            }
            
            
            
        }
    }
}