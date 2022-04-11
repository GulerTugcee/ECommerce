using ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace ECommerce.Web.ViewConponents.Models
{
    public class CollectionTabSliderModel
    {
        public CollectionTabSliderModel()
        {
            Categories = new List<Category>();
            Products = new Dictionary<int, List<Product>>();
            ProductImages = new Dictionary<int, List<ProductImage>>();
        }
        public List<Category> Categories { get; set; }
        public Dictionary<int,List<Product>> Products { get; set; }
        public Dictionary<int,List<ProductImage>> ProductImages { get; set; }
    }
}
