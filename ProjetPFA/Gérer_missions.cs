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
    public partial class Gérer_mission : Form
    {
        public Gérer_mission()
        {
            InitializeComponent();
        }

        private void Gérer_mission_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Accueil f1 = new Accueil();
            f1.ShowDialog();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MissionDAO.Delete_Mission(int.Parse(textBox10.Text));
                MessageBox.Show("Mission Supprimer");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Mission m = MissionDAO.Get_Mission_Num(int.Parse(textBox10.Text));
                textBox10.Text = m.Num.ToString();
                comboBox1.Text = m.Etat;
                textBox7.Text = m.Département;
                dateTimePicker2.Text = m.Début_traitement.ToString();
                dateTimePicker1.Text = m.Date_cloture.ToString();
                richTextBox2.Text = m.Description;
                List<Mission> L = new List<Mission>();
                L.Add(m);
                dataGridView1.DataSource = L;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<Mission> ListMissions = MissionDAO.Get_Mission_Cloturée();
                dataGridView1.DataSource = ListMissions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                List<Mission> ListMissions = MissionDAO.Get_Mission();
                dataGridView1.DataSource = ListMissions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<Mission> ListMissions = MissionDAO.Get_Mission_Non_Traitée();
                dataGridView1.DataSource = ListMissions;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
