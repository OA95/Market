using Market.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Query
{
    public class GetAllProductQuery : IRequest<List<Product>>
    {
    }
}
