using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Model
{
    public class IdentityResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
