using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace companyproject
{
    public partial class employee : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\MyDb.mdf;Integrated Security=True;Connect Timeout=30");

        public employee()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (IDTb.Text == "" || AdSoyadTb.Text == "" || PozisyonCb.Text == "" || TelefonTb.Text == "" || EğitimCb.Text == "" || DoğumTarihiDob.Text == "" || AdresTb.Text == "")
            {
                MessageBox.Show("Eksik bilgi!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into EmployeeTbl values('" + IDTb.Text + "','" + AdSoyadTb.Text + "','" + PozisyonCb.SelectedItem.ToString() + "','" + TelefonTb.Text + "','" + EğitimCb.SelectedItem.ToString() + "','" + DoğumTarihiDob.Value.Date + "','" + AdresTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel başarıyla eklendi");
                    Con.Close();
                    ekle();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ekle()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDTb.Text = EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString();
            AdSoyadTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            PozisyonCb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            TelefonTb.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EğitimCb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            DoğumTarihiDob.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            AdresTb.Text = EmployeeDGV.SelectedRows[0].Cells[6].Value.ToString();
            
        }

        private void employee_Load_1(object sender, EventArgs e)
        {
            ekle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IDTb.Text == "" || AdSoyadTb.Text == "" || PozisyonCb.Text == "" || TelefonTb.Text == "" || EğitimCb.Text == "" || DoğumTarihiDob.Text == "" || AdresTb.Text == "")
            {
                MessageBox.Show("Eksik bilgi!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update EmployeeTbl set AdSoyad='" + AdSoyadTb.Text + "',Adres='" + AdresTb.Text + "',Pozisyon='" + PozisyonCb.SelectedItem.ToString() + "',DoğumTarihi='" + DoğumTarihiDob.Value.Date + "',Telefon='" + TelefonTb.Text + "',Eğitim='" + EğitimCb.SelectedItem.ToString() + "' where ID='"+IDTb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel bilgileri başarıyla değiştirildi!");
                    Con.Close();
                    ekle();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IDTb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi!");
            }
            else
            {
                try
                {

                    Con.Open();
                    string query = "DELETE FROM EmployeeTbl where ID='" + IDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel başarıyla silindi!");
                    Con.Close();
                    ekle();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
