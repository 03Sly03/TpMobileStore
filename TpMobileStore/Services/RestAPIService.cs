using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TpMobileStore.Models;

namespace TpMobileStore.Services
{
    public class RestAPIService : IAPIService
    {
        private HttpClient httpClient;

        public RestAPIService()
        {
            httpClient = new HttpClient();
            //Ne pas oublier d'autoriser le trafic en clear dans le manifest android (pour ios, ...)
            httpClient.BaseAddress = new Uri("https://fakestoreapi.com/");
        }
        //public void Add(string element)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<Product>> Get()
        {
            List<Product> datas = await httpClient.GetFromJsonAsync<List<Product>>("products");
            return datas;
        }

        //public async Task<Product> GetById(int id)
        //{
        //    Product product = await httpClient.GetFromJsonAsync<Product>("products/" + id);
        //    return product;
        //}
    }
}
