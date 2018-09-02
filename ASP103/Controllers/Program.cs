using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace ASP103.Controllers
{
    class Program
    {

        public static String ExecuteSQLCmd(String sql)
        {
            Console.WriteLine("Getting Connection ...");
            SqlConnection sqlConnection = DBUtils.GetDBConnection();
            String jsonString = "0";
            try
            {
                Console.WriteLine("Openning Connection ...");
                sqlConnection.Open();
                Console.WriteLine("Connection successful!");

                SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                jsonString = "1";
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return jsonString;

        }

        public static String UpdateSQLCmd(String sql)
        {
            return ExecuteSQLCmd(sql);
        }

        public static String InsertSQLCmd(String sql)
        {
            return ExecuteSQLCmd(sql);
        }


        public static String SelectSQLCmd(String sql)
        {
            Console.WriteLine("Getting Connection ...");
            SqlConnection sqlConnection = DBUtils.GetDBConnection();
            String jsonString = "";
            try
            {
                Console.WriteLine("Openning Connection ...");
                sqlConnection.Open();
                Console.WriteLine("Connection successful!");

                //String sql = "SELECT * FROM customer";
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCmd;
                DataTable ds = new DataTable();
                sqlDataAdapter.Fill(ds);

                jsonString = DataTableToJsonObjAFweb(ds);
                Console.WriteLine(jsonString);

                sqlDataAdapter.Dispose();
                sqlCmd.Dispose();


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return jsonString;

        }

        public static string DataTableToJsonObjAFweb(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("''" + ds.Tables[0].Columns[j].ColumnName.ToString() + "'':" + "''" + ds.Tables[0].Rows[i][j].ToString() + "'',");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("''" + ds.Tables[0].Columns[j].ColumnName.ToString() + "'':" + "''" + ds.Tables[0].Rows[i][j].ToString() + "''");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }


        public static string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

    }
}
