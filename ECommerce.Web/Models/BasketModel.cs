using ECommerce.Entities.Concrete;
using System.Collections.Generic;

namespace ECommerce.Web.Models
{
    public class BasketModel
    {
        public int? UserId { get; set; }
        public string Code { get; set; }
        public List<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();
    }
    public class BasketProduct
    {
        public string GuidKey { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
