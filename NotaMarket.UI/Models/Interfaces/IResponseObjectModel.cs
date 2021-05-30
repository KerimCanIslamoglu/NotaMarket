using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Interfaces
{
    public interface IResponseObjectModel<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
        T Response { get; set; }
    }
}
