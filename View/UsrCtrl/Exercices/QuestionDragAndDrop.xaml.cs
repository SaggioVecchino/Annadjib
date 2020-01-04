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
using Projet.UserControls.ELEVE;
namespace Projet.View.UsrCtrl.Exercices
{
    /// <summary>
    /// Logique d'interaction pour QuestionDragAndDrop.xaml
    /// </summary>
    public partial class QuestionDragAndDrop : UserControl
    {
        public QuestionDragAndDrop()
        {
            InitializeComponent();
            NextQuestion.IsEnabled = false;
            this.Temps.Content = new ExerciceTemps();
            ModelView.DragAndDropVM dp = new ModelView.DragAndDropVM(this);
            dp.CreateTextBlocks((Model.DragAndDrop)EleveUserControl.Environnement.question);
            dp.CreateAnswersBlocks((Model.DragAndDrop)EleveUserControl.Environnement.question);

        }

        private void Sumbit_Click(object sender, RoutedEventArgs e)
        {
            ModelView.DragAndDropVM dp = new ModelView.DragAndDropVM(this);
            dp.getAnswers((Model.DragAndDrop)EleveUserControl.Environnement.question);
            Sumbit.IsEnabled = false;
            NextQuestion.IsEnabled = true;
            Choices.Text = "الجواب الصحيح";
            dp.correctAnswer((Model.DragAndDrop)EleveUserControl.Environnement.question);
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.eleveConnecte.QuestionSuivante();
            Sumbit.IsEnabled = true;

            if (EleveUserControl.Environnement.question== EleveUserControl.Environnement.exercice.exercice[2])
            {
                NextQuestion.Content = "النتيجة";
                NextQuestion.IsEnabled = true;

            }
            if (EleveUserControl.Environnement.question == null)
            {
                EleveUserControl.Environnement.eleveConnecte.Corriger();
                Commun.Note.Content = new Note();
                return;
            }
            NextQuestion.IsEnabled = false;
            Choices.Text = "الاختيارات";
            ModelView.DragAndDropVM dp = new ModelView.DragAndDropVM(this);
            dp.CreateTextBlocks((Model.DragAndDrop)EleveUserControl.Environnement.question);
            dp.CreateAnswersBlocks((Model.DragAndDrop)EleveUserControl.Environnement.question);

        }
    }
}
