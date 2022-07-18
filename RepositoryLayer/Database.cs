using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace RepositoryLayer
{
    public class Database : IDatabase
    {
        public SQLiteConnection Connection { get; set; }

        public Database()
        {
            try
            {
                 Connection = new SQLiteConnection("Data Source=database.sqlite3; foreign keys=true;");
                 Connection.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }
        }
        ~Database()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}
