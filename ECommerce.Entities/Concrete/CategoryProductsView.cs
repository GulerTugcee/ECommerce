﻿using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class CategoryProductsView : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string  Description { get; set; }
        public string SeoName { get; set; }
        public int Sort { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
