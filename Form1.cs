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
    public partial class Form1 : Form//comme logo du programmme
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)//pour changer la valeur de progressbar
        {
            if (progressBar1.Value < 100)
            {
                x += 5;
                progressBar1.Value += 1;
                pictureBox2.Location = new Point(x, y);
                label2.Text = progressBar1.Value.ToString() + " %";//changer la text qui montre la valeur de prgressbar
            }
            else//fin de progressbar
            {
                axWindowsMediaPlayer1.URL = "correctSound.mp3";
                timer1.Enabled = false;
               
               
                this.Close();
             
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//skip if enter was clicked
        {
            if (e.KeyCode == Keys.Enter) { this.Close();  }
        }
        int x, y;

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            axWindowsMediaPlayer1.URL = "correctSound.mp3";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "carRun.mp3";
            x = pictureBox2.Location.X;
            y = pictureBox2.Location.Y;
        }
    }
}
