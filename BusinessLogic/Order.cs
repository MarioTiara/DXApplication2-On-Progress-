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
    public class Order
    {

        public static DataTable GetShippmentAll()
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportAll"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__Shippment_Report_All);

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

        public static DataTable GetShippmentCustomerSid(string CUSTOMER_SID)
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportCustomerSid"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__Shippment_Report_CustomerSID);

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


        public static DataTable GetShippmentProjectNo(string PROJECT_NO)
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportCustomerSid"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__Shippment_Report_ProjectNo);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@PROJECT_NO", PROJECT_NO);
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



        public static DataTable GetHistoryShippmentAll(string FROM_DATE, string TO_DATE)
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportAll"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__History_Shippment_Report);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@FROM_DATE",FROM_DATE);
                            adapter.SelectCommand.Parameters.AddWithValue("@TO_DATE", TO_DATE);
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

        public static DataTable GetHistoryShippmentCustomerSid(string CUSTOMER_SID, string FROM_DATE, string TO_DATE)
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportCustomerSid"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__History_Shippment_Report_CustomerSID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@CUSTOMER_SID", CUSTOMER_SID);
                            adapter.SelectCommand.Parameters.AddWithValue("@FROM_DATE", FROM_DATE);
                            adapter.SelectCommand.Parameters.AddWithValue("@TO_DATE", TO_DATE);
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


        public static DataTable GetHistoryShippmentProjectNo(string PROJECT_NO , string FROM_DATE , string TO_DATE)
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportCustomerSid"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__History_Shippment_Report_ProjectNo);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@PROJECT_NO", PROJECT_NO);
                            adapter.SelectCommand.Parameters.AddWithValue("@FROM_DATE",FROM_DATE);
                            adapter.SelectCommand.Parameters.AddWithValue("@TO_DATE", TO_DATE);
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


        public static DataTable GetHistoryShippmentDetail(string ORDER_NUMBER)
        {
            try
            {
                using (DataTable table = new DataTable("ShippmentReportDetail"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Order.SQL__History_Shippment_Report_Detail);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@ORDER_NUMBER", ORDER_NUMBER);
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
