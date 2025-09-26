using Market.Domain.Interfaces;
using Market.Application.Query;
using Market.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Handler
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        IProductRepository _productRepository;

        public GetAllProductHandler(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
           return _productRepository.GetAllProducts();
        }
    }
}
