using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Web.ViewConponents.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Web.ViewConponents
{
    public class CollectionTabSliderViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICategoryProductService _categoryProductService;
        private readonly IProductImageService _productImageService;
        public CollectionTabSliderViewComponent(
            ICategoryService categoryService,
            IProductService productService,
            ICategoryProductService categoryProductService,
            IProductImageService productImageService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _categoryProductService = categoryProductService;
            _productImageService = productImageService;
        }
        public IViewComponentResult Invoke()
        {
            CollectionTabSliderModel model = new CollectionTabSliderModel();
            var categories = _categoryService.List();
            model.Categories = categories; // kategorileri verdim.
            foreach (var item in categories)
            {
                var categoryProducts = _categoryProductService.List(item.Id);
                List<Product> productList = new List<Product>();//1111111
                foreach (var product in categoryProducts)
                {
                  
                    //.Value int? ile tanımlanmış olan property ler içindeki değeri almak için kullanılır. ? null bırakılabilir demektir.
                    var productDetails = _productService.Get(product.ProductId.Value);
                    productList.Add(productDetails);//222222
                    SetImage(model, productDetails.Id);//44444444444444444444
                    
                }
                model.Products.Add(item.Id, productList);//33333
            }

            return View(model);
        }
        private void SetImage(CollectionTabSliderModel model,int productId)
        {
            List<ProductImage> images = new List<ProductImage>();//--1111
            var productImages = _productImageService.List(productId);
            foreach (var item in productImages)
            {
                images.Add(item);
            }
            //using System.Linq
            if (!model.ProductImages.Any(x => x.Key == productId))
            {
                model.ProductImages.Add(productId, images);//---2222
            }
            
        }
    }
}
