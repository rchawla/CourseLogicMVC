using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CourseLogicWeb.ConfigurationService
{
    public class ConfigurationService
    {
        public static string GetRoot()
        {
            string result = "";
            if (ConfigurationManager.AppSettings["Root"] != null)
            {
                result = ConfigurationManager.AppSettings["Root"].ToString();
            }
            return result;
        }

        public static string APPLICATION_KEY()
        {
            string result = "";
            if (ConfigurationManager.AppSettings["APPLICATION_KEY"] != null)
            {
                result = ConfigurationManager.AppSettings["APPLICATION_KEY"].ToString();
            }
            return result;
        }
        public static string SECRET_KEY()
        {
            string result = "";
            if (ConfigurationManager.AppSettings["SECRET_KEY"] != null)
            {
                result = ConfigurationManager.AppSettings["SECRET_KEY"].ToString();
            }
            return result;
        }

        public static string GetDomainForEmail()
        {
            string result = "";
            if (ConfigurationManager.AppSettings["DomainForEmail"] != null)
            {
                result = ConfigurationManager.AppSettings["DomainForEmail"].ToString();
            }
            return result;
        }
    }
}