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
    public partial class Beiro : Form
    {
        private DrawingBoard board = null;

        public Beiro()
        {
            InitializeComponent();

            board = new DrawingBoard(10, 16);
            panel1.Controls.Add(board);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(intd.Text == ""){

            }
            else if(stringd.Text == ""){

            }
        }
    }
}
