using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _productImageDal;
        //ctor TAB TAB
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        public List<ProductImage> List(int productId = 0)
        {
            if (productId > 0)
            {
                return _productImageDal
                        .List(x => x.ProductId == productId)
                        .OrderBy(x => x.Sort)
                        .ToList(); 
            }
            return _productImageDal.List();
        }
    }
}
