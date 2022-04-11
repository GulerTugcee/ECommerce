using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Abstract;
using ECommerce.Web.ViewConponents.Models;

namespace ECommerce.Web.ViewConponents
{
    public class LogoSectionViewComponent : ViewComponent
    {
        private readonly IBrandService _brandService;
        public LogoSectionViewComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IViewComponentResult Invoke()
        {
            LogoSectionModel model = new LogoSectionModel();
            model.BrandData = _brandService.List();
            return View(model);
        }
    }
}
