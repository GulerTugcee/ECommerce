using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ISettingService
    {
        string Get(string name);
        void WriteAllSettingCache();
    }
}
