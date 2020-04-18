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
    public partial class Espace_Responsable_Traitement : Form
    {
        public Espace_Responsable_Traitement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Authentification f1 = new Authentification();
            f1.ShowDialog();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Authentification f3 = new Authentification();
            f3.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Information_personnel f2 = new Information_personnel();
            f2.ShowDialog();
            this.Hide();
        }
    }
}
