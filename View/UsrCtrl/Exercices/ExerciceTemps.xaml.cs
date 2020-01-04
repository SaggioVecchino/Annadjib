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
using System.Windows.Threading;
using Projet.UserControls.ELEVE;
using Projet.Model;
namespace Projet.View.UsrCtrl.Exercices
{
    /// <summary>
    /// Logique d'interaction pour ExerciceTemps.xaml
    /// </summary>
    public partial class ExerciceTemps : UserControl
    {

        internal static DispatcherTimer timer;
        internal TimeSpan _time;

        public ExerciceTemps()
        {
            InitializeComponent();

            



            int tmp = 0;
            switch (EleveUserControl.Environnement.exercice.type)
            {
                // case Utilities.TypeQuestion.QCM: tmp = 0; break; //Par défaut tmp = 0
                case Utilities.TypeQuestion.TrueOrFalse: tmp = 1; break;
                case Utilities.TypeQuestion.DragAndDrop: tmp = 2; break;
            }


            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[3 * tmp + EleveUserControl.Environnement.exercice.cours - 1].dejaFait)
                faitCheck.ToolTip = "لقد قمت بهذا التمرين من قبل. أعلى علامة لك بهذا التمرين : " + EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[3 * tmp + EleveUserControl.Environnement.exercice.cours - 1].note + " على 5 ";
            else
                faitCheck.Visibility = Visibility.Hidden;
            _time = TimeSpan.FromMinutes(EleveUserControl.Environnement.exercice.time);
            textBlock3.Text = _time.Minutes.ToString() + ":" + _time.Seconds.ToString();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object o, EventArgs a)
        {
            _time = _time.Add(TimeSpan.FromSeconds(-1));
            textBlock3.Text = _time.Minutes.ToString() + ":" + _time.Seconds.ToString();
            if (_time.TotalSeconds.CompareTo(15) == 0)
            {
                textBlock3.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }
            if (_time.TotalSeconds.CompareTo(0) == 0)
            {
                EleveUserControl.Environnement.eleveConnecte.Corriger();
                Commun.finTemps.Visibility = Visibility.Visible;
                Commun.Note.Content = new Note();
                textBlock3.Foreground = new SolidColorBrush(Colors.Black);
                timer.Stop();
                return;
            }
        }

        public static bool StopTemps()
        {
            try
            {
                timer.Stop();
                return true;
            }
            catch { return false; }
        }

    }
}
