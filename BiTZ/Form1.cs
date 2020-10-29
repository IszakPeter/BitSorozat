using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace BiTZ
{        //32 bájt lehet
    public partial class Form1 : Form {

        static Random rnd = new Random();
        long st=0;
        string RandomBItekWe(int count) => string.Join("", Enumerable.Range(0, count).Select(_ => rnd.Next(2)));
        string RandomBItekWt(int count) => string.Join("", new string[count].Select(_ => rnd.Next(2)));

        SqLiteConnector connector = null;
        public Form1(){
            InitializeComponent();

        }
        private void test_Click(object sender, EventArgs e) {
        }
        private void Form1_Load(object sender, EventArgs e){
            if (!File.Exists("database.db")){
                File.Create("database.db").Close();
                var sql = @"CREATE TABLE 'Bitesk'( 'id' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,'data' TEXT NULL);";
                connector = new SqLiteConnector("database.db");
                connector.Query(sql);
            }
            connector = new SqLiteConnector("database.db");
            tabel.DataSource = connector.FillDataTable("select * from Bitek");
            tabel.Rows[0].Selected = false;

            tabel.ClearSelection();
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connector.Disconect();
        }

        private void Kiemel(object sender, EventArgs e) {
        }

        private void tabel_Click(object sender, EventArgs e)
        {
            if (tabel.SelectedCells.Count > 0)
            {
                var selected = tabel.SelectedCells;
                var selectedRows = new List<DataGridViewRow>();
                for (int i = selected.Count-1; i >-1 ; i--)
                {
                    var sr = tabel.Rows[selected[i].RowIndex];
                    selectedRows.Add(sr);
                }

//                selectedRows.Select(_=>_.Cells["id"].Value+ " "+_.Cells["data"].Value)));
                selectedRows.ForEach(_ => {
                    var c = _.Cells;
                    new Kiiro(int.Parse(c["id"].Value+""), c["data"].Value + "").Show();   });
            }

        }
    }
}
