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

namespace ceza_evi_demo
{
    public partial class mkayıt : Form
    {
        public mkayıt()
        {
            InitializeComponent();
        }
        OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\ceza evi demo\\verimerkezi.mdb");// veri tabanı bağlantısı
        OleDbCommand komut = new OleDbCommand();
        private void mahkumverigöster()   ///başlangıç
                                    ///mahkum için veri gösterme metodu %%%  SADECE MAHKUM %%%
        {
            listView1.Items.Clear();
            bağlantı.Open();                                ///veritabnı açılışı
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bağlantı;
            komut.CommandText = "Select * From mahkum";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kimlikno"].ToString();
                ekle.SubItems.Add(oku["adı"].ToString());
                ekle.SubItems.Add(oku["soyadı"].ToString());
                ekle.SubItems.Add(oku["dtarihi"].ToString());
                ekle.SubItems.Add(oku["dyeri"].ToString());
                ekle.SubItems.Add(oku["adresi"].ToString());
                ekle.SubItems.Add(oku["suçu"].ToString());
                ekle.SubItems.Add(oku["cezası"].ToString());

                listView1.Items.Add(ekle);
            }
            bağlantı.Close();       ///bitiş     ///veritabanı kapnışı
        }
        private void button4_Click(object sender, EventArgs e)
        {
            müdür anasahife = new müdür();
            anasahife.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)   ///kayıt butonu
        {
            bağlantı.Open();
            OleDbCommand komut = new OleDbCommand("insert into mahkum (kimlikno,adı,soyadı,dtarihi,dyeri,adresi,suçu,cezası) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            mahkumverigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mahkumverigöster();
        }

        private void button3_Click(object sender, EventArgs e)  /// silme butonu
        {
            bağlantı.Open();
            komut.Connection = bağlantı;
            komut.CommandText = "delete from mahkum where kimlikno='" + textBox9.Text + "'";
            komut.ExecuteNonQuery();
            bağlantı.Close();
            mahkumverigöster();
        }

        private void button6_Click(object sender, EventArgs e)   ///güncelleme butonu
        {
            bağlantı.Open();
            komut.Connection = bağlantı;
            komut.CommandText="update mahkum set adı='" + textBox2.Text + "',soyadı='" + textBox3.Text + "',dtarihi='" + textBox4.Text + "',dyeri='" + textBox5.Text + "',adresi='" + textBox6.Text + "',suçu='" + textBox7.Text + "',cezası='" + textBox8.Text + "'where kimlikno='"+textBox1.Text+"'";
            komut.ExecuteNonQuery();
            bağlantı.Close();
            mahkumverigöster();
        }
    }
}
