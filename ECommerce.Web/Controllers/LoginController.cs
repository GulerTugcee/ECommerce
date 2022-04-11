using Microsoft.AspNetCore.Mvc;
using ECommerce.Web.Models;//-----------------
using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.DataAccess.Concrete;
using ECommerce.Business.Helpers;
using ECommerce.Entities.Concrete;
using System;
using ECommerce.Web.Helper;

namespace ECommerce.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTokenService _userTokenService;
        // LoginController program tarafından kullanıldığı anda
        // Dependenjy tool bu Interface yi IUserService görüyor ve kendisindeki configurasyona göre
        //  services.AddScoped<IUserService, UserManager>();
        // IUserService istentiğinde bize UserManager ornekleyip veriyor.
        private readonly ICookieHelper _cookieHelper;
        public LoginController(IUserService userService, IUserTokenService userTokenService, ICookieHelper cookieHelper)
        {
            _userService = userService;
            _userTokenService = userTokenService;
            _cookieHelper = cookieHelper;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Anotation
        [HttpPost]// Login/Index POST
        public IActionResult Index(LoginViewModel model)
        {
            // LoginViewModel bize gelen datanın validation işleminden geçip geçmediğinin kontrolü yapılır.Geçti ise true geçemedi ise false değeri fırlatır.
            if (ModelState.IsValid)
            {
                var result = _userService.Login(model.Email, model.Password);
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

                    _cookieHelper.Add("login", userToken.TokenKey, Response, DateTime.Now.AddMonths(12));

                    //cookie çerez işlemlerini yapmalıyız.
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
          
            // login silmek istediğimiz cookie adı
            var cookie = _cookieHelper.Get("login", Request);
            //tokendeki değeri disable edersek kullanıcıda çıkış yapmış olur
            _userTokenService.TokenDisable(cookie);
            return View("Index");// cookie silme sonrası bu loginconrtroller içerisindeki Index actionu çağırılır.
        }
    }
}
