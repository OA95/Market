using FluentAssertions;
using Market.Api.Controllers;
using Market.Application.Query;
using Market.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Test
{
    public class ProductControllerTest
    {
        [Fact]
        void GetProductsTest_WhenProductFound_ReturnOk()
        {
            //arrange
            var mediator = new Mock<IMediator>();
            var controller=new ProductController(mediator.Object);

            //act
            List<Product> products = [
             new() { Id = 1, Description = "¨Pr1", Name = "Product1", Price = 2.99m }];
            mediator.Setup(m => m.Send(It.IsAny<GetAllProductQuery>(),It.IsAny< CancellationToken>())).ReturnsAsync(products);

            var result = controller.GetProducts();


            //Assert
            result.Should().NotBeNull();
        }
    }
}
