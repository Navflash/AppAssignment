using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace phoneApp.RestClient
{
    public class RestClient<T>
    {
        private const string WebServiceUrl = "https://jsonplaceholder.typicode.com/users/";

        public async Task<List<T>> GetAsync()
        {
            var httpclient = new HttpClient();

            var json = await httpclient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
    }
}
