using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wisielec
{
    public partial class Form1 : Form
    {
        string slowo;

        public Form1()
        {
            InitializeComponent();
            losuj_slowo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string litera = textBox1.Text;
            bool czy_trafiony = false;
            int gdzie_trafiony = 0;
        }

        private void losuj_slowo()
        {
            
            string[] slowa = { "krokusy", "liliput", "marchew", "selerek", "krakers", "klakier" };
            int ile_slow = slowa.Length;
            Random gen = new Random();
            int indeks_slowa = gen.Next(0, ile_slow);
            slowo = slowa[indeks_slowa];
            label1.Text = Convert.ToString(slowo[0]);
            label7.Text = Convert.ToString(slowo[6]);
        }
    }
}
