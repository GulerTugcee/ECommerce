using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class SettingManager : ISettingService
    {
        private readonly ISettingDal _settingDal;
        private readonly IMemoryCacheService _memoryCacheService;//1
        public SettingManager(ISettingDal settingDal,IMemoryCacheService memoryCacheService)//1
        {
            _settingDal = settingDal;
            _memoryCacheService = memoryCacheService;//1
        }

        public string Get(string name)
        {
            var cacheResult = _memoryCacheService.Get<Setting>("setting_" + name, null);

            if (cacheResult == null)
            {
                var result = _settingDal.Get(x => x.Name == name);//2
                _memoryCacheService.Set("setting_" + name, result);//2
                return result.Value;
            }
            else
            {
                return cacheResult.Value;
            }

        }

        public void WriteAllSettingCache()
        {
            var allSettings = _settingDal.List();
            foreach (var setting in allSettings)
            {
                _memoryCacheService.Delete("setting_" + setting.Name);
                _memoryCacheService.Set("setting_" + setting.Name, setting);
            }
        }
    }
}
