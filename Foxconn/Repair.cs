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
    public partial class Repair : Form
    {
        public int ID;
        public Repair()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=ASIS\SQLEXPRESS;Database=Foxconn;Integrated Security=true");

        private void Repair_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        public void Guncelle()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            //listView1.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From repair", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Tarih"].ToString();
                    Liste.SubItems.Add(reader["Vardiya"].ToString());
                    Liste.SubItems.Add(reader["CalismaSaati"].ToString());
                    Liste.SubItems.Add(reader["Input"].ToString());
                    Liste.SubItems.Add(reader["Hw"].ToString());
                    Liste.SubItems.Add(reader["Sw"].ToString());
                    Liste.SubItems.Add(reader["Te"].ToString());
                    Liste.SubItems.Add(reader["Scretched"].ToString());
                    Liste.SubItems.Add(reader["OnSite"].ToString());
                    Liste.SubItems.Add(reader["FPF"].ToString());
                    Liste.SubItems.Add(reader["MTTR"].ToString());
                    ID = int.Parse(reader["ID"].ToString());
                    
                   
                    dateTimePicker1.Value = DateTime.Parse(Liste.SubItems[0].Text);
                    cbvardiya.Text = Liste.SubItems[1].Text;
                    tbcalismasaati.Text = Liste.SubItems[2].Text;
                    tbinput.Text = Liste.SubItems[3].Text;
                    tbhw.Text = Liste.SubItems[4].Text;
                    tbsw.Text = Liste.SubItems[5].Text;
                    tbte.Text = Liste.SubItems[6].Text;
                    tbscretched.Text = Liste.SubItems[7].Text;
                    tbonsite.Text = Liste.SubItems[8].Text;
                    tbfpf.Text = Liste.SubItems[9].Text;
                    tbmttr.Text = Liste.SubItems[10].Text;
                    //listView1.Items.Add(Liste);
                    //@Takvim,@CalisanHat,@Hat,@Vardiya,@UPH,@CalismaSaati,@OT,@Pdop,@PdopOTCalisan,
                    //@TotalTime,@EngineeringStandart,@Hedef,@Gerceklesen,@Planli,@Plansiz,@Rapor,@EngineeringStdForecast,@Downtimes
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string tarih = dateTimePicker1.Value.ToString();
                string vardiya = cbvardiya.Text.Trim();
                string calismasaati = tbcalismasaati.Text.Trim();
                string input = tbinput.Text.Trim();
                string hw = tbhw.Text.Trim();
                string sw = tbsw.Text.Trim();
                string te = tbte.Text.Trim();
                string scretched  = tbscretched.Text.Trim();
                string onsite = tbonsite.Text.Trim();
                string fpf = tbfpf.Text.Trim();
                string mttr = tbmttr.Text.Trim();

                if (tarih == "" /*|| pdop == "" || pdopotcalisanadet == "" || totaltime == "" || engstdop == "" || hedef == "" || 
                    gerceklesen == "" || planli == "" || plansiz == "" || rapor == "" || engineeringstandartforecast == "" || 
                    downtime == "" || cbcalisanhat.SelectedIndex == 0 || cbhat.SelectedIndex==0 || cbvardiya.SelectedIndex==0 ||
                    cbcalismasaati.SelectedIndex==0 || cbot.SelectedIndex==0*/)
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                /*else if (pdopotcalisanadet.Contains('@') == false || pdopotcalisanadet.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }*/
                else
                {
                    //Bildiğiniz gibi bir kişiyi silebilmemiz için bize silmek istediğimiz kişinin ID değeri gerekmektedir.
                    //ID değerini ListView'da seçili olan kişinin tag'inden alıyoruz ve Convert işlemini uyguluyoruz.

                    SqlCommand comm = new SqlCommand("Update bilgiler Set Tarih=@Tarih, Vardiya=@Vardiya, CalismaSaati=@CalismaSaati,Input=@Input, Hw=@Hw, Sw=@Sw,Te=@Te, Scretched=@Scretched, OnSite=@OnSite,FPF=@FPF, MTTR=@MTTR where ID=" + ID, baglanti);

                    comm.Parameters.AddWithValue("@Tarih", tarih);
                    comm.Parameters.AddWithValue("@Vardiya", vardiya);
                    comm.Parameters.AddWithValue("@CalismaSaati", calismasaati);
                    comm.Parameters.AddWithValue("@Input", input);
                    comm.Parameters.AddWithValue("@Hw", hw);
                    comm.Parameters.AddWithValue("@Sw", sw);
                    comm.Parameters.AddWithValue("@Te", te);
                    comm.Parameters.AddWithValue("@Scretched", scretched);
                    comm.Parameters.AddWithValue("@OnSite", onsite);
                    comm.Parameters.AddWithValue("@FPF", fpf);
                    comm.Parameters.AddWithValue("@MTTR", mttr);

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
    }
}
