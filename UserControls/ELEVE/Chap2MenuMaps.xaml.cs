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
    /// Logique d'interaction pour Chap2MenuMaps.xaml
    /// </summary>
    public partial class Chap2MenuMaps : UserControl
    {
        public Chap2MenuMaps()
        {
            InitializeComponent();
            EleveWindow.mettreAJourButtonToLogOut();
            //condition exams
            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.obtenirMoyAllExercices()>=2.5) buttonExam.IsEnabled = true;

            //trophy 9
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[9])
            {
                if ((EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam1 == 10) && (EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam2 == 10))
                {
                    if(EleveUserControl.Environnement.eleveConnecte.Statistiques.obtenirMoyAllExercices() >= 4.5)
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(9);
                }
            }


            if (buttonExam.IsEnabled)
            {
                buttonExam.ToolTip = "اختبارات شاملة لدروس المجال الثاني";
            }
            else
            {
                buttonExam.ToolTip = "يمكنك حل الاختبارات بعد الحصول على معدل كل التمارين اكبر من 5 على 10";
            }
        }

        private void buttonCours_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Courses();
        }

        private void buttonExercice_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Exercices();
        }

        private void buttonExam_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Examens();
        }
        private void textChap2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
        }
    }
}
