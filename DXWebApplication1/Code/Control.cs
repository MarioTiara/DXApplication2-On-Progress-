using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Data;
using System.Configuration;

namespace DXWebApplication1.Code
{
    public class Vehicle
    {
        public static ListEditItemCollection GetByCompany(string COMPANY_SID)
        {
            ListEditItemCollection listItem = new ListEditItemCollection();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                conn.Open();
                using (DataTable reader = BusinessLogic.Vehicle.GetAll())
                {
                    ListEditItem item = new ListEditItem();
                    item.Text = "-- PILIH --";
                    item.Value = Guid.Empty.ToString();
                    item.Selected = false;
                    listItem.Add(item);

                    for (int i = 0; i < reader.Rows.Count; i++)
                    {
                        if (!Convert.ToBoolean(reader.Rows[i]["IS_ACTIVE"])) continue;
                        item = new ListEditItem();
                        item.Text = reader.Rows[i]["REG_NO"].ToString().ToUpper();
                        item.Value = reader.Rows[i]["VEHICLE_SID"].ToString();
                        item.Selected = false;
                        listItem.Add(item);
                    }
                }
            }
            return listItem;
        }
    
    }
}