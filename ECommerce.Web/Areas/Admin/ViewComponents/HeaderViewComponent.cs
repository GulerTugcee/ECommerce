using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class HeaderViewComponent : ViewComponent
    {
        public HeaderViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
