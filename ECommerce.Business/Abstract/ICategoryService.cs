using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> List(int parentId = 0);
        int GetById(string seoName);
    }
}
