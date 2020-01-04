using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet.UserControls.ELEVE;

namespace Projet.Model
{
    public class Exercice
    {
        public int i { set; get; }//pour indiquer la question courante
        public double time { set; get; }
        public int nbQuestion { private set; get; }
        public List<Question> exercice { private set; get; }
        public Utilities.TypeQuestion type { private set; get; }
        public float note { private set; get; }
        public int nombreDeReponsesJustes { private set; get; }
        public int nombreDeReponses { private set; get; }
        public int cours { private set; get; }
        //---------------------------------------------------------
        private List<int> randomNumbers(int nbMax)
        {
            List<int> randomNumber = new List<int>(nbMax);
            int j = 0;
            int number = 0;
            Random random = new Random();
            while (j < Utilities.min(nbQuestion, nbMax))
            {
                do//générer des nombre sans doublons
                {
                    number = random.Next(nbMax + 1);
                } while (randomNumber.Contains(number) || number == 0);
                randomNumber.Add(number);
                j++;
            }
            return randomNumber;
        }
        //---------------------------------------------------------

        public Exercice(int nbQuestion, Utilities.TypeQuestion type, String chemin, int cours)
        {
            this.cours = cours;
            i = 0;
            note = 0;
            nombreDeReponsesJustes = 0;
            nombreDeReponses = 0;
            this.nbQuestion = nbQuestion;
            this.exercice = new List<Question>(nbQuestion);
            this.type = type;
            time = 0;
            int nbMaxdeQst = 0; //le nombre maximum de question disponible dans ce type d'exercice
                                //pour générer l'id des questions aléatoirement
            List<int> listRand;

            switch (type)
            {
                case Utilities.TypeQuestion.DragAndDrop:
                    {

                        nbMaxdeQst = Utilities.nbQstDragAndDrop;
                        listRand = new List<int>(randomNumbers(nbMaxdeQst));
                        for (int i = 0; i < Utilities.min(nbQuestion, nbMaxdeQst); i++)
                            exercice.Add(new DragAndDrop(listRand[i], chemin));

                    }
                    break;
                case Utilities.TypeQuestion.TrueOrFalse:
                    {

                        nbMaxdeQst = Utilities.nbQstTrueOrFalse;
                        listRand = new List<int>(randomNumbers(nbMaxdeQst));
                        for (int i = 0; i < Utilities.min(nbQuestion, nbMaxdeQst); i++)
                            exercice.Add(new TrueOrFalse(listRand[i], chemin));

                    }
                    break;
                case Utilities.TypeQuestion.QCM:
                    {

                        nbMaxdeQst = Utilities.nbQstQcm;
                        listRand = new List<int>(randomNumbers(nbMaxdeQst));


                        for (int i = 0; i < Utilities.min(nbQuestion, nbMaxdeQst); i++)
                            exercice.Add(new QCM(listRand[i], chemin));

                    }
                    break;
            }
            EleveUserControl.Environnement.question = exercice[0];
            time = calculTemps();
        }
        //---------------------------------------------------------
        public float obtenirNote()//retourne la note de l'exo
        {
            int i = 0;
            switch (type)
            {
                case Utilities.TypeQuestion.QCM:
                    {
                        for (int k = 0; k <= this.i - 1; k++)
                            if (((QCM)exercice[k]).verifier())
                                i++;
                        nombreDeReponses = nbQuestion;
                        nombreDeReponsesJustes = i;
                    }
                    break;

                case Utilities.TypeQuestion.DragAndDrop:
                    {
                        for (int k = 0; k <= this.i - 1; k++)
                        {
                            nombreDeReponsesJustes += (int)(((DragAndDrop)exercice[k]).note() * ((DragAndDrop)exercice[k]).nbVides * 1.0);
                        }
                        for (int k = 0; k < nbQuestion; k++)
                        {
                            i += ((DragAndDrop)exercice[k]).nbVides;
                        }
                        nombreDeReponses = i;
                    }

                    break;
                case Utilities.TypeQuestion.TrueOrFalse:
                    {
                        for (int k = 0; k <= this.i - 1; k++)
                            if (((TrueOrFalse)exercice[k]).verifier())
                                i++;
                        nombreDeReponses = nbQuestion;
                        nombreDeReponsesJustes = i;
                    }
                    break;
            }
            double note1;
            if (type == Utilities.TypeQuestion.DragAndDrop)
                note1 = ((double)nombreDeReponsesJustes / nombreDeReponses)*5;
            else
                note1 = ((double)i / nbQuestion) * 5;//exercice noté sur 5
            note = (float)Math.Round(note1, 1);
            return note;
        }
        //---------------------------------------------------------
        private double calculTemps()//calculer le temps necessaire poue faire l'exo en fonction des questions qu'il le compose 
        {
            double tempsTotal = 0;
            foreach (Question qst in exercice)
            {
                tempsTotal += qst.temps;
            }
            return tempsTotal;
        }
        //---------------------------------------------------------
        public Question QuestionSuivante()//null si pas de question suivante
        {
            switch (type)
            {
                case Utilities.TypeQuestion.QCM:
                    {
                        if (++i > 3) return null;
                        return exercice[i];
                    }
                case Utilities.TypeQuestion.TrueOrFalse:
                    {
                        if (++i > 3) return null;
                        return exercice[i];
                    }
                case Utilities.TypeQuestion.DragAndDrop:
                    {
                        if (++i > 2) return null;
                        return exercice[i];
                    }
            }
            return null;
        }
    }
}
