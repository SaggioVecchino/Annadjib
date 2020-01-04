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
namespace Projet.View.UsrCtrl.Cours
{
    /// <summary>
    /// Logique d'interaction pour CoursTexte.xaml
    /// </summary>
    public partial class CoursTexte : UserControl
    {
        public CoursTexte()
        {
            InitializeComponent();
            DataContext = EleveUserControl.Environnement.cours;
        }

        private void buttonPrec_Click(object sender, RoutedEventArgs e)
        {
            if (EleveUserControl.Environnement.eleveConnecte.PagePrcedanteCours(EleveUserControl.Environnement.cours) == -1)
                return;
            if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                Commun.CoursContenu.Content = new Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                Commun.CoursContenu.Content = new CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                Commun.CoursContenu.Content = new CoursImage();
        }

        private void buttonSuiv_Click(object sender, RoutedEventArgs e)
        {
            if (EleveUserControl.Environnement.eleveConnecte.PageSuivanteCours(EleveUserControl.Environnement.cours) == -1)
            {
                EleveUserControl.cc.containerCenter.Content = new FinCours();
                return;
            }
            if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextImage)
                Commun.CoursContenu.Content = new Cours();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.TextSeul)
                Commun.CoursContenu.Content = new CoursTexte();
            else if (EleveUserControl.Environnement.cours.Get_Type_page() == Model.Utilities.TypePageCours.ImageSeule)
                Commun.CoursContenu.Content = new CoursImage();
        }
    }
}
