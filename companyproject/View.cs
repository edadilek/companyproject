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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\MyDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection Con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\Katilim.mdf;Integrated Security=True;Connect Timeout=30");

        private void fonk()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where ID='" +IDTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                adsoyad2.Text = dr["AdSoyad"].ToString();
                telefon2.Text = dr["Telefon"].ToString();
                dogumtarihi2.Text = dr["DoğumTarihi"].ToString();
                pozisyon2.Text = dr["Pozisyon"].ToString();
                egitim2.Text = dr["Eğitim"].ToString();
                adres2.Text = dr["Adres"].ToString();
                adsoyad2.Visible = true;
                telefon2.Visible = true;
                dogumtarihi2.Visible = true;
                pozisyon2.Visible = true;
                egitim2.Visible = true;
                adres2.Visible = true;

            }
            
            
            Con.Close();
            ekle();
        }

        private void ekle()
        {
            Con2.Open();
            string query = "select * from AttendanceTbl where ID ='"+IDTb.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con2);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            viewDGV.DataSource = ds.Tables[0];
            Con2.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void View_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fonk();
            ekle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("       PERSONEL BİLGİLERİ       ", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(210));
            e.Graphics.DrawString("Personel ID: " + IDTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50,130));
            e.Graphics.DrawString("Pozisyon: " + pozisyon2.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50,170));
            e.Graphics.DrawString("Ad Soyad: " + adsoyad2.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50,210));
            e.Graphics.DrawString("Telefon: " + telefon2.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50,250));
            e.Graphics.DrawString("Adres: " + adres2.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50,290));
            e.Graphics.DrawString("Doğum Tarihi: " + dogumtarihi2.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50,330));
            e.Graphics.DrawString("       developpedbyedadilek       ", new Font("Century Gothic", 20, FontStyle.Regular), Brushes.Red, new Point(200,1100));
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDTb.Text = viewDGV.SelectedRows[0].Cells[0].Value.ToString();
            
        }

        
    }
}
