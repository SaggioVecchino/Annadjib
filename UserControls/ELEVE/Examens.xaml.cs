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
    /// Logique d'interaction pour Examens.xaml
    /// </summary>
    public partial class Examens : UserControl
    {
        public Examens()
        {
            InitializeComponent();
            EleveWindow.mettreAJourButtonToReturn();
        }

        private void textExamens_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Examens();
        }

        private void buttonExam1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Projet.View.UsrCtrl.Exam.Exam1();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Exam1;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonExam2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Projet.View.UsrCtrl.Exam.Exam2();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Exam2;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void textChap2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }
    }
}
