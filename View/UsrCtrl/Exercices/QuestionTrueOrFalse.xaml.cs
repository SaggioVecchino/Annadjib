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
    /// Logique d'interaction pour QuestionTrueOrFalse.xaml
    /// </summary>
    public partial class QuestionTrueOrFalse : UserControl
    {
        public QuestionTrueOrFalse()
        {
            InitializeComponent();
            DataContext = (Model.TrueOrFalse) EleveUserControl.Environnement.question;
        }

        private void buttonTrue_Click(object sender, RoutedEventArgs e)
        {
            ((Model.TrueOrFalse)EleveUserControl.Environnement.question).Reponse = true;
            buttonFalse.Visibility = Visibility.Hidden;
            buttonTrue.Visibility = Visibility.Hidden;
            Commun.ExerciceReponse.Content = new ExerciceReponse();
        }

        private void buttonFalse_Click(object sender, RoutedEventArgs e)
        {
            ((Model.TrueOrFalse)EleveUserControl.Environnement.question).Reponse = false;
            buttonFalse.Visibility = Visibility.Hidden;
            buttonTrue.Visibility = Visibility.Hidden;
            Commun.ExerciceReponse.Content = new ExerciceReponse();
        }
    }
}
