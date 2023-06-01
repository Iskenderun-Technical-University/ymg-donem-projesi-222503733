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
    public partial class Ogretmen : Form
    {
        public Ogretmen()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();

        private void Ogretmen_Load(object sender, EventArgs e)
        {
            string tcno = this.Text;

            //label2.Text = tcno;
            using (OleDbConnection db_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb"))
            {
                db_baglanti.Open();
                OleDbCommand sorgula = new OleDbCommand("SELECT Dersprogramı FROM Ogretmen WHERE TCNO=@TCNO ", db_baglanti);
                sorgula.Parameters.AddWithValue("@TCNO", tcno);
                OleDbDataReader reader = sorgula.ExecuteReader();

                if (reader.Read())
                {
                    string Dersprogramı = reader["Dersprogramı"].ToString();
                    //string sinavSonuclari = reader["SinavSonuclari"].ToString();
                    label3.Text = Dersprogramı;
                    //label1.Text = sinavSonuclari;
                }
                else
                {
                    label3.Text = "Öğrenci bulunamadı";
                   
                }
            }
        }
    }
}
