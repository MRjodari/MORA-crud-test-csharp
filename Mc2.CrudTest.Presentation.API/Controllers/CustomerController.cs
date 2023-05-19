using Mc2.CrudTest.Application.CQRS.Commands;
using Mc2.CrudTest.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mc2.CrudTest.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(
      Summary = "Save a Customer",
      Description = "Save a Customer with Details",
      OperationId = "Customer.Add",
      Tags = new[] { "CustomerController" })]
        public async Task<IActionResult> AddCustomer([FromBody] SaveCustomerCommand saveCustomerCommand)
        {
            var result = await _mediator.Send(saveCustomerCommand);
            return Ok(result);
        }

        [HttpGet("Id")]
        [SwaggerOperation(
      Summary = "Get a Customer",
      Description = "Get a Customer with id",
      OperationId = "Customer.GetById",
      Tags = new[] { "CustomerController" })]
        public async Task<IActionResult> Get([FromQuery] GetCustomerQuery getProductQuery)
        {
            return Ok(await _mediator.Send(getProductQuery));
        }

        [HttpPut("Id")]
        [SwaggerOperation(
      Summary = "Edit a Customer",
      Description = "Update a Customer with id",
      OperationId = "Customer.EditById",
      Tags = new[] { "CustomerController" })]
        public async Task<IActionResult> EditCustomer([FromQuery] EditCustomerCommand editCustomerCommand)
        {
            return Ok(await _mediator.Send(editCustomerCommand));
        }

    }
}
