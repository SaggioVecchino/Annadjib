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
    /// Logique d'interaction pour ExerciceReponse.xaml
    /// </summary>
    public partial class ExerciceReponse : UserControl
    {

        public ExerciceReponse()
        {

            InitializeComponent();
            switch (EleveUserControl.Environnement.exercice.type)
            {
                case Model.Utilities.TypeQuestion.QCM:
                    {
                        DataContext = (Model.QCM)EleveUserControl.Environnement.question;
                    }
                    break;
                case Model.Utilities.TypeQuestion.TrueOrFalse:
                    {
                        DataContext = (Model.TrueOrFalse)EleveUserControl.Environnement.question;
                    }
                    break;
            }

        }

        private void buttonSuiv_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.Environnement.eleveConnecte.QuestionSuivante();

            if (EleveUserControl.Environnement.question == null)
            {
                EleveUserControl.Environnement.eleveConnecte.Corriger();
                Commun.Note.Content = new Note();
                return;
            }
            switch (EleveUserControl.Environnement.exercice.type)
            {
                case Model.Utilities.TypeQuestion.QCM:
                    {
                        Commun.ExerciceQuestion.Content = new QuestionQCM();
                        Commun.ExerciceReponse.Content = new BonneReponseVide();
                    }
                    break;
                case Model.Utilities.TypeQuestion.TrueOrFalse:
                    {
                        Commun.ExerciceQuestion.Content = new QuestionTrueOrFalse();
                        Commun.ExerciceReponse.Content = new BonneReponseVide();
                    }
                    break;
            }
        }
    }
}
