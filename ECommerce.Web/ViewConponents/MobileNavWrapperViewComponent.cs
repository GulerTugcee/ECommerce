using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.ViewConponents
{
    public class MobileNavWrapperViewComponent : ViewComponent
    {
        public MobileNavWrapperViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
