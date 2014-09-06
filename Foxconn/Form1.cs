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
    public partial class Form1 : Form
    {

        public int uph=0;
        public int hours=0;
        public int ot=0;
        public int hedef=0;
        /// <summary>
        /// HEDEF=UPH*(HOURS+OT)
        /// </summary>
        public int engineeringhoursforecast=0;
        public int engstandart=0;
        /// <summary>
        /// ENG HOURS FORECAST = ENG STANDART * (HOURS+OT)
        /// </summary>
        public int pdtotalhours=0;
        public int pdop=0;
        public int pdopot=0;
        /// <summary>
        /// PD TOTAL HOURS= ( PD OP* HOURS)+(PD OP OT* OT)
        /// </summary>
        public float toplamcalismasaati = 0;

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Server=ASIS\SQLEXPRESS;Database=Foxconn;Integrated Security=true");

        public void Guncelle()
        {
            //Güncelle methodunu oluşturma nedenimiz herhangi bir ekleme, silme veya güncelleme işlemi yaptıktan sonra
            //programı kapatıp, açmaya gerek kalmadan listemizin güncel halini görebilmektir. Her işlemden sonra Guncelle() methodunu da
            //ekleyeceğiz.

            listView1.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From Bilgiler", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Takvim"].ToString();
                    Liste.SubItems.Add(reader["CalisanHat"].ToString());
                    Liste.SubItems.Add(reader["Hat"].ToString());
                    Liste.SubItems.Add(reader["Vardiya"].ToString());
                    Liste.SubItems.Add(reader["UPH"].ToString());
                    Liste.SubItems.Add(reader["CalismaSaati"].ToString());
                    Liste.SubItems.Add(reader["OT"].ToString());
                    Liste.SubItems.Add(reader["Pdop"].ToString());
                    Liste.SubItems.Add(reader["Pdopot"].ToString());
                    Liste.SubItems.Add(reader["TotalTime"].ToString());
                    Liste.SubItems.Add(reader["EngineeringStandart"].ToString());
                    Liste.SubItems.Add(reader["Hedef"].ToString());
                    Liste.SubItems.Add(reader["Gerceklesen"].ToString());
                    Liste.SubItems.Add(reader["Planli"].ToString());
                    Liste.SubItems.Add(reader["Plansiz"].ToString());
                    Liste.SubItems.Add(reader["Rapor"].ToString());
                    Liste.SubItems.Add(reader["EngineeringStdForecast"].ToString());
                    Liste.SubItems.Add(reader["Downtimes"].ToString());
                    listView1.Items.Add(Liste);
                    toplamcalismasaati += float.Parse(reader["CalismaSaati"].ToString());
                    lblcalismasaati.Text = toplamcalismasaati.ToString();

                    //@Takvim,@CalisanHat,@Hat,@Vardiya,@UPH,@CalismaSaati,@OT,@Pdop,@PdopOTCalisan,
                    //@TotalTime,@EngineeringStandart,@Hedef,@Gerceklesen,@Planli,@Plansiz,@Rapor,@EngineeringStdForecast,@Downtimes
                }
            }
            reader.Close();
            baglanti.Close();
            //bağlantıyı kapattık. Dikkat edilmesi gereken bir nokta da işlem bittikten sonra mutlaka bağlantı kapatılmalıdır.
            //aksi halde programımız bir sonraki komutta hata verecektir.
        }

        private void btnrepair_Click(object sender, EventArgs e)
        {
            try
            {
                /*string isim = textBox1.Text.Trim();
                string soyad = textBox2.Text.Trim();
                string eposta = textBox3.Text.Trim();*/

                /*if (isim == "" || soyad == "" || eposta == "" || comboBox1.SelectedIndex == 0)
                {
                    MessageBox.Show("Lütfen bilgileri doldurunuz.", "Hata!");
                }
                else if (eposta.Contains('@') == false || eposta.Contains(".com") == false) //İçerisinde @ veya .com olmayan e-posta adreslerini kabul etmesin.
                {
                    MessageBox.Show("Lütfen düzgün bir E-Posta adresi giriniz.", "Hata!");
                }

                else
                {*/
                    /*ListViewItem Liste = new ListViewItem();

                    Liste.Text = isim;
                    Liste.SubItems.Add(soyad);
                    Liste.SubItems.Add(eposta);
                    Liste.SubItems.Add(comboBox1.Text);*/

                SqlCommand comm = new SqlCommand("Insert Into repair values (@Tarih,@Vardiya,@CalismaSaati,@Input,@Hw,@Sw,@Te,@Scretched,@OnSite,@FPF,@MTTR)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.
                    comm.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.ToString());
                    comm.Parameters.AddWithValue("@Vardiya", "formül");
                    comm.Parameters.AddWithValue("@CalismaSaati", toplamcalismasaati);
                    comm.Parameters.AddWithValue("@Input", "frsd");
                    comm.Parameters.AddWithValue("@Hw", "fre");
                    comm.Parameters.AddWithValue("@Sw", "rfe");
                    comm.Parameters.AddWithValue("@Te", "frv");
                    comm.Parameters.AddWithValue("@Scretched", "rfd");
                    comm.Parameters.AddWithValue("@OnSite", "rfsd");
                    comm.Parameters.AddWithValue("@FPF", "dsr");
                    comm.Parameters.AddWithValue("@MTTR", "vgrfs");
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    //Guncelle();
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }

            Repair repairForm = new Repair();
            repairForm.Show();//Kullancı adı ve şifre doğru ise giriş yap

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Ekle();
            Guncelle();
            //tbhedef.Text = hedef.ToString();

            calisanHat();
            hat();
            vardiya();
            calismaSaati();
            overtime();
        }

        private void overtime()
        {
            cbot.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From oT", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    cbot.Items.Add(Liste.Text);
                }
            }
            reader.Close();
            baglanti.Close();
        }

        private void calismaSaati()
        {
            cbcalismasaati.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From calismaSaati", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    cbcalismasaati.Items.Add(Liste.Text);
                }
            }
            reader.Close();
            baglanti.Close();
        }

        private void vardiya()
        {
            cbvardiya.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From vardiya", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    cbvardiya.Items.Add(Liste.Text);
                }
            }
            reader.Close();
            baglanti.Close();
        }

        private void hat()
        {
            cbhat.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From hat", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    cbhat.Items.Add(Liste.Text);
                }
            }
            reader.Close();
            baglanti.Close();
        }

        private void calisanHat()
        {
            cbcalisanhat.Items.Clear();
            SqlCommand sorgu = new SqlCommand("Select*From calisanHat", baglanti);
            baglanti.Open(); //Bağlantıyı açtık.
            SqlDataReader reader = sorgu.ExecuteReader(); //Select sorgumuz sonucunda dönen değerleri SqlDataReader ile okuyoruz.

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem Liste = new ListViewItem();
                    Liste.Tag = reader["ID"];
                    Liste.Text = reader["Name"].ToString();
                    cbcalisanhat.Items.Add(Liste.Text);
                }
            }
            reader.Close();
            baglanti.Close();
        }

        public void Ekle()
        {
            string date = dateTimePicker1.Value.ToShortDateString();
            uph = int.Parse("3");
            hours = Int32.Parse("5");
            ot = Int32.Parse("2");
            hedef = uph * (hours + ot);
            tbhedef.Text = Convert.ToString(hedef);

            if (cbcalisanhat.Text == "PRETEST")
            {
                tbdowntimes.Visible = false;
            }

            tbdowntimes.Text = date;

        }

        private void btncid_Click(object sender, EventArgs e)
        {
            CID cidForm = new CID();
            cidForm.Show();
        }

        private void btnproductionsummary_Click(object sender, EventArgs e)
        {
            ProductionSummary productionsummaryForm = new ProductionSummary();
            productionsummaryForm.Show();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            /**/try
            {
                string uph = tbuph.Text.Trim();
                string pdop = tbpdop.Text.Trim();
                string pdopotcalisanadet = tbpdopotcalisanadet.Text.Trim();
                string totaltime = tbtotaltime.Text.Trim();
                string engstdop = tbengineeringstandartop.Text.Trim();
                string hedef = tbhedef.Text.Trim();
                string gerceklesen = tbgerceklesen.Text.Trim();
                string planli = tbplanli.Text.Trim();
                string plansiz = tbplansiz.Text.Trim();
                string rapor = tbrapor.Text.Trim();
                string engineeringstandartforecast = tbengineeringstandartforecast.Text.Trim();
                string downtime = tbdowntimes.Text.Trim();





                if (uph == "" /*|| pdop == "" || pdopotcalisanadet == "" || totaltime == "" || engstdop == "" || hedef == "" || 
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
                    hedef = ((float.Parse(uph))* (float.Parse(cbcalismasaati.Text) + float.Parse(cbot.Text))).ToString();
                    engineeringstandartforecast = ((float.Parse(engstdop)) * (float.Parse(cbcalismasaati.Text) + float.Parse(cbot.Text))).ToString();
                    totaltime = ((float.Parse(pdop)*(float.Parse(cbcalismasaati.Text))) + (float.Parse(pdopotcalisanadet) * float.Parse(cbot.Text))).ToString();

                    ListViewItem Liste = new ListViewItem();

                    Liste.Text = dateTimePicker1.Value.ToString();
                    Liste.SubItems.Add(cbcalisanhat.Text);
                    Liste.SubItems.Add(cbhat.Text);
                    Liste.SubItems.Add(cbvardiya.Text);
                    Liste.SubItems.Add(uph);
                    Liste.SubItems.Add(cbcalismasaati.Text);
                    Liste.SubItems.Add(cbot.Text);
                    Liste.SubItems.Add(pdop);
                    Liste.SubItems.Add(pdopotcalisanadet);
                    Liste.SubItems.Add(totaltime);
                    Liste.SubItems.Add(engstdop);
                    Liste.SubItems.Add(hedef);
                    Liste.SubItems.Add(gerceklesen);
                    Liste.SubItems.Add(planli);
                    Liste.SubItems.Add(plansiz);
                    Liste.SubItems.Add(rapor);
                    Liste.SubItems.Add(engineeringstandartforecast);
                    Liste.SubItems.Add(downtime);


                    SqlCommand comm = new SqlCommand("Insert Into bilgiler values (@Takvim,@CalisanHat,@Hat,@Vardiya,@UPH,@CalismaSaati,@OT,@Pdop,@Pdopot,@TotalTime,@EngineeringStandart,@Hedef,@Gerceklesen,@Planli,@Plansiz,@Rapor,@EngineeringStdForecast,@Downtimes)", baglanti);
                    //Sql sorgumuzdaki parametreleri dolduruyoruz. örnek: @Isim parametresine gelecek değer textBox1'in Text'idir gibi.

                    comm.Parameters.AddWithValue("@Takvim", dateTimePicker1.Value.ToString());
                    comm.Parameters.AddWithValue("@CalisanHat", cbcalisanhat.Text);
                    comm.Parameters.AddWithValue("@Hat", cbhat.Text);
                    comm.Parameters.AddWithValue("@Vardiya", cbvardiya.Text);
                    comm.Parameters.AddWithValue("@UPH", uph);
                    comm.Parameters.AddWithValue("@CalismaSaati", cbcalismasaati.Text);
                    comm.Parameters.AddWithValue("@OT", cbot.Text);
                    comm.Parameters.AddWithValue("@Pdop", pdop);
                    comm.Parameters.AddWithValue("@Pdopot", pdopotcalisanadet);
                    comm.Parameters.AddWithValue("@TotalTime", totaltime);
                    comm.Parameters.AddWithValue("@EngineeringStandart", engstdop);
                    comm.Parameters.AddWithValue("@Hedef", hedef);
                    comm.Parameters.AddWithValue("@Gerceklesen", gerceklesen);
                    comm.Parameters.AddWithValue("@Planli", planli);
                    comm.Parameters.AddWithValue("@Plansiz", plansiz);
                    comm.Parameters.AddWithValue("@Rapor", rapor);
                    comm.Parameters.AddWithValue("@EngineeringStdForecast", engineeringstandartforecast);
                    comm.Parameters.AddWithValue("@Downtimes", downtime);
                    baglanti.Open(); //Bağlantıyı açıyoruz.
                    comm.ExecuteNonQuery(); //Komutu çalıştırıyoruz.
                    baglanti.Close(); //Ve sonra bağlantıyı kapatıyoruz.
                    Guncelle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!"); //Uygulamamız hataya düşerse diye burada hata mesajını veriyoruz.
            }/**/
        }
        /// <summary>
        /// Bu bölümde de ListView üzerinden hangi kişiyi seçersek Textbox kontrollerine ve Combobox kontrolüne o kişinin bilgileri gelecek.
        /// Bunu yapmamızdaki amaç bir kişiyi güncellerken bilgilerini tekrar yazmak yerine otomatik olarak gelmesi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Parse(e.Item.Text);
            cbcalisanhat.Text = e.Item.SubItems[1].Text;
            cbhat.Text = e.Item.SubItems[2].Text;
            cbvardiya.Text = e.Item.SubItems[3].Text;
            tbuph.Text = e.Item.SubItems[4].Text;
            cbcalismasaati.Text=e.Item.SubItems[5].Text;
            cbot.Text=e.Item.SubItems[6].Text;
            tbpdop.Text=e.Item.SubItems[7].Text;
            tbpdopotcalisanadet.Text=e.Item.SubItems[8].Text;
            tbtotaltime.Text=e.Item.SubItems[9].Text;
            tbengineeringstandartop.Text=e.Item.SubItems[10].Text;
            tbhedef.Text = e.Item.SubItems[11].Text;
            tbgerceklesen.Text = e.Item.SubItems[12].Text;
            tbplanli.Text = e.Item.SubItems[13].Text;
            tbplansiz.Text = e.Item.SubItems[14].Text;
            tbrapor.Text = e.Item.SubItems[15].Text;
            tbengineeringstandartforecast.Text = e.Item.SubItems[16].Text;
            tbdowntimes.Text = e.Item.SubItems[17].Text;

            //btnkaydet.Enabled = false;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Kişinin üstüne çift tıklayınca detay penceresi açılsın.

            Detay d = new Detay();

            int KisiID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            SqlCommand sorgu = new SqlCommand("Select*From bilgiler Where ID=" + KisiID, baglanti);
            baglanti.Open();
            SqlDataReader rdr = sorgu.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    
                    d.tb1.Text = rdr["Takvim"].ToString();
                    d.tb2.Text = rdr["CalisanHat"].ToString();
                    d.tb3.Text = rdr["Hat"].ToString();
                    d.tb4.Text = rdr["Vardiya"].ToString();
                    d.tb5.Text = rdr["UPH"].ToString();
                    d.tb6.Text = rdr["CalismaSaati"].ToString();
                    d.tb7.Text = rdr["OT"].ToString();
                    d.tb8.Text = rdr["Pdop"].ToString();
                    d.tb9.Text = rdr["Pdopot"].ToString();
                    d.tb10.Text = rdr["TotalTime"].ToString();
                    d.tb11.Text = rdr["EngineeringStandart"].ToString();
                    d.tb12.Text = rdr["Hedef"].ToString();
                    d.tb13.Text = rdr["Gerceklesen"].ToString();
                    d.tb14.Text = rdr["Planli"].ToString();
                    d.tb15.Text = rdr["Plansiz"].ToString();
                    d.tb16.Text = rdr["Rapor"].ToString();
                    d.tb17.Text = rdr["EngineeringStdForecast"].ToString();
                    d.tb18.Text = rdr["Downtimes"].ToString();
                }
            }
            rdr.Close();
            baglanti.Close();

            d.Show();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string uph = tbuph.Text.Trim();
                string pdop = tbpdop.Text.Trim();
                string pdopotcalisanadet = tbpdopotcalisanadet.Text.Trim();
                string totaltime = tbtotaltime.Text.Trim();
                string engstdop = tbengineeringstandartop.Text.Trim();
                string hedef = tbhedef.Text.Trim();
                string gerceklesen = tbgerceklesen.Text.Trim();
                string planli = tbplanli.Text.Trim();
                string plansiz = tbplansiz.Text.Trim();
                string rapor = tbrapor.Text.Trim();
                string engineeringstandartforecast = tbengineeringstandartforecast.Text.Trim();
                string downtime = tbdowntimes.Text.Trim();

                if (uph == "" /*|| pdop == "" || pdopotcalisanadet == "" || totaltime == "" || engstdop == "" || hedef == "" || 
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

                    int ID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                    SqlCommand comm = new SqlCommand("Update bilgiler Set Takvim=@Takvim, CalisanHat=@CalisanHat, Hat=@Hat,Vardiya=@Vardiya, UPH=@UPH, CalismaSaati=@CalismaSaati,OT=@OT, Pdop=@Pdop, Pdopot=@Pdopot,TotalTime=@TotalTime, EngineeringStandart=@EngineeringStandart,Hedef=@Hedef, Gerceklesen=@Gerceklesen, Planli=@Planli,Plansiz=@Plansiz, Rapor=@Rapor, EngineeringStdForecast=@EngineeringStdForecast,Downtimes=@Downtimes where ID=" + ID, baglanti);
                    //(@Takvim,@CalisanHat,@Hat,@Vardiya,@UPH,@CalismaSaati,@OT,@Pdop,@Pdopot,@TotalTime,@EngineeringStandart,@Hedef,@Gerceklesen,@Planli,@Plansiz,@Rapor,@EngineeringStdForecast,@Downtimes)
                    comm.Parameters.AddWithValue("@Takvim", dateTimePicker1.Value.ToString());
                    comm.Parameters.AddWithValue("@CalisanHat", cbcalisanhat.Text);
                    comm.Parameters.AddWithValue("@Hat", cbhat.Text);
                    comm.Parameters.AddWithValue("@Vardiya", cbvardiya.Text);
                    comm.Parameters.AddWithValue("@UPH", uph);
                    comm.Parameters.AddWithValue("@CalismaSaati", cbcalismasaati.Text);
                    comm.Parameters.AddWithValue("@OT", cbot.Text);
                    comm.Parameters.AddWithValue("@Pdop", pdop);
                    comm.Parameters.AddWithValue("@Pdopot", pdopotcalisanadet);
                    comm.Parameters.AddWithValue("@TotalTime", totaltime);
                    comm.Parameters.AddWithValue("@EngineeringStandart", engstdop);
                    comm.Parameters.AddWithValue("@Hedef", hedef);
                    comm.Parameters.AddWithValue("@Gerceklesen", gerceklesen);
                    comm.Parameters.AddWithValue("@Planli", planli);
                    comm.Parameters.AddWithValue("@Plansiz", plansiz);
                    comm.Parameters.AddWithValue("@Rapor", rapor);
                    comm.Parameters.AddWithValue("@EngineeringStdForecast", engineeringstandartforecast);
                    comm.Parameters.AddWithValue("@Downtimes", downtime);

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

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                //Seçtiğimiz kişiyi siliyoruz.
                SqlCommand comm = new SqlCommand("Delete From bilgiler Where ID=" + ID, baglanti);
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
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item is ComboBox)
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

        private void tbuph_TextChanged(object sender, EventArgs e)
        {/*
            if (tbuph.Text.Length == 0)
            {
                hedef = 0;
            }
            uph = int.Parse(tbuph.Text);
            hedef += uph;
            uph = 0;
            tbhedef.Text = hedef.ToString();*/
           // MessageBox.Show(uph.ToString(), "Hata!");

        }

        private void cbcalismasaati_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            hours = int.Parse(cbcalismasaati.Text);
            hedef += hours;
            tbhedef.Text = hedef.ToString();*/
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yardım yf = new Yardım();
            yf.Show();
        }

        private void verileriGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerileriGuncelle vg = new VerileriGuncelle();
            vg.Show();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkında hf = new Hakkında();
            hf.Show();
        }
    }
}
