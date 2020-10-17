using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BiTZ
{        //32 bájt lehet
    public partial class Form1 : Form {
        static Random rnd = new Random();
        SqLiteConnector connector = null;
        public Form1(){
            InitializeComponent();

        }
        
        private void test_Click(object sender, EventArgs e)
        {
            string c = string.Join("",Enumerable.Range(0, 256).Select(_=> rnd.Next(2)));
            //new Kiiro(c).Show(); 
            new PictureShorting().Show();
        }
        private void Form1_Load(object sender, EventArgs e){
            if (!File.Exists("database.db")){
                File.Create("database.db").Close();
                var sql ="CREATE TABLE \"Bitek\"(\"data\" TEXT NULL);";
                connector = new SqLiteConnector("database.db");
            }
            connector = new SqLiteConnector("database.db");
            tabel.DataSource = connector.FillDataTable("select * from Bitek");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connector.Disconect();
        }
    }
}
