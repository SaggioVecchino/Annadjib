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
using Projet.UserControls.LOGIN;
using Projet.Model;

namespace Projet.UserControls.LOGIN
{
    /// <summary>
    /// Logique d'interaction pour firstPage.xaml
    /// </summary>
    public partial class LoginChooseType : UserControl
    {
        public LoginChooseType()
        {
            InitializeComponent();
        }

        private void buttonEleve_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ChargerEleves();
            if (Utilities.listeDesEleves.Count > 0)
            {
                Commun.contentControl_.Content = new LogSignUser();
            }
            else
            {
                Commun.contentControl_.Content = new formulaire();
            }
        }
        

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            Commun.contentControl_.Content = new AdminSign();
        }
    }
}
