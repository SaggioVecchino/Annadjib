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
    /// Logique d'interaction pour Exercices.xaml
    /// </summary>
    public partial class Exercices : UserControl
    {
        private int exerciceDuCours = 0;
        public Exercices()
        {
            InitializeComponent();
            EleveWindow.mettreAJourButtonToReturn();
        }
        private void textChap2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonQCM_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(exerciceDuCours, Model.Utilities.TypeQuestion.QCM);
            Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
            Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionQCM();
            switch (exerciceDuCours)
            {
                case 1:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.QCM1;
                    break;
                case 2:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.QCM2;
                    break;
                case 3:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.QCM3;
                    break;
            }
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonElfaragh_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(exerciceDuCours, Model.Utilities.TypeQuestion.DragAndDrop);
            Commun.Exercice.Content = new View.UsrCtrl.Exercices.QuestionDragAndDrop();
            switch (exerciceDuCours)
            {
                case 1:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.DragAndDrop1;
                    break;
                case 2:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.DragAndDrop2;
                    break;
                case 3:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.DragAndDrop3;
                    break;
            }
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonCartes_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new MapsMenu();

        }

        private void buttonVrai_faux_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(exerciceDuCours, Model.Utilities.TypeQuestion.TrueOrFalse);
            Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
            Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionTrueOrFalse();
            switch (exerciceDuCours)
            {
                case 1:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.TrueOrFalse1;
                    break;
                case 2:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.TrueOrFalse2;
                    break;
                case 3:
                    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.TrueOrFalse3;
                    break;
            }
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void textExercices_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Exercices();

        }

        private void all_Selected(object sender, RoutedEventArgs e)
        {
            exerciceDuCours = new Random().Next(Model.Utilities.nbCours) + 1;
        }

        private void cours1_Selected(object sender, RoutedEventArgs e)
        {
            exerciceDuCours = 1;
        }

        private void cours2_Selected(object sender, RoutedEventArgs e)
        {
            exerciceDuCours = 2;
        }

        private void cours3_Selected(object sender, RoutedEventArgs e)
        {
            exerciceDuCours = 3;
        }
    }
}

