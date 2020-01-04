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

namespace Projet.UserControls.ELEVE
{
    /// <summary>
    /// Logique d'interaction pour HelpLateral.xaml
    /// </summary>
    public partial class HelpLateral : UserControl
    {
        public HelpLateral()
        {
            InitializeComponent();
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            Commun.ContenuEleve = null;
            LoginWindow w = new LoginWindow();
            Commun.window_user.Close();
            w.Show();
        }

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            if (helpBox.Visibility == Visibility.Collapsed) helpBox.Visibility = Visibility.Visible;
            else helpBox.Visibility = Visibility.Collapsed;
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();
            EleveUserControl.cc.containerCenter.Content =new Chap2MenuMaps();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            helpBox.Visibility = Visibility.Collapsed;
        }
    }
}
