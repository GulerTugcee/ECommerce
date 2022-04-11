using ECommerce.Core.Entities;
using System.Linq.Expressions; //-----
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DataAccess
{
    //IEntityRepository aslında db deki tablolarda işlem yapmak için kullanacağımız methodları temsil eder.
    //Ama temsil edeceği tablolar birbirinden çok farklı olduğundan her seferinde her tablo için bir interface yazamayız onun yerine IEntityRepository generik olarak her tablo için şekillenecek biçimde ayarlanabilir.
    //<TTablo> aslında bu interface nin alacağı şekildir.Yani Tablo yerine herşey yazılabilir herşey derken kurallara uymalıdır.
    public interface IEntityRepository<TTablo> where TTablo : class, IEntity, new()
    {
        TTablo Get(Expression<Func<TTablo,bool>> filter);
        List<TTablo> List(Expression<Func<TTablo, bool>> filter = null);
        IQueryable<TTablo> Query(Expression<Func<TTablo, bool>> filter);
        void Add(TTablo entity);
        void Update(TTablo entity);
        void Delete(TTablo entity);
        bool Any(Expression<Func<TTablo, bool>> filter);

    }
}
