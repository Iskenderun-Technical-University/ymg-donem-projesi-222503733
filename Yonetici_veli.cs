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
    public partial class Yonetici_veli : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public Yonetici_veli()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici yönetici = new Yonetici();
            yönetici.Show();
            this.Hide();
        }
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
            da = new OleDbDataAdapter("SELECT Veli.TCNO,Kisiler.Ad, Kisiler.Soyad,Kisiler.Adres, Kisiler.Telefon, Kisiler.Grubu, Veli.TCNO, Veli.OgrenciTCNO, Veli.SinavSonuclari FROM Veli INNER JOIN Kisiler ON Veli.TCNO = Kisiler.TCNO", con);
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

            cmd.CommandText = "INSERT INTO Veli (TCNO, OgrenciTCNO, SinavSonucu) VALUES ('" + txtOgrenciTCNO.Text + "', '" + txtOgrenci.Text + "','" + txtSonuc.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            griddoldur();
        }
    }
    }

