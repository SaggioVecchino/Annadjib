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
    /// Logique d'interaction pour TitleAccueil.xaml
    /// </summary>
    public partial class TitleAccueil : UserControl
    {
        public TitleAccueil()
        {
            InitializeComponent();
            nomEcole.DataContext = EleveAdmin.admin;
            logoContent.Content = new UserControls.GENERAL.LogoUC();
        }
    }
}
