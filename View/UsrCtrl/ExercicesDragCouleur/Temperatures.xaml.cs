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
using Nicenis;
using Projet.UserControls.ELEVE;

namespace Projet.View.UsrCtrl.ExercicesDragCouleur
{
    /// <summary>
    /// Logique d'interaction pour Temperatures.xaml
    /// </summary>
    public partial class Temperatures : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        public Temperatures()
        {
            InitializeComponent();
            m1.DataContext = m1;
            m2.DataContext = m2;
            m3.DataContext = m3;
            m4.DataContext = m4;
            m5.DataContext = m5;
            m6.DataContext = m6;
            m7.DataContext = m7;
            m8.DataContext = m8;
            m9.DataContext = m9;
            m10.DataContext = m10;
            if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[12].dejaFait)
                faitCheck.ToolTip = "لقد قمت بهذا التمرين من قبل. أعلى علامة لك بهذا التمرين : " + EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[12].note + " على 5 ";
            else
                faitCheck.Visibility = Visibility.Hidden;
            Commun.IDCouleur = 2;
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
                button.Click -= button_Click;
                timer.Stop();
                textBlock16.Text = "0:0";
                if (i1.Source.Equals(m1.Source) && i2.Source.Equals(m5.Source) && i3.Source.Equals(m2.Source) && i4.Source.Equals(m3.Source) && i5.Source.Equals(m4.Source) && i6.Source.Equals(m6.Source) && i7.Source.Equals(m7.Source) && i8.Source.Equals(m8.Source) && i9.Source.Equals(m9.Source) && i10.Source.Equals(m10.Source))
                {
                    nbCor = 10;
                    note = 10;
                }
                else
                {
                    if (i1.Source.Equals(m1.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i2.Source.Equals(m5.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i3.Source.Equals(m2.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i4.Source.Equals(m3.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i5.Source.Equals(m4.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i6.Source.Equals(m6.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i7.Source.Equals(m7.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i8.Source.Equals(m8.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i9.Source.Equals(m9.Source))
                    {
                        note++;
                        nbCor++;
                    }
                    if (i10.Source.Equals(m10.Source))
                    {
                        note++;
                        nbCor++;
                    }


                    i1.Source = (m1.Source);
                    i2.Source = (m5.Source);
                    i3.Source = (m2.Source);
                    i4.Source = (m3.Source);
                    i5.Source = (m4.Source);
                    i6.Source = (m6.Source);
                    i7.Source = (m7.Source);
                    i8.Source = (m8.Source);
                    i9.Source = (m9.Source);
                    i10.Source = (m10.Source);
                    i1.AllowDrop = false;
                    i2.AllowDrop = false;
                    i3.AllowDrop = false;
                    i4.AllowDrop = false;
                    i5.AllowDrop = false;
                    i6.AllowDrop = false;
                    i7.AllowDrop = false;
                    i8.AllowDrop = false;
                    i9.AllowDrop = false;
                    i10.AllowDrop = false;

                }
                Commun.nombreDeReponsesJustesCouleur = nbCor;
                Commun.noteCouleur = note / (float)2.0;
                Commun.nombreDeReponsesCouleur = 10;
                Model.Utilities.StructExo exo;
                exo.dejaFait = true;
                exo.cours = 2;
                exo.type = Model.Utilities.TypeQuestion.Cartes;
                exo.note = Model.Utilities.max(note / (float)2.0,
                   EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[12].note);
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[12] = exo;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button1.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
            }
        }
        /*    private void Image_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //Point currentPosition = e.GetPosition(null);

                    Image path = e.Source as Image;

                    var dragData = new DataObject(typeof(Image), path);
                    DragDrop.DoDragDrop(dragSource: path,
                                        data: dragData,
                                        allowedEffects: DragDropEffects.Copy);
                }
            }*/

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
            button.Click -= button_Click;
            float note = 0;
            int nbCor = 0;
            timer.Stop();
            textBlock16.Text = "0:0";
            if (i1.Source.Equals(m1.Source) && i2.Source.Equals(m5.Source) && i3.Source.Equals(m2.Source) && i4.Source.Equals(m3.Source) && i5.Source.Equals(m4.Source) && i6.Source.Equals(m6.Source) && i7.Source.Equals(m7.Source) && i8.Source.Equals(m8.Source) && i9.Source.Equals(m9.Source) && i10.Source.Equals(m10.Source))
            {
                nbCor = 10;
                note = 10;
            }
            else
            {
                if (i1.Source.Equals(m1.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i2.Source.Equals(m5.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i3.Source.Equals(m2.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i4.Source.Equals(m3.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i5.Source.Equals(m4.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i6.Source.Equals(m6.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i7.Source.Equals(m7.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i8.Source.Equals(m8.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i9.Source.Equals(m9.Source))
                {
                    note++;
                    nbCor++;
                }
                if (i10.Source.Equals(m10.Source))
                {
                    note++;
                    nbCor++;
                }


                i1.Source = (m1.Source);
                i2.Source = (m5.Source);
                i3.Source = (m2.Source);
                i4.Source = (m3.Source);
                i5.Source = (m4.Source);
                i6.Source = (m6.Source);
                i7.Source = (m7.Source);
                i8.Source = (m8.Source);
                i9.Source = (m9.Source);
                i10.Source = (m10.Source);
                i1.AllowDrop = false;
                i2.AllowDrop = false;
                i3.AllowDrop = false;
                i4.AllowDrop = false;
                i5.AllowDrop = false;
                i6.AllowDrop = false;
                i7.AllowDrop = false;
                i8.AllowDrop = false;
                i9.AllowDrop = false;
                i10.AllowDrop = false;

            }
            Commun.nombreDeReponsesJustesCouleur = nbCor;
            Commun.noteCouleur = note / (float)2.0;
            Commun.nombreDeReponsesCouleur = 10;
            Model.Utilities.StructExo exo;
            exo.dejaFait = true;
            exo.cours = 2;
            exo.type = Model.Utilities.TypeQuestion.Cartes;
            exo.note = Model.Utilities.max(note / (float)2.0,
               EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[12].note);
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[12] = exo;
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
