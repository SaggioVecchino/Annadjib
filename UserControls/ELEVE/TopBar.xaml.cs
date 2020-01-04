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
using Projet.UserControls.GENERAL;

namespace Projet.UserControls.ELEVE
{
    /// <summary>
    /// Logique d'interaction pour TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        public static TrophyContainer trophy = null;
        public TopBar()
        {
            InitializeComponent();
            barContent.Content = new BarMenu();
            logoContent.Content = new LogoUC();
            trophyNotificationContent.Content = new TrophyContainer();
            trophy =(TrophyContainer)trophyNotificationContent.Content;
        }
    }
}
