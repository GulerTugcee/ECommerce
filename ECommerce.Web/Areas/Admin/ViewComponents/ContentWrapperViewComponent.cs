using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.ViewComponents
{
    [Area("Admin")]
    public class ContentWrapperViewComponent : ViewComponent
    {
        public ContentWrapperViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
