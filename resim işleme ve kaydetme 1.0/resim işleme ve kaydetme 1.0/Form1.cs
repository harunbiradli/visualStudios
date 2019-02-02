using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resim_işleme_ve_kaydetme_1._0
{

    public class ImageProcessor
    {
        public ImageProcessor()
        {
 
        }
        public ImageProcessor(Image parImage)
        {
            Img = parImage;
        }
 
        private Image _Img;
        private Bitmap bmp;
        public Image Img
        {
            get
            {
                return _Img;
            }
            set
            {
                _Img = value;
                bmp = new Bitmap(_Img);
            }
        }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
