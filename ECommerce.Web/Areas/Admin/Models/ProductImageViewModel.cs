using ECommerce.Entities.Concrete;
using System.Collections.Generic;
namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductImageViewModel
    {
        public List<ProductImage> ProductImages { get; set; }
        public string Name { get; set; }
    }
}
