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
    /// Logique d'interaction pour adminSign.xaml
    /// </summary>
    public partial class AdminSign:UserControl
    {
        public AdminSign()
        {
            InitializeComponent();
            Model.Admin admin = Model.Utilities.ChargerAdmin();
            nomEcole.DataContext = admin;
            if ( !admin.passwordChanged)
            passwordPlaceHolder.ToolTip = "كلمة السر الحالية هي ’admin’ الرجاء منك الدخول وتغيرها";
        }
        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            Commun.contentControl_.Content = new LoginChooseType();
        }

        private void buttonEntrer_Click(object sender, RoutedEventArgs e)
        {
            Model.Admin admin = Model.Admin.AuthentificationAdmin(passwordBox.Password);
            if (admin == null)
            {
                erreurPassword.Text = "كلمة المرور خاطئة";
                erreurPassword.Visibility = Visibility.Visible;
            }
            else
            {
                Commun.AdminConnecte = true;
                AdminWindow s = new AdminWindow();
                s.Show();
                Commun.window_.Close();
            }
        }

        private void passwordPlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordPlaceHolder.Visibility = Visibility.Collapsed;
            passwordBox.Focus();
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "") passwordBox.Visibility = Visibility.Visible;
        }
    }
}
