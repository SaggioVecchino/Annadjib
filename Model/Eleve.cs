using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Projet.UserControls.ELEVE;
namespace Projet.Model
{
    [Serializable]
    public class Eleve
    {
        // public static int idEleve_ { get; set; } //Pour générer IdEleve d'une manière automatique
        //Il faut que le fichier qui contient cette variable l'initialise à 0 donc contient 0 à l'installation

        public int IdEleve { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomComplet
        {
            get
            {
                return Nom + ' ' + Prenom;
            }
        }
        public DateTime DateDeNaissance { get; set; }
        public string Avatar { get; set; } //Le chemin de l'avatar en chaine de caractères
        public int PasswordHashed { get; set; }

        public Stats Statistiques { get; set; }

        public override string ToString()
        {
            return NomComplet;
        }


        //    public Eleve() { } //Si jamais on aurait besoin
        //---------------------------------------------------------
        public Eleve(string Nom, string Prenom, DateTime DateDeNaissance, string Avatar, string Password) //Là on crée l'élève
        {

            Utilities.ChargerEleves();//Il faut la faire parce qu'on a pas appelé ObtenirEleve ni AuthentficationEleve qui appelle ObtenirEleve
            if (Utilities.listeDesEleves.Count == 0)
                this.IdEleve = 0;
            else
                this.IdEleve = Utilities.listeDesEleves.ElementAt(Utilities.listeDesEleves.Count - 1).IdEleve + 1;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.DateDeNaissance = DateDeNaissance;
            this.Avatar = Avatar;
            this.PasswordHashed = Password.GetHashCode();
            this.Statistiques = new Stats();
            Utilities.listeDesEleves.Add(this);
            Utilities.EnregistrerListeDesEleves();
        }
        //---------------------------------------------------------
        public static Eleve ObtenirEleve(int IdEleve)//Là on charge l'élève
        {
            Utilities.ChargerEleves();
            foreach (Eleve eleve in Utilities.listeDesEleves)
                if (eleve.IdEleve == IdEleve)
                    return eleve;
            return null;
        }
        //---------------------------------------------------------
        public static Eleve AuthentficationEleve(int IdEleve, string Password)//Retourne eleve d'id IdEleve si mot de passe correct, null sinon
        {
            Eleve eleve = ObtenirEleve(IdEleve);
            if (eleve == null)
                return null;
            if (Password.GetHashCode() == eleve.PasswordHashed)
                return eleve;
            return null;
        }
        //---------------------------------------------------------
        public void ChangerMotDePasse(string nouveauMotDePasse)
        {
            this.PasswordHashed = nouveauMotDePasse.GetHashCode();
            //c'est important pour utiliserla technique d'entrer
            //l'ancien mot de passe pour rentrer un nouveau
            //Croyez moi cette affectation peut etre indispensable dans certains cas
            int indice = 0;//On utilise pas la méthode find
            //Utilities.ChargerEleves();
            //La liste est déjà chargé puisqu'on est à ce point là, donc inutil de la recharger
            foreach (Eleve eleve in Utilities.listeDesEleves)
            {
                if (eleve.IdEleve == this.IdEleve)
                    break;//Il y'aura un break forcément
                indice++;
            }
            Utilities.listeDesEleves.ElementAt(indice).PasswordHashed = nouveauMotDePasse.GetHashCode();
            Utilities.EnregistrerListeDesEleves();
        }

        //---------------------------------------------------------

        public Cours OuvrirCours(int IdCours)
        {
           // Commun.coursId = IdCours;
            return new Cours(IdCours, Statistiques.Cours[IdCours - 1].pageCourante);
        
        }

        public int PageSuivanteCours(Cours cours)
        {
            int i = cours.Suivant();
            if (i != -1)
            {
                Utilities.StructCours c = new Utilities.StructCours();
                c.id = cours.ID;
                c.pageCourante = cours.page_courante;
                Statistiques.Cours[cours.ID - 1] = c;
                Utilities.MettreAJourListeDesEleves(this);

            }
            return i;
        }

        public int PagePrcedanteCours(Cours cours)
        {
            int i = cours.Precedant();
            if (i != -1)
            {
                Utilities.StructCours c = new Utilities.StructCours();
                c.id = cours.ID;
                c.pageCourante = cours.page_courante;
                Statistiques.Cours[cours.ID - 1] = c;
                Utilities.MettreAJourListeDesEleves(this);
            }
            return i;
        }

        //---------------------------------------------------------
        /*public bool PeutFaireExamen(int IdExamen)//Dans le cas de plusieurs examens
        {
            //utiliser les variables de Statistiques pour retourner un boolean
            if(conditions)
                return true;
            return false;
        }*/
        //---------------------------------------------------------
        public Exercice OuvrirExercice(int numeroCours, Utilities.TypeQuestion type)
        {
            switch (type)
            {
                case Utilities.TypeQuestion.TrueOrFalse:
                    {
                        switch (numeroCours)
                        {
                            case 1:
                                {
                                    return new Exercice(4, Utilities.TypeQuestion.TrueOrFalse, Utilities.cheminTrueOrFalse1, numeroCours);
                                }
                            case 2:
                                {
                                    return new Exercice(4, Utilities.TypeQuestion.TrueOrFalse, Utilities.cheminTrueOrFalse2, numeroCours);
                                }
                            case 3:
                                {
                                    return new Exercice(4, Utilities.TypeQuestion.TrueOrFalse, Utilities.cheminTrueOrFalse3, numeroCours);
                                }
                        }
                    }
                    break;
                case Utilities.TypeQuestion.QCM:
                    {
                        switch (numeroCours)
                        {
                            case 1:
                                {
                                    return new Exercice(4, Utilities.TypeQuestion.QCM, Utilities.cheminQcm1, numeroCours);
                                }
                            case 2:
                                {
                                    return new Exercice(4, Utilities.TypeQuestion.QCM, Utilities.cheminQcm2, numeroCours);
                                }
                            case 3:
                                {
                                    return new Exercice(4, Utilities.TypeQuestion.QCM, Utilities.cheminQcm3, numeroCours);
                                }
                        }

                    }
                    break;
                case Utilities.TypeQuestion.DragAndDrop:
                    {
                        switch (numeroCours)
                        {
                            case 1:
                                {
                                    return new Exercice(3, Utilities.TypeQuestion.DragAndDrop, Utilities.cheminDragAndDrop1, numeroCours);
                                }
                            case 2:
                                {
                                    return new Exercice(3, Utilities.TypeQuestion.DragAndDrop, Utilities.cheminDragAndDrop2, numeroCours);
                                }
                            case 3:
                                {
                                    return new Exercice(3, Utilities.TypeQuestion.DragAndDrop, Utilities.cheminDragAndDrop3, numeroCours);
                                }
                        }

                    }
                    break;
            }
            return null;
        }


        public Question QuestionSuivante()
        {
            if (EleveUserControl.Environnement.exercice == null)
                return null;
            EleveUserControl.Environnement.question = EleveUserControl.Environnement.exercice.QuestionSuivante();
            return EleveUserControl.Environnement.question;
        }

        public float Corriger()
        {
            if (EleveUserControl.Environnement.exercice == null) return (float)-1.0;
            int tmp = 0;
            switch (EleveUserControl.Environnement.exercice.type)
            {
                // case Utilities.TypeQuestion.QCM: tmp = 0; break; //Par défaut tmp = 0
                case Utilities.TypeQuestion.TrueOrFalse: tmp = 1; break;
                case Utilities.TypeQuestion.DragAndDrop: tmp = 2; break;
            }
            Utilities.StructExo strexotmp = new Utilities.StructExo();
            strexotmp.cours = EleveUserControl.Environnement.exercice.cours;
            strexotmp.type = EleveUserControl.Environnement.exercice.type;
            strexotmp.note = EleveUserControl.Environnement.exercice.obtenirNote();
            strexotmp.note=Utilities.max(strexotmp.note,
                Statistiques.Exo[3 * tmp + EleveUserControl.Environnement.exercice.cours - 1].note);
            strexotmp.dejaFait = true;
            Statistiques.Exo[3 * tmp + EleveUserControl.Environnement.exercice.cours - 1] = strexotmp;
            Utilities.MettreAJourListeDesEleves(this);
            return strexotmp.note;
        }//-1.0 si problème


        //---------------------------------------------------------
        /* public Examen OuvrirExamen(int IdExamen)
         {
             if (this.PeutFaireExamen(IdExamen))
                 return new Examen(IdExamen);
             return null;
         }*/
    }





}

