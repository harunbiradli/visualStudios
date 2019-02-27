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
    public partial class memurzkayıt : Form
    {
        public memurzkayıt()
        {
            InitializeComponent();
        }
        OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\ceza evi demo\\verimerkezi.mdb");// veri tabanı bağlantısı
        OleDbCommand komut = new OleDbCommand();
        private void ziyaretçiverigöster()   ///başlangıç
        ///mahkum için veri gösterme metodu %%%  SADECE ZİYARETÇİ %%%
        {
            listView1.Items.Clear();
            bağlantı.Open();                                ///veritabnı açılışı
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bağlantı;
            komut.CommandText = "Select * From ziyaretçi";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kimlikno"].ToString();
                ekle.SubItems.Add(oku["adı"].ToString());
                ekle.SubItems.Add(oku["soyadı"].ToString());
                ekle.SubItems.Add(oku["adresi"].ToString());
                ekle.SubItems.Add(oku["ztip"].ToString());
                ekle.SubItems.Add(oku["zbilgisi"].ToString());

                listView1.Items.Add(ekle);
            }
            bağlantı.Close();       ///bitiş     ///veritabanı kapanışı
        }
        private void button6_Click(object sender, EventArgs e)    ///gösterme butonu
        {
            ziyaretçiverigöster();
        }

        private void button1_Click(object sender, EventArgs e)   ///kayıt butonu
        {
            bağlantı.Open();
            OleDbCommand komut = new OleDbCommand("insert into ziyaretçi (kimlikno,adı,soyadı,adresi,ztip,zbilgisi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            ziyaretçiverigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button5_Click(object sender, EventArgs e)   ///silme butonu
        {
            bağlantı.Open();
            komut.Connection = bağlantı;
            komut.CommandText = "delete from ziyaretçi where kimlikno='" + textBox7.Text + "'";
            komut.ExecuteNonQuery();
            bağlantı.Close();
            ziyaretçiverigöster();
        }

        private void button7_Click(object sender, EventArgs e)   ///güncelleme butonu
        {
            bağlantı.Open();
            komut.Connection = bağlantı;
            komut.CommandText = "update ziyaretçi set adı='" + textBox2.Text + "',soyadı='" + textBox3.Text + "',adresi='" + textBox4.Text + "',ztip='" + textBox5.Text + "',zbilgisi='" + textBox6.Text + "'";
            komut.ExecuteNonQuery();
            bağlantı.Close();
            ziyaretçiverigöster();
        }

        private void button4_Click(object sender, EventArgs e)   ///memur ana menüsü
        {
            memur anasayfa = new memur();
            anasayfa.Show();
            this.Hide();
        }
    }
}
