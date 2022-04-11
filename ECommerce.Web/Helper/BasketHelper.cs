using ECommerce.Web.Models;
using System.Linq;

namespace ECommerce.Web.Helper
{
    //singleton desing pattern

    public class BasketHelper
    {
        static BasketHelper obj = new BasketHelper();
        public static BasketHelper m
        {
            get
            {
                return obj;
            }
        }

        public void Create(BasketModel basketItem)
        {
            Program.basket.Add(basketItem);
        }
        public void AddProduct(BasketProduct product, string code, int userId,int quantity)
        {
            var basket = Program.basket.Where(x => x.Code == code).FirstOrDefault();
            if (basket == null)
            {
                var newBasket = new BasketModel()
                {
                    Code = code,
                    UserId = userId
                };
                Create(newBasket);
                newBasket.BasketProducts.Add(product);

            }
            else
            {
                if (basket.BasketProducts.Any(x => x.ProductId == product.ProductId))
                {
                    var basketProduct = basket.BasketProducts.FirstOrDefault(x => x.ProductId.Equals(product.ProductId));
                    basketProduct.Quantity += quantity;//buuuuuuuuuuu
                }
                else
                {
                    basket.BasketProducts.Add(product);
                }
              
            }
        }

        public BasketModel Get(string code)
        {
            return Program.basket.FirstOrDefault(x => x.Code == code);
        }
    }
}
