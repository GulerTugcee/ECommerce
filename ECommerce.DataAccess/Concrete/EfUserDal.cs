using ECommerce.Core.DataAccess;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, EcommerceContext>, IUserDal //EfEntityRepositoryBase den kalıtım almak zorundadur ki User tablosu üzerince CRUD işlemleri için methodları generic olarak oluştursun
    {
        // burada bir istisna var eğer EfEntityRepositoryBase harici bir işlem yapılacaksa o method IUserDal içerisine eklenir ve burada method yazılır. //BUNU VİDEODA KULLANMAYIN
    }
}
