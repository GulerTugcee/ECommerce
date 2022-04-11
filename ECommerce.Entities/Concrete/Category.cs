using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.Entities;
namespace ECommerce.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public int Sort { get; set; }

        public bool? Status { get; set; }

        public string SeoName { get; set; }
    }
}
