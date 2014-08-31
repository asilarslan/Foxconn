using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxconn
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Sql Database'imize bağlantımızı kurduk. Global bir değişken olarak tanımladık. Bu sayede her seferinde tekrar bağlantı komutunu yazmamız gerekmeyecek.
        SqlConnection baglan = new SqlConnection(@"Server=ASIS\SQLEXPRESS;Database=Foxconn;Integrated Security=true");

        private void button1_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "Select * from giris WHERE sifre='" + textBox1.Text +  "'";
            baglan.Open();//Bağlantıyı açtık

            SqlDataReader oku = komut.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.
            while (oku.Read())
            {

                kontrol = true;

            }

            baglan.Close();//Bağlantıyı kapattık


            if (kontrol == true)
            {
                this.Hide();//Login formu gizle
                Form1 yoneticiForm = new Form1();
                yoneticiForm.Show();//Kullancı adı ve şifre doğru ise giriş yap
            }

            else
            {

                MessageBox.Show("Giriş Başarısız");//Kullanıcı adı veya şifre yanlış

            }
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool kontrol = false;
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglan;
                komut.CommandText = "Select * from giris WHERE sifre='" + textBox1.Text + "'";
                baglan.Open();//Bağlantıyı açtık

                SqlDataReader oku = komut.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.
                while (oku.Read())
                {

                    kontrol = true;

                }

                baglan.Close();//Bağlantıyı kapattık


                if (kontrol == true)
                {
                    this.Hide();//Login formu gizle
                    Form1 yoneticiForm = new Form1();
                    yoneticiForm.Show();//Kullancı adı ve şifre doğru ise giriş yap
                }

                else
                {

                    MessageBox.Show("Giriş Başarısız");//Kullanıcı adı veya şifre yanlış

                }
            }
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
