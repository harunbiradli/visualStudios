using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ceza_evi_demo
{
    public partial class müdür : Form
    {
        public müdür()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mkayıt mahkumkayıt = new mkayıt();
            mahkumkayıt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pkayıt perkayıt = new pkayıt();
            perkayıt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zkayıt ziyaretkayıt = new zkayıt();
            ziyaretkayıt.Show();
            this.Hide();
        }

        private void müdür_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            mtakip mahkumtakip = new mtakip();
            mahkumtakip.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ptakip personeltakip = new ptakip();
            personeltakip.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ztakip ziyaretçitakip = new ztakip();
            ziyaretçitakip.Show();
            this.Hide();
        }
    }
}
