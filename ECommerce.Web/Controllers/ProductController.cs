using ECommerce.Business.Abstract;
using ECommerce.Business.Helpers;
using ECommerce.Web.Helper;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductImageService _productImageService;
        IProductDetailService _productDetailService;
        ICookieHelper _cookieHelper;
        IUserTokenService _userTokenService;
        IViewRenderService _viewRenderService;

        public ProductController(IProductService productService, IProductImageService productImageService, IProductDetailService productDetailService, ICookieHelper cookieHelper, IUserTokenService userTokenService, IViewRenderService viewRenderService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productDetailService = productDetailService;
            _cookieHelper = cookieHelper;
            _userTokenService = userTokenService;
            _viewRenderService = viewRenderService;
        }
        [HttpPost]
        public JsonResult AddBasket(int quantity, int productId)
        {
            string basketGuid = null;
            int userId = 0;
            var basketCookie = _cookieHelper.Get("basket", Request);
            var userCookie = _cookieHelper.Get("login", Request);
            if (userCookie != null)
            {
                var user = _userTokenService.GetTokenUserId(userCookie);
                userId = user;

            }
            if (basketCookie == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add("basket", basketGuid, Response, DateTime.Now.AddDays(11));
            }
            else
            {
                basketGuid = basketCookie;
            }
            AddBasketModel result = new AddBasketModel();
            var productDetail = _productDetailService.Get(productId);
            var productImages = _productImageService.List(productId);
            var product = _productService.Get(productId);//------------------

            BasketHelper.m.AddProduct(new BasketProduct()
            {

                GuidKey = basketGuid,
                Image = productImages.First().Name,
                ProductId = productId,
                Quantity = quantity,
                product = product
                

            }, basketGuid, userId, quantity);

            string basketHtml = _viewRenderService.RenderToStringAsync("Product/BasketMini", BasketHelper.m.Get(basketGuid)).Result;




            return Json(basketHtml);
        }

        [HttpPost]
        public JsonResult GetBasket()
        {
            string html = null;
            var basketId = _cookieHelper.Get("basket",Request);


            if (basketId != null)
            {
                var products = BasketHelper.m.Get(basketId);
                if (products == null)
                {
                    return Json(html);
                }
                html = _viewRenderService.RenderToStringAsync("Product/BasketMini", products).Result;
                return Json(html);

            }
            else
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult PlusMinusBAsketProduct(int productId,int quantity)
        {
            var basketId = _cookieHelper.Get("basket", Request);
            var product = BasketHelper.m.Get(basketId);
            var p = product.BasketProducts.FirstOrDefault(x => x.ProductId == productId);
            p.Quantity = p.Quantity + quantity;
            return Json(p.Quantity);

        }
        [HttpPost]
        public JsonResult CalculateBasket()
        {
            var basketId = _cookieHelper.Get("basket", Request);
            var product = BasketHelper.m.Get(basketId);
            return Json(product.BasketProducts.Sum(x => x.product.Price * x.Quantity).ToString("C"));

        }
        public IActionResult Index(string name)
        {
            //using ECommerce.Web.Models;
            ProductViewModel model = new ProductViewModel();
            var product = _productService.Get(name);
            var html = _productDetailService.Get(product.Id);//
            if (product != null)
            {
                model.Detail.Name = product.Name;
                model.Detail.Description = product.Description;
                model.Detail.Price = product.Price;
                model.Detail.ProductId = product.Id;
                model.Detail.DetailHtml = html == null ? "" : html.DetailHtml;//


                var productImages = _productImageService.List(product.Id);
                model.Images = productImages;
                return View(model);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
