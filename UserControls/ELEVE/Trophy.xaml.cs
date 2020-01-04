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
    /// Logique d'interaction pour Trophy.xaml
    /// </summary>
    public partial class Trophy : UserControl
    {
        public Trophy(int trophyId)
        {
            InitializeComponent();
            trophyImage.DataContext = "/IMAGES/TROPHIES/" +(trophyId+1)+ ".png";
            trophyName.DataContext = trophyTitle(trophyId);
            EleveUserControl.Environnement.eleveConnecte.Statistiques.trophies[trophyId] = true;
            Model.Utilities.MettreAJourListeDesEleves(EleveUserControl.Environnement.eleveConnecte);
        }
        private static string trophyTitle(int id)
        {
            switch (id)
            {
                case 0: return "أول دخول";
                case 1: return "أول درس";
                case 2: return "أول تمرين";
                case 3: return "علامة كاملة";
                case 4: return "المجال الثاني";
                case 5: return "تمرين كامل";
                case 6: return "اول الخرائط";
                case 7: return "ممتاز في كل الإختبارات";
                case 8: return "كل الخرائط";
                case 9: return "النجيب في الجغرافبا";
                case -1: return "جائزة مقفلة";
            }
            return "";
        }
    }
}
