using BusinessLogic.Interface;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft;

namespace BusinessLogic
{
    public class VehicleSummary : IVehicleSummary
    {
        public string GetVehicleSummary(int VEHICLE_SID , string DESCRIPTION)
        {
            return "B9916TEW" + VEHICLE_SID + DESCRIPTION;
        }
    }
}
