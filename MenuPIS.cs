using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;

namespace AulaPIS
{
    public partial class MenuPIS : Form
    {
        Bitmap bmpOriginal = null;
        Bitmap bmpConvertido = null;
        public MenuPIS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = new OpenFileDialog();
            
            if (result.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(result.FileName);
                filePath.Text = file.ToString();
                pictureBox1.Image = Image.FromFile(file.ToString());
                bmpOriginal = new Bitmap(pictureBox1.Image);
            }
        }

        private void exercicio1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < bmpOriginal.Width; x++)
            {
                for (int y = 0; y < bmpOriginal.Height; y++)
                {
                    Color pixel = bmpOriginal.GetPixel(x, y);

                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    bmpOriginal.SetPixel(x, y, Color.FromArgb(255 - red, 255 - green, 255 - blue));
                }
            }
            pictureBox2.Image = bmpOriginal;
        }

        private void exercicio2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < bmpOriginal.Width; x++)
            {
                for (int y = 0; y < bmpOriginal.Height; y++)
                {
                    Color pixel = bmpOriginal.GetPixel(x, y);

                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    bmpOriginal.SetPixel(x, y, Color.FromArgb(255 - red, 255 - green, 255 - blue));
                }
            }
            pictureBox2.Image = bmpOriginal;
        }

        private void exercicio3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap inter;
            AForge.Imaging.Filters.RotateBilinear rotate = new AForge.Imaging.Filters.RotateBilinear(90, true);
            inter = AForge.Imaging.Image.Convert16bppTo8bpp(bmpOriginal);
            bmpConvertido = rotate.Apply(inter);
            pictureBox2.Image = bmpConvertido;
        }
    }
}