using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.UI.ApiHelper
{
    public class RestApiGenerator<T> : IRestApiGenerator<T> where T : class
    {

        public async Task<T> GetApi(T returnObject, string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        returnObject = JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                }
            }

            return returnObject;
        }

        public async Task<T> PostApi(T returnObject, T jsonContent, string url)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        returnObject = JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                }
            }

            return returnObject;
        }

        public async Task<T> PutApi(T returnObject, T jsonContent, string url)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        returnObject = JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                }
            }

            return returnObject;
        }
        public async Task<T> DeleteApi(T returnObject, string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnObject = JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

            return returnObject;
        }

    }
}
