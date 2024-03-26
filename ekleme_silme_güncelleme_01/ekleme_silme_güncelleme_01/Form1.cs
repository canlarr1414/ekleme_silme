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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.OleDB.4.0;Data Source=ogr_01.mdb");
        OleDbDataAdapter data;

        void listele()
        {
            //açma
            baglanti.Open();
            data = new OleDbDataAdapter("SELECT *FROM ogrenciler",baglanti);
            DataTable tablo = new DataTable();
            data.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
            string sorgu = "INSERT INTO ogrenciler(ogr_ad,ogr_soyad,ogr_no,ogr_tel)VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"')";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //silme
            string sorgu = "DELETE * FROM ogrenciler WHERE ogr_ad='"+textBox1.Text+"' AND ogr_soyad='"+textBox2.Text+"' AND ogr_no='"+textBox3.Text+"' AND ogr_tel='"+textBox4.Text+"'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelleme
            string sorgu = "UPDATE ogrenciler SET ogr_ad='"+textBox1.Text+"',ogr_soyad='"+textBox2.Text+"',ogr_no='"+textBox3.Text+"',ogr_tel='"+textBox4.Text+"'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //textboxa alma
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
