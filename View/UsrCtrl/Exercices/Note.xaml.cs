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
using static Projet.Model.Utilities.TypeQuestion;
using static Projet.Model.Utilities.TypePageCours;
using static Projet.Model.Utilities;
using Projet.UserControls.ELEVE;

namespace Projet.View.UsrCtrl.Exercices
{
    /// <summary>
    /// Logique d'interaction pour Note.xaml
    /// </summary>
    public partial class Note : UserControl
    {
        public String smileySource = null;
        public Note()
        {
            InitializeComponent();
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();
            smileyImage.DataContext = afficherSmiley(EleveUserControl.Environnement.exercice.note / (float)5.0);

            //trophy 2
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[2])
            {
                UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(2);
            }
            //

            //trophy 5
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[5])
            {
                if(EleveUserControl.Environnement.exercice.note==5)
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(5);
            }
            //

            DataContext = EleveUserControl.Environnement.exercice;
            textBlock8.Text = afficherMessage(EleveUserControl.Environnement.exercice.note / (float)5.0);
            if (EleveUserControl.Environnement.exercice.note / (float)5.0 < 0.5)
            {
                textBlock5.Foreground = new SolidColorBrush(Colors.Red);
                textBlock8.Foreground = new SolidColorBrush(Colors.Red);
                button1.Visibility = Visibility.Visible;
            }
            else
            {
                textBlock5.Foreground = new SolidColorBrush(Colors.Green);
                textBlock8.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (EleveUserControl.Environnement.exercice.note / (float)5.0 != 1)
                button.Visibility = Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (EleveUserControl.Environnement.exercice.type == QCM)
            {
                EleveUserControl.Environnement.exercice =
                   EleveUserControl.Environnement.eleveConnecte.OuvrirExercice
                     (EleveUserControl.Environnement.exercice.cours, QCM);
                Commun.Exercice.Content = new Exercice();
                Commun.ExerciceQuestion.Content = new QuestionQCM();
            }
            else if (EleveUserControl.Environnement.exercice.type == TrueOrFalse)
            {
                EleveUserControl.Environnement.exercice =
                   EleveUserControl.Environnement.eleveConnecte.OuvrirExercice
                     (EleveUserControl.Environnement.exercice.cours, TrueOrFalse);
                Commun.Exercice.Content = new Exercice();
                Commun.ExerciceQuestion.Content = new QuestionTrueOrFalse();
            }
            else if (EleveUserControl.Environnement.exercice.type == DragAndDrop)
            {
                EleveUserControl.Environnement.exercice =
                   EleveUserControl.Environnement.eleveConnecte.OuvrirExercice
                     (EleveUserControl.Environnement.exercice.cours, DragAndDrop);
                Commun.Exercice.Content = new View.UsrCtrl.Exercices.QuestionDragAndDrop();
            }

        }

        private string afficherMessage(float moyenne) // entre 0 et 1
        {
            if (moyenne < 0.5) return "ننصحك بمراجعة درسك";
            if (moyenne == 0.5) return "يمكنك أن تقدّم أفضل";
            if (moyenne < 1 && moyenne > 0.5) return "أحسنت";
            return "ممتاز";
        }
        private string afficherSmiley(float moyenne) // entre 0 et 1
        {
            if (moyenne <= 0.3) return "/IMAGES/SMILEY/S4.png";
            if (moyenne <= 0.5) return "/IMAGES/SMILEY/S3.png";
            if (moyenne <= 0.8 ) return "/IMAGES/SMILEY/S2.png";
            return "/IMAGES/SMILEY/S1.png";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StructCours c = new StructCours();
            c.id = EleveUserControl.Environnement.exercice.cours;
            c.pageCourante = 1;//On revient à la première page
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[c.id - 1] = c;
            MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
            EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(c.id);
            if (EleveUserControl.Environnement.cours.Get_Type_page() == TextImage)
                Commun.CoursContenu.Content = new Cours.Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == TextSeul)
                Commun.CoursContenu.Content = new Cours.CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == ImageSeule)
                Commun.CoursContenu.Content = new Cours.CoursImage();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new UserControls.ELEVE.Exercices();
        }
    }
}
