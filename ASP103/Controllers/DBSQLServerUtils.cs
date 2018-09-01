using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ASP103.Controllers
{
    class DBSQLServerUtils
    {

        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            connString = "Data Source = sql.freeasphost.net\\MSSQL2016; Initial Catalog = eddyko00_SampleDB; Persist Security Info = True; User ID = eddyko00_SampleDB; Password = DBSamplePW";
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }


    }
}
