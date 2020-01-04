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
using Projet.UserControls.ELEVE;
namespace Projet.UserControls.GENERAL
{
    /// <summary>
    /// Logique d'interaction pour APropos.xaml
    /// </summary>
    public partial class APropos : UserControl
    {
        public APropos()
        {
            InitializeComponent();
            if (!Commun.AdminConnecte) EleveWindow.mettreAJourButtonToReturn();
            else
            {
                AdminWindow.mettreAJourButtonToReturn();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            if (!Commun.AdminConnecte) EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
            else
            {
                Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
            } 
        }
    }
}
