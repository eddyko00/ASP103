using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ASP103.Controllers
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = "sql.freeasphost.net\\MSSQL2016";

            string database = "eddyko00_SampleDB";
            string username = "eddyko00_SampleDB";
            string password = "DBSamplePW";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
