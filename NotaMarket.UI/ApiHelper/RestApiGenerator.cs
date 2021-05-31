using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.UI.ApiHelper
{
    public class RestApiGenerator : IRestApiGenerator
    {

        public async Task<T> GetApi<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                        //string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    //returnObject = JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }

        public async Task<T> PostApi<T>( object jsonContent, string url)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                   
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }

        public async Task<T> PutApi<T>( object jsonContent, string url)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                   
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }
        public async Task<T> DeleteApi<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }

    }
}
