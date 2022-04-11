using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public  class Brand : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
