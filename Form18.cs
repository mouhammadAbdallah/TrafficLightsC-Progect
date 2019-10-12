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
    
    public partial class Form18 : Form
    {
        
        public static Plan5Auto p5;
        int t;//temps en second;
        int compteur = 0;
        int temps;// en decisecond
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";

            Plan5.annulerVPCree();
            //pictureBox1.SendToBack();

            Plan5Auto.annulerVPExist();
            
            p5 = new Plan5Auto();
            t = 0;
            temps = 0;
            timer3.Interval = 50 * 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan5Auto.nbVoitureExisteDroite; i++)
            {
                p5.tVoitureDroite[i].Bouger();
            }
          


        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            compteur = (compteur + 1);
            if (compteur == 1) { }
            if (compteur % 100 == 40) { p5.fp5.inverseFeuxNos(); Plan5.capableNos = true; }
            if (compteur % 100 == 42) { Plan5.capableNos = false; }
            if (compteur % 100 == 50) { p5.fp5.inverseFeuxZawya(); p5.fp5.inverseFeuxNos(); }
            if (compteur % 100 == 90) { p5.fp5.inverseFeuxZawya(); Plan5.capableZawya = true; }
            if (compteur % 100 == 92) { Plan5.capableZawya = false; }
            if (compteur % 100 == 0) { p5.fp5.inverseFeuxNos(); p5.fp5.inverseFeuxZawya(); }
            if (Plan5.capableZawya == true)
            {
                Plan5.stopVoitureBasBas = 610;
                Plan5.stopVoitureDroiteDroite = 1075;
                Plan5.stopVoitureHautHaut = 60;
                Plan5.stopVoitureGaucheGauche = 220;
            }
            if (Plan5.capableNos == true)
            {
                Plan5.stopVoitureBasGauche = 900;
                Plan5.stopVoitureDroiteBas = 240;
                Plan5.stopVoitureHautDroite = 400;
                Plan5.stopVoitureGaucheHaut = 425;
            }
            compteur = compteur % 100;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            temps++;
            if (p5.qTempsVoitureBas.Count != 0)
            {
                if (temps == (int)(((double)p5.qTempsVoitureBas.Peek()) * 60 * 10))
                {
                    p5.tVoitureBas[Plan5Auto.nbVoitureExisteBas] = new VoiturePlan5Auto("bas");
                    Plan5Auto.nbVoitureExisteBas++;
                    p5.qTempsVoitureBas.Dequeue();
                }
            }
            if (p5.qTempsVoitureGauche.Count != 0)
            {
                if (temps == (int)(((double)p5.qTempsVoitureGauche.Peek()) * 60 * 10))
                {
                    p5.tVoitureGauche[Plan5Auto.nbVoitureExisteGauche] = new VoiturePlan5Auto("gauche");
                    Plan5Auto.nbVoitureExisteGauche++;
                    p5.qTempsVoitureGauche.Dequeue();
                }
            }
            if (p5.qTempsVoitureHaut.Count != 0)
            {
                if (temps == (int)(((double)p5.qTempsVoitureHaut.Peek()) * 60 * 10))
                {
                    p5. tVoitureHaut[Plan5Auto.nbVoitureExisteHaut] = new VoiturePlan5Auto("haut");

                    Plan5Auto.nbVoitureExisteHaut++;
                    p5.qTempsVoitureHaut.Dequeue();
                }
            }

            if (p5.qTempsVoitureDroite.Count != 0)
            {
                if (temps == (int)(((double)p5.qTempsVoitureDroite.Peek()) * 60 * 10))
                {
                    p5.tVoitureDroite[Plan5Auto.nbVoitureExisteDroite] = new VoiturePlan5Auto("droite");
                    Plan5Auto.nbVoitureExisteDroite++;
                    p5.qTempsVoitureDroite.Dequeue();
                }
            }

          
           
           
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            t++;
           if (t % 20 == 0) axWindowsMediaPlayer1.URL = "beepCar.mp3";

            label7.Text = (t / 3600).ToString(); label6.Text = ((t / 60) % 60).ToString(); label3.Text = (t % 60).ToString();
            if (t >= Plan5Auto.tempsDuSimulation * 60) { label7.Visible = !label7.Visible; label6.Visible = !label6.Visible; label3.Visible = !label3.Visible; }
        }

        private void Form18_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan5.stopVoitureBasBas = 610;
            Plan5.stopVoitureDroiteBas = 240;
            Plan5.stopVoitureHautDroite = 400;
            Plan5.stopVoitureBasGauche = 900;
            Plan5.stopVoitureGaucheGauche = 220;
            Plan5.stopVoitureGaucheHaut = 425;
            Plan5.stopVoitureHautHaut = 60;
            Plan5.stopVoitureDroiteDroite = 1075;
        }



        private void timer5_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan5Auto.nbVoitureExisteBas; i++)
            {
                if (p5.tVoitureBas[i] != null)
                {
                    if (p5.tVoitureBas[i].existe == false)
                        p5.tVoitureBas[i] = null;
                    else p5.tVoitureBas[i].Bouger();

                }
            }

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan5Auto.nbVoitureExisteHaut; i++)
            {
                if (p5.tVoitureHaut[i] != null)
                {
                    if (p5.tVoitureHaut[i].existe == false)
                        p5.tVoitureHaut[i] = null;
                    else p5.tVoitureHaut[i].Bouger();

                }
            }

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan5Auto.nbVoitureExisteGauche; i++)
            {if (p5.tVoitureGauche[i] != null)
                {
                    if (p5.tVoitureGauche[i].existe == false)
                        p5.tVoitureGauche[i] = null;
                    else p5.tVoitureGauche[i].Bouger();

                }
            }
          
        }
       

    }
}
