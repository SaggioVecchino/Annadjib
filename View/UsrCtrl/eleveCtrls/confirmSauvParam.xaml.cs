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

namespace Projet.View.UsrCtrl.eleveCtrls
{
    /// <summary>
    /// Logique d'interaction pour confirmSauvParam.xaml
    /// </summary>
    public partial class confirmSauvParam : UserControl
    {
        public confirmSauvParam()
        {
            InitializeComponent();
            //EleveWindow.mettreAJourButtonToReturn();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            if (Commun.AdminConnecte)
            {
                Commun.confirmSauvParamAdmin.Visibility = Visibility.Hidden;
                // Commun.AdminContenu.Opacity = 1;
            }
            else
            {
                Commun.confirmSauvParam.Visibility = Visibility.Hidden;
            }

        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {

            if (modifierInfo.ChangementPwdEnCour)
            {
                if (Commun.AdminConnecte)
                {
                    Commun.confirmSauvParamAdmin.Visibility = Visibility.Hidden;
                    modifierInfo.ChangementPwdEnCour = false;
                    Commun.ConfirmationAdmin.Visibility = Visibility.Hidden;
                    Commun.AdminContenu.Opacity = 1;
                    modifierInfo.nonSauvPwdAdmin = true;

                }
                else
                {
                    Commun.confirmSauvParam.Visibility = Visibility.Hidden;
                    modifierInfo.ChangementPwdEnCour = false;
                    Commun.modifierPwdEleve.Visibility = Visibility.Hidden;
                    Commun.ContenuEleve.Opacity = 1;
                    modifierInfo.nonSauvPwd = true;

                }

            }
            else
            {
                if (Commun.AdminConnecte)
                {
                    Commun.confirmSauvParamAdmin.Visibility = Visibility.Hidden;
                    Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar = modifierInfo.imAvAvant;
                    Commun.AdminContenu.Visibility = Visibility.Visible;
                    Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
                    Commun.AdminContenu.Visibility = Visibility.Visible;
                }
                else
                {
                    Commun.confirmSauvParam.Visibility = Visibility.Hidden;
                    Projet.UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Avatar = modifierInfo.imAvAvant;
                    Commun.ContenuEleve.Content = new UserControls.ELEVE.Chap2MenuMaps();
                }

            }
        }
    }
}
