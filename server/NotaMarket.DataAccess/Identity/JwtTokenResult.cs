using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.DataAccess.Identity
{
    public class JwtTokenResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
