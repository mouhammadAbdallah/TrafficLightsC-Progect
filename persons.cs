using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Traffic_signs
{
    public class Person
    {
        protected int x;
        protected int y;
        public bool existe;
        protected PictureBox picPerson;
        public static int dp;//variation de la position de person
        protected bool marchant;//true si le person en marche
        protected Person()
        {
            existe = true;
            picPerson = new PictureBox();
            picPerson.SizeMode = PictureBoxSizeMode.StretchImage;
            marchant = true;
        }
        protected void BougerVersHaut()
        {
            if (y > -65) y = y - dp;
            else { existe = false; picPerson.Dispose(); }
        }
        protected void BougerVersBas()
        {
            if (y < 772) y = y + dp;
            else { existe = false; picPerson.Dispose(); }
        }
        protected void BougerVersDroite()
        {
            if (x < 1370) x = x + dp;
            else { existe = false; picPerson.Dispose(); }
        }
        protected void BougerVersGauche()
        {
            if (x > -65) x = x - dp;
            else { existe = false; picPerson.Dispose(); }
        }
    }
    public class PersonPlan1 : Person
    {
        protected string lieuInitial;//lieu initiale :"haut", "droite", "gauche", "bas"
        public static int nbPersonCreeBas;
        public static int nbPersonCreeHaut;
        public static int nbPersonCreeDroite;
        public static int nbPersonCreeGauche;
        static PersonPlan1 ()
        {
          nbPersonCreeBas=0;
         nbPersonCreeHaut=0;
          nbPersonCreeDroite=0;
         nbPersonCreeGauche=0;
        }
        protected PersonPlan1(string LieuInitial) : base()
        {
            lieuInitial = LieuInitial;
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 790; y = 730 + 30 * nbPersonCreeBas;
                        nbPersonCreeBas++;
                        picPerson.Image = new Bitmap("personVersHaut.png");
                        picPerson.Size = new Size(30,15);
                        break;
                    }
                case "gauche":
                    {
                        x = -30 * (nbPersonCreeGauche + 1); y = 461;
                        nbPersonCreeGauche++;
                       picPerson.Image = new Bitmap("personVersDroite.png");
                      picPerson.Size = new Size(15, 30);
                        break;
                    }
                case "haut":
                    {
                        x = 534;

                        y = -30 * (nbPersonCreeHaut + 1);
                        nbPersonCreeHaut++;
                        picPerson.Image = new Bitmap("personVersBas.png");
                        picPerson.Size = new Size(30, 15);
                        break;
                    }
                case "droite":
                    {
                        x = 1370 + 30 * nbPersonCreeDroite; y = 238;
                        nbPersonCreeDroite++;
                        picPerson.Image = new Bitmap("personVersGauche.png");
                        picPerson.Size = new Size(15, 30);
                        break;
                    }
            }
        }
        protected void bougerDeBas()
        {
            if ((y < 458) && (y > 251)) y = y - 2 * dp;
            else BougerVersHaut();

        }
        protected void bougerDeHaut()
        {
         
            if ((y < 457) && (y > 256)) y = y + 2 * dp;
            else BougerVersBas();
        }
        protected void bougerDeDroite()
        {
            if ((x < 780) && (x > 547)) x = x - 2 * dp;
            else BougerVersGauche();
        }
        protected void bougerDeGauche()
        {
            if ((x < 786) && (x > 557)) x = x + 2 * dp;
            else BougerVersDroite();
        }


    }
    public class PersonPlan1Auto : PersonPlan1
    {
        public PersonPlan1Auto(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f5.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if (((Plan1.capableDeQuite==false) && (Math.Abs(y - Plan1.stopPersonBas) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopPersonBas;
                                    Plan1.stopPersonBas += 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
                            }
                            else
                            {

                                bougerDeBas();    
                            }
                            break;
                        }
                    case "gauche":
                        {
                            if (((Plan1.capableDeQuite == false) && (Math.Abs(x - Plan1.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopPersonGauche;
                                    Plan1.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((Plan1.capableDeQuite == false)) && (Math.Abs(y - Plan1.stopPersonHaut) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopPersonHaut;
                                    Plan1.stopPersonHaut -= 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();
                            }
                            break;
                        }
                    case "droite":
                        {

                            if (((Plan1.capableDeQuite == false) && (Math.Abs(x - Plan1.stopPersonDroite) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopPersonDroite;
                                    Plan1.stopPersonDroite += 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
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
    public class PersonPlan1Manuel : PersonPlan1
    {
        public PersonPlan1Manuel(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f8.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if (((!(Plan1.capableDeQuite==true)) && (Math.Abs(y - Plan1.stopPersonBas) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopPersonBas;
                                    Plan1.stopPersonBas += 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeBas();
                             
                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((!(Plan1.capableDeQuite == true) && (Math.Abs(x - Plan1.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopPersonGauche;
                                    Plan1.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((!(Plan1.capableDeQuite == true))) && (Math.Abs(y - Plan1.stopPersonHaut) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan1.stopPersonHaut;
                                    Plan1.stopPersonHaut -= 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();
                            }
                            break;
                        }
                    case "droite":
                        {

                            if (((!(Plan1.capableDeQuite == true)) && (Math.Abs(x - Plan1.stopPersonDroite) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan1.stopPersonDroite;
                                    Plan1.stopPersonDroite += 30; marchant = false;
                                }
                                if (Plan1.capableDeQuite == true) marchant = true;
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
    public class PersonPlan2 : Person
    {
        protected string lieuInitial;//lieu initiale :"haut", "droite", "gauche", "bas"
        public static int nbPersonCreeBas;
        public static int nbPersonCreeHaut;
        public static int nbPersonCreeDroite;
        public static int nbPersonCreeGauche;
        static PersonPlan2()
        {
            nbPersonCreeBas = 0;
            nbPersonCreeHaut = 0;
            nbPersonCreeDroite = 0;
            nbPersonCreeGauche = 0;
        }
        protected PersonPlan2(string LieuInitial) : base()
        {
            lieuInitial = LieuInitial;
            switch (lieuInitial)
            {
                case "bas":
                    {
                        x = 790; y = 730 + 30 * nbPersonCreeBas;
                        nbPersonCreeBas++;
                        picPerson.Image = new Bitmap("arabVersHaut.png");
                        picPerson.Size = new Size(30, 15);
                        break;
                    }
                case "gauche":
                    {
                        x = -30 * (nbPersonCreeGauche + 1); y = 461;
                        nbPersonCreeGauche++;
                        picPerson.Image = new Bitmap("arabVersDroite.png");
                        picPerson.Size = new Size(15, 30);
                        break;
                    }
                case "haut":
                    {
                        x = 534;

                        y = -30 * (nbPersonCreeHaut + 1);
                        nbPersonCreeHaut++;
                        picPerson.Image = new Bitmap("arabVersBas.png");
                        picPerson.Size = new Size(30, 15);
                        break;
                    }
                case "droite":
                    {
                        x = 1370 + 30 * nbPersonCreeDroite; y = 238;
                        nbPersonCreeDroite++;
                        picPerson.Image = new Bitmap("arabVersGauche.png");
                        picPerson.Size = new Size(15, 30);
                        break;
                    }
            }
        }
        protected void bougerDeBas()
        {
            if ((y < 458) && (y > 251)) y = y - 2 * dp;
            else BougerVersHaut();

        }
        protected void bougerDeHaut()
        {

            if ((y < 457) && (y > 256)) y = y + 2 * dp;
            else BougerVersBas();
        }
        protected void bougerDeDroite()
        {
            
             BougerVersGauche();
        }
        protected void bougerDeGauche()
        {
            if ((x < 786) && (x > 557)) x = x + 2 * dp;
            else BougerVersDroite();
        }


    }
    public class PersonPlan2Auto : PersonPlan2
    {
        public PersonPlan2Auto(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f10.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if (((!(Plan2.capableDeQuite == true)) && (Math.Abs(y - Plan2.stopPersonBas) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan2.stopPersonBas;
                                    Plan2.stopPersonBas += 30; marchant = false;
                                }
                                if (Plan2.capableDeQuite == true) marchant = true;
                            }
                            else
                            {

                                bougerDeBas();
                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((!(Plan2.capableDeQuite == true) && (Math.Abs(x - Plan2.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan2.stopPersonGauche;
                                    Plan2.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Plan2.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((!(Plan2.capableDeQuite == true))) && (Math.Abs(y - Plan2.stopPersonHaut) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan2.stopPersonHaut;
                                    Plan2.stopPersonHaut -= 30; marchant = false;
                                }
                                if (Plan2.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();
                            }
                            break;
                        }
                    case "droite":
                        {
                            bougerDeDroite();
                            break;
                        }

                }
            }
        }


    }
    public class PersonPlan2Manuel : PersonPlan2
    {
        public PersonPlan2Manuel(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f11.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "bas":
                        {
                            if (((!(Plan2.capableDeQuite == true)) && (Math.Abs(y - Plan2.stopPersonBas) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan2.stopPersonBas;
                                    Plan2.stopPersonBas += 30; marchant = false;
                                }
                                if (Plan2.capableDeQuite == true) marchant = true;
                            }
                            else
                            {

                                bougerDeBas();
                            }
                            break;
                        }
                    case "gauche":
                        {
                            if ((!(Plan2.capableDeQuite == true) && (Math.Abs(x - Plan2.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan2.stopPersonGauche;
                                    Plan2.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Plan2.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((!(Plan2.capableDeQuite == true))) && (Math.Abs(y - Plan2.stopPersonHaut) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan2.stopPersonHaut;
                                    Plan2.stopPersonHaut -= 30; marchant = false;
                                }
                                if (Plan2.capableDeQuite == true) marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();
                            }
                            break;
                        }
                    case "droite":
                        {
                            bougerDeDroite();
                            break;
                        }

                }
            }
        }


    }
    public class PersonPlan3 : Person
    {
        protected string lieuInitial;//lieu initiale :"haut", "gauche"
        public static int nbPersonCreeHaut;
        public static int nbPersonCreeGauche;
        static PersonPlan3()
        {
            nbPersonCreeHaut = 0;
            nbPersonCreeGauche = 0;
        }
        protected PersonPlan3(string LieuInitial) : base()
        {
            lieuInitial = LieuInitial;
            switch (lieuInitial)
            {
                case "gauche":
                    {
                        x = -30 * (nbPersonCreeGauche + 1); y = 461;
                        nbPersonCreeGauche++;
                        picPerson.Image = new Bitmap("personVersDroiteNuit.png");
                        picPerson.Size = new Size(15, 30);
                        break;
                    }
                case "haut":
                    {
                        x = 643;

                        y = -30 * (nbPersonCreeHaut + 1);
                        nbPersonCreeHaut++;
                        picPerson.Image = new Bitmap("personVersBasNuit.png");
                        picPerson.Size = new Size(30, 15);
                        break;
                    }
            }
        }
        protected void bougerDeHaut()
        {

            if ((y < 457) && (y > 344)) y = y + 3 * dp;
            else BougerVersBas();
        }
        protected void bougerDeGauche()
        {
            if ((x < 786) && (x > 664)) x = x + 3 * dp;
            else BougerVersDroite();
            if((x>1000)&&(x<1020)) picPerson.Image = new Bitmap("personVersDroite.png");
            if(x>1155) picPerson.Image = new Bitmap("personVersDroiteNuit.png");


        }


    }
    public class PersonPlan3Auto : PersonPlan3
    {
        public PersonPlan3Auto(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f12.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "gauche":
                        {
                            if (((Plan3.capableDeQuiteN==false) && (Math.Abs(x - Plan3.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan3.stopPersonGauche;
                                    Plan3.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Plan3.capableDeQuiteN == true) marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((Plan3.capableDeQuiteZ == false)) && (Math.Abs(y - Plan3.stopPersonHaut) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan3.stopPersonHaut;
                                    Plan3.stopPersonHaut -= 30; marchant = false;
                                }
                                if (Plan3.capableDeQuiteZ== true) marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();
                            }
                            break;
                        }
                }
            }
        }


    }
    public class PersonPlan3Manuel : PersonPlan3
    {
        public PersonPlan3Manuel(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f13.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "gauche":
                        {
                            if ((!(Form13.p3.fp3.feuBas.couleur == "rouge") && (Math.Abs(x - Plan3.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan3.stopPersonGauche;
                                    Plan3.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Form13.p3.fp3.feuBas.couleur == "rouge") marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }
                    case "haut":
                        {
                            if ((((!(Form13.p3.fp3.feuGauche.couleur == "rouge"))) && (Math.Abs(y - Plan3.stopPersonHaut) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    y = Plan3.stopPersonHaut;
                                    Plan3.stopPersonHaut -= 30; marchant = false;
                                }
                                if (Form13.p3.fp3.feuGauche.couleur == "rouge") marchant = true;
                            }
                            else
                            {
                                bougerDeHaut();
                            }
                            break;
                        }
                }
            }
        }


    }
    public class PersonPlan4 : Person
    {
        protected string lieuInitial;//lieu initiale :"haut", "droite", "gauche"
        public static int nbPersonCreeHaut;
        public static int nbPersonCreeDroite;
        public static int nbPersonCreeGauche;
        static PersonPlan4()
        {
            nbPersonCreeHaut = 0;
            nbPersonCreeDroite = 0;
            nbPersonCreeGauche = 0;
        }
        protected PersonPlan4(string LieuInitial) : base()
        {
            lieuInitial = LieuInitial;
            switch (lieuInitial)
            {
                case "gauche":
                    {
                        x = -30 * (nbPersonCreeGauche + 1); y = 461;
                        nbPersonCreeGauche++;
                        picPerson.Image = new Bitmap("personneVersDroite.png");
                        picPerson.Size = new Size(15, 30);
                        break;
                    }

                case "droite":
                    {
                        x = 1370 + 30 * nbPersonCreeDroite; y = 238;
                        nbPersonCreeDroite++;
                        picPerson.Image = new Bitmap("personneVersGauche.png");
                        picPerson.Size = new Size(15, 30);
                        break;
                    }
            }
        }

        protected void bougerDeDroite()
        {

            BougerVersGauche();
        }
        protected void bougerDeGauche()
        {
            if ((x < 786) && (x > 557)) x = x + 2 * dp;
            else BougerVersDroite();
        }


    }
    public class PersonPlan4Auto : PersonPlan4
    {
        public PersonPlan4Auto(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f14.Controls.Add(picPerson);
        }
        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "gauche":
                        {
                            if (((Plan4.capableDeQuiteN==false) && (Math.Abs(x - Plan4.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan4.stopPersonGauche;
                                    Plan4.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Plan4.capableDeQuiteN == true) marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }

                    case "droite":
                        {
                            bougerDeDroite();
                            break;
                        }

                }
            }
        }


    }
    public class PersonPlan4Manuel : PersonPlan4
    {
        public PersonPlan4Manuel(string LieuInitial) : base(LieuInitial)
        {
            picPerson.Location = new Point(x, y);
            Form6.f15.Controls.Add(picPerson);
        }

        public void Bouger()
        {
            if (existe == true)
            {
                picPerson.Location = new Point(x, y);
                switch (lieuInitial)
                {
                    case "gauche":
                        {
                            if ((!(Form15.p4.fp4.feuBas.couleur == "rouge") && (Math.Abs(x - Plan4.stopPersonGauche) < dp)) || (marchant == false))
                            {
                                if (marchant == true)
                                {
                                    x = Plan4.stopPersonGauche;
                                    Plan4.stopPersonGauche -= 30; marchant = false;
                                }
                                if (Form15.p4.fp4.feuBas.couleur == "rouge") marchant = true;
                            }
                            else
                            {
                                bougerDeGauche();
                            }
                            break;
                        }

                    case "droite":
                        {
                            bougerDeDroite();
                            break;
                        }

                }
            }
        }

    }
}
