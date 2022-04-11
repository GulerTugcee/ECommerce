using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class SoftDelete
    {
        public bool? IsDeleted { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedPc { get; set; }
        public string DeletedIp { get; set; }
    }
}
