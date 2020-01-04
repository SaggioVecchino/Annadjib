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
    /// Logique d'interaction pour EtatAncienneSession.xaml
    /// </summary>
    public partial class EtatAncienneSession : UserControl
    {
        public EtatAncienneSession()
        {
            InitializeComponent();
            switch (EleveUserControl.Environnement.eleveConnecte.Statistiques.etat)
            {
                case Model.Utilities.EtatAncienneSession.Cours1:
                    textBlock.Text = "عند آخر خروج لك كنت تقرأ الدّرس مظاهر السّطح في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.Cours2:
                    textBlock.Text = "عند آخر خروج لك كنت تقرأ الدّرس المناخ والنّبات في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.Cours3:
                    textBlock.Text = "عند آخر خروج لك كنت تقرأ الدّرس الموارد الطّبيعيّة في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.QCM1:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع اختر الجواب الصّحيح حول الدّرس مظاهر السّطح في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.QCM2:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع اختر الجواب الصّحيح حول الدّرس المناخ والنّبات في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.QCM3:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع اختر الجواب الصّحيح حول الدّرس الموارد الطّبيعيّة في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.TrueOrFalse1:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع صحيح أو خطأ حول الدّرس مظاهر السّطح في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.TrueOrFalse2:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع صحيح أو خطأ حول الدّرس المناخ والنّبات في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.TrueOrFalse3:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع صحيح أو خطأ حول الدّرس الموارد الطّبيعيّة في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.DragAndDrop1:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع املأ الفراغات حول الدّرس مظاهر السّطح في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.DragAndDrop2:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع املأ الفراغات حول الدّرس المناخ والنّبات في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.DragAndDrop3:
                    textBlock.Text = "عند آخر خروج لك كنت متوقّفا عند تمرين من نوع املأ الفراغات حول الدّرس الموارد الطّبيعيّة في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.MapAnimaux:
                    textBlock.Text = "عند آخر خروج كنت في تمرين من نوع خرائط حول تمركز الحيوانات في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.MapMounakh:
                    textBlock.Text = "عند آخر خروج كنت في تمرين من نوع خرائط حول المناخ في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.MapPluie:
                    textBlock.Text = "عند آخر خروج كنت في تمرين من نوع خرائط حول التّساقط في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.MapTadaris:
                    textBlock.Text = "عند آخر خروج كنت في تمرين من نوع خرائط حول التّضاريس في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.MapTemperatures:
                    textBlock.Text = "عند آخر خروج كنت في تمرين من نوع خرائط حول توزيع درجة الحرارة في الجزائر";
                    break;
                case Model.Utilities.EtatAncienneSession.Exam1:
                    textBlock.Text = "عند آخر خروج كنت في الامتحان الأوّل";
                    break;
                case Model.Utilities.EtatAncienneSession.Exam2:
                    textBlock.Text = "عند آخر خروج كنت في الامتحان الثّاني";
                    break;

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            switch (EleveUserControl.Environnement.eleveConnecte.Statistiques.etat)
            {
                case Model.Utilities.EtatAncienneSession.Cours1:
                    EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(1);
                    if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.Cours();
                    else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursTexte();
                    else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursImage();
                 //   EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Cours1;
                 //   Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.Cours2:
                    EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(2);
                    if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.Cours();
                    else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursTexte();
                    else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursImage();
                 //   EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Cours1;
                 //   Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.Cours3:
                    EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(3);
                    if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.Cours();
                    else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursTexte();
                    else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                        Commun.CoursContenu.Content = new View.UsrCtrl.Cours.CoursImage();
               //     EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Cours1;
                //    Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.QCM1:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(1, Model.Utilities.TypeQuestion.QCM);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
                    Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionQCM();
                    break;
                case Model.Utilities.EtatAncienneSession.QCM2:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(2, Model.Utilities.TypeQuestion.QCM);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
                    Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionQCM();
                    break;
                case Model.Utilities.EtatAncienneSession.QCM3:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(3, Model.Utilities.TypeQuestion.QCM);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
                    Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionQCM();
                    break;
                case Model.Utilities.EtatAncienneSession.TrueOrFalse1:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(1, Model.Utilities.TypeQuestion.TrueOrFalse);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
                    Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionTrueOrFalse();
                    break;
                case Model.Utilities.EtatAncienneSession.TrueOrFalse2:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(2, Model.Utilities.TypeQuestion.TrueOrFalse);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
                    Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionTrueOrFalse();
                    break;
                case Model.Utilities.EtatAncienneSession.TrueOrFalse3:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(3, Model.Utilities.TypeQuestion.TrueOrFalse);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.Exercice();
                    Commun.ExerciceQuestion.Content = new View.UsrCtrl.Exercices.QuestionTrueOrFalse();
                    break;
                case Model.Utilities.EtatAncienneSession.DragAndDrop1:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(1, Model.Utilities.TypeQuestion.DragAndDrop);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.QuestionDragAndDrop();
                    break;
                case Model.Utilities.EtatAncienneSession.DragAndDrop2:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(2, Model.Utilities.TypeQuestion.DragAndDrop);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.QuestionDragAndDrop();
                    break;
                case Model.Utilities.EtatAncienneSession.DragAndDrop3:
                    EleveUserControl.Environnement.exercice = EleveUserControl.Environnement.eleveConnecte.OuvrirExercice(3, Model.Utilities.TypeQuestion.DragAndDrop);
                    Commun.Exercice.Content = new View.UsrCtrl.Exercices.QuestionDragAndDrop();
                    break;
                case Model.Utilities.EtatAncienneSession.MapAnimaux:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Animaux();
                  //  EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTadaris;
                 //   Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.MapMounakh:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Mounakh();
               //     EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTadaris;
               //     Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.MapPluie:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Pluie();
               //     EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTadaris;
               //     Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.MapTadaris:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Tadaris();
            //        EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTadaris;
            //        Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.MapTemperatures:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Temperatures();
                 //   EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.MapTadaris;
                 //   Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.Exam1:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.Exam.Exam1();
                //    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Exam1;
                 //   Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;
                case Model.Utilities.EtatAncienneSession.Exam2:
                    EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.Exam.Exam2();
                //    EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Exam2;
                 //   Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                    break;

            }
            //  Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
            EleveWindow.mettreAJourButtonToReturn();
            Commun.EtatAncienneSession.Content = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Commun.EtatAncienneSession.Content = null;
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }
    }
}
