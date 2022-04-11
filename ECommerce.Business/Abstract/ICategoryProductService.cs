using ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryProductService
    {
        List<CategoryProduct> List(int categoryId);
        List<CategoryProductsView> CategoryProducts(int categoryId);
    }
}
