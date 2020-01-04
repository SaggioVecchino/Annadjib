using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projet.Model.Utilities;

namespace Projet.Model
{
    [Serializable]
    public class Cours
    {
        public string nom { get; set; }
        public int ID { get; set; }// identifiant du cours
        public int nombre_pages { get; set; }
        public int page_courante { get; set; }
        private string[] contenu;

        //Pour Le binding
        public string titre { get; set; }
        public string texte { get; set; }
        public string srcImage { get; set; }

        public Cours(int ID, int pageCourante)
        {
            this.ID = ID;
            page_courante = pageCourante;
            // On remplie les informations du cours depuis un fichier qui contient les noms et le nombres de pages de tous les cours 
            using (StreamReader info_file = new StreamReader(cheminInfoCours))
            {
                //On utilise l'identifiant du cours pour avoir 
                //le déplacement nécessaire dans le fichier qui contient les informations de tous les cours

                int deplacement = ID * 2 - 1, j = 1;
                bool verif = true;
                while (verif)
                {
                    while (j < deplacement)
                    {
                        string tmp = info_file.ReadLine();
                        j++;
                    }
                    nom = info_file.ReadLine();
                    nombre_pages = Convert.ToInt32(info_file.ReadLine());
                    verif = false;
                }
            }

            string Cours_path = string.Format("cours/cour{0}.txt", ID);// construire le path vers le fichier cours

            using (StreamReader cour_file = new StreamReader(Cours_path))
            {
                string strtmp = cour_file.ReadToEnd();     // recuperer le cour en entier dans une chain de caractére
                contenu = strtmp.Split(new Char[] { '@' });//On construit le tableau qui contient les titres, textes et les images 
                                                           // On sépare les textes et les images dans le fichier par le caractere @
            }
            Get_titre();
            Get_text();
            Get_image();
        }

        public string Get_titre(int page)
        {   // récuperer le titre d'une page donnée
            titre = contenu[3 * (page - 1)];
            return titre;
        }

        public string Get_titre()
        {   // récuperer le titre de la page courante
            return Get_titre(page_courante);
        }

        public string Get_text(int page)
        {   // récuperer le text d'une page donnée
            texte = contenu[3 * (page - 1) + 1];
            return texte;
        }

        public string Get_text()
        {   // récuperer le text de la page courante
            return Get_text(page_courante);
        }

        public string Get_image(int page)
        {    // récuperer le lien vers l'image d'une page donnée
            srcImage = contenu[3 * (page - 1) + 2];
            return srcImage;
        }

        public string Get_image()
        {    // récuperer le lien vers l'image de la page courante
            return Get_image(page_courante);
        }

        public Utilities.TypePageCours Get_Type_page(int page)
        {
            if (Get_text(page).Equals("null"))
            {
                if (Get_image(page).Equals("null"))
                {
                    return Utilities.TypePageCours.Vide;
                }
                else
                {
                    return Utilities.TypePageCours.ImageSeule;
                }
            }
            else
            {
                if (Get_image(page).Equals("null"))
                {
                    return Utilities.TypePageCours.TextSeul;
                }
                else { return Utilities.TypePageCours.TextImage; }
            }
        }

        public Utilities.TypePageCours Get_Type_page()
        {
            if (texte.Equals("null"))
            {
                if (srcImage.Equals("null"))
                {
                    return Utilities.TypePageCours.Vide;
                }
                else
                {
                    return Utilities.TypePageCours.ImageSeule;
                }
            }
            else
            {
                if (srcImage.Equals("null"))
                {
                    return Utilities.TypePageCours.TextSeul;
                }
                else
                {
                    return Utilities.TypePageCours.TextImage;
                }
            }
        }

        public bool Suivant_possible()
        {   // verifier si elle existe une page suivante
            if (page_courante == nombre_pages)
                return false;
            return true;
        }

        public bool Precedant_possible()
        {   // verifier si elle existe une page précédante
            if (page_courante == 1)
                return false;
            return true;
        }

        public int Suivant()
        {
            if (Suivant_possible())
            {
                page_courante++;
                Get_titre();
                Get_text();
                Get_image();
                return page_courante;
            }
            return -1;
        }

        public int Precedant()
        {
            if (Precedant_possible())
            {
                page_courante--;
                Get_titre();
                Get_text();
                Get_image();
                return page_courante;
            }
            return -1;
        }
    }
}
