using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic_signs
{

    public partial class Form14 : Form
    {
        int te;
        int s = 2;
        bool ambBas;
        VoiturePlan4Auto ambulance;
        public static Plan4Auto p4;
        int t, k;//temps en second;
        int compteur = 0;
        int temps;// en decisecond
    
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";
            s = 2;
            ambBas = false;
            Plan4.annulerVPCree();
            Plan4Auto.annulerVPExist();

            p4 = new Plan4Auto();
            t = 0;
            temps = 0;
            timer3.Interval = 50 * 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ambulance != null)
            {
                if (ambulance.existe == false) { ambulance = null; timer1.Enabled = false;timer13.Enabled = false; }
                else { ambulance.Bouger(); ambulance.Bouger(); }
            }

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            temps++;
            if (p4.qTempsVoitureGaucheBas.Count != 0)
            {
                if (temps == (int)(((double)p4.qTempsVoitureGaucheBas.Peek()) * 60 * 10))
                {
                    p4.tVoitureGaucheBas[Plan4Auto.nbVoitureExisteGaucheBas] = new VoiturePlan4Auto("gaucheBas");
                    Plan4Auto.nbVoitureExisteGaucheBas++;
                    p4.qTempsVoitureGaucheBas.Dequeue();
                }
            }
            if (p4.qTempsVoitureBasGauche.Count != 0)
            {
                if (temps == (int)(((double)p4.qTempsVoitureBasGauche.Peek()) * 60 * 10))
                {

                    p4.tVoitureBasGauche[Plan4Auto.nbVoitureExisteBasGauche] = new VoiturePlan4Auto("basGauche");

                    Plan4Auto.nbVoitureExisteBasGauche++;
                    p4.qTempsVoitureBasGauche.Dequeue();
                }
            }
            if (p4.qTempsVoitureGaucheHaut.Count != 0)
            {
                if (temps == (int)(((double)p4.qTempsVoitureGaucheHaut.Peek()) * 60 * 10))
                {
                    p4.tVoitureGaucheHaut[Plan4Auto.nbVoitureExisteGaucheHaut] = new VoiturePlan4Auto("gaucheHaut");
                    Plan4Auto.nbVoitureExisteGaucheHaut++;
                    p4.qTempsVoitureGaucheHaut.Dequeue();
                }
            }

            if (p4.qTempsVoitureBasDroite.Count != 0)
            {
                if (temps == (int)(((double)p4.qTempsVoitureBasDroite.Peek()) * 60 * 10))
                {
                    p4.tVoitureBasDroite[Plan4Auto.nbVoitureExisteBasDroite] = new VoiturePlan4Auto("basDroite");

                    Plan4Auto.nbVoitureExisteBasDroite++;
                    p4.qTempsVoitureBasDroite.Dequeue();
                }
            }

            if (p4.qTempsPersonGauche.Count != 0)
            {
                if (temps == (int)(((double)p4.qTempsPersonGauche.Peek()) * 60 * 10))
                {
                    p4.tPersonGauche[Plan4Auto.nbPersonExisteGauche] = new PersonPlan4Auto("gauche");
                    Plan4Auto.nbPersonExisteGauche++;
                    p4.qTempsPersonGauche.Dequeue();
                }
            }

            if (p4.qTempsPersonDroite.Count != 0)
            {
                if (temps == (int)(((double)p4.qTempsPersonDroite.Peek()) * 60 * 10))
                {
                    p4.tPersonDroite[Plan4Auto.nbPersonExisteDroite] = new PersonPlan4Auto("droite");
                    Plan4Auto.nbPersonExisteDroite++;
                  
                    p4.qTempsPersonDroite.Dequeue();
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            compteur = (compteur + 1);
            if (compteur == 1) { Plan4.capableDeQuiteN = true; pictureBox1.Image = new Bitmap("feuxPersonOn.png"); }
            if (compteur % 100 == 40) { p4.fp4.inverseFeuxZ(); Plan4.capableVoitureZ = true; }
            if (compteur % 100 == 41) { Plan4.capableVoitureZ = false; Plan4.capableDeQuiteN = false; pictureBox1.Image = new Bitmap("feuxPersonOff.png"); }
            if (compteur % 100 == 50) { p4.fp4.inverseFeuxN(); p4.fp4.inverseFeuxZ(); Plan4.capableDeQuiteZ = true; }
            if (compteur % 100 == 90) { p4.fp4.inverseFeuxN(); Plan4.capableVoitureN = true; }
            if (compteur % 100 == 91) { Plan4.capableDeQuiteZ = false; Plan4.capableVoitureN = false; }
            if (compteur % 100 == 0) { p4.fp4.inverseFeuxN(); p4.fp4.inverseFeuxZ(); }

            if (Plan4.capableDeQuiteN == true)
            {
                Plan4.stopPersonGauche = 510;

            }
            if ((ambBas == true) && (p4.fp4.feuGauche.couleur != "vert"))
            {
                if (k == 0)
                { timer3.Interval = 5; }
                k++;
            }
            else if (ambBas == true) { timer3.Interval = 50 * 10; ambBas = false; }

            compteur = compteur % 100;

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            t++;
            if (t % 20 == 0) axWindowsMediaPlayer1.URL = "beepCar.mp3";
            label7.Text = (t / 3600).ToString(); label6.Text = ((t / 60) % 60).ToString(); label3.Text = (t % 60).ToString();
            label5.Text = (((Plan4.stopVoitureBasDroite - 500) / 75)).ToString();
            label2.Text = (((Plan4.stopVoitureBasGauche - 500) / 75)).ToString();
            label4.Text = (((460 - Plan4.stopVoitureGaucheBas) / 75)).ToString();
            label1.Text = (((460 - Plan4.stopVoitureGaucheHaut) / 75)).ToString();
            if (t >= Plan4Auto.tempsDuSimulation * 60) { label7.Visible = !label7.Visible; label6.Visible = !label6.Visible; label3.Visible = !label3.Visible; }
            label8.Text = (((510 - Plan4.stopPersonGauche) / 30)).ToString();

        }

        private void Form14_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan4.stopVoitureBasGauche = 500; Plan4.stopVoitureBasDroite = 500;
            Plan4.stopVoitureGaucheBas = 460; Plan4.stopVoitureGaucheHaut = 460;
            Plan4.stopPersonGauche = 510;

        }

    

        private void timer5_Tick(object sender, EventArgs e)
        {
            te++;
            if (te == 10) { timer5.Enabled = false; button2.Enabled = true; }

        }

  

        private void timer6_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbVoitureExisteGaucheBas; i++)
            {
                if (p4.tVoitureGaucheBas[i] != null)
                {
                    if (p4.tVoitureGaucheBas[i].existe == false)
                        p4.tVoitureGaucheBas[i] = null;
                    else p4.tVoitureGaucheBas[i].Bouger();

                }
            }

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbVoitureExisteGaucheHaut; i++)
            {
                if (p4.tVoitureGaucheHaut[i] != null)
                {
                    if (p4.tVoitureGaucheHaut[i].existe == false)
                        p4.tVoitureGaucheHaut[i] = null;
                    else p4.tVoitureGaucheHaut[i].Bouger();

                }
            }

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbVoitureExisteBasGauche; i++)
            {
                if (p4.tVoitureBasGauche[i] != null)
                {
                    if (p4.tVoitureBasGauche[i].existe == false)
                        p4.tVoitureBasGauche[i] = null;
                    else p4.tVoitureBasGauche[i].Bouger();

                }
              
            }

        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbVoitureExisteBasDroite; i++)
            {
                if (p4.tVoitureBasDroite[i] != null)
                {
                    if (p4.tVoitureBasDroite[i].existe== false)
                        p4.tVoitureBasDroite[i] = null;
                    else p4.tVoitureBasDroite[i].Bouger();

                }
            }

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbPersonExisteGauche; i++)
            {
                if (p4.tPersonGauche[i] != null)
                {
                    if (p4.tPersonGauche[i].existe == false)
                        p4.tPersonGauche[i] = null;
                    else p4.tPersonGauche[i].Bouger();

                }
            }

        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbPersonExisteHaut; i++)
            {if (p4.tPersonHaut[i] != null)
                {
                    if (p4.tPersonHaut[i].existe == false)
                        p4.tPersonHaut[i] = null;
                    else p4.tPersonHaut[i].Bouger();

                }
            }

        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbPersonExisteDroite; i++)
            {
                if (p4.tPersonDroite[i] != null)
                {
                    if (p4.tPersonDroite[i].existe == false)
                        p4.tPersonDroite[i] = null;
                    else p4.tPersonDroite[i].Bouger();

                }
            }

        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Auto.nbVoitureExisteGaucheBas; i++)
            {
                if (p4.tVoitureGaucheBas[i] != null)
                {
                    if (p4.tVoitureGaucheBas[i].y !=420)
                        if ((Math.Abs(ambulance.x - p4.tVoitureGaucheBas[i].x) < 120)&&(p4.tVoitureGaucheBas[i].y< 420))

                        p4.tVoitureGaucheBas[i].y = 420;
                }
            }
            for (int i = 0; i < Plan4Auto.nbVoitureExisteGaucheHaut; i++)
            {
                if (p4.tVoitureGaucheHaut[i] != null)
                {
                    if (p4.tVoitureGaucheHaut[i].y != 275)
                    if ((Math.Abs(ambulance.x - p4.tVoitureGaucheHaut[i].x )<120)&& (p4.tVoitureGaucheHaut[i].y > 275))
                        p4.tVoitureGaucheHaut[i].y = 275;
                }
            }
            for (int i = 0; i < Plan4Auto.nbVoitureExisteBasGauche; i++)
            {
                if (p4.tVoitureBasGauche[i] != null)
                {
                    if ((p4.tVoitureBasGauche[i].x > 800) && (p4.tVoitureBasGauche[i].y != 275))
                        if (Math.Abs(ambulance.x - p4.tVoitureBasGauche[i].x) < 120)
                            p4.tVoitureBasGauche[i].y = 275;
                }
            }
            for (int i = 0; i < Plan4Auto.nbVoitureExisteBasDroite; i++)
            {
                if (p4.tVoitureBasDroite[i] != null)
                {
                    if ((p4.tVoitureBasDroite[i].x > 790) && (p4.tVoitureBasDroite[i].y != 420))
                        if ( Math.Abs(ambulance.x - p4.tVoitureBasDroite[i].x) < 120)
                            p4.tVoitureBasDroite[i].y = 420;
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "urgence.mp3";

            te = 0; timer5.Enabled = true; timer1.Enabled = true; timer13.Enabled = true;
            k = 0; button2.Enabled = false;
            ambulance = new VoiturePlan4Auto("ambulance"); ambBas = true;
            //ambulance.picVoiture.Image = new Bitmap("ambilanceVersDroite.png");
            //ambulance.y = 332; ambulance.x= -100;ambulance.picVoiture.Size = new Size(90, 60);
       
        }

    }
}

