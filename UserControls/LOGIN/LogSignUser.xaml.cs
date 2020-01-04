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
using Projet.Model;
namespace Projet.UserControls.LOGIN
{
    /// <summary>
    /// Logique d'interaction pour LogSignUser.xaml
    /// </summary>
    public partial class LogSignUser : UserControl
    {
        
        public LogSignUser()
        {
            InitializeComponent();
            //Utilities.ChargerEleves();
            userName.ItemsSource = Utilities.listeDesEleves;
        }
        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            Commun.contentControl_.Content = new LoginChooseType();
        }

        private void buttonNewMember_Click(object sender, RoutedEventArgs e)
        {
            Commun.contentControl_.Content = new formulaire();
        }

        private void buttonEntrer_Click(object sender, RoutedEventArgs e)
        {
            if (userName.SelectedItem == null || passwordBox.Password == "")
            {
                if (passwordBox.Password == "")
                    erreurMessage.Text = "يجب عليك ادخال كلمة السر أولا";
                if (userName.SelectedItem == null)
                {
                    erreurMessage.Text = "يجب عليك اختيار اسم المستخدم اولا";
                }
                erreurMessage.Visibility = Visibility.Visible;
            }
            else
            {
                Eleve el, auto;
                string nm = ((Eleve)userName.SelectedItem).NomComplet;
                el = Utilities.listeDesEleves.Find(r => r.NomComplet == nm);
                auto = Eleve.AuthentficationEleve(el.IdEleve, passwordBox.Password);
                if (auto == null)
                {
                    erreurMessage.Text = "كلمة السر خاطئة";
                    erreurMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    EleveUserControl.Environnement.eleveConnecte = el;
                    EleveWindow s = new EleveWindow();
                    Commun.window_user = s;
                    s.Show();
                    Commun.AdminConnecte = false;
                    Commun.window_.Close();
                }
            }
        }

        private void passwordPlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordPlaceHolder.Visibility = Visibility.Collapsed;
            passwordBox.Focus();
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "")
            {
                passwordPlaceHolder.Visibility = Visibility.Visible;
                erreurMessage.Visibility = Visibility.Visible;
            }
        }

        private void userName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userName.SelectedItem == null) userName.Text = "اسم المستخدم";
        }

    }
}
