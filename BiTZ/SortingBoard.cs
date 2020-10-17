using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace BiTZ
{
    public partial class SortingBoard : UserControl
    {
        static Random rnd = new Random();
        static int randomPos(object[] t) => rnd.Next(0, t.Length);

        int pixelSize;
        int pixelDent;
        string bits;

        Label[] pixels = null;
        public SortingBoard(int ps, int pd,string bs) {
            InitializeComponent();
            Size = new Size(ps * pd, ps * pd);
            pixelSize = ps;
            pixelDent = pd;
            bits = bs.PadRight(pd*pd,'0');
            int index = 0;
            pixels = new Label[pd * pd];
            for (int i = 0; i < pd; i++){
                for (int j = 0; j < pd; j++){
                    pixels[index]=(PIxel(new Point(j * pixelSize, i * pixelSize),(bits[index]=='1'?Color.Black:Color.White),index));
                    index++;
                }
            }
            Controls.AddRange(pixels);
        }
        Label PIxel(Point po, Color color, int index  )
        {
            var p = new Label {
                Size = new Size(pixelSize, pixelSize),
                Location = po,
                BackColor = color,
                Tag = index
            };
            return p;
        }
        public void ShufelPixels()
        {
            for (int r = 0; r < rnd.Next(pixels.Length/2, pixels.Length); r++)
            {
//                MessageBox.Show(r + "");
                var t = randomPos(pixels);
                var k = randomPos(pixels);
                (pixels[t].Location, pixels[t].Tag, pixels[k].Location,pixels[k].Tag) = (pixels[k].Location, pixels[k].Tag, pixels[t].Location, pixels[t].Tag);    
                Application.DoEvents();
            }
        }
        public void ShortPixels()
        {

            bubbleSort(pixels, pixels.Length);
        }
        static void bubbleSort(Label[] arr, int n){
            if (n != 1){
                for (int i = 0; i < n - 1; i++)
                    if (((int)arr[i].Tag) > ((int)arr[i + 1].Tag))
                    {
                        (arr[i].Location, arr[i].Tag, arr[i + 1].Location, arr[i + 1].Tag) = (arr[i + 1].Location, arr[i + 1].Tag, arr[i].Location, arr[i].Tag);
                        Application.DoEvents();
                    }
                   bubbleSort(arr, n - 1);
            }
      //      MessageBox.Show("kész");
        }


    }
}
