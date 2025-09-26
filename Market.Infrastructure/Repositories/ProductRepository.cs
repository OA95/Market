using Market.Domain.Entities;
using Market.Domain.Interfaces;

namespace Market.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<List<Product>> GetAllProducts()
        {
            return
                [
                new(){Id=1,Description="¨Pr1",Name="Product1",Price=2.99m},
                new(){Id=2,Description="¨Pr2",Name="Product1",Price=2.99m},
                new(){Id=3,Description="¨Pr3",Name="Product1",Price=2.99m},
                new(){Id=4,Description="¨Pr4",Name="Product1",Price=2.99m}
                ];
        }
    }
}
