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

namespace Projet.View.UsrCtrl.Admin
{
    /// <summary>
    /// Logique d'interaction pour MenuLaterale.xaml
    /// </summary>
    public partial class MenuLaterale : UserControl
    {
        public MenuLaterale()
        {
            InitializeComponent();
        }

        private void buttonParam_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Content = new View.UsrCtrl.Admin.parametresAdmin();
            Commun.AdminContenu.Visibility = Visibility.Visible;
            Commun.AdminTitle.Content = new View.UsrCtrl.Admin.TitleParametres();
        }

        private void buttonAPropos_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Content = new UserControls.GENERAL.APropos();
            Commun.AdminTitle.Content = new View.UsrCtrl.Admin.TitleAccueil();
            Commun.AdminTitle.Content = new TopBarAPropos();
            Commun.AdminContenu.Visibility = Visibility.Visible;
        }
    }
}
