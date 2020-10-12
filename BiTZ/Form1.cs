using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiTZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint = Point.Empty;
        bool isMouseDown = false;
        byte[] array = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e){
            if (isMouseDown == true){
                if (lastPoint != null){
                    if (pictureBox1.Image == null)
                        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image)){
                        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                    }
                    pictureBox1.Invalidate();
                    lastPoint = e.Location;
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            isMouseDown = false;
            lastPoint = Point.Empty;// törli a pontot
        }
        private void clearButton_Click(object sender, EventArgs e){
            if (pictureBox1.Image != null){
                pictureBox1.Image = null;
                Invalidate();
            }
        }
        public  byte[] ImageToByte(Image img){
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            array= ImageToByte((Image)pictureBox1.Image);
            array = "255;0;255;255;0;255".Split(';').Select(_ => byte.Parse(_)).ToArray();
            MessageBox.Show(string.Join(" ", array));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MemoryStream mStream = new MemoryStream(array))
            {
                pictureBox1.Image= Image.FromStream(mStream);
            }
        }
    }
}
