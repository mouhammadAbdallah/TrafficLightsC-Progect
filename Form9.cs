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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

      

        private void Form9_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0)
            {
                if (File.Exists(@"histories\" + comboBox1.DisplayMember.ToString() + comboBox1.ValueMember.ToString() + ".txt") == true)//exit cette history
                {
                    StreamWriter sw = new StreamWriter(@"histories\" + comboBox1.Text.ToString() + comboBox1.Tag.ToString() + ".txt", true);
                    sw.WriteLine("**message**:\nyou have a message from"+Program.f2.f4.label1.Text+" "+ Program.f2.f4.label1.Text+" at the time :" + DateTime.Now.ToString() + "\n");
                    sw.Close();
                }
                else//history n existe alors cree; 
                {
                    StreamWriter sw = new StreamWriter(@"histories\" + comboBox1.Text.ToString()+ ".txt");
                    sw.WriteLine("**message**:\nyou have a message from " + Program.f2.f4.label1.Text + " " + Program.f2.f4.label2.Text + " at the time :" + DateTime.Now.ToString() + "\n"+textBox1.Text);
                    sw.Close();
                }
                textBox1.Text = "";
            }
        }
    }
}
