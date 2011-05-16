using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseLogicWeb.Models
{
    public class WebCookies
    {
        public void ClearCookies()
        {
            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                HttpCookie cookie = GetCookie(key);
                if (cookie != null)
                {
                    if (cookie.Name != "CLU")
                    {
                        //cookie.Expires = DateTime.Now;
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }
            }
        }

        private HttpCookie GetCookie(string Name)
        {
            HttpCookie result = null;
            if (HttpContext.Current.Request.Cookies[Name] != null)
                result = HttpContext.Current.Request.Cookies[Name];
            return result;
        }
    }
}