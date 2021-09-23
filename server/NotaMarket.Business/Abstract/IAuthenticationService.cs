using NotaMarket.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotaMarket.Business.Abstract
{
    public interface IAuthenticationService
    {
        JwtSecurityToken Register();
        JwtSecurityToken Login();
    }
}
