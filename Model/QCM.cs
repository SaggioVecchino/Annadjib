using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet.Model
{
    class QCM : Question
    {

        public int ID { get; set; }
        public string question { get; set; }
        public int nbr_choix { get; set; }
        public string[] choix { get; set; }
        public int BonneReponse_ { get; set; }
        public string BonneReponse { get; set; }
        public int Reponse { get; set; }
        //-------------------------------------------------------------------------

        public QCM(int id, string chemin)
        {
            ID = id;//initialiser l'id
            //lire les autre information du fichier
            StreamReader reader = new StreamReader(chemin);
            int j = 0;
            int i;
            string strtmp;
            int nbr_choix_tmp;
            //deplacer dans le fichier jusqu'a arriver a la position voulu
            while (j < id - 1)
            {
                strtmp = reader.ReadLine();
                strtmp = reader.ReadLine();
                //recuperer le nombre de choix dans chaque question pour savoire combien il faut deplacer 
                nbr_choix_tmp = Convert.ToInt32(reader.ReadLine());
                for (i = 0; i < 1 + nbr_choix_tmp; i++)
                    strtmp = reader.ReadLine();
                j++;
            }
            i = 0;
            temps = Convert.ToDouble(reader.ReadLine());
            question = reader.ReadLine();// charger la question
            nbr_choix = Convert.ToInt32(reader.ReadLine());// charger le nombre de choix
            choix = new string[nbr_choix];
            while (i < nbr_choix)
            {
                choix[i] = reader.ReadLine();// charger les choix
                i++;
            }
            BonneReponse_ = Convert.ToInt32(reader.ReadLine()); // charger le numero de la bonne reponce 
            BonneReponse = choix[BonneReponse_-1];
        }
        //-------------------------------------------------------------------------

        public Boolean verifier()
        {
            if (BonneReponse_ == Reponse)
                return true;
            return false;
        }
    }
}
