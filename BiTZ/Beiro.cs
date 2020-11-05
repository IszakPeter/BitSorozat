using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiTZ
{
    public partial class Beiro : Form
    {
        SqLiteConnector connector = null;

        string _bits;
        DrawingBoard board = null;
        string eStringd;
        string eIntd;
        string eBoard;
        int ID;
        string data;
        Color yellow = Color.Yellow;
        Color basic;


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


        public Beiro(int id, string bits)
        {
            InitializeComponent();
            ID = id;
            _bits = bits;
            board = new DrawingBoard(10, 16);
            //   MessageBox.Show(bits.Length+" kiiro constr");
            panel1.Controls.Add(board);
        }



        private void Beiro_Load(object sender, EventArgs e)
        {
            var bytes = BitsToBytes(_bits);
            basic = button1.BackColor;
            stringd.Enabled = true;
            intd.Enabled = true;

            stringd.Text = Encoding.UTF8.GetString(bytes);
            eStringd = stringd.Text;

            intd.Text = new BigInteger(bytes) + "";
            eIntd = intd.Text;
            board.BitsToDraw(_bits);
            eBoard = _bits;
            board.canDraw = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (stringd.Text != eStringd)
            {
                data = StringToBits(stringd.Text);
            }
            else if (intd.Text != eIntd)
            {
                data = BytesToBits(BigInteger.Parse(intd.Text).ToByteArray());
            }
            else if (board.DrawToBits() != eBoard)
            {
                data = board.DrawToBits();
            }

            var sql = "INSERT INTO Bitek ('data') VALUES('" + data + "')";

            //var sql = "UPDATE Bitek SET data='" + data + "' WHERE id=" + ID;
            connector = new SqLiteConnector("database.db");
            connector.Query(sql);

            Application.Restart();
        }


    }
}
