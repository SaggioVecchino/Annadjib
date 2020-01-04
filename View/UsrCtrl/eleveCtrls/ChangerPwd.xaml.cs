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
namespace Projet.View.UsrCtrl.eleveCtrls
{
    /// <summary>
    /// Logique d'interaction pour ChangerPwd.xaml
    /// </summary>
    public partial class ChangerPwd : UserControl
    {
        private static Boolean verifPwd = true;
        private static Boolean verifPwdconfirm = true;
        public ChangerPwd()
        {

            InitializeComponent();
            //EleveWindow.mettreAJourButtonToReturn();
            modifierInfo.changementPwd = false;
            modifierInfo.changementPwdAdmin = false;
            modifierInfo.ChangementPwdEnCour = true;
            if (Commun.AdminConnecte)
            {
                PwdFaux.Visibility = Visibility.Hidden;
                ancienTextBlock.Visibility = Visibility.Hidden;
                AncienPwd.Visibility = Visibility.Hidden;
            }
            else
            {
                PwdFaux.Visibility = Visibility.Hidden;
                ancienTextBlock.Visibility = Visibility.Visible;
                AncienPwd.Visibility = Visibility.Visible;
            }

        }

        private void cancelPwd_Click(object sender, RoutedEventArgs e)
        {

            if (Commun.AdminConnecte)
            {
                if ((modifierInfo.nonSauvPwdAdmin) && (modifierInfo.changementPwdAdmin))
                {
                    Commun.confirmSauvParamAdmin.Content = new View.UsrCtrl.eleveCtrls.confirmSauvParam();
                    Commun.confirmSauvParamAdmin.Visibility = Visibility.Visible;
                }
                else
                {
                    Commun.ConfirmationAdmin.Visibility = Visibility.Hidden;
                    Commun.AdminContenu.Opacity = 1;
                    modifierInfo.ChangementPwdEnCour = false;

                }

            }
            else
            {
                if ((modifierInfo.nonSauvPwd) && (modifierInfo.changementPwd))
                {
                    Commun.confirmSauvParam.Content = new View.UsrCtrl.eleveCtrls.confirmSauvParam();
                    Commun.confirmSauvParam.Visibility = Visibility.Visible;
                }
                else
                {
                    modifierInfo.ChangementPwdEnCour = false;
                    Commun.modifierPwdEleve.Visibility = Visibility.Hidden;
                    Commun.ContenuEleve.Opacity = 1;

                }


            }

        }

        private void sauvgarderPwd_Click(object sender, RoutedEventArgs e)
        {

            if (!NauveauPwd.Password.ToString().Equals(ConfirmNauveauPwd.Password.ToString()))
            {

                verifPwdconfirm = false;
            }
            if (verifPwd)
            {
                if (verifPwdconfirm)
                {
                    if (NauveauPwd.Password.ToString().Equals(AncienPwd.Password.ToString()))
                    {
                        if (!Commun.AdminConnecte)
                        {
                            if (AncienPwd.Password.ToString().Equals(""))
                            {
                                PwdFaux.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                MemePwd.Visibility = Visibility.Visible;
                            }
                        }


                    }
                    else
                    {
                        if (!NauveauPwd.Password.ToString().Equals(""))
                        {
                            if (Commun.AdminConnecte)
                            {
                                Admin.EleveAdmin.elevAdmin.PasswordHashed = NauveauPwd.Password.GetHashCode();
                                int i = Model.Utilities.listeDesEleves.FindIndex(x => x.IdEleve == Admin.EleveAdmin.elevAdmin.IdEleve);
                                Model.Utilities.listeDesEleves[i] = Admin.EleveAdmin.elevAdmin;
                                modifierInfo.nonSauvPwdAdmin = true;
                                modifierInfo.changementPwdAdmin = false;
                            }
                            else
                            {
                                EleveUserControl.Environnement.eleveConnecte.PasswordHashed = NauveauPwd.Password.GetHashCode();
                                int i = Model.Utilities.listeDesEleves.FindIndex(x => x.IdEleve == EleveUserControl.Environnement.eleveConnecte.IdEleve);
                                Model.Utilities.listeDesEleves[i] = EleveUserControl.Environnement.eleveConnecte;
                                modifierInfo.nonSauvPwd = true;
                                modifierInfo.changementPwd = false;

                            }

                            Model.Utilities.EnregistrerListeDesEleves();
                            MessageSauv.Visibility = Visibility.Hidden;
                            MessageSauvCorrect.Visibility = Visibility.Visible;
                            cancelPwd_Click(sender,e);

                        }
                        else
                        {
                            NauvPwdVide.Visibility = Visibility.Visible;
                        }

                    }
                }
                else
                {
                    NauvPwdFaux.Visibility = Visibility.Visible;
                    MessageSauv.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (!verifPwdconfirm) NauvPwdFaux.Visibility = Visibility.Visible;
                MessageSauv.Visibility = Visibility.Visible;
            }
            if ((Commun.AdminConnecte) && NauveauPwd.Password.ToString().Equals(""))
            {
                MessageSauv.Visibility = Visibility.Visible;
                NauvPwdVide.Visibility = Visibility.Visible;
            }
            verifPwd = true;
            verifPwdconfirm = true;

        }

        private void AncienPwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Commun.AdminConnecte)
            {
                if (EleveUserControl.Environnement.eleveConnecte.PasswordHashed != AncienPwd.Password.GetHashCode())
                {
                    PwdFaux.Visibility = Visibility.Visible;
                    verifPwd = false;
                }
                else
                {
                    verifPwd = true;
                }
            }


        }

        private void AncienPwd_GotFocus(object sender, RoutedEventArgs e)
        {
            modifierInfo.changementPwd = true;
            modifierInfo.changementPwdAdmin = true;
            MessageSauvCorrect.Visibility = Visibility.Hidden;
            PwdFaux.Visibility = Visibility.Hidden;
            MessageSauv.Visibility = Visibility.Hidden;
        }

        private void ConfirmNauveauPwd_GotFocus(object sender, RoutedEventArgs e)
        {
            modifierInfo.changementPwd = true;
            modifierInfo.changementPwdAdmin = true;
            MessageSauvCorrect.Visibility = Visibility.Hidden;
            NauvPwdFaux.Visibility = Visibility.Hidden;
        }

        private void NauveauPwd_GotFocus(object sender, RoutedEventArgs e)
        {
            modifierInfo.changementPwd = true;
            modifierInfo.changementPwdAdmin = true;
            MessageSauvCorrect.Visibility = Visibility.Hidden;
            NauvPwdVide.Visibility = Visibility.Hidden;
            MemePwd.Visibility = Visibility.Hidden;
        }

        private void NauveauPwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Commun.AdminConnecte)
            {
                if (NauveauPwd.Password.ToString().Equals(""))
                {
                    NauvPwdVide.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (((NauveauPwd.Password.ToString().Equals(AncienPwd.Password.ToString()))) && (!(AncienPwd.Password.ToString().Equals(""))))
                {
                    MemePwd.Visibility = Visibility.Visible;
                }
                if (NauveauPwd.Password.ToString().Equals(""))
                {
                    NauvPwdVide.Visibility = Visibility.Visible;
                }
            }


        }
    }
}
