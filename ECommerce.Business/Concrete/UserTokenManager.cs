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
    public class UserTokenManager : IUserTokenService
    {
        private readonly IUserTokenDal _userTokenDal;

        public UserTokenManager(IUserTokenDal userTokenDal)
        {
            _userTokenDal = userTokenDal;
        }

        public void Add(UserToken token)
        {
            _userTokenDal.Add(token);
        }

        public int GetTokenUserId(string token)
        {
            var tokenData = _userTokenDal.Get(x => x.TokenKey == token && x.Status != false);
            if (tokenData == null)
            {
                return 0;
            }
            else
            {
                return tokenData.UserId;
            }
        }

        public void TokenDisable(string token)
        {
            // token neden disable olur.
            // kullanıcı logout olmuştur.
            var tokenData = _userTokenDal.Get(x => x.TokenKey == token);
            if (tokenData != null)
            {
                tokenData.Status = false;
                _userTokenDal.Update(tokenData);
            }
        }
    }
}
