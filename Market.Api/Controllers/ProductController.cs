using Market.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;
       public ProductController(IMediator mediator)
       {
            _mediator = mediator;
       }

        [HttpGet]
        public  async Task<IActionResult> GetProducts()
        {
            var query = new GetAllProductQuery();
            var products = _mediator.Send(query);
            return Ok(products);
        }
    }
}
