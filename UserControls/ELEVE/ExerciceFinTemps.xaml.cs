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
    /// Logique d'interaction pour ExerciceFinTemps.xaml
    /// </summary>
    public partial class ExerciceFinTemps : UserControl
    {
        public ExerciceFinTemps()
        {
            InitializeComponent();
        }

        private void okey_Click(object sender, RoutedEventArgs e)
        {
            Commun.finTemps.Visibility = Visibility.Collapsed;
        }
    }
}
