﻿using System;
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
        public  Color penColor=Color.Black;
        
        public DrawingBoard(int ps,int pd) {    //ps és pd paraméter --> paraméter átadás
            InitializeComponent();
            pixelSize = ps;
            pixelDensity = pd;
            Size=new Size(pixelDensity*pixelSize,pixelDensity*pixelSize);
            for (int i = 0; i < pixelDensity; i++)
                for (int j = 0; j < pixelDensity; j++)
                    pixels.Add(Pixel(new Point(j*pixelSize,i*pixelSize)));
            Controls.AddRange(pixels.ToArray());
        }


        public void BitsToDraw(string bs)
        {
           bs= bs.PadRight(pixelDensity * pixelDensity,'0');
                for (int i = 0; i < bs.Length; i++)
                    pixels[i].BackColor = bs[i] == '1' ? Color.Black : Color.White;
        }

       public string DrawToBits() =>
            string.Join("", pixels.Select(_ => _.BackColor == Color.Black ? "1" : "0"));
            
       private Label Pixel(Point point) {
           var l = new Label {
               Size=new Size(pixelSize,pixelSize),
               Location=point,
               BackColor = Color.White
           };
           l.MouseMove += delegate(object sender, MouseEventArgs args) {
                   ((Label) sender).BackColor = penColor;
           };
           return l;
           
       }

       
        private void DrawingBoard_MouseDown(object sender, MouseEventArgs e)
       {
           MessageBox.Show("Lent");
       }

        private void DrawingBoard_Load(object sender, EventArgs e)
        {

        }
    }
}