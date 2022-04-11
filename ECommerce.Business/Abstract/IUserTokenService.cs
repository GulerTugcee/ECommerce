using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IUserTokenService
    {
        void Add(UserToken token);
        int GetTokenUserId(string token);
        void TokenDisable(string token);
    }
}
