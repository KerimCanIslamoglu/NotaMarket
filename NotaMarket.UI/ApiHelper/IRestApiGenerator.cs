using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.ApiHelper
{
    public interface IRestApiGenerator
    {
        Task<T> GetApi<T>(string url);
        Task<T> PostApi<T>(object jsonContent, string url);
        Task<T> PostApiWithFile<T>(object jsonContent, string url);
        Task<T> PutApi<T>( object jsonContent, string url);
        Task<T> DeleteApi<T>(string url);
    }
}
