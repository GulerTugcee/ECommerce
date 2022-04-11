using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class ProductDetail : IEntity 
    {
        public int Id{ get; set; }
        public int ProductId { get; set; }
        public string DetailHtml { get; set; }
    }
}
