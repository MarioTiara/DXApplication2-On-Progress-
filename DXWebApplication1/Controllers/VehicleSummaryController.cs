using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class VehicleSummaryController : Controller
    {
        //
        // GET: /VehicleSummary/
        public ActionResult Index()
        {
            return View();
        }

        DXWebApplication1.Models.seinoEntities db = new DXWebApplication1.Models.seinoEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.vwVehicleWithOrders;
            return PartialView("_GridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(DXWebApplication1.Models.vwVehicleWithOrder item)
        {
            var model = db.vwVehicleWithOrders;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(DXWebApplication1.Models.vwVehicleWithOrder item)
        {
            var model = db.vwVehicleWithOrders;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.VEHICLE_SID == item.VEHICLE_SID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.String VEHICLE_SID)
        {
            var model = db.vwVehicleWithOrders;
            if (VEHICLE_SID != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.VEHICLE_SID == VEHICLE_SID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
	}
}