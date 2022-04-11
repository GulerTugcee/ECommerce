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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Product Get(string seoUrl)
        {
            return _productDal.Get(x => x.SeoName == seoUrl);
        }

        public Product Get(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }

        public List<Product> List()
        {
            return _productDal.List();
        }
    }
}
