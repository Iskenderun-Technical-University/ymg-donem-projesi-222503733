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
    public partial class Veli : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        public Veli()
        {
            InitializeComponent();
        }

        private void Veli_Load(object sender, EventArgs e)
        {
            string tcno = this.Text;

            label1.Text = tcno;
            using (OleDbConnection db_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbetüt.mdb"))
            {
                db_baglanti.Open();
                OleDbCommand sorgula = new OleDbCommand("SELECT SinavSonucu FROM Veli WHERE TCNO=@TCNO ", db_baglanti);
                sorgula.Parameters.AddWithValue("@TCNO", tcno);
                OleDbDataReader reader = sorgula.ExecuteReader();

                if (reader.Read())
                {
                    string sinavSonucu = reader["SinavSonucu"].ToString();
                    label1.Text = sinavSonucu;
                }
                else
                {
                    label1.Text = "Öğrenci bulunamadı";
                    
                }

                
            }


        }
    }
}
