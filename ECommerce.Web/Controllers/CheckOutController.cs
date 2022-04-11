using ECommerce.Business.Abstract;
using ECommerce.Business.Helpers;
using ECommerce.Entities.Concrete;
using ECommerce.Web.Helper;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace ECommerce.Web.Controllers
{
    public class CheckOutController : Controller
    {
        ICookieHelper _cookieHelper;
        IOrderService _orderService;
        IUserTokenService _userTokenService;
        IUserService _userService;

        public CheckOutController(ICookieHelper cookieHelper, IOrderService orderService, IUserTokenService userTokenService, IUserService userService)
        {
            _cookieHelper = cookieHelper;
            _orderService = orderService;
            _userTokenService = userTokenService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            CheckOutIndexViewModel model = new CheckOutIndexViewModel();

            var code = _cookieHelper.Get("basket", Request);

            var products = BasketHelper.m.Get(code);
            if (products == null  || products.BasketProducts == null )
            {
                return RedirectToAction("index", "home");
            }
            model.basketModel = products;

            return View(model);
        }
        [HttpPost]
        public JsonResult CheckOut(string inputFirstName,string inputLastName,string inputEmail,string inputPhone,string inputAddress,string inputCity)
        {
            var code = _cookieHelper.Get("basket", Request);
            var user = _cookieHelper.Get("login", Request);
            if (string.IsNullOrEmpty(user))
            {
                return Json("Login");
            }
            var UserId = _userTokenService.GetTokenUserId(user);
            var userDetail = _userService.GetById(UserId);
            if (userDetail == null)
            {
                return Json("Login");
            }

            var products = BasketHelper.m.Get(code);
            if (products == null || products.BasketProducts == null)
            {
                return Json("Error");
            }

                Order order = new Order();
            order.Address = inputAddress;
            order.FirstName = inputFirstName; 
            order.LastName = inputLastName;
            order.Phone = inputPhone;
            order.Total = products.BasketProducts.Sum(x=>x.Quantity * x.product.Price);
            order.Date = System.DateTime.Now;
            order.City = Convert.ToInt32(inputCity);
            order.UserId = UserId;
            order.OrderDetail = JsonConvert.SerializeObject(products);

            _orderService.Add(order);

            return Json("Ok");
        }
    }
}
