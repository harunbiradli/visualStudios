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
    public partial class pkayıt : Form
    {
        public pkayıt()
        {
            InitializeComponent();
        }
        OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\ceza evi demo\\verimerkezi.mdb");// veri tabanı bağlantısı
        OleDbCommand komut = new OleDbCommand();
        private void personelverigöster()   ///başlangıç
        ///mahkum için veri gösterme metodu %%%  SADECE PERSONEL %%%
        {
            listView1.Items.Clear();
            bağlantı.Open();                                ///veritabnı açılışı
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bağlantı;
            komut.CommandText = "Select * From giriş";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kimlikno"].ToString();
                ekle.SubItems.Add(oku["şifre"].ToString());
                ekle.SubItems.Add(oku["kullanıcı"].ToString());
                ekle.SubItems.Add(oku["adı"].ToString());
                ekle.SubItems.Add(oku["soyadı"].ToString());
                ekle.SubItems.Add(oku["doğumtarihi"].ToString());
                ekle.SubItems.Add(oku["doğumyeri"].ToString());
                ekle.SubItems.Add(oku["adresi"].ToString());

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

        private void button5_Click(object sender, EventArgs e)
        {
            personelverigöster();
        }

        private void button1_Click(object sender, EventArgs e)  ///kayıt butonu
        {
            bağlantı.Open();
            OleDbCommand komut = new OleDbCommand("insert into giriş (kimlikno,adı,soyadı,doğumtarihi,doğumyeri,adresi,kullanıcı,şifre) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox7.Text + "')", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            personelverigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button6_Click(object sender, EventArgs e)   ///silme butonu
        {
            bağlantı.Open();
            komut.Connection = bağlantı;
            komut.CommandText = "delete from giriş where kimlikno='" + textBox9.Text + "'";
            komut.ExecuteNonQuery();
            bağlantı.Close();
            personelverigöster();
        }

        private void button7_Click(object sender, EventArgs e)    ///güncelleme butonu
        {
            bağlantı.Open();
            komut.Connection = bağlantı;
            komut.CommandText = "update giriş set adı='" + textBox2.Text + "',soyadı='" + textBox3.Text + "',doğumtarihi='" + textBox4.Text + "',doğumyeri='" + textBox5.Text + "',adresi='" + textBox6.Text + "',kullanıcı='" + comboBox1.Text + "',şifre='" + textBox7.Text + "'where kimlikno='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            bağlantı.Close();
            personelverigöster();
        }
    }
}
