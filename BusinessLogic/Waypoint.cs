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
   public class Waypoint
    {
       public static DataTable GetWaypointInfo(string VehicleSid, string FROM_DATE, string TO_DATE)
       {
           try
           {
               using (DataTable table = new DataTable("Waypoint"))
               {

                   using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                   {
                       string cmdText = DataAccess.DataAccess.GetCommandText(DataAccess.Waypoint.SQL__HistoryWaypoint);

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
    }
}
