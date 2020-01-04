using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet.Model
{
    class DragAndDrop : Question
    {
        private List<string> bonneReponses;
        private List<string> reponsesSelectionnee;
        public int nbVides { get; set; }
        private string contenu;

        public List<string> BonneReponses
        {
            get
            {
                return bonneReponses;
            }

            set
            {
                bonneReponses = value;
            }
        }

        public List<string> ReponsesSelectionnee
        {
            get
            {
                return reponsesSelectionnee;
            }

            set
            {
                reponsesSelectionnee = value;
            }
        }

        public string Contenu
        {
            get
            {
                return contenu;
            }

            set
            {
                contenu = value;
            }
        }
        //-------------------------------------------------------------------------
        public DragAndDrop(int number, string chemin)
        {
            int i = 0;
            int j = 0;
            bonneReponses = new List<string>();
            StreamReader reader = new StreamReader(chemin);
            while (i < number - 1)//parcourir tout les paragraphes et leur réponses jusqu'au paragraphe souhaité
            {
                string lignes = reader.ReadLine();
                while (lignes != "@")// on lit le paragraphe
                {
                    lignes = reader.ReadLine();
                }
                nbVides = Convert.ToInt32(reader.ReadLine());// on lit le nombres de vides que vas contenir chaque paragraphe
                while (j < nbVides)
                {
                    reader.ReadLine();//on lit les bonnes réponses dans l'ordre
                    j++;
                }
                j = 0;
                i++;
            }

            //lecture du contenu du paragraphe souhaité , son nombre de vides et ses bonnes réponses 
            temps = Convert.ToDouble(reader.ReadLine());
            string ligne = reader.ReadLine();
            while (ligne != "@")
            {
                Contenu += ligne;
                ligne = reader.ReadLine();
            }

            nbVides = Convert.ToInt32(reader.ReadLine());
            this.reponsesSelectionnee = new List<string>(nbVides);
            bonneReponses = new List<string>(nbVides);
            while (j < nbVides)
            {
                BonneReponses.Add(reader.ReadLine());
                j++;
            }

        }
        //-------------------------------------------------------------------------

        public double note()
        {
            int note1 = 0;
            int i = 0;
            foreach (string rpns in reponsesSelectionnee)
            {
                if (rpns == bonneReponses[i])
                {
                    note1++;
                }
                i++;
            }
            return (note1 * 1.0 / i * (1.0));
        }

        //-------------------------------------------------------------------------

        public string BonneReponse()
        {
            int j = 0;
            int i = 0;
            string resultat = "";
            string ligne = "";
            if (contenu[0].Equals("؟"))
            {
                resultat = bonneReponses[0];
                j++;

            }

            string[] contenuS = contenu.Split('؟');

            while ((j < bonneReponses.Count) && (i < contenuS.Length))
            {
                ligne = contenuS[i] + bonneReponses[j];
                resultat += ligne;
                i++;
                j++;
            }

            while (j < bonneReponses.Count)
            {
                resultat += bonneReponses[j];
                j++;
            }
            while (i < contenuS.Length)
            {
                resultat += contenuS[i];
                i++;
            }
            return resultat;

        }
        //-------------------------------------------------------------------------

    }
}
