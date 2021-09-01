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
    public class Vehicle
    {

        public static DataTable GetAll()
        {
            try
            {
                using (DataTable table = new DataTable("Vehicle"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Vehicle.SQL__Vehicle_GetAll);

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

        public static DataTable VehicleByCustomer(string CUSTOMER_SID)
        {
            try
            {
                using (DataTable table = new DataTable("Vehicle"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Vehicle.SQL__Vehicle_By_CustomerSID);

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

        public static DataTable VehicleByCustomerProjectSID(string CUSTOMER_SID , string PROJECT_SID)
        {
            try
            {
                using (DataTable table = new DataTable("Vehicle"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Vehicle.SQL__Vehicle_By_CustomerSID_ProjectSID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@CUSTOMER_SID", CUSTOMER_SID);
                            adapter.SelectCommand.Parameters.AddWithValue("@PROJECT_SID", PROJECT_SID);
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


        public static DataTable LoadCombobox()
        {
            try
            {
                using (DataTable table = new DataTable("Vehicle"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Vehicle.SQL__Vehicle_GetAll_Combobox);

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
    }
}
