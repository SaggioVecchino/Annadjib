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
    /// Logique d'interaction pour ConfirmationSupprimEleve.xaml
    /// </summary>
    public partial class ConfirmationSupprimEleve : UserControl
    {
        public ConfirmationSupprimEleve()
        {
            InitializeComponent();
            message.DataContext= "هل تريد حقا حذف التلميذ " + Commun.selectedNammeComplet+ " ؟";
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Model.Utilities.ChargerEleves();

            //  Model.Utilities.listeDesEleves.Remove((Model.Eleve)listBox.SelectedItem);
            Model.Utilities.listeDesEleves.RemoveAt(EleveAdmin.selectedEleve);
            Model.Utilities.EnregistrerListeDesEleves();
            //   Model.Utilities.ChargerEleves();

            EleveAdmin.ListboxAdmin.ItemsSource = Model.Utilities.listeDesEleves;
            /*  Model.Eleve ed = (Model.Eleve)listBox.SelectedItem;
           if (ed != null)
               textBlock.Text = ed.Prenom;
           else
               textBlock.Text = "null";*/
            Commun.AdminContenu.Opacity = 1;
            Commun.ConfirmationAdmin.Content = null;
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            Commun.AdminContenu.Opacity = 1;
            Commun.ConfirmationAdmin.Content = null;
        }
    }
}
