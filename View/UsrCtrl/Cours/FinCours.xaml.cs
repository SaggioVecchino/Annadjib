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

namespace Projet.View.UsrCtrl.Cours
{
    /// <summary>
    /// Logique d'interaction pour FinCours.xaml
    /// </summary>
    public partial class FinCours : UserControl
    {
        public FinCours()
        {
            InitializeComponent();
            textBlock8.Text = "لقد انهيت مراجعة درس " + View.UsrCtrl.Stats.stats.coursNameById(UserControls.ELEVE.EleveUserControl.Environnement.cours.ID-1);
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[1])
            {
                if (UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[0].pageCourante == 18)
                {
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(1);
                }
                else if (UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[1].pageCourante == 24)
                {
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(1);
                }
                else if (UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[2].pageCourante == 12)
                {
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(1);
                }
            }
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[4])
            {
                if (UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[0].pageCourante == 18)
                if (UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[1].pageCourante == 24)
                if (UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[2].pageCourante == 12)
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(4);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Commun.CoursContenu.Content = new UserControls.ELEVE.Exercices();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Commun.CoursContenu.Content = new UserControls.ELEVE.Courses();
        }
    }
}
