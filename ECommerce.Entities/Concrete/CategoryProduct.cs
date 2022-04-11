using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class CategoryProduct : IEntity
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? CategoryId { get; set; }

        public int? Sort { get; set; }

    }
}
