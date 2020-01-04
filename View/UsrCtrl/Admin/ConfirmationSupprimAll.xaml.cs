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
    /// Logique d'interaction pour ConfirmationSupprimAll.xaml
    /// </summary>
    public partial class ConfirmationSupprimAll : UserControl
    {
        public ConfirmationSupprimAll()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Opacity = 1;
            Model.Utilities.listeDesEleves.Clear();
            Model.Utilities.EnregistrerListeDesEleves();
            Commun.ConfirmationAdmin.Content = null;

        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Opacity = 1;
            Commun.ConfirmationAdmin.Content = null;
        }
    }
}
