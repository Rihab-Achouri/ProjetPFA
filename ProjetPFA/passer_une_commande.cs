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

                string requet = String.Format("select max (num_commande) from commande;");
                OleDbDataReader RD = utils.lire(requet);
                int num = rd.GetInt32(0) * int.Parse(textBox2.Text);
                utils.Disconnect();

                string Message2 = num.ToString();
                string Message1 = prix.ToString();
                MessageBox.Show("Le numéro de votre commande est:"+ Message1 + "\n Le prix à payer est: " + Message2 );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Commande p = CommandeDAO.Get_commande_reference(int.Parse(textBox3.Text));
                textBox3.Text = p.Num_commande.ToString();
                comboBox1.Text = p.Reference_produit.ToString();
                textBox2.Text = p.Qt.ToString();
                dateTimePicker1.Text = p.Date_commande.ToString();
                dateTimePicker2.Text = p.Date_livraison_souhaité.ToString();
                
                List<Commande> L = new List<Commande>();
                L.Add(p);
                dataGridView1.DataSource = L;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Commande> Listcommande = CommandeDAO.Get_commande_Id_client(int.Parse(textBox1.Text));
                dataGridView1.DataSource = Listcommande;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
