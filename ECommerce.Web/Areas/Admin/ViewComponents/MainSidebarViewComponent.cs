using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class MainSidebarViewComponent : ViewComponent
    {
        public MainSidebarViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
