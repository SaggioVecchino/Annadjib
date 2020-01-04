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
    /// Logique d'interaction pour parametresAdmin.xaml
    /// </summary>
    public partial class parametresAdmin : UserControl
    {
        public parametresAdmin()
        {
            InitializeComponent();
            textBox.DataContext = EleveAdmin.admin;

            AdminWindow.mettreAJourButtonToReturn();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                message.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Red);
                message.Text = "ادخل اسم المؤسسة";
            }  
            else
            {
                EleveAdmin.admin.ChangerNomEcole(textBox.Text);
                message.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Green);
                message.Text = "تم الحفظ بنجاح";
            }
                
        }

        private void deleteAll_Click(object sender, RoutedEventArgs e)
        {

            Commun.ConfirmationAdmin.Content = new View.UsrCtrl.Admin.ConfirmationSupprimAll();
            Commun.ConfirmationAdmin.Visibility = Visibility.Visible;
            Commun.AdminContenu.Visibility = Visibility.Visible;
            Commun.AdminContenu.Opacity = 0.4;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = EleveAdmin.admin.NomEcole;
            message.Text = "";
        }

        private void editAdminPass_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Content = new View.UsrCtrl.Admin.ChangingPassAdmin();
            Commun.AdminContenu.Visibility = Visibility.Visible;

        }
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {

              Commun.AdminContenu.Content = new View.UsrCtrl.Admin.Contenu();
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            message.Text = "";
        }
    }
}
