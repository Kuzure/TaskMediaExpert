using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskMediaExpert.Application.CQRS.Product.Command;
using TaskMediaExpert.Application.CQRS.Product.Query;
using TaskMediaExpert.Application.Interface;
using TaskMediaExpert.Infrastructure;
using TaskMediaExpert.Infrastructure.Models;

namespace TaskMediaExpert.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> Add([FromBody] AddProductCommand command) =>
            await ExecuteCommand(async () => await Mediator.Send(command));

        [HttpGet("all")]
        [ProducesResponseType(typeof(Response<IEnumerable<ProductModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllProductList([FromQuery] GetAllProductQuery query) =>
            await ExecuteQuery(async () => await Mediator.Send(query));

        [HttpGet("pageable")]
        [ProducesResponseType(typeof(PaginationResponse<IEnumerable<ProductModel>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPageableProductList([FromQuery] GetPageableProductQuery query) =>
            await ExecuteQuery(async () => await Mediator.Send(query));
    }
}
