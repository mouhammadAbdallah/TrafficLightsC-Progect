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
    public partial class Form6 : Form
    {
        public static Form5 f5;//contient plan
        public static Form8 f8;//meme plan mais manuel;
        public static Form10 f10;//contient plan
        public static Form11 f11;//meme plan mais manuel;
        public static Form12 f12;//contient plan
        public static Form13 f13;//meme plan mais manuel;
        public static Form14 f14;//contient plan
        public static Form15 f15;//meme plan mais manuel;
        public static Form18 f18;//meme plan mais manuel;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label15.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)//Go
        {
            
            switch (this.Tag.ToString())
            {

                case "4route":
                    {

                        if (radioButton1.Checked == true)
                        {

                            f5 = new Form5();
                            try
                            {
                                Plan1Auto.moyenVoitureBas = int.Parse(textBox3.Text.Trim()); Plan1Auto.moyenVoitureGauche = int.Parse(textBox1.Text); Plan1Auto.moyenVoitureDroite = int.Parse(textBox2.Text); Plan1Auto.moyenVoitureHaut = int.Parse(textBox4.Text);
                                Plan1Auto.moyenPersonBas = int.Parse(textBox7.Text); Plan1Auto.moyenPersonGauche = int.Parse(textBox5.Text); Plan1Auto.moyenPersonDroite = int.Parse(textBox6.Text); Plan1Auto.moyenPersonHaut = int.Parse(textBox8.Text);
                                Person.dp = int.Parse(textBox9.Text); Voiture.dv = int.Parse(textBox10.Text);
                                Plan1Auto.tempsDuSimulation = double.Parse(textBox13.Text);
                               
                                f5.Show();//montrer le simulation 0 de plan a 4 route a 2 fleche
                                if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                                {
                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                    sw.WriteLine("and you choose:\nnumber of person down:" + textBox7.Text + "\nnumber of person left: " + textBox5.Text + "\nnumber of person right: " + textBox6.Text + "\n number of person up: " + textBox8.Text +
                                       "\nnumber of car down: " + textBox3.Text + "\nnumber of car left: " + textBox1.Text + "\nnumber of car right: " + textBox2.Text + "\nnumber of car up:" +
                                    textBox4.Text + ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }
                                else//history n existe alors cree; 
                                {
                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                    sw.WriteLine("and you choose:\nnumber of person down:" + textBox7.Text + ";\nnumber of person left: " + textBox5.Text + ";\nnumber of person right: " + textBox6.Text + ";\n number of person up: " + textBox8.Text +
                                     ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text + ";\nnumber of car right: " + textBox2.Text + ";\nnumber of car up:" +
                                  textBox4.Text + ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }

                            }
                            catch
                            {
                                label15.Visible = true;
                                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                                f5.Close();
                            }
                        }
                        else
                        {
                            Person.dp = int.Parse(textBox9.Text);
                            Voiture.dv = int.Parse(textBox10.Text);
                            if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                sw.WriteLine("and you choose:Manuel:\n");
                                sw.Close();
                            }
                            else//history n existe alors cree; 
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                sw.WriteLine("and you choose:Manuel:\n");
                                sw.Close();
                            }
                            f8 = new Form8();
                            f8.Show();
                        }
                        break;
                    }
                case "3route":


                    {


                        if (radioButton1.Checked == true)
                        {

                            f10 = new Form10();
                            try
                            {
                                Plan2Auto.moyenVoitureBas = int.Parse(textBox3.Text.Trim()); Plan2Auto.moyenVoitureGauche = int.Parse(textBox1.Text); Plan2Auto.moyenVoitureDroite = int.Parse(textBox2.Text);
                                Plan2Auto.moyenPersonBas = int.Parse(textBox7.Text); Plan2Auto.moyenPersonGauche = int.Parse(textBox5.Text); Plan2Auto.moyenPersonDroite = int.Parse(textBox6.Text); Plan2Auto.moyenPersonHaut = int.Parse(textBox8.Text);
                                Person.dp = int.Parse(textBox9.Text); Voiture.dv = int.Parse(textBox10.Text);
                                Plan2Auto.tempsDuSimulation = double.Parse(textBox13.Text);

                                

                                f10.Show();//montrer le simulation 1 de plan a 3 route a 2 fleche
                                if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                                {
                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                    sw.WriteLine("and you choose:\nnumber of person down:" + textBox7.Text + ";\nnumber of person left: " + textBox5.Text + ";\nnumber of person right: " + textBox6.Text +
                                       ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text + ";\nnumber of car right: " + textBox2.Text +
                                   ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }
                                else//history n existe alors cree; 
                                {
                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                    sw.WriteLine("and you choose:\nnumber of person down:" + textBox7.Text + ";\nnumber of person left: " + textBox5.Text + ";\nnumber of person right: " + textBox6.Text +
                                       ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text + ";\nnumber of car right: " + textBox2.Text +
                                   ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();

                                }

                            }
                            catch
                            {
                                label15.Visible = true;
                                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                                f10.Close();
                            }
                        }
                        else
                        {
                            Person.dp = int.Parse(textBox9.Text);
                            Voiture.dv = int.Parse(textBox10.Text);
                            if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                sw.WriteLine("and you choose:Manuel:");
                                sw.Close();
                            }
                            else//history n existe alors cree; 
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                sw.WriteLine("and you choose:Manuel:");
                                sw.Close();
                            }
                            f11 = new Form11();
                            f11.Show();
                        }
                        break;
                    }

                case "41route":
                    {

                        if (radioButton1.Checked == true)
                        {

                            f12 = new Form12();
                            try
                            {
                                Plan3Auto.moyenVoitureBas = int.Parse(textBox3.Text.Trim()); Plan3Auto.moyenVoitureGauche = int.Parse(textBox1.Text);
                                Plan3Auto.moyenPersonGauche = int.Parse(textBox5.Text); Plan3Auto.moyenPersonHaut = int.Parse(textBox8.Text);
                                Person.dp = int.Parse(textBox9.Text); Voiture.dv = int.Parse(textBox10.Text);
                                Plan3Auto.tempsDuSimulation = double.Parse(textBox13.Text);

                            

                                f12.Show();//montrer le simulation 1 de plan a 3 route a 2 fleche
                                if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                                {
                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                    sw.WriteLine("and you choose:\nnumber of person left " + textBox5.Text +
                                       ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text +
                                   ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }
                                else//history n existe alors cree; 
                                {

                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                    sw.WriteLine("and you choose:\nnumber of person left " + textBox5.Text +
                                        ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text +
                                    ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }

                            }
                            catch
                            {
                                label15.Visible = true;
                                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                                f12.Close();
                            }
                        }
                        else
                        {
                            Person.dp = int.Parse(textBox9.Text);
                            Voiture.dv = int.Parse(textBox10.Text);
                            if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                sw.WriteLine("and you choose:Manuel:");
                                sw.Close();
                            }
                            else//history n existe alors cree; 
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                sw.WriteLine("and you choose:Manuel:");
                                sw.Close();
                            }
                            f13 = new Form13();
                            f13.Show();
                        }
                        break;
                    }
                case "31route":
                    {

                        if (radioButton1.Checked == true)
                        {

                            f14 = new Form14();
                            try
                            {
                                Plan4Auto.moyenVoitureBasDroite = (int)(int.Parse(textBox3.Text.Trim()) / 2.0) - 1; Plan4Auto.moyenVoitureBasGauche = (int)(int.Parse(textBox3.Text.Trim()) / 2.0) + 1; Plan4Auto.moyenVoitureGaucheBas = (int)(int.Parse(textBox1.Text.Trim()) / 2.0) - 1; Plan4Auto.moyenVoitureGaucheHaut = (int)(int.Parse(textBox1.Text.Trim()) / 2.0) + 1;
                                Plan4Auto.moyenPersonGauche = int.Parse(textBox5.Text); Plan4Auto.moyenPersonHaut = int.Parse(textBox8.Text); Plan4Auto.moyenPersonDroite = int.Parse(textBox6.Text);
                                Person.dp = int.Parse(textBox9.Text); Voiture.dv = int.Parse(textBox10.Text);
                                Plan4Auto.tempsDuSimulation = double.Parse(textBox13.Text);

                      

                                f14.Show();//montrer le simulation 1 de plan a 3 route a 1 fleche
                                if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                                {
                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                    sw.WriteLine("and you choose:\nnumber of person left: " + textBox5.Text + "\nnumber of person right: " + textBox6.Text +
                                       ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text +
                                   ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }
                                else//history n existe alors cree; 
                                {

                                    StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                    sw.WriteLine("and you choose:\nnumber of person left: " + textBox5.Text + "\nnumber of person right: " + textBox6.Text +
                                          ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text +
                                      ";\ncar speed:" + textBox10.Text + ";\nperson speed:" + textBox9.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                    sw.Close();
                                }

                            }
                            catch
                            {
                                label15.Visible = true;
                                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                                f14.Close();
                            }
                        }
                        else
                        {
                            Person.dp = int.Parse(textBox9.Text);
                            Voiture.dv = int.Parse(textBox10.Text);
                            if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                sw.WriteLine("and you choose:Manuel:");
                                sw.Close();
                            }
                            else//history n existe alors cree; 
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                sw.WriteLine("and you choose:Manuel:");
                                sw.Close();
                            }
                            f15 = new Form15();
                            f15.Show();
                        }
                        break;


                    }
                case "complex":
                    {
                        f18 = new Form18();
                        try
                        {
                            Plan5Auto.moyenVoitureBas = int.Parse(textBox3.Text.Trim()); Plan5Auto.moyenVoitureGauche = int.Parse(textBox1.Text); Plan5Auto.moyenVoitureDroite = int.Parse(textBox2.Text); Plan5Auto.moyenVoitureHaut = int.Parse(textBox4.Text);
                            Voiture.dv = int.Parse(textBox10.Text);
                            Plan5Auto.tempsDuSimulation = double.Parse(textBox13.Text);
                         
                            f18.Show();//montrer le simulation 0 de plan a 4 route a 2 fleche
                            if (File.Exists(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt") == true)//exit cette history
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt", true);
                                sw.WriteLine("and you choose:" + ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text + ";\nnumber of car right: " + textBox2.Text + ";\nnumber of car up:" +
                                textBox4.Text + ";\ncar speed:" + textBox10.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                sw.Close();
                            }
                            else//history n existe alors cree; 
                            {
                                StreamWriter sw = new StreamWriter(@"histories\" + Program.f2.f4.label1.Tag.ToString() + ".txt");
                                sw.WriteLine("and you choose:" + ";\nnumber of car down: " + textBox3.Text + ";\nnumber of car left: " + textBox1.Text + ";\nnumber of car right: " + textBox2.Text + ";\nnumber of car up:" +
                               textBox4.Text + ";\ncar speed:" + textBox10.Text + ";\ntime of simulation:" + textBox13.Text + "\n");
                                sw.Close();
                            }

                        }
                        catch
                        {
                            label15.Visible = true;
                            axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                            f18.Close();
                        }
                    }

                    break;
            }
        }



        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//manuel
        {
            textBox1.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false;
            textBox5.Enabled = false; textBox6.Enabled = false; textBox7.Enabled = false; textBox8.Enabled = false;
            textBox13.Enabled = false;
            label1.Enabled = false; label2.Enabled = false; label3.Enabled = false; label4.Enabled = false;
            label5.Enabled = false; label6.Enabled = false; label7.Enabled = false; label8.Enabled = false;
            label13.Enabled = false; label14.Enabled = false;
           
        }

        private void radioButton1_Click(object sender, EventArgs e)//auto
        {
            textBox1.Enabled = true; textBox2.Enabled = true; textBox3.Enabled = true;
            textBox4.Enabled = true; textBox5.Enabled = true; textBox6.Enabled = true; textBox7.Enabled = true; textBox8.Enabled = true;
            textBox13.Enabled = true;
            label1.Enabled = true; label2.Enabled = true; label3.Enabled = true; label4.Enabled = true;
            label5.Enabled = true; label6.Enabled = true; label7.Enabled = true; label8.Enabled = true;
            label13.Enabled = true; label14.Enabled = true;
        


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }


    }
}
