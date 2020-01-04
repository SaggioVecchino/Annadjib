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
    /// Logique d'interaction pour Courses.xaml
    /// </summary>
    public partial class Courses : UserControl
    {
        public Courses()
        {
            InitializeComponent();
            EleveWindow.mettreAJourButtonToReturn();
        }

        private void buttonCours1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(1);
            if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursImage();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Cours1;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonCours2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(2);
            if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursImage();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Cours2;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void buttonCours3_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(3);
            if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursImage();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Cours3;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void textChap2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void textCourses_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Courses();
        }
    }
}
