using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.ApiHelper
{
    public interface IRestApiGenerator<T>
    {
        Task<T> GetApi(T returnObject, string url);
        Task<T> PostApi(T returnObject, T jsonContent, string url);
        Task<T> PutApi(T returnObject, T jsonContent, string url);
        Task<T> DeleteApi(T returnObject, string url);
    }
}
