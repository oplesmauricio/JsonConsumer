using JsonConsumer.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonConsumer.Service
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        public async Task<Estado> GetProdutosAsync()
        {
            try
            {
                string url = "http://services.groupkt.com/state/get/USA/NY";
                var response = await client.GetStringAsync(url);
                var estados = JsonConvert.DeserializeObject<Estado>(response);
                return estados;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}