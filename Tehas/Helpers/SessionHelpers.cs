using System;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Tehas.Frontend.Models;

namespace Tehas.Frontend.Helpers
{
    public static class SessionHelpers
    {
        public static object Session(string key)
        {
            var obj = HttpContext.Current.Session[key];
            return obj;
        }

        //public static object Session(string key, Type responseType)
        //{
        //    var obj = HttpContext.Current.Session[key];
        //    return obj;
        //}
        public static void Session(string key, object value)
        {
            HttpContext.Current.Session.Timeout = 180;
            HttpContext.Current.Session[key] = value;
        }
        public static void Session(string key, object value, int minutes)
        {
            HttpContext.Current.Session.Timeout = minutes;
            HttpContext.Current.Session[key] = value;
        }
        public static void SessionRemoveAll()
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
        }

        public static void Cookie(string key, object value)
        {
            var jsonLoginModel = JsonConvert.SerializeObject(value);
            var strBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonLoginModel));
            var userCookie = new HttpCookie(key, strBase64);
            userCookie.Expires = userCookie.Expires.AddHours(6);
            HttpContext.Current.Response.SetCookie(userCookie);
        }
        public static object Cookie(string key, Type responseType)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie == null || cookie.Value == null) return null;
            var p = Encoding.UTF8.GetString(Convert.FromBase64String(cookie.Value));
            var res = JsonConvert.DeserializeObject(p, responseType);
            return res;
        }
        public static bool IsAuthentificated()
        {
            var obj = HttpContext.Current.Session["User"] as SessionModel;
            if (obj != null)
                return true;
            return false;
        } 
    }
}