using TpMobileStore.Models;

namespace TpMobileStore.Services
{
    public interface IAPIService
    {
        public Task<List<Product>> Get();
        public Task<Product> GetById(int id);
        //public void Add(string element);
    }
}