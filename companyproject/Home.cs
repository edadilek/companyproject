using myproject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace companyproject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            View Vw = new View();
            Vw.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            View Vw = new View();
            Vw.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            maas ms = new maas();
            ms.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            maas ms = new maas();
            ms.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            settings st = new settings();
            st.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            settings st = new settings();
            st.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            myproject.attendance ac = new myproject.attendance();
            ac.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            attendance ac = new attendance();
            ac.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
