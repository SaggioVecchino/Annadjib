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

namespace Projet.View.UsrCtrl.Exercices
{
    /// <summary>
    /// Logique d'interaction pour Exercice.xaml
    /// </summary>
    public partial class Exercice : UserControl
    {
        public Exercice()
        {
            InitializeComponent();
            Commun.ExerciceTemps = Temps;
            Commun.ExerciceQuestion = Question;
            Commun.ExerciceReponse = Reponse;
            Commun.ExerciceReponse.Content = new BonneReponseVide();
            Commun.ExerciceTemps.Content = new ExerciceTemps();
        }

    }
}
