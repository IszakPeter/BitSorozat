using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiTZ {
    public partial class Kiiro : Form {
        static string[] words = "szó;Eathen;nagybetű;Kisbetű,Peti;Jordán;Gút;Tankcsapda;retek;mogyoró;sok;fekete;fehér;pina;obcén szavak;bicska;ló;kutya;citrom;Python;hesteg;Neoton Familia;zene;turú;vaj;sajt;pudding;igen;nem;talán;fegyver;pirkadat;est;hajnal;priusz;rendőr;pandúr;szemüveg;nő;szeretet;magány;pornhub;Piper Perri;Lana Rhodhes;Lena Paul;Eva Elif;LittleReislin;LittleSpoonz;hiányszakma;informatika".Split(';');
        static Random rnd = new Random();
        static string getRandomWord() => words[rnd.Next(words.Length)];
        SqLiteConnector connector = null;
        #region varibels
        string _bits;
        DrawingBoard board = null;
        string eStringd;
        string eIntd;
        string eBoard;
        int ID;
        string data;
        Color yellow = Color.Yellow;
        Color basic;
        #endregion

        string StringToBits(string s) => string.Join("", Encoding.UTF8.GetBytes(s).Select(_ => Convert.ToString(_, 2).PadLeft(8, '0')));
        string BytesToBits(byte[] b) => string.Join("", b.Select(_ => Convert.ToString(_, 2).PadLeft(8, '0')));

        byte[] BitsToBytes(string bits) {
            var bytes = new List<byte>();
            var s = "";
            for (int i = 0; i < bits.Length; i++) {
                s += bits[i];
                if ((i + 1) % 8 == 0) {
                    bytes.Add(Convert.ToByte(s, 2));
                    s = "";
                }
            }
            return bytes.ToArray();
        }


        public Kiiro(int id, string bits) {
            InitializeComponent();
            ID = id;
            _bits = bits;
            board = new DrawingBoard(10, 16);
            panel1.Controls.Add(board);
        }
        private void Kiiro_Load(object sender, EventArgs e) {

            var bytes = BitsToBytes(_bits);
            basic = button2.BackColor;
            stringd.Enabled = false;
            intd.Enabled = false;

            stringd.Text = Encoding.UTF8.GetString(bytes);    // byteból szöveget 
            eStringd = stringd.Text;

            intd.Text =new BigInteger(bytes)+"";
            eIntd = intd.Text;
            board.BitsToDraw(_bits);
            eBoard = _bits;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(stringd.Text != eStringd){
                data = StringToBits(stringd.Text);
            }
            else if(intd.Text != eIntd)
            {
                data = BytesToBits(BigInteger.Parse(intd.Text).ToByteArray());
            }
            else if(board.DrawToBits() != eBoard){
                data = board.DrawToBits();
            }



            //var sql = "INSERT INTO Bitek ('data') VALUES('"+data+"');";  {Neked Jordánom}


            var sql = "UPDATE Bitek SET data='" + data + "' WHERE id=" + ID;
            connector = new SqLiteConnector("database.db");
            connector.Query(sql);

            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stringd.Enabled = !stringd.Enabled;
            intd.Enabled = !intd.Enabled;
            board.canDraw = !board.canDraw;
            button2.BackColor = button2.BackColor == basic ? yellow : basic;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sql = "DELETE FROM Bitek WHERE id=" + ID;
            connector = new SqLiteConnector("database.db");
            connector.Query(sql);

            Application.Restart();
        }
    }
}
