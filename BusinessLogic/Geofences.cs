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
    public class Geofences
    {
        public static DataTable GetAll()
        {
            try
            {
                using (DataTable table = new DataTable("Geofences"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Get_Geofence);

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

        public static DataTable GetGeofenceInfo(string GEONAME)
        {
            try
            {
                using (DataTable table = new DataTable("GeofenceInfo"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Get_Geofence_Info);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@GEONAME", GEONAME);
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

        public static DataTable GetGeofenceType()
        {
            try
            {
                using (DataTable table = new DataTable("GetGeofenceType"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Get_GeofencesType);

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

        public static DataTable GetGeofenceCode()
        {
            try
            {
                using (DataTable table = new DataTable("GetGeofenceCode"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Get_GeofencesIdLMS);

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

        public static DataTable GetGeofenceInfoLMS(string GEOFENCE_CODE)
        {
            try
            {
                using (DataTable table = new DataTable("GetGeofenceInfoLMS"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Get_GeofenceInfoLMS);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                        {
                            adapter.SelectCommand.CommandType = CommandType.Text;
                            adapter.SelectCommand.Parameters.AddWithValue("@GEOFENCE_CODE", GEOFENCE_CODE);
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

        public static DataTable GetGeofenceLatLong()
        {
            try
            {
                using (DataTable table = new DataTable("GeofencesLatLong"))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Get_GeofenceLatLong);

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
        
        
        
        public static int Insert(
               string COMPANY_SID,
               string DIVISION_SID,
               string SUBDIVISION_SID,
            
               string GEOFENCE_TYPE,
               string GEOFENCE_CODE,
               string GEOFENCE_NAME,
               string GEOFENCE_LAT,
               string GEOFENCE_LON,
               string GEOFENCE_SPEED,
               string GEOFENCE_GEOM,
               string ACCOUNT_SID,
               string GEOFENCE_ALERT,
               string IS_ACTIVE)
        {
            try { 
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                conn.Open();
                string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Geofences_Insert);
                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@COMPANY_SID", COMPANY_SID);
                    command.Parameters.AddWithValue("@DIVISION_SID", DIVISION_SID);
                    command.Parameters.AddWithValue("@SUBDIVISION_SID", SUBDIVISION_SID);
                    command.Parameters.AddWithValue("@GEOFENCE_TYPE", GEOFENCE_TYPE);
                    command.Parameters.AddWithValue("@GEOFENCE_CODE", GEOFENCE_CODE);
                    command.Parameters.AddWithValue("@GEOFENCE_NAME", GEOFENCE_NAME);
                    command.Parameters.AddWithValue("@GEOFENCE_LAT", GEOFENCE_LAT);
                    command.Parameters.AddWithValue("@GEOFENCE_LON", GEOFENCE_LON);
                    command.Parameters.AddWithValue("@GEOFENCE_SPEED", GEOFENCE_SPEED);
                    command.Parameters.AddWithValue("@GEOFENCE_SPEED2", GEOFENCE_SPEED);
                    command.Parameters.AddWithValue("@GEOFENCE_GEOM", GEOFENCE_GEOM);
                    command.Parameters.AddWithValue("@ACCOUNT_SID", ACCOUNT_SID);
                    command.Parameters.AddWithValue("@GEOFENCE_ALERT", GEOFENCE_ALERT);
                    command.Parameters.AddWithValue("@IS_ACTIVE", IS_ACTIVE);
                    return command.ExecuteNonQuery();
                }
            }
            }
            catch (Exception e)
            {

            }
            return 0;
        }





        public static int Update(
           string COMPANY_SID,
           string DIVISION_SID,
           string SUBDIVISION_SID,
           string GEOFENCE_TYPE,
           string GEOFENCE_CODE,
           string GEOFENCE_NAME,
           string GEOFENCE_LAT,
           string GEOFENCE_LON,
           string GEOFENCE_SPEED,
           string GEOFENCE_GEOM,
           string ACCOUNT_SID,
           string GEOFENCE_ALERT,
           string IS_ACTIVE,
           string GEOFENCE_SID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    conn.Open();
                    string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Geofences.SQL__Geofences_Update);
                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@COMPANY_SID", COMPANY_SID);
                        command.Parameters.AddWithValue("@DIVISION_SID", DIVISION_SID);
                        command.Parameters.AddWithValue("@SUBDIVISION_SID", SUBDIVISION_SID);
                        command.Parameters.AddWithValue("@GEOFENCE_TYPE", GEOFENCE_TYPE);
                        command.Parameters.AddWithValue("@GEOFENCE_CODE", GEOFENCE_CODE);
                        command.Parameters.AddWithValue("@GEOFENCE_NAME", GEOFENCE_NAME);
                        command.Parameters.AddWithValue("@GEOFENCE_LAT", GEOFENCE_LAT);
                        command.Parameters.AddWithValue("@GEOFENCE_LON", GEOFENCE_LON);
                        command.Parameters.AddWithValue("@GEOFENCE_SPEED", GEOFENCE_SPEED);
                        command.Parameters.AddWithValue("@GEOFENCE_SPEED2", GEOFENCE_SPEED);
                        command.Parameters.AddWithValue("@GEOFENCE_GEOM", GEOFENCE_GEOM);
                        command.Parameters.AddWithValue("@ACCOUNT_SID", ACCOUNT_SID);
                        command.Parameters.AddWithValue("@GEOFENCE_ALERT", GEOFENCE_ALERT);
                        command.Parameters.AddWithValue("@IS_ACTIVE", IS_ACTIVE);
                        command.Parameters.AddWithValue("@GEOFENCE_SID", GEOFENCE_SID);
                        command.Parameters.AddWithValue("@UPDATE_BY", ACCOUNT_SID);
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
