using ECommerce.Entities.Concrete;//1111
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;//1111

namespace ECommerce.Web.ViewConponents
{
    public class ProductHtmlViewComponent : ViewComponent
    {
        public ProductHtmlViewComponent()
        {

        }
        //html tarafında gönderilen modelin viewe gönderilmesi için gerekli
        public IViewComponentResult Invoke(List<CategoryProductsView> model)
        {

            return View(model);
        }
    }
}
