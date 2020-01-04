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
    /// Logique d'interaction pour Mounakh.xaml
    /// </summary>
    public partial class Mounakh : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        public Mounakh()
        {
            InitializeComponent();
            c2.DataContext = c2;
            c1.DataContext = c1;
            c3.DataContext = c3;
            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[11].dejaFait)
                faitCheck.ToolTip = "لقد قمت بهذا التمرين من قبل. أعلى علامة لك بهذا التمرين : " + EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[11].note + " على 5 ";
            else
                faitCheck.Visibility = Visibility.Hidden;
            Commun.IDCouleur = 2;
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
                if (path1.Fill.ToString() == c1.Fill.ToString() && path2.Fill.ToString() == c2.Fill.ToString() && path3.Fill.ToString() == c3.Fill.ToString())
                {

                    note = 5;
                    nbCor = 3;
                }
                else
                {

                    if (path1.Fill.ToString() == c1.Fill.ToString())
                    {
                        note += 2;
                        nbCor++;
                    }
                    if (path2.Fill.ToString() == c2.Fill.ToString())
                    {
                        note += 2;
                        nbCor++;
                    }
                    if (path3.Fill.ToString() == c3.Fill.ToString())
                    {
                        note += 1;
                        nbCor++;
                    }
                    path1.Fill = c1.Fill;
                    path2.Fill = c2.Fill;
                    path3.Fill = c3.Fill;
                    path1.AllowDrop = false;
                    path2.AllowDrop = false;
                    path3.AllowDrop = false;

                }
                Commun.nombreDeReponsesJustesCouleur = nbCor;
                Commun.noteCouleur = note;
                Commun.nombreDeReponsesCouleur = 3;
                Model.Utilities.StructExo exo;
                exo.dejaFait = true;
                exo.cours = 2;
                exo.type = Model.Utilities.TypeQuestion.Cartes;
                exo.note = Model.Utilities.max(note,
                   EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[11].note);
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[11] = exo;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button1.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;

            }
        }


        private void Path_Drop(object sender, DragEventArgs e)
        {
            Path p = e.Data.GetData(typeof(Path)) as Path;
            // ((Path)sender).Data = p.Data;
            ((Path)sender).Fill = p.Fill;
            Mouse.OverrideCursor = null;
        }

        private void Path_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Mouse.SetCursor(Cursors.Hand);
            e.Handled = true;
        }

        private void Path_DragEnter(object sender, DragEventArgs e)
        {
            Mouse.SetCursor(Cursors.Arrow);
            //Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void Path_DragLeave(object sender, DragEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }

        private void Path_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.Click -= button_Click;
            float note = 0;
            int nbCor = 0;
            timer.Stop();
            textBlock.Text = "0:0";
            if (path1.Fill.ToString() == c1.Fill.ToString() && path2.Fill.ToString() == c2.Fill.ToString() && path3.Fill.ToString() == c3.Fill.ToString())
            {

                note = 5;
                nbCor = 3;
            }
            else
            {

                if (path1.Fill.ToString() == c1.Fill.ToString())
                {
                    note += 2;
                    nbCor++;
                }
                if (path2.Fill.ToString() == c2.Fill.ToString())
                {
                    note += 2;
                    nbCor++;
                }
                if (path3.Fill.ToString() == c3.Fill.ToString())
                {
                    note += 1;
                    nbCor++;
                }
                path1.Fill = c1.Fill;
                path2.Fill = c2.Fill;
                path3.Fill = c3.Fill;
                path1.AllowDrop = false;
                path2.AllowDrop = false;
                path3.AllowDrop = false;

            }
            Commun.nombreDeReponsesJustesCouleur = nbCor;
            Commun.noteCouleur = note;
            Commun.nombreDeReponsesCouleur = 3;
            Model.Utilities.StructExo exo;
            exo.dejaFait = true;
            exo.cours = 2;
            exo.type = Model.Utilities.TypeQuestion.Cartes;

            exo.note = Model.Utilities.max(note,
               EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[11].note);
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[11] = exo;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
            button1.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.NoteCouleur();
        }

    }
}
