using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Web.ViewConponents.Models;
using Microsoft.AspNetCore.Mvc;// -----

namespace ECommerce.Web.ViewConponents
{
    public class HeaderWrapViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public HeaderWrapViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            HeaderWrapModel headerWrapModel = new HeaderWrapModel()
            {
                Categories = _categoryService.List()
            };
            return View(headerWrapModel);
        }
    }
}
