using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Caching; //-- class bazında cache oluşturmak için bu namespace eklenir.

namespace ECommerce.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        private readonly IMemoryCacheService _memoryCacheService;
        public SliderManager(ISliderDal sliderDal,IMemoryCacheService memoryCacheService)
        {
            _sliderDal = sliderDal;
            _memoryCacheService = memoryCacheService;
        }
        public List<Slider> List()
        {
           
            var cacheResult = _memoryCacheService.Get<List<Slider>>("slider_all", null);
            if (cacheResult == null)
            {
                var list = _sliderDal.List().Where(x => x.Status && x.EndDate > DateTime.Now).OrderBy(x => x.Sort).ToList();

                _memoryCacheService.Set("slider_all", list);
                return list;
            }
            else
            {
                return cacheResult;
            }
        }

    }
}
