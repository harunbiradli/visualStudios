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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\ceza evi demo\\verimerkezi.mdb");
            OleDbCommand cmd = new OleDbCommand("select * from giriş where kimlikno='" + textBox1.Text + "' and şifre='" + textBox2.Text + "'", con);
            OleDbDataAdapter oldda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            oldda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["kullanıcı"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("Giriş Yapılıyor." + dt.Rows[i][2]);          ///giriş den sonra seçilen formun kime ait olduğunu gösteren mesajkutusu....
                        if (comboBox1.SelectedIndex == 0)                            ///comboBoxs in indeklerine göre kullanıcı giriş formu seçiliyor.
                        {
                            müdür f = new müdür();
                            f.Show();
                            this.Hide();
                        }
                        else if(comboBox1.SelectedIndex == 1)
                        {
                            memur ff = new memur();
                            ff.Show();
                            this.Hide();
                        }
                        else
                        {
                            gardiyan fff = new gardiyan();
                            fff.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("kullanıcı bulunamadı.");   ///hata olursa
            }
        }
    }
}
//Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\ceza evi demo\verimerkezi.mdb"