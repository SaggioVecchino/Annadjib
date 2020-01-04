using Projet.UserControls;
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
using Projet.UserControls.ELEVE;


namespace Projet.UserControls.ELEVE
{
    /// <summary>
    /// Logique d'interaction pour EleveUserControl.xaml
    /// </summary>
    public partial class EleveUserControl : UserControl
    {
        internal class Environnement
        {
            public static Model.Eleve eleveConnecte { get; set; }
            public static Model.Cours cours { get; set; }
            public static Model.Exercice exercice { get; set; }
            public static Model.Question question { get; set; }
            public static double note;
        }
        public static ContentCenter cc = new ContentCenter();
        public static HelpLateral lateralHelpContainer=null;
        public EleveUserControl()
        {
            InitializeComponent();
            //
            Commun.Exercice = cc.containerCenter;
            Commun.CoursContenu = cc.containerCenter;
            Commun.Note = cc.containerCenter;
            Commun.ContenuEleve = cc.containerCenter;
            Commun.EtatAncienneSession = EtatAncienneSession;
            Commun.finTemps = finTemps;
            //
            barTopContent.Content = new TopBar();
            lateralMenuContent.Content = new LateralMenuEleve();
            lateralHelpContent.Content = new HelpLateral();
            finTemps.Content = new ExerciceFinTemps();
            finTemps.Visibility = Visibility.Collapsed;
            //
            lateralHelpContainer =(HelpLateral) lateralHelpContent.Content;
            cc.containerCenter.Content = new Chap2MenuMaps();//permuted
            centerContent.Content = cc;
            if (Environnement.eleveConnecte.Statistiques.etat != Model.Utilities.EtatAncienneSession.Menu)
                Commun.EtatAncienneSession.Content = new EtatAncienneSession();
            //
            Commun.modifierPwdEleve = PwdContenu;
            Commun.confirmSauvParam = confirmSauvPar;
            //
            //Trophy 0
            if (!EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[0]) TopBar.trophy.container.Content = new Trophy(0);
        }

    }
}
