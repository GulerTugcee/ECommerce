using ECommerce.Business.Abstract;
using ECommerce.Business.Helpers;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;//----
namespace ECommerce.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IStringHelpers _stringHelpers;

        public UserManager(IUserDal userDal, IStringHelpers stringHelpers)
        {
            _userDal = userDal;
            _stringHelpers = stringHelpers;
        }

        public void Add(User user)
        {
            user.Password=_stringHelpers.ToMd5(user.Password);
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
           
            _userDal.Update(user);
            
           
        }

        public void Edit(User user)
        {
           user.Password = _stringHelpers.ToMd5(user.Password);
            _userDal.Update(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(x => x.Id == userId);
        }

        public List<User> List()
        {
            return _userDal.List();
        }

        public User Login(string username, string password)
        {
            password = _stringHelpers.ToMd5(password);
            // db de tutulan şifre md5 şifrelenmiş oılduğundan bir method ile bunu md5 e çevirdik.
            return _userDal.Query(x => x.Email == username && x.Password == password).FirstOrDefault();
        }

        public User Login(string username, string password, bool adminLogin)
        {
            password = _stringHelpers.ToMd5(password);
            return _userDal.Query(x => x.Email == username && x.Password == password && x.IsAdmin == true).FirstOrDefault();

        }

       
    }
}
