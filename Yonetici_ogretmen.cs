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
    public partial class Yonetici_ogretmen : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public Yonetici_ogretmen()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
            da = new OleDbDataAdapter("SELECT Ogretmen.TCNO,Kisiler.Ad, Kisiler.Soyad,Kisiler.Adres, Kisiler.Telefon, Kisiler.Grubu, Ogretmen.TCNO, Ogretmen.Brans, Ogretmen.Maas, Ogretmen.Dersprogramı, Ogretmen.Deneyim, Ogretmen.Sinif FROM Ogretmen INNER JOIN Kisiler ON Ogretmen.TCNO = Kisiler.TCNO", con);
            ds = new DataSet();

            // Parametrelerinizi belirtin
            da.SelectCommand.Parameters.AddWithValue("@TCNO", txtOgrenciTCNO.Text);
            // Diğer parametreleri de ekleyin

            con.Open();
            da.Fill(ds, "Ogrenci");
            dataGridView1.DataSource = ds.Tables["Ogrenci"];
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici yönetici = new Yonetici();
            yönetici.Show();
            this.Hide();
        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Kisiler (TCNO, Ad, Soyad, Adres, Telefon,Grubu) VALUES ('" + txtOgrenciTCNO.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtAdres.Text + "','" + txtTelefon.Text + "','" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO Ogretmen (TCNO, Brans, Maas, Dersprogramı, Deneyim, Sinif) VALUES ('" + txtOgrenciTCNO.Text + "', '" + txtBrans.Text + "','" + txtMaas.Text + "','" + txtprogram.Text + "','" + txtDeneyim.Text + "','" + txtSinif.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            griddoldur();
        }

        private void buttonxxx_Click(object sender, EventArgs e)
        {
            Yonetici anasayfa = new Yonetici();
            anasayfa.Show();
            this.Hide();
        }
    }
}
