using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BiTZ
{
    public partial class DrawingBoard : UserControl
    {
        private int pixelSize;
        private int pixelDensity;
        private List<Label> pixels=new List<Label>();
        public  Color penColor=Color.Red;
        public bool canDraw = false;
        int bs_count = 0;
        public DrawingBoard(int ps,int pd) {
            InitializeComponent();
            (pixelSize, pixelDensity) = (ps, pd);
            this.Size = new Size(pixelDensity * pixelSize, pixelDensity * pixelSize);
            this.BorderStyle = BorderStyle.FixedSingle;
            for (int i = 0; i < pixelDensity; i++)
                for (int j = 0; j < pixelDensity; j++)
                    pixels.Add(Pixel(new Point(j*pixelSize,i*pixelSize)));
            Controls.AddRange(pixels.ToArray());
        }

        public void Clear()
        {
            for (int i = 0; i < bs_count; i++)
                pixels[i].BackColor = Color.White;
        }

        public void BitsToDraw(string bs)
        {
            // bs= bs.PadRight(pixelDensity * pixelDensity,'0');
            bs_count = bs.Length;
            MessageBox.Show(bs.Length+" draw");
                for (int i = 0; i < bs.Length; i++)
                    pixels[i].BackColor = bs[i] == '1' ? penColor : Color.White;
        }

        public string DrawToBits() =>
            string.Join("", pixels.Select(_ => _.BackColor == penColor ? "1" : "0"));
            
        private Label Pixel(Point point) {
           var l = new Label {
               Size=new Size(pixelSize,pixelSize),
               Location=point,
               BackColor = Color.White
           };
            l.Paint += delegate (object sender, PaintEventArgs e) {
                ControlPaint.DrawBorder(e.Graphics, ((Label)sender).ClientRectangle,
                    Color.Black, 0, ButtonBorderStyle.Solid, // left
                    Color.Black, 0, ButtonBorderStyle.Solid, // top
                    Color.Black, 1, ButtonBorderStyle.Solid, // right
                    Color.Black, 1, ButtonBorderStyle.Solid);// bottom
            };
            l.MouseMove += delegate(object sender, MouseEventArgs args) {
                if(canDraw) 
                    ((Label) sender).BackColor = penColor;
           };
           return l;          
        }

        private void DrawingBoard_Load(object sender, EventArgs e)
        {

        }
    }
}