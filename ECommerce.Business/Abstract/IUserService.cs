using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IUserService
    {
        User Login(string username, string password);
        User Login(string username, string password,bool adminLogin);
        User GetById(int userId);
        List<User> List();
        void Add(User user);
        void Edit(User user);
        void Delete(User user);
        
    }
}
