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
    public partial class Form13 : Form
    {
        public static Plan3Manuel p3;
        int t;
        public Form13()
        {
            InitializeComponent();
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun1.mp3";

            label4.Text = Person.dp.ToString();
            label5.Text = Voiture.dv.ToString();
            Plan3.annulerVPCree();
            p3 = new Plan3Manuel();
            t = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PersonPlan3Manuel p = new PersonPlan3Manuel("haut");
            Plan3Manuel.plusPerson(p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VoiturePlan3Manuel c = new VoiturePlan3Manuel("gauche");
            Plan3Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PersonPlan3Manuel p = new PersonPlan3Manuel("gauche");
            Plan3Manuel.plusPerson(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VoiturePlan3Manuel c = new VoiturePlan3Manuel("bas");
            Plan3Manuel.plusVoiture(c); axWindowsMediaPlayer1.URL = "beepCar.mp3";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Plan3Manuel.nbVoitureCree; i++)
            {
                Plan3Manuel.tV[i].Bouger();
            }
            for (int i = 0; i < Plan3Manuel.nbPersonCree; i++)
            {
                Plan3Manuel.tP[i].Bouger();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            t++;
            label7.Text = (t / 3600).ToString();
            label6.Text = ((t / 60) % 60).ToString();
            label3.Text = (t % 60).ToString();
            label13.Text = (((560 - Plan3.stopVoitureGauche) / 75)).ToString();
            label12.Text = (((Plan3.stopVoitureBas - 500) / 75)).ToString();

            label8.Text = (((624 - Plan3.stopPersonGauche) / 30)).ToString();
            label11.Text = (((303 - Plan3.stopPersonHaut) / 30)).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Voiture.dv != 1)
                Voiture.dv--;
            label5.Text = Voiture.dv.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Voiture.dv++;
            label5.Text = Voiture.dv.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Person.dp != 1) { Person.dp--; label4.Text = (int.Parse(label4.Text) - 1).ToString(); }
            }

        private void button13_Click(object sender, EventArgs e)
        {
             Person.dp++;
            label4.Text = (int.Parse(label4.Text) + 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p3.fp3.inverseFeuxZ();
            if (Form13.p3.fp3.feuBas.couleur == "rouge") pictureBox4.Image = new Bitmap("feuxPersonOn.png");
            else pictureBox4.Image = new Bitmap("feuxPersonOff.png");
            if (Form13.p3.fp3.feuGauche.couleur == "rouge") pictureBox1.Image = new Bitmap("feuxPersonOn.png");
            else pictureBox1.Image = new Bitmap("feuxPersonOff.png");
        }

        private void Form13_FormClosed(object sender, FormClosedEventArgs e)
        {
            Plan3.stopVoitureBas = 500;
            Plan3.stopVoitureGauche = 560;
            Plan3.stopPersonGauche = 624;
            Plan3.stopPersonHaut = 303;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p3.fp3.inverseFeuxN();
            if (Form13.p3.fp3.feuBas.couleur == "rouge") { pictureBox4.Image = new Bitmap("feuxPersonOn.png"); Plan3.stopPersonGauche = 624; }
            else pictureBox4.Image = new Bitmap("feuxPersonOff.png");
            if (Form13.p3.fp3.feuGauche.couleur == "rouge") { pictureBox1.Image = new Bitmap("feuxPersonOn.png"); Plan3.stopPersonHaut = 303; }
            else pictureBox1.Image = new Bitmap("feuxPersonOff.png");
  
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            if (button14.Tag.ToString() == "stop")
                button14.BackgroundImage = new Bitmap("stopon.png");
            else button14.BackgroundImage = new Bitmap("playon.png");

        }
    }
}
