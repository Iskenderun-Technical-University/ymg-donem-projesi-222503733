using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace etüt_merkezi_programı
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();

        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        private void button2_Click(object sender, EventArgs e)
        {

        }
        public partial class Ogrenci : Form
        {
            public string Ad { get; set; }
            public string SinavSonuclari { get; internal set; }

            // Rest of the code for the Ogrenci class
            // ...
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = textBox1.Text;
            string sifre = textBox2.Text;
            string tur = comboBox1.SelectedItem.ToString();

            using (OleDbConnection db_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb"))
            {
                db_baglanti.Open();
                OleDbCommand sorgula = new OleDbCommand("SELECT * FROM Kullanicilar WHERE kulad=@KullaniciAdi AND sifre=@Sifre AND tur=@Tur", db_baglanti);
                sorgula.Parameters.AddWithValue("@KullaniciAdi", kullanici);
                sorgula.Parameters.AddWithValue("@Sifre", sifre);
                sorgula.Parameters.AddWithValue("@Tur", tur);

                using (OleDbDataReader oku = sorgula.ExecuteReader())
                {
                    if (oku.Read())
                    {
                        string ogrenciAdi = oku["kulad"].ToString();

                        if (tur == "Öğrenci")
                        {
                            // Retrieve TCNO from the "Ogrenci" table using INNER JOIN
                            OleDbCommand tcnoCommand = new OleDbCommand("SELECT Ogrenci.TCNO FROM Kullanicilar INNER JOIN Ogrenci ON Kullanicilar.TCNO = Ogrenci.TCNO WHERE Kullanicilar.kulad=@KullaniciAdi", db_baglanti);
                            tcnoCommand.Parameters.AddWithValue("@KullaniciAdi", kullanici);
                            string tcno = tcnoCommand.ExecuteScalar()?.ToString();

                            etüt_merkezi_programı.Ogrenci ac = new etüt_merkezi_programı.Ogrenci();
                            ac.Ad = ogrenciAdi;
                            ac.Text = tcno;
                            ac.ShowDialog();
                            this.Hide();
                        }
                        else if (tur == "Öğretmen")
                        {

                            // Retrieve TCNO from the "Ogrenci" table using INNER JOIN
                            OleDbCommand tcnoCommand = new OleDbCommand("SELECT Ogrenci.TCNO FROM Kullanicilar INNER JOIN Ogrenci ON Kullanicilar.TCNO = Ogrenci.TCNO WHERE Kullanicilar.kulad=@KullaniciAdi", db_baglanti);
                            tcnoCommand.Parameters.AddWithValue("@KullaniciAdi", kullanici);
                            string tcno = tcnoCommand.ExecuteScalar()?.ToString();


                            etüt_merkezi_programı.Ogretmen ac = new etüt_merkezi_programı.Ogretmen();
                            ac.Text = tcno;
                            ac.ShowDialog();
                            this.Hide();




                        }
                        else if (tur == "Veli")
                        {
                            // Retrieve TCNO from the "Ogrenci" table using INNER JOIN
                            OleDbCommand tcnoCommand = new OleDbCommand("SELECT Ogrenci.TCNO FROM Kullanicilar INNER JOIN Ogrenci ON Kullanicilar.TCNO = Ogrenci.TCNO WHERE Kullanicilar.kulad=@KullaniciAdi", db_baglanti);
                            tcnoCommand.Parameters.AddWithValue("@KullaniciAdi", kullanici);
                            string tcno = tcnoCommand.ExecuteScalar()?.ToString();


                            etüt_merkezi_programı.Veli ac = new etüt_merkezi_programı.Veli();
                            ac.Text = tcno;
                            ac.ShowDialog();
                            this.Hide();
                                                       
                        }
                        else if (tur == "Yönetici")
                        {
                            Yonetici ac = new Yonetici();
                            ac.ShowDialog();
                            this.Hide();
                        }
                    }
                    else
                    {
                        label3.Text = "Kullanıcı adı, şifre veya tür hatalı! Lütfen yöneticiyle iletişime geçiniz.";
                    }

                    oku.Close();
                    db_baglanti.Close();
                    db_baglanti.Dispose();

                }

            }
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



    

