using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BusinessLogic
{
    public class Accounts
    {

        public static DataTable AccountzLogin(string ACCOUNT_SID, string PASSWORDZ)
        {
            try
            {
                using (DataTable table = new DataTable("Account"))
                {


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Accounts.SQL__Login);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@ACCOUNT_SID", ACCOUNT_SID);
                            adapter.SelectCommand.Parameters.AddWithValue("@PASSWORDZ", PASSWORDZ);
                            adapter.Fill(table);
                        }
                    }

                    return table;
                }

            }
            catch (Exception e)
            {

            }

            return null;
        }


     


        public static int LastLogin(string ACCOUNT_SID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    conn.Open();
                    string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Accounts.SQL__Login_LastLogin);
                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@ACCOUNT_SID", ACCOUNT_SID);
                        command.Parameters.AddWithValue("@LAST_LOGIN", DateTime.Now);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

            }
            return 0; 
        }

    }
}
