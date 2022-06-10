using System;
using System.Data.SQLite;

namespace ATEN_Util
{
    public class Conn
    {
        public static SQLiteConnection ConnDB()
        {
            SQLiteConnection conn = new SQLiteConnection("data source=db\\ATEN_Lottery.db");
            conn.Open();
            return conn;
        }
    }

}
