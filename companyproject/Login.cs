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
    

    public partial class Login : Form
    {

        //diğer forma değeri gönderebilmek için
        public static string pas = "";


        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pas = kulAdTb.Text;
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "select * from LoginTbl where ID= '" + kulAdTb.Text + "' and Sifre= '" + sifreTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

         
            if (kulAdTb.Text=="" || sifreTb.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz!");
            }
            else if(kulAdTb.Text=="Admin" && sifreTb.Text=="1234")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else if (dt.Rows.Count==1)

            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kulAdTb.Clear();
            sifreTb.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
