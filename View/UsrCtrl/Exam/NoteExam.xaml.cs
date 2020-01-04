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
using Projet.View.UsrCtrl.Exam;
using Projet.UserControls.ELEVE;
namespace Projet.View.UsrCtrl.Exam
{
    /// <summary>
    /// Logique d'interaction pour Note.xaml
    /// </summary>
    public partial class NoteExam : UserControl
    {
        public NoteExam()
        {
            InitializeComponent();

            textBlock8.Text = afficherMessage(EleveUserControl.Environnement.note / (double)10);
            smileyImage.DataContext = afficherSmiley(EleveUserControl.Environnement.note / (double)10);
            textBlock5.Text = EleveUserControl.Environnement.note.ToString();
            //trophy
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[3])
            {
                if (EleveUserControl.Environnement.note == 10)
                {
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(3);
                }
            }
            //

            //trophy 7
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[7])
            {
                if ((EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam1 == 10)&& (EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam2 == 10))
                {
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(7);
                }
            }
            //

            if (EleveUserControl.Environnement.note / (double)10 < 0.5)
            {
                textBlock5.Foreground = new SolidColorBrush(Colors.Red);
                textBlock8.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (EleveUserControl.Environnement.note / (double)10 == 1)
                {
                    textBlock5.Foreground = new SolidColorBrush(Colors.Green);
                    textBlock8.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    if (EleveUserControl.Environnement.note / (double)10 >= 0.7)
                    {
                        textBlock5.Foreground = new SolidColorBrush(Colors.Green);
                        textBlock8.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        textBlock5.Foreground = new SolidColorBrush(Colors.Yellow);
                        textBlock8.Foreground = new SolidColorBrush(Colors.Yellow);
                    }
                }
            }


        }



        private string afficherMessage(double moyenne) // entre 0 et 1
        {
            if (moyenne < 0.5) return "ننصحك بمراجعة درسك";

            if (moyenne < 0.7 && moyenne >= 0.5) return "جيد لكن يمكنك أن تقدّم أفضل";
            if (moyenne < 1 && moyenne >= 0.7) return "أحسنت";
            return "ممتاز";
        }

        private string afficherSmiley(double moyenne) // entre 0 et 1
        {
            if (moyenne <= 0.3) return "/IMAGES/SMILEY/S4.png";
            if (moyenne <= 0.5) return "/IMAGES/SMILEY/S3.png";
            if (moyenne <= 0.8) return "/IMAGES/SMILEY/S2.png";
            return "/IMAGES/SMILEY/S1.png";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Projet.UserControls.ELEVE.Courses();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new Projet.UserControls.ELEVE.Examens();
        }
    }
}
