using Projet.UserControls.ELEVE;
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

namespace Projet.View.UsrCtrl.ExercicesDragCouleur
{
    /// <summary>
    /// Logique d'interaction pour NoteCouleur.xaml
    /// </summary>
    public partial class NoteCouleur : UserControl
    {
        public NoteCouleur()
        {
            InitializeComponent();
            textBlock3.Text = Commun.nombreDeReponsesCouleur.ToString();
            textBlock5.Text = Commun.noteCouleur.ToString();
            textBlock1.Text = Commun.nombreDeReponsesJustesCouleur.ToString();
            smileyImage.DataContext = afficherSmiley(Commun.noteCouleur / (float)5.0);
            //trophy
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[2])
            {
                UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(2);
            }
            ///

            //trophy 5
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[5])
            {
                if (Commun.noteCouleur == 5)
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(5);
            }

            //trophy 6
            int nbExoJuste = 0;
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[6])
            {
                //if () 3 exos de maps tous juste
                
                for ( int i=9; i < 14; i++)
                {
                    if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[i].note == 5.0) nbExoJuste++;
                }
                if ( nbExoJuste==3)
                    UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(6);
            }
            nbExoJuste = 0;
            //
            //trophy 8
            if (!UserControls.ELEVE.EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[8])
            {
                //if () tous les exos de maps 5/5
                for (int i = 9; i < 14; i++)
                {
                    if (EleveUserControl.Environnement.eleveConnecte.Statistiques.Exo[i].note == 5.0) nbExoJuste++;
                }
                if ( nbExoJuste==5)
                UserControls.ELEVE.TopBar.trophy.container.Content = new UserControls.ELEVE.Trophy(8);
            }
           //

            textBlock8.Text = afficherMessage(Commun.noteCouleur / (float)5.0);

            if (Commun.noteCouleur / (float)5.0 < 0.5)
            {
                textBlock5.Foreground = new SolidColorBrush(Colors.Red);
                textBlock8.Foreground = new SolidColorBrush(Colors.Red);
                button1.Visibility = Visibility.Visible;
            }
            else
            {
                textBlock5.Foreground = new SolidColorBrush(Colors.Green);
                textBlock8.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (Commun.noteCouleur / (float)5.0 != 1)
                button.Visibility = Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Commun.IDCouleur == 1)
                EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Tadaris();
            if (Commun.IDCouleur == 3)
                EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Pluie();
            if (Commun.IDCouleur == 2 && Commun.nombreDeReponsesCouleur == 5)
                EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Animaux();
            if (Commun.IDCouleur == 2 && Commun.nombreDeReponsesCouleur == 3)
                EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Mounakh();
            if (Commun.IDCouleur == 2 && Commun.nombreDeReponsesCouleur == 10)
                EleveUserControl.cc.containerCenter.Content = new View.UsrCtrl.ExercicesDragCouleur.Temperatures();

        }

        private string afficherMessage(float moyenne) // entre 0 et 1
        {
            if (moyenne < 0.5) return "ننصحك بمراجعة درسك";
            if (moyenne == 0.5) return "يمكنك أن تقدّم أفضل";
            if (moyenne < 1 && moyenne > 0.5) return "أحسنت";
            return "ممتاز";
        }

        private string afficherSmiley(float moyenne) // entre 0 et 1
        {
            if (moyenne <= 0.3) return "/IMAGES/SMILEY/S4.png";
            if (moyenne <= 0.5) return "/IMAGES/SMILEY/S3.png";
            if (moyenne <= 0.8) return "/IMAGES/SMILEY/S2.png";
            return "/IMAGES/SMILEY/S1.png";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Model.Utilities.StructCours c = new Model.Utilities.StructCours();
            c.id = Commun.IDCouleur;
            c.pageCourante = 1;//On revient à la première page
            EleveUserControl.Environnement.eleveConnecte.Statistiques.Cours[c.id - 1] = c;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
            EleveUserControl.Environnement.cours = EleveUserControl.Environnement.eleveConnecte.OuvrirCours(c.id);
            if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                Commun.CoursContenu.Content = new Cours.Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                Commun.CoursContenu.Content = new Cours.CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                Commun.CoursContenu.Content = new Cours.CoursImage();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            EleveUserControl.cc.containerCenter.Content = new UserControls.ELEVE.Exercices();
        }
    }
}
