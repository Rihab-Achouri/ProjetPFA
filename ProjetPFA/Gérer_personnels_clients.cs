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
    public partial class Gérer_personnels_clients : Form
    {
        public Gérer_personnels_clients()
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
            Accueil f1 = new Accueil();
            f1.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Personnel p = PersonnelDAO.Get_personnel_ID(int.Parse(textBox1.Text));
                textBox2.Text = p.Nom;
                textBox3.Text = p.Prenom;
                textBox4.Text = p.Tel.ToString();
                textBox5.Text = p.Adresse_mail;
                textBox6.Text = p.Poste;
                List<Personnel> L = new List<Personnel>();
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
                PersonnelDAO.Update_personnel(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text, textBox6.Text);
                MessageBox.Show("UPDATE DONE");
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
                PersonnelDAO.Delete_personnel(int.Parse(textBox7.Text));
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
                List<Personnel> Listpersonnels = PersonnelDAO.Get_personnel();
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
                PersonnelDAO.Insert_personnel(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text, textBox6.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
