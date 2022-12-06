using AutoMapper;
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
        [HttpGet("{id}")]
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
    }
}
