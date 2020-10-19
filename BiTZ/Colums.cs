using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiTZ
{
    public partial class Colums : Form
    {
        public Colums()
        {
            InitializeComponent();
        }

        private void Colums_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                this.Controls.Add(oszlop(i,new Point(i*20,10)));
            }
        }
        Label oszlop(int index, Point point)
        {
            Label l = new Label {
                Size=new Size(10,(1+index)*20),
                Location=point,
                BackColor=Color.Black
            };
            return l;
        }
    }
}
