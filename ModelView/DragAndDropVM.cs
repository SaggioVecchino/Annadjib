using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projet.ModelView
{
    class DragAndDropVM
    {
        //Déclaration de l'environement qui vas contenir des éléments alloués dynamiquement
        View.UsrCtrl.Exercices.QuestionDragAndDrop environement;

        public DragAndDropVM(View.UsrCtrl.Exercices.QuestionDragAndDrop environement)
        {
            this.environement = environement;
        }

        //-------------------------------------------------------------------------

        //Création dynamique des TextBlocks qui vont contenir le paragraphe avec ses vides et les suggestions
        // dragAndDrop contient toutes les information liées à la question en cours
        public void CreateTextBlocks( Model.DragAndDrop dragAndDrop)
        {
            environement.myParagraph.Children.Clear();
            //on divise le contenu du paragraphe selon la logique prédéfini
            //le ؟ est l'endroit ou on doit mettre des vides qui seront rempli avec les suggestions proposées
            string[] words = dragAndDrop.Contenu.Split('؟');
            int nbMots = words.Length;
            TextBlock t,t1;
            for (int i = 0; i < nbMots; i++)
            {
                t = new TextBlock();
                t.FontSize = 14;
                t.Text = words[i];
                t.Margin = new System.Windows.Thickness(0, 0, 0, 10);
                //on ajoute le textBlock qui contient une parties des mots de la questions
                environement.myParagraph.Children.Add(t);
                if (i == dragAndDrop.nbVides)
                    break;
                //on crée un autre textBlock qui vas contenir des pointillés (l'espace vide)
                t = new TextBlock();
                t.Name = "textblockVide" + i;
                t.AllowDrop = true;
                t.Width = 170;
                t.TextAlignment = TextAlignment.Center;
                t.FlowDirection = FlowDirection.LeftToRight;
                t.Text = ".....................";
                //on souscrit ce text block à l'événement drop pour pouvoir y mettre le text déposer dessus
                t.Drop += new DragEventHandler(this.TextBlock_Drop);
                t.Margin = new System.Windows.Thickness(0, 0, 0, 10);
                environement.myParagraph.Children.Add(t);
                //on enregistre le nom du textBlock pour pouvoir le retrouver afin d'effectuer des tests dessus lors de la correction
                t1 = (TextBlock)environement.myParagraph.FindName(t.Name);
                //si son nom existe déjà (dans une ancienne question) on le désinscrit d'abord
                if (t1 != null)
                    environement.myParagraph.UnregisterName(t.Name);
                environement.myParagraph.RegisterName(t.Name, t);

            }
            
        }
        //-------------------------------------------------------------------------

        //Creations des textsBlocks qui contiennent les suggestions
        public void CreateAnswersBlocks(Model.DragAndDrop dragAndDrop)
        {
            environement.myChoices.Children.Clear();
            environement.myAnswer.Children.Clear();
            //on déclare un TextBlock spécial crée au préalable nommé DraggableTextBlock
            //ce textBlock permet la visualisation du contenu lors de son glissement 
            View.UsrCtrl.Exercices.DraggableTextBlock t;
            Random rnd = new Random();
            //on ordonne les suggestions aléatoirement sans ordre prédéfini
            string[] MyRandomArray = dragAndDrop.BonneReponses.OrderBy(x => rnd.Next()).ToArray();
            for (int i=0; i<dragAndDrop.nbVides; i++)
            {
                t = new View.UsrCtrl.Exercices.DraggableTextBlock ();
                t.txt.Text = MyRandomArray[i];
                t.Margin = new System.Windows.Thickness(300,i*33, 50, 10);
                t.txt.Foreground = Brushes.DarkCyan;
                t.Width = 170;
                t.txt.TextAlignment = TextAlignment.Center;
                t.txt.FlowDirection = FlowDirection.LeftToRight;
                t.txt.FontSize = 14;
                environement.myChoices.Children.Add(t);
            }
        }
        //-------------------------------------------------------------------------

        //Correction de la question
        public void getAnswers(Model.DragAndDrop dragAndDrop)
        {
            dragAndDrop.ReponsesSelectionnee.Clear();
            for (int i=0 ; i <dragAndDrop.nbVides; i++)
            {
                //on recupère les réponses sélectionnées des textBlock 
                TextBlock textb = (TextBlock)environement.myParagraph.FindName("textblockVide" + i);
                //on les mets dans un tableau
                dragAndDrop.ReponsesSelectionnee.Add(textb.Text);
                //on affiche du vert si la bonne réponse a été séléctionnées et du rouge sinon
                if (dragAndDrop.ReponsesSelectionnee[i] == dragAndDrop.BonneReponses[i])
                    textb.Foreground = Brushes.Green;
                else
                    textb.Foreground = Brushes.Red;
            }
        }
        //-------------------------------------------------------------------------

        //affichage de la bonne Réponse
        public void correctAnswer(Model.DragAndDrop dragAndDrop)
        {
            environement.myChoices.Children.Clear();
            TextBlock t;
            string[] words = dragAndDrop.BonneReponse().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                t = new TextBlock();
                t.FontSize = 14;
                t.Text = words[i]+" ";
                t.Margin = new System.Windows.Thickness(0, 0, 0, 10);
                environement.myAnswer.Children.Add(t);
            }
            
        }
        //-------------------------------------------------------------------------

        //Récupération des données d'un textBlock avec l'évenement Drop
        private void TextBlock_Drop(object sender, DragEventArgs e)
        {
            var currentTextBlock = sender as TextBlock;
            TextBlock draggedWord = e.Data.GetData(typeof(TextBlock)) as TextBlock;
            //affectation du text de l'élément glisser à l'élément vers le textBlock voulu
            currentTextBlock.Text = draggedWord.Text;
            currentTextBlock.Foreground = Brushes.Black;
        }

    }

}
