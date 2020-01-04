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
    /// Logique d'interaction pour modifierInfo.xaml
    /// </summary>
    public partial class modifierInfo : UserControl
    {
        public static Boolean ChangementPwdEnCour;
        public static string imAv;
        public static string imAvAvant;
        public static int indiceAvatarCourant;
        public static DateTime? dateNaissance;
        public static Boolean nonSauv;
        public static Boolean nonSauvAdmin;
        public static Boolean nonSauvPwd;
        public static Boolean changement;
        public static Boolean changementAdmin;
        public static Boolean changementPwd;
        public static Boolean nonSauvPwdAdmin;
        public static Boolean changementPwdAdmin;
        public modifierInfo()
        {
            InitializeComponent();
            if (!Commun.AdminConnecte) EleveWindow.mettreAJourButtonToReturn();
            else AdminWindow.mettreAJourButtonToReturn();


            ChangementPwdEnCour = false;
            changement = false;
            changementAdmin = false;
            nonSauv = true;
            nonSauvAdmin = true;
            nonSauvPwd = true;
            nonSauvPwdAdmin = true;
            Model.Utilities.ChargerAvatars();
            if (Commun.AdminConnecte)
            {
                imAv = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar;
                imAvAvant = imAv;
                imgAvatar.DataContext = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar;
                lastname.DataContext = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Nom;
                firstname.DataContext = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Prenom;
                dateNaissanceDP.SelectedDate = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.DateDeNaissance;

            }
            else
            {
                imAv = EleveUserControl.Environnement.eleveConnecte.Avatar;
                imAvAvant = imAv;
                imgAvatar.DataContext = EleveUserControl.Environnement.eleveConnecte.Avatar;
                lastname.DataContext = EleveUserControl.Environnement.eleveConnecte.Nom;
                firstname.DataContext = EleveUserControl.Environnement.eleveConnecte.Prenom;
                dateNaissanceDP.SelectedDate = EleveUserControl.Environnement.eleveConnecte.DateDeNaissance;
            }
            indiceAvatarCourant = Model.Utilities.listeAvatar.IndexOf(imAv);
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var dp = sender as DatePicker;
            dateNaissance = dp.SelectedDate;
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            message_succes.Visibility = Visibility.Hidden;
            Error.Visibility = Visibility.Hidden;
            indiceAvatarCourant--;
            if (indiceAvatarCourant < 0)
            {
                indiceAvatarCourant = Model.Utilities.listeAvatar.Count - 1;
            }
            imAv = Model.Utilities.listeAvatar[indiceAvatarCourant];
            if (Commun.AdminConnecte)
            {

                Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar = imAv;
                imgAvatar.DataContext = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar;
                if (imAv.Equals(imAvAvant))
                {
                    changementAdmin = false;
                }
                else changementAdmin = true;
            }
            else
            {
                EleveUserControl.Environnement.eleveConnecte.Avatar = imAv;
                imgAvatar.DataContext = EleveUserControl.Environnement.eleveConnecte.Avatar;
                if (imAv.Equals(imAvAvant))
                {
                    changement = false;
                }
                else changement = true;
            }

        }

        private void right_Click(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            message_succes.Visibility = Visibility.Hidden;
            Error.Visibility = Visibility.Hidden;
            indiceAvatarCourant++;
            if (indiceAvatarCourant >= Model.Utilities.listeAvatar.Count)
            {
                indiceAvatarCourant = 0;
            }
            imAv = Model.Utilities.listeAvatar[indiceAvatarCourant];
            if (Commun.AdminConnecte)
            {

                Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar = imAv;
                imgAvatar.DataContext = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Avatar;
                if (imAv.Equals(imAvAvant))
                {
                    changementAdmin = false;
                }
                else changementAdmin = true;
            }
            else
            {
                EleveUserControl.Environnement.eleveConnecte.Avatar = imAv;
                imgAvatar.DataContext = EleveUserControl.Environnement.eleveConnecte.Avatar;
                if (imAv.Equals(imAvAvant))
                {
                    changement = false;
                }
                else changement = true;
            }
        }

        private void firstname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            if (Commun.AdminConnecte) changementAdmin = true;
            else changement = true;

            TextBox tb = (TextBox)sender;
            tb.Text = "";
            message_succes.Visibility = Visibility.Hidden;
            Error.Visibility = Visibility.Hidden;
        }

        private void firstname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            TextBox tb = (TextBox)sender;
            string prenom;
            if (Commun.AdminConnecte)
            {
                prenom = Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Prenom;
                tb.Text = tb.Text == string.Empty ? prenom : tb.Text;
            }
            else
            {
                prenom = EleveUserControl.Environnement.eleveConnecte.Prenom;
                tb.Text = tb.Text == string.Empty ? prenom : tb.Text;
            }
        }

        private void lastname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            if (Commun.AdminConnecte) changementAdmin = true;
            else changement = true;
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            message_succes.Visibility = Visibility.Hidden;
            Error.Visibility = Visibility.Hidden;
        }

        private void lastname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            TextBox tb = (TextBox)sender;
            if (Commun.AdminConnecte)
            {
                tb.Text = tb.Text == string.Empty ? Projet.View.UsrCtrl.Admin.EleveAdmin.elevAdmin.Nom : tb.Text;
            }
            else
            {
                tb.Text = tb.Text == string.Empty ? EleveUserControl.Environnement.eleveConnecte.Nom : tb.Text;
            }
        }

        private void sauvgarde_Click(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            String nomComp = lastname.Text+" " + firstname.Text;
            if (Commun.AdminConnecte)
            {

                if ((firstname.Text != "") && (firstname.Text != "الإسم") && (lastname.Text != "") && (lastname.Text != "اللّقب"))
                {

                    if ((Model.Utilities.listeDesEleves.Find(r => ((r.NomComplet == nomComp))) != null) && (Admin.EleveAdmin.elevAdmin.NomComplet!=nomComp))
                    {
                        Error.Text = "هذا الإسم مسجّل مسبقا";
                        Error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        Admin.EleveAdmin.elevAdmin.Prenom = firstname.Text;
                        Admin.EleveAdmin.elevAdmin.Nom = lastname.Text;
                    }
                }

                Admin.EleveAdmin.elevAdmin.DateDeNaissance = (DateTime)dateNaissance;
                int i = Model.Utilities.listeDesEleves.FindIndex(x => x.IdEleve == Admin.EleveAdmin.elevAdmin.IdEleve);
                Model.Utilities.listeDesEleves[i] = Admin.EleveAdmin.elevAdmin;
                nonSauvAdmin = true;
                changementAdmin = false;


            }
            else
            {
                if ((firstname.Text != "") && (firstname.Text != "الإسم") && (lastname.Text != "") && (lastname.Text != "اللّقب"))
                {

                    if ((Model.Utilities.listeDesEleves.Find(r => ((r.NomComplet == nomComp))) != null) && (nomComp!= EleveUserControl.Environnement.eleveConnecte.NomComplet))
                    {
                        Error.Text = "هذا الإسم مسجّل مسبقا";
                        Error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        EleveUserControl.Environnement.eleveConnecte.Prenom = firstname.Text;
                        EleveUserControl.Environnement.eleveConnecte.Nom = lastname.Text;
                    }
                }
                EleveUserControl.Environnement.eleveConnecte.DateDeNaissance = (DateTime)dateNaissance;
                int i = Model.Utilities.listeDesEleves.FindIndex(x => x.IdEleve == EleveUserControl.Environnement.eleveConnecte.IdEleve);
                Model.Utilities.listeDesEleves[i] = EleveUserControl.Environnement.eleveConnecte;
                nonSauv = true;
                changement = false;
            }
            Model.Utilities.EnregistrerListeDesEleves();
            message_succes.Visibility = Visibility.Visible;
        }

        private void changePwd_Click(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            if (Commun.AdminConnecte)
            {
                Commun.ConfirmationAdmin.Opacity = 1;
                Commun.ConfirmationAdmin.Content = new View.UsrCtrl.eleveCtrls.ChangerPwd();
                Commun.ConfirmationAdmin.Visibility = Visibility.Visible;
                Commun.AdminContenu.Opacity = 0.5;
            }
            else
            {
                Commun.modifierPwdEleve.Opacity = 1;
                Commun.modifierPwdEleve.Content = new View.UsrCtrl.eleveCtrls.ChangerPwd();
                Commun.modifierPwdEleve.Visibility = Visibility.Visible;
                Commun.ContenuEleve.Opacity = 0.5;
            }


        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            if (Commun.AdminConnecte)
            {
                if ((nonSauvAdmin) && (changementAdmin))
                {
                    Commun.confirmSauvParamAdmin.Content = new View.UsrCtrl.eleveCtrls.confirmSauvParam();
                    Commun.confirmSauvParamAdmin.Visibility = Visibility.Visible;
                }
                else
                {
                    Commun.AdminContenu.Content = new Projet.View.UsrCtrl.Admin.Contenu();
                    Commun.AdminTitle.Content = new Admin.TitleAccueil();
                }
            }
            else
            {
                if ((nonSauv) && (changement))
                {
                    Commun.confirmSauvParam.Content = new View.UsrCtrl.eleveCtrls.confirmSauvParam();
                    Commun.confirmSauvParam.Visibility = Visibility.Visible;
                }
                else
                {
                    Commun.ContenuEleve.Content = new UserControls.ELEVE.Chap2MenuMaps();
                }

            }

        }
        private void DatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ChangementPwdEnCour) return;
            if (Commun.AdminConnecte) changementAdmin = true;
            else
            {
                changement = true;
            }
            Error.Visibility = Visibility.Hidden;
            message_succes.Visibility = Visibility.Hidden;
        }
    }
}