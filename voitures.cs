using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;//additionner ici pour utiliser leur class comme picturebox

namespace Traffic_signs
{
    public class Voiture
    {
        protected Random g;
        public int x;
       public int y;
        public bool existe;
        protected int numero;
        public PictureBox picVoiture;
        public static int dv;//variation de la position de vehicule
        public bool tournée;//true si la voiture deja tournée
        protected bool marchant;//true si la voiture en marche
        protected Voiture()
        {
            g = new Random();
            existe = true;
            picVoiture = new PictureBox();
            picVoiture.SizeMode = PictureBoxSizeMode.StretchImage;
            picVoiture.BackColor = Color.Transparent;
            tournée = false;
            marchant = true;
        }
        protected void BougerVersHaut()
        {
            if (y > -65) y = y - dv;
            else { existe = false; picVoiture.Dispose(); }
        }
        protected void BougerVersBas()
        {
            if (y < 772) y = y + dv;
            else { existe = false; picVoiture.Dispose(); }
        }
        protected void BougerVersDroite()
        {
            if (x < 1370) x = x + dv;
            else { existe = false; picVoiture.Dispose(); }
        }
        protected void BougerVersGauche()
        {
            if (x > -65) x = x - dv;
            else { existe = false; picVoiture.Dispose(); }
        }
    }
    public class VoiturePlan1 : Voiture
    {
        protected string lieuInitial;//lieu initiale :"haut", "droite", "gauche", "bas"
        protected int trajet;//trajet: 0 si va direct, 1 si va a droite, 2 si va agauche
        public static int nbVoitureCreeBas;
        public static int nbVoitureCreeHaut;
        public static int nbVoitureCreeDroite;
        public static int nbVoitureCreeGauche;
        static VoiturePlan1()
        {
            nbVoitureCreeBas = 0;
            nbVoitureCreeHaut = 0;
            nbVoitureCreeDroite = 0;
            nbVoitureCreeGauche = 0;
        }
        protected VoiturePlan1(string LieuInitial) : base()
        {
            trajet = g.Next(0, 3);
            lieuInitial = LieuInitial;
            numero = g.Next(0, 4);
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 715+ g.Next(0,6);
                        y = 730 + 75 * nbVoitureCreeBas;
                        nbVoitureCreeBas++;
                        picVoiture.Image = new Bitmap("voitureVersHaut" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "gauche":
                    {
                        x = -75 * (nbVoitureCreeGauche + 1); y = 400 + g.Next(0, 6);
                        nbVoitureCreeGauche++;

                        picVoiture.Image = new Bitmap("voitureVersDroite" + numero.ToString().ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
                case "haut":
                    {
                        x = 600 + g.Next(0, 6); y = -75 * (nbVoitureCreeHaut + 1);
                        nbVoitureCreeHaut++;
                        picVoiture.Image = new Bitmap("voitureVersBas" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "droite":
                    {
                        x = 1370 + 75 * nbVoitureCreeDroite; y = 290 + g.Next(0, 6);
                        nbVoitureCreeDroite++;
                        picVoiture.Image = new Bitmap("voitureVersGauche" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
            }
        }
        protected void bougerDeBas() {
            switch (trajet)
            {

                case 0://trajet direct
                    {
                        BougerVersHaut();
                        break;
                    }
                case 1:
                case 2://trajet destine droite
                    {
                        if (y > 400) BougerVersHaut();
                        if ((y < 400 + dv) && (y > 400 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("voitureVersDroite" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 400;

                        }
                        if (tournée == true)
                        {

                            BougerVersDroite();

                        }
                        break;
                    }
            }
        }
        protected  void bougerDeGauche()
        {
           
            switch (trajet)
            {
                case 0:
                case 2:
                    {
                        BougerVersDroite(); break;
                    }
                case 1:
                    {
                        if (x < 590) BougerVersDroite();

                        if ((x < 590 + dv) && (x > 590 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("voitureVersBas" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            x = 590;y = 450;

                        }
                        if (tournée == true) BougerVersBas();
                        break;
                    }
            }

        }
        protected void bougerDeHaut()
        {
            
            switch (trajet)
            {
                case 0:
                    {
                        BougerVersBas();
                        break;
                    }
                case 1:
                case 2:
                    {
                        if (y < 280) BougerVersBas();
                        if ((y < 280 + dv) && (y > 280 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("voitureVersGauche" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            x -= 25;
                            picVoiture.Location = new Point(x, y);
                            y = 290;
                        }
                        if (tournée == true) BougerVersGauche();
                        break;
                    }
            }
        }
        protected void bougerDeDroite()
        {
           
            switch (trajet)
            {
                case 0:
                case 2:
                    {
                        BougerVersGauche(); break;
                    }
                case 1:
                    {
                        if (x > 720) BougerVersGauche();
                        if ((x < 720 + dv) && (x > 720 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("voitureVersHaut" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            y -= 25;
                            picVoiture.Location = new Point(x, y);
                            x = 730;
                        }
                        if (tournée == true) BougerVersHaut();
                        break;
                    }
            }
        }

    }
    public class VoiturePlan1Auto : VoiturePlan1
    {
        public VoiturePlan1Auto(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f5.Controls.Add(picVoiture);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form5.p1.fp1.feuBas.couleur == "rouge") || ((Form5.p1.fp1.feuBas.couleur == "jaune") && (Plan1.capableVoitureN == false))) && (Math.Abs(y - Plan1.stopVoitureBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopVoitureBas;
                                    Plan1.stopVoitureBas += 75; marchant = false;
                                }
                                if (Form5.p1.fp1.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();

                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form5.p1.fp1.feuGauche.couleur == "rouge") || ((Form5.p1.fp1.feuGauche.couleur == "jaune") && (Plan1.capableVoitureZ == false))) && (Math.Abs(x - Plan1.stopVoitureGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopVoitureGauche;
                                    Plan1.stopVoitureGauche -= 75; marchant = false;
                                }
                                if (Form5.p1.fp1.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();

                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((Form5.p1.fp1.feuHaut.couleur == "rouge") || ((Form5.p1.fp1.feuHaut.couleur == "jaune") && (Plan1.capableVoitureN == false))) && (Math.Abs(y - Plan1.stopVoitureHaut) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopVoitureHaut;
                                    Plan1.stopVoitureHaut -= 75; marchant = false;
                                }
                                if (Form5.p1.fp1.feuHaut.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();



                            }
                            break;
                        }
                    case "droite":
                        {
                            if ((((Form5.p1.fp1.feuDroite.couleur == "rouge") || ((Form5.p1.fp1.feuDroite.couleur == "jaune")&&(Plan1.capableVoitureZ==false))) && (Math.Abs(x - Plan1.stopVoitureDroite) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopVoitureDroite;
                                    Plan1.stopVoitureDroite += 75; marchant = false;
                                }
                                if (Form5.p1.fp1.feuDroite.couleur == "vert") marchant = true;
                            }
                            else
                            {

                                bougerDeDroite();                          
                            }
                            break;
                        }

                }
            }
        }


    }
    public class VoiturePlan1Manuel : VoiturePlan1
    {
        public VoiturePlan1Manuel(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f8.Controls.Add(picVoiture);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form8.p1.fp1.feuBas.couleur == "rouge") || (Form8.p1.fp1.feuBas.couleur == "jaune")) && (Math.Abs(y - Plan1.stopVoitureBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopVoitureBas;
                                    Plan1.stopVoitureBas += 75; marchant = false;
                                }
                                if (Form8.p1.fp1.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();
                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form8.p1.fp1.feuGauche.couleur == "rouge") || (Form8.p1.fp1.feuGauche.couleur == "jaune")) && (Math.Abs(x - Plan1.stopVoitureGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopVoitureGauche;
                                    Plan1.stopVoitureGauche -= 75; marchant = false;
                                }
                                if (Form8.p1.fp1.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();




                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((Form8.p1.fp1.feuHaut.couleur == "rouge") || (Form8.p1.fp1.feuHaut.couleur == "jaune")) && (Math.Abs(y - Plan1.stopVoitureHaut) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopVoitureHaut;
                                    Plan1.stopVoitureHaut -= 75; marchant = false;
                                }
                                if (Form8.p1.fp1.feuHaut.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();


                            }
                            break;
                        }
                    case "droite":
                        {
                            if ((((Form8.p1.fp1.feuDroite.couleur == "rouge") || (Form8.p1.fp1.feuDroite.couleur == "jaune")) && (Math.Abs(x - Plan1.stopVoitureDroite) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopVoitureDroite;
                                    Plan1.stopVoitureDroite += 75; marchant = false;
                                }
                                if (Form8.p1.fp1.feuDroite.couleur == "vert") marchant = true;
                            }
                            else
                            {

                                bougerDeDroite();
                            }
                            break;
                        }

                }
            }
        }


    }
    public class VoiturePlan2 : Voiture
    {
        protected string lieuInitial;//lieu initiale : "droite", "gauche", "bas"
        protected int trajet;
        public static int nbVoitureCreeBas;
        public static int nbVoitureCreeDroite;
        public static int nbVoitureCreeGauche;
        static VoiturePlan2()
        {
            nbVoitureCreeBas = 0;
            nbVoitureCreeDroite = 0;
            nbVoitureCreeGauche = 0;
        }
        protected VoiturePlan2(string LieuInitial) : base()
        {
            trajet = g.Next(0, 2);
            lieuInitial = LieuInitial;
            numero = g.Next(0, 4);
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 715 + g.Next(0, 6);
                        y = 730 + 75 * nbVoitureCreeBas;
                        nbVoitureCreeBas++;
                        picVoiture.Image = new Bitmap("rangeVersHaut" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "gauche":
                    {
                        x = -75 * (nbVoitureCreeGauche + 1); y = 400 + g.Next(0, 6);
                        nbVoitureCreeGauche++;

                        picVoiture.Image = new Bitmap("rangeVersDroite" + numero.ToString().ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
                case "droite":
                    {
                        x = 1370 + 75 * nbVoitureCreeDroite; y = 290+ g.Next(0, 6);
                        nbVoitureCreeDroite++;
                        picVoiture.Image = new Bitmap("rangeVersGauche" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
            }
        }
        protected void bougerDeBas()
        {
            switch (trajet)
            {
                case 0:
                //trajet destine droite
                    {
                        if (y > 400) BougerVersHaut();
                        if ((y < 400 + dv) && (y > 400 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeVersDroite" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 400;

                        }
                        if (tournée == true)
                        {

                            BougerVersDroite();

                        }
                        break;
                    }
                case 1://trajet destine gauche
                    {
                        if (y > 290) BougerVersHaut();
                        if ((y < 290 + dv) && (y > 290 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeVersGauche" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 290;x = 690;
                        }
                        if (tournée == true) BougerVersGauche();
                        break;
                    }
            }
        }
        protected void bougerDeGauche()
        {

            switch (trajet)
            {
                case 0://direct
                    {
                        BougerVersDroite(); break;
                    }
                case 1:// son droite
                    {
                        if (x < 590) BougerVersDroite();

                        if ((x < 590 + dv) && (x > 590 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeVersBas" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            x = 590;y = 450;

                        }
                        if (tournée == true) BougerVersBas();
                        break;
                    }
            }

        }

        protected void bougerDeDroite()
        {

            switch (trajet)
            {
                case 0:
                case 1://direct
                    {
                        BougerVersGauche(); break;
                    }
            }
        }

    }
    public class VoiturePlan2Auto : VoiturePlan2
    {
        public VoiturePlan2Auto(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f10.Controls.Add(picVoiture);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form10.p2.fp2.feuBas.couleur == "rouge") || ((Form10.p2.fp2.feuBas.couleur == "jaune") && (Plan2.capableVoitureN == false))) && (Math.Abs(y - Plan2.stopVoitureBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan2.stopVoitureBas;
                                    Plan2.stopVoitureBas += 75; marchant = false;
                                }
                                if (Form10.p2.fp2.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();

                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form10.p2.fp2.feuGauche.couleur == "rouge") || ((Form10.p2.fp2.feuGauche.couleur == "jaune") && (Plan2.capableVoitureZ == false))) && (Math.Abs(x - Plan2.stopVoitureGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan2.stopVoitureGauche;
                                    Plan2.stopVoitureGauche -= 75; marchant = false;
                                }
                                if (Form10.p2.fp2.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();

                            }
                            break;
                        }
                    case "droite":
                        {
                            if ((((Form10.p2.fp2.feuDroite.couleur == "rouge") || ((Form10.p2.fp2.feuDroite.couleur == "jaune") && (Plan2.capableVoitureZ == false))) && (Math.Abs(x - Plan2.stopVoitureDroite) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan2.stopVoitureDroite;
                                    Plan2.stopVoitureDroite += 75; marchant = false;
                                }
                                if (Form10.p2.fp2.feuDroite.couleur == "vert") marchant = true;
                            }
                            else
                            {

                                bougerDeDroite();
                            }
                            break;
                        }

                }
            }
        }


    }
    public class VoiturePlan2Manuel : VoiturePlan2
    {
        public VoiturePlan2Manuel(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f11.Controls.Add(picVoiture);
        }

        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form11.p2.fp2.feuBas.couleur == "rouge") || (Form11.p2.fp2.feuBas.couleur == "jaune")) && (Math.Abs(y - Plan2.stopVoitureBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan2.stopVoitureBas;
                                    Plan2.stopVoitureBas += 75; marchant = false;
                                }
                                if (Form11.p2.fp2.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();

                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form11.p2.fp2.feuGauche.couleur == "rouge") || (Form11.p2.fp2.feuGauche.couleur == "jaune")) && (Math.Abs(x - Plan2.stopVoitureGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan2.stopVoitureGauche;
                                    Plan2.stopVoitureGauche -= 75; marchant = false;
                                }
                                if (Form11.p2.fp2.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();

                            }
                            break;
                        }
                    case "droite":
                        {
                            if ((((Form11.p2.fp2.feuDroite.couleur == "rouge") || (Form11.p2.fp2.feuDroite.couleur == "jaune")) && (Math.Abs(x - Plan2.stopVoitureDroite) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan2.stopVoitureDroite;
                                    Plan2.stopVoitureDroite += 75; marchant = false;
                                }
                                if (Form11.p2.fp2.feuDroite.couleur == "vert") marchant = true;
                            }
                            else
                            {

                                bougerDeDroite();
                            }
                            break;
                        }

                }
            }
        }

    }
    public class VoiturePlan3 : Voiture
    {
        protected string lieuInitial;//lieu initiale :"gauche", "bas"
        public int trajet;
        public static int nbVoitureCreeBas;
        public static int nbVoitureCreeGauche;
       
        static VoiturePlan3()
        {
            nbVoitureCreeBas = 0;
            nbVoitureCreeGauche = 0;
        }
        protected VoiturePlan3(string LieuInitial) : base()
        {
            trajet = g.Next(0, 2);
            lieuInitial = LieuInitial;
            numero = g.Next(0, 3);
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 715 + g.Next(0, 6);
                        y = 730 + 75 * nbVoitureCreeBas;
                        nbVoitureCreeBas++;
                        picVoiture.Image = new Bitmap("voitureVersHautNuit" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "gauche":
                    {
                        x = -75 * (nbVoitureCreeGauche + 1); y = 400 + g.Next(0, 6);
                        nbVoitureCreeGauche++;

                        picVoiture.Image = new Bitmap("voitureVersDroiteNuit" + numero.ToString().ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
            }
        }
        protected void bougerDeBas()
        {
            switch (trajet)
            {

                case 0://trajet direct
                    {
                        BougerVersHaut();
                        break;
                    }
                case 1://trajet destine droite
                    {
                        if ((y > 400)&&(tournée==false)) BougerVersHaut();
                        if ((y < 400 + dv) && (y > 400 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("voitureVersDroiteNuit" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 400;

                        }
                        if (tournée == true)
                        {

                            BougerVersDroite();

                        }
                        break;
                    }
            }
        }
        protected void bougerDeGauche()
        {

            switch (trajet)
            {
                case 0://direct
                    {
                        BougerVersDroite(); break;
                    }
                case 1://vers haut
                    {
                        if (x < 718) BougerVersDroite();
                        if ((x < 718 + dv) && (x > 718 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("voitureVersHautNuit" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            x = 718;
                            y =350;
                        }
                        if (tournée == true) BougerVersHaut();
                        break;


                    }
            }

        }

    }
    public class VoiturePlan3Auto : VoiturePlan3
    {
        public VoiturePlan3Auto(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f12.Controls.Add(picVoiture);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form12.p3.fp3.feuBas.couleur == "rouge") || ((Form12.p3.fp3.feuBas.couleur == "jaune")&&(Plan3.capableVoitureN==false))) && (Math.Abs(y - Plan3.stopVoitureBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan3.stopVoitureBas;
                                    Plan3.stopVoitureBas += 75; marchant = false;
                                }
                                if (Form12.p3.fp3.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();

                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form12.p3.fp3.feuGauche.couleur == "rouge") || ((Form12.p3.fp3.feuGauche.couleur == "jaune") && (Plan3.capableVoitureZ == false))) && (Math.Abs(x - Plan3.stopVoitureGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan3.stopVoitureGauche;
                                    Plan3.stopVoitureGauche -= 75; marchant = false;
                                }
                                if (Form12.p3.fp3.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();

                            }
                            break;
                        }                                
                }
            }
        }


    }
    public class VoiturePlan3Manuel : VoiturePlan3
    {
        public VoiturePlan3Manuel(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f13.Controls.Add(picVoiture);
        }

        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form13.p3.fp3.feuBas.couleur == "rouge") || (Form13.p3.fp3.feuBas.couleur == "jaune")) && (Math.Abs(y - Plan3.stopVoitureBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan3.stopVoitureBas;
                                    Plan3.stopVoitureBas += 75; marchant = false;
                                }
                                if (Form13.p3.fp3.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();

                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form13.p3.fp3.feuGauche.couleur == "rouge") || (Form13.p3.fp3.feuGauche.couleur == "jaune")) && (Math.Abs(x - Plan3.stopVoitureGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan3.stopVoitureGauche;
                                    Plan3.stopVoitureGauche -= 75; marchant = false;
                                }
                                if (Form13.p3.fp3.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();

                            }
                            break;
                        }
                }
            }
        }

    }
    public class VoiturePlan4 : Voiture
    {
        protected string lieuInitial;//lieu initiale :"gaucheBas", "basGauche","gaucheHaut", "basDroite"
        public static int nbVoitureCreeBasGauche;
        public static int nbVoitureCreeGaucheBas;
        public static int nbVoitureCreeBasDroite;
        public static int nbVoitureCreeGaucheHaut;
        static VoiturePlan4()
        {
            nbVoitureCreeBasGauche = 0;
            nbVoitureCreeGaucheBas = 0;
            nbVoitureCreeBasDroite = 0;
            nbVoitureCreeGaucheHaut = 0;
        }
        protected VoiturePlan4(string LieuInitial) : base()
        {
            lieuInitial = LieuInitial;
            numero = g.Next(0, 4);
            switch (lieuInitial)
            {
                case "basDroite":
                    {
                        x = 700 + g.Next(0, 6);
                        y = 730 + 75 * nbVoitureCreeBasDroite;
                        nbVoitureCreeBasDroite++;
                        picVoiture.Image = new Bitmap("voitureVersHaut" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "gaucheBas":
                    {
                        x = -75 * (nbVoitureCreeGaucheBas + 1); y = 390 + 3 * numero;
                        nbVoitureCreeGaucheBas++;

                        picVoiture.Image = new Bitmap("voitureVersDroite" + numero.ToString().ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
                case "basGauche":
               
                    {
                        x = 625 + g.Next(0, 6);
                        y = 730 + 75 * nbVoitureCreeBasGauche;
                        nbVoitureCreeBasGauche++;
                        picVoiture.Image = new Bitmap("voitureVersHaut" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "ambulance":
                    {
                       y = 332; x = -200; picVoiture.Size = new Size(90, 60);
                        picVoiture.Image = new Bitmap("ambilanceVersDroite.png");
                       
                        break;
                    }
                case "gaucheHaut":
                    {
                        x = -75 * (nbVoitureCreeGaucheHaut + 1); y = 305 + g.Next(0, 6);
                        nbVoitureCreeGaucheHaut++;

                        picVoiture.Image = new Bitmap("voitureVersDroite" + numero.ToString().ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
            }
        }
        protected void bougerDeBasDroite()
        {


            if ((y > 400)&&(tournée == false)) BougerVersHaut();
            if ((y < 400 + dv) && (y > 400 - dv) && (tournée == false))
            {
                picVoiture.Image = new Bitmap("voitureVersDroite" + numero.ToString() + ".png");
                picVoiture.Size = new Size(65, 40);
                tournée = true;
                picVoiture.Location = new Point(x, y);
                y = 400;

            }
            if (tournée == true)
            {

                BougerVersDroite();

            }


        }
        protected void bougerDeBasGauche()
        {


            if (y > 310) BougerVersHaut();
            if ((y < 310 + dv) && (y > 310 - dv) && (tournée == false))
            {
                picVoiture.Image = new Bitmap("voitureVersDroite" + numero.ToString() + ".png");
                picVoiture.Size = new Size(65, 40);
                tournée = true;
                picVoiture.Location = new Point(x, y);
                y = 310;

            }
            if (tournée == true)
            {

                BougerVersDroite();

            }


        }
        protected void bougerDeGaucheBas()
        {


            BougerVersDroite();

        }
        protected void bougerDeGaucheHaut()
        {


            BougerVersDroite();

        }
    }
    public class VoiturePlan4Auto : VoiturePlan4
    {
       
        public VoiturePlan4Auto(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f14.Controls.Add(picVoiture);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "basDroite":
                        {
                            if ((((Form14.p4.fp4.feuBas.couleur == "rouge") || ((Form14.p4.fp4.feuBas.couleur == "jaune")&&(Plan4.capableVoitureN==false))) && (Math.Abs(y - Plan4.stopVoitureBasDroite) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan4.stopVoitureBasDroite;
                                    Plan4.stopVoitureBasDroite += 75; marchant = false;
                                }
                                if (Form14.p4.fp4.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBasDroite();

                            }
                            break;
                        }
                        case "basGauche":
                            {
                                if ((( (Form14.p4.fp4.feuBas.couleur == "rouge") ||( (Form14.p4.fp4.feuBas.couleur == "jaune") && (Plan4.capableVoitureN== false))) && (Math.Abs(y - Plan4.stopVoitureBasGauche) < dv)) || (marchant == false))
                                {
                                    if (marchant == true)
                                    {
                                        y = Plan4.stopVoitureBasGauche;
                                        Plan4.stopVoitureBasGauche += 75; marchant = false;
                                    }
                                    if (Form14.p4.fp4.feuBas.couleur == "vert") marchant = true;
                                }
                                else
                                {
                                    bougerDeBasGauche();

                                }
                                break;
                            }
                        case "gaucheBas":
                        {
                            if ((((Form14.p4.fp4.feuGauche.couleur == "rouge") || ((Form14.p4.fp4.feuGauche.couleur == "jaune") && (Plan4.capableVoitureZ == false))) && (Math.Abs(x - Plan4.stopVoitureGaucheBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan4.stopVoitureGaucheBas;
                                    Plan4.stopVoitureGaucheBas -= 75; marchant = false;
                                }
                                if (Form14.p4.fp4.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGaucheBas();

                            }
                            break;
                        }
                        case "gaucheHaut":
                            {
                                if ((((Form14.p4.fp4.feuGauche.couleur == "rouge") || ((Form14.p4.fp4.feuGauche.couleur == "jaune") && (Plan4.capableVoitureZ == false))) && (Math.Abs(x - Plan4.stopVoitureGaucheHaut) < dv)) || (marchant == false))
                                {
                                    if (marchant == true)
                                    {
                                        x = Plan4.stopVoitureGaucheHaut;
                                        Plan4.stopVoitureGaucheHaut -= 75; marchant = false;
                                    }
                                    if (Form14.p4.fp4.feuGauche.couleur == "vert") marchant = true;
                                }

                                else
                                {
                                    bougerDeGaucheHaut();

                                }
                                break;
                            }
                    case "ambulance":
                        {
                            if ((((Form14.p4.fp4.feuGauche.couleur == "rouge") || ((Form14.p4.fp4.feuGauche.couleur == "jaune") && (Plan4.capableVoitureZ == false))) && (Math.Abs(x - Plan4.stopambulance) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan4.stopambulance;
                                     marchant = false;
                                }
                                if (Form14.p4.fp4.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGaucheBas();

                            }
                            break;
                        }
                }
            }
        }


    }
    public class VoiturePlan4Manuel : VoiturePlan4
    {
        public VoiturePlan4Manuel(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f15.Controls.Add(picVoiture);
        }

            public void Bouger()
            {
                if (existe == true)
                {
                    picVoiture.Location = new Point(x, y);
                    switch (lieuInitial)
                    {
                        case "basDroite":
                            {
                                if ((((Form15.p4.fp4.feuBas.couleur == "rouge") || (Form15.p4.fp4.feuBas.couleur == "jaune")) && (Math.Abs(y - Plan4.stopVoitureBasDroite) < dv)) || (marchant == false))
                                {
                                    if (marchant == true)
                                    {
                                        y = Plan4.stopVoitureBasDroite;
                                        Plan4.stopVoitureBasDroite += 75; marchant = false;
                                    }
                                    if (Form15.p4.fp4.feuBas.couleur == "vert") marchant = true;
                                }
                                else
                                {
                                    bougerDeBasDroite();

                                }
                                break;
                            }
                        case "basGauche":
                            {
                                if ((((Form15.p4.fp4.feuBas.couleur == "rouge") || (Form15.p4.fp4.feuBas.couleur == "jaune")) && (Math.Abs(y - Plan4.stopVoitureBasGauche) < dv)) || (marchant == false))
                                {
                                    if (marchant == true)
                                    {
                                        y = Plan4.stopVoitureBasGauche;
                                        Plan4.stopVoitureBasGauche += 75; marchant = false;
                                    }
                                    if (Form15.p4.fp4.feuBas.couleur == "vert") marchant = true;
                                }
                                else
                                {
                                    bougerDeBasGauche();

                                }
                                break;
                            }
                        case "gaucheBas":
                            {
                                if ((((Form15.p4.fp4.feuGauche.couleur == "rouge") || (Form15.p4.fp4.feuGauche.couleur == "jaune")) && (Math.Abs(x - Plan4.stopVoitureGaucheBas) < dv)) || (marchant == false))
                                {
                                    if (marchant == true)
                                    {
                                        x = Plan4.stopVoitureGaucheBas;
                                        Plan4.stopVoitureGaucheBas -= 75; marchant = false;
                                    }
                                    if (Form15.p4.fp4.feuGauche.couleur == "vert") marchant = true;
                                }

                                else
                                {
                                    bougerDeGaucheBas();

                                }
                                break;
                            }
                        case "gaucheHaut":
                            {
                                if ((((Form15.p4.fp4.feuGauche.couleur == "rouge") || (Form15.p4.fp4.feuGauche.couleur == "jaune")) && (Math.Abs(x - Plan4.stopVoitureGaucheHaut) < dv)) || (marchant == false))
                                {
                                    if (marchant == true)
                                    {
                                        x = Plan4.stopVoitureGaucheHaut;
                                        Plan4.stopVoitureGaucheHaut -= 75; marchant = false;
                                    }
                                    if (Form15.p4.fp4.feuGauche.couleur == "vert") marchant = true;
                                }

                                else
                                {
                                    bougerDeGaucheHaut();

                                }
                                break;
                            }
                    }
                }
            }

        }
    public class VoiturePlan5 : Voiture
    {
        protected string lieuInitial;//lieu initiale :"haut", "droite", "gauche", "bas"
        protected int trajet;//trajet: 0 si va direct, 1 si va a droite, 2 si va agauche,3 si va arriere
        public static int nbVoitureCreeBas;
        public static int nbVoitureCreeHaut;
        public static int nbVoitureCreeDroite;
        public static int nbVoitureCreeGauche;
       protected bool r = true, s = true, t = true;
        static VoiturePlan5()
        {
            nbVoitureCreeBas = 0;
            nbVoitureCreeHaut = 0;
            nbVoitureCreeDroite = 0;
            nbVoitureCreeGauche = 0;
        }
        protected VoiturePlan5(string LieuInitial) : base()
        {
            trajet = g.Next(2, 3);
            lieuInitial = LieuInitial;
            numero = g.Next(0, 2);
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 1000 + g.Next(0, 6);
                        y = 730 + 75 * nbVoitureCreeBas;
                        nbVoitureCreeBas++;
                        picVoiture.Image = new Bitmap("rangeAscimoVersHaut" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "gauche":
                    {
                        x = -75 * (nbVoitureCreeGauche + 1); y = 515 + g.Next(0, 6);
                        nbVoitureCreeGauche++;

                        picVoiture.Image = new Bitmap("rangeAscimoVersDroite" + numero.ToString().ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
                case "haut":
                    {
                        x = 306 + g.Next(0, 6); y = -75 * (nbVoitureCreeHaut + 1);
                        nbVoitureCreeHaut++;
                        picVoiture.Image = new Bitmap("rangeAscimoVersBas" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(40, 65);
                        break;
                    }
                case "droite":
                    {
                        x = 1370 + 75 * nbVoitureCreeDroite; y = 160 + g.Next(0, 6);
                        nbVoitureCreeDroite++;
                        picVoiture.Image = new Bitmap("rangeAscimoVersGauche" + numero.ToString() + ".png");
                        picVoiture.Size = new Size(65, 40);
                        break;
                    }
            }
        }
        protected void bougerDeBas()
        {
            switch (trajet)
            {

                case 0://trajet direct
                    {
                        BougerVersHaut();
                        break;
                    }
                case 1:
                        //trajet destine droite
                    {
                        if (y > 530) BougerVersHaut();
                        if ((y < 530 + dv) && (y > 530 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersDroite" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 530;
                            x = 1050;

                        }
                        if (tournée == true)
                        {

                            BougerVersDroite();

                        }
                        break;
                    }
                case 2://trajet destine gauche
                    {
                        if (y > 160) BougerVersHaut();
                        if ((y < 160 + dv) && (y > 160 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersGauche" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 160;
                            x = 922;
                        }
                        if (tournée == true) BougerVersGauche();
                        break;
                    }
            }
        }

        protected void bougerDeGauche()
        {

            switch (trajet)
            {
                case 0:
           
                    {
                        BougerVersDroite(); break;
                    }
                case 1:
                    {
                        if (x < 304) BougerVersDroite();

                        if ((x < 304 + dv) && (x > 304 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersBas" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            x = 304;
                            y = 586;

                        }
                        if (tournée == true) BougerVersBas();
                        break;
                    }
                    case 2:
                        {
                            if (x < 977) BougerVersDroite();
                            if ((x < 977 + dv) && (x > 977 - dv) && (tournée == false))
                            {
                                picVoiture.Image = new Bitmap("rangeAscimoVersHaut" + numero.ToString() + ".png");
                                picVoiture.Size = new Size(40, 65);
                                tournée = true;
                                picVoiture.Location = new Point(x, y);
                                x = 977;y = 470;
                            }
                            if (tournée == true) BougerVersHaut();
                            break;


                        }
            }

        }
        protected void bougerDeHaut()
        {

            switch (trajet)
            {
                case 0:
                    {
                        BougerVersBas();

                        break;
                    }
                case 1:
               
                    {
                        if (y < 151) BougerVersBas();
                        if ((y < 151 + dv) && (y > 151 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersGauche" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y = 151;x = 240;
                        }
                        if (tournée == true) BougerVersGauche();
                        break;
                    }
                case 2:
                    {
                        if (y < 511) BougerVersBas();
                        if ((y < 511+ dv) && (y > 511 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersDroite" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(65, 40);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            y =511;x = 360;
                        }
                        if (tournée == true) BougerVersDroite();
                        break;
                    }

            }
        }
        protected void bougerDeDroite()
        {

            switch (trajet)
            {
                case 0:
                    {
                        BougerVersGauche(); break;
                    }
                case 1:
                    {
                        if (x > 994) BougerVersGauche();
                        if ((x < 994 + dv) && (x > 994- dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersHaut" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            x = 994;y = 103;
                        }
                        if (tournée == true) BougerVersHaut();
                        break;
                    }
                case 2:
                    {
                        if (x > 311) BougerVersGauche();
                        if ((x < 311 + dv) && (x > 311 - dv) && (tournée == false))
                        {
                            picVoiture.Image = new Bitmap("rangeAscimoVersBas" + numero.ToString() + ".png");
                            picVoiture.Size = new Size(40, 65);
                            tournée = true;
                            picVoiture.Location = new Point(x, y);
                            x = 311;y = 212;
                        }
                        if (tournée == true) BougerVersBas();
                        break;
                    }
            }
        }

    }
    public class VoiturePlan5Auto : VoiturePlan5
    {
        public VoiturePlan5Auto(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f18.Controls.Add(picVoiture);
        }
       
        public void Bouger()
        {
           
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form18.p5.fp5.feuBasDroite.couleur == "rouge") || ((Form18.p5.fp5.feuBasDroite.couleur == "jaune") && (Plan5.capableZawya == false))) && (Math.Abs(y - Plan5.stopVoitureBasBas) < 2*dv)) || (r == false))
                            {

                                if (r == true)
                                {
                                    y = Plan5.stopVoitureBasBas;
                                    Plan5.stopVoitureBasBas += 75; r = false;
                                }
                                if (Form18.p5.fp5.feuBasDroite.couleur == "vert") r = true;
                            }
                            else
                            {
                                if ((((Form18.p5.fp5.feuDroiteBas.couleur == "rouge") || ((Form18.p5.fp5.feuDroiteBas.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(y - Plan5.stopVoitureDroiteBas) < 2 * dv)) || (s == false))
                                {

                                    if (s == true)
                                    {
                                        y = Plan5.stopVoitureDroiteBas;
                                        Plan5.stopVoitureDroiteBas += 75;s = false;
                                   
                                    }
                                    if (Form18.p5.fp5.feuDroiteBas.couleur == "vert") s= true;
                                }
                                else
                                {
                                    if ((((Form18.p5.fp5.feuHautDroite.couleur == "rouge") || ((Form18.p5.fp5.feuHautDroite.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(x - Plan5.stopVoitureHautDroite) < 2 * dv)) || (t == false))
                                    {
                                        if (t == true)
                                        {
                                            x = Plan5.stopVoitureHautDroite;
                                            Plan5.stopVoitureHautDroite += 75; t = false;
                                        }
                                        if (Form18.p5.fp5.feuHautDroite.couleur == "vert") t= true;
                                    }

                                    else
                                        bougerDeBas();

                                }
                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form18.p5.fp5.feuGaucheBas.couleur == "rouge") || ((Form18.p5.fp5.feuGaucheBas.couleur == "jaune") && (Plan5.capableZawya == false))) && (Math.Abs(x - Plan5.stopVoitureGaucheGauche) < 2 * dv)) || (r == false))
                            {

                                if (r == true)
                                {
                                   x = Plan5.stopVoitureGaucheGauche;
                                    Plan5.stopVoitureGaucheGauche -= 75; r = false;
                                }
                                if (Form18.p5.fp5.feuGaucheBas.couleur == "vert") r = true;
                            }
                            else
                            {
                                if ((((Form18.p5.fp5.feuBasGauche.couleur == "rouge") || ((Form18.p5.fp5.feuBasGauche.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(x - Plan5.stopVoitureBasGauche) < 2 * dv)) || (s == false))
                                {

                                    if (s == true)
                                    {
                                        x= Plan5.stopVoitureBasGauche;
                                        Plan5.stopVoitureBasGauche -= 75; s = false;

                                    }
                                    if (Form18.p5.fp5.feuBasGauche.couleur == "vert") s = true;
                                }
                                else
                                {
                                    if ((((Form18.p5.fp5.feuDroiteBas.couleur == "rouge") || ((Form18.p5.fp5.feuDroiteBas.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(y - Plan5.stopVoitureDroiteBas) < 2 * dv)) || (t == false))
                                    {
                                        if (t == true)
                                        {
                                            y= Plan5.stopVoitureDroiteBas;
                                            Plan5.stopVoitureDroiteBas += 75; t = false;
                                        }
                                        if (Form18.p5.fp5.feuDroiteBas.couleur == "vert") t = true;
                                    }

                                    else
                                        bougerDeGauche();

                                }
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((Form18.p5.fp5.feuHautGauche.couleur == "rouge") || ((Form18.p5.fp5.feuHautGauche.couleur == "jaune") && (Plan5.capableZawya == false))) && (Math.Abs(y - Plan5.stopVoitureHautHaut) < 2 * dv)) || (r == false))
                            {

                                if (r == true)
                                {
                                    y = Plan5.stopVoitureHautHaut;
                                    Plan5.stopVoitureHautHaut -= 75; r = false;
                                }
                                if (Form18.p5.fp5.feuHautGauche.couleur == "vert") r = true;
                            }
                            else
                            {
                                if ((((Form18.p5.fp5.feuGaucheHaut.couleur == "rouge") || ((Form18.p5.fp5.feuGaucheHaut.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(y - Plan5.stopVoitureGaucheHaut) < 2 * dv)) || (s == false))
                                {

                                    if (s == true)
                                    {
                                        y = Plan5.stopVoitureGaucheHaut;
                                        Plan5.stopVoitureGaucheHaut -= 75; s = false;

                                    }
                                    if (Form18.p5.fp5.feuGaucheHaut.couleur == "vert") s = true;
                                }
                                else
                                {
                                    if ((((Form18.p5.fp5.feuBasGauche.couleur == "rouge") || ((Form18.p5.fp5.feuBasGauche.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(x - Plan5.stopVoitureBasGauche) < 2 * dv)) || (t == false))
                                    {
                                        if (t == true)
                                        {
                                            x = Plan5.stopVoitureBasGauche;
                                            Plan5.stopVoitureBasGauche -= 75; t = false;
                                        }
                                        if (Form18.p5.fp5.feuBasGauche.couleur == "vert") t = true;
                                    }

                                    else
                                        bougerDeHaut();

                                }
                            }
                            break;
                        }
                    case "droite":
                        {
                            if ((((Form18.p5.fp5.feuDroiteHaut.couleur == "rouge") || ((Form18.p5.fp5.feuDroiteHaut.couleur == "jaune") && (Plan5.capableZawya == false))) && (Math.Abs(x - Plan5.stopVoitureDroiteDroite) < 2 * dv)) || (r == false))
                            {

                                if (r == true)
                                {
                                    x = Plan5.stopVoitureDroiteDroite;
                                    Plan5.stopVoitureDroiteDroite += 75; r = false;
                                }
                                if (Form18.p5.fp5.feuDroiteHaut.couleur == "vert") r = true;
                            }
                            else
                            {
                                if ((((Form18.p5.fp5.feuHautDroite.couleur == "rouge") || ((Form18.p5.fp5.feuHautDroite.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(x - Plan5.stopVoitureHautDroite) < 2 * dv)) || (s == false))
                                {

                                    if (s == true)
                                    {
                                        x = Plan5.stopVoitureHautDroite;
                                        Plan5.stopVoitureHautDroite += 75; s = false;

                                    }
                                    if (Form18.p5.fp5.feuHautDroite.couleur == "vert") s = true;
                                }
                                else
                                {
                                    if ((((Form18.p5.fp5.feuGaucheHaut.couleur == "rouge") || ((Form18.p5.fp5.feuGaucheHaut.couleur == "jaune") && (Plan5.capableNos == false))) && (Math.Abs(y - Plan5.stopVoitureGaucheHaut) < 2 * dv)) || (t == false))
                                    {
                                        if (t == true)
                                        {
                                            y = Plan5.stopVoitureGaucheHaut;
                                            Plan5.stopVoitureGaucheHaut -= 75; t = false;
                                        }
                                        if (Form18.p5.fp5.feuGaucheHaut.couleur == "vert") t = true;
                                    }

                                    else
                                        bougerDeDroite();

                                }
                            }
                            break;
                        }
                }
            }
        }


    }
    public class AmbulancePlan3 : Voiture
    {
        protected string lieuInitial;//lieu initiale :"gauche", "bas"
        public int trajet;
        protected AmbulancePlan3(string LieuInitial) : base()
        {
            
            lieuInitial = LieuInitial;
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 685;
                       
                        y = 800;
                        picVoiture.Image = new Bitmap("ambilanceVersHautNuit.png");
                        picVoiture.Size = new Size(50, 75);
                        break;
                    }
                case "gauche":
                    {
                       y =418;
                       
                        x = -150;

                        picVoiture.Image = new Bitmap("ambilanceVersDroiteNuit.png");
                        picVoiture.Size = new Size(75, 50);
                        break;
                    }
            }
        }
        protected void bougerDeBas()
        {
           
          BougerVersHaut();
                      
           
        }
        protected void bougerDeGauche()
        {      
             BougerVersDroite();            
        }

    }
    public class AmbulancePlan3Auto : AmbulancePlan3
    {
        public AmbulancePlan3Auto(string LieuInitial) : base(LieuInitial)
        {
            picVoiture.Location = new Point(x, y);
            Form6.f12.Controls.Add(picVoiture);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picVoiture.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if ((((Form12.p3.fp3.feuBas.couleur == "rouge") || ((Form12.p3.fp3.feuBas.couleur == "jaune") && (Plan3.capableVoitureN == false))) && (Math.Abs(y - Plan3.stopAmbulanceBas) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan3.stopAmbulanceBas;
                                   marchant = false;
                                }
                                if (Form12.p3.fp3.feuBas.couleur == "vert") marchant = true;
                            }
                            else
                            {
                                bougerDeBas();

                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((((Form12.p3.fp3.feuGauche.couleur == "rouge") || ((Form12.p3.fp3.feuGauche.couleur == "jaune") && (Plan3.capableVoitureZ == false))) && (Math.Abs(x - Plan3.stopAmbulanceGauche) < dv)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan3.stopAmbulanceGauche;
                                     marchant = false;
                                }
                                if (Form12.p3.fp3.feuGauche.couleur == "vert") marchant = true;
                            }

                            else
                            {
                                bougerDeGauche();

                            }
                            break;
                        }
                }
            }
        }


    }

}


