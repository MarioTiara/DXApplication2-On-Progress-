using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Web.Mvc;
using System.Data.Entity;
using System.Data.Linq;


namespace DXWebApplication1.Models
{
    public class vwShippment
    {
        public string RECORD_ID { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string CUSTOMER_SID { get; set; }
        public string REG_NO { get; set; }
        public string DESCRIPTION { get; set; }
        public string ORIGIN_CODE { get; set; }
        public string ORIGIN_NAME { get; set; }
        public string DESTINATION_CODE { get; set; }
        public string DESTINATION_NAME { get; set; }
        public string PROJECT_SID { get; set; }
        public DateTime PICKUP_DATE { get; set; }
        public DateTime PROGRESS_DATE { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public DateTime ARRIVAL_DATE { get; set; }
        public DateTime COMPLETE_DATE { get; set; }
        public DateTime DUE_DATE { get; set; }
        public DateTime EXPIRED_DATE { get; set; }
        public string DRIVER_SID { get; set; }
        public string DRIVER_PHONE { get; set; }
        public string ROUTE_UID { get; set; }
        public string STATUS { get; set; }
        public string SWITCH_FROM { get; set; }
    }

    public class vwModelHistoryShippment
    {
        public string RECORD_ID { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string CUSTOMER_SID { get; set; }
        public string REG_NO { get; set; }
        public string DESCRIPTION { get; set; }
        public string ORIGIN_CODE { get; set; }

        public string OrderGPNo1 { get; set; }
        public string OrderGPNo2 { get; set; }
        public string AllocOrderWaybillNo { get; set; }

        public string ORIGIN_NAME { get; set; }
        public string DESTINATION_CODE { get; set; }
        public string DESTINATION_NAME { get; set; }
        public string PROJECT_SID { get; set; }
        public DateTime PICKUP_DATE { get; set; }
        public DateTime PROGRESS_DATE { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public DateTime ARRIVAL_DATE { get; set; }
        public DateTime COMPLETE_DATE { get; set; }
        public DateTime DUE_DATE { get; set; }
        public DateTime EXPIRED_DATE { get; set; }
        public string DRIVER_SID { get; set; }
        public string DRIVER_PHONE { get; set; }
        //public string ROUTE_UID { get; set; }
        public string STATUS { get; set; }
        // public string SWITCH_FROM { get; set; }
        public DateTime HISTORY_DATE { get; set; }
        public string HISTORY_LOCATION { get; set; }
        //public string STATUSX { get; set; }
    }

    public class vwvwModelHistoryShippmentDetail
    {
        public string ORDER_NUMBER { get; set; }
        public string STATUS { get; set; }
        public DateTime HISTORY_DATE { get; set; }
        public string HISTORY_LOCATION { get; set; }
    }
    
}