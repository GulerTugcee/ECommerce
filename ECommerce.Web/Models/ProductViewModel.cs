using ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace ECommerce.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Detail = new ProductDetail();
            Images = new List<ProductImage>();
        }
        public ProductDetail Detail { get; set; }
        public List<ProductImage> Images { get; set; }
    }
    public class ProductDetail
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string DetailHtml { get; set; }
        public int ProductId { get; internal set; }
    }
}
