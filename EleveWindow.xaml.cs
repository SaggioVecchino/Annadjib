using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using Projet.UserControls.ELEVE;
namespace Projet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow2.xaml
    /// </summary>
    public partial class EleveWindow : MetroWindow
    {
        public EleveWindow()
        {
            InitializeComponent();
            mainContent.Content = new EleveUserControl();
        }

        public static void mettreAJourButtonToReturn()
        {
            {
                EleveUserControl.lateralHelpContainer.buttonLogOut.Visibility = Visibility.Collapsed;
                EleveUserControl.lateralHelpContainer.buttonRetour.Visibility = Visibility.Visible;
            }
        }
        public static void mettreAJourButtonToLogOut()
        {
            {
                EleveUserControl.lateralHelpContainer.buttonRetour.Visibility = Visibility.Collapsed;
                EleveUserControl.lateralHelpContainer.buttonLogOut.Visibility = Visibility.Visible;
            }
        }
    }
}
