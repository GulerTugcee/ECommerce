using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Helpers
{
    public class CookieHelper : ICookieHelper
    {
        public void Add(string name, string value, HttpResponse response, DateTime endDate)
        {
            try
            {
                CookieOptions options = new CookieOptions();
                options.Expires = endDate;
                response.Cookies.Append(name, value, options);
            }
            catch (Exception)
            {

                Console.WriteLine("Cookie Hata");
            }
        }

        public void Delete(string name,HttpResponse response)
        {
            Add(name, null, response, DateTime.Now.AddDays(-10));
        }

        public string Get(string name, HttpRequest request)
        {
            try
            {
                return request.Cookies[name];
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
