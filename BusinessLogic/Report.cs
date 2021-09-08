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
   public class Report
    {

       public static DataTable GetDataDetailActivityReport(string VehicleSid, string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("DetailActivityReport"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Detail_Activity_Report);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@VEHICLE_SID", VehicleSid);
                           adapter.SelectCommand.Parameters.AddWithValue("@WP_FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@WP_TO_DATE", Convert.ToDateTime(TO_DATE));
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


       public static DataTable SpeedReport(string VehicleSid, string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("SpeedReport"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Speed_Report);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@VEHICLE_SID", VehicleSid);
                           adapter.SelectCommand.Parameters.AddWithValue("@WP_FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@WP_TO_DATE", Convert.ToDateTime(TO_DATE));
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

       public static DataTable VehicleInGeofence(string STARTDATE, string ENDDATE, string POLYGON)
       {


           //IFormatProvider culture = new CultureInfo("en-US", true);
           try
           {
               using (DataTable table = new DataTable("VehicleInGeofence"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Vehicle_In_Geofence);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@STARTDATE", Convert.ToDateTime(STARTDATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@ENDDATE", Convert.ToDateTime(ENDDATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@POLYGON", POLYGON);
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


       public static DataTable VehicleInGeofenceRegNo(string STARTDATE, string ENDDATE, string VehicleSid)
       {


           //IFormatProvider culture = new CultureInfo("en-US", true);
           try
           {
               using (DataTable table = new DataTable("VehicleInGeofence"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Vehicle_In_Geofence_OnlyRegNo);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@STARTDATE", Convert.ToDateTime(STARTDATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@ENDDATE", Convert.ToDateTime(ENDDATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@VehicleSid", VehicleSid);
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

       public static DataTable VehicleInGeofenceRegNoAndPolygon(string STARTDATE, string ENDDATE, string POLYGON, string VehicleSid)
       {
           try
           {
               using (DataTable table = new DataTable("VehicleInGeofence"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Vehicle_In_Geofence_RegNoPolygon);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@STARTDATE", Convert.ToDateTime(STARTDATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@ENDDATE", Convert.ToDateTime(ENDDATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@POLYGON", POLYGON);
                           adapter.SelectCommand.Parameters.AddWithValue("@VehicleSid", VehicleSid);
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

       public static DataTable OdoMeterReport(string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("OdoMeterReport"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Vehicle_Report_OdoMeter);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@TO_DATE", Convert.ToDateTime(TO_DATE));
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

       public static DataTable OdoMeterReportByVehicle(string VehicleSid, string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("OdoMeterReport"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Vehicle_Report_OdoMeter_ByVehicle);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@VEHICLE_SID", VehicleSid);
                           adapter.SelectCommand.Parameters.AddWithValue("@FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@TO_DATE", Convert.ToDateTime(TO_DATE));
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

       public static DataTable CameraReport1(string VehicleSid, string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("Cam_Report1"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Camera_Report1);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@VEHICLE_SID", VehicleSid);
                           adapter.SelectCommand.Parameters.AddWithValue("@CAPTURE_FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@CAPTURE_TO_DATE", Convert.ToDateTime(TO_DATE));
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

       public static DataTable CameraReport2(string VehicleSid, string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("Cam_Report2"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Report.SQL__Camera_Report2);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@VEHICLE_SID", VehicleSid);
                           adapter.SelectCommand.Parameters.AddWithValue("@CAPTURE_FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@CAPTURE_TO_DATE", Convert.ToDateTime(TO_DATE));
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

   public class EventReport
   {
       public static DataTable GetData(string VehicleSid, string FROM_DATE , string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("EventReport"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.EventReport.SQL__Event_Report);

                       using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                       {
                           adapter.SelectCommand.CommandType = CommandType.Text;
                           adapter.SelectCommand.Parameters.AddWithValue("@VehicleSid", VehicleSid);
                           adapter.SelectCommand.Parameters.AddWithValue("@FROM_DATE", Convert.ToDateTime(FROM_DATE));
                           adapter.SelectCommand.Parameters.AddWithValue("@TO_DATE", Convert.ToDateTime(TO_DATE));
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
