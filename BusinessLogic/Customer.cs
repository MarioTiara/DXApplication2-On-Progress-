using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace BusinessLogic
{
    public class Customer
    {

        public static DataTable GetCustomer()
        {
            try
            {
                using (DataTable table = new DataTable("Customer"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Customer.SQL__Customers);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
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


        public static DataTable GetCustomerProjectAll()
        {
            try
            {
                using (DataTable table = new DataTable("CustomerProjectAll"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Customer.SQL__Customers_Project_All);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
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

        public static DataTable GetCustomerProject(string CUSTOMER_SID)
        {
            try
            {
                using (DataTable table = new DataTable("CustomerProject"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Customer.SQL__Customers_Project);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@CUSTOMER_SID", CUSTOMER_SID);
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
    }
}
