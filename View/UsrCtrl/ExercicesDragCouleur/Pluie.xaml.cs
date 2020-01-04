using Projet.UserControls.ELEVE;
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

namespace Projet.View.UsrCtrl.ExercicesDragCouleur
{
    /// <summary>
    /// Logique d'interaction pour Pluie.xaml
    /// </summary>
    ///  internal DispatcherTimer timer ;

    public partial class Pluie : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        public Pluie()
        {
            InitializeComponent();
            c1.DataContext = c1;
            c2.DataContext = c2;
            c3.DataContext = c3;
            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[13].dejaFait)
                faitCheck.ToolTip = "لقد قمت بهذا التمرين من قبل. أعلى علامة لك بهذا التمرين : " + EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[13].note + " على 5 ";
            else
                faitCheck.Visibility = Visibility.Hidden;
            Commun.IDCouleur = 3;
            timer = new DispatcherTimer();
            _time = TimeSpan.FromSeconds(120);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object o, EventArgs a)
        {

            textBlock.Text = _time.Minutes.ToString() + ":" + _time.Seconds.ToString();
            _time = _time.Add(TimeSpan.FromSeconds(-1));
            if (_time.TotalSeconds.CompareTo(0) == 0)
            {
                float note = 0;
                int nbCor = 0;
                button.Click -= button_Click;
                timer.Stop();
                textBlock.Text = "0:0";
                if (p1.Fill.ToString() == c3.Fill.ToString() && p2.Fill.ToString() == c2.Fill.ToString() && p3.Fill.ToString() == c1.Fill.ToString() && p4.Fill.ToString() == c2.Fill.ToString() && p5.Fill.ToString() == c2.Fill.ToString())
                {
                    nbCor = 5;
                    note = 5;
                }
                else
                {
                    if (p1.Fill.ToString() == c3.Fill.ToString())
                    {
                        nbCor++;
                        note++;
                    }
                    if (p2.Fill.ToString() == c2.Fill.ToString())
                    {
                        nbCor++;
                        note++;
                    }
                    if (p3.Fill.ToString() == c1.Fill.ToString())
                    {
                        nbCor++;
                        note++;
                    }
                    if (p4.Fill.ToString() == c2.Fill.ToString())
                    {
                        nbCor++;
                        note++;
                    }
                    if (p5.Fill.ToString() == c2.Fill.ToString())
                    {
                        nbCor++;
                        note++;
                    }


                    p1.Fill = c3.Fill;
                    p2.Fill = c2.Fill;
                    p3.Fill = c1.Fill;
                    p4.Fill = c2.Fill;
                    p5.Fill = c2.Fill;
                    p1.AllowDrop = false;
                    p2.AllowDrop = false;
                    p3.AllowDrop = false;
                    p4.AllowDrop = false;
                    p5.AllowDrop = false;
                }
                Commun.nombreDeReponsesJustesCouleur = nbCor;
                Commun.noteCouleur = note;
                Commun.nombreDeReponsesCouleur = 5;
                Model.Utilities.StructExo exo;
                exo.dejaFait = true;
                exo.cours = 3;
                exo.type = Model.Utilities.TypeQuestion.Cartes;
                exo.note = Model.Utilities.max(note,
                   EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[13].note);
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[13] = exo;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button1.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
            }
        }

        private void Path_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Mouse.SetCursor(Cursors.Hand);
            e.Handled = true;
        }

        private void p1_Drop(object sender, DragEventArgs e)
        {
            Path p = e.Data.GetData(typeof(Path)) as Path;
            ((Path)sender).Fill = p.Fill;
            //  Mouse.OverrideCursor = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.NoteCouleur();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.Click -= button_Click;
            float note = 0;
            int nbCor = 0;
            timer.Stop();
            textBlock.Text = "0:0";
            if (p1.Fill.ToString() == c3.Fill.ToString() && p2.Fill.ToString() == c2.Fill.ToString() && p3.Fill.ToString() == c1.Fill.ToString() && p4.Fill.ToString() == c2.Fill.ToString() && p5.Fill.ToString() == c2.Fill.ToString())
            {
                nbCor = 5;
                note = 5;
            }
            else
            {
                if (p1.Fill.ToString() == c3.Fill.ToString())
                {
                    nbCor++;
                    note++;
                }
                if (p2.Fill.ToString() == c2.Fill.ToString())
                {
                    nbCor++;
                    note++;
                }
                if (p3.Fill.ToString() == c1.Fill.ToString())
                {
                    nbCor++;
                    note++;
                }
                if (p4.Fill.ToString() == c2.Fill.ToString())
                {
                    nbCor++;
                    note++;
                }
                if (p5.Fill.ToString() == c2.Fill.ToString())
                {
                    nbCor++;
                    note++;
                }


                p1.Fill = c3.Fill;
                p2.Fill = c2.Fill;
                p3.Fill = c1.Fill;
                p4.Fill = c2.Fill;
                p5.Fill = c2.Fill;
                p1.AllowDrop = false;
                p2.AllowDrop = false;
                p3.AllowDrop = false;
                p4.AllowDrop = false;
                p5.AllowDrop = false;
            }
            Commun.nombreDeReponsesJustesCouleur = nbCor;
            Commun.noteCouleur = note;
            Commun.nombreDeReponsesCouleur = 5;
            Model.Utilities.StructExo exo;
            exo.dejaFait = true;
            exo.cours = 3;
            exo.type = Model.Utilities.TypeQuestion.Cartes;
            exo.note = Model.Utilities.max(note,
               EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[13].note);
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[13] = exo;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
            button1.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
        }
    }

}

