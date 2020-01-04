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
    /// Logique d'interaction pour EleveInfo.xaml
    /// </summary>
    public partial class EleveInfo : UserControl
    {
        public EleveInfo()
        {
            InitializeComponent();
            this.DataContext = View.UsrCtrl.Admin.EleveAdmin.elevAdmin;

            AdminWindow.mettreAJourButtonToReturn();
        }
    }
}
