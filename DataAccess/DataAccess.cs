using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class DataAccess
    {

        public static string CommandText { get; set; }

        public static string GetCommandText(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(fileName);
            return new StringBuilder(System.IO.File.ReadAllText(path).ToString()).ToString();
        }

        public static string GetCommandText(string fileName, string tableName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(fileName);
            return new StringBuilder(System.IO.File.ReadAllText(path).Replace("%TABLE%", tableName)).ToString();
        }

        public static string GetCommandProcedure(string cmdText, string procName, string tableID)
        {
            string tableName = "WP_" + tableID.Replace("-", "");
            procName = procName.Replace("%WP_TAB%", tableName);
            cmdText = cmdText.Replace("%WP_TAB%", tableName);
            return cmdText.Replace("%PROC_NAME%", procName);
        }
    }
}
