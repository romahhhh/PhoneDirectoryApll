using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IDatabase
    {
        public SQLiteConnection Connection { get; set; }
    }
}
