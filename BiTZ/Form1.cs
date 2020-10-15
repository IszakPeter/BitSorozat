using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Numerics;

namespace BiTZ
{        //32 bájt lehet
    public partial class Form1 : Form {
        static Random rnd = new Random();
        private DrawingBoard board = null;

        public Form1(){
            InitializeComponent();
        }

        /*
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        private Bitmap GenBitmap(int width, int height) {
            int ch =3; 
            Random rnd = new Random();
            int imageByteSize = width * height * ch;
            byte[] imageData = new byte[imageByteSize]; 
            rnd.NextBytes(imageData);       
            imageData = imageData.OrderByDescending(_ => _).ToArray();
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pNative = bmData.Scan0;
            Marshal.Copy(imageData, 0, pNative, imageByteSize);
            bitmap.UnlockBits(bmData);
            return bitmap;
        }
        */
        private void test_Click(object sender, EventArgs e)
        {
            string c = string.Join("",Enumerable.Range(0, 256).Select(_=> rnd.Next(2)));

            board.BitsToDraw(c);
        }
        private void Form1_Load(object sender, EventArgs e){
           board= new DrawingBoard(10,16);
            panel1.Controls.Add(board);
        }
       
    }
}
