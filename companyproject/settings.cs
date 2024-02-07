using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace companyproject
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IDTb.Text == "" || Sifre.Text == "")
            {
                MessageBox.Show("Eksik bilgi!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into LoginTbl values('" + IDTb.Text + "','" + Sifre.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel şifresi başarıyla belirlendi!");
                    Con.Close();
                    
                    

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IDTb.Text == "" || Sifre.Text == "")
            {
                MessageBox.Show("Eksik bilgi!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update LoginTbl set Sifre='" + Sifre.Text + "' where ID = '"+IDTb.Text+ "'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel şifresi başarıyla değiştirildi!");
                    Con.Close();



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                Con.Open();
                string query = "DELETE FROM LoginTbl";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tüm veriler silindi!");
                Con.Close();
                
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
