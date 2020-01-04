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

namespace Projet.View.UsrCtrl.Admin
{
    /// <summary>
    /// Logique d'interaction pour ChangingPassAdmin.xaml
    /// </summary>
    public partial class ChangingPassAdmin : UserControl
    {
        public ChangingPassAdmin()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            message.Text = "";
            message.Foreground = Brushes.Red;
            
            if (textBox5.Password == "" || textBox6.Password == "")
                message.Text = "ادخل كلمة المرور";
            else
            {
                if (Model.Admin.AuthentificationAdmin(textBox5.Password) == null)
                {
                    message.Text = "كلمة المرور خاطئة";
                }
                else
                {
                    EleveAdmin.admin.passwordChanged = true;
                    EleveAdmin.admin.ChangerMotDePasseAdmin(textBox6.Password);
                    message.Foreground = Brushes.Green;
                    message.Text = "تم الحفظ بنجاح";
                    
                    //Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            message.Text = "";
            message.Foreground = Brushes.Red;
            textBox6.Password = "";
            textBox5.Password = "";
            Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
        }

        private void textBox5_GotFocus(object sender, RoutedEventArgs e)
        {
            message.Text = "";
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {

            Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
        }
    }
}
