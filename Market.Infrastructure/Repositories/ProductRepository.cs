using Market.Domain.Entities;
using Market.Domain.Interfaces;
using Market.Infrastructure.Data;

namespace Market.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        MarketDBContext _marketDB;

        public ProductRepository (MarketDBContext marketDB)
        {
            _marketDB = marketDB;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            var products = _marketDB.Products.ToList();
            return products ;
            //return 
            //    [
            //    new(){Id=1,Description="¨Pr1",Name="Product1",Price=2.99m},
            //    new(){Id=2,Description="¨Pr2",Name="Product2",Price=2.99m},
            //    new(){Id=3,Description="¨Pr3",Name="Product3",Price=2.99m},
            //    new(){Id=4,Description="¨Pr4",Name="Product4",Price=2.99m}
            //    ];
        }
    }
}
