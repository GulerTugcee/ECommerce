using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;
namespace ECommerce.Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> List();
    }
}
