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
    public class CategoryProductManager : ICategoryProductService
    {
        private readonly ICategoryProductDal _categoryProductDal;
        private readonly IProductDal _productDal;
        private readonly IProductImageDal _productImageDal;

        public CategoryProductManager(ICategoryProductDal categoryProductDal, IProductDal productDal, IProductImageDal productImageDal)
        {
            _categoryProductDal = categoryProductDal;
            _productDal = productDal;
            _productImageDal = productImageDal;
        }

        public List<CategoryProductsView> CategoryProducts(int categoryId)
        {
            List<CategoryProductsView> result = new List<CategoryProductsView>();
            var categoryProduct = _categoryProductDal.List(x => x.CategoryId == categoryId);
            for (int i = 0; i < categoryProduct.Count; i++)
            {
                var product = _productDal.Get(x => x.Id == categoryProduct[i].ProductId);//şuuuu
                var productImage = _productImageDal.List(x => x.ProductId == categoryProduct[i].ProductId);
                result.Add(new CategoryProductsView()
                {
                    CategoryId = categoryId,
                    Description = product.Description,
                    Id = categoryProduct[i].Id,
                    Name = product.Name,
                    Price = product.Price,
                    SeoName = product.SeoName,
                    Sort = categoryProduct[i].Sort.Value,
                    ProductImages = productImage
                });
            }

            return result;

        }

        public List<CategoryProduct> List(int categoryId)
        {
            return _categoryProductDal.List(x => x.CategoryId == categoryId).OrderBy(x => x.Sort).ToList();
        }
    }
}
