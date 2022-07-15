using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Company_telephone_directory.Database
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            //string host = "127.0.0.1";
            string server = "host.docker.internal";
            int port = 3306;
            string database = "company_telephone_directory";
            string user = "user";
            string password = "user";

            return DBMySQLUtils.GetDBConnection(server, port, database, user, password);
        }

    }
}
