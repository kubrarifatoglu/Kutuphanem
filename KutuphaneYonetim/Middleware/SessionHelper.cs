using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SirketYonetim.Middleware
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public void Set(string key, string value)
        {
            value = !String.IsNullOrEmpty(value) ? value : "";
            //Sessiona Kullanıcın Mail adresini atalım
            HttpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public string Get(string key)
        {
            //Sessiondan Kullanıcın Mail adresini okuyalım
            return HttpContextAccessor.HttpContext.Session.GetString(key);
        }
        public void Clear()
        {
            //Sessiondan Kullanıcın Mail adresini okuyalım
            HttpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
