using ECommerce.Core.DataAccess;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;

namespace ECommerce.DataAccess.Concrete
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, EcommerceContext>, IBrandDal
    {

    }
}
