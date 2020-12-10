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
    public partial class Kiiro : Form
    {
        private string bits;
        private DrawingBoard board = null;

        public Kiiro(string bs)
        {
            InitializeComponent();
            bits = bs;
            board = new DrawingBoard(10, 16);
            panel1.Controls.Add(board);
        }

        private void Kiiro_Load(object sender, EventArgs e)
        {
            List<byte> bytes = new List<byte>();
            string s = "";
            for (int i = 0; i < bits.Length; i++)
            {
                if ((i+1)%8==0)
                {
                    s += bits[i];
                    bytes.Add(Convert.ToByte(s,2));
                    s = "";
                }
                else
                {
                    s += bits[i];
                }
            }

            stringd.Text = Encoding.UTF8.GetString(bytes.ToArray());    // bitből szöveget 
            board.BitsToDraw(bits);
        }
    }
}
