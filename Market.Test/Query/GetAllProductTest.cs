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

        [Fact]
        public void GetAllProductQueueHandel_WhenProductExist_ReturnListofProducts()
        {
            //Arrange
            var mockProducts = new Mock<IProductRepository>();
            var hendler= new GetAllProductHandler(mockProducts.Object);


            //act
            var queryGet = new GetAllProductQuery();

            List<Product> products = [
                new() { Id = 1, Description = "¨Pr1", Name = "Product1", Price = 2.99m }];
                
            mockProducts.Setup(r => r.GetAllProducts()).ReturnsAsync(products);

            var result = hendler.Handle(queryGet,CancellationToken.None);

            //Assert
            result.Should().NotBeNull();

        }

        //public void GetAllProductQueueHandel_WhenProduxtExist_ReturnListNotNull()
    }
}
