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
    /// Logique d'interaction pour Tadaris.xaml
    /// </summary>
    public partial class Tadaris : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        public Tadaris()
        {
            InitializeComponent();
            c1.DataContext = c1;
            c2.DataContext = c2;
            c3.DataContext = c3;
            c4.DataContext = c4;
            c5.DataContext = c5;
            c6.DataContext = c6;
            c7.DataContext = c7;
            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[9].dejaFait)
                faitCheck.ToolTip = "لقد قمت بهذا التمرين من قبل. أعلى علامة لك بهذا التمرين : " + EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[9].note + " على 5 ";
            else
                faitCheck.Visibility = Visibility.Hidden;

            Commun.IDCouleur = 1;
            timer = new DispatcherTimer();
            _time = TimeSpan.FromSeconds(120);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object o, EventArgs a)
        {
            textBlock2.Text = _time.Minutes.ToString() + ":" + _time.Seconds.ToString();
            _time = _time.Add(TimeSpan.FromSeconds(-1));
            if (_time.TotalSeconds.CompareTo(0) == 0)
            {
                double note = 0;
                int nbCor = 0;
                button.Click -= button_Click;
                timer.Stop();
                textBlock2.Text = "0:0";
                if (p1.Fill.ToString() == c1.Fill.ToString() &&
               p2.Fill.ToString() == c2.Fill.ToString() &&
               p31.Fill.ToString() == c3.Fill.ToString() &&
               p32.Fill.ToString() == c3.Fill.ToString() &&
               p33.Fill.ToString() == c3.Fill.ToString() &&
               p41.Fill.ToString() == c4.Fill.ToString() &&
               p42.Fill.ToString() == c4.Fill.ToString() &&
               p43.Fill.ToString() == c4.Fill.ToString() &&
               p51.Fill.ToString() == c5.Fill.ToString() &&
               p52.Fill.ToString() == c5.Fill.ToString() &&
               p53.Fill.ToString() == c5.Fill.ToString() &&
               p61.Fill.ToString() == c6.Fill.ToString() &&
               p62.Fill.ToString() == c6.Fill.ToString() &&
               p7.Fill.ToString() == c7.Fill.ToString())
                {
                    nbCor = 14;
                    note = 10;
                }
                else
                {
                    if (p1.Fill.ToString() == c1.Fill.ToString())
                    { note++; nbCor++; }
                    if (p2.Fill.ToString() == c2.Fill.ToString())
                    {
                        note++; nbCor++;
                    }
                    if (p31.Fill.ToString() == c3.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p32.Fill.ToString() == c3.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p33.Fill.ToString() == c3.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p41.Fill.ToString() == c4.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p42.Fill.ToString() == c4.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p43.Fill.ToString() == c4.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p51.Fill.ToString() == c5.Fill.ToString())
                    {
                        note++; nbCor++;
                    }
                    if (p52.Fill.ToString() == c5.Fill.ToString())
                    {
                        note++; nbCor++;
                    }
                    if (p53.Fill.ToString() == c5.Fill.ToString())
                    {
                        note++; nbCor++;
                    }
                    if (p61.Fill.ToString() == c6.Fill.ToString())
                    {
                        note += 0.5; nbCor++;
                    }
                    if (p62.Fill.ToString() == c6.Fill.ToString())
                    { note += 0.5; nbCor++; }
                    if (p7.Fill.ToString() == c7.Fill.ToString())
                    {
                        note++; nbCor++;
                    }



                    p1.Fill = c1.Fill;
                    p2.Fill = c2.Fill;
                    p31.Fill = c3.Fill;
                    p32.Fill = c3.Fill;
                    p33.Fill = c3.Fill;
                    p41.Fill = c4.Fill;
                    p42.Fill = c4.Fill;
                    p43.Fill = c4.Fill;
                    p51.Fill = c5.Fill;
                    p52.Fill = c5.Fill;
                    p53.Fill = c5.Fill;
                    p61.Fill = c6.Fill;
                    p62.Fill = c6.Fill;
                    p7.Fill = c7.Fill;
                    p7.AllowDrop = false;
                    p1.AllowDrop = false;
                    p2.AllowDrop = false;
                    p31.AllowDrop = false;
                    p32.AllowDrop = false;
                    p33.AllowDrop = false;
                    p41.AllowDrop = false;
                    p42.AllowDrop = false;
                    p43.AllowDrop = false;
                    p51.AllowDrop = false;
                    p52.AllowDrop = false;
                    p53.AllowDrop = false;
                    p61.AllowDrop = false;
                    p62.AllowDrop = false;
                    p7.AllowDrop = false;

                }
                Commun.nombreDeReponsesJustesCouleur = nbCor;
                Commun.noteCouleur = (float)note / (float)2.0;
                Commun.nombreDeReponsesCouleur = 14;
                Model.Utilities.StructExo exo;
                exo.dejaFait = true;
                exo.cours = 1;
                exo.type = Model.Utilities.TypeQuestion.Cartes;
                exo.note = Model.Utilities.max((float)note / (float)2.0,
                   EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[9].note);
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[9] = exo;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button1.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
            }
        }


        private void Path_Drop(object sender, DragEventArgs e)
        {
            Path p = e.Data.GetData(typeof(Path)) as Path;
            ((Path)sender).Fill = p.Fill;
        }

        private void Path_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Mouse.SetCursor(Cursors.Hand);
            e.Handled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double note = 0;
            int nbCor = 0;
            button.Click -= button_Click;
            timer.Stop();
            textBlock2.Text = "0:0";
            if (p1.Fill.ToString() == c1.Fill.ToString() &&
                p2.Fill.ToString() == c2.Fill.ToString() &&
                p31.Fill.ToString() == c3.Fill.ToString() &&
                p32.Fill.ToString() == c3.Fill.ToString() &&
                p33.Fill.ToString() == c3.Fill.ToString() &&
                p41.Fill.ToString() == c4.Fill.ToString() &&
                p42.Fill.ToString() == c4.Fill.ToString() &&
                p43.Fill.ToString() == c4.Fill.ToString() &&
                p51.Fill.ToString() == c5.Fill.ToString() &&
                p52.Fill.ToString() == c5.Fill.ToString() &&
                p53.Fill.ToString() == c5.Fill.ToString() &&
                p61.Fill.ToString() == c6.Fill.ToString() &&
                p62.Fill.ToString() == c6.Fill.ToString() &&
                p7.Fill.ToString() == c7.Fill.ToString())
            {
                nbCor = 14;
                note = 10;
            }
            else
            {
                if (p1.Fill.ToString() == c1.Fill.ToString())
                { note++; nbCor++; }
                if (p2.Fill.ToString() == c2.Fill.ToString())
                {
                    note++; nbCor++;
                }
                if (p31.Fill.ToString() == c3.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p32.Fill.ToString() == c3.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p33.Fill.ToString() == c3.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p41.Fill.ToString() == c4.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p42.Fill.ToString() == c4.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p43.Fill.ToString() == c4.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p51.Fill.ToString() == c5.Fill.ToString())
                {
                    note++; nbCor++;
                }
                if (p52.Fill.ToString() == c5.Fill.ToString())
                {
                    note++; nbCor++;
                }
                if (p53.Fill.ToString() == c5.Fill.ToString())
                {
                    note++; nbCor++;
                }
                if (p61.Fill.ToString() == c6.Fill.ToString())
                {
                    note += 0.5; nbCor++;
                }
                if (p62.Fill.ToString() == c6.Fill.ToString())
                { note += 0.5; nbCor++; }
                if (p7.Fill.ToString() == c7.Fill.ToString())
                {
                    note++; nbCor++;
                }



                p1.Fill = c1.Fill;
                p2.Fill = c2.Fill;
                p31.Fill = c3.Fill;
                p32.Fill = c3.Fill;
                p33.Fill = c3.Fill;
                p41.Fill = c4.Fill;
                p42.Fill = c4.Fill;
                p43.Fill = c4.Fill;
                p51.Fill = c5.Fill;
                p52.Fill = c5.Fill;
                p53.Fill = c5.Fill;
                p61.Fill = c6.Fill;
                p62.Fill = c6.Fill;
                p7.Fill = c7.Fill;
                p7.AllowDrop = false;
                p1.AllowDrop = false;
                p2.AllowDrop = false;
                p31.AllowDrop = false;
                p32.AllowDrop = false;
                p33.AllowDrop = false;
                p41.AllowDrop = false;
                p42.AllowDrop = false;
                p43.AllowDrop = false;
                p51.AllowDrop = false;
                p52.AllowDrop = false;
                p53.AllowDrop = false;
                p61.AllowDrop = false;
                p62.AllowDrop = false;
                p7.AllowDrop = false;

            }
            Commun.nombreDeReponsesJustesCouleur = nbCor;
            Commun.noteCouleur = (float)note / (float)2.0;
            Commun.nombreDeReponsesCouleur = 14;
            Model.Utilities.StructExo exo;
            exo.dejaFait = true;
            exo.cours = 1;
            exo.type = Model.Utilities.TypeQuestion.Cartes;
            exo.note = Model.Utilities.max((float)note / (float)2.0,
               EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[9].note);
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[9] = exo;
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
