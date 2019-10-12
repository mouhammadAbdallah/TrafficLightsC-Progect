using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Traffic_signs
{
    public partial class Form5 : Form//plan 1
    {
        public static Plan1Auto p1;
        int t;//temps en second;
       public int compteur = 0;
        int temps;// en decisecond
        public static int intervalDuTraffic;
        private void timer4_Tick(object sender, EventArgs e)//compte le temps;
        {
            t++;
            
            if(t%16==0) axWindowsMediaPlayer1.URL = "beepCar.mp3";
            label1.Text = (t / 3600).ToString(); label2.Text = ((t / 60) % 60).ToString(); label3.Text = (t % 60).ToString();
            if (t >= Plan1Auto.tempsDuSimulation * 60) { label1.Visible = !label1.Visible; label2.Visible = !label2.Visible; label3.Visible = !label3.Visible; }
            label4.Text = (((460 - Plan1.stopVoitureGauche) / 75)).ToString();
            label5.Text = (((Plan1.stopVoitureBas - 500) / 75)).ToString();
            label7.Text = (((170 - Plan1.stopVoitureHaut) / 75)).ToString();
            label6.Text = (((Plan1.stopVoitureDroite - 830) / 75)).ToString();

            label8.Text = (((510 - Plan1.stopPersonGauche) / 30)).ToString();
            label9.Text = (((Plan1.stopPersonBas - 500) / 30)).ToString();
            label11.Text = (((220 - Plan1.stopPersonHaut) / 30)).ToString();
            label10.Text = (((Plan1.stopPersonDroite - 830) / 30)).ToString();
        }
        private void timer3_Tick(object sender, EventArgs e)//pour changer les feux
        {
            
            compteur = compteur + 1; 
            if (compteur == 40)//saret z asfar
            { p1.fp1.inverseFeuxZ(); Plan1.capableVoitureZ = true; }

            if (compteur == 50)//saret n a5dar w z a7mar
            { p1.fp1.inverseFeuxZ(); p1.fp1.inverseFeuxN(); }

            if (compteur == 90)//saret n asfar
            { p1.fp1.inverseFeuxN();Plan1.capableVoitureN = true; }

            if (compteur == 100)//saret n a7mar w z a5dar
            { p1.fp1.inverseFeuxN(); p1.fp1.inverseFeuxZ(); }

            if (compteur == 130)//saret  z asfar
            { p1.fp1.inverseFeuxZ(); Plan1.capableVoitureZ = true; }

            if (compteur == 140)//saret z ahmar
            { p1.fp1.inverseFeuxZ(); Plan1.capableDeQuite = true; feuxPlan1.feuPersonInverse(true); }

            if (compteur == 170)//saret n a5dar
            { p1.fp1.inverseFeuxN(); }

            if (compteur == 190)//saret n asfar
            { p1.fp1.inverseFeuxN(); Plan1.capableVoitureN = true; }

            if ((compteur == 93)||((compteur == 193)))
            {  Plan1.capableVoitureN = false; }
            if ((compteur == 43) || ((compteur == 133)))
            { Plan1.capableVoitureZ = false; }

            if (compteur == 200)// n saret ahmar w z saret a5dar
            { p1.fp1.inverseFeuxZ(); p1.fp1.inverseFeuxN(); }


            if (compteur == 160) { Plan1.capableDeQuite = false; feuxPlan1.feuPersonInverse(true); }
                if (Plan1.capableDeQuite == true)
            {
                Plan1.stopPersonGauche = 510;
                Plan1.stopPersonDroite = 830;
                Plan1.stopPersonBas = 500;
                Plan1.stopPersonHaut = 220;

            }
            compteur = compteur % 200;
           


        }
        public Form5()
        {
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";
            Plan1.annulerVPCree();
            Plan1Auto.annulerVPExist();
            compteur = 0;
            p1 = new Plan1Auto();
            t = 0;
            temps = 0;
            timer3.Interval = 50*10;

        }

        private void timer2_Tick(object sender, EventArgs e)// montre qui tick chaque deciisecond
        { //test le temps de sortir des voitures et personnes
            temps++;
            if (p1.qTempsVoitureDroite.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsVoitureDroite.Peek()) * 60 * 10))
                {
                    p1.tVoitureDroite[Plan1Auto.nbVoitureExisteDroite] = new VoiturePlan1Auto("droite");
                    Plan1Auto.nbVoitureExisteDroite++;
                    p1.qTempsVoitureDroite.Dequeue();
                }
            }
            if (p1.qTempsVoitureGauche.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsVoitureGauche.Peek()) * 60 * 10))
                {
                    p1.tVoitureGauche[Plan1Auto.nbVoitureExisteGauche] = new VoiturePlan1Auto("gauche");
                    Plan1Auto.nbVoitureExisteGauche++;
                    p1.qTempsVoitureGauche.Dequeue();
                }
            }
            if (p1.qTempsVoitureBas.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsVoitureBas.Peek()) * 60 * 10))
                {
                    p1.tVoitureBas[Plan1Auto.nbVoitureExisteBas] = new VoiturePlan1Auto("bas");
                    Plan1Auto.nbVoitureExisteBas++;
                    p1.qTempsVoitureBas.Dequeue();
                }
            }
            if (p1.qTempsVoitureHaut.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsVoitureHaut.Peek()) * 60 * 10))
                {
                    p1.tVoitureHaut[Plan1Auto.nbVoitureExisteHaut] = new VoiturePlan1Auto("haut");
                    Plan1Auto.nbVoitureExisteHaut++;
                    p1.qTempsVoitureHaut.Dequeue();
                }
            }
            if (p1.qTempsPersonDroite.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsPersonDroite.Peek()) * 60 * 10))
                {
                    p1.tPersonDroite[Plan1Auto.nbPersonExisteDroite] = new PersonPlan1Auto("droite");
                    Plan1Auto.nbPersonExisteDroite++;
                   
                    p1.qTempsPersonDroite.Dequeue();
                }
            }
            if (p1.qTempsPersonGauche.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsPersonGauche.Peek()) * 60 * 10))
                {
                    p1.tPersonGauche[Plan1Auto.nbPersonExisteGauche] = new PersonPlan1Auto("gauche");
                    Plan1Auto.nbPersonExisteGauche++;
                  
                    p1.qTempsPersonGauche.Dequeue();
                }
            }
            if (p1.qTempsPersonBas.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsPersonBas.Peek()) * 60 * 10))
                {
                    p1.tPersonBas[Plan1Auto.nbPersonExisteBas] = new PersonPlan1Auto("bas");
                    Plan1Auto.nbPersonExisteBas++;
                
                    p1.qTempsPersonBas.Dequeue();
                }
            }
            if (p1.qTempsPersonHaut.Count != 0)
            {
                if (temps == (int)(((double)p1.qTempsPersonHaut.Peek()) * 60 * 10))
                {
                    p1.tPersonHaut[Plan1Auto.nbPersonExisteHaut] = new PersonPlan1Auto("haut");
                    Plan1Auto.nbPersonExisteHaut++;
                    p1.qTempsPersonHaut.Dequeue();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)//pour bouger les voiture el les personnes
        {




            for (int i = 0; i < Plan1Auto.nbPersonExisteHaut; i++)
            {
                 if (p1.tPersonHaut[i] != null)
                {
                    if (p1.tPersonHaut[i].existe == false)
                        p1.tPersonHaut[i] = null;
                    else p1.tPersonHaut[i].Bouger();
                }
              
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan1.stopVoitureBas = 500;
            Plan1. stopVoitureGauche = 460;
            Plan1. stopVoitureHaut = 170;
            Plan1. stopVoitureDroite = 830;
            Plan1. stopPersonBas = 500;
            Plan1. stopPersonGauche = 510;
            Plan1. stopPersonHaut = 220;
            Plan1. stopPersonDroite = 830;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Plan1.annulerVPCree();
            Plan1Auto.annulerVPExist();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbVoitureExisteDroite; i++)
            {if (p1.tVoitureDroite[i] != null)
                {
                    if (p1.tVoitureDroite[i].existe == false) p1.tVoitureDroite[i] = null;
                    else p1.tVoitureDroite[i].Bouger();
                }
                
            }

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbVoitureExisteGauche; i++)
            {
                if (p1.tVoitureGauche[i] != null)
                {

                    if (p1.tVoitureGauche[i].existe == false) p1.tVoitureGauche[i] = null;

                    else
                        p1.tVoitureGauche[i].Bouger();
                }
            }

        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbVoitureExisteBas; i++)
            {
                if (p1.tVoitureBas[i] != null)
                {
                    if (p1.tVoitureBas[i].existe == false) p1.tVoitureBas[i] = null;
                    else p1.tVoitureBas[i].Bouger();
                }
            }

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbVoitureExisteHaut; i++)
            {
                if (p1.tVoitureHaut[i] != null)
                {
                    if (p1.tVoitureHaut[i].existe == false)
                        p1.tVoitureHaut[i] = null;
                    else

                        p1.tVoitureHaut[i].Bouger();
                }
            }

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbPersonExisteDroite; i++)
            {
                if (p1.tPersonDroite[i] != null)
                {
                    if (p1.tPersonDroite[i].existe == false) p1.tPersonDroite[i] = null;
                    else p1.tPersonDroite[i].Bouger();

                }
               
            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbPersonExisteGauche; i++)
            {
                if (p1.tPersonGauche[i]!=null)
                {
                    if(p1.tPersonGauche[i].existe == false)
                        p1.tPersonGauche[i] = null;
                    else p1.tPersonGauche[i].Bouger();
                }
               
            }

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan1Auto.nbPersonExisteBas; i++)
            {
                if (p1.tPersonBas[i]!=null)
                {
                    if (p1.tPersonBas[i].existe == false)
                        p1.tPersonBas[i] = null;
                    else p1.tPersonBas[i].Bouger();
                }
               
            }

        }
    }
}
