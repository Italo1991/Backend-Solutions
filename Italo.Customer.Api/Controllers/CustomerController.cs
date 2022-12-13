using AutoMapper;
using Italo.Customer.Api.Requests;
using Italo.Customer.Api.Responses;
using Italo.Customer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Italo.Customer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerAppService customerAppService,
            IMapper mapper)
        {
            _customerAppService = customerAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint to return customer by id
        /// </summary>
        /// <param name="id" example="1">Customer's id</param>
        /// <returns>Customer</returns>
        /// <response code="200">Customer</response>
        /// <response code="404">Customer not found</response>
        /// <response code="500">Error to get by id</response>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int id)
        {
            var customer = await _customerAppService.GetByIdAsync(id);
            if (customer == null) return NotFound();

            var customerResponse = _mapper.Map<CustomerResponse>(customer);
            return Ok(customerResponse);
        }


        /// <summary>
        /// Endpoint to add customer
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns>boolean</returns>
        /// <response code="200">boolean</response>
        /// <response code="400">Customer is invalid</response> 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> AddAsync([FromBody] CustomerRequest customerRequest)
        {
            var customerEntity = _mapper.Map<Domain.Entities.Customer>(customerRequest);
            var success = await _customerAppService.AddAsync(customerEntity);
            if (success) return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Endpoint to modify customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerModifyRequest"></param>
        /// <returns>boolean</returns>
        /// <response code="200">boolean</response>
        /// <response code="404">Customer not found</response>
        /// <response code="400">Customer is invalid</response>
        [HttpPut("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ModifyAsync([FromRoute] int id, [FromBody] CustomerRequest customerModifyRequest)
        {
            var exists = await _customerAppService.AlreadyExists(id);
            if (!exists) return NotFound();

            var customerEntity = _mapper.Map<Domain.Entities.Customer>(customerModifyRequest);
            _customerAppService.Modify(id, customerEntity);
            return Ok();
        }

        /// <summary>
        /// Endpoint to delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean</returns>
        /// <response code="200">boolean</response>
        /// <response code="404">Customer not exists</response>
        /// <response code="500">Error to delete</response>
        [HttpDelete("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            var customer = await _customerAppService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            
            _customerAppService.Delete(customer);
            return Ok();
        }
    }
}
