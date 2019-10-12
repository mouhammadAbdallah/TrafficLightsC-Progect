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
    public partial class Form15 : Form
    {
        public static Plan4Manuel p4;
        int t;
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";

            Plan4.annulerVPCree();
            label9.Text = Voiture.dv.ToString();
            label6.Text = Person.dp.ToString();
            p4 = new Plan4Manuel();
            t = 0;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan4Manuel.nbVoitureCree; i++)
            {
                Plan4Manuel.tV[i].Bouger();
            }
            for (int i = 0; i < Plan4Manuel.nbPersonCree; i++)
            {
                Plan4Manuel.tP[i].Bouger();
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            t++;
            label1.Text = (t / 3600).ToString();
            label2.Text = ((t / 60) % 60).ToString();
            label3.Text = (t % 60).ToString();


            label7.Text = (((Plan4.stopVoitureBasDroite - 500) / 75)).ToString();
            label14.Text = (((Plan4.stopVoitureBasGauche - 500) / 75)).ToString();
            label10.Text = (((460 - Plan4.stopVoitureGaucheHaut) / 75)).ToString();
            label13.Text = (((460 - Plan4.stopVoitureGaucheBas) / 75)).ToString();

            label8.Text = (((510 - Plan4.stopPersonGauche) / 30)).ToString();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Voiture.dv++;
            label6.Text = Voiture.dv.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Voiture.dv != 1)
                Voiture.dv--;
            label6.Text = Voiture.dv.ToString();

        }


        private void button13_Click(object sender, EventArgs e)
        {
            Person.dp++;
            label9.Text = Person.dp.ToString();

        }


        private void button12_Click(object sender, EventArgs e)
        {
            if (Person.dp != 1) Person.dp--;
            label9.Text = Person.dp.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            p4.fp4.inverseFeuxN();
            if (Form15.p4.fp4.feuBas.couleur == "rouge") { pictureBox4.Image = new Bitmap("feuxPersonOn.png"); Plan4.stopPersonGauche = 510; }
            else pictureBox4.Image = new Bitmap("feuxPersonOff.png");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            VoiturePlan4Manuel c = new VoiturePlan4Manuel("gaucheBas");
            Plan4Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }


        private void button9_Click(object sender, EventArgs e)
        {
            PersonPlan4Manuel p = new PersonPlan4Manuel("gauche");
            Plan4Manuel.plusPerson(p);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            VoiturePlan4Manuel c = new VoiturePlan4Manuel("basDroite");
            Plan4Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
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
            PersonPlan4Manuel p = new PersonPlan4Manuel("haut");
            Plan4Manuel.plusPerson(p);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PersonPlan4Manuel p = new PersonPlan4Manuel("droite");
            Plan4Manuel.plusPerson(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoiturePlan4Manuel c = new VoiturePlan4Manuel("basGauche");
            Plan4Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VoiturePlan4Manuel c = new VoiturePlan4Manuel("gaucheHaut");
            Plan4Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void Form15_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan4.stopVoitureBasGauche = 500; Plan4.stopVoitureBasDroite = 500;
            Plan4.stopVoitureGaucheBas = 460; Plan4.stopVoitureGaucheHaut = 460;
            Plan4.stopPersonGauche = 510;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            p4.fp4.inverseFeuxZ();
            //if (Form15.p4.fp4.feuBas.couleur == "rouge") pictureBox4.Image = new Bitmap("vert feux.png");
            //else pictureBox4.Image = new Bitmap("rouge feux.png");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
