using Microsoft.AspNetCore.Http; // cookie kullanımı için gerekli
//Nugget üzerinden sadece
//Microsoft.AspNetCore.Http
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Helpers
{
    public interface ICookieHelper
    {
        // çerezler kullanıcı browserine yazılırken Response ile yazılır.
        public void Add(string name,string value, HttpResponse response, DateTime endDate);

        public string Get(string name, HttpRequest request);
        public void Delete(string name,HttpResponse response);

        
    }
}
