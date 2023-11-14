using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataBaseKursRabota.Repositories
{
    public class Server
    {
        private static Server instance;

        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Server();
                }
                return instance;
            }
        }

        public string GetRequest(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var endpoint = new Uri($"http://127.0.0.1:8000/{url}");
                var response = httpClient.GetAsync(endpoint).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public System.Net.HttpStatusCode PostRequest(string url, StringContent payload)
        {
            using (var httpClient = new HttpClient())
            {
                var endpoint = new Uri($"http://127.0.0.1:8000/{url}");

                var result = httpClient.PostAsync(endpoint, payload).Result.StatusCode;
                return result;
            }
        }

        public async Task<System.Net.HttpStatusCode> PostRequestAsync(string url, HttpContent payload)
        {
            using (var httpClient = new HttpClient())
            {
                var endpoint = new Uri($"http://127.0.0.1:8000/{url}");

                var result = await httpClient.PostAsync(endpoint, payload);
                return result.StatusCode;
            }
        }

        public System.Net.HttpStatusCode DeleteRequest(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var endpoint = new Uri($"http://127.0.0.1:8000/{url}");

                var result = httpClient.DeleteAsync(endpoint).Result.StatusCode;
                return result;
            }
        }

        public static StringContent GetPayload<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
