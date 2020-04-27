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
    public partial class passer_une_commande : Form
    {
        public passer_une_commande()
        {
            InitializeComponent();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string requete = String.Format("select prix_unitaire from produit where reference = '{0}';", int.Parse(comboBox1.Text));
                OleDbDataReader rd = utils.lire(requete);
                int prix = rd.GetInt32(0) * int.Parse(textBox2.Text);
                utils.Disconnect();

                CommandeDAO.passer_commande(int.Parse(textBox1.Text), int.Parse(comboBox1.Text),int.Parse(textBox2.Text),prix, DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string requete = String.Format("select prix_unitaire from produit where reference = '{0}';", int.Parse(comboBox1.Text));
                OleDbDataReader rd = utils.lire(requete);
                int prix = rd.GetInt32(0) * int.Parse(textBox2.Text);
                utils.Disconnect();

                CommandeDAO.Update_commande(int.Parse(textBox1.Text), int.Parse(comboBox1.Text), int.Parse(textBox2.Text), prix, DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Accueil f1 = new Accueil();
            f1.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
