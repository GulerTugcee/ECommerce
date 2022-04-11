using System.Collections.Generic;
using ECommerce.Entities.Concrete;
namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
