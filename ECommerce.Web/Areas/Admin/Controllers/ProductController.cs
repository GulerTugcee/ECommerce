using ECommerce.Business.Abstract;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductImageService _productImageService;

        public ProductController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public IActionResult Index()
        {
            var product = _productService.List();
            ProductListViewModel productListViewModel = new ProductListViewModel();
            productListViewModel.ProductImages = _productImageService.List();
            productListViewModel.Products = product;

            return View(productListViewModel);
        }
        public IActionResult Images(int id)
        {
            var productImages = _productImageService.List(id);
            ProductImageViewModel productImageViewModel = new ProductImageViewModel();
            productImageViewModel.ProductImages = productImages;
            productImageViewModel.Name = _productService.Get(id).Name;
            productImageViewModel.ProductImages = productImages;

            return View(productImageViewModel);
        }
        public IActionResult ImageUpload(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString()+".jpg";
            if (file != null)
            {
                var upload = Path.Combine();
            }
            return View();
        }
    }
}
