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
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();

        public string Ad { get; internal set; }

        private void Ogretmen_Load(object sender, EventArgs e)
        {
            string tcno = this.Text;

            label1.Text = tcno;
            using (OleDbConnection db_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb"))
            {
                db_baglanti.Open();
                OleDbCommand sorgula = new OleDbCommand("SELECT SinavProgrami, SinavSonuclari FROM Ogrenci WHERE TCNO=@TCNO ", db_baglanti);
                sorgula.Parameters.AddWithValue("@TCNO", tcno);
                OleDbDataReader reader = sorgula.ExecuteReader();

                if (reader.Read())
                {
                    string sinavProgrami = reader["SinavProgrami"].ToString();
                    string sinavSonuclari = reader["SinavSonuclari"].ToString();
                    label4.Text = sinavProgrami;
                    label1.Text = sinavSonuclari;
                }
                else
                {
                    label1.Text = "Öğrenci bulunamadı";
                    label4.Text = "";
                }
            }

        }
        }
    }

