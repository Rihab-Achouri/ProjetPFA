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

namespace ProjetPFA
{
    public partial class Gérer_personnels : Form
    {
        public Gérer_personnels()
        {
            InitializeComponent();
        }

        private void Gérer_personnels_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Espace_Administrateur f3 = new Espace_Administrateur();
            f3.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                personnel p = personnelDAO.Get_personnel_ID(int.Parse(textBox1.Text));
                textBox2.Text = p.nom;
                textBox3.Text = p.prenom;
                textBox4.Text = p.tel.ToString();
                textBox5.Text = p.adresse_mail;
                textBox6.Text = p.poste;
                List<personnel> L = new List<personnel>();
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
            try
            {
                personnelDAO.Update_personnel(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text, textBox6.Text);
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
                personnelDAO.Delete_personnel(int.Parse(textBox7.Text));
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
                List<personnel> Listpersonnels = personnelDAO.Get_personnel();
                dataGridView1.DataSource = Listpersonnels;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                personnelDAO.Insert_personnel(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text, textBox6.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
