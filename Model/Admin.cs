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
    public class Admin
    {

        public int PasswordHashed { get; set; }
        public string NomEcole { get; set; }
        public bool passwordChanged { get; set; }
        //Constructure par défaut par défaut suffit

        public static Admin AuthentificationAdmin(string MotDePasse)//Retourne admin si mot de passe correct, null sinon
        {
            Admin admin = Utilities.ChargerAdmin();
            if (MotDePasse.GetHashCode() != admin.PasswordHashed)
                return null;
            Utilities.ChargerEleves();
            return admin;
        }
        //----------------------------------------------------------
        public void ChangerMotDePasseAdmin(string nouveauMotDePasse)
        {
            this.PasswordHashed = nouveauMotDePasse.GetHashCode();
            Utilities.EnregistrerAdmin(this);
        }
        //---------------------------------------------------------
        public void ChangerNomEcole(string nouveauNom)
        {
            this.NomEcole = nouveauNom;
            Utilities.EnregistrerAdmin(this);
        }
        //---------------------------------------------------------
        public bool ChangerMotDePasseEleve(int id, string noveauMotDePasse)
        {
            bool ok = false;
            int indice = 0;
            //Utilities.ChargerEleves();
            //Pas la peine de de recharger la liste des eleves puisqu'elle y est dans AuthentificationAdmin
            foreach (Eleve eleve in Utilities.listeDesEleves)
            {
                if (eleve.IdEleve == id)
                {
                    ok = true;
                    break;
                }
                indice++;
            }
            if (!ok)
                return false;
            Utilities.listeDesEleves.ElementAt(indice).PasswordHashed = noveauMotDePasse.GetHashCode();
            Utilities.EnregistrerListeDesEleves();
            return true;
        }
        //---------------------------------------------------------
        public bool SupprimerEleve(int id)
        {
            bool OK = false;
            int indice = 0;
            //Utilities.ChargerEleves();
            //Pas la peine de de recharger la liste des eleves puisqu'elle y est dans AuthentificationAdmin
            foreach (Eleve eleve in Utilities.listeDesEleves)
            {
                if (eleve.IdEleve == id)
                {
                    OK = true;
                    break;
                }
                indice++;
            }
            if (!OK)
                return false;
            Utilities.listeDesEleves.RemoveAt(indice);
            Utilities.EnregistrerListeDesEleves();
            return true;
        }
        //---------------------------------------------------------
        public string obtenirStatEleve(int id)
        {
            Eleve el = null;
            el = Utilities.listeDesEleves.Find(x => x.IdEleve == id);
            if (el != null)
            {
                return el.Statistiques.ToString();
            }
            return "";
        }
    }
}