using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Projet.Model
{
    [Serializable]
    public class Stats
    {
        private List<Utilities.StructCours> cours;
        private List<Utilities.StructExo> exo;
        public bool Exam1DejaFait { set; get; }
        public bool Exam2DejaFait { set; get; }
        public double noteExam1 { set; get; }
        public double noteExam2 { set; get; }
        public Utilities.EtatAncienneSession etat;
        public bool[] trophies;


        public List<Utilities.StructCours> Cours
        {
            get
            {
                return cours;
            }

            set
            {
                cours = value;
            }
        }

        internal List<Utilities.StructExo> Exo
        {
            get
            {
                return exo;
            }

            set
            {
                exo = value;
            }
        }


        public Stats()
        {
            trophies = new bool[10];
            Cours = new List<Utilities.StructCours>(Utilities.nbCours);
            Utilities.StructCours tmp = new Utilities.StructCours();
            for (int i = 1; i <= Utilities.nbCours; i++)
            {
                tmp.id = i;
                tmp.pageCourante = 1; //Lors de la création on est toujours à la première page :3
                Cours.Add(tmp);
            }
            Exo = new List<Utilities.StructExo>(Utilities.nbExo);
            Utilities.StructExo exo;
            for (int i = 1; i <= 3; i++)
            {
                exo.type = Utilities.TypeQuestion.QCM;
                exo.cours = i;
                exo.note = 0;
                exo.dejaFait = false;
                Exo.Add(exo);
            }
            for (int i = 1; i <= 3; i++)
            {
                exo.type = Utilities.TypeQuestion.TrueOrFalse;
                exo.cours = i;
                exo.note = 0;
                exo.dejaFait = false;
                Exo.Add(exo);
            }
            for (int i = 1; i <= 3; i++)
            {
                exo.type = Utilities.TypeQuestion.DragAndDrop;
                exo.cours = i;
                exo.note = 0;
                exo.dejaFait = false;
                Exo.Add(exo);
            }

            exo.type = Utilities.TypeQuestion.Cartes;
            exo.cours = 1;
            exo.note = 0;
            exo.dejaFait = false;
            Exo.Add(exo);
            for (int i = 1; i <= 3; i++)
            {
                exo.type = Utilities.TypeQuestion.Cartes;
                exo.cours = 2;
                exo.note = 0;
                Exo.Add(exo);
            }
            exo.type = Utilities.TypeQuestion.Cartes;
            exo.cours = 3;
            exo.note = 0;
            Exo.Add(exo);


            Exam1DejaFait = false;
            Exam2DejaFait = false;
            noteExam1 = 0;
            noteExam2 = 0;

            etat = Utilities.EtatAncienneSession.Menu;

        }


        public double obtenirNoteCours(int i)//indice 1 ou 2 ou 3
        {
            int j = 0;
            double note = 0;
            switch (i)
            {
                case 1:
                    foreach (Utilities.StructExo exercice in exo)
                    {
                        if (exercice.cours == i)
                        {
                            j++;
                            note += exercice.note;
                        }
                    }
                    note /= j;
                    return note;
                case 2:
                    foreach (Utilities.StructExo exercice in exo)
                    {
                        if (exercice.cours == i)
                        {
                            j++;
                            note += exercice.note;
                        }
                    }
                    note /= j;
                    return note;
                case 3:
                    foreach (Utilities.StructExo exercice in exo)
                    {
                        if (exercice.cours == i)
                        {
                            j++;
                            note += exercice.note;
                        }
                    }
                    note /= j;
                    return note;
            }
            return -1;
        }
        public double obtenirMoyAllExercices()
        {
            double result = 0;
            for (int i = 1; i <= 3; i++) result += obtenirNoteCours(i);
            return (result / 3.0);
        }

        public int nbExoFaitCours(int i)//indice 1 ou 2 ou 3
        {
            int j = 0;

            switch (i)
            {
                case 1:
                    foreach (Utilities.StructExo exercice in exo)
                        if (exercice.cours == i && exercice.dejaFait)
                            j++;
                    return j;
                case 2:
                    foreach (Utilities.StructExo exercice in exo)
                        if (exercice.cours == i && exercice.dejaFait)
                            j++;
                    return j;
                case 3:
                    foreach (Utilities.StructExo exercice in exo)
                        if (exercice.cours == i && exercice.dejaFait)
                            j++;
                    return j;
            }
            return -1;
        }
        //---------------------------------------------------------
        /*
        public override string ToString()
        {
            string myStats = "";
            foreach (Utilities.StructCours info in cours)
            {
                myStats = "\nCOURS " + info.id + "\n avancement " + info.pageCourante;
            }
            foreach (Utilities.StructExo info in exo)
            {
                myStats += "\nEXERCICE " + info.id;
                if (info.dejaFait)
                    myStats += "\n note = " + info.note;
                else
                    myStats += "\n PAS ENCORE FAIT";
            }
            if (peutFaireExam)
            {
                foreach (Utilities.StructExam info in examen)
                {
                    myStats += "\nEXAMEN " + info.id;
                    if (info.dejaFait)
                        myStats += "\n note = " + info.note;
                    else
                        myStats += "\n PAS ENCORE FAIT";
                }

            }

            return myStats;
        }*/
    }
}