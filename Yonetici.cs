using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etüt_merkezi_programı
{
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
  
            Yonetici_ogr ogrenci = new Yonetici_ogr();
            ogrenci.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yonetici_ogretmen ogretmen = new Yonetici_ogretmen();
            ogretmen.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yonetici_veli veli = new Yonetici_veli();
            veli.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
