using FluentAssertions;
using Market.Application.Handler;
using Market.Domain.Interfaces;
using Market.Application.Query;
using Market.Domain.Entities;
using Moq;

namespace Market.Test.Query
{
    public class GetAllProductTest
    {
        Mock<IProductRepository> _mockProducts;
        GetAllProductHandler _hendler;

        public GetAllProductTest() 
        {
            _mockProducts = new Mock<IProductRepository>();
            _hendler = new GetAllProductHandler(_mockProducts.Object);
        }

        [Fact]
        public void GetAllProductQueueHandel_WhenProductExist_ReturnListofProducts()
        {
            //Arrange
            var queryGet = new GetAllProductQuery();
            List<Product> products = [
                new() { Id = 1, Description = "¨Pr1", Name = "Product1", Price = 2.99m }];
            _mockProducts.Setup(r => r.GetAllProducts()).ReturnsAsync(products);

            //act
            var result = _hendler.Handle(queryGet,CancellationToken.None);

            //Assert
            result.Should().NotBeNull();

        }

        //public void GetAllProductQueueHandel_WhenProduxtExist_ReturnListNotNull()
    }
}
