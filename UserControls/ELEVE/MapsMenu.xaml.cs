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

namespace Projet.UserControls.ELEVE
{
    /// <summary>
    /// Logique d'interaction pour MapsMenu.xaml
    /// </summary>
    public partial class MapsMenu : UserControl
    {
        public MapsMenu()
        {
            InitializeComponent();
            EleveWindow.mettreAJourButtonToReturn();
        }
        private void textChap2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
            Commun.ContenuEleve.Visibility = Visibility.Visible;
        }

        private void textExercices_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Exercices();
        }

        private void textMaps_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new MapsMenu();
        }

        private void buttonMap1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Tadaris();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTadaris;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonMap1_Copy_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Pluie();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapPluie;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonMap1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Mounakh();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapMounakh;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonMap1_Copy4_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Animaux();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapAnimaux;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonMap1_Copy3_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Temperatures();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTemperatures;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }
    }
}
