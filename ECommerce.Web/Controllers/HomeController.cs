using ECommerce.Business.Abstract;
using ECommerce.Web.Models;
using ECommerce.Web.ViewConponents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISettingService _settingService;

        public HomeController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            var phoneNumber = _settingService.Get("phone");
            var siteSlogan = _settingService.Get("site-top-slogan");
            //
            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                TopHeaderModel = new TopHeaderModel { 
                    PhoneNumber = phoneNumber,
                    SiteSlogan = siteSlogan    
                }
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
