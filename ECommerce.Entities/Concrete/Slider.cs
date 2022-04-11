using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }
        public int Sort { get; set; }
    }
}
