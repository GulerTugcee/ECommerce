using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class FooterViewComponent : ViewComponent
    {
        public FooterViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
