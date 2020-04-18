using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetPFA
{
    public partial class Espace_Responsable_Qualité : Form
    {
        public Espace_Responsable_Qualité()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Traitement_personnel f1 = new Traitement_personnel();
            f1.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Information_personnel f2 = new Information_personnel();
            f2.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Authentification f3 = new Authentification();
            f3.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
