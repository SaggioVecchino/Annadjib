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
    /// Logique d'interaction pour help.xaml
    /// </summary>
    public partial class help : UserControl
    {
        public help()
        {
            InitializeComponent();
        }
        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow w = new LoginWindow();
            w.Show();
            Commun.window_2.Close();
        }

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            if (helpBox.Visibility == Visibility.Collapsed) helpBox.Visibility = Visibility.Visible;
            else helpBox.Visibility = Visibility.Collapsed;
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
            Commun.AdminTitle.Content = new View.UsrCtrl.Admin.TitleAccueil();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            helpBox.Visibility = Visibility.Collapsed;
        }
    }
}
