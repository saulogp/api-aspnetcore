using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using bffapi.Dto;
using Newtonsoft.Json;

namespace bffapi.Services
{
    public class DbServices
    {
        HttpClient httpClient = new HttpClient();


        IEnumerable<ClientDto> listClient;

        IEnumerable<ProductDto> listProduct;

        public async Task<IEnumerable<ClientDto>> GetClientAsync()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5002");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync("api/Client");
            if (response.IsSuccessStatusCode)
            {
                var productString = await response.Content.ReadAsStringAsync();
                listClient = JsonConvert.DeserializeObject<IEnumerable<ClientDto>>(productString);
            }
            else
            {
                response.EnsureSuccessStatusCode();
            }
            return listClient;
        }

        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5003");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync("api/Product");
            if (response.IsSuccessStatusCode)
            {
                var productString = await response.Content.ReadAsStringAsync();
                listProduct = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(productString);
            }
            else
            {
                response.EnsureSuccessStatusCode();
            }
            return listProduct;
        }
    }
}
