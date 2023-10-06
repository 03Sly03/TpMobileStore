using TpMobileStore.Models;

namespace TpMobileStore.Services
{
    public interface IAPIService
    {
        public Task<List<Product>> Get();
        //public void Add(string element);
    }
}