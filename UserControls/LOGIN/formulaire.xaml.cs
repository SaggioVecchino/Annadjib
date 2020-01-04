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
using Projet.Model;
using Projet.UserControls.LOGIN;
using Projet.UserControls.ELEVE;
namespace Projet.UserControls.LOGIN
{
    /// <summary>
    /// Logique d'interaction pour formulaire.xaml
    /// </summary>
    public partial class formulaire : UserControl
    {
        static DateTime? dateDeNaissance = new DateTime(2007, 1, 1);
        public formulaire()
        {
            InitializeComponent();
            dateNaissance.SelectedDate = dateDeNaissance;
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            Commun.contentControl_.Content = new LogSignUser();
        }

        private void textBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            nomError.Text = "";
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            tb.GotFocus -= textBox3_GotFocus;
        }

        private void textBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = tb.Text == string.Empty ? "الإسم" : tb.Text;
        }

        private void textBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            prenomError.Text = "";
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= textBox4_GotFocus;
        }

        private void textBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = tb.Text == string.Empty ? "اللقب" : tb.Text;
        }

        private void textBox5_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox5.Password == "") textBoxps1.Visibility = Visibility.Visible;


        }

        private void textBox6_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox6.Password == "") textBoxps2.Visibility = Visibility.Visible;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            dateDeNaissance = picker.SelectedDate;
            if (dateDeNaissance == null)
            {
                dateError.Text = "الرجاء ادخال تاريخ الميلاد";
            }
            else
            {
                dateError.Text = "";
            }

        }

        private void textBoxps1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxps1.Visibility = Visibility.Collapsed;
            textBox5.Focus();
        }

        private void textBoxps2_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxps2.Visibility = Visibility.Collapsed;
            textBox6.Focus();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (prenomPlaceHolder.Text == "" || prenomPlaceHolder.Text == "الإسم" || nomPlaceHolder.Text == "" || nomPlaceHolder.Text == "اللقب" || textBox5.Password == "" || textBox5.Password == "ادخل كلمة المرور" || textBox6.Password == "" || textBox6.Password == " تأكيد  كلمة المرور")
            {
                if (prenomPlaceHolder.Text == "" || prenomPlaceHolder.Text == "الإسم")
                {
                    prenomError.Text = " الرجاء إدخال الإسم";
                }
                else
                {
                    prenomError.Text = "";
                }

                if (nomPlaceHolder.Text == "" || nomPlaceHolder.Text == "اللقب")
                {
                    nomError.Text = " الرجاء إدخال اللقب";
                }
                else
                {
                    nomError.Text = "";
                }

                if (textBox5.Password == "" || textBox5.Password == "ادخل كلمة المرور")
                {
                    password1Error.Text = "الرجاء إدخال كلمة المرور";
                }
                else
                {
                    password1Error.Text = "";
                }

                if (textBox6.Password == "" || textBox6.Password == " تأكيد  كلمة المرور")
                {
                    password2Error.Text = "الرجاء تأكيد كلمة المرور";
                }
                else
                {
                    password2Error.Text = "";
                }
            }
            else
            {
                if (!textBox5.Password.ToString().Equals(textBox6.Password.ToString()))
                {
                    password2Error.Text = "الرجاء إدخال نفس كلمة المرور";
                }
                else
                {
                    if (Utilities.listeDesEleves.Find(r=>((r.Nom == nomPlaceHolder.Text )&&(r.Prenom == prenomPlaceHolder.Text)) ) != null) 
                    {
                        prenomError.Text = "أنت مسجل مسبقا";
                    }
                    else
                    {
                        Eleve ev = new Eleve(nomPlaceHolder.Text, prenomPlaceHolder.Text,(DateTime)dateDeNaissance, Model.Utilities.avatarParDefaut,textBox5.Password);
                        
                        EleveUserControl.Environnement.eleveConnecte = ev;
                        EleveWindow s = new EleveWindow();
                        Commun.window_user = s;
                        s.Show();
                        Commun.AdminConnecte = false;
                        Commun.window_.Close();
                    }
                    
                }
            }

        }
    }
}
