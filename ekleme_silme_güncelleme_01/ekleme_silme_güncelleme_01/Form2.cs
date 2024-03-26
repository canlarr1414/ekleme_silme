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
namespace ekleme_silme_güncelleme_01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.OleDB.4.0;Data Source=ogr_01.mdb");
        OleDbDataAdapter data;
        void listele()
        {
            baglanti.Open();
            data = new OleDbDataAdapter("SELECT *FROM sinif",baglanti);
            DataTable tablo = new DataTable();
            data.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        Random rnd = new Random();
        
        private void button2_Click(object sender, EventArgs e)
        {
            //random
            int rst = rnd.Next(9, 12);
            textBox1.Text = rst.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
           string sorgu = "INSERT INTO sinif(hangi_sinif,kacinci_sinif) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"')";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
             }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
