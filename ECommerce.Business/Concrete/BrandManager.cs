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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMemoryCacheService _memoryCacheService;
        public BrandManager(IBrandDal brandDal, IMemoryCacheService memoryCacheService)
        {
            _brandDal = brandDal;
            _memoryCacheService = memoryCacheService;
        }
        public List<Brand> List()
        {
            var cacheResult = _memoryCacheService.Get<List<Brand>>("brand_all", null);
            if (cacheResult == null)
            {
                var list = _brandDal.List();

                _memoryCacheService.Set("brand_all", list);
                return list;
            }
            else
            {
                return cacheResult;
            }
        }
    }
}
