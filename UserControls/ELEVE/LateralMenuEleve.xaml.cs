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
using Projet.UserControls.GENERAL;
namespace Projet.UserControls.ELEVE
{
    /// <summary>
    /// Logique d'interaction pour LateralMenuEleve.xaml
    /// </summary>
    public partial class LateralMenuEleve : UserControl
    {
        public LateralMenuEleve()
        {
            InitializeComponent();
        }
        private void buttonHideMenu_Click(object sender, RoutedEventArgs e)
        {
            lateralMenuContainer.Visibility = Visibility.Collapsed;
            buttonShowMenu.Visibility = Visibility.Visible;
        }
        private void buttonShowMenu_Click(object sender, RoutedEventArgs e)
        {
            avatarImage.DataContext = EleveUserControl.Environnement.eleveConnecte.Avatar;
            nom_prenom.DataContext = EleveUserControl.Environnement.eleveConnecte.NomComplet;
            buttonShowMenu.Visibility = Visibility.Collapsed;
            lateralMenuContainer.Visibility = Visibility.Visible;
        }

        private void buttonAPropos_Click(object sender, RoutedEventArgs e)
        {
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();
            buttonHideMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            EleveUserControl.cc.containerCenter.Content = new APropos();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonParam_Click(object sender, RoutedEventArgs e)
        {
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();
            buttonHideMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Model.Utilities.ChargerAvatars();
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();
            Commun.ContenuEleve.Content = new View.UsrCtrl.eleveCtrls.modifierInfo();
            Commun.ContenuEleve.Opacity = 1;
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonShowProfil_Click(object sender, RoutedEventArgs e)
        {
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();
            buttonHideMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
            Commun.ContenuEleve.Content = new View.UsrCtrl.Stats.stats(EleveUserControl.Environnement.eleveConnecte);
        }
    }
}
