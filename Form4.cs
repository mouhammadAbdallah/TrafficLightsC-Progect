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
    public partial class Form4 : Form//menu du programme et montre le profile et information;
    {
        DataSet ds;
        public static Form6 f6;
        public Form3 f3;//pour changer information sur click
        public Form4()
        {
            InitializeComponent();
        }

       
        private void pictureBox1_Click_1(object sender, EventArgs e)//ouvrir plan 0 de 4 route  a 2 fleche
        {
            axWindowsMediaPlayer1.URL = "soundSelect.mp3";
            //create ou additionner history;
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)//exit cette history
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt", true);
                sw.WriteLine("-------------\nyou have used simulation of plan 1 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }
            else//history n existe alors cree; 
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() +  ".txt");
                sw.WriteLine("-------------\nyou have used simulation of plan 1 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }

            f6 = new Form6();
            f6.Tag = "4route";
        

            f6.ShowDialog();


        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
            ds = new DataSet();
            ds.ReadXml("users.xml");

            axWindowsMediaPlayer1.URL = "correctSound.mp3";



        }



        private void pictureBox3_Click(object sender, EventArgs e)//3 route a 2fleche
        {
            axWindowsMediaPlayer1.URL = "soundSelect.mp3";
            //create ou additionner history;
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)//exit cette history
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString()  + ".txt", true);
                sw.WriteLine("-------------\nyou have used simulation of plan 2 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }
            else//history n existe alors cree; 
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt");
                sw.WriteLine("-------------\nyou have used simulation of plan 2 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }

            f6 = new Form6();
            f6.label4.Visible = false;
          
            f6.textBox4.Visible = false;
            f6.Tag = "3route";
           
            f6.pictureBox1.Image = new Bitmap("route3avecfleche.png");
            f6.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "soundSelect.mp3";

            //create ou additionner history;
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)//exit cette history
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString()+".txt", true);
                sw.WriteLine("-------------\nyou have used simulation of plan 3 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }
            else//history n existe alors cree; 
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt");
                sw.WriteLine("-------------\nyou have used simulation of plan 3 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }

            f6 = new Form6();
            f6.Tag = "41route";
            f6.label4.Visible = false;
            f6.textBox4.Visible = false;
         
            f6.pictureBox1.Image = new Bitmap("route4avecfleche.png");
            f6.textBox2.Visible = false;
            f6.label2.Visible = false;
            f6.textBox7.Visible = false;
            f6.label7.Visible = false;
            f6.textBox6.Visible = false;
            f6.label6.Visible = false;
       
            f6.ShowDialog();






        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "soundSelect.mp3";
            //create ou additionner history;
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)//exit cette history
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt", true);
                sw.WriteLine("-------------\nyou have used simulation of plan 4 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }
            else//history n existe alors cree; 
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt");
                sw.WriteLine("-------------\nyou have used simulation of plan 4 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }

            f6 = new Form6();
            f6.Tag = "31route";
            f6.label4.Visible = false;
            f6.textBox4.Visible = false;
            f6.textBox2.Visible = false;
            f6.label2.Visible = false;
            f6.textBox8.Visible = false;
            f6.label8.Visible = false;
           
           
            f6.textBox7.Visible = false;
            f6.label7.Visible = false;
            f6.pictureBox1.Image = new Bitmap("route10avecfleche.png");
     
            f6.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "soundSelect.mp3";
            //create ou additionner history;
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)//exit cette history
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt", true);
                sw.WriteLine("-------------\nyou have used simulation of plan 5 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }
            else//history n existe alors cree; 
            {
                StreamWriter sw = new StreamWriter(@"histories\" + label1.Tag.ToString() + ".txt");
                sw.WriteLine("-------------\nyou have used simulation of plan 5 \nat the time :" + DateTime.Now.ToString() + "\n");
                sw.Close();
            }

            f6 = new Form6();
            f6.Tag = "complex";
            f6.pictureBox1.Image = new Bitmap("route12avecfleche.png");
            f6.label8.Visible = false;
            f6.label5.Visible = false;
            f6.label7.Visible = false;
            f6.label6.Visible = false;
            f6.textBox8.Visible = false; f6.textBox5.Visible = false;
            f6.textBox7.Visible = false;
            f6.textBox6.Visible = false;
            f6.radioButton2.Visible = false;
            f6.label6.Visible = false;
           
            f6.ShowDialog();



        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = new Bitmap("route12Form4.png");
            label3.Text = "Plan 5";

        }

        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox7.Image = new Bitmap("route2Form4.png");
            label3.Text = "Plan 1";
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = new Bitmap("route10Form4.png");
            label3.Text = "Plan 4";
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = new Bitmap("route3Form4.png");
            label3.Text = "Plan 2";
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = new Bitmap("route4Form4.png");
            label3.Text = "Plan 3";

        }

        private void Form4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = null;
            label3.Text = "";
        }

        private void viewAllUsersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            DataSet ds = new DataSet();
            ds.ReadXml("users.xml");
            PictureBox pb; Label f, l, p,em;
            f9.comboBox1.DataSource = ds.Tables[0];
            f9.comboBox1.DisplayMember = "email";


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                pb = new PictureBox();
                pb.Size = new Size(150, 150);
                pb.Location = new Point(50, 50 + 150 * i);
                pb.Image = new Bitmap(ds.Tables[0].Rows[i][8].ToString());
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                f9.panel1.Controls.Add(pb);


                f = new Label();

                f.Location = new Point(300, 100 + 150 * i);
                f.Text = ds.Tables[0].Rows[i][0].ToString();
                f.Font = new Font("Algerian", 10f, FontStyle.Bold);
                f9.panel1.Controls.Add(f);
                l = new Label();

                l.Location = new Point(300, 125 + 150 * i);
                l.Text = ds.Tables[0].Rows[i][1].ToString();
                l.Font = new Font("Algerian", 10f, FontStyle.Bold);
                f9.panel1.Controls.Add(l);
                p = new Label();

                p.Location = new Point(300, 150 + 150 * i);
                p.Text = ds.Tables[0].Rows[i][9].ToString();
                p.Font = new Font("Algerian", 10f, FontStyle.Italic);
                f9.panel1.Controls.Add(p);
                em = new Label();

                em.Location = new Point(300, 175 + 150 * i);
                em.Text = ds.Tables[0].Rows[i][6].ToString();
                em.Text = em.Text.Remove(em.Text.LastIndexOf("@"), 9);
                em.Font = new Font("Algerian", 9f, FontStyle.Italic);
                em.ForeColor = Color.Blue;
                f9.panel1.Controls.Add(em);

            }
            f9.Show();

        }

        private void changeOwnInformaionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3();//on met ds elle information precedent de cette user
            f3.Show();
            bool trouver = false;
            string mail = label1.Tag.ToString(), pass = label2.Tag.ToString();
            int i = 0;//pour chercher ds les rows
            while ((i < ds.Tables[0].Rows.Count) && (trouver == false))
                if (((ds.Tables[0].Rows[i]["email"].ToString() != mail) || (ds.Tables[0].Rows[i]["password"].ToString() != pass)))
                    i++;
                else trouver = true;
            //remplir la form par information
            f3.button2.Text = "Change";
            f3.label1.Text = "Change your old information";
            f3.textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
            f3.textBox3.Text = ds.Tables[0].Rows[i][1].ToString();
            f3.textBox7.Text = ds.Tables[0].Rows[i][9].ToString();
            f3.comboBox1.Text = ds.Tables[0].Rows[i][3].ToString();
            f3.comboBox2.Text = ds.Tables[0].Rows[i][4].ToString();
            f3.radioButton1.Checked = true;//on met les :male si non il la change
            f3.textBox4.Text = ds.Tables[0].Rows[i][5].ToString();
            f3.pictureBox1.Image = new Bitmap(ds.Tables[0].Rows[i][8].ToString());
            f3.pictureBox1.Tag = ds.Tables[0].Rows[i][8].ToString();//cacher ds le tag de picture son full path
            f3.textBox5.Text = ds.Tables[0].Rows[i][6].ToString().Substring(0, ds.Tables[0].Rows[i][6].ToString().LastIndexOf('@'));
            f3.textBox5.ReadOnly = true;
            f3.textBox6.Text = ds.Tables[0].Rows[i][7].ToString();
            f3.textBox6.ReadOnly = true;
            f3.textBox2.Text = "0000"; f3.textBox2.ReadOnly = true;
            //need de log in again to refresh information
            MessageBox.Show("your account will refresh after changing information ", "indication", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void deleteAcountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool trouver = false;
            string mail = label1.Tag.ToString(), pass = label2.Tag.ToString();//car chaque label cache ds son tag email ou pass
            int i = 0;//pour chercher ds les rows
            while ((i < ds.Tables[0].Rows.Count) && (trouver == false))
                if (((ds.Tables[0].Rows[i]["email"].ToString() != mail) || (ds.Tables[0].Rows[i]["password"].ToString() != pass)))
                    i++;
                else trouver = true;
            ds.Tables[0].Rows[i].Delete();//delete from xml
            ds.WriteXml("users.xml");
            if (File.Exists(@"histories\" + label1.Tag + ".txt") == true)
            {
                File.Delete(@"histories\" + label1.Tag + ".txt");//delte from history
            }
            MessageBox.Show("you have succefully delete your account ", "succeful delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();

        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)//ouvrir si existe
            {
                Form7 f7 = new Form7();//pour history;
                f7.Show();
                string[] s; int l = 0; ;
                StreamReader sr = new StreamReader(@"histories\" + label1.Tag.ToString() + ".txt");
                while (sr.Peek() != -1)
                {
                    l++;

                    sr.ReadLine();

                }
                s = new string[l]; l = 0;
                sr.Close();
                sr = new StreamReader(@"histories\" + label1.Tag.ToString() + ".txt");
                while (sr.Peek() != -1)
                {


                    s[l] = sr.ReadLine(); l++;

                }
                sr.Close();
                f7.textBox1.Lines = s;
            }
            else//history vide
            {
                MessageBox.Show("there isn't history", "warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"histories\" + label1.Tag.ToString() + ".txt") == true)
                File.Delete(@"histories\" + label1.Tag.ToString() + ".txt");

        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Image = pictureBox2.Image;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = null;
        }
    }
}
