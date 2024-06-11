using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {   private Random rand = new Random();
        private int[] x = new int[4];
        private string s;
        private int bulls;
        private int cows;

        public Form1()
        {   InitializeComponent();
            StartGame();
            var pos = this.PointToScreen(label2.Location);
            pos = pictureBox1.PointToClient(pos);
            label2.Parent = pictureBox1;
            label2.Location = pos;
            label2.BackColor = Color.Transparent;
        }

        private void StartGame()
        {
            NewChislo();
            label2.Text = "";
            label3.Text = "****";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox2.UseSystemPasswordChar = true;
            pictureBox1.BackColor = ColorTranslator.FromHtml("#f5f5f5");
            label8.Text = "";
            label9.Text = "";
        }

        private void NewChislo()
        {
            bool contains;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    contains = false;
                    x[i] = rand.Next(10);
                    for (int k = 0; k < i; k++)
                        if (x[k] == x[i])
                            contains = true;
                } while (contains);
            }
            s = x[0].ToString() + x[1] + x[2] + x[3];
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void RezultatShow()
        {    
            if (bulls == 3)
            {
                textBox3.Text += textBox1.Text + ", биків - " + bulls + ", корів - " + cows + " - ВІДМІННИЙ ХІД\n"; 
            }
            else {
                textBox3.Text += textBox1.Text + ", биків - " + bulls + ", корів - " + cows + "\r\n";

            }
        }

        private void SravnitChisla()
        {
            bulls = 0;
            cows = 0;
            char[] ch = textBox1.Text.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                if (s.Contains(ch[i]))
                {
                    if (s[i] == ch[i])
                        bulls++;
                    else
                        cows++;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 4)
            {
                label8.Text = "Введіть чотиризначне число";
            }
            else
            {
                SravnitChisla();
                RezultatShow();
                label8.Text = "";
            }
            textBox1.Text = "";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            label3.Text = s;
            label2.Text = "";
            textBox1.ReadOnly = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StartGame();
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 4)
            {
                label9.Text = "Введіть чотиризначне число";
                textBox2.Text = "";
            }
            else
            {
                label9.Text = "";
                s = textBox2.Text;
                textBox2.Text="";

            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gamecreating.ru");
        }
    }
}