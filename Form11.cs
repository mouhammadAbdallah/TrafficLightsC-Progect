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
    public partial class Form11 : Form
    {
        public static Plan2Manuel p2;
        int t;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";

            Plan2.annulerVPCree();
            p2 = new Plan2Manuel();
            label10.Text = Voiture.dv.ToString();
            label7.Text = Person.dp.ToString();
            t = 0;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan2Manuel.nbVoitureCree; i++)
            {
                Plan2Manuel.tV[i].Bouger();
            }
            for (int i = 0; i < Plan2Manuel.nbPersonCree; i++)
            {
                Plan2Manuel.tP[i].Bouger();
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            t++;
            label5.Text = (t / 3600).ToString();
            label4.Text = ((t / 60) % 60).ToString();
            label3.Text = (t % 60).ToString();
            label13.Text = (((460 - Plan2.stopVoitureGauche) / 75)).ToString();
            label12.Text = (((Plan2.stopVoitureBas - 500) / 75)).ToString();
            label6.Text = (((Plan2.stopVoitureDroite - 830) / 75)).ToString();

            label8.Text = (((510 - Plan2.stopPersonGauche) / 30)).ToString();
            label9.Text = (((Plan2.stopPersonBas - 500) / 30)).ToString();
            label11.Text = (((220 - Plan2.stopPersonHaut) / 30)).ToString();
        }


        private void button6_Click(object sender, EventArgs e)
        { Voiture.dv++;
            label10.Text = Voiture.dv.ToString();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Voiture.dv != 1)
                Voiture.dv--;
            label10.Text = Voiture.dv.ToString();
        }
  

        private void button13_Click(object sender, EventArgs e)
        {
            Person.dp++;
            label7.Text = Person.dp.ToString();
        }
 

        private void button12_Click(object sender, EventArgs e)
        {
            if (Person.dp != 1) Person.dp--;
            label7.Text = Person.dp.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p2.fp2.inverseFeuxZ();
            if ((p2.fp2.feuBas.couleur == "rouge") && (p2.fp2.feuGauche.couleur == "rouge"))
            {
                feuxPlan2.feuPersonInverse(false);
                Plan2.capableDeQuite = true;
                Plan2.stopPersonGauche = 510;
                Plan2.stopPersonBas = 500;
                Plan2.stopPersonHaut = 220;
            }
            else { Plan2.capableDeQuite = false; pictureBox1.Tag = "rouge";
                pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                pictureBox4.Image = new Bitmap("feuxPersonOff.png");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            VoiturePlan2Manuel c = new VoiturePlan2Manuel("gauche");
            Plan2Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }
  

        private void button9_Click(object sender, EventArgs e)
        {
            PersonPlan2Manuel p = new PersonPlan2Manuel("gauche");
            Plan2Manuel.plusPerson(p);
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            VoiturePlan2Manuel c = new VoiturePlan2Manuel("droite");
            Plan2Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }
   

        private void button10_Click(object sender, EventArgs e)
        {
            PersonPlan2Manuel p = new PersonPlan2Manuel("bas");
            Plan2Manuel.plusPerson(p);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            VoiturePlan2Manuel c = new VoiturePlan2Manuel("bas");
            Plan2Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }


        private void button14_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled; timer2.Enabled = !timer2.Enabled;
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
                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                    sw.WriteLine(textBox1.Text);
                    sw.Close();
                }
            }
            textBox1.Text = "";
        }
    

        private void button11_Click(object sender, EventArgs e)
        {
            PersonPlan2Manuel p = new PersonPlan2Manuel("haut");
            Plan2Manuel.plusPerson(p);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PersonPlan2Manuel p = new PersonPlan2Manuel("droite");
            Plan2Manuel.plusPerson(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p2.fp2.inverseFeuxN();
            if ((p2.fp2.feuBas.couleur == "rouge") && (p2.fp2.feuGauche.couleur == "rouge"))
            {
                feuxPlan2.feuPersonInverse(false);
                Plan2.capableDeQuite = true;
                Plan2.stopPersonGauche = 510;
                Plan2.stopPersonBas = 500;
                Plan2.stopPersonHaut = 220;
            }
            else { Plan2.capableDeQuite = false;
                pictureBox1.Tag = "rouge";
                pictureBox1.Image = new Bitmap("feuxPersonOff.png");
                pictureBox2.Image = new Bitmap("feuxPersonOff.png");
                pictureBox4.Image = new Bitmap("feuxPersonOff.png");
            }
        }

        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan2.stopVoitureBas = 500;
            Plan2.stopVoitureGauche = 460;
            Plan2.stopVoitureDroite = 830;
            Plan2.stopPersonBas = 500;
            Plan2.stopPersonGauche = 510;
            Plan2.stopPersonHaut = 220;
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            if (button14.Tag.ToString() == "stop")
                button14.BackgroundImage = new Bitmap("stopon.png");
            else button14.BackgroundImage = new Bitmap("playon.png");

        }
    }
}
