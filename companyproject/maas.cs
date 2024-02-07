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
    public partial class maas : Form
    {
        public maas()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\MyDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fonk()
        {
            if (IDTb.Text=="")
            {
                MessageBox.Show("Personel ID giriniz!");
            }
            else
            {
                Con.Open();
                string query = "select * from EmployeeTbl where ID='" + IDTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    empnameTb.Text = dr["AdSoyad"].ToString();
                    empposTb.Text = dr["Pozisyon"].ToString();

                }

                Con.Close();
            }
        }

        private void maas_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fonk();
        }

        int gunluk,toplam;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("       MAAŞ BİLGİLERİ       ", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(240));
            e.Graphics.DrawString("Personel ID: " + IDTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50, 130));
            e.Graphics.DrawString("Pozisyon: " + empposTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50, 170));
            e.Graphics.DrawString("Ad Soyad: " + empnameTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50, 210));
            e.Graphics.DrawString("Çalışılan Gün: " + empdayTb.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50, 250));
            e.Graphics.DrawString("Maaş: " + toplam, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(50, 290));
            e.Graphics.DrawString("       developpedbyedadilek       ", new Font("Century Gothic", 20, FontStyle.Regular), Brushes.Red, new Point(200, 1100));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (empposTb.Text == "")
            {
                MessageBox.Show("Personel ID giriniz!");
            }
            else if (empdayTb.Text == "" || Convert.ToInt32(empdayTb.Text) >= 25)
            {
                MessageBox.Show("Geçerli bir çalışma günü giriniz!");

            }
            else
            {
                if(empposTb.Text== "Yazilim Gelistirme Uzmani")
                {
                    gunluk = 200;
                }
                else if(empposTb.Text == "Proje Yoneticisi") 
                {
                    gunluk = 250;
                }
                else if (empposTb.Text == "Mobil Yazilim Uzmani")
                {
                    gunluk = 250;
                }
                else if (empposTb.Text == "Veritabani Uzmani")
                {
                    gunluk = 300;
                }
                else 
                {
                    gunluk = 300;
                }
                toplam = gunluk * Convert.ToInt32(empdayTb.Text);
                MaasSonuc.Text = "Personel ID:  " +IDTb.Text + "\n"+"Personel Adı:  " + empnameTb.Text + "\n"+"Pozisyon:  " + empposTb.Text + "\n"+"Çalıştığı Gün Sayısı:  " + empdayTb.Text + "\n"+"Günlük:  " + gunluk + "\n"+"Maaş:  " + toplam;
            }
        }
    }
}
