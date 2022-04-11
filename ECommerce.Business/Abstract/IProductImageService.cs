using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductImageService
    {
        // urun resmi productId değerine göre gelmelidir.
        List<ProductImage> List(int productId = 0);
    }
}
