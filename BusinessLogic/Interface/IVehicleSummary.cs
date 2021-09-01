using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IVehicleSummary
    {
        string GetVehicleSummary(int VEHICLE_SID, string DESCRIPTION);
    }
}
