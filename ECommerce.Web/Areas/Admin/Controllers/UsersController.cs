using ECommerce.Business.Abstract;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Entities.Concrete;
using ECommerce.Business.Helpers;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        IUserService _userservice;
        IUserTokenService _userTokenservice;
        ICookieHelper _cookieHelper;

        public UsersController(IUserService userservice, ICookieHelper cookieHelper, IUserTokenService userTokenservice)
        {
            _userservice = userservice;
            _cookieHelper = cookieHelper;
            _userTokenservice = userTokenservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            UsersListViewModel usersListViewModel = new UsersListViewModel();
            usersListViewModel.UserList = _userservice.List();
            return View(usersListViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserAddModel userAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userAddModel);
            }
            else
            {
                User user = new User
                {
                    Email = userAddModel.Email,
                    IsAdmin = userAddModel.IsAdmin,
                    Password = userAddModel.Password,
                    Status = userAddModel.Status
                };
                _userservice.Add(user);
                return RedirectToAction("List");
            }
        }

        public IActionResult Edit(int id)
        {
            var user = _userservice.GetById(id);
            if (user != null)
            {
                UserEditModel userEditModel = new UserEditModel
                {
                    Email = user.Email,
                    IsAdmin = user.IsAdmin.Value,
                    Status = user.Status.Value,
                    Id = user.Id
                };
            }
            else
            {
                TempData["error"] = "Kullanıcı Bulunamadı";
                RedirectToAction("List");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UserEditModel userEditModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userEditModel);
            }
            else
            {
                User user = new User
                {
                    Email = userEditModel.Email,
                    IsAdmin = userEditModel.IsAdmin,
                    Password = userEditModel.Password,
                    Status = userEditModel.Status,
                    Id = userEditModel.Id
                };
                _userservice.Edit(user);
                return RedirectToAction("List");
            }
        }
        public IActionResult Remove(int id)
        {
            var cookie = _cookieHelper.Get("AdminLogin", Request);
            if (cookie != null)
            {
                return RedirectToAction("List");
            }
            var adminUserId = _userTokenservice.GetTokenUserId(cookie);

            var user = _userservice.GetById(id);
            user.DeleteUser = adminUserId;
            user.DeletedIp = Request.Host.Value;
            user.DeletedPc = Request.Headers["REMOTE_HOST"];
            user.DeletedDate = System.DateTime.Now;
            user.IsDeleted = true;

            _userservice.Delete(user);

            return RedirectToAction("List");
        }
    }
}
