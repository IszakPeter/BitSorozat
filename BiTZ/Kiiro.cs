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
        string getRandomWord() => words[rnd.Next(words.Length)];
        private string bits;
        private DrawingBoard board = null;
        
        string StringToBits(string s) => string.Join("", Encoding.UTF8.GetBytes(s).Select(_ => Convert.ToString(_, 2).PadLeft(8, '0')));
        
        string BytesToBits(byte[] b) => string.Join("", b.Select(_ => Convert.ToString(_, 2).PadLeft(8, '0')));
        byte[] BitsToBytes(string bits)
        {
            List<byte> bytes = new List<byte>();
            string s = "";
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
        
        public Kiiro(string bs) {
            InitializeComponent();
            bits = bs;
            board = new DrawingBoard(10, 16);
            panel1.Controls.Add(board);
        }
        private void Kiiro_Load(object sender, EventArgs e) {
            var bytes = BitsToBytes(bits); 
            stringd.Text = Encoding.UTF8.GetString(bytes);    // byteból szöveget 
            intd.Text =new BigInteger(bytes)+"";
            board.BitsToDraw(bits);
        }
    }
}
