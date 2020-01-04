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
    /// Logique d'interaction pour QuestionQCM.xaml
    /// </summary>
    public partial class QuestionQCM : UserControl
    {
        public QuestionQCM()
        {
            InitializeComponent();
            DataContext = (Model.QCM)EleveUserControl.Environnement.question;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            // checkBox.IsChecked = true;
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            textBlock2.Visibility = Visibility.Hidden;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;
            //  checkBox1.IsChecked = true;
            checkBox2.IsChecked = false;
            textBlock2.Visibility = Visibility.Hidden;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;
            checkBox1.IsChecked = false;
            // checkBox2.IsChecked = true;
            textBlock2.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox.IsChecked || (bool)checkBox1.IsChecked || (bool)checkBox2.IsChecked)
            {
                button.Visibility = Visibility.Hidden;
                Commun.ExerciceReponse.Content = new ExerciceReponse();
                if (EleveUserControl.Environnement.exercice.type == Model.Utilities.TypeQuestion.QCM)
                {
                    if ((bool)checkBox.IsChecked) ((Model.QCM)EleveUserControl.Environnement.question).Reponse = 1;
                    else if ((bool)checkBox1.IsChecked) ((Model.QCM)EleveUserControl.Environnement.question).Reponse = 2;
                    else ((Model.QCM)EleveUserControl.Environnement.question).Reponse = 3;
                }
                else if (EleveUserControl.Environnement.exercice.type == Model.Utilities.TypeQuestion.TrueOrFalse) { }
                return;
            }
            textBlock2.Visibility = Visibility.Visible;
        }
    }
}
