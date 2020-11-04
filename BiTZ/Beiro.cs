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

        string StringToBits(string s) => string.Join("", Encoding.UTF8.GetBytes(s).Select(_ => Convert.ToString(_, 2).PadLeft(8, '0')));
        string BytesToBits(byte[] b) => string.Join("", b.Select(_ => Convert.ToString(_, 2).PadLeft(8, '0')));

        byte[] BitsToBytes(string bits)
        {
            var bytes = new List<byte>();
            var s = "";
            for (int i = 0; i < bits.Length; i++)
            {
                s += bits[i];
                if ((i + 1) % 8 == 0)
                {
                    bytes.Add(Convert.ToByte(s, 2));
                    s = "";
                }
            }
            return bytes.ToArray();
        }



        public Beiro()
        {
            InitializeComponent();

            board = new DrawingBoard(10, 16);
            panel1.Controls.Add(board);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
