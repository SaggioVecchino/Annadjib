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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class AdminWindow : MetroWindow
    {
        public AdminWindow()
        {
            InitializeComponent();
            Commun.AdminContenu = this.Contenu;
            Contenu.Content = new View.UsrCtrl.Admin.Contenu();
            Commun.AdminLaterale = this.menuLateralAdmin;
            menuLateralAdmin.Content = new View.UsrCtrl.Admin.MenuLaterale();
            Commun.AdminTitle = this.titleAdmin;
            Commun.ConfirmationAdmin = this.Confirmation;
            titleAdmin.Content = new View.UsrCtrl.Admin.TitleAccueil();
            help.Content= new View.UsrCtrl.Admin.help();
            Commun.AdminHelp =(View.UsrCtrl.Admin.help)this.help.Content;
            Commun.window_2 = this;
            Commun.confirmSauvParamAdmin = this.ConfirmExit;//
        }
        public static void mettreAJourButtonToReturn()
        {            
            {
                Commun.AdminHelp.buttonLogOut.Visibility = Visibility.Collapsed;
                Commun.AdminHelp.buttonRetour.Visibility = Visibility.Visible;
            }
        }
        public static void mettreAJourButtonToLogOut()
        {
            if (Commun.AdminHelp != null)
            {
                Commun.AdminHelp.buttonRetour.Visibility = Visibility.Collapsed;
                Commun.AdminHelp.buttonLogOut.Visibility = Visibility.Visible;
            }
        }
    }
}
