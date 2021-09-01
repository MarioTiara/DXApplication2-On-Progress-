using DevExpress.Web.Mvc;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;

using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DXWebApplication1.Models;


using DevExpress.Web.Demos;
using System.Threading;

namespace DXWebApplication1.Views.HistoryShippment
{

    public delegate ActionResult GridViewExportMethod(GridViewSettings settings, object dataObject);
    public class GridViewExportDemoHelper
    {
        static Dictionary<string, GridViewExportMethod> exportFormatsInfo;
        public static Dictionary<string, GridViewExportMethod> ExportFormatsInfo
        {
            get
            {
                if (exportFormatsInfo == null)
                    exportFormatsInfo = CreateExportFormatsInfo();
                return exportFormatsInfo;
            }
        }
        static Dictionary<string, GridViewExportMethod> CreateExportFormatsInfo()
        {
            return new Dictionary<string, GridViewExportMethod> {
                {
                    "CustomExportToXLS",
                    (settings, data) => GridViewExtension.ExportToXls(settings, data, new XlsExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG })
                },
                {
                    "CustomExportToXLSX",
                    (settings, data) => GridViewExtension.ExportToXlsx(settings, data, new XlsxExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG })
                }
            };
        }

        public static GridViewSettings CreateGeneralDetailGridSettings(string ORDER_NUMBER)
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "detailGrid_" + ORDER_NUMBER;
            settings.Width = Unit.Percentage(100);

            settings.KeyFieldName = "ORDER_NUMBER";
            settings.Columns.Add("ORDER_NUMBER");
            settings.Columns.Add("HISTORY_DATE").PropertiesEdit.DisplayFormatString = "d";
            settings.Columns.Add("HISTORY_LOCATION");
            settings.Columns.Add("STATUS");

            settings.SettingsDetail.MasterGridName = "masterGrid";
            settings.Styles.Header.Wrap = DevExpress.Utils.DefaultBoolean.True;

            return settings;
        }

        //public ActionResult MasterDetailDetailPartial(string ORDER_NUMBER)
        //{
        //    object dataDetail;
        //    DataTable resultDetail = new DataTable();
        //    resultDetail = BusinessLogic.Order.GetHistoryShippmentDetail(ORDER_NUMBER);
        //    List<Models.vwvwModelHistoryShippmentDetail> listDetail = new List<Models.vwvwModelHistoryShippmentDetail>();
        //    for (int i = 0; i < resultDetail.Rows.Count; i++)
        //    {
        //        vwvwModelHistoryShippmentDetail DataView = new vwvwModelHistoryShippmentDetail();
        //        DataView.ORDER_NUMBER = resultDetail.Rows[i]["ORDER_NUMBER"].ToString();
        //        DataView.HISTORY_DATE = Convert.ToDateTime(resultDetail.Rows[i]["HISTORY_DATE"].ToString());
        //        DataView.HISTORY_LOCATION = resultDetail.Rows[i]["HISTORY_LOCATION"].ToString();
        //        DataView.STATUS = resultDetail.Rows[i]["STATUS"].ToString();

        //        listDetail.Add(DataView);

        //    }

        //    dataDetail = listDetail;
        //    ViewBag.Detail = dataDetail;
        //    return ViewBag.Detail;
        //}
    }

}