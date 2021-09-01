using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DXWebApplication1.Models
{
    public class GetCustomer
    {
        public string PROJECT_NAME { get; set; }
        public string PROJECT_NO { get; set; }
        //public GetCustomer(DataRow row)
        //{

        //    CUSTOMER_NAME = row["CUSTOMER_NAME"].ToString();
        //    CUSTOMER_NO = row["CUSTOMER_NO"].ToString();
        //}
    }

    public class GetCustomerProject
    {
        public string PROJECT_NAME { get; set; }
        public string CUSTOMER_SID { get; set; }
        public string PROJECT_NO { get; set; }
       
        //public GetCustomerProject(DataRow row)
        //{
        //    PROJECT_NAME = row["PROJECT_NAME"].ToString();
        //    CUSTOMER_SID = row["CUSTOMER_SID"].ToString();
        //    PROJECT_NO = row["PROJECT_NO"].ToString();
        //}
    }
    public class GetProjectNo
    {
        public string PROJECT_NO { get; set; }
        //public GetProjectNo(DataRow row)
        //{
        //    PROJECT_NO = row["PROJECT_NO"].ToString();

        //}

    }
}