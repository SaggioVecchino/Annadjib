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
    /// Logique d'interaction pour BarMenu.xaml
    /// </summary>
    public partial class BarMenu : UserControl
    {
        public BarMenu()
        {
            InitializeComponent();
        }

        private void buttonChap2_Click(object sender, RoutedEventArgs e)
        {
            View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();//////////////////////
            EleveUserControl.cc.containerCenter.Content = new Chap2MenuMaps();
            EleveUserControl.Environnement.eleveConnecte.Statistiques.etat = Model.Utilities.EtatAncienneSession.Menu;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Ps: Dans chaque clique il faut mettre cette instruction View.UsrCtrl.Exercices.ExerciceTemps.StopTemps();//
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////


    }
}
