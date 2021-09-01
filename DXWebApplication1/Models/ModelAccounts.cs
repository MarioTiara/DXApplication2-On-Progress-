using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class ModelAccounts
    {
        public string ACCOUNT_SID { get; set; }
        public string COMPANY_SID { get; set; }
        public string DIVISION_SID { get; set; }
        public string SUBDIVISION_SID { get; set; }
        public string CUSTOMER_SID { get; set; }
        public string PROJECT_SID { get; set; }
        public string FULL_NAME { get; set; }
        public string PASSWORDZ { get; set; }
        public string EMAIL { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string ZIP { get; set; }
        public string PROVINCE { get; set; }
        public string COUNTRY { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public byte ROLE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN { get; set; }
        public string PWD { get; set; }
        public string DEFAULT_MENU { get; set; }
        public string PASS_MON { get; set; }
        public Nullable<long> LAST_ALERT_SID { get; set; }
        public byte USER_TYPE { get; set; }
        public Nullable<System.Guid> ROLE_SID { get; set; }
    }
}