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
    public partial class Form10 : Form
    {
        public static Plan2Auto p2;
        int t;//temps en second;
        int compteur = 0;
        int temps;// en decisecond
        public bool capable;

        private void timer3_Tick(object sender, EventArgs e)
        {
            compteur = compteur + 1;
            if (compteur == 40)//saret z asfar
            { p2.fp2.inverseFeuxZ(); Plan2.capableVoitureZ = true; }

            if (compteur == 50)//saret n a5dar w z a7mar
            { p2.fp2.inverseFeuxZ(); p2.fp2.inverseFeuxN(); }

            if (compteur == 90)//saret n asfar
            { p2.fp2.inverseFeuxN(); Plan2.capableVoitureN = true; }

            if (compteur == 100)//saret n a7mar w z a5dar
            { p2.fp2.inverseFeuxN(); p2.fp2.inverseFeuxZ(); }

            if (compteur == 130)//saret  z asfar
            { p2.fp2.inverseFeuxZ(); Plan2.capableVoitureZ = true; }

            if (compteur == 140)//saret z ahmar
            { p2.fp2.inverseFeuxZ(); Plan2.capableDeQuite = true; feuxPlan2.feuPersonInverse(true); }

            if (compteur == 170)//saret n a5dar
            { p2.fp2.inverseFeuxN(); }

            if (compteur == 190)//saret n asfar
            { p2.fp2.inverseFeuxN(); Plan2.capableVoitureN = true; }

            if ((compteur == 93) || ((compteur == 193)))
            { Plan2.capableVoitureN = false; }
            if ((compteur == 43) || ((compteur == 133)))
            { Plan2.capableVoitureZ = false; }

            if (compteur == 200)// n saret ahmar w z saret a5dar
            { p2.fp2.inverseFeuxZ(); p2.fp2.inverseFeuxN(); }


            if (compteur == 160) { Plan2.capableDeQuite = false; feuxPlan2.feuPersonInverse(true); }
            if (Plan2.capableDeQuite == true)
            {
                Plan2.stopPersonGauche = 510;
                Plan2.stopPersonBas = 500;
                Plan2.stopPersonHaut = 220;

            }
            compteur = compteur % 200;

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            t++;
            if (t % 16 == 0) axWindowsMediaPlayer1.URL = "beepCar.mp3";

            label1.Text = (t / 3600).ToString(); label2.Text = ((t / 60) % 60).ToString(); label3.Text = (t % 60).ToString();
            if (t >= Plan2Auto.tempsDuSimulation * 60) { label1.Visible = !label1.Visible; label2.Visible = !label2.Visible; label3.Visible = !label3.Visible; }
            label4.Text = (((460 - Plan2.stopVoitureGauche) / 75)).ToString();
            label5.Text = (((Plan2.stopVoitureBas - 500) / 75)).ToString();
            
            label6.Text = (((Plan2.stopVoitureDroite - 830) / 75)).ToString();

            label8.Text = (((510 - Plan2.stopPersonGauche) / 30)).ToString();
            label9.Text = (((Plan2.stopPersonBas - 500) / 30)).ToString();
            label11.Text = (((220 - Plan2.stopPersonHaut) / 30)).ToString();
      

        }

       
        private void timer2_Tick(object sender, EventArgs e)
        {
            temps++;
            if (p2.qTempsVoitureDroite.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsVoitureDroite.Peek()) * 60 * 10))
                {
                    p2.tVoitureDroite[Plan2Auto.nbVoitureExisteDroite] = new VoiturePlan2Auto("droite");
                    Plan2Auto.nbVoitureExisteDroite++;
                    p2.qTempsVoitureDroite.Dequeue();
                }
            }
            if (p2.qTempsVoitureGauche.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsVoitureGauche.Peek()) * 60 * 10))
                {
                   p2. tVoitureGauche[Plan2Auto.nbVoitureExisteGauche] = new VoiturePlan2Auto("gauche");
                    Plan2Auto.nbVoitureExisteGauche++;
                    p2.qTempsVoitureGauche.Dequeue();
                }
            }
            if (p2.qTempsVoitureBas.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsVoitureBas.Peek()) * 60 * 10))
                {
                    p2.tVoitureBas[Plan2Auto.nbVoitureExisteBas] = new VoiturePlan2Auto("bas");
                    Plan2Auto.nbVoitureExisteBas++;
                    p2.qTempsVoitureBas.Dequeue();
                }
            }

            if (p2.qTempsPersonDroite.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsPersonDroite.Peek()) * 60 * 10))
                {
                    p2.tPersonDroite[Plan2Auto.nbPersonExisteDroite] = new PersonPlan2Auto("droite");
                    Plan2Auto.nbPersonExisteDroite++;
                    p2.qTempsPersonDroite.Dequeue();
                }
            }
            if (p2.qTempsPersonGauche.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsPersonGauche.Peek()) * 60 * 10))
                {
                    p2.tPersonGauche[Plan2Auto.nbPersonExisteGauche] = new PersonPlan2Auto("gauche");
                    Plan2Auto.nbPersonExisteGauche++;
                    p2.qTempsPersonGauche.Dequeue();
                }
            }
            if (p2.qTempsPersonBas.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsPersonBas.Peek()) * 60 * 10))
                {
                    p2.tPersonBas[Plan2Auto.nbPersonExisteBas] = new PersonPlan2Auto("bas");
                    Plan2Auto.nbPersonExisteBas++;
                    p2.qTempsPersonBas.Dequeue();
                }
            }
            if (p2.qTempsPersonHaut.Count != 0)
            {
                if (temps == (int)(((double)p2.qTempsPersonHaut.Peek()) * 60 * 10))
                {
                    p2.tPersonHaut[Plan2Auto.nbPersonExisteHaut] = new PersonPlan2Auto("haut");
                    Plan2Auto.nbPersonExisteHaut++;
                    p2.qTempsPersonHaut.Dequeue();
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


            for (int i = 0; i < Plan2Auto.nbPersonExisteHaut; i++)
            {
                if (p2.tPersonHaut[i]!=null)
                {
                    if (p2.tPersonHaut[i].existe == false)
                        p2.tPersonHaut[i] = null;
                    else p2.tPersonHaut[i].Bouger();
                }
               
            }

        }

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";
            Plan2.annulerVPCree();
            Plan2Auto.annulerVPExist();
            capable = false;
            compteur = 0;
            p2 = new Plan2Auto();
            t = 0;
            temps = 0;
            timer3.Interval = 50 * 10;
        }

        private void Form10_FormClosed(object sender, FormClosedEventArgs e)
        {
           Plan2. stopVoitureBas = 500;
            Plan2.stopVoitureGauche = 460;
            Plan2.stopVoitureDroite = 830;
            Plan2.stopPersonBas = 500;
            Plan2.stopPersonGauche = 510;
            Plan2.stopPersonHaut = 220;
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Auto.nbVoitureExisteDroite; i++)
            {
                if (p2.tVoitureDroite[i]!=null)
                {
                    if (p2.tVoitureDroite[i].existe == false)
                        p2.tVoitureDroite[i] = null;
                    else p2.tVoitureDroite[i].Bouger();
                }
               
            }

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Auto.nbVoitureExisteBas; i++)
            {
                if (p2.tVoitureBas[i] != null)
                {
                    if (p2.tVoitureBas[i].existe == false)
                        p2.tVoitureBas[i] = null;
                    else p2.tVoitureBas[i].Bouger();
                }
              
            }

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Auto.nbVoitureExisteGauche; i++)
            {
                if (p2.tVoitureGauche[i] != null)
                {
                    if (p2.tVoitureGauche[i].existe == false)
                        p2.tVoitureGauche[i] = null;
                    else p2.tVoitureGauche[i].Bouger();
                }
              
            }

        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Auto.nbPersonExisteDroite; i++)
            {
                if (p2.tPersonDroite[i] != null)
                {
                    if (p2.tPersonDroite[i].existe == false)
                        p2.tPersonDroite[i] = null;
                    else p2.tPersonDroite[i].Bouger();

                }
            
            }

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Auto.nbPersonExisteGauche; i++)
            {
                if (p2.tPersonGauche[i] != null)
                {
                    if (p2.tPersonGauche[i].existe == false)
                        p2.tPersonGauche[i] = null;
                    else p2.tPersonGauche[i].Bouger();

                }
            }

        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Auto.nbPersonExisteBas; i++)
            {
                if (p2.tPersonBas[i] != null)
                {
                    if (p2.tPersonBas[i].existe == false)
                        p2.tPersonBas[i] = null;
                    else p2.tPersonBas[i].Bouger();

                }
            }

        }
    }
}
