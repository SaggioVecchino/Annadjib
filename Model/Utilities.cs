using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    [Serializable]
    static public partial class Utilities
    {
        public const string avatarParDefaut = "/Projet;component/IMAGES/AVATARS/0.png";
        public const string CheminListeDesEleves = "ListeDesEleves";
        public const string CheminAdmin = "Admin";
        public static List<Eleve> listeDesEleves { set; get; }
        public static List<string> listeAvatar { get; set; }

        public const int nbCours = 3;
        public const int nbExo = 14;
        public const int nbExam = 2;

        public const int nbQstDragAndDrop = 6;
        public const int nbQstTrueOrFalse = 8;
        public const int nbQstQcm = 9;
        public const string CheminAvatar = "Avatar.txt";
        public const string cheminInfoCours = "cours/infocours.txt";

        public const string cheminDragAndDrop1 = "DragAndDrop1.txt";
        public const string cheminTrueOrFalse1 = "TrueOrFalse1.txt";
        public const string cheminQcm1 = "QCM1.txt";
        public const string cheminDragAndDrop2 = "DragAndDrop2.txt";
        public const string cheminTrueOrFalse2 = "TrueOrFalse2.txt";
        public const string cheminQcm2 = "QCM2.txt";
        public const string cheminDragAndDrop3 = "DragAndDrop3.txt";
        public const string cheminTrueOrFalse3 = "TrueOrFalse3.txt";
        public const string cheminQcm3 = "QCM3.txt";

        public enum TypeQuestion
        {
            QCM,
            TrueOrFalse,
            DragAndDrop,
            Cartes
        }

        public enum TypePageCours
        {
            ImageSeule,
            TextSeul,
            TextImage,
            Vide
        }

        public enum EtatAncienneSession
        {
            Menu,
            Cours1,
            Cours2,
            Cours3,
            QCM1,
            QCM2,
            QCM3,
            TrueOrFalse1,
            TrueOrFalse2,
            TrueOrFalse3,
            DragAndDrop1,
            DragAndDrop2,
            DragAndDrop3,
            MapTadaris,
            MapPluie,
            MapMounakh,
            MapAnimaux,
            MapTemperatures,
            Exam1,
            Exam2
        }


        [Serializable]
        public struct StructCours
        {
            public int id;
            public int pageCourante;
        }

        [Serializable]
        public struct StructExo
        {
            public TypeQuestion type;
            public int cours;//on commence par convention par 1
            public float note;
            public bool dejaFait;
        }

        
       /* public struct StructExam
        {
            public int id;
            public int note;
            public bool dejaFait;
        }*/

        //---------------------------------------------------------

        private static T Charger<T>(string path, long offset)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(path, FileMode.Open, FileAccess.Read);
                flux.Seek(offset, SeekOrigin.Begin);
                return (T)formatter.Deserialize(flux);
            }
            catch
            {
                return default(T);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }

        //---------------------------------------------------------

        private static void Enregistrer(object toSave, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(path, FileMode.Create, FileAccess.Write);
                formatter.Serialize(flux, toSave);
                flux.Flush();
            }
            catch { }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }

        //--------------------------------------------------------- 

        public static void EnregistrerAdmin(Admin admin)
        {
            Utilities.Enregistrer(admin, Utilities.CheminAdmin);
        }

        //---------------------------------------------------------

        public static void EnregistrerListeDesEleves()
        {
            Utilities.Enregistrer(Utilities.listeDesEleves, Utilities.CheminListeDesEleves);
        }

        //---------------------------------------------------------

        public static void MettreAJourListeDesEleves(Eleve eleve)
        {
            listeDesEleves[listeDesEleves.FindIndex(r => r.IdEleve == eleve.IdEleve)] = eleve;
            Enregistrer(Utilities.listeDesEleves, Utilities.CheminListeDesEleves);
        }

        //---------------------------------------------------------

        public static Admin ChargerAdmin()//On charge les informations concernant l'admin à partir du fichier
        {
            return Charger<Admin>(Utilities.CheminAdmin, 0);
        }

        //---------------------------------------------------------

        public static void ChargerEleves()//On charge la liste des eleves à partir du fichier
        {
            Utilities.listeDesEleves = new List<Eleve>();
            Utilities.listeDesEleves = Charger<List<Eleve>>(Utilities.CheminListeDesEleves, 0);
        }

        //---------------------------------------------------------

        public static void InitialiserlisteDesEleves()//Utilisée pour générer CheminListeDesEleves
        {
            Enregistrer(new List<Eleve>(), Utilities.CheminListeDesEleves); //liste initialement vide
        }

        //---------------------------------------------------------

        public static void InitialiserAdmin()//Utilisée pour générer CheminAdmin
        {
            Enregistrer(new Admin() { NomEcole = "مؤسستي", PasswordHashed = "admin".GetHashCode(),passwordChanged=false}, Utilities.CheminAdmin);
        }

        //---------------------------------------------------------

        public static int min(int a, int b)
        {
            if (a <= b) return a;
            else return b;
        }

        //---------------------------------------------------------

        public static int max(int a, int b)
        {
            if (a >= b) return a;
            else return b;
        }

        //---------------------------------------------------------

        public static float max(float a, float b)
        {
            if (a >= b) return a;
            else return b;
        }

        //---------------------------------------------------------
        //---------------------------------------------------------
        public static void ChargerAvatars()
        {
            StreamReader sr = new StreamReader(CheminAvatar);
            string line;
            listeAvatar = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                listeAvatar.Add(line);
            }
        }
        //---------------------------------------------------------

    }
}
