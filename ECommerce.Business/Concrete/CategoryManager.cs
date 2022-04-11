using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int GetById(string seoName)
        {
           var result = _categoryDal.Get(x => x.SeoName == seoName);
            if (result != null)
            {
                return result.Id;
            }
            else
            {
                return 0;
            }
        }

        public List<Category> List(int parentId = 0)
        {
            return _categoryDal.List(x => x.ParentId == parentId);
        }
    }
}
