using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Model.Interfaces
{
    public interface IResponseListModel<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
        IList<T> Response { get; set; }
    }
}
