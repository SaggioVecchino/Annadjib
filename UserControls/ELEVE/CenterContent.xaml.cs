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
    /// Logique d'interaction pour CenterContent.xaml
    /// </summary>
    public partial class CenterContent : UserControl
    {
        public CenterContent()
        {
            InitializeComponent();
            EleveUserControl.cc.containerCenter.Visibility = Visibility.Visible;
        }
    }
}
