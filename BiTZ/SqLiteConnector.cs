using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiTZ
{
    class SqLiteConnector {
        SQLiteConnection connection;
        
        public SqLiteConnector(string database) {
            connection = new SQLiteConnection("data source = " + database);
            connection.Open();
        }
        public List<string> Query(string sql){
            var l = new List<string>();
            var cmd = new SQLiteCommand(sql, connection);
            var result = cmd.ExecuteReader();
            while (result.Read())
                l.Add(string.Join(" ",result));
            result.Close();
            return l;
        }
        public DataTable FillDataTable(string sql) {
            var cmd = new SQLiteCommand(sql, connection);
            var adapter = new SQLiteDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        ~SqLiteConnector()
        {
            connection.Close();
        }
    }

}
