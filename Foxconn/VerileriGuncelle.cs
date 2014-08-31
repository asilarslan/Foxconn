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
    public partial class VerileriGuncelle : Form
    {
        public VerileriGuncelle()
        {
            InitializeComponent();
        }
        //Sql Database'imize bağlantımızı kurduk. Global bir değişken olarak tanımladık. Bu sayede her seferinde tekrar bağlantı komutunu yazmamız gerekmeyecek.
        SqlConnection baglanti = new SqlConnection(@"Server=ASIS\SQLEXPRESS;Database=Foxconn;Integrated Security=true");

        public void Guncelle()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            listView1.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From CalisanHat", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    listView1.Items.Add(Liste);
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }
        public void Guncelle2()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            listView2.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From Hat", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    listView2.Items.Add(Liste);
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }
        public void Guncelle3()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            listView3.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From Vardiya", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    listView3.Items.Add(Liste);
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }
        public void Guncelle4()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            listView4.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From CalismaSaati", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    listView4.Items.Add(Liste);
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }
        public void Guncelle5()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            listView5.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From OT", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    listView5.Items.Add(Liste);
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }
        private void btn1ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb1.Text.Trim();

                if (isim == "" )
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/

                else
                {
                    ListViewItem Liste = new ListViewItem();

                    Liste.Text = isim;

                    SqlCommand comm = new SqlCommand("Insert Into calisanHat values (@Name)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.
                    comm.Parameters.AddWithValue("@Name", isim);
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    Guncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn1duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb1.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/
                else
                {
                    //Bildiğiniz gibi bir kişiyi silebilmemiz için bize silmek istediğimiz kişinin ID değeri gerekmektedir.
                    //ID değerini ListView'da seçili olan kişinin tag'inden alıyoruz ve Convert işlemini uyguluyoruz.

                    int ID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                    SqlCommand comm = new SqlCommand("Update calisanHat Set Name=@Name where ID=" + ID, baglanti);

                    comm.Parameters.AddWithValue("@Name", isim);

                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery();
                    baglanti.Close(); //Bağlantıyı kapatıyoruz.

                    //Kişiyi güncelledikten sonra textBox kontrollerin sıfırlıyoruz.
                    foreach (Control item in this.groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.ResetText();
                        }
                    }
                    //comboBox1.SelectedIndex = 0;

                    Guncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn1sil_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                //Seçtiğimiz kişiyi siliyoruz.
                SqlCommand comm = new SqlCommand("Delete From calisanHat Where ID=" + ID, baglanti);
                baglanti.Open();
                comm.ExecuteNonQuery();
                baglanti.Close();
                //Kişiyi sildikten sonra textBox kontrollerin sıfırlıyoruz.
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.ResetText();
                    }
                }
                //comboBox1.SelectedIndex = 0;
                Guncelle();
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçiniz.", "Hata!");
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tb1.Text = e.Item.Text;
        }

        private void VerileriGuncelle_Load(object sender, EventArgs e)
        {
            Guncelle();
            Guncelle2();
            Guncelle3();
            Guncelle4();
            Guncelle5();
        }

        
        private void btn2ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb2.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/

                else
                {
                    ListViewItem Liste = new ListViewItem();

                    Liste.Text = isim;

                    SqlCommand comm = new SqlCommand("Insert Into hat values (@Name)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.
                    comm.Parameters.AddWithValue("@Name", isim);
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    Guncelle2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn2duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb2.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/
                else
                {
                    //Bildiğiniz gibi bir kişiyi silebilmemiz için bize silmek istediğimiz kişinin ID değeri gerekmektedir.
                    //ID değerini ListView'da seçili olan kişinin tag'inden alıyoruz ve Convert işlemini uyguluyoruz.

                    int ID = Convert.ToInt32(listView2.SelectedItems[0].Tag);
                    SqlCommand comm = new SqlCommand("Update hat Set Name=@Name where ID=" + ID, baglanti);

                    comm.Parameters.AddWithValue("@Name", isim);

                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery();
                    baglanti.Close(); //Bağlantıyı kapatıyoruz.

                    //Kişiyi güncelledikten sonra textBox kontrollerin sıfırlıyoruz.
                    foreach (Control item in this.groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.ResetText();
                        }
                    }
                    //comboBox1.SelectedIndex = 0;

                    Guncelle2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }

        }

        private void btn2sil_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(listView2.SelectedItems[0].Tag);
                //Seçtiğimiz kişiyi siliyoruz.
                SqlCommand comm = new SqlCommand("Delete From hat Where ID=" + ID, baglanti);
                baglanti.Open();
                comm.ExecuteNonQuery();
                baglanti.Close();
                //Kişiyi sildikten sonra textBox kontrollerin sıfırlıyoruz.
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.ResetText();
                    }
                }
                //comboBox1.SelectedIndex = 0;
                Guncelle2();
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçiniz.", "Hata!");
            }
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tb2.Text = e.Item.Text;
        }

        private void btn3ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb3.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/

                else
                {
                    ListViewItem Liste = new ListViewItem();

                    Liste.Text = isim;

                    SqlCommand comm = new SqlCommand("Insert Into vardiya values (@Name)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.
                    comm.Parameters.AddWithValue("@Name", isim);
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    Guncelle3();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn3duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb3.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/
                else
                {
                    //Bildiğiniz gibi bir kişiyi silebilmemiz için bize silmek istediğimiz kişinin ID değeri gerekmektedir.
                    //ID değerini ListView'da seçili olan kişinin tag'inden alıyoruz ve Convert işlemini uyguluyoruz.

                    int ID = Convert.ToInt32(listView3.SelectedItems[0].Tag);
                    SqlCommand comm = new SqlCommand("Update vardiya Set Name=@Name where ID=" + ID, baglanti);

                    comm.Parameters.AddWithValue("@Name", isim);

                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery();
                    baglanti.Close(); //Bağlantıyı kapatıyoruz.

                    //Kişiyi güncelledikten sonra textBox kontrollerin sıfırlıyoruz.
                    foreach (Control item in this.groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.ResetText();
                        }
                    }
                    //comboBox1.SelectedIndex = 0;

                    Guncelle3();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn3sil_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(listView3.SelectedItems[0].Tag);
                //Seçtiğimiz kişiyi siliyoruz.
                SqlCommand comm = new SqlCommand("Delete From vardiya Where ID=" + ID, baglanti);
                baglanti.Open();
                comm.ExecuteNonQuery();
                baglanti.Close();
                //Kişiyi sildikten sonra textBox kontrollerin sıfırlıyoruz.
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.ResetText();
                    }
                }
                //comboBox1.SelectedIndex = 0;
                Guncelle3();
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçiniz.", "Hata!");
            }
        }

        private void listView3_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tb3.Text = e.Item.Text;
        }

        private void btn4ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb4.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/

                else
                {
                    ListViewItem Liste = new ListViewItem();

                    Liste.Text = isim;

                    SqlCommand comm = new SqlCommand("Insert Into calismaSaati values (@Name)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.
                    comm.Parameters.AddWithValue("@Name", isim);
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    Guncelle4();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn4duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb4.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/
                else
                {
                    //Bildiğiniz gibi bir kişiyi silebilmemiz için bize silmek istediğimiz kişinin ID değeri gerekmektedir.
                    //ID değerini ListView'da seçili olan kişinin tag'inden alıyoruz ve Convert işlemini uyguluyoruz.

                    int ID = Convert.ToInt32(listView4.SelectedItems[0].Tag);
                    SqlCommand comm = new SqlCommand("Update CalismaSaati Set Name=@Name where ID=" + ID, baglanti);

                    comm.Parameters.AddWithValue("@Name", isim);

                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery();
                    baglanti.Close(); //Bağlantıyı kapatıyoruz.

                    //Kişiyi güncelledikten sonra textBox kontrollerin sıfırlıyoruz.
                    foreach (Control item in this.groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.ResetText();
                        }
                    }
                    //comboBox1.SelectedIndex = 0;

                    Guncelle4();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn4sil_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(listView4.SelectedItems[0].Tag);
                //Seçtiğimiz kişiyi siliyoruz.
                SqlCommand comm = new SqlCommand("Delete From calismaSaati Where ID=" + ID, baglanti);
                baglanti.Open();
                comm.ExecuteNonQuery();
                baglanti.Close();
                //Kişiyi sildikten sonra textBox kontrollerin sıfırlıyoruz.
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.ResetText();
                    }
                }
                //comboBox1.SelectedIndex = 0;
                Guncelle4();
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçiniz.", "Hata!");
            }
        }

        private void listView4_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tb4.Text = e.Item.Text;
        }

        private void btn5ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb5.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/

                else
                {
                    ListViewItem Liste = new ListViewItem();

                    Liste.Text = isim;

                    SqlCommand comm = new SqlCommand("Insert Into Ot values (@Name)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.
                    comm.Parameters.AddWithValue("@Name", isim);
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    Guncelle5();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn5duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string isim = tb5.Text.Trim();

                if (isim == "")
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/
                else
                {
                    //Bildiğiniz gibi bir kişiyi silebilmemiz için bize silmek istediğimiz kişinin ID değeri gerekmektedir.
                    //ID değerini ListView'da seçili olan kişinin tag'inden alıyoruz ve Convert işlemini uyguluyoruz.

                    int ID = Convert.ToInt32(listView5.SelectedItems[0].Tag);
                    SqlCommand comm = new SqlCommand("Update oT Set Name=@Name where ID=" + ID, baglanti);

                    comm.Parameters.AddWithValue("@Name", isim);

                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery();
                    baglanti.Close(); //Bağlantıyı kapatıyoruz.

                    //Kişiyi güncelledikten sonra textBox kontrollerin sıfırlıyoruz.
                    foreach (Control item in this.groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.ResetText();
                        }
                    }
                    //comboBox1.SelectedIndex = 0;

                    Guncelle5();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }
        }

        private void btn5sil_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(listView5.SelectedItems[0].Tag);
                //Seçtiğimiz kişiyi siliyoruz.
                SqlCommand comm = new SqlCommand("Delete From oT Where ID=" + ID, baglanti);
                baglanti.Open();
                comm.ExecuteNonQuery();
                baglanti.Close();
                //Kişiyi sildikten sonra textBox kontrollerin sıfırlıyoruz.
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.ResetText();
                    }
                }
                //comboBox1.SelectedIndex = 0;
                Guncelle5();
            }
            catch
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçiniz.", "Hata!");
            }
        }

        private void listView5_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tb5.Text = e.Item.Text;
        }
    }
}
