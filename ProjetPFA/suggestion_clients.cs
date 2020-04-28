using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEL;
using DAL;
using System.Data.OleDb;

namespace ProjetPFA
{
    public partial class suggestion_clients : Form
    {
        public suggestion_clients()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Accueil f1 = new Accueil();
            f1.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string requete = String.Format("insert into suggestion (id_client, message) values ('{0}','{1}');", int.Parse(textBox1.Text), richTextBox1.Text);
            utils.miseajour(requete);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }
    }

}
