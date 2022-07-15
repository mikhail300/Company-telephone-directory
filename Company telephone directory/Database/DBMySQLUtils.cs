using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Company_telephone_directory.Database
{
    class DBMySQLUtils
    {

        public static MySqlConnection
                 GetDBConnection(string server, int port, string database, string user, string password)
        {
            // Connection String.
            string connString = "server=" + server + ";database=" + database
                + ";port=" + port + ";user=" + user + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

    }
}
