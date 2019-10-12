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
    
    public partial class Form3 : Form//create  new account si on sait la code
    {
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//mettre une profile
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fname = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(fname);
                pictureBox1.Tag = fname;

            }
        }

        private void button2_Click(object sender, EventArgs e)//additione au xml si il nexiste pas ou changer information ds cas specifique,voir loin
        {
            bool trouver = false;
            string mail = textBox5.Text.Trim() + "@user.com", pass = textBox6.Text.Trim();
            if (textBox2.Text.Trim() != "0000")//code pour les persoone qui peut utiliser ce programme;
            {
                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                label7.Text = "wrong code";
                label7.Visible = true;
            }
            else//il sait la code
            {
                int i = 0;
                while ((i < ds.Tables[0].Rows.Count) && (trouver == false))//cherecher si email exist
                    if (((ds.Tables[0].Rows[i]["email"].ToString() != mail)))
                        i++;
                    else trouver = true;//email exist
                if ((trouver == true)&&(textBox5.ReadOnly==false))//impossible de cree car exist avant
                {
                    axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                    label7.Text = "email exist";
                    label7.Visible = true;
                    textBox5.Text = "";
                }
                else//changer information si il fait ds leur private account changer information
                {
                    i = 0;
                    trouver = false;
                    while ((i < ds.Tables[0].Rows.Count) && (trouver == false))//cherecher si email exist
                        if (((ds.Tables[0].Rows[i]["email"].ToString() != mail) || (ds.Tables[0].Rows[i]["password"].ToString() != pass)))
                            i++;
                        else trouver = true;//email exist

                    if (trouver == true)//changer les,car si il connait email et password alors c'est leur account
                    {
                        
                        if (textBox7.Text == "") textBox7.Text = ds.Tables[0].Rows[i][9].ToString();

                        ds.Tables[0].Rows[i][0] = textBox1.Text;
                        ds.Tables[0].Rows[i][1] = textBox3.Text;
                        ds.Tables[0].Rows[i][2] = radioButton1.Checked;
                        ds.Tables[0].Rows[i][3] = int.Parse(comboBox1.Text);
                        ds.Tables[0].Rows[i][4] = int.Parse(comboBox2.Text);
                        ds.Tables[0].Rows[i][5] = int.Parse(textBox4.Text);
                        ds.Tables[0].Rows[i][6] = textBox5.Text.Trim() + "@user.com";
                        ds.Tables[0].Rows[i][7] = textBox6.Text.Trim();
                        ds.Tables[0].Rows[i][8] = pictureBox1.Tag.ToString();
                        ds.Tables[0].Rows[i][9] = int.Parse(textBox7.Text);

                        ds.WriteXml("users.xml");
                        axWindowsMediaPlayer1.URL = "correctSound.mp3";
                        
                        MessageBox.Show("you have succefully change your data information\nrefresh.....\n Please sign in again", "succeful change", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                        Program.f2.f4.Close();//pour la refres

                        this.Close();
                        


                    }
                    else //n existe pas alors on l additionne
                    {
                        if (pictureBox1.Tag.ToString() == "") pictureBox1.Tag = "userphoto.png";//prfile default

                        axWindowsMediaPlayer1.URL = "correctSound.mp3";
                        try
                        {
                            DataRow dr = ds.Tables[0].NewRow();//additionner a xml
                            if ((mail.Length == 0) || (pass.Length == 0)||(textBox1.Text.Length==0) || (textBox3.Text.Length==0))
                            {
                                axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                                label7.Text = "Error exist";
                                label7.Visible = true;
                            }
                            else
                            {
                                dr[0] = textBox1.Text;
                                dr[1] = textBox3.Text;
                                dr[2] = radioButton1.Checked;
                                dr[3] = int.Parse(comboBox1.Text);
                                dr[4] = int.Parse(comboBox2.Text);
                                dr[5] = int.Parse(textBox4.Text);
                                dr[6] = mail;
                                dr[7] = pass;
                                dr[8] = pictureBox1.Tag.ToString();
                                dr[9] = int.Parse(textBox7.Text);
                                ds.Tables[0].Rows.Add(dr);
                                ds.WriteXml("users.xml");
                                axWindowsMediaPlayer1.URL = "correctSound.mp3";
                                Program.f2.textBox1.Text = textBox5.Text.Trim();
                                Program.f2.textBox2.Text = textBox6.Text.Trim();
                                this.Close();
                            }
                        }
                        catch {
                            axWindowsMediaPlayer1.URL = "wrongSound.mp3";
                            label7.Text = "Error exist";
                            label7.Visible = true;
                        }
                       
                     


                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;//cacher label "email exist"ou "wrong code"
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml("users.xml");
        }
    }
}