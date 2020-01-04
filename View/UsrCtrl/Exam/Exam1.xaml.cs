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
    public partial class Exam1 : UserControl
    {
        internal DispatcherTimer timer;
        internal TimeSpan _time;
        internal double note = 0;

        public Exam1()
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
            textBlock4b.DataContext = textBlock4b.Text;
            textBlock5b.DataContext = textBlock5b.Text;
            textBlock6b.DataContext = textBlock6b.Text;
            textBlock7b.DataContext = textBlock7b.Text;
            //
            textBlock4c.DataContext = textBlock4c.Text;
            textBlock5c.DataContext = textBlock5c.Text;
            textBlock6c.DataContext = textBlock6c.Text;


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
                if (checkBox2c.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox2c.IsChecked = true;
                    checkBoxc.Visibility = Visibility.Collapsed;
                    checkBox1c.Visibility = Visibility.Collapsed;
                }

                ///

                if (checkBoxd.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxd.IsChecked = true;
                    checkBox1d.Visibility = Visibility.Collapsed;
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
                if (checkBox1f.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox1f.IsChecked = true;
                    checkBoxf.Visibility = Visibility.Collapsed;
                }



                ///
                if (textBlock9.Text.Equals("جبال الونشريس") || textBlock9.Text.Equals("جبال تسالا"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9.Text = "جبال الونشريس";
                    textBlock9.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11.Text.Equals("جبال تسالا") || textBlock11.Text.Equals("جبال الونشريس"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11.Text = "جبال تسالا";
                    textBlock11.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13.Text.Equals("جبال القصور"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13.Text = "جبال القصور";
                    textBlock13.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock9b.Text.Equals("اعتدال"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock9b.Text = "اعتدال";
                    textBlock9b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11b.Text.Equals("غزارة الأمطار"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock11b.Text = "غزارة الأمطار";
                    textBlock11b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13b.Text.Equals("ارتفاع"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock13b.Text = "ارتفاع";
                    textBlock13b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock15b.Text.Equals("قلة الأمطار"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock15b.Text = "قلة الأمطار";
                    textBlock15b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock9c.Text.Equals("مصادر للمياه"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9c.Text = "مصادر للمياه";
                    textBlock9c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11c.Text.Equals("المجاري المائية"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11c.Text = "المجاري المائية";
                    textBlock11c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13c.Text.Equals("المياه الجوفية"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13c.Text = "المياه الجوفية";
                    textBlock13c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }


                textBlock9.AllowDrop = false;
                textBlock11.AllowDrop = false;
                textBlock13.AllowDrop = false;
                textBlock9b.AllowDrop = false;
                textBlock11b.AllowDrop = false;
                textBlock13b.AllowDrop = false;
                textBlock15b.AllowDrop = false;
                textBlock9c.AllowDrop = false;
                textBlock11c.AllowDrop = false;
                textBlock13c.AllowDrop = false;
                EleveUserControl.Environnement.note = note;
                if (EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam1 < note) EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam1 = note;
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exam1DejaFait = true;
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
                      (textBlock9.Text == "-------" || textBlock11.Text == "-------" || textBlock13.Text == "-------") ||
                      (textBlock9b.Text == "-------" || textBlock11b.Text == "-------" || textBlock13b.Text == "-------" || textBlock15b.Text == "-------") ||
                      (textBlock9c.Text == "-------" || textBlock11c.Text == "-------" || textBlock13c.Text == "-------")
                      )
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
                if (checkBox2c.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox2c.IsChecked = true;
                    checkBoxc.Visibility = Visibility.Collapsed;
                    checkBox1c.Visibility = Visibility.Collapsed;
                }
                ///
                if (checkBoxd.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBoxd.IsChecked = true;
                    checkBox1d.Visibility = Visibility.Collapsed;
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
                if (checkBox1f.IsChecked == true)
                {
                    note++; nbCorrect++;
                }
                else
                {
                    checkBox1f.IsChecked = true;
                    checkBoxf.Visibility = Visibility.Collapsed;
                }
                ///
                if (textBlock9.Text.Equals("جبال الونشريس") || textBlock9.Text.Equals("جبال تسالا"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9.Text = "جبال الونشريس";
                    textBlock9.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11.Text.Equals("جبال تسالا") || textBlock11.Text.Equals("جبال الونشريس"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11.Text = "جبال تسالا";
                    textBlock11.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13.Text.Equals("جبال القصور"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13.Text = "جبال القصور";
                    textBlock13.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock9b.Text.Equals("اعتدال"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock9b.Text = "اعتدال";
                    textBlock9b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11b.Text.Equals("غزارة الأمطار"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock11b.Text = "غزارة الأمطار";
                    textBlock11b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13b.Text.Equals("ارتفاع"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock13b.Text = "ارتفاع";
                    textBlock13b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock15b.Text.Equals("قلة الأمطار"))
                {
                    note += 0.25; nbCorrect++;
                }
                else
                {
                    textBlock15b.Text = "قلة الأمطار";
                    textBlock15b.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock9c.Text.Equals("مصادر للمياه"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock9c.Text = "مصادر للمياه";
                    textBlock9c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock11c.Text.Equals("المجاري المائية"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock11c.Text = "المجاري المائية";
                    textBlock11c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }
                if (textBlock13c.Text.Equals("المياه الجوفية"))
                {
                    note += 0.5; nbCorrect++;
                }
                else
                {
                    textBlock13c.Text = "المياه الجوفية";
                    textBlock13c.Background = (Brush)bc.ConvertFrom("#FFD62E2E");
                }

                textBlock9.AllowDrop = false;
                textBlock11.AllowDrop = false;
                textBlock13.AllowDrop = false;
                textBlock9b.AllowDrop = false;
                textBlock11b.AllowDrop = false;
                textBlock13b.AllowDrop = false;
                textBlock15b.AllowDrop = false;
                textBlock9c.AllowDrop = false;
                textBlock11c.AllowDrop = false;
                textBlock13c.AllowDrop = false;
                EleveUserControl.Environnement.note = note;
                EleveUserControl.Environnement.note = note;
                if (EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam1 < note) EleveUserControl.Environnement.eleveConnecte.Statistiques.noteExam1 = note;
                EleveUserControl.Environnement.eleveConnecte.Statistiques.Exam1DejaFait = true;
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
