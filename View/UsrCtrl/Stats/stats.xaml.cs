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

namespace Projet.View.UsrCtrl.Stats
{
    /// <summary>
    /// Logique d'interaction pour stats.xaml
    /// </summary>
    public partial class stats : UserControl
    {
        public stats(Model.Eleve eleve)
        {

            InitializeComponent();
            if (!Commun.AdminConnecte) EleveWindow.mettreAJourButtonToReturn();
            else AdminWindow.mettreAJourButtonToReturn();
            nom.DataContext = eleve.Nom;
            preNom.DataContext = eleve.Prenom;
            dateNaissance.DataContext = eleve.DateDeNaissance.ToString("dd - MM - yyyy");
            imgAvatar.DataContext = eleve.Avatar;
            //NbExoFait
            nbExoFait12.Text = eleve.Statistiques.nbExoFaitCours(1).ToString();
            nbExoFait22.Text = eleve.Statistiques.nbExoFaitCours(2).ToString();
            nbExoFait32.Text = eleve.Statistiques.nbExoFaitCours(3).ToString();
            /////////////////// cours
            courName1.DataContext = coursNameById(0);
            courName2.DataContext = coursNameById(1);
            courName3.DataContext = coursNameById(2);

            if (eleve.Statistiques.Cours[0].pageCourante == 1) avancementCour1.Text = "0";
            else avancementCour1.Text = System.Math.Round(((double)eleve.Statistiques.Cours[0].pageCourante) * 100 / 18.0, 2).ToString();
            if (eleve.Statistiques.Cours[1].pageCourante == 1) avancementCour2.Text = "0";
            else avancementCour2.Text = System.Math.Round(((double)eleve.Statistiques.Cours[1].pageCourante) * 100 / 24.0, 2).ToString();
            if (eleve.Statistiques.Cours[2].pageCourante == 1) avancementCour3.Text = "0";
            else avancementCour3.Text = System.Math.Round(((double)eleve.Statistiques.Cours[2].pageCourante) * 100 / 12.0, 2).ToString();
            /*
            setColorByAvan(((double)eleve.Statistiques.Cours[0].pageCourante) * 100 / 18.0,avancementCour1,true);
            setColorByAvan(((double)eleve.Statistiques.Cours[1].pageCourante) * 100 / 24.0, avancementCour2, true);
            setColorByAvan(((double)eleve.Statistiques.Cours[2].pageCourante) * 100 / 12.0, avancementCour3, true);
            */
            setColorByAvan(((double)eleve.Statistiques.Cours[0].pageCourante) * 100 / 18.0, courName1, true);
            setColorByAvan(((double)eleve.Statistiques.Cours[1].pageCourante) * 100 / 24.0, courName2, true);
            setColorByAvan(((double)eleve.Statistiques.Cours[2].pageCourante) * 100 / 12.0, courName3, true);

            ////// Moyenne exercices
            courNameMoy1.DataContext = coursNameById(0);
            courNameMoy2.DataContext = coursNameById(1);
            courNameMoy3.DataContext = coursNameById(2);

            moyenneCour1.Text = (System.Math.Round(eleve.Statistiques.obtenirNoteCours(1)*2, 2).ToString());
            moyenneCour2.Text = (System.Math.Round(eleve.Statistiques.obtenirNoteCours(2)*2, 2).ToString());
            moyenneCour3.Text = (System.Math.Round(eleve.Statistiques.obtenirNoteCours(3)*2, 2).ToString());

            setColorByAvan(System.Math.Round(eleve.Statistiques.obtenirNoteCours(1) / 5.0, 2), courNameMoy1, false);
            setColorByAvan(System.Math.Round(eleve.Statistiques.obtenirNoteCours(2) / 5.0, 2), courNameMoy2, false);
            setColorByAvan(System.Math.Round(eleve.Statistiques.obtenirNoteCours(3) / 5.0, 2), courNameMoy3, false);

            if (!Commun.AdminConnecte)
            {
                moyenneCour1.ToolTip = "لتحسين معدلك قم بحل المزيد من التمارين";
                moyenneCour2.ToolTip = "لتحسين معدلك قم بحل المزيد من التمارين";
                moyenneCour3.ToolTip = "لتحسين معدلك قم بحل المزيد من التمارين";
            }

            //// Examens
            exam1.Text = "الإخبار الأول";
            exam2.Text = "الإختبار الثاني";

            if (eleve.Statistiques.Exam1DejaFait)
            {
                noteExam1.Text = eleve.Statistiques.noteExam1.ToString();
                setColorByAvan(eleve.Statistiques.noteExam1/10.0, exam1, false);

            }
            else noteExam1.Text = " - ";

            if (eleve.Statistiques.Exam2DejaFait)
            {
                noteExam2.Text = eleve.Statistiques.noteExam2.ToString();
                setColorByAvan(eleve.Statistiques.noteExam2 / 10.0, exam2, false);
            }
            else noteExam2.Text = " - ";


            //trophies
            if (eleve.Statistiques.trophies[0])
            {
                trophy0.DataContext = trophySourceById(0);
                trophy0.ToolTip = trophyToolTypById(0);
            }

            else
            {
                trophy0.DataContext = trophySourceById(-1);
                trophy0.ToolTip = trophyToolTypById(-1);
            }

            if (eleve.Statistiques.trophies[1])
            {
                trophy1.DataContext = trophySourceById(1);
                trophy1.ToolTip = trophyToolTypById(1);
            }

            else
            {
                trophy1.DataContext = trophySourceById(-1);
                trophy1.ToolTip = trophyToolTypById(-1);
            }
            if (eleve.Statistiques.trophies[2])
            {
                trophy2.DataContext = trophySourceById(2);
                trophy2.ToolTip = trophyToolTypById(2);
            }

            else
            {
                trophy2.DataContext = trophySourceById(-1);
                trophy2.ToolTip = trophyToolTypById(-1);
            }
            if (eleve.Statistiques.trophies[3])
            {
                trophy3.DataContext = trophySourceById(3);
                trophy3.ToolTip = trophyToolTypById(3);
            }

            else
            {
                trophy3.DataContext = trophySourceById(-1);
                trophy3.ToolTip = trophyToolTypById(-1);
            }
            if (eleve.Statistiques.trophies[4])
            {
                trophy4.DataContext = trophySourceById(4);
                trophy4.ToolTip = trophyToolTypById(4);
            }

            else
            {
                trophy4.DataContext = trophySourceById(-1);
                trophy4.ToolTip = trophyToolTypById(-1);
            }
            if (eleve.Statistiques.trophies[5])
            {
                trophy5.DataContext = trophySourceById(5);
                trophy5.ToolTip = trophyToolTypById(5);
            }

            else
            {
                trophy5.DataContext = trophySourceById(-1);
                trophy5.ToolTip = trophyToolTypById(-1);
            }
            if (eleve.Statistiques.trophies[6])
            {
                trophy6.DataContext = trophySourceById(6);
                trophy6.ToolTip = trophyToolTypById(6);
            }

            else
            {
                trophy6.DataContext = trophySourceById(-1);
                trophy6.ToolTip = trophyToolTypById(-1);
            }

            if (eleve.Statistiques.trophies[7])
            {
                trophy7.DataContext = trophySourceById(7);
                trophy7.ToolTip = trophyToolTypById(7);
            }

            else
            {
                trophy7.DataContext = trophySourceById(-1);
                trophy7.ToolTip = trophyToolTypById(-1);
            }

            if (eleve.Statistiques.trophies[8])
            {
                trophy8.DataContext = trophySourceById(8);
                trophy8.ToolTip = trophyToolTypById(8);
            }

            else
            {
                trophy8.DataContext = trophySourceById(-1);
                trophy8.ToolTip = trophyToolTypById(-1);
            }

            if (eleve.Statistiques.trophies[9])
            {
                trophy9.DataContext = trophySourceById(9);
                trophy9.ToolTip = trophyToolTypById(9);
            }

            else
            {
                trophy9.DataContext = trophySourceById(-1);
                trophy9.ToolTip = trophyToolTypById(-1);
            }

        }
        public static string coursNameById(int i)
        {
            if (i == 0) return "مظاهر السطح في الجزائر";
            if (i == 1) return "المناخ و النبات";
            return "الموارد الطبيعية";
        }

        private static void setColorByAvan(double dd, TextBlock txtBlock,bool bb)
        {
            if (bb)
            {
                if (dd == 100.0) txtBlock.Foreground = Brushes.Green;
                else if (dd >= 50.0) txtBlock.Foreground = Brushes.LimeGreen;
                else if (dd >= 20.0) txtBlock.Foreground = Brushes.OrangeRed;
                else txtBlock.Foreground = Brushes.DarkRed;
            }
            else
            {
                if(dd==1.0) txtBlock.Foreground = Brushes.Green;
                else if(dd>=0.5) txtBlock.Foreground = Brushes.LimeGreen;
                else txtBlock.Foreground = Brushes.DarkRed;
            }
            
        }
        private static String trophySourceById(int id)
        {
            return "/IMAGES/TROPHIES/" + (id + 1) + ".png";
        }
        private static String trophyToolTypById(int id)
        {
            switch (id)
            {
                case -1:return "جائزة لم تفتح بعد - لفتح الجوائز قم بمراجعة الدروس و التميز في حل التمارين و الإختبارات";
                case 0: return "أول دخول : الطريق نحو الإجتهاد";
                case 1: return "أول درس : بداية العمل";
                case 2: return "أول تمرين : بداية الإجتهاد";
                case 3: return "إختبار 10 : بداية الإمتباز";
                case 4: return "المجال الثاني : انهيت المجال";
                case 5: return "تمرين 5 على 5 : تمرين كامل";
                case 6: return "حافظ الخرائط";
                case 7: return "الممتاز";
                case 8: return "نجيب الخرائط";
                case 9: return "النجيب في الجغرافيا";
            }
            return "جائزة لم تفتح بعد";
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if (!Commun.AdminConnecte) UserControls.ELEVE.EleveUserControl.cc.containerCenter.Content = new UserControls.ELEVE.Chap2MenuMaps();
            else
            {
                Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
            }
        }
    }
}
