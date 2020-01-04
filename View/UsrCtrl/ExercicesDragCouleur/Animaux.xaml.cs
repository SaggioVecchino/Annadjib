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
    /// Logique d'interaction pour Animaux.xaml
    /// </summary>
    public partial class Animaux : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        public Animaux()
        {
            InitializeComponent();
            Commun.IDCouleur = 2;
            m1.DataContext = m1;
            m2.DataContext = m2;
            m3.DataContext = m3;
            m4.DataContext = m4;
            m5.DataContext = m5;
            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[10].dejaFait)
                faitCheck.ToolTip = "لقد قمت بهذا التمرين من قبل. أعلى علامة لك بهذا التمرين : " + EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[10].note + " على 5 ";
            else
                faitCheck.Visibility = Visibility.Hidden;

            timer = new DispatcherTimer();
            _time = TimeSpan.FromSeconds(60);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object o, EventArgs a)
        {
            textBlock16.Text = _time.Minutes.ToString() + ":" + _time.Seconds.ToString();
            _time = _time.Add(TimeSpan.FromSeconds(-1));
            if (_time.TotalSeconds.CompareTo(0) == 0)
            {
                float note = 0;
                int nbCor = 0;
                timer.Stop();
                textBlock16.Text = "0:0";
                if (i1.Source.Equals(m1.Source) && (i2.Source.Equals(m2.Source) || i2.Source.Equals(m3.Source)) && (i3.Source.Equals(m2.Source) || i3.Source.Equals(m3.Source)) && (i4.Source.Equals(m4.Source) || i4.Source.Equals(m5.Source)) && (i5.Source.Equals(m4.Source) || i5.Source.Equals(m5.Source)))
                {
                    note = 5;
                    nbCor = 5;

                }
                else
                {
                    if (i1.Source.Equals(m1.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i2.Source.Equals(m2.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i3.Source.Equals(m3.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i4.Source.Equals(m4.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i5.Source.Equals(m5.Source))
                    {
                        note++;
                        nbCor++;
                    }

                    i1.Source = (m1.Source);
                    i2.Source = (m2.Source);
                    i3.Source = (m3.Source);
                    i4.Source = (m4.Source);
                    i5.Source = (m5.Source);

                    i1.AllowDrop = false;
                    i2.AllowDrop = false;
                    i3.AllowDrop = false;
                    i4.AllowDrop = false;
                    i5.AllowDrop = false;
                }
                Commun.nombreDeReponsesJustesCouleur = nbCor;
                Commun.noteCouleur = note;
                Commun.nombreDeReponsesCouleur = 5;
                Model.Utilities.StructExo exo;
                exo.dejaFait = true;
                exo.cours = 2;
                exo.type = Model.Utilities.TypeQuestion.Cartes;
                exo.note = Model.Utilities.max(note,
                   EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[10].note);
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[10] = exo;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button1.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
            }
        }


        private void Image_Drop(object sender, DragEventArgs e)
        {
            Image p = e.Data.GetData(typeof(Image)) as Image;
            ((Image)sender).Source = p.Source;
            //   Mouse.OverrideCursor = null;
        }

        private void Image_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Mouse.SetCursor(Cursors.Hand);
            e.Handled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            float note = 0;
            int nbCor = 0;
            timer.Stop();
            textBlock16.Text = "0:0";
            if (i1.Source.Equals(m1.Source) &&
                (i2.Source.Equals(m2.Source) || i2.Source.Equals(m3.Source)) &&
                (i3.Source.Equals(m2.Source) || i3.Source.Equals(m3.Source)) &&
                (i4.Source.Equals(m4.Source) || i4.Source.Equals(m5.Source)) &&
                (i5.Source.Equals(m4.Source) || i5.Source.Equals(m5.Source)))
            {
                note = 5;
                nbCor = 5;

            }
            else
            {
                if (i1.Source.Equals(m1.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i2.Source.Equals(m2.Source) || i2.Source.Equals(m3.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i3.Source.Equals(m2.Source) || i3.Source.Equals(m3.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i4.Source.Equals(m4.Source) || i4.Source.Equals(m5.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i5.Source.Equals(m4.Source) || i5.Source.Equals(m5.Source))
                {
                    note++;
                    nbCor++;
                }

                i1.Source = (m1.Source);
                i2.Source = (m2.Source);
                i3.Source = (m3.Source);
                i4.Source = (m4.Source);
                i5.Source = (m5.Source);

                i1.AllowDrop = false;
                i2.AllowDrop = false;
                i3.AllowDrop = false;
                i4.AllowDrop = false;
                i5.AllowDrop = false;
            }
            Commun.nombreDeReponsesJustesCouleur = nbCor;
            Commun.noteCouleur = note;
            Commun.nombreDeReponsesCouleur = 5;
            Model.Utilities.StructExo exo;
            exo.dejaFait = true;
            exo.cours = 2;
            exo.type = Model.Utilities.TypeQuestion.Cartes;
            exo.note = Model.Utilities.max(note,
               EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[10].note);
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[10] = exo;
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

