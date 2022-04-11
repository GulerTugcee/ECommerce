using ECommerce.Business.Abstract;
using ECommerce.Business.Helpers;
using ECommerce.Web.ViewConponents.Models;//using 2
using Microsoft.AspNetCore.Mvc; // using
using Microsoft.AspNetCore.Mvc.ViewComponents;
namespace ECommerce.Web.ViewConponents
{
    public class TopHeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly ICookieHelper _cookieHelper;
        private readonly IUserTokenService _userTokenService;
        private readonly IUserService _userService;
        public TopHeaderViewComponent(ISettingService settingService, ICookieHelper cookieHelper, IUserTokenService userTokenService,IUserService userService)
        {
            _settingService = settingService;
            _cookieHelper = cookieHelper;
            _userTokenService = userTokenService;
            _userService = userService;

        }
        public IViewComponentResult Invoke()
        {
            var phoneNumber = _settingService.Get("phone");
            var siteSlogan = _settingService.Get("site-top-slogan");

            var userCookie = _cookieHelper.Get("login", Request);

            TopHeaderModel model = new TopHeaderModel();
            model.PhoneNumber = phoneNumber;
            model.SiteSlogan = siteSlogan;
            if (userCookie != null)
            {
                var userId = _userTokenService.GetTokenUserId(userCookie);
                if (userId != 0)
                {
                    var userDetail = _userService.GetById(userId);
                    if (userDetail != null)
                    {
                        model.IsLogin = true;
                        model.Name = userDetail.Email;
                        model.Id = userDetail.Id.ToString();
                    }
                }
            }


            return View(model);
        }
    }
}
