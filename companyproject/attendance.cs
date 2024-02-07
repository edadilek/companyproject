using System;
using companyproject;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace myproject
{
    public partial class attendance : Form
    {
        public attendance()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\Katilim.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public static string pas2 = "";
       
        private void button4_Click(object sender, EventArgs e)
        {
            
            pas2 = Login.pas;
            if (DateDp.Text == "" )
            {
                MessageBox.Show("Tarih seçiniz!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AttendanceTbl values('" + pas2 + "','" + DateDp.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Giriş kaydedildi!");
                    Con.Close();
                    ekle();
                   


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ekle()
        {
            Con.Open();
            string query = "select * from AttendanceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            katilimDGV.DataSource = ds.Tables[0];
            Con.Close();
            
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pas2 = katilimDGV.SelectedRows[0].Cells[0].Value.ToString();
            DateDp.Text = katilimDGV.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            ekle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DateDp.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!");
            }
            else
            {
                try
                {

                    Con.Open();
                    string query = "DELETE FROM AttendanceTbl where Tarih='" + DateDp.Value.Date + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Giriş başarıyla silindi!");
                    Con.Close();
                    ekle();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Con.Open();
                string query = "DELETE FROM AttendanceTbl";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tüm veriler silindi!");
                Con.Close();
                ekle();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
