using System;
using System.Collections;
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
    internal class EleveAdmin
    {
        internal static Model.Eleve elevAdmin;
        internal static Model.Admin admin = Model.Utilities.ChargerAdmin();
        internal static ListBox ListboxAdmin;
        internal static int selectedEleve;
    }
    /// <summary>
    /// Logique d'interaction pour Contenu.xaml
    /// </summary>
    public partial class Contenu : UserControl
    {
        public Contenu()
        {
            InitializeComponent();
            EleveAdmin.ListboxAdmin = listBox;
            Model.Utilities.ChargerEleves();
            listBox.ItemsSource = Model.Utilities.listeDesEleves;
            if(Commun.AdminTitle!=null)Commun.AdminTitle.Content = new Admin.TitleAccueil();
            AdminWindow.mettreAJourButtonToLogOut();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Commun.selectedNammeComplet = ((Model.Eleve)EleveAdmin.ListboxAdmin.SelectedItem).NomComplet;
            EleveAdmin.selectedEleve = Model.Utilities.listeDesEleves.FindIndex(r => r.NomComplet == ((Model.Eleve)EleveAdmin.ListboxAdmin.SelectedItem).NomComplet);
            Commun.ConfirmationAdmin.Content = new View.UsrCtrl.Admin.ConfirmationSupprimEleve();
            Commun.AdminContenu.Opacity = 0.4;

        }


        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            IEnumerator ee = ((Grid)sender).Children.GetEnumerator();
            IEnumerator e2 = ((Grid)sender).Children.GetEnumerator();
            ee.MoveNext();
            ee.MoveNext();
            e2.MoveNext();
            e2.MoveNext();
            e2.MoveNext();

            //        string nomComplet= (TextBlock)ee.Current).Text+" "+ (TextBlock)e2.Current).Text;
            int i = Model.Utilities.listeDesEleves.FindIndex(r => ((r.Nom == ((TextBlock)ee.Current).Text) && (r.Prenom == ((TextBlock)e2.Current).Text)));
            //    listBox.SelectedItems.Add(listBox.Items.GetItemAt(i));
            listBox.SelectedItem = listBox.Items.GetItemAt(i);
        }


        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            IEnumerator ee = ((Grid)sender).Children.GetEnumerator();
            ee.MoveNext();
            IEnumerator e2 = ((Grid)sender).Children.GetEnumerator();
            e2.MoveNext();
            e2.MoveNext();
            //  listBox.SelectedItems.Remove(Model.Utilities.listeDesEleves.Find(r => ((r.Nom == ((TextBlock)ee.Current).Text) && (r.Prenom == ((TextBlock)e2.Current).Text))));
            listBox.SelectedItem = null;


        }

        /*private void viewProfile_Click(object sender, RoutedEventArgs e)
        {
            Model.Utilities.ChargerEleves();
            int j = Model.Utilities.listeDesEleves.FindIndex(r => r.Prenom == ((Model.Eleve)listBox.SelectedItem).Prenom);
            EleveAdmin.elevAdmin = Model.Utilities.listeDesEleves[j];
            Commun.AdminContenu.Content = new EleveInfo();
            Commun.AdminContenu.Visibility = Visibility.Visible;
            Commun.AdminTitle.Content = new EleveInfoTitle();
        }*/

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Model.Utilities.ChargerEleves();
            int j = Model.Utilities.listeDesEleves.FindIndex(r => r.Prenom == ((Model.Eleve)listBox.SelectedItem).Prenom);
            EleveAdmin.elevAdmin = Model.Utilities.listeDesEleves[j];
            if (EleveAdmin.elevAdmin != null)
            {
                //Commun.ConfirmationAdmin.Content = new View.UsrCtrl.eleveCtrls.ChangerPwd();
                Commun.AdminContenu.Content = new View.UsrCtrl.eleveCtrls.modifierInfo();
                Commun.AdminContenu.Visibility = Visibility.Visible;
                Commun.AdminTitle.Content = new EleveInfoTitle();
            }
            /*else
            {

            }*/
        }

        private void statistics_Click(object sender, RoutedEventArgs e)
        {
            Model.Utilities.ChargerEleves();
            int j = Model.Utilities.listeDesEleves.FindIndex(r => r.Prenom == ((Model.Eleve)listBox.SelectedItem).Prenom);
            EleveAdmin.elevAdmin = Model.Utilities.listeDesEleves[j];
            if (EleveAdmin.elevAdmin != null)
            {
                Model.Utilities.ChargerAvatars();
                Commun.AdminContenu.Content = new View.UsrCtrl.Stats.stats(EleveAdmin.elevAdmin);
                Commun.AdminContenu.Visibility = Visibility.Visible;
                Commun.AdminTitle.Content = new EleveInfoTitle();
            }
        }
    }
}






