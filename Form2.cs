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
    public partial class Form2 : Form//cree(il ya code pour cree "0000") ou ouvrir un account car ce programme n est pas public il eat pour des personne qui etudie des simulation comme ici et faite des resultats;
    {
       public Form4 f4;//pour ouvrir la private simulation de chaque personne
        DataSet ds;//data pour users
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            i = 0;
           
            Form1 f1 = new Form1();
            f1.ShowDialog();//show le logo du programme
            this.Tag = false;

            ds = new DataSet();
            ds.ReadXml("users.xml");//read les users;
            
            
        
            textBox1.Text = "mohamad1998"; textBox2.Text = "@@mohamad@@";//pour une vite utilisation lors du prgramation on donne un user
          

            // create xml files pour les users un seul fois pour que on prends la forme de data a stocke

            //DataSet ds = new DataSet();
            //ds.DataSetName = "users";
            //DataTable dt = new DataTable();
            //dt.TableName = "user";
            //ds.Tables.Add(dt);
            //DataColumn dc = new DataColumn("firstName", typeof(string));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("lastName", typeof(string));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("gender", typeof(bool));//true to male
            //dt.Columns.Add(dc);
            //dc = new DataColumn("birthday", typeof(int));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("birthMonth", typeof(int));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("birthYear", typeof(int));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("email", typeof(string));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("password", typeof(string));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("profile", typeof(string));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("phoneNumber", typeof(int));
            //dt.Columns.Add(dc);
            //DataRow dr = dt.NewRow();
            //dr[0] = "mohamad";
            //dr[1] = "abdallah";
            //dr[2] = true;
            //dr[3] = 10;
            //dr[4] = 3;
            //dr[5] = 1998;
            //dr[6] = "mohamad1998@user.com";
            //dr[7] = "@@mohamad@@";
            //dr[8] = "mohamad.jpg";
            //dr[9] = 70581493;
            //dt.Rows.Add(dr);
            //ds.WriteXml("users.xml");



        }

        private void button1_Click(object sender, EventArgs e)//button sign in
        {
            timer1.Enabled = false;
            ds = new DataSet();
            ds.ReadXml("users.xml");
            bool trouver = false;
            string mail = textBox1.Text.Trim() + "@user.com", pass = textBox2.Text.Trim();
            int i = 0;//pour chercher ds les rows
            while ((i < ds.Tables[0].Rows.Count)&&(trouver==false))//chercher ds les rows
                if (((ds.Tables[0].Rows[i]["email"].ToString() != mail)|| (ds.Tables[0].Rows[i]["password"].ToString() != pass)))
                    i++;
                else trouver = true;// email exist
            
            if (trouver==true)// email exist
            {
               f4 = new Form4();//ouvrir le programe de cette utilisateur
                //mettre le profile et autre data
                f4.pictureBox2.Image = new Bitmap(ds.Tables[0].Rows[i]["profile"].ToString());
                f4.label1.Text = ds.Tables[0].Rows[i]["firstName"].ToString();
                f4.label1.Tag = ds.Tables[0].Rows[i]["email"].ToString();
                f4.label2.Text = ds.Tables[0].Rows[i]["lastName"].ToString();
                f4.label2.Tag = ds.Tables[0].Rows[i]["password"].ToString();
               

                f4.ShowDialog();//ouvrir le programe de cette utiisateur
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else//email n existe pas
            {
               
                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                    label4.Visible = true;   //text=wrong mail ou password         
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;//cacher wrong mail ou password lorsque il commence a ecrire

        }

        private void button2_Click(object sender, EventArgs e)//create new account
        {
            Form3 f3 = new Form3();
            
              f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)//pour clear mail et pass
        {
            textBox1.Text = ""; textBox2.Text = "";
        }

        int i;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            pictureBox1.Image = new Bitmap("welcome" + (i % 2).ToString() + ".png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
