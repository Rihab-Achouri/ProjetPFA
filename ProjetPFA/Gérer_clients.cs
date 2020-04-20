using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BEL;

namespace ProjetPFA
{
    public partial class Gérer_clients : Form
    {
        public Gérer_clients()
        {
            InitializeComponent();
        }

        private void Gérer_clients_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Espace_Administrateur f3 = new Espace_Administrateur();
            f3.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                clientDAO.Delete_client(int.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                client clt = clientDAO.Get_client_ID(int.Parse(textBox1.Text));
                textBox2.Text = clt.nom_cl;
                textBox3.Text = clt.prenom_cl;
                textBox4.Text = clt.tel_cl.ToString();
                textBox5.Text = clt.adresse_mail_cl;
                List<client> L = new List<client>();
                L.Add(clt);
                dataGridView1.DataSource = L;
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
                clientDAO.Insert_client(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                clientDAO.Update_client(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text);
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
                List<client> ListClients = clientDAO.Get_client();
                dataGridView1.DataSource = ListClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
}
