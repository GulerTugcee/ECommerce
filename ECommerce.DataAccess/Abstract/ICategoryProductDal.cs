using ECommerce.Core.DataAccess;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICategoryProductDal : IEntityRepository<CategoryProduct>
    {
    }
}
