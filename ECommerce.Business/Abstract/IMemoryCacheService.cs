using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IMemoryCacheService
    {
        T Get<T>(string key, Func<T> act);
        void Set(string key, object data);
        void Delete(string key);
        void Clear();
        void Clear(string header);

    }
}
