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
namespace Projet.View.UsrCtrl.Exam
{
    /// <summary>
    /// Logique d'interaction pour Exam.xaml
    /// </summary>
    public partial class Exam2 : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        double note = 0;

        public Exam2()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            _time = TimeSpan.FromSeconds(480);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
            textBlock4.DataContext = textBlock4.Text;
            textBlock5.DataContext = textBlock5.Text;
            textBlock6.DataContext = textBlock6.Text;

            //

            textBlock5b.DataContext = textBlock5b.Text;
            textBlock6b.DataContext = textBlock6b.Text;
            textBlock7b.DataContext = textBlock7b.Text;
            //
            textBlock4c.DataContext = textBlock4c.Text;
            textBlock5c.DataContext = textBlock5c.Text;
            textBlock6c.DataContext = textBlock6c.Text;
            textBlock7c.DataContext = textBlock7c.Text;


        }

        private void Timer_Tick(object o, EventArgs a)
        {

            textBlock19.Text = _time.Minutes.ToString() + ":" + _time.Seconds.ToString();
            _time = _time.Add(TimeSpan.FromSeconds(-1));
            if (_time.TotalSeconds.CompareTo(0) == 0)
            {

                button.Click -= button_Click;
                timer.Stop();
                textBlock19.Text = "0:0";
                note = 0;
                int nbCorrect = 0;
                var bc = new BrushConverter();
                if (checkBox2.IsChecked == true)
                {
                    note++;
                    nbCorrect++;
                }
                else
                {
                    checkBox2.IsChecked = true;
                    checkBox.Visibility = Visibility.Collapsed;
                    checkBox1.Visibility = Visibility.Collapsed;
                }
                if (checkBox1b.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox1b.IsChecked = true;
                    checkBoxb.Visibility = Visibility.Collapsed;
                    checkBox2b.Visibility = Visibility.Collapsed;
                }
                if (checkBoxc.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxc.IsChecked = true;
                    checkBox2c.Visibility = Visibility.Collapsed;
                    checkBox1c.Visibility = Visibility.Collapsed;
                }

                ///

                if (checkBox1d.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox1d.IsChecked = true;
                    checkBoxd.Visibility = Visibility.Collapsed;
                }
                if (checkBoxe.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxe.IsChecked = true;
                    checkBox1e.Visibility = Visibility.Collapsed;
                }
                if (checkBoxf.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxf.IsChecked = true;
                    checkBox1f.Visibility = Visibility.Collapsed;
                }



                ///
                if (textBlock9.Text.Equals("مظاهر طبيعية متنوعة"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9.Text = "مظاهر طبيعية متنوعة";
                    textBlock9.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11.Text.Equals("منخفض"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11.Text = "منخفض";
                    textBlock11.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13.Text.Equals("سطح القارات"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13.Text = "سطح القارات";
                    textBlock13.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock9b.Text.Equals("صيف حار و جاف و شتاء دافئ و ممطر"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9b.Text = "صيف حار و جاف و شتاء دافئ و ممطر";
                    textBlock9b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11b.Text.Equals("صيف حار و جاف و شتاء بارد و ممطر"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11b.Text = "صيف حار و جاف و شتاء بارد و ممطر";
                    textBlock11b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13b.Text.Equals("صيف شديد الحرارة و شتاء شديد البرودة"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13b.Text = "صيف شديد الحرارة و شتاء شديد البرودة";
                    textBlock13b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }

                if (textBlock9c.Text.Equals("الأطلس التلي"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock9c.Text = "الأطلس التلي";
                    textBlock9c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11c.Text.Equals("السلسلة النوميدية"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock11c.Text = "السلسلة النوميدية";
                    textBlock11c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13c.Text.Equals("الأطلس الصحراوي"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock13c.Text = "الأطلس الصحراوي";
                    textBlock13c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock15c.Text.Equals("الأوراس"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock15c.Text = "الأوراس";
                    textBlock15c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }



                textBlock9.AllowDrop = false;
                textBlock11.AllowDrop = false;
                textBlock13.AllowDrop = false;
                textBlock9b.AllowDrop = false;
                textBlock11b.AllowDrop = false;
                textBlock13b.AllowDrop = false;

                textBlock9c.AllowDrop = false;
                textBlock11c.AllowDrop = false;
                textBlock13c.AllowDrop = false;
                textBlock15c.AllowDrop = false;

                EleveUserControl.Environnement.note = note;
                EleveUserControl.Environnement.note = note;
                if (EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam2 < note) EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam2 = note;
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exam2DejaFait = true;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button2.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
            }


        }


        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;

        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;

            checkBox2.IsChecked = false;

        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;
            checkBox1.IsChecked = false;


        }
        private void checkBox_Checkedb(object sender, RoutedEventArgs e)
        {

            checkBox1b.IsChecked = false;
            checkBox2b.IsChecked = false;

        }

        private void checkBox1_Checkedb(object sender, RoutedEventArgs e)
        {
            checkBoxb.IsChecked = false;

            checkBox2b.IsChecked = false;

        }

        private void checkBox2_Checkedb(object sender, RoutedEventArgs e)
        {
            checkBoxb.IsChecked = false;
            checkBox1b.IsChecked = false;


        }

        private void checkBox_Checkedc(object sender, RoutedEventArgs e)
        {

            checkBox1c.IsChecked = false;
            checkBox2c.IsChecked = false;

        }

        private void checkBox1_Checkedc(object sender, RoutedEventArgs e)
        {
            checkBoxc.IsChecked = false;

            checkBox2c.IsChecked = false;

        }

        private void checkBox2_Checkedc(object sender, RoutedEventArgs e)
        {
            checkBoxc.IsChecked = false;
            checkBox1c.IsChecked = false;


        }
        private void checkBox_Checkedd(object sender, RoutedEventArgs e)
        {
            checkBox1d.IsChecked = false;
        }

        private void checkBox1_Checkedd(object sender, RoutedEventArgs e)
        {
            checkBoxd.IsChecked = false;
        }
        private void checkBox_Checkede(object sender, RoutedEventArgs e)
        {
            checkBox1e.IsChecked = false;
        }

        private void checkBox1_Checkede(object sender, RoutedEventArgs e)
        {
            checkBoxe.IsChecked = false;
        }
        private void checkBox_Checkedf(object sender, RoutedEventArgs e)
        {
            checkBox1f.IsChecked = false;
        }

        private void checkBox1_Checkedf(object sender, RoutedEventArgs e)
        {
            checkBoxf.IsChecked = false;
        }

        private void textBlock9_Drop(object sender, DragEventArgs e)
        {
            ((TextBlock)sender).Text = e.Data.GetData(typeof(string)) as string;
        }






        private void button_Click(object sender, RoutedEventArgs e)
        {


            // on vérifie si l'élève appuie sur terminer avant de terminer complètement 
            if ((checkBox.IsChecked == false && checkBox1.IsChecked == false && checkBox2.IsChecked == false) ||
                     (checkBoxb.IsChecked == false && checkBox1b.IsChecked == false && checkBox2b.IsChecked == false) ||
                     (checkBoxc.IsChecked == false && checkBox1c.IsChecked == false && checkBox2c.IsChecked == false) ||
                       (checkBoxd.IsChecked == false && checkBox1d.IsChecked == false) ||
                     (checkBoxe.IsChecked == false && checkBox1e.IsChecked == false) ||
                     (checkBoxf.IsChecked == false && checkBox1f.IsChecked == false) ||
                      (textBlock9.Text == "--------------" || textBlock11.Text == "-------" || textBlock13.Text == "-------") ||
                      (textBlock9b.Text == "----------------------------" ||
                      textBlock11b.Text == "----------------------------" ||
                      textBlock13b.Text == "----------------------------" ||
                      (textBlock9c.Text == "--------------" || textBlock11c.Text == "--------------" ||
                      textBlock13c.Text == "--------------" || textBlock15c.Text == "-------")))


            {
                textBlock22.Visibility = Visibility.Visible;
                textBlock22.Text = "لم تجب على كل الاسئلة";
            }
            else
            {

                textBlock22.Visibility = Visibility.Hidden;
                button.Click -= button_Click;
                timer.Stop();
                textBlock19.Text = "0:0";
                note = 0;
                int nbCorrect = 0;
                var bc = new BrushConverter();
                if (checkBox2.IsChecked == true)
                {
                    note++;
                    nbCorrect++;
                }
                else
                {
                    checkBox2.IsChecked = true;
                    checkBox.Visibility = Visibility.Collapsed;
                    checkBox1.Visibility = Visibility.Collapsed;
                }
                if (checkBox1b.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox1b.IsChecked = true;
                    checkBoxb.Visibility = Visibility.Collapsed;
                    checkBox2b.Visibility = Visibility.Collapsed;
                }
                if (checkBoxc.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxc.IsChecked = true;
                    checkBox2c.Visibility = Visibility.Collapsed;
                    checkBox1c.Visibility = Visibility.Collapsed;
                }

                ///

                if (checkBox1d.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox1d.IsChecked = true;
                    checkBoxd.Visibility = Visibility.Collapsed;
                }
                if (checkBoxe.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxe.IsChecked = true;
                    checkBox1e.Visibility = Visibility.Collapsed;
                }
                if (checkBoxf.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxf.IsChecked = true;
                    checkBox1f.Visibility = Visibility.Collapsed;
                }



                ///
                if (textBlock9.Text.Equals("مظاهر طبيعية متنوعة"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9.Text = "مظاهر طبيعية متنوعة";
                    textBlock9.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11.Text.Equals("منخفض"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11.Text = "منخفض";
                    textBlock11.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13.Text.Equals("سطح القارات"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13.Text = "سطح القارات";
                    textBlock13.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock9b.Text.Equals("صيف حار و جاف و شتاء دافئ و ممطر"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9b.Text = "صيف حار و جاف و شتاء دافئ و ممطر";
                    textBlock9b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11b.Text.Equals("صيف حار و جاف و شتاء بارد و ممطر"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11b.Text = "صيف حار و جاف و شتاء بارد و ممطر";
                    textBlock11b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13b.Text.Equals("صيف شديد الحرارة و شتاء شديد البرودة"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13b.Text = "صيف شديد الحرارة و شتاء شديد البرودة";
                    textBlock13b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }

                if (textBlock9c.Text.Equals("الأطلس التلي"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock9c.Text = "الأطلس التلي";
                    textBlock9c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11c.Text.Equals("السلسلة النوميدية"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock11c.Text = "السلسلة النوميدية";
                    textBlock11c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13c.Text.Equals("الأطلس الصحراوي"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock13c.Text = "الأطلس الصحراوي";
                    textBlock13c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock15c.Text.Equals("الأوراس"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock15c.Text = "الأوراس";
                    textBlock15c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }




                textBlock9.AllowDrop = false;
                textBlock11.AllowDrop = false;
                textBlock13.AllowDrop = false;
                textBlock9b.AllowDrop = false;
                textBlock11b.AllowDrop = false;
                textBlock13b.AllowDrop = false;

                textBlock9c.AllowDrop = false;
                textBlock11c.AllowDrop = false;
                textBlock13c.AllowDrop = false;
                textBlock15c.AllowDrop = false;

                EleveUserControl.Environnement.note = note;
                if (EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam2 < note) EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam2 = note;
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exam2DejaFait = true;
                Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
                button2.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Hidden;
            }

        }
        private void buttonresult_Click(object sender, RoutedEventArgs e)
        {

            EleveUserControl.cc.containerCenter.Content = new Projet.View.UsrCtrl.Exam.NoteExam();
        }
    }
}
