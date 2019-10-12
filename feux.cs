using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Traffic_signs
{
    public class feu//pour une seule feu
    {
        internal int xrouge;
        internal int yrouge;
        internal int xvert;
        internal int yvert;
        internal int xjaune;
        internal int yjaune;
        internal string lieu;//lieu  :"haut", "droite", "gauche", "bas"
        internal string couleur;// "vert", "rouge", "jaune"
        internal PictureBox picVert;
        internal PictureBox picRouge;
        internal PictureBox picJaune;
        public feu(string Lieu, string Couleur)
        {

            lieu = Lieu;
            couleur = Couleur;
            picVert = new PictureBox(); picRouge = new PictureBox(); picJaune = new PictureBox();
            picVert.SizeMode = PictureBoxSizeMode.StretchImage; picRouge.SizeMode = PictureBoxSizeMode.StretchImage; picJaune.SizeMode = PictureBoxSizeMode.StretchImage;
            picRouge.Size = new Size(25, 25); picVert.Size = new Size(25, 25); picJaune.Size = new Size(25, 25);
            switch (couleur)
            {
                case "rouge":
                    {
                        picRouge.Visible = true; picVert.Visible = false; picJaune.Visible = false; break;
                       
                       
                    }
                case "jaune":
                    {
                        picRouge.Visible = false; picVert.Visible = false; picJaune.Visible = true; break;
                    }
                case "vert":
                    {
                        picRouge.Visible = false; picVert.Visible = true; picJaune.Visible = false; break;
                        
                    }
            }
            picRouge.Image = new Bitmap("rouge feux.png"); picVert.Image = new Bitmap("vert feux.png"); picJaune.Image = new Bitmap("jaune feux.png");
        }
        public void inverseFeu()
        {
            switch (couleur)
            {
                case "rouge":
                    {
                        couleur = "vert"; 
                        picRouge.Visible = false; picVert.Visible = true; picJaune.Visible = false;
                         break;
                    }
                case "jaune":
                    {
                            couleur = "rouge";
                            picRouge.Visible = true; picVert.Visible = false; picJaune.Visible = false;
                        
                        break;

                    }
                case "vert":
                    {
                        couleur = "jaune";
                        picRouge.Visible = false; picVert.Visible = false; picJaune.Visible = true; break;
                    }
            }
        }

    }
    public class feuxPlan1
    {
        static bool auto;
        public feu feuBas, feuDroite, feuGauche, feuHaut;
        static void position(feu f)
        {
            switch (f.lieu)
            {
                case "bas":
                    {
                        f.xrouge = 840; f.yrouge = 510; f.xvert = 840; f.yvert = 564; f.xjaune = 840; f.yjaune = 539; break;
                    }
                case "haut":
                    {
                        f.xrouge = 488; f.yrouge = 192; f.xvert = 488; f.yvert = 139; f.xjaune = 488; f.yjaune = 165; break;
                    }
                case "droite":
                    {
                        f.xrouge = 845; f.yrouge = 199; f.xvert = 904; f.yvert = 199; f.xjaune = 874; f.yjaune = 199; break;
                    }
                case "gauche":
                    {
                        f.xrouge = 477; f.yrouge = 508; f.xvert = 418; f.yvert = 508; f.xjaune = 448; f.yjaune = 508; break;
                    }
            }
            f.picRouge.Location = new Point(f.xrouge, f.yrouge);
            f.picVert.Location = new Point(f.xvert, f.yvert);
            f.picJaune.Location = new Point(f.xjaune, f.yjaune);
        }
        void addAuPlan(feu f)
        {
            if (auto == true)
            {
                Form6.f5.Controls.Add(f.picVert);
                Form6.f5.Controls.Add(f.picRouge);
                Form6.f5.Controls.Add(f.picJaune);
            }
            else
            {
                Form6.f8.Controls.Add(f.picVert);
                Form6.f8.Controls.Add(f.picRouge);
                Form6.f8.Controls.Add(f.picJaune);
            }
        }
       public static void feuPersonInverse(bool b)
        {
            if (b == true)
            {
                if (Form6.f5.pictureBox1.Tag.ToString() == "rouge")
                {
                    Form6.f5.pictureBox1.Tag = "vert";
                    Form6.f5.pictureBox1.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f5.pictureBox2.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f5.pictureBox3.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f5.pictureBox4.Image = new Bitmap("feuxPersonOn.png");
                }
                else
                {
                    Form6.f5.pictureBox1.Tag = "rouge";
                    Form6.f5.pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f5.pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f5.pictureBox3.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f5.pictureBox4.Image = new Bitmap("feuxPersonOff.png");
                }
            }
            else
            {
                if (Form6.f8.pictureBox1.Tag.ToString() == "rouge")
                {          
                    Form6.f8.pictureBox1.Tag = "vert";
                    Form6.f8.pictureBox1.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f8.pictureBox2.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f8.pictureBox4.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f8.pictureBox3.Image = new Bitmap("feuxPersonOn.png");
                }          
                else       
                {          
                    Form6.f8.pictureBox1.Tag = "rouge";
                    Form6.f8.pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f8.pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f8.pictureBox4.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f8.pictureBox3.Image = new Bitmap("feuxPersonOffpng");
                }
            }
        }
        public feuxPlan1(bool Auto)
        {
           
            auto = Auto;
            feuBas = new feu("bas", "rouge"); position(feuBas); addAuPlan(feuBas);
            feuDroite = new feu("droite", "vert"); position(feuDroite); addAuPlan(feuDroite);
            feuHaut = new feu("haut", "rouge"); position(feuHaut); addAuPlan(feuHaut);
            feuGauche = new feu("gauche", "vert"); position(feuGauche); addAuPlan(feuGauche);
        }
        public void inverseFeuxZ()
        {
            feuDroite.inverseFeu(); feuGauche.inverseFeu();
            if (feuDroite.couleur == "vert")
            {
                Plan1.stopVoitureGauche = 460;
                Plan1.stopVoitureDroite = 830;
            }
        }
        public void inverseFeuxN()
        {
            feuBas.inverseFeu(); feuHaut.inverseFeu();
            if (feuBas.couleur == "vert")//meme que haut
            {
                Plan1.stopVoitureBas = 500;
                Plan1.stopVoitureHaut = 170;

            }

        }
    }
    public class feuxPlan2
    {
        static bool auto;
        public feu feuBas, feuDroite, feuGauche;
        static void position(feu f)
        {
            switch (f.lieu)
            {
                case "bas":
                    {
                        f.xrouge = 840; f.yrouge = 510; f.xvert = 840; f.yvert = 564; f.xjaune = 840; f.yjaune = 539; break;
                    }
                case "droite":
                    {
                        f.xrouge = 845; f.yrouge = 199; f.xvert = 904; f.yvert = 199; f.xjaune = 874; f.yjaune = 199; break;
                    }
                case "gauche":
                    {
                        f.xrouge = 477; f.yrouge = 508; f.xvert = 418; f.yvert = 508; f.xjaune = 448; f.yjaune = 508; break;
                    }
            }
            f.picRouge.Location = new Point(f.xrouge, f.yrouge);
            f.picVert.Location = new Point(f.xvert, f.yvert);
            f.picJaune.Location = new Point(f.xjaune, f.yjaune);
        }
        void addAuPlan(feu f)
        {
            if (auto == true)
            {
                Form6.f10.Controls.Add(f.picVert);
                Form6.f10.Controls.Add(f.picRouge);
                Form6.f10.Controls.Add(f.picJaune);
            }
            else
            {
                Form6.f11.Controls.Add(f.picVert);
                Form6.f11.Controls.Add(f.picRouge);
                Form6.f11.Controls.Add(f.picJaune);
            }
        }
        public feuxPlan2(bool Auto)
        {
            auto = Auto;
            feuBas = new feu("bas", "rouge"); position(feuBas); addAuPlan(feuBas);
            feuDroite = new feu("droite", "vert"); position(feuDroite); addAuPlan(feuDroite);
            feuGauche = new feu("gauche", "vert"); position(feuGauche); addAuPlan(feuGauche);
        }
        public static void feuPersonInverse(bool b)
        {
            if (b == true)
            {
                if (Form6.f10.pictureBox1.Tag.ToString() == "rouge")
                {
                    Form6.f10.pictureBox1.Tag = "vert";
                    Form6.f10.pictureBox1.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f10.pictureBox2.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f10.pictureBox4.Image = new Bitmap("feuxPersonOn.png");
                }
                else
                {
                    Form6.f10.pictureBox1.Tag = "rouge";
                    Form6.f10.pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f10.pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f10.pictureBox4.Image = new Bitmap("feuxPersonOff.png");
                }
            }
            else
            {
                if (Form6.f11.pictureBox1.Tag.ToString() == "rouge")
                {          
                    Form6.f11.pictureBox1.Tag = "vert";
                    Form6.f11.pictureBox1.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f11.pictureBox2.Image = new Bitmap("feuxPersonOn.png");
                    Form6.f11.pictureBox4.Image = new Bitmap("feuxPersonOn.png");
                }          
                else       
                {          
                    Form6.f11.pictureBox1.Tag = "rouge";
                    Form6.f11.pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f11.pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                    Form6.f11.pictureBox4.Image = new Bitmap("feuxPersonOff.png");
                }
            }  
        }
        public void inverseFeuxN()
        {
            feuBas.inverseFeu();
            if (feuBas.couleur == "vert")//meme que haut
            {
                Plan2.stopVoitureBas = 500;
                
            }

        }
        public void inverseFeuxZ()
        {
            feuDroite.inverseFeu(); feuGauche.inverseFeu();
            if (feuDroite.couleur == "vert")
            {
                Plan2.stopVoitureGauche = 460;
                Plan2.stopVoitureDroite = 830;
            }
        }
    }
    public class feuxPlan3
    {
        static bool auto;
       public feu feuBas, feuGauche;
        static void position(feu f)
        {
            switch (f.lieu)
            {
                case "bas":
                    {
                        f.xrouge = 840; f.yrouge = 510; f.xvert = 840; f.yvert = 564; f.xjaune = 840; f.yjaune = 539; break;
                    }
                case "gauche":
                    {
                        f.xrouge = 578; f.yrouge = 508; f.xvert = 520; f.yvert = 508; f.xjaune = 549; f.yjaune = 508; break;
                    }
            }
            f.picRouge.Location = new Point(f.xrouge, f.yrouge);
            f.picVert.Location = new Point(f.xvert, f.yvert);
            f.picJaune.Location = new Point(f.xjaune, f.yjaune);
        }
        void addAuPlan(feu f)
        {
            if (auto == true)
            {
                Form6.f12.Controls.Add(f.picVert);
                Form6.f12.Controls.Add(f.picRouge);
                Form6.f12.Controls.Add(f.picJaune);
            }
            else
            {
                Form6.f13.Controls.Add(f.picVert);
                Form6.f13.Controls.Add(f.picRouge);
                Form6.f13.Controls.Add(f.picJaune);
            }
        }
        public feuxPlan3(bool Auto)
        {
            auto = Auto;
            feuBas = new feu("bas", "rouge"); position(feuBas); addAuPlan(feuBas);
            feuGauche = new feu("gauche", "vert"); position(feuGauche); addAuPlan(feuGauche);
        }
        public void inverseFeuxZ()
        {
           feuGauche.inverseFeu();
            if (feuGauche.couleur == "vert")
            {
                Plan3.stopVoitureGauche = 560;
                Plan3.stopAmbulanceGauche = 560;
            }

        }
        public void inverseFeuxN()
        {
            feuBas.inverseFeu();
            if (feuBas.couleur == "vert")//meme que haut
            {
                Plan3.stopVoitureBas = 500;
                Plan3.stopAmbulanceBas = 500;

            }


        }
    }
    public class feuxPlan4
    {
        static bool auto;
        public feu feuBas,  feuGauche;
        static void position(feu f)
        {
            switch (f.lieu)
            {
                case "bas":
                    {
                        f.xrouge = 840; f.yrouge = 510; f.xvert = 840; f.yvert = 564; f.xjaune = 840; f.yjaune = 539; break;
                    }
                case "gauche":
                    {
                        f.xrouge = 477; f.yrouge = 508; f.xvert = 418; f.yvert = 508; f.xjaune = 448; f.yjaune = 508; break;
                    }
            }
            f.picRouge.Location = new Point(f.xrouge, f.yrouge);
            f.picVert.Location = new Point(f.xvert, f.yvert);
            f.picJaune.Location = new Point(f.xjaune, f.yjaune);
        }
        void addAuPlan(feu f)
        {
            if (auto == true)
            {
                Form6.f14.Controls.Add(f.picVert);
                Form6.f14.Controls.Add(f.picRouge);
                Form6.f14.Controls.Add(f.picJaune);
            }
            else
            {
                Form6.f15.Controls.Add(f.picVert);
                Form6.f15.Controls.Add(f.picRouge);
                Form6.f15.Controls.Add(f.picJaune);
            }
        }
        public feuxPlan4(bool Auto)
        {
            auto = Auto;
            feuBas = new feu("bas", "rouge"); position(feuBas); addAuPlan(feuBas);           
            feuGauche = new feu("gauche", "vert"); position(feuGauche); addAuPlan(feuGauche);
        }
        public void inverseFeuxZ()
        {
            feuGauche.inverseFeu();
            if (feuGauche.couleur == "vert")
            {
                Plan4.stopVoitureGaucheBas = 460; Plan4.stopVoitureGaucheHaut = 460;
            }

        }
        public void inverseFeuxN()
        {
            feuBas.inverseFeu();
            if (feuBas.couleur == "vert")//meme que haut
            {
                Plan4.stopVoitureBasGauche = 500; Plan4.stopVoitureBasDroite = 500;


            }
        }
    }
    public class feuPetit//pour une seule feu
    {
        internal int xrouge;
        internal int yrouge;
        internal int xvert;
        internal int yvert;
        internal int xjaune;
        internal int yjaune;
        internal string lieu;//lieu  :"haut", "droite", "gauche", "bas"
        internal string couleur;// "vert", "rouge", "jaune"
        internal PictureBox picVert;
        internal PictureBox picRouge;
        internal PictureBox picJaune;
        public feuPetit(string Lieu, string Couleur)
        {

            lieu = Lieu;
            couleur = Couleur;
            picVert = new PictureBox(); picRouge = new PictureBox(); picJaune = new PictureBox();
            picVert.SizeMode = PictureBoxSizeMode.StretchImage; picRouge.SizeMode = PictureBoxSizeMode.StretchImage; picJaune.SizeMode = PictureBoxSizeMode.StretchImage;
            picRouge.Size = new Size(13, 13); picVert.Size = new Size(13, 13); picJaune.Size = new Size(13, 13);
            switch (couleur)
            {
                case "rouge":
                    {
                        picRouge.Visible = true; picVert.Visible = false; picJaune.Visible = false; break;


                    }
                case "jaune":
                    {
                        picRouge.Visible = false; picVert.Visible = false; picJaune.Visible = true; break;
                    }
                case "vert":
                    {
                        picRouge.Visible = false; picVert.Visible = true; picJaune.Visible = false; break;

                    }
            }
            picRouge.Image = new Bitmap("rouge feux.png"); picVert.Image = new Bitmap("vert feux.png"); picJaune.Image = new Bitmap("jaune feux.png");
        }
        public void inverseFeu()
        {
            switch (couleur)
            {
                case "rouge":
                    {
                        couleur = "vert";
                        picRouge.Visible = false; picVert.Visible = true; picJaune.Visible = false;
                        break;
                    }
                case "jaune":
                    {
                        couleur = "rouge";
                        picRouge.Visible = true; picVert.Visible = false; picJaune.Visible = false;

                        break;

                    }
                case "vert":
                    {
                        couleur = "jaune";
                        picRouge.Visible = false; picVert.Visible = false; picJaune.Visible = true; break;
                    }
            }
        }

    }
    public class feuxPlan5
    {
        public feuPetit feuBasGauche, feuBasDroite,feuDroiteBas,feuDroiteHaut,feuHautGauche,feuHautDroite,feuGaucheBas,feuGaucheHaut;
        static void position(feuPetit f)
        {
            switch (f.lieu)
            {
                case "basDroite":
                    {
                        f.xrouge = 1097; f.yrouge = 621; f.xvert = 1097; f.yvert = 650; f.xjaune = 1097; f.yjaune = 635; break;
                    }
                case "droiteBas":
                    {
                        f.xrouge = 1097; f.yrouge = 255; f.xvert = 1097; f.yvert =283; f.xjaune = 1097; f.yjaune = 270; break;
                    }
                case "hautDroite":
                    {
                        f.xrouge = 421; f.yrouge = 99; f.xvert = 453; f.yvert = 99; f.xjaune = 438; f.yjaune = 99; break;
                    }
                case "basGauche":
                    {
                        f.xrouge = 914; f.yrouge = 618; f.xvert = 884; f.yvert = 618; f.xjaune = 899; f.yjaune = 618; break;

                    }
                case "gaucheBas":
                    {
                        f.xrouge = 238; f.yrouge = 618; f.xvert = 209; f.yvert = 618; f.xjaune =224; f.yjaune = 618; break;

                    }
                case "gaucheHaut":
                    {
                        f.xrouge = 244; f.yrouge = 461; f.xvert = 244; f.yvert = 433; f.xjaune = 244; f.yjaune = 446; break;

                    }
                case "hautGauche":
                    {
                        f.xrouge = 244; f.yrouge = 96; f.xvert = 244; f.yvert =68; f.xjaune = 244; f.yjaune = 82; break;

                    }
                case "droiteHaut":
                    {
                        f.xrouge = 1097; f.yrouge = 99; f.xvert = 1127; f.yvert = 99; f.xjaune = 1112; f.yjaune = 99; break;

                    }

            }
            f.picRouge.Location = new Point(f.xrouge, f.yrouge);
            f.picVert.Location = new Point(f.xvert, f.yvert);
            f.picJaune.Location = new Point(f.xjaune, f.yjaune);
        }
        void addAuPlan(feuPetit f)
        {

                Form6.f18.Controls.Add(f.picVert);
                Form6.f18.Controls.Add(f.picRouge);
                Form6.f18.Controls.Add(f.picJaune);
        }
        public feuxPlan5()
        {
       
            feuBasDroite = new feuPetit("basDroite", "rouge"); position(feuBasDroite); addAuPlan(feuBasDroite);
            feuDroiteBas = new feuPetit("droiteBas", "vert"); position(feuDroiteBas); addAuPlan( feuDroiteBas);
            feuHautDroite = new feuPetit("hautDroite", "vert"); position(feuHautDroite); addAuPlan(feuHautDroite);
            feuBasGauche = new feuPetit("basGauche", "vert"); position(feuBasGauche); addAuPlan(feuBasGauche);
            feuDroiteHaut = new feuPetit("droiteHaut", "rouge"); position(feuDroiteHaut); addAuPlan(feuDroiteHaut);
            feuGaucheHaut = new feuPetit("gaucheHaut", "vert"); position(feuGaucheHaut); addAuPlan(feuGaucheHaut);
            feuHautGauche = new feuPetit("hautGauche", "rouge"); position(feuHautGauche); addAuPlan(feuHautGauche);
            feuGaucheBas = new feuPetit("gaucheBas", "rouge"); position(feuGaucheBas); addAuPlan(feuGaucheBas);
        }
        public void inverseFeuxZawya()
        {
            feuBasDroite.inverseFeu();
                feuDroiteHaut.inverseFeu();
            feuHautGauche.inverseFeu();
            feuGaucheBas.inverseFeu();
            if (feuBasDroite.couleur == "vert")
            {
                Plan5.stopVoitureBasBas = 610;
                Plan5.stopVoitureDroiteDroite = 1075;
                Plan5.stopVoitureHautHaut = 60;
                Plan5.stopVoitureGaucheGauche = 220;
            }
        }
        public void inverseFeuxNos()
        {
            feuDroiteBas.inverseFeu();
            feuHautDroite.inverseFeu();
            feuBasGauche.inverseFeu();
            feuGaucheHaut.inverseFeu();
            if (feuDroiteBas.couleur == "vert")
            {
                Plan5.stopVoitureBasGauche = 900;
                Plan5.stopVoitureDroiteBas = 240;
                Plan5.stopVoitureHautDroite = 400;
                Plan5.stopVoitureGaucheHaut = 425;
            }
        }
    }
}