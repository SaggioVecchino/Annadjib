using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class TrueOrFalse : Question
    {

        private string contenu;
        private bool reponse;
        private bool bonneReponse;
        public string BonneReponse { get; private set; }

        public TrueOrFalse(int number, string chemin)
        {
          //  temps = 30;//on donne 30 seconds pour toutes les quesions de ce type
            int i = 0;
            StreamReader reader = new StreamReader(chemin);
            while (i < number - 1)//on se déplace jusqu'a ce qu'on arrive à la question  voulue
            {
                //on lit 3 fois (une pour le contenu de la question et une pour sa valeur de vérité et une pour le temps)
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                i++;
            }
            //on lit enfin le temps et le contenu souhaités et la valeur de vérité qu'on convertit en booléen
            temps = Convert.ToDouble(reader.ReadLine());
            contenu = reader.ReadLine();
            bonneReponse = Convert.ToBoolean(reader.ReadLine());
            if (bonneReponse) BonneReponse = "صحيح";
            else BonneReponse = "خطأ";
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

        public bool Reponse
        {
            get
            {
                return reponse;
            }

            set
            {
                reponse = value;
            }
        }

        public Boolean verifier()
        {
            if (bonneReponse == reponse) { return true; }
            else { return false; }
        }

    }
}
