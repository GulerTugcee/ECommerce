using ECommerce.Business.Abstract;//using
using ECommerce.Web.Helper;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryProductService _categoryProductService;
        private readonly ICategoryService _categoryService;
        //using ECommerce.Web.Helper;
        private readonly IViewRenderService _viewRenderService;

        public CategoryController(
            ICategoryProductService categoryProductService,
            ICategoryService categoryService,
            IViewRenderService viewRenderService)
        {
            _categoryProductService = categoryProductService;
            _categoryService = categoryService;
            _viewRenderService = viewRenderService;
        }

        public IActionResult Index(string name)
        {
            int categoryId = _categoryService.GetById(name);
            var products = _categoryProductService.CategoryProducts(categoryId);
            ViewData["categoryName"] = name;
           // ViewBag.categoryName = name;
            //TempData["name"] = "ali";
            return View(new CategoryProductModel() { Products = products.Take(4).ToList() });
        }
        [HttpPost]
        public IActionResult GetProducts(string name, int page)
        {
            return View();
        }

        [HttpPost]
        public JsonResult ProductPost(string name,int page)
        {
            //ajax ile post atıldığında geri dönen değerin Json tipinde olması gerekiyor.
            // Json javascript object manasına gelir.
            // Post işleminde Json dönmek için Action methodumuzun JsonResult tipinde değer döndürmesi gerekir.,
            //nesnelerin Json olarak dönüşmesi için Json(object)
            var result = GenerateProduct(name, page);
            return Json(result); // bu aslında nesnelerimizi string tipinde json a çevirir bu sayede biz json objelerini browser tarafında yakalayabiliriz.
        }
        public string GenerateProduct(string name, int page)
        {
            int categoryId = _categoryService.GetById(name);
            int pageProductCount = 4;
            int skip = page == 1 ? pageProductCount : pageProductCount * (page + 1);
            //using System.Linq;
            var products = _categoryProductService.CategoryProducts(categoryId).Skip(skip).Take(pageProductCount).ToList();

            string html = _viewRenderService.RenderToStringAsync("Category/GetProducts",
                new CategoryProductModel() {Products = products }).Result;

            return html;

        }


    }
}
