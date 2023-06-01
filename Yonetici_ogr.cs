using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;  // Access bağlantısı kurabilmek için.

namespace etüt_merkezi_programı
{
    public partial class Yonetici_ogr : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public class Kisi
        {
            public string TCNO { get; set; }
        }

        // Çocuk sınıf
        public class Ogrenci : Kisi
        {
            public string OkulNo { get; set; }
            public string Sinifi { get; set; }
            public string SinavSonuclari { get; set; }
        }
        public Yonetici_ogr()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
            da = new OleDbDataAdapter("SELECT Ogrenci.TCNO,Kisiler.Ad, Kisiler.Soyad,Kisiler.Adres, Kisiler.Telefon, Kisiler.Grubu, Ogrenci.OkulNo, Ogrenci.Sinifi, Ogrenci.SinavSonuclari, Ogrenci.SinavProgrami FROM Ogrenci INNER JOIN Kisiler ON Ogrenci.TCNO = Kisiler.TCNO", con);
            ds = new DataSet();

            // Parametrelerinizi belirtin
            da.SelectCommand.Parameters.AddWithValue("@TCNO", txtOgrenciTCNO.Text);
            // Diğer parametreleri de ekleyin

            con.Open();
            da.Fill(ds, "Ogrenci");
            dataGridView1.DataSource = ds.Tables["Ogrenci"];
            con.Close();

        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Kisiler (TCNO, Ad, Soyad, Adres, Telefon,Grubu) VALUES ('" + txtOgrenciTCNO.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtAdres.Text + "','" + txtTelefon.Text + "','" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO Ogrenci (TCNO, OkulNo, Sinifi, SinavSonuclari,SinavProgrami) VALUES ('" + txtOgrenciTCNO.Text + "','" + txtOkulNumarasi.Text + "','" + txtSinifi.Text + "','" + txtSinavSonuclari.Text + "','" + txtSinavProgrami.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            griddoldur();
        }

        private void buttonxxx_Click(object sender, EventArgs e)
        {
            Yonetici yönetici = new Yonetici();
            yönetici.Show();
            this.Hide();
        }

        private void Yonetici_ogr_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
    }
}
