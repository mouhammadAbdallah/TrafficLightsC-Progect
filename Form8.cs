using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Traffic_signs
{
    public partial class Form8 : Form
    {
       public static Plan1Manuel p1;
        int t;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";

            Plan1.annulerVPCree();
            p1 = new Plan1Manuel();
            t = 0;        
        }

        private void button1_Click(object sender, EventArgs e)// cree car de gauche
        {
            VoiturePlan1Manuel c = new VoiturePlan1Manuel("droite");
           Plan1Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoiturePlan1Manuel c = new VoiturePlan1Manuel("haut");
           Plan1Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VoiturePlan1Manuel c = new VoiturePlan1Manuel("bas");
           Plan1Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VoiturePlan1Manuel c = new VoiturePlan1Manuel("gauche");
           Plan1Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <Plan1Manuel.nbVoitureCree; i++)
            {
              Plan1Manuel.tV[i].Bouger();
            }
            for (int i = 0; i < Plan1Manuel.nbPersonCree; i++)
            {
                Plan1Manuel.tP[i].Bouger();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            p1.fp1.inverseFeuxZ();
            if ((p1.fp1.feuBas.couleur == "rouge") && (p1.fp1.feuGauche.couleur == "rouge"))
            {
                feuxPlan1.feuPersonInverse(false);
                Plan1.capableDeQuite = true;
                Plan1.stopPersonGauche = 510;
                Plan1.stopPersonDroite = 830;
                Plan1.stopPersonBas = 500;
                Plan1.stopPersonHaut = 220;

            }
            else { Plan1.capableDeQuite = false;pictureBox1.Tag = "rouge";
                   pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                   pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                   pictureBox4.Image = new Bitmap("feuxPersonOff.png");
                   pictureBox3.Image = new Bitmap("feuxPersonOff.png");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Voiture.dv++;
        }

        private void button7_Click(object sender, EventArgs e)
        {if(Voiture.dv!=1)
                Voiture.dv--;
        }

        private void button8_Click(object sender, EventArgs e)
        {
           PersonPlan1Manuel p = new PersonPlan1Manuel("droite");
            Plan1Manuel.plusPerson(p);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PersonPlan1Manuel p = new PersonPlan1Manuel("gauche");
            Plan1Manuel.plusPerson(p);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PersonPlan1Manuel p = new PersonPlan1Manuel("bas");
            Plan1Manuel.plusPerson(p);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PersonPlan1Manuel p = new PersonPlan1Manuel("haut");
            Plan1Manuel.plusPerson(p);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Person.dp++;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Person.dp != 1) Person.dp--;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            t++;
            label5.Text = (t / 3600).ToString();
            label4.Text = ((t / 60) % 60).ToString();
            label3.Text = (t % 60).ToString();
            label13.Text = (((460 - Plan1.stopVoitureGauche) / 75)).ToString();
            label12.Text = (((Plan1.stopVoitureBas - 500) / 75)).ToString();
            label7.Text = (((170 - Plan1.stopVoitureHaut) / 75)).ToString();
            label6.Text = (((Plan1.stopVoitureDroite - 830) / 75)).ToString();

            label8.Text = (((510 - Plan1.stopPersonGauche) / 30)).ToString();
            label9.Text = (((Plan1.stopPersonBas - 500) / 30)).ToString();
            label11.Text = (((220 - Plan1.stopPersonHaut) / 30)).ToString();
            label10.Text = (((Plan1.stopPersonDroite - 830) / 30)).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            timer1.Enabled =!timer1.Enabled;timer2.Enabled = !timer2.Enabled;
            if (button14.Tag.ToString() == "stop")
            {
                button14.BackgroundImage = new Bitmap("playoff.png");
                button14.Tag = "play";
            }
            else
            {
                button14.BackgroundImage = new Bitmap("stopoff.png");
                button14.Tag = "stop";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0)
            {
                if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                {
                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                    sw.WriteLine(textBox1.Text);
                    sw.Close();
                }
                else//history n existe alors cree; 
                {
                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() +  ".txt");
                    sw.WriteLine(textBox1.Text);
                    sw.Close();
                }
            }
            textBox1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            p1.fp1.inverseFeuxN();
            if ((p1.fp1.feuBas.couleur == "rouge") && (p1.fp1.feuGauche.couleur == "rouge"))
            {
                Plan1.capableDeQuite = true;
                feuxPlan1.feuPersonInverse(false);
               
                    Plan1.stopPersonGauche = 510;
                    Plan1.stopPersonDroite = 830;
                    Plan1.stopPersonBas = 500;
                    Plan1.stopPersonHaut = 220;
            }

            else { Plan1.capableDeQuite = false;pictureBox1.Tag = "rouge";
                pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                pictureBox2.Image = new Bitmap("feuxPersonOff.png");
               pictureBox4.Image = new Bitmap("feuxPersonOff.png");
                pictureBox3.Image = new Bitmap("feuxPersonOff.png");
            }

        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan1.stopVoitureBas = 500;
            Plan1.stopVoitureGauche = 460;
            Plan1.stopVoitureHaut = 170;
            Plan1.stopVoitureDroite = 830;
            Plan1.stopPersonBas = 500;
            Plan1.stopPersonGauche = 510;
            Plan1.stopPersonHaut = 220;
            Plan1.stopPersonDroite = 830;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            if (button14.Tag.ToString() == "stop")
                button14.BackgroundImage = new Bitmap("stopon.png");
            else button14.BackgroundImage = new Bitmap("playon.png");
        }
    }
}
