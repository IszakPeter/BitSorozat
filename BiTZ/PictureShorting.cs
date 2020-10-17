using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiTZ
{
    public partial class PictureShorting : Form
    {
        static Random rnd = new Random();
        public PictureShorting()
        {
            InitializeComponent();
        }
        void boubleSortPicture(byte[] b, int n)
        {
            if (n != 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (b[i] > b[i + 1])
                        (b[i], b[i + 1]) = (b[i + 1], b[i]);
                }
                Bitmap bitmap = new Bitmap(32, 32, PixelFormat.Format24bppRgb);
                BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                IntPtr pNative = bmData.Scan0;
                Marshal.Copy(b, 0, pNative, b.Length);
                bitmap.UnlockBits(bmData);
                Application.DoEvents();
                Thread.Sleep(1);
                boubleSortPicture(b, n - 1);
            }
        }
        private void PictureShorting_Load(object sender, EventArgs e)
        {
            var sziv = "011100111000000010001100010000001000000001000000010000001000000000100001000000000001001000000000000011000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string c = string.Join("", Enumerable.Range(0, 256).Select(_ => rnd.Next(2)));
            board = new SortingBoard(10, 16, c);
          
            this.Controls.Add(board);
        }
        SortingBoard board = null;

        private void button1_Click(object sender, EventArgs e)
        {
            board.ShufelPixels();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.ShortPixels();
        }
    }
}

