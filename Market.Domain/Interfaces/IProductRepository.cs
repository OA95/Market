using Market.Domain.Entities;

namespace Market.Domain.Interfaces
{
    public interface IProductRepository
    {
        public  Task<List<Product>> GetAllProducts();

    }
}
