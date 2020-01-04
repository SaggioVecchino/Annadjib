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

namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    internal class Commun
    {
        public static ContentControl contentControl_;
        public static Window window_;
        public static ContentControl AdminLaterale;
        public static ContentControl AdminTitle;
        public static ContentControl AdminContenu;
        public static View.UsrCtrl.Admin.help AdminHelp;
        public static ContentControl CoursContenu;
        public static ContentControl ExerciceTemps;
        public static ContentControl ExerciceQuestion;
        public static ContentControl ExerciceReponse;
        public static ContentControl Exercice;
        public static Window window_2;
        public static Window window_user;
        public static ContentControl Note;
        public static ContentControl modifierPwdEleve;//
        public static bool AdminConnecte;//
        public static ContentControl confirmSauvParam;//
        public static ContentControl ConfirmationAdmin;//
        public static ContentControl ContenuEleve;//
        public static ContentControl EtatAncienneSession;//
        public static ContentControl confirmSauvParamAdmin;//
        public static int nombreDeReponsesJustesCouleur;
        public static float noteCouleur;
        public static int nombreDeReponsesCouleur;
        public static int IDCouleur;
        public static string selectedNammeComplet="";
        public static ContentControl finTemps;
        //public static int coursId=-1;
    }

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Commun.contentControl_ = contentLogReg;
            Commun.contentControl_.Content = new LoginChooseType();
            Commun.window_=this;     
        }

        private void move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void reduce_button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
