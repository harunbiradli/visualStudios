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
    public partial class ptakip : Form
    {
        public ptakip()
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
        private void button2_Click(object sender, EventArgs e)
        {
            müdür anasahife = new müdür();
            anasahife.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelverigöster();
        }
    }
}
