using ECommerce.Business.Abstract;
using ECommerce.Business.Helpers;
using ECommerce.Entities.Concrete;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IUserService _userService;
        private readonly IUserTokenService _userTokenService;
        // LoginController program tarafından kullanıldığı anda
        // Dependenjy tool bu Interface yi IUserService görüyor ve kendisindeki configurasyona göre
        //  services.AddScoped<IUserService, UserManager>();
        // IUserService istentiğinde bize UserManager ornekleyip veriyor.
        private readonly ICookieHelper _cookieHelper;
        public HomeController(IUserService userService, IUserTokenService userTokenService, ICookieHelper cookieHelper)
        {
            _userService = userService;
            _userTokenService = userTokenService;
            _cookieHelper = cookieHelper;
        }
            [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult Index(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model.Email, model.Password,true);
                if (result == null)
                {
                    ModelState.AddModelError("LoginError", "Giriş Başarısız.");
                }
                else
                {
                    // token oluştur
                    //_UserTokenServis ile bir token oluşturun.
                    // Google c# guid key nasıl oluşturulur.
                    UserToken userToken = new UserToken();
                    userToken.Status = true;
                    userToken.TokenKey = Guid.NewGuid().ToString();
                    userToken.UserId = result.Id;
                    userToken.CreateDate = DateTime.Now;

                    _userTokenService.Add(userToken);

                    _cookieHelper.Add("AdminLogin", userToken.TokenKey, Response, DateTime.Now.AddMonths(12));

                    //cookie çerez işlemlerini yapmalıyız.
                    return RedirectToAction("Index", "DashBoard");
                }
            }

            
            return View(model);
        }
    }
}
