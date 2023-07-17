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

namespace CoRobić
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("czynnosci.txt");
            if (!File.Exists("czynnosci.txt"))
            {
                File.Create("czynnosci.txt");
                sw.WriteLine("0");
            }
            StreamReader sr = new StreamReader("czynnosci.txt");
            
            //czy wycieczka po słodycze?
            Random słodycze = new Random();

        }
    }
}
