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
    public partial class Form12 : Form
    {
        int te;int s;
        int k,l;
        public static Plan3Auto p3;
        int t;//temps en second;
        int compteur = 0;
        int temps;// en decisecond
        public AmbulancePlan3Auto ambulanceBas, ambulanceGauche;
        bool ambBas, ambGauche;
        public Form12()
        {
            InitializeComponent();
        }
         private void timer2_Tick(object sender, EventArgs e)
        {
            temps++;
            if (p3.qTempsVoitureGauche.Count != 0)
            {
                if (temps == (int)(((double)p3.qTempsVoitureGauche.Peek()) * 60 * 10))
                {
                   p3. tVoitureGauche[Plan3Auto.nbVoitureExisteGauche] = new VoiturePlan3Auto("gauche");
                    Plan3Auto.nbVoitureExisteGauche++;
                    p3.qTempsVoitureGauche.Dequeue();
                }
            }
            if (p3.qTempsVoitureBas.Count != 0)
            {
                if (temps == (int)(((double)p3.qTempsVoitureBas.Peek()) * 60 * 10))
                {
                    p3.tVoitureBas[Plan3Auto.nbVoitureExisteBas] = new VoiturePlan3Auto("bas");

                    Plan3Auto.nbVoitureExisteBas++;
                    p3.qTempsVoitureBas.Dequeue();
                }
            }

            if (p3.qTempsPersonGauche.Count != 0)
            {
                if (temps == (int)(((double)p3.qTempsPersonGauche.Peek()) * 60 * 10))
                {
                   p3. tPersonGauche[Plan3Auto.nbPersonExisteGauche] = new PersonPlan3Auto("gauche");
                    Plan3Auto.nbPersonExisteGauche++;
                    p3.qTempsPersonGauche.Dequeue();
                }
            }
            if (p3.qTempsPersonHaut.Count != 0)
            {
                if (temps == (int)(((double)p3.qTempsPersonHaut.Peek()) * 60 * 10))
                {
                    p3.tPersonHaut[Plan3Auto.nbPersonExisteHaut] = new PersonPlan3Auto("haut");

                    Plan3Auto.nbPersonExisteHaut++;
                    p3.qTempsPersonHaut.Dequeue();
                }
            }
        }
     

        private void timer3_Tick(object sender, EventArgs e) {
           
            compteur = (compteur + 1);
            if (compteur == 1) { Plan3.capableDeQuiteN = true;pictureBox1.Image = new Bitmap("feuxPersonOn.png"); }
            if (compteur % 100 == 40) { p3.fp3.inverseFeuxZ(); Plan3.capableVoitureZ = true; }
            if (compteur % 100 == 41) { Plan3.capableVoitureZ = false; Plan3.capableDeQuiteN = false; pictureBox1.Image = new Bitmap("feuxPersonOff.png"); }
            if (compteur % 100 == 50) { p3.fp3.inverseFeuxN(); p3.fp3.inverseFeuxZ();Plan3.capableDeQuiteZ = true; pictureBox4.Image = new Bitmap("feuxPersonOn.png"); }
            if (compteur % 100 == 90) { p3.fp3.inverseFeuxN(); Plan3.capableVoitureN = true; }
            if (compteur % 100 ==91) { Plan3.capableDeQuiteZ = false; Plan3.capableVoitureN = false; pictureBox4.Image = new Bitmap("feuxPersonOff.png"); }
            if (compteur % 100 == 0) { p3.fp3.inverseFeuxN(); p3.fp3.inverseFeuxZ(); }
            if (Plan3.capableDeQuiteZ == true)
            {
                
              Plan3.  stopPersonHaut = 303;
            }
            if (Plan3.capableDeQuiteN == true)
            {
               Plan3. stopPersonGauche = 624;
              
            }

            if ((ambBas == true) && (p3.fp3.feuBas.couleur != "vert"))
            {
                if (k == 0)
                { timer3.Interval =50;  }
                k++;
            }
            else if (ambBas == true) { timer3.Interval = 50 * 10; ambBas = false; }

            if ((ambGauche == true) && (p3.fp3.feuGauche.couleur != "vert")) {
                if (l == 0)
                { timer3.Interval =50; }
                    l++;
            }
            else if (ambGauche == true) { timer3.Interval = 50 * 10; ambGauche = false; }
            compteur = compteur % 100;
           
        }
        

         private void timer4_Tick(object sender, EventArgs e)
        {
            t++;
            if (t % 20 == 0) axWindowsMediaPlayer1.URL = "beepCar.mp3";
            label1.Text = (t / 3600).ToString(); label2.Text = ((t / 60) % 60).ToString(); label3.Text = (t % 60).ToString();
            if (t >= Plan3Auto.tempsDuSimulation * 60) { label1.Visible = !label1.Visible; label2.Visible = !label2.Visible; label3.Visible = !label3.Visible; }
            label4.Text = (((560 - Plan3.stopVoitureGauche) / 75)).ToString();
            label5.Text = (((Plan3.stopVoitureBas - 500) / 75)).ToString();

            label8.Text = (((624 - Plan3.stopPersonGauche) / 30)).ToString();
            label11.Text = (((303 - Plan3.stopPersonHaut) / 30)).ToString();
        }
 

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                if (ambulanceGauche != null)
                {
                if (ambulanceGauche.existe == false)
                {
                    timer1.Enabled = false; timer12.Enabled = false; 
                    ambulanceGauche = null;
                }
                else { ambulanceGauche.Bouger(); ambulanceGauche.Bouger(); }
                }
              
             
   

        }

        private void Form12_Load(object sender, EventArgs e) {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";
            Plan3.annulerVPCree();
            Plan3Auto.annulerVPExist();
            s = 2;
            p3 = new Plan3Auto();
            t = 0;
            temps = 0;
            timer3.Interval = 50 * 10;ambBas = false;ambGauche = false;
          
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            te++;
            if (te ==30)
            {
                button2.Enabled = true; button1.Enabled = true;timer5.Enabled = false;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
             
            for (int i = 0; i < Plan3Auto.nbVoitureExisteGauche; i++)
            {
                if (p3.tVoitureGauche[i] != null)
                {
                    if (p3.tVoitureGauche[i].existe == false)
                        p3.tVoitureGauche[i] = null;
                    else p3.tVoitureGauche[i].Bouger();

                }
            }

        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan3Auto.nbVoitureExisteBas; i++)
            {
                if (p3.tVoitureBas[i] != null)
                {
                    if (p3.tVoitureBas[i].existe == false)
                        p3.tVoitureBas[i] = null;
                    else p3.tVoitureBas[i].Bouger();

                }
            }

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
     
            for (int i = 0; i < Plan3Auto.nbPersonExisteGauche; i++)
            {
                if (p3.tPersonGauche[i] != null)
                {
                    if (p3.tPersonGauche[i].existe == false)
                        p3.tPersonGauche[i] = null;
                    else p3.tPersonGauche[i].Bouger();

                }
            }

        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan3Auto.nbPersonExisteHaut; i++)
            {
                if (p3.tPersonHaut[i] != null)
                {
                    if (p3.tPersonHaut[i].existe == false)
                        p3.tPersonHaut[i] = null;
                    else p3.tPersonHaut[i].Bouger();


                }
            }

        }

 

        private void timer8_Tick_1(object sender, EventArgs e)
        {
            
                if (ambulanceBas != null)
                {
                if (ambulanceBas.existe == false)
                {
                    ambulanceBas = null; timer8.Enabled = false; timer11.Enabled = false;

                }
                else { ambulanceBas.Bouger(); ambulanceBas.Bouger(); }
                }
          
          
        
        }

        private void timer11_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < Plan3Auto.nbVoitureExisteBas; i++)
            {
                if (p3.tVoitureBas[i] != null)
                {
                    if (p3.tVoitureBas[i].x != 742)
                    if ( (Math.Abs (ambulanceBas.y - p3.tVoitureBas[i].y) < 110) && (p3.tVoitureBas[i].x < 742))
                        p3.tVoitureBas[i].x = 742;

                }
            }

            for (int i = 0; i < Plan3Auto.nbVoitureExisteGauche; i++)
            {
                if (p3.tVoitureGauche[i] != null)
                {
                    if ((p3.tVoitureGauche[i].y < 390)&& (p3.tVoitureGauche[i].x != 742))
                    {
                        if ((Math.Abs(ambulanceBas.y - p3.tVoitureGauche[i].y) < 110))
                            p3.tVoitureGauche[i].x = 742;
                    }
                  
                }

            }



    }

        private void timer12_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < Plan3Auto.nbVoitureExisteGauche; i++)
            {
                if (p3.tVoitureGauche[i] != null)
                {
                    if (p3.tVoitureGauche[i].y != 370)
                        if ((Math.Abs(ambulanceGauche.x - p3.tVoitureGauche[i].x) < 110) && (p3.tVoitureGauche[i].y > 370))
                            p3.tVoitureGauche[i].y = 370;
                }
            }

            for (int i = 0; i < Plan3Auto.nbVoitureExisteBas; i++)
            {
                if (p3.tVoitureBas[i] != null)
                {
                    if ((p3.tVoitureBas[i].x > 772)&& (p3.tVoitureBas[i].y != 370))
                        if ((Math.Abs(ambulanceGauche.x - p3.tVoitureBas[i].x) < 110))

                            p3.tVoitureBas[i].y = 370;

                }
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "urgence.mp3";
            l = 0; te = 0; button1.Enabled = false; button2.Enabled = false;
            timer5.Enabled = true; timer1.Enabled = true;timer12.Enabled = true;
            ambulanceGauche = new AmbulancePlan3Auto("gauche"); ambGauche = true;
       
        }

        private void Form12_FormClosed(object sender, FormClosedEventArgs e)
        {
          Plan3.  stopVoitureBas = 500;Plan3.stopAmbulanceGauche = 560;Plan3.stopAmbulanceBas = 500;
            Plan3.stopVoitureGauche = 560;
            Plan3.stopPersonGauche = 624;
            Plan3.stopPersonHaut = 303;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "urgence.mp3";
            k = 0;te = 0;button1.Enabled = false;button2.Enabled = false;
           timer5.Enabled = true; timer8.Enabled = true; timer11.Enabled = true;

            ambulanceBas = new AmbulancePlan3Auto("bas");ambBas = true;

        }
    }
    }
